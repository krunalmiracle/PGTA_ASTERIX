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
        // Data Item I021/076, Time of Message Reception of Velocity–High Precision
        public string Time_of_Message_Reception_Velocity_High_Precision;
        public string Geometric_Height;
        public string Quality_Indicators;
        // Quality Indicators
        public string NUCr_NACv;
        public string NUCp_NIC;
        public string NICbaro;
        public string SIL;
        public string NACp;
        public string SILS;
        public string SDA;
        public string GVA;
        public int PIC;
        public string ICB;
        public string NUCp;
        public string NIC;
        // MOPS Version
        public string VNS;
        public string LTT;
        public string MOPS;
        // Mode 3/A Code in Octal Representation
        public string ModeA3;
        // Roll Angle
        public string Roll_Angle;
        // Flight Level
        public string Flight_Level;
        //Magnetic Heading (Element of Air Vector).
        public string Magnetic_Heading;
        //Target Status
        public string ICF;
        public string LNAV;
        public string PS;
        public string SS;
        //Barometric Vertical Rate, in two’s complement form.
        public string Barometric_Vertical_Rate;
        //Geometric Vertical Rate, in two’s complement form, with reference to WGS-84.
        public string Geometric_Vertical_Rate;
        //  Ground Speed and Track Angle elements of Airborne Ground Vector.
        public string Ground_Speed;
        public string Track_Angle;
        public string Ground_vector;
        // Track Angle Rate, Rate of Turn, in two’s complement form.
        public string Track_Angle_Rate;
        // Time of ASTERIX Report Transmission
        public string Time_of_Asterix_Report_Transmission;
        public int Time_of_day_sec;
        // Data Item I021/170, Target Identification
        public string Target_Identification;
        //EMITTER CATEGORY
        public string ECAT;
        // Meteorological information.
        public int MET_present = 0;
        public string Wind_Speed;
        public string Wind_Direction;
        public string Temperature;
        public string Turbulence;
        // Data Item I021/146, Selected Altitude
        public string SAS;
        public string Source;
        public string Sel_Altitude;
        public string Selected_Altitude;
        // Data Item I021/148, Final State Selected Altitude
        public string MV;
        public string AH;
        public string AM;
        public string Final_State_Altitude;
        //TRAJECTORY INTENT
        public int Trajectory_present = 0;
        public bool subfield1;
        public bool subfield2;
        public string NAV;
        public string NVB;
        public int REP;
        public string[] TCA;
        public string[] NC;
        public int[] TCP;
        public string[] Altitude;
        public string[] Latitude;
        public string[] Longitude;
        public string[] Point_Type;
        public string[] TD;
        public string[] TRA;
        public string[] TOA;
        public string[] TOV;
        public string[] TTR;
        // Data Item I021/016, Service Management
        public string RP;
        // Data Item I021/008, Aircraft Operational Status
        public string RA;
        public string TC;
        public string TS;
        public string ARV;
        public string CDTIA;
        public string Not_TCAS;
        public string SA;
        // Data Item I021/271, Surface Capabilities and Characteristics
        public string POA;
        public string CDTIS;
        public string B2_low;
        public string RAS;
        public string IDENT;
        public string LengthandWidth;
        // Data Item I021/132, Message Amplitude
        public string Message_Amplitude;
        // Data Item I021/250, Mode S MB Data
        public string[] MB_Data;
        public string[] BDS1;
        public string[] BDS2;
        public int modeS_rep;
        // Data Item I021/260, ACAS Resolution Advisory Report
        public string TYP;
        public string STYP;
        public string ARA;
        public string RAC;
        public string RAT;
        public string MTE;
        public string TTI;
        public string TID;
        // RECEIVER ID
        public string Receiver_ID;
        // Data Item I021/295, Data Ages
        public int Data_Ages_present = 0;
        public string AOS;
        public string TRD;
        public string M3A;
        public string QI;
        public string TI;
        public string MAM;
        public string GH;
        public string FL;
        public string ISA;
        public string FSA;
        public string AS;
        public string TAS;
        public string MH;
        public string BVR;
        public string GVR;
        public string GV;
        public string TAR;
        public string TI_DataAge;
        public string TS_DataAge;
        public string MET;
        public string ROA;
        public string ARA_DataAge;
        public string SCC;

        /// Constructors
        public CAT21v21() { }
        // Constructor with message array and decoder class
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
                 message (checking if the FSPEC in its Position == 1) and if it exists calls the function to decode the parameter */
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
                if (FSPEC.Count() > 16){
                    
                    if (FSPEC[14] == '1') {
                         string octet = string.Concat(message[index], message[index + 1], message[index + 2], message[index + 3]);
                        string FSI = octet.Substring(0, 2);
                        string time = octet.Substring(2, 30);
                        int str = Convert.ToInt32(time, 2);
                        double sec = (Convert.ToDouble(str)) * Math.Pow(2, -30);
                        if (FSI == "10") { sec--; }
                        if (FSI == "01") { sec++; }
                        Time_of_Message_Reception_Velocity_High_Precision = Convert.ToString(sec) + " sec";
                        index +=4;
                    }
                    if (FSPEC[15] == '1') { 
                        Geometric_Height = Convert.ToString(decode.TwoComplement2Decimal(string.Concat(message[index], message[index + 1])) * 6.25) + " ft";
                        index += 2;
                    }
                    if (FSPEC[16] == '1') { 
                        NUCr_NACv = Convert.ToString(Convert.ToInt32(message[index].Substring(0, 3), 2));
                        NUCp_NIC = Convert.ToString(Convert.ToInt32(message[index].Substring(3, 4), 2));
                        index++;
                        if (message[index-1].Substring(7, 1) == "1")
                        {
                            
                            NICbaro = Convert.ToString(Convert.ToInt32(message[index].Substring(0, 1), 2));
                            SIL = Convert.ToString(Convert.ToInt32(message[index].Substring(1, 2), 2));
                            NACp = Convert.ToString(Convert.ToInt32(message[index].Substring(3, 4), 2));
                            index++;
                            if (message[index-1].Substring(7, 1) == "1")
                            {
                                
                                if (message[index].Substring(2, 1) == "0") { SILS = "Measured per flight-Hour"; }
                                else { SILS = "Measured per sample"; }
                                SDA = Convert.ToString(Convert.ToInt32(message[index].Substring(3, 2), 2));
                                GVA = Convert.ToString(Convert.ToInt32(message[index].Substring(5, 2), 2));
                                index++;
                                if (message[index-1].Substring(7, 1) == "1")
                                {
                                    
                                    PIC = Convert.ToInt32(message[index].Substring(0, 4), 2);
                                    if (PIC == 0) { ICB = "No integrity(or > 20.0 NM)"; NUCp = "0"; NIC = "0"; }
                                    if (PIC == 1) { ICB = "< 20.0 NM"; NUCp = "1"; NIC = "1"; }
                                    if (PIC == 2) { ICB = "< 10.0 NM"; NUCp = "2"; NIC = "-"; }
                                    if (PIC == 3) { ICB = "< 8.0 NM"; NUCp = "-"; NIC = "2"; }
                                    if (PIC == 4) { ICB = "< 4.0 NM"; NUCp = "-"; NIC = "3"; }
                                    if (PIC == 5) { ICB = "< 2.0 NM"; NUCp = "3"; NIC = "4"; }
                                    if (PIC == 6) { ICB = "< 1.0 NM"; NUCp = "4"; NIC = "5"; }
                                    if (PIC == 7) { ICB = "< 0.6 NM"; NUCp = "-"; NIC = "6 (+ 1/1)"; }
                                    if (PIC == 8) { ICB = "< 0.5 NM"; NUCp = "5"; NIC = "6 (+ 0/0)"; }
                                    if (PIC == 9) { ICB = "< 0.3 NM"; NUCp = "-"; NIC = "6 (+ 0/1)"; }
                                    if (PIC == 10) { ICB = "< 0.2 NM"; NUCp = "6"; NIC = "7"; }
                                    if (PIC == 11) { ICB = "< 0.1 NM"; NUCp = "7"; NIC = "8"; }
                                    if (PIC == 12) { ICB = "< 0.04 NM"; NUCp = ""; NIC = "9"; }
                                    if (PIC == 13) { ICB = "< 0.013 NM"; NUCp = "8"; NIC = "10"; }
                                    if (PIC == 14) { ICB = "< 0.004 NM"; NUCp = "9"; NIC = "11"; }
                                    index++;
                                }
                            }
                        }

                    }
                    if (FSPEC[17] == '1') { 
                        if (message[index].Substring(1, 1) == "0") { VNS = "The MOPS Version is supported by the GS"; }
                        else { VNS = "The MOPS Version is not supported by the GS"; }
                        int ltt = Convert.ToInt32( message[index].Substring(5,3),2);
                        if (ltt == 0) { LTT = "Other"; }
                        else if (ltt == 1) { LTT = "UAT"; }
                        else if (ltt == 2) 
                        {
                            int vn = Convert.ToInt32(message[index].Substring(2, 3), 2);
                            string VN= "";
                            if (vn == 0) { VN = "ED102/DO-260"; }
                            if (vn == 1) { VN = "DO-260A"; }
                            if (vn == 2) { VN = "ED102A/DO-260B"; }
                            LTT= "Version Number: " + VN; 
                        }
                        else if (ltt == 3) { LTT = "VDL 4"; }
                        else { LTT = "Not assigned"; }
                        MOPS = LTT;
                        index++;
                    }
                    if (FSPEC[18] == '1') { 
                       ModeA3 = Convert.ToString(decode.Decimal2Octal(Convert.ToInt32(string.Concat(message[index], message[index + 1]).Substring(4,12),2))).PadLeft(4,'0');
                        index += 2;
                    }
                    if (FSPEC[19] == '1') { 
                        Roll_Angle = Convert.ToString(decode.TwoComplement2Decimal(string.Concat(message[index],message[index]))*0.01) + "º"; 
                    }
                    if (FSPEC[20] == '1') { 
                        Flight_Level = Convert.ToString(decode.TwoComplement2Decimal(string.Concat(message[index], message[index + 1])) * (0.25)) + " FL";
                        index += 2; 
                    }
                }
                if (FSPEC.Count() > 22)
                {
                    if (FSPEC[21] == '1') { 
                        Magnetic_Heading = Convert.ToString(Convert.ToInt32(string.Concat(message[index], message[index]), 2) * (360 / (Math.Pow(2, 16)))) + "º"; 
                        index += 2;
                    }
                    if (FSPEC[22] == '1') { 
                        if (message[index].Substring(0, 1) == "0") { ICF = "No intent change active"; }
                        else {ICF= "Intent change flag raised"; }
                        if (message[index].Substring(1, 1) == "0") { LNAV = "LNAV Mode engaged"; }
                        else { LNAV = "LNAV Mode not engaged"; }
                        int ps = Convert.ToInt32(message[index].Substring(3,3), 2);
                        if (ps==0) { PS = "No emergency / not reported"; }
                        else if (ps == 1) { PS = "General emergency"; }
                        else if (ps == 2) { PS = "Lifeguard / medical emergency"; }
                        else if (ps == 3) { PS = "Minimum fuel"; }
                        else if (ps == 4) { PS = "No communications"; }
                        else if (ps == 5) { PS = "Unlawful interference"; }
                        else { PS = "'Downed' Aircraft "; }
                        int ss = Convert.ToInt32(message[index].Substring(6, 2), 2);
                        if (ss == 0) { SS = "No condition reported"; }
                        else if (ss == 1) { SS = "Permanent Alert (Emergency condition)"; }
                        else if (ss == 2) { SS = "Temporary Alert (change in Mode 3/A Code other than emergency)"; }
                        else { SS = "SPI set"; }
                        index++;
                    }
                    if (FSPEC[23] == '1') { 
                        if (message[index].Substring(0, 1) == "0") {
                        Barometric_Vertical_Rate = Convert.ToString(decode.TwoComplement2Decimal(string.Concat(message[index], message[index + 1]).Substring(1, 15)) * 6.25) + " feet/minute"; }
                        else { Barometric_Vertical_Rate = "Value exceeds defined rage"; }
                        index += 2;
                    }
                    if (FSPEC[24] == '1') { 
                        if (message[index].Substring(0, 1) == "0")
                        {
                            Geometric_Vertical_Rate = Convert.ToString(decode.TwoComplement2Decimal(string.Concat(message[index], message[index + 1]).Substring(1, 15)) * 6.25) + " feet/minute"; 
                        }
                        else { Geometric_Vertical_Rate = "Value exceeds defined rage"; }
                        index += 2;
                    }
                    if (FSPEC[25] == '1') { 
                       if (message[index].Substring(0, 1) == "0")
                        {
                            Ground_Speed = String.Format("{0:0.00}", (Convert.ToInt32(string.Concat(message[index], message[index + 1]).Substring(1, 15),2) * Math.Pow(2, -14)*3600)) +  "Knts";
                        // double meters = 
                            Track_Angle = String.Format("{0:0.00}", Convert.ToInt32(string.Concat(message[index + 2], message[index + 3]).Substring(0, 16),2) * (360 / (Math.Pow(2, 16))));
                            Ground_vector = "GS: " + Ground_Speed + ", T.A: "+ String.Format("{0:0.00}",Track_Angle)+"º";
                        }
                        else { Ground_vector= "Value exceeds defined rage"; }
                        index +=  4;
                    }
                    if (FSPEC[26] == '1') { 
                        Track_Angle_Rate = Convert.ToString(Convert.ToInt32(string.Concat(message[index], message[index]).Substring(6, 10), 2)*(1/32))+" º/s";
                        index += 2;
                    }
                    if (FSPEC[27] == '1') { 
                        int str = Convert.ToInt32(string.Concat(message[index], message[index + 1], message[index + 2]), 2);
                        double segundos = (Convert.ToDouble(str) / 128);
                        Time_of_day_sec = Convert.ToInt32(Math.Truncate(segundos));
                        TimeSpan tiempo = TimeSpan.FromSeconds(segundos);
                        Time_of_Asterix_Report_Transmission = tiempo.ToString(@"hh\:mm\:ss\:fff");
                        index += 3; 
                    }
                }
                if (FSPEC.Count() > 29)
                {
                    if (FSPEC[28] == '1') { 
                        StringBuilder Identification= new StringBuilder();
                        string octets = string.Concat(message[index], message[index + 1], message[index + 2], message[index + 3], message[index + 4], message[index + 5]);
                        for (int i=0; i<8;i++) {Identification.Append(decode.Code2Char(octets.Substring(i*6,6)));}
                        string tar = Identification.ToString();
                        if (tar.Length > 1) { Target_Identification = tar; }
                        index =  index + 6; 
                    }
                    if (FSPEC[29] == '1') { 
                        int ecat = Convert.ToInt32(message[index], 2);
                        if (Target_Identification == "7777XBEG") { ECAT = "No ADS-B Emitter Category Information"; }
                        else
                        {
                            if (ecat == 0) { ECAT = "No ADS-B Emitter Category Information"; }
                            if (ecat == 1) { ECAT = "Light aircraft"; }
                            if (ecat == 2) { ECAT = "Small aircraft"; }
                            if (ecat == 3) { ECAT = "Medium aircraft"; }
                            if (ecat == 4) { ECAT = "High Vortex Large"; }
                            if (ecat == 5) { ECAT = "Heavy aircraft"; }
                            if (ecat == 6) { ECAT = "Highly manoeuvrable(5g acceleration capability) and high speed(> 400 knots cruise)"; }
                            if (ecat == 7 || ecat == 8 || ecat == 9) { ECAT = "Reserved"; }
                            if (ecat == 10) { ECAT = "Rotocraft"; }
                            if (ecat == 11) { ECAT = "Glider / Sailplane"; }
                            if (ecat == 12) { ECAT = "Lighter than air"; }
                            if (ecat == 13) { ECAT = "Unmanned Aerial Vehicle"; }
                            if (ecat == 14) { ECAT = "Space / Transatmospheric Vehicle"; }
                            if (ecat == 15) { ECAT = "Ultralight / Handglider / Paraglider"; }
                            if (ecat == 16) { ECAT = "Parachutist / Skydiver"; }
                            if (ecat == 17 || ecat == 18 || ecat == 19) { ECAT = "Reserved"; }
                            if (ecat == 20) { ECAT = "Surface emergency vehicle"; }
                            if (ecat == 21) { ECAT = "Surface service vehicle"; }
                            if (ecat == 22) { ECAT = "Fixed ground or tethered obstruction"; }
                            if (ecat == 23) { ECAT = "Cluster obstacle"; }
                            if (ecat == 24) { ECAT = "Line obstacle"; }
                        }
                        index++; 
                    }
                    if (FSPEC[30] == '1') { 
                        MET_present = 1;
                        int indexin = index;
                        int indexfin = index++;
                        if (message[indexin].Substring(0, 1) == "1") {Wind_Speed = Convert.ToString(Convert.ToInt32(string.Concat(message[indexfin],message[indexfin]), 2)) + " Knots"; indexfin += 2;}
                        if (message[indexin].Substring(1, 1) == "1") { Wind_Direction = Convert.ToString(Convert.ToInt32(string.Concat(message[indexfin], message[indexfin]), 2)) + " degrees"; indexfin += 2; }
                        if (message[indexin].Substring(2, 1) == "1") { Temperature = Convert.ToString(Convert.ToInt32(string.Concat(message[indexfin], message[indexfin]), 2)*0.25) + " ºC"; indexfin += 2; }
                        if (message[indexin].Substring(3, 1) == "1") { Turbulence = Convert.ToString(Convert.ToInt32(string.Concat(message[indexfin], message[indexfin]), 2)) + " Turbulence"; indexfin+=2; }
                        index = indexfin; 
                    }
                    if (FSPEC[31] == '1') { 
                        string sou = message[index].Substring(1, 2);
                        if (sou == "00") { Source = "Unknown"; }
                        else if (sou == "01") { Source = "Aircraft Altitude (Holding Altitude)"; }
                        else if (sou == "10") { Source = "MCP/FCU Selected Altitude"; }
                        else { Source = "FMS Selected Altitude"; }
                        Sel_Altitude = Convert.ToString(decode.TwoComplement2Decimal(string.Concat(message[index], message[index+1]).Substring(3, 13)) * 25) + " ft";
                        Selected_Altitude= "SA: "+ Convert.ToString(Sel_Altitude);
                        index += 2;
                    }
                    if (FSPEC[32] == '1') { 
                        if (message[index].Substring(0, 1) == "0") { MV = "Not active or unknown"; }
                        else { MV = "Active"; }
                        if (message[index].Substring(1, 1) == "0") { AH = "Not active or unknown"; }
                        else { AH = "Active"; }
                        if (message[index].Substring(2, 1) == "0") { AM = "Not active or unknown"; }
                        else { AM = "Active"; }
                        Final_State_Altitude = Convert.ToString(decode.TwoComplement2Decimal(string.Concat(message[index], message[index+1]).Substring(3, 13)) * 25) + " ft";
                        index += 2;
                    }
                    if (FSPEC[33] == '1') { 
                        Trajectory_present = 1;
                        if (message[index].Substring(0, 1) == "1") { subfield1 = true; }
                        else { subfield1 = false; }
                        if (message[index].Substring(1, 1) == "1") { subfield2 = true; }
                        else { subfield2 = false; }
                        if (subfield1 == true)
                        {
                            index++;
                            if (message[index].Substring(0, 1) == "0") { NAV = "Trajectory Intent Data is available for this aircraft"; }
                            else { NAV = "Trajectory Intent Data is not available for this aircraft "; }
                            if (message[index].Substring(1, 1) == "0") { NVB = "Trajectory Intent Data is valid"; }
                            else { NVB = "Trajectory Intent Data is not valid"; }
                        }
                        if (subfield2 == true)
                        {
                            index++;
                            REP = Convert.ToInt32(message[index], 2);
                            TCA = new string[REP];
                            NC = new string[REP];
                            TCP = new int[REP];
                            Altitude = new string[REP];
                            Latitude = new string[REP];
                            Longitude = new string[REP];
                            Point_Type = new string[REP];
                            TD = new string[REP];
                            TRA = new string[REP];
                            TOA = new string[REP];
                            TOV = new string[REP];
                            TTR = new string[REP];
                            index++;

                            for (int i = 0; i < REP; i++)
                            {
                                if (message[index].Substring(0, 1) == "0") { TCA[i] = "TCP number available"; }
                                else { TCA[i] = "TCP number not available"; }
                                if (message[index].Substring(1, 1) == "0") { NC[i] = "TCP compliance"; }
                                else { NC[i] = "TCP non-compliance"; }
                                TCP[i] = Convert.ToInt32(message[index].Substring(2, 6));
                                index++;
                                Altitude[i] = Convert.ToString(decode.TwoComplement2Decimal(string.Concat(message[index], message[index + 1])) * 10) + " ft";
                                index += 2;
                                Latitude[i] = Convert.ToString(decode.TwoComplement2Decimal(string.Concat(message[index], message[index + 1])) * (180 / (Math.Pow(2, 23)))) + " deg";
                                index +=2;
                                Longitude[i] = Convert.ToString(decode.TwoComplement2Decimal(string.Concat(message[index], message[index + 1])) * (180 / (Math.Pow(2, 23)))) + " deg";
                                index += 2;
                                int pt = Convert.ToInt32(message[index].Substring(0, 4), 2);
                                if (pt == 0) { Point_Type[i] = "Unknown"; }
                                else if (pt == 1) { Point_Type[i] = "Fly by waypoint (LT) "; }
                                else if (pt == 2) { Point_Type[i] = "Fly over waypoint (LT)"; }
                                else if (pt == 3) { Point_Type[i] = "Hold pattern (LT)"; }
                                else if (pt == 4) { Point_Type[i] = "Procedure hold (LT)"; }
                                else if (pt == 5) { Point_Type[i] = "Procedure turn (LT)"; }
                                else if (pt == 6) { Point_Type[i] = "RF leg (LT)"; }
                                else if (pt == 7) { Point_Type[i] = "Top of climb (VT)"; }
                                else if (pt == 8) { Point_Type[i] = "Top of descent (VT)"; }
                                else if (pt == 9) { Point_Type[i] = "Start of level (VT)"; }
                                else if (pt == 10) { Point_Type[i] = "Cross-over altitude (VT)"; }
                                else { Point_Type[i] = "Transition altitude (VT)"; }
                                string td = message[index].Substring(4, 2);
                                if (td == "00") { TD[i] = "N/A"; }
                                else if (td == "01") { TD[i] = "Turn right"; }
                                else if (td == "10") { TD[i] = "Turn left"; }
                                else { TD[i] = "No turn"; }
                                if (message[index].Substring(6, 1) == "0") { TRA[i] = "TTR not available"; }
                                else { TRA[i] = "TTR available"; }
                                if (message[index].Substring(7, 1) == "0") { TOA[i] = "TOV available"; }
                                else { TOA[i] = "TOV not available"; }
                                index++;
                                TOV[i] = Convert.ToString(Convert.ToInt32(string.Concat(message[index], message[index + 1], message[index + 2]), 2)) + " sec";
                                index += 3;
                                TTR[i] = Convert.ToString(Convert.ToInt32(string.Concat(message[index], message[index + 1]), 2) * 0.01) + " Nm";
                                index += 2;
                            }
                        }
                    }
                    if (FSPEC[34] == '1') { 
                        RP = Convert.ToString(Convert.ToDouble(Convert.ToInt32(message[index], 2)) * 0.5) + " sec";
                        index++; 
                    }

                }
                if (FSPEC.Count() > 36)
                {
                    if (FSPEC[35] == '1') { 
                        char[] OctetoChar = message[index].ToCharArray(0, 8);
                        if (OctetoChar[0] == '1') { RA = "TCAS RA active"; }
                        else { RA = "TCAS II or ACAS RA not active"; }
                        if (Convert.ToInt32(string.Concat(OctetoChar[1], OctetoChar[2]), 2) == 1) { TC = "No capability for trajectory Change Reports"; }
                        else if (Convert.ToInt32(string.Concat(OctetoChar[1], OctetoChar[2]), 2) == 2) { TC = "Support fot TC+0 reports only"; }
                        else if (Convert.ToInt32(string.Concat(OctetoChar[1], OctetoChar[2]), 2) == 3) { TC = "Support for multiple TC reports"; }
                        else { TC = "Reserved"; }
                        if (OctetoChar[3] == '0') { TS = "No capability to support Target State Reports"; }
                        else { TS = "Capable of supporting target State Reports"; }
                        if (OctetoChar[4] == '0') { ARV = "No capability to generate ARV-Reports"; }
                        else { ARV = "Capable of generate ARV-Reports"; };
                        if (OctetoChar[5] == '0') { CDTIA = "CDTI not operational"; }
                        else { CDTIA = "CDTI operational"; }
                        if (OctetoChar[6] == '0') { Not_TCAS = "TCAS operational"; }
                        else { Not_TCAS = "TCAS not operational"; }
                        if (OctetoChar[7] == '0') { SA = "Antenna Diversity"; }
                        else { SA = "Single Antenna only"; }
                        index++;
                    }
                    if (FSPEC[36] == '1') { 
                        if (message[index].Substring(2, 1) == "0") { POA = "Position transmitted is not ADS-B Position reference point"; }
                        else { POA = "Position transmitted is the ADS-B Position reference point"; }
                        if (message[index].Substring(3, 1) == "0") { CDTIS = "Cockpit Display of Traffic Information not operational"; }
                        else { CDTIS = "Cockpit Display of Traffic Information operational"; }
                        if (message[index].Substring(4, 1) == "0") { B2_low= "Class B2 transmit power ≥ 70 Watts"; }
                        else { B2_low= "Class B2 transmit power < 70 Watts"; }
                        if (message[index].Substring(5, 1) == "0") { RAS = "Aircraft not receiving ATC-services"; }
                        else { RAS = "Aircraft receiving ATC services"; }
                        if (message[index].Substring(6, 1) == "0") { IDENT = "IDENT switch not active"; }
                        else { IDENT = "IDENT switch active"; }
                        if (message[index].Substring(7, 1) == "1") 
                        {
                            index++;
                            int LaW =Convert.ToInt32(message[index].Substring(4,4),2) ; 
                            if ( LaW == 0) { LengthandWidth  = "Lenght < 15  and Width < 11.5";  }
                            if (LaW == 1) { LengthandWidth = "Lenght < 15  and Width < 23"; }
                            if (LaW == 2) { LengthandWidth = "Lenght < 25  and Width < 28.5"; }
                            if (LaW == 3) { LengthandWidth = "Lenght < 25  and Width < 34"; }
                            if (LaW == 4) { LengthandWidth = "Lenght < 35  and Width < 33"; }
                            if (LaW == 5) { LengthandWidth = "Lenght < 35  and Width < 38"; }
                            if (LaW == 6) { LengthandWidth = "Lenght < 45  and Width < 39.5"; }
                            if (LaW == 7) { LengthandWidth = "Lenght < 45  and Width < 45"; }
                            if (LaW == 8) { LengthandWidth = "Lenght < 55  and Width < 45"; }
                            if (LaW == 9) { LengthandWidth = "Lenght < 55  and Width < 52"; }
                            if (LaW == 10) { LengthandWidth = "Lenght < 65  and Width < 59.5"; }
                            if (LaW == 11) { LengthandWidth = "Lenght < 65  and Width < 67"; }
                            if (LaW == 12) { LengthandWidth = "Lenght < 75  and Width < 72.5"; }
                            if (LaW == 13) { LengthandWidth = "Lenght < 75  and Width < 80"; }
                            if (LaW == 14) { LengthandWidth = "Lenght < 85  and Width < 80"; }
                            if (LaW == 15) { LengthandWidth = "Lenght > 85  and Width > 80"; }
                        }
                        index++;
                    }
                    if (FSPEC[37] == '1') { 
                        Message_Amplitude = Convert.ToString(decode.TwoComplement2Decimal(message[index])) + " dBm"; 
                        index++; 
                    }
                    if (FSPEC[38] == '1') { 
                        int modeS_rep = Convert.ToInt32(message[index], 2);
                        if (modeS_rep < 0) {MB_Data = new string[modeS_rep];BDS1 = new string[modeS_rep]; BDS2 = new string[modeS_rep]; }
                        index++;
                        for (int i=0;i<modeS_rep;i++)
                        {
                            MB_Data[i] = String.Concat(message[index], message[index + 1], message[index + 2], message[index + 3], message[index + 4], message[index + 5], message[index + 6]);
                            BDS1[1] = message[index + 7].Substring(0, 4);
                            BDS2[1] = message[index + 7].Substring(4, 4);
                            index +=8;
                        } 
                    }
                    if (FSPEC[39] == '1') { 
                        string messg = string.Concat(message[index], message[index + 1], message[index + 2], message[index + 3], message[index + 4], message[index + 5], message[index + 6]);
                        TYP = messg.Substring(0,5);
                        STYP = messg.Substring(5, 3);
                        ARA = messg.Substring(8, 14);
                        RAC = messg.Substring(22, 4);
                        RAT = messg.Substring(26, 1);
                        MTE = messg.Substring(27, 1);
                        TTI = messg.Substring(28, 2);
                        TID = messg.Substring(30, 26);
                        index +=7;
                    }
                    if (FSPEC[40] == '1') { 
                        Receiver_ID = Convert.ToString(Convert.ToInt32(message[index],2));
                        index++;
                    }
                    if (FSPEC[41] == '1') { 
                        Data_Ages_present = 1;
                        int indexin = index;
                        if (message[index].Substring(7, 1) == "1")
                        {
                            index++;
                            if (message[index].Substring(7, 1) == "1")
                            {
                                index++;
                                if (message[index].Substring(7, 1) == "1")
                                {
                                    index++;
                                }
                            }
                        }
                        index++;
                        if (message[indexin].Substring(0, 1) == "1") { AOS = Convert.ToString(Convert.ToInt32(message[index], 2) * 0.1) + " s"; index++; }
                        if (message[indexin].Substring(1, 1) == "1") { TRD = Convert.ToString(Convert.ToInt32(message[index], 2) * 0.1) + " s"; index++; }
                        if (message[indexin].Substring(2, 1) == "1") { M3A = Convert.ToString(Convert.ToInt32(message[index], 2) * 0.1) + " s"; index++; }
                        if (message[indexin].Substring(3, 1) == "1") { QI = Convert.ToString(Convert.ToInt32(message[index], 2) * 0.1) + " s"; index++; }
                        if (message[indexin].Substring(4, 1) == "1") { TI = Convert.ToString(Convert.ToInt32(message[index], 2) * 0.1) + " s"; index++; }
                        if (message[indexin].Substring(5, 1) == "1") { MAM = Convert.ToString(Convert.ToInt32(message[index], 2) * 0.1) + " s"; index++; }
                        if (message[indexin].Substring(6, 1) == "1") { GH = Convert.ToString(Convert.ToInt32(message[index], 2) * 0.1) + " s"; index++; }
                        if (message[indexin].Substring(7, 1) == "1")
                        {
                            if (message[indexin + 1].Substring(0, 1) == "1") { FL = Convert.ToString(Convert.ToInt32(message[index], 2) * 0.1) + " s"; index++; }
                            if (message[indexin + 1].Substring(1, 1) == "1") { ISA = Convert.ToString(Convert.ToInt32(message[index], 2) * 0.1) + " s"; index++; }
                            if (message[indexin + 1].Substring(2, 1) == "1") { FSA = Convert.ToString(Convert.ToInt32(message[index], 2) * 0.1) + " s"; index++; }
                            if (message[indexin + 1].Substring(3, 1) == "1") { AS = Convert.ToString(Convert.ToInt32(message[index], 2) * 0.1) + " s"; index++; }
                            if (message[indexin + 1].Substring(4, 1) == "1") { TAS = Convert.ToString(Convert.ToInt32(message[index], 2) * 0.1) + " s"; index++; }
                            if (message[indexin + 1].Substring(5, 1) == "1") { MH = Convert.ToString(Convert.ToInt32(message[index], 2) * 0.1) + " s"; index++; }
                            if (message[indexin + 1].Substring(6, 1) == "1") { BVR = Convert.ToString(Convert.ToInt32(message[index], 2) * 0.1) + " s"; index++; }
                        }
                        if (message[indexin+1].Substring(7, 1) == "1")
                        {
                            if (message[indexin + 2].Substring(0, 1) == "1") { GVR = Convert.ToString(Convert.ToInt32(message[index], 2) * 0.1) + " s"; index++; }
                            if (message[indexin + 2].Substring(1, 1) == "1") { GV = Convert.ToString(Convert.ToInt32(message[index], 2) * 0.1) + " s"; index++; }
                            if (message[indexin + 2].Substring(2, 1) == "1") { TAR = Convert.ToString(Convert.ToInt32(message[index], 2) * 0.1) + " s"; index++; }
                            if (message[indexin + 2].Substring(3, 1) == "1") { TI_DataAge = Convert.ToString(Convert.ToInt32(message[index], 2) * 0.1) + " s"; index++; }
                            if (message[indexin + 2].Substring(4, 1) == "1") { TS_DataAge = Convert.ToString(Convert.ToInt32(message[index], 2) * 0.1) + " s"; index++; }
                            if (message[indexin + 2].Substring(5, 1) == "1") { MET = Convert.ToString(Convert.ToInt32(message[index], 2) * 0.1) + " s"; index++; }
                            if (message[indexin + 2].Substring(6, 1) == "1") { ROA = Convert.ToString(Convert.ToInt32(message[index], 2) * 0.1) + " s"; index++; }
                        }
                        if (message[indexin+2].Substring(7, 1) == "1")
                        {
                            if (message[indexin + 3].Substring(0, 1) == "1") { ARA_DataAge = Convert.ToString(Convert.ToInt32(message[index], 2) * 0.1) + " s"; index++; }
                            if (message[indexin + 3].Substring(1, 1) == "1") { SCC = Convert.ToString(Convert.ToInt32(message[index], 2) * 0.1) + " s"; index++; }
                        }
                    }
                }
            }
            catch
            {
                message = hexMessageArray;
            }
        }

        // Target Report Descriptor
        private int Compute_Target_Report_Descriptor(string[] message, int index)
        {
            char[] OctetoChar = message[index].ToCharArray(0, 8);
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
            index++;
            if (OctetoChar[7] == '1')
            {
                OctetoChar = message[index].ToCharArray(0, 8);
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
                index++;
                if (OctetoChar[7] == '1')
                {
                    OctetoChar = message[index].ToCharArray(0, 8);
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
                    index++;
                }
            }
            return index;
        }


        







    }
}