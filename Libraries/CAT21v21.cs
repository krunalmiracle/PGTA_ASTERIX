using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecerixUPC.Libraries
{
    class CAT21v21
    {
        readonly char[] FSPEC;
        readonly string[] message;
        public List<string> items = new List<string>();

        // COMPUTE PARAMETERS

        //MESSAGE TYPE
            public string messageType;

        //DATA SOURCE IDENTIFIER
            public string SAC;
            public string SIC;

        // Target Report Descriptor
            public string ATP;
            public string ARC;
            public string RC;
            public string RAB;
            public string DCR;
            public string GBS;
            public string SIM;
            public string TST;
            public string SAA;
            public string CL;
            public string IPC;
            public string NOGO;
            public string CPR;
            public string LDPJ;
            public string RCF;
            public string FX;
        // Track Number
            public string Track_Number;
        // Service Identification
            public string Service_Identification;
        // Time of Applicability for Position
            public string Time_of_Applicability_Position;
        //  Position in WGS-84 Co-ordinates.
            public string LatitudeWGS_84;
            public string LongitudeWGS_84;
            public double LatitudeWGS_84_map = -200;
            public double LongitudeWGS_84_map = -200;
        //  High-Resolution Position in WGS-84 Co-ordinates
            public string High_Resolution_LatitudeWGS_84;
            public string High_Resolution_LongitudeWGS_84;
        // Time of Applicability Velocity
            public string Time_of_Applicability_Velocity;
        // True Airspeed
            public string True_Air_Speed;
        // Air Speed
            public string Air_Speed;
        //TARGET ADDRESS
        public string Target_address;
        // Time of Message Reception Position
        public string Time_of_Message_Reception_Position;
        // Time_of_Message_Reception_Position_High_Precision
        public string Time_of_Message_Reception_Position_High_Precision;
        // Time_of_Message_Reception_Velocity
        public string Time_of_Message_Reception_Velocity;
        public CAT21v21() { }
        public CAT21v21(string[] hexMessageArray, HelpDecode decode)
        {
            try
            {
                //Decode FSPEC
                string FSPEC0 = decode.getFSPEC(hexMessageArray);
                int numOctets = FSPEC0.Length / 7;
                int index = 3 + numOctets;
                this.FSPEC = FSPEC0.ToCharArray(0, FSPEC0.Length);
                this.message = decode.MessageToBinary(hexMessageArray);

                /* From now on each function looks to see if the decoding parameter exists in the 
                 message (checking if the FSPEC in its position == 1) and if it exists calls the function to decode the parameter */
                // Compute_Data_Source_Identification
                if (FSPEC[0] == '1') {
                    SAC = Convert.ToString(Convert.ToInt32(message[index], 2));
                    SIC = Convert.ToString(Convert.ToInt32(message[index + 1], 2));
                    index += 2;
                }
                // Compute_Target_Report_Descripter
                if (FSPEC[1] == '1') { 

                    index = this.Compute_Target_Report_Descriptor(message, index); 
                }
                // Compute_Track_Number
                if (FSPEC[2] == '1') {
                    Track_Number = Convert.ToString(Convert.ToInt32(string.Concat(message[index], message[index + 1]).Substring(4, 12), 2));
                    index += 2;
                }
                //  Compute_Service_Identification
                if (FSPEC[3] == '1') {
                    Service_Identification = Convert.ToString(Convert.ToInt32(message[index], 2));
                    index++;
                }
                //  Compute_Time_of_Aplicabillity_Position
                if (FSPEC[4] == '1') {
                    int str = Convert.ToInt32(string.Concat(message[index], message[index + 1], message[index + 2]), 2);
                    double segundos = (Convert.ToDouble(str) / 128);
                    // Time_of_day_sec = Convert.ToInt32(Math.Truncate(segundos));
                    TimeSpan tiempo = TimeSpan.FromSeconds(segundos);
                    Time_of_Applicability_Position = tiempo.ToString(@"hh\:mm\:ss\:fff");
                    index += 3;
                }
                //  Compute_PositionWGS_84
                if (FSPEC[5] == '1') {
                    double Latitude = decode.TwoComplement2Decimal(string.Concat(message[index], message[index + 1], message[index + 2])) * (180 / (Math.Pow(2, 23)));
                    index += 3;
                    double Longitude = decode.TwoComplement2Decimal(string.Concat(message[index], message[index + 1], message[index + 2])) * (180 / (Math.Pow(2, 23)));
                    LatitudeWGS_84_map = Convert.ToDouble(Latitude);
                    LongitudeWGS_84_map = Convert.ToDouble(Longitude);
                    int Latdegres = Convert.ToInt32(Math.Truncate(Latitude));
                    int Latmin = Convert.ToInt32(Math.Truncate((Latitude - Latdegres) * 60));
                    double Latsec = Math.Round(((Latitude - (Latdegres + (Convert.ToDouble(Latmin) / 60))) * 3600), 2);
                    int Londegres = Convert.ToInt32(Math.Truncate(Longitude));
                    int Lonmin = Convert.ToInt32(Math.Truncate((Longitude - Londegres) * 60));
                    double Lonsec = Math.Round(((Longitude - (Londegres + (Convert.ToDouble(Lonmin) / 60))) * 3600), 2);
                    LatitudeWGS_84 = Convert.ToString(Latdegres) + "º " + Convert.ToString(Latmin) + "' " + Convert.ToString(Latsec) + "''";
                    LongitudeWGS_84 = Convert.ToString(Londegres) + "º" + Convert.ToString(Lonmin) + "' " + Convert.ToString(Lonsec) + "''";
                    index += 3;
                }
                //  Compute_High_Resolution_PositionWGS_84
                if (FSPEC[6] == '1') {
                    double Latitude = decode.TwoComplement2Decimal(string.Concat(message[index], message[index + 1], message[index + 2], message[index + 3])) * (180 / (Math.Pow(2, 30))); index += 4;
                    double Longitude = decode.TwoComplement2Decimal(string.Concat(message[index], message[index + 1], message[index + 2], message[index + 3])) * (180 / (Math.Pow(2, 30))); index += 4;
                    LatitudeWGS_84_map = Convert.ToDouble(Latitude);
                    LongitudeWGS_84_map = Convert.ToDouble(Longitude);
                    int Latdegres = Convert.ToInt32(Math.Truncate(Latitude));
                    int Latmin = Convert.ToInt32(Math.Truncate((Latitude - Latdegres) * 60));
                    double Latsec = Math.Round(((Latitude - (Latdegres + (Convert.ToDouble(Latmin) / 60))) * 3600), 5);
                    int Londegres = Convert.ToInt32(Math.Truncate(Longitude));
                    int Lonmin = Convert.ToInt32(Math.Truncate((Longitude - Londegres) * 60));
                    double Lonsec = Math.Round(((Longitude - (Londegres + (Convert.ToDouble(Lonmin) / 60))) * 3600), 5);
                    High_Resolution_LatitudeWGS_84 = Convert.ToString(Latdegres) + "º " + Convert.ToString(Latmin) + "' " + Convert.ToString(Latsec) + "''";
                    High_Resolution_LongitudeWGS_84 = Convert.ToString(Londegres) + "º" + Convert.ToString(Lonmin) + "' " + Convert.ToString(Lonsec) + "''";
                }
                // Extended Cat21v2.1
                if (FSPEC.Count() > 8)
                {
                    if (FSPEC[7] == '1') {
                        int str = Convert.ToInt32(string.Concat(message[index], message[index + 1], message[index + 2]), 2);
                        double segundos = (Convert.ToDouble(str) / 128);
                        TimeSpan tiempo = TimeSpan.FromSeconds(segundos);
                        Time_of_Applicability_Velocity = tiempo.ToString(@"hh\:mm\:ss\:fff");
                        index += 3;
                    }
                    if (FSPEC[8] == '1') {
                        if (message[index].Substring(0, 1) == "0") { Air_Speed = Convert.ToString(Convert.ToInt32(string.Concat(message[index], message[index + 1]).Substring(1, 15), 2) * Math.Pow(2, -14)) + " NM/s"; }
                        else { Air_Speed = Convert.ToString(Convert.ToInt32(string.Concat(message[index], message[index + 1]).Substring(1, 15), 2) * 0.001) + " Mach"; }
                        index += 2;
                    }
                    if (FSPEC[9] == '1') {
                        if (message[index].Substring(0, 1) == "0")
                        {
                            True_Air_Speed = Convert.ToString(Convert.ToInt32(string.Concat(message[index], message[index + 1]).Substring(1, 15), 2)) + " Knots";
                        }
                        else { True_Air_Speed = "Value exceeds defined rage"; }
                        index += 2;
                    }
                    if (FSPEC[10] == '1') {
                        Target_address = string.Concat(decode.Binary2Hex(message[index]), decode.Binary2Hex(message[index + 1]), decode.Binary2Hex(message[index + 2]));
                        index += 3;
                    }
                    if (FSPEC[11] == '1') {
                        int str = Convert.ToInt32(string.Concat(message[index], message[index + 1], message[index + 2]), 2);
                        double segundos = (Convert.ToDouble(str) / 128);
                        TimeSpan tiempo = TimeSpan.FromSeconds(segundos);
                        Time_of_Message_Reception_Position = tiempo.ToString(@"hh\:mm\:ss\:fff");
                        index += 3;
                    }
                    if (FSPEC[12] == '1') {
                        string octet = string.Concat(message[index], message[index + 1], message[index + 2], message[index + 3]);
                        string FSI = octet.Substring(0, 2);
                        string time = octet.Substring(2, 30);
                        int str = Convert.ToInt32(time, 2);
                        double sec = (Convert.ToDouble(str)) * Math.Pow(2, -30);
                        if (FSI == "10") { sec--; }
                        if (FSI == "01") { sec++; }
                        Time_of_Message_Reception_Position_High_Precision = Convert.ToString(sec) + " sec";
                        index += 4;
                    }
                    if (FSPEC[13] == '1') {
                        int str = Convert.ToInt32(string.Concat(message[index], message[index + 1], message[index + 2]), 2);
                        double segundos = (Convert.ToDouble(str) / 128);
                        TimeSpan tiempo = TimeSpan.FromSeconds(segundos);
                        Time_of_Message_Reception_Velocity = tiempo.ToString(@"hh\:mm\:ss\:fff");
                        index += 3;
                    }
                }
            }
            catch
            {
                message = hexMessageArray;
            }
        }

        // Target Report Descriptor
        private int Compute_Target_Report_Descriptor(string[] message, int pos)
        {
            char[] OctetoChar = message[pos].ToCharArray(0, 8);
            int atp = Convert.ToInt32(string.Concat(OctetoChar[0], OctetoChar[1], OctetoChar[2]), 2);
            int arc = Convert.ToInt32(string.Concat(OctetoChar[3], OctetoChar[4]), 2);
            if (atp == 0) { ATP = "24-Bit ICAO address"; }
            else if (atp == 1) { ATP = "Duplicate address"; }
            else if (atp == 2) { ATP = "Surface vehicle address"; }
            else if (atp == 3) { ATP = "Anonymous address"; }
            else { ATP = "Reserved for future use"; }
            if (arc == 0) { ARC = "25 ft "; }
            else if (arc == 1) { ARC = "100 ft"; }
            else if (arc == 2) { ARC = "Unknown"; }
            else { ARC = "Invalid"; }
            if (OctetoChar[5] == '0') { RC = "Default"; }
            else { RC = "Range Check passed, CPR Validation pending"; }
            if (OctetoChar[6] == '0') { RAB = "Report from target transponder"; }
            else { RAB = "Report from field monitor (fixed transponder)"; }
            pos++;
            if (OctetoChar[7] == '1')
            {
                OctetoChar = message[pos].ToCharArray(0, 8);
                if (OctetoChar[0] == '0') { DCR = "No differential correction (ADS-B)"; }
                else { DCR = "Differential correction (ADS-B)"; }
                if (OctetoChar[1] == '0') { GBS = "Ground Bit not set"; }
                else { GBS = "Ground Bit set"; }
                if (OctetoChar[2] == '0') { SIM = "Actual target report"; }
                else { SIM = "Simulated target report"; }
                if (OctetoChar[3] == '0') { TST = "Default"; }
                else { TST = "Test Target"; }
                if (OctetoChar[4] == '0') { SAA = "Equipment capable to provide Selected Altitude"; }
                else { SAA = "Equipment not capable to provide Selected Altitude"; }
                int cl = Convert.ToInt32(string.Concat(OctetoChar[5], OctetoChar[6]), 2);
                if (cl == 0) { CL = "Report valid"; }
                else if (cl == 1) { CL = "Report suspect"; }
                else if (cl == 2) { CL = "No information"; }
                else { CL = "Reserved for future use"; }
                pos++;
                if (OctetoChar[7] == '1')
                {
                    OctetoChar = message[pos].ToCharArray(0, 8);
                    if (OctetoChar[2] == '0') { IPC = "Default"; }
                    else { IPC = "Independent Position Check failed"; }
                    if (OctetoChar[3] == '0') { NOGO = "NOGO-bit not set"; }
                    else { NOGO = "NOGO-bit set"; }
                    if (OctetoChar[4] == '0') { CPR = "CPR Validation correct "; }
                    else { CPR = "CPR Validation failed"; }
                    if (OctetoChar[5] == '0') { LDPJ = "LDPJ not detected"; }
                    else { LDPJ = "LDPJ detected"; }
                    if (OctetoChar[6] == '0') { RCF = "Default"; }
                    else { RCF = "Range Check failed "; }
                    pos++;
                }
            }
            return pos;
        }


        







    }
}