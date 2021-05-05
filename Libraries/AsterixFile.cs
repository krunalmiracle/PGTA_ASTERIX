using System;
using System.Collections.Generic;
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
        
        List<int> datablocks = new List<int>();
        

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

        public List<int> getDataBlocks()
        {
            return datablocks;
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
            while ((currPointer + 1) < lengthFile)
            {
                messageLength = (fileBytes[currPointer + 1] * 256) + fileBytes[currPointer + 2];
                message = fileBytesList.GetRange(currPointer, messageLength);

                // Convert Message Byte to Messages of Hexadecimal
                Byte[] arr = message.ToArray();
                foreach (byte b in arr)
                {
                    messageHex.Add(b.ToString("X"));
                }
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
            CAT10Helper cat10Helper = new CAT10Helper(decode);
            CAT21Helper cat21Helper = new CAT21Helper(decode);
            //List<CAT10> arrCat10 = new List<CAT10>[listhex.Count];
            List<CAT10> arrCat10 = new List<CAT10>();
            List<CAT21> arrCat21 = new List<CAT21>();
            /*CAT10 newcat10 = new CAT10(decode, cat10Helper); */
            string[] arraystring;
            /*CAT21v21 newcat21 = new CAT21v21(decode, cat10Helper);*/

            for (int q = 0; q < messagesHex.Count; q++)
            {
                arraystring = messagesHex[q];
                /*int CAT = int.Parse(arraystring[0], System.Globalization.NumberStyles.HexNumber);*/

                if (arraystring[0] == "A")
                {
                    arrCat10.Add(new CAT10(decode, cat10Helper, arraystring,q));
                }
                else if (arraystring[0] == "15")
                {
                    arrCat21.Add(new CAT21(decode, cat21Helper, arraystring, q));
                }
            }
            string a = ";";
        }
    }
}
