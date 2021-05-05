using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DecerixUPC.Libraries
{
    class AsterixFile
    {
 
        List<string[]> listhex = new List<string[]>();
        List<CAT10> listCAT10 = new List<CAT10>();
        List<CAT21> listCAT21 = new List<CAT21>();
        public DataTable tablaCAT10 = new DataTable();


        public List<CAT10> getListCAT10()
        {
            return listCAT10;
        }
        public List<CAT21> getListCAT21()
        {
            return listCAT21;
        }

        public List<string[]> getHex()
        {
            return listhex;
        }
        private static string ToHex(byte[] bytes)
        {
            char[] c = new char[bytes.Length * 2];

            byte b;

            for (int bx = 0, cx = 0; bx < bytes.Length; ++bx, ++cx)
            {
                b = ((byte)(bytes[bx] >> 4));
                c[cx] = (char)(b > 9 ? b + 0x37 + 0x20 : b + 0x30);

                b = ((byte)(bytes[bx] & 0x0F));
                c[++cx] = (char)(b > 9 ? b + 0x37 + 0x20 : b + 0x30);
            }

            return new string(c);
        }
        public void read(string path)
        {
            StartTable10();
            // Load file to RAM
            byte[] fileBytes = File.ReadAllBytes(path);
            // New Version Improvement by 0.673ms@4Ghz and 150MB ram usage only
            // Go over all of the packets and store them in a separate list of lists
            // First Octet Category
            List<Byte> fileBytesList = fileBytes.ToList();
            // 2nd*256 + 3rd Octet = Length in Bytes
            int messageCategory = fileBytes[0];
            int messageLength; // 2nd*256 + 3rd Octet
            List<List<Byte>> messages = new List<List<Byte>>();
            List<String[]> messagesHex = new List<String[]>();
            List<String[]> messagesBinary = new List<String[]>();
            List<int> messagesLengths = new List<int>();
            // Store messages from the fileBytes into packet size Blocks using messageLength
            int currPointer = 0;
            int lengthFile = fileBytesList.Count;
            List<Byte> message;
            List<string> messageHex = new List<string>();
            List<string> messageBinary = new List<string>();
            while ((currPointer + 1) < lengthFile)
            {
                messageLength = (fileBytes[currPointer + 1] * 256) + fileBytes[currPointer + 2];
                message = fileBytesList.GetRange(currPointer, messageLength);

                // Convert Message Byte to Messages of Hexadecimal
                messagesBinary.Add(message.Select(x => Convert.ToString(x, 2).PadLeft(8, '0')).ToArray());
                message.ForEach((b) =>
                {
                    messageHex.Add(b.ToString("X"));

                });
                // Store the Message and Message in Hex
                messages.Add(message); // (currentMessageByte)-LastByteIncluded
                messagesHex.Add(messageHex.ToArray());
                messageHex.Clear();
                messagesLengths.Add(messageLength);
                currPointer += messageLength;
            }

            // Messages separated --> Now we have to convert them according to CAT 10 or CAT 21
            HelpDecode decode = new HelpDecode();
            // To improve performance, just 1 object generated. For entire list
            CAT10Helper cat10Helper = new CAT10Helper(ref decode);
            CAT21Helper cat21Helper = new CAT21Helper(ref decode);
            //List<CAT10> arrCat10 = new List<CAT10>[listhex.Count];
            List<CAT10> arrCat10 = new List<CAT10>();
            List<CAT21> arrCat21 = new List<CAT21>();
            /*CAT10 newcat10 = new CAT10(decode, cat10Helper); */
            string[] arraystring;
            /*CAT21v21 newcat21 = new CAT21v21(decode, cat10Helper);*/
            CAT10 temp10;
            for (int q = 0; q < messagesHex.Count; q++)
            {
                arraystring = messagesHex[q];
                /*int CAT = int.Parse(arraystring[0], System.Globalization.NumberStyles.HexNumber);*/

                if (arraystring[0] == "A")
                {
                    temp10 = new CAT10(ref decode, ref cat10Helper, arraystring, q, messagesBinary[q]);
                    arrCat10.Add(temp10);
                    AddRowTable10(temp10);
                }
                else if (arraystring[0] == "15")
                {
                    arrCat21.Add(new CAT21(ref decode, ref cat21Helper, arraystring, q, messagesBinary[q]));
                }
            }
            string a = ";";
        }


        public void AddRowTable10(CAT10 Message)
        {
            var row = tablaCAT10.NewRow();
            row["Number"] = Message.Id;
            row["Category"] = "10";
            if (Message.SAC != null) { row["SAC"] = Message.SAC; }
            else { row["SAC"] = "No Data"; }
            if (Message.SIC != null) { row["SIC"] = Message.SIC; }
            else { row["SIC"] = "No Data"; }
            if (Message.TAR != null)
            {
                if (Message.TAR.Replace(" ", "") != "") { row["Target\nIdentification"] = Message.TAR; }
                else { row["Target\nIdentification"] = "No Data"; }
            }
            else { row["Target\nIdentification"] = "No Data"; }
            if (Message.TYP != null) { row["Target\nReport\nDescriptor"] = "Click to expand"; }
            else { row["Target\nReport\nDescriptor"] = "No Data"; }
            if (Message.messageType != null) { row["Message Type"] = Message.messageType; }
            else { row["Message Type"] = "No Data"; }
            if (Message.FlightLevel != null) { row["Flight Level"] = Message.FlightLevel; }
            else { row["Flight Level"] = "No Data"; }
            if (Message.TrackNumber != null) { row["Track\nNumber"] = Message.TrackNumber; }
            else { row["Track\nNumber"] = "No Data"; }
            if (Message.TimeOfDay != null) { row["Time of\nDay"] = Message.TimeOfDay; }
            else { row["Time of\nDay"] = "No Data"; }
            if (Message.CNF != null) { row["Track Status"] = "Click to expand"; }
            else { row["Track Status"] = "No Data"; }
            if (Message.LatitudeWGS_84 != null && Message.LongitudeWGS_84 != null) { row["Position in WGS-84 Co-ordinates"] = Message.LatitudeWGS_84 + ", " + Message.LongitudeWGS_84; }
            else { row["Position in WGS-84 Co-ordinates"] = "No Data"; }
            if (Message.X_Component != null) { row["Position in\nCartesian\nCo-ordinates"] = Message.X_Component + " - " + Message.Y_Component; }
            else { row["Position in\nCartesian\nCo-ordinates"] = "No Data"; }
            if (Message.Position_In_Polar != null) { row["Position in\nPolar\nCo-ordinates"] = Message.Position_In_Polar; }
            else { row["Position in\nPolar\nCo-ordinates"] = "No Data"; }
            if (Message.GroundSpeed != null) { row["Track Velocity in Polar Coordinates"] = Message.GroundSpeed + Message.TrackAngle; }
            else { row["Track Velocity in Polar Coordinates"] = "No Data"; }
            if (Message.Vx != null) { row["Track Velocity in\nCartesian\nCoordinates"] = Message.Vx +"-"+ Message.Vy; }
            else { row["Track Velocity in\nCartesian\nCoordinates"] = "No Data"; }
            if (Message.WIDTH != null) { row["Target Size\nand\nOrientation"] = Message.LENGHT+","+Message.ORIENTATION+","+ Message.WIDTH; }
            else { row["Target Size\nand\nOrientation"] = "No Data"; }
            if (Message.TargetAddress != null) { row["Target\nAddress"] = Message.TargetAddress; }
            else { row["Target\nAddress"] = "No Data"; }
            if (Message.NOGO != null) { row["System\nStatus"] = "Click to expand"; }
            else { row["System\nStatus"] = "No Data"; }
            if (Message.VFI != null) { row["Vehicle Fleet\nIdentification"] = Message.VFI; }
            else { row["Vehicle Fleet\nIdentification"] = "No Data"; }
            
            if (Message.MeasuredHeight != null) { row["Measured\nHeight"] = Message.MeasuredHeight; }
            else { row["Measured\nHeight"] = "No Data"; }
            if (Message.Mode3A != null) { row["Mode-3A\nCode"] = Message.Mode3A; }
            else { row["Mode-3A\nCode"] = "No Data"; }
            if (Message.MBData != null) { row["Mode S MB\nData"] = "Click to expand"; }
            else { row["Mode S MB\nData"] = "No Data"; }
            if (Message.DeviationX != null) { row["Standard\nDeviation\nof Position"] = "Click to expand"; }
            else { row["Standard\nDeviation\nof Position"] = "No Data"; }
            if (Message.REP != 0) { row["Presence"] = "Click to expand"; }
            else { row["Presence"] = "No Data"; }
            if (Message.PAM != null) { row["Amplitude\nof Primary\nPlot"] = Message.PAM; }
            else { row["Amplitude\nof Primary\nPlot"] = "No Data"; }
            if (Message.Ax != null) { row["Calculated\nAcceleration"] = Message.Ax + " " + Message.Ay; }
            else { row["Calculated\nAcceleration"] = "No Data"; }
            tablaCAT10.Rows.Add(row);
        }
        public void StartTable10()
        {
            tablaCAT10.Columns.Add("Number");
            tablaCAT10.Columns.Add("Category");
            tablaCAT10.Columns.Add("SAC");
            tablaCAT10.Columns.Add("SIC");

            tablaCAT10.Columns.Add("Target\nIdentification");
            tablaCAT10.Columns.Add("Track\nNumber");
            tablaCAT10.Columns.Add("Target\nReport\nDescriptor");
            tablaCAT10.Columns.Add("Message Type");
            tablaCAT10.Columns.Add("Flight Level");
            tablaCAT10.Columns.Add("Time of\nDay");
            tablaCAT10.Columns.Add("Track Status");
            tablaCAT10.Columns.Add("Position in WGS-84 Co-ordinates");
            tablaCAT10.Columns.Add("Position in\nCartesian\nCo-ordinates");
            tablaCAT10.Columns.Add("Position in\nPolar\nCo-ordinates");
            tablaCAT10.Columns.Add("Track Velocity in Polar Coordinates");
            tablaCAT10.Columns.Add("Track Velocity in\nCartesian\nCoordinates");
            tablaCAT10.Columns.Add("Target Size\nand\nOrientation");
            tablaCAT10.Columns.Add("Target\nAddress");
            tablaCAT10.Columns.Add("System\nStatus");
            tablaCAT10.Columns.Add("Vehicle Fleet\nIdentification");
            //tablaCAT10.Columns.Add("Pre-programmed\nMessage");
            tablaCAT10.Columns.Add("Measured\nHeight");
            tablaCAT10.Columns.Add("Mode-3A\nCode");
            tablaCAT10.Columns.Add("Mode S MB\nData");
            tablaCAT10.Columns.Add("Standard\nDeviation\nof Position");
            tablaCAT10.Columns.Add("Presence");
            tablaCAT10.Columns.Add("Amplitude\nof Primary\nPlot");
            tablaCAT10.Columns.Add("Calculated\nAcceleration");
        }

    }
}
