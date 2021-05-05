using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMap.NET;

namespace DecerixUPC.Libraries
{
    class CAT10Helper
    {   
        private HelpDecode lib;
        public char[] FSPEC;
        public CAT10Helper(HelpDecode decode)
        {
            this.lib = decode;
        }

        /// <summary>
        /// Data Item I010/000, Message Type
        /// 
        /// Definition: This Data Item allows for a more convenient handling of the messages at the receiver side by further defining the type of transaction.
        /// Format: One-octet fixed length Data Item.
        /// </summary>
        public string MESSAGE_TYPE;
        public int Compute_Message_Type(string[] message, int pos)
        {
            MESSAGE_TYPE = "Error";
            int Message_Type = Convert.ToInt32(message[pos], 2);
            if (Message_Type == 1) { MESSAGE_TYPE = "Target Report"; }
            if (Message_Type == 2) { MESSAGE_TYPE = "Start of Update Cycle"; }
            if (Message_Type == 3) { MESSAGE_TYPE = "Periodic Status Message"; }
            if (Message_Type == 4) { MESSAGE_TYPE = "Event-triggered Status Message"; }
            pos++;
            return pos;
        }

        /// <summary>
        /// Data Item I010/010, Data Source Identifier
        /// 
        /// Definition: Identification of the system from which the data are received.
        /// Format: Two-octet fixed length Data Item.
        /// </summary>
        public string SAC;
        public string SIC;
        public int airportCode;
        public int Compute_Data_Source_Identifier(string[] message, int pos)
        {
            SAC = Convert.ToString(Convert.ToInt32(message[pos], 2));
            SIC = Convert.ToString(Convert.ToInt32(message[pos + 1], 2));
            this.airportCode = GetAirporteCode(Convert.ToInt32(SIC));
            pos += 2;
            return pos;
        }
        public int GetAirporteCode(int SIC)
        {
            int i = 0;
            if (SIC == 107 || SIC == 7 || SIC == 219) { i = 0; } //BARCELONA
            else if (SIC == 5 || SIC == 105 || SIC == 209) { i = 1; } //ASTURIAS
            else if (SIC == 2 || SIC == 102) { i = 2; } //PALMA
            else if (SIC == 6 || SIC == 106 || SIC == 227 || SIC == 228) { i = 3; } //SANTIAGO
            else if (SIC == 3 || SIC == 4 || SIC == 104) { i = 4; } //BARAJAS
            else if (SIC == 1 || SIC == 101) { i = 5; } //TENERIFE
            else if (SIC == 108) { i = 6; } //Malaga
            else if (SIC == 203) { i = 7; } //Bilbao
            else if (SIC == 206) { i = 8; } //ALICANTE
            else if (SIC == 207) { i = 9; } //GRANADA
            else if (SIC == 210) { i = 10; } //LANZAROTE
            else if (SIC == 211) { i = 11; } //TURRILLAS
            else if (SIC == 212) { i = 12; } //Menorca
            else if (SIC == 213 || SIC == 229) { i = 13; } //IBIZA
            else if (SIC == 214) { i = 14; } //VALDESPINA
            else if (SIC == 215 || SIC == 221) { i = 15; } //PARACUELLOS
            else if (SIC == 216) { i = 16; } //RANDA
            else if (SIC == 218) { i = 17; } //GERONA
            else if (SIC == 220 || SIC == 222) { i = 18; } //ESPIÑEIRAS
            else if (SIC == 223) { i = 19; } //VEJER
            else if (SIC == 224) { i = 20; } //YESTE
            else if (SIC == 225 || SIC == 226) { i = 21; } //VIGO
            else if (SIC == 230) { i = 22; } //VALENCIA
            else if (SIC == 231) { i = 23; } //SEVILLA
            return i;
        }
        /// <summary>
        /// Data Item I010/020, Target Report Descriptor
        /// 
        /// Definition: Type and characteristics of the data as transmitted by a system.
        /// Format: Variable length Data Item comprising a first part of one-octet, followed by one-octet extents as necessary.
        /// </summary>

        public string TYP;
        public string DCR;
        public string CHN;
        public string GBS;
        public string CRT;
        //First extension
        public string SIM;
        public string TST;
        public string RAB;
        public string LOP;
        public string TOT;
        //Second extension
        public string SPI;
        public int Compute_Target_Report_Descriptor(string[] message, int pos)
        {
            int cont = 1;
            string octeto1 = message[pos];
            string TYP = octeto1.Substring(0, 3);
            if (TYP == "000")
                this.TYP = "SSR MLAT";
            if (TYP == "001")
                this.TYP = "Mode S MLAT";
            if (TYP == "010")
                this.TYP = "ADS-B";
            if (TYP == "011")
                this.TYP = "PSR";
            if (TYP == "100")
                this.TYP = "Magnetic Loop System";
            if (TYP == "101")
                this.TYP = "HF MLAT";
            if (TYP == "110")
                this.TYP = "Not defined";
            if (TYP == "111")
                this.TYP = "Other types";

            string DCR = octeto1.Substring(3, 1);
            if (DCR == "0")
                this.DCR = "No differential correction";
            if (DCR == "1")
                this.DCR = "Differential correction";

            string CHN = octeto1.Substring(4, 1);
            if (CHN == "1")
                this.CHN = "Chain 2";
            if (CHN == "0")
                this.CHN = "Chain 1";

            string GBS = octeto1.Substring(5, 1);
            if (GBS == "0")
                this.GBS = "Transponder Ground bit not set";
            if (GBS == "1")
                this.GBS = "Transponder Ground bit set";

            string CRT = octeto1.Substring(6, 1);
            if (CRT == "0")
                this.CRT = "No Corrupted reply in multilateration";
            if (CRT == "1")
                this.CRT = "Corrupted replies in multilateration";
            string FX = Convert.ToString(octeto1[7]);
            while (FX == "1")
            {
                string newoctet = message[pos + cont];
                FX = Convert.ToString(newoctet[7]);
                if (cont == 1)
                {
                    string SIM = newoctet.Substring(0, 1);
                    if (SIM == "0")
                        this.SIM = "Actual target report";
                    if (SIM == "1")
                        this.SIM = "Simulated target report";

                    string TST = newoctet.Substring(1, 1);
                    if (TST == "0")
                        this.TST = "TST: Default";
                    if (TST == "1")
                        this.TST = "Test Target";

                    string RAB = newoctet.Substring(2, 1);
                    if (RAB == "0")
                        this.RAB = "Report from target transponder";
                    if (RAB == "1")
                        this.RAB = "Report from field monitor (fixed transponder)";

                    string LOP = newoctet.Substring(3, 2);
                    if (LOP == "00")
                        this.LOP = "Loop status: Undetermined";
                    if (LOP == "01")
                        this.LOP = "Loop start";
                    if (LOP == "10")
                        this.LOP = "Loop finish";

                    string TOT = newoctet.Substring(5, 2);
                    if (TOT == "00")
                        this.TOT = "Type of vehicle: Undetermined";
                    if (TOT == "01")
                        this.TOT = "Aircraft";
                    if (TOT == "10")
                        this.TOT = "Ground vehicle";
                    if (TOT == "11")
                        this.TOT = "Helicopter";
                }
                else
                {
                    if (newoctet.Substring(0, 1) == "0")
                        this.SPI = "Absence of SPI (Special Position Identification)";
                    if (newoctet.Substring(0, 1) == "1")
                        this.SPI = "SPI (Special Position Identification)";
                }
                cont++;
            }
            pos = cont + pos;
            return pos;
        }


        /// <summary>
        /// Data Item I010/040, Measured Position in Polar Co-ordinates
        /// 
        /// Definition: Measured position of a target in local polar co-ordinates.
        /// Format: Four-octet fixed length Data Item.
        /// </summary>
        public string RHO;
        public string THETA;
        public string Position_In_Polar;
        public int Compute_Measured_Position_in_Polar_Coordinates(string[] message, int pos)
        {
            double Range = Convert.ToInt32(string.Concat(message[pos], message[pos + 1]), 2); //I suppose in meters
            if (Range >= 65536) { RHO = "RHO exceds the max range or is the max range "; } //RHO = " + Convert.ToString(Range) + "m"; MessageBox.Show("RHO exceed the max range or is the max range, RHO = {0}m", Convert.ToString(Range)); }
            else { RHO = "ρ:" + Convert.ToString(Range) + "m"; }//MessageBox.Show("RHO is the max range, RHO = {0}m", Convert.ToString(Range)); }
            THETA = ", θ:" + String.Format("{0:0.00}", Convert.ToDouble(Convert.ToInt32(string.Concat(message[pos + 2], message[pos + 3]), 2)) * (360 / (Math.Pow(2, 16)))) + "°"; //I suppose in degrees
            Position_In_Polar = RHO + THETA;
            pos += 4;
            return pos;
        }


        /// <summary>
        /// Data Item I010/041, Position in WGS-84 Co-ordinates
        /// 
        /// Definition : Position of a target in WGS-84 Co-ordinates.
        /// Format : Eight-octet fixed length Data Item
        /// </summary>
        /// <param name="Latitude_in_WGS_84">Latitude in Degrees minutes seconds that will show in the tables</param>
        /// <param name="Longitudee_in_WGS_84">Longitude in Degrees minutes seconds that will show in the tables</param>
        /// <param name="Latitude_in_WGS_84_map">Latitude in decimals used to draw markers on map</param>
        /// <param name="Latitude_in_WGS_84_map">Longiutde in decimals used to draw markers on map</param>
        /// 
        public string Latitude_in_WGS_84;
        public string Longitude_in_WGS_84;
        public double LatitudeWGS_84_map = -200;
        public double LongitudeWGS_84_map = -200;
        public int Compute_Position_in_WGS_84_Coordinates(string[] message, int pos)
        {
            double Latitude = this.lib.TwoComplement2Decimal(string.Concat(message[pos], message[pos + 1], message[pos + 2], message[pos + 3])) * (180 / (Math.Pow(2, 31))); pos += 4;
            double Longitude = this.lib.TwoComplement2Decimal(string.Concat(message[pos], message[pos + 1], message[pos + 2], message[pos + 3])) * (180 / (Math.Pow(2, 31))); pos += 4;
            int Latdegres = Convert.ToInt32(Math.Truncate(Latitude));
            int Latmin = Convert.ToInt32(Math.Truncate((Latitude - Latdegres) * 60));
            double Latsec = Math.Round(((Latitude - (Latdegres + (Convert.ToDouble(Latmin) / 60))) * 3600), 5);
            int Londegres = Convert.ToInt32(Math.Truncate(Longitude));
            int Lonmin = Convert.ToInt32(Math.Truncate((Longitude - Londegres) * 60));
            double Lonsec = Math.Round(((Longitude - (Londegres + (Convert.ToDouble(Lonmin) / 60))) * 3600), 5);
            Latitude_in_WGS_84 = Convert.ToString(Latdegres) + "º " + Convert.ToString(Latmin) + "' " + Convert.ToString(Latsec) + "''";
            Longitude_in_WGS_84 = Convert.ToString(Londegres) + "º" + Convert.ToString(Lonmin) + "' " + Convert.ToString(Lonsec) + "''";
            return pos;
        }
 

        /// <summary>
        /// Data Item I010/042, Position in Cartesian Co-ordinates
        /// 
        /// Definition: Position of a target in Cartesian co-ordinates, in two’s complement form.
        /// Format: Four-octet fixed length Data Item.
        /// </summary>
        /// <param name="Position_Cartesian_Coordinates"> Position in string format for tables </param>
        /// <param name="X_Component_map">X componet to use in map</param>
        /// <param name="Y_Component_map">Y component to use in map</param>
        public double X_Component_map = -99999;
        public double Y_Component_map = -99999;
        public string X_Component;
        public string Y_Component;
        public string Position_Cartesian_Coordinates;
        public int Compute_Position_in_Cartesian_Coordinates(string[] message, int pos)
        {
            X_Component_map = this.lib.TwoComplement2Decimal(string.Concat(message[pos], message[pos + 1]));
            Y_Component_map = this.lib.TwoComplement2Decimal(string.Concat(message[pos + 2], message[pos + 3]));
            X_Component = Convert.ToString(X_Component_map);
            Y_Component = Convert.ToString(Y_Component_map);
            Position_Cartesian_Coordinates = "X: " + X_Component + ", Y: " + Y_Component;
            Point p = new Point(X_Component_map, Y_Component_map);
           /* PointLatLng position = ComputeWGS_84_from_Cartesian(p, this.SIC);*/ //Compute WGS84 position from cartesian position
            /*Set_WGS84_Coordinates(position);*/ //Apply computed WGS84 position to this message
            pos += 4;
            return pos;
        }

        /// Calculate WGS84 coordinates from Cartesian
        /// </summary>
        /// <param name="p"> Cartesian coordenates of the object</param>
        /// <param name="SIC">SIC of the radar which detected the object, to know which radar is and where it's placed </param>
        /// <returns>Object WGS84 coordinates</returns>
        /*public PointLatLng ComputeWGS_84_from_Cartesian(Point p, string SIC)
        {
            PointLatLng pos = new PointLatLng();
            double X = p.X;
            double Y = p.Y;
            CoordinatesXYZ ObjectCartesian = new CoordinatesXYZ(X, Y, 0); //We pass from Point to CoordinatesXYZ to be able to work with the GeoUtils library
            PointLatLng AirportPoint = GetCoordenatesSMRMALT(Convert.ToInt32(SIC)); //We get the Radar coordinates from its SIC
            CoordinatesWGS84 AirportGeodesic = new CoordinatesWGS84(AirportPoint.Lat * (Math.PI / 180), AirportPoint.Lng * (Math.PI / 180)); //We went from PointLatLng to Coordinates WGS84 to be able to work with GeoUtils. Coordinates must be passed from degrees to radians
            GeoUtils geoUtils = new GeoUtils();
            CoordinatesWGS84 MarkerGeodesic = geoUtils.change_system_cartesian2geodesic(ObjectCartesian, AirportGeodesic); //We apply the change from CoordiantesXYZ to Coordinate GS83
            geoUtils = null;
            double LatitudeWGS_84_map = MarkerGeodesic.Lat * (180 / Math.PI);
            double LongitudeWGS_84_map = MarkerGeodesic.Lon * (180 / Math.PI);
            pos.Lat = LatitudeWGS_84_map;
            pos.Lng = LongitudeWGS_84_map;
            return pos;
        }*/
        /// <summary>
        /// Returns de coordenates of the SMR or MLAT from the introduced SIC code
        /// </summary>
        /// <param name="SIC"> SIC code of the radar </param>
        /// <returns>Coordinates of the radar</returns>
        public PointLatLng GetCoordenatesSMRMALT(int SIC)
        {
            PointLatLng point = new PointLatLng(0, 0);
            if (SIC == 1) { point = SMRTenerife; }
            else if (SIC == 2) { point = SMRPalma; }
            else if (SIC == 3) { point = SMRBarajas_S; }
            else if (SIC == 4) { point = SMRBarajas_N; }
            else if (SIC == 5) { point = SMRAsturias; }
            else if (SIC == 6) { point = SMRSantiago; }
            else if (SIC == 7) { point = SMRBarcelona; }
            else if (SIC == 101) { point = ARPTenerife; }
            else if (SIC == 102) { point = ARPPalma; }
            else if (SIC == 104) { point = ARPBarajas; }
            else if (SIC == 105) { point = ARPAsturias; }
            else if (SIC == 106) { point = ARPSantiago; }
            else if (SIC == 107) { point = ARPBarcelona; }
            else if (SIC == 108) { point = ARPMalaga; }
            return point;
        }
        PointLatLng SMRAsturias = new PointLatLng(43.56464083, -6.030623056);
        PointLatLng SMRBarcelona = new PointLatLng(41.29561833, 2.095114167);
        PointLatLng SMRPalma = new PointLatLng(39.54864778, 2.732764444);
        PointLatLng SMRSantiago = new PointLatLng(42.89805333, -8.413033056);
        PointLatLng SMRBarajas_N = new PointLatLng(40.49184306, -3.569051667);
        PointLatLng SMRBarajas_S = new PointLatLng(40.46814972, -3.568730278);
        PointLatLng SMRTenerife = new PointLatLng(28.47749583, -16.33252028);
        PointLatLng ARPPalma = new PointLatLng(39.5486842, 2.73276111);
        PointLatLng ARPAsturias = new PointLatLng(43.56356722, -6.034621111);
        PointLatLng ARPBarajas = new PointLatLng(40.47224833, -3.560945278);
        PointLatLng ARPBarcelona = new PointLatLng(41.2970767, 2.07846278);
        PointLatLng ARPMalaga = new PointLatLng(36.67497111, -4.499206944);
        PointLatLng ARPTenerife = new PointLatLng(28.48265333, -16.34153722);
        PointLatLng ARPSantiago = new PointLatLng(42.896335, -8.41514361);
        /// <summary>
        /// Apply WGS84 position to this message 
        /// </summary>
        /// <param name="pos">Computed WGS84 position</param>

        public void Set_WGS84_Coordinates(PointLatLng pos)
        {
            LatitudeWGS_84_map = pos.Lat;
            LongitudeWGS_84_map = pos.Lng;
            int Latdegres = Convert.ToInt32(Math.Truncate(LatitudeWGS_84_map));
            int Latmin = Convert.ToInt32(Math.Truncate((LatitudeWGS_84_map - Latdegres) * 60));
            double Latsec = Math.Round(((LatitudeWGS_84_map - (Latdegres + (Convert.ToDouble(Latmin) / 60))) * 3600), 5);
            int Londegres = Convert.ToInt32(Math.Truncate(LongitudeWGS_84_map));
            int Lonmin = Convert.ToInt32(Math.Truncate((LongitudeWGS_84_map - Londegres) * 60));
            double Lonsec = Math.Round(((LongitudeWGS_84_map - (Londegres + (Convert.ToDouble(Lonmin) / 60))) * 3600), 5);
            Latitude_in_WGS_84 = Convert.ToString(Latdegres) + "º " + Convert.ToString(Latmin) + "' " + Convert.ToString(Latsec) + "''";
            Longitude_in_WGS_84 = Convert.ToString(Londegres) + "º" + Convert.ToString(Lonmin) + "' " + Convert.ToString(Lonsec) + "''";
        }

        /// <summary>
        /// Data Item I010/060, Mode-3/A Code in Octal Representation
        /// 
        /// Definition: Mode-3/A code converted into octal representation
        /// Format: Two-octet fixed length Data Item.
        /// </summary>
        // DATA ITEM I010/060, MODE-3/A CODE IN OCTAL REPRESANTATION
        public string V_Mode_3A;
        public string G_Mode_3A;
        public string L_Mode_3A;
        public string Mode_3A;
        public int Compute_Mode_3A_Code_in_Octal_Representation(string[] message, int pos)
        {
            char[] OctetoChar = message[pos].ToCharArray(0, 8);
            if (OctetoChar[0] == '0') { V_Mode_3A = "V: Code validated"; }
            else { V_Mode_3A = "V: Code not validated"; }
            if (OctetoChar[1] == '0') { G_Mode_3A = "G: Default"; }
            else { G_Mode_3A = "G: Garbled code"; }
            if (OctetoChar[2] == '0') { L_Mode_3A = "L: Mode-3/A code derived from the reply of the transponder"; }
            else { L_Mode_3A = "L: Mode-3/A code not extracted during the last scan"; }
            Mode_3A = Convert.ToString(this.lib.Decimal2Octal(Convert.ToInt32(string.Concat(message[pos], message[pos + 1]).Substring(4, 12), 2))).PadLeft(4, '0');
            pos += 2;
            return pos;
        }

        /// <summary>
        /// Data Item I010/090, Flight Level in Binary Representation
        /// 
        /// Definition: Flight Level (Mode C / Mode S Altitude) converted into binary two's complement representation.
        /// Format: Two-octet fixed length Data Item.
        /// </summary>
        public string V_Flight_Level;
        public string G_Flight_Level;
        public string Flight_Level_Binary;
        public string Flight_Level;
        public int Compute_Flight_Level_in_Binary_Representaion(string[] message, int pos)
        {
            char[] OctetoChar = message[pos].ToCharArray(0, 8);
            if (OctetoChar[0] == '0') { V_Flight_Level = "Code validated"; }
            else { V_Flight_Level = "Code not validated"; }
            if (OctetoChar[1] == '0') { G_Flight_Level = "Default"; }
            else { G_Flight_Level = "Garbled code"; }
            Flight_Level_Binary = Convert.ToString(this.lib.TwoComplement2Decimal(string.Concat(message[pos], message[pos + 1]).Substring(2, 14)) * (0.25));
            Flight_Level = V_Flight_Level + ", " + G_Flight_Level + ", Flight Level: " + Flight_Level_Binary;
            Flight_Level = Convert.ToString(Convert.ToDouble(Flight_Level_Binary) * 100) + " ft";
            pos += 2;
            return pos;
        }

        /// <summary>
        /// Data Item I010/091, Measured Height
        /// 
        /// Definition: Height above local 2D co-ordinate reference system (two's complement) based on direct measurements not related to barometric pressure.
        /// Format: Two-octet fixed length Data Item.
        /// </summary>
        public string Measured_Height;
        public int Compute_Measured_Height(string[] message, int pos)
        {
            Measured_Height = Convert.ToString(this.lib.TwoComplement2Decimal(string.Concat(message[pos], message[pos + 1])) * 6.25) + " ft";
            pos += 2;
            return pos;
        }

        /// <summary>
        /// Data Item I010/131, Amplitude of Primary Plot
        /// 
        /// Definition: Amplitude of Primary Plot.
        /// Format: One-Octet fixed length Data Item.
        /// </summary>
        public string PAM;
        public int Compute_Amplitude_of_Primary_Plot(string[] message, int pos)
        {
            double pam = Convert.ToInt32(message[pos], 2); // Lo de Range 0.255 no se si está bien ponerlo
            if (pam == 0) { PAM = "PAM: 0, the minimum detectable level for the radar"; }
            else { PAM = "PAM: " + Convert.ToString(Convert.ToInt32(message[pos], 2)); }
            pos++;
            return pos;
        }


        /// <summary>
        /// Data Item I010/140, Time of Day
        /// 
        /// Definition: Absolute time stamping expressed as UTC.
        /// Format: Three-octet fixed length Data Item.
        /// </summary>
        /// <param name="Time_of_day_sec">Seconds in int format to be used in map</param>
        /// <param name="Time_of_day_sec">Seconds in string format to be shown in tables</param>
        public string Time_Of_Day;
        public int Time_of_day_sec;
        public int Compute_Time_of_Day(string[] message, int pos)
        {
            int str = Convert.ToInt32(string.Concat(message[pos], message[pos + 1], message[pos + 2]), 2);
            double segundos = (Convert.ToDouble(str) / 128);
            Time_of_day_sec = Convert.ToInt32(Math.Truncate(segundos));
            TimeSpan tiempo = TimeSpan.FromSeconds(segundos);
            Time_Of_Day = tiempo.ToString(@"hh\:mm\:ss\:fff");
            pos += 3;
            return pos;
        }

        /// <summary>
        /// Data Item I010/161, Track Number
        /// 
        /// Definition: An integer value representing a unique reference to a track record within a particular track file.
        /// Format: Two-octet fixed length Data Item.
        /// </summary>
        public string Track_Number;
        public int Compute_Track_Number(string[] message, int pos)
        {
            Track_Number = Convert.ToString(Convert.ToInt32(string.Concat(message[pos], message[pos + 1]).Substring(4, 12), 2));
            pos += 2;
            return pos;
        }

        
        /// <summary>
        /// Data Item I010/170, Track Status
        /// 
        /// Definition: Status of track.
        /// Format: Variable length Data Item comprising a first part of one-octet, followed by one-octet extents as necessary.
        /// </summary>

        public string CNF;
        public string TRE;
        public string CST;
        public string MAH;
        public string TCC;
        public string STH;
        public string TOM;
        public string DOU;
        public string MRS;
        public string GHO;
        public int Compute_Track_Status(string[] message, int pos)
        {
            char[] OctetoChar = message[pos].ToCharArray(0, 8);
            if (OctetoChar[0] == '0') { CNF = "Confirmed track"; }
            else { CNF = "Track in initialisation phase"; }
            if (OctetoChar[1] == '0') { TRE = "TRE: Default"; }
            else { TRE = "TRE: Last report for a track"; }
            int crt = Convert.ToInt32(string.Concat(OctetoChar[2], OctetoChar[3]), 2);
            if (crt == 0) { CST = "No extrapolation"; }
            else if (crt == 1) { CST = "Predictable extrapolation due to sensor refresh period"; }
            else if (crt == 2) { CST = "Predictable extrapolation in masked area"; }
            else if (crt == 3) { CST = "Extrapolation due to unpredictable absence of detection"; }
            if (OctetoChar[4] == '0') { MAH = "MAH: Default"; }
            else { MAH = "MAH: Horizontal manoeuvre"; }
            if (OctetoChar[5] == '0') { TCC = "Tracking performed in 'Sensor Plane', i.e. neither slant range correction nor projection was applied"; }
            else { TCC = "Slant range correction and a suitable projection technique are used to track in a 2D.reference plane, tangential to the earth model at the Sensor Site co-ordinates"; }
            if (OctetoChar[6] == '0') { STH = "Measured position"; }
            else { STH = "Smoothed position"; }
            pos++;
            if (OctetoChar[7] == '1')
            {
                OctetoChar = message[pos].ToCharArray(0, 8);
                int tom = Convert.ToInt32(string.Concat(OctetoChar[0], OctetoChar[1]), 2);
                if (tom == 0) { TOM = "TOM: Unknown type of movement"; }
                else if (tom == 1) { TOM = "TOM: Taking-off"; }
                else if (tom == 2) { TOM = "TOM: Landing"; }
                else if (tom == 3) { TOM = "TOM: Other types of movement"; }
                int dou = Convert.ToInt32(string.Concat(OctetoChar[2], OctetoChar[3], OctetoChar[4]), 2);
                if (dou == 0) { DOU = "No doubt"; }
                else if (dou == 1) { DOU = "Doubtful correlation (undetermined reason)"; }
                else if (dou == 2) { DOU = "Doubtful correlation in clutter"; }
                else if (dou == 3) { DOU = "Loss of accuracy"; }
                else if (dou == 4) { DOU = "Loss of accuracy in clutter"; }
                else if (dou == 5) { DOU = "Unstable track"; }
                else if (dou == 6) { DOU = "Previously coasted"; }
                int mrs = Convert.ToInt32(string.Concat(OctetoChar[5], OctetoChar[6]), 2);
                if (mrs == 0) { MRS = "Merge or split indication undetermined"; }
                else if (mrs == 1) { MRS = "Track merged by association to plot"; }
                else if (mrs == 2) { MRS = "Track merged by non-association to plot"; }
                else if (mrs == 3) { MRS = "Split track"; }
                pos++;
                if (OctetoChar[7] == '1')
                {
                    OctetoChar = message[pos].ToCharArray(0, 8);
                    if (OctetoChar[0] == '0') { GHO = "GHO: Default"; }
                    else { GHO = "Ghost track"; }
                    pos++;
                }
            }
            return pos;
        }

        /// <summary>
        /// Data Item I010/200, Calculated Track Velocity in Polar Co-ordinates
        /// 
        /// Definition: Calculated track velocity expressed in polar co-ordinates.
        /// Format : Four-Octet fixed length data item.
        /// </summary>
        public string Ground_Speed;
        public string Track_Angle;
        public string Track_Velocity_Polar_Coordinates;
        public int Compute_Track_Velocity_in_Polar_Coordinates(string[] message, int pos)
        {
            double ground_speed = Convert.ToDouble(Convert.ToInt32(string.Concat(message[pos], message[pos + 1]), 2)) * Math.Pow(2, -14);
            double meters = ground_speed * 1852;
            if (ground_speed >= 2) { Ground_Speed = "Ground Speed exceed the max value (2 NM/s) or is the max value, "; }
            else { Ground_Speed = "GS: " + String.Format("{0:0.00}", meters) + " m/s, "; }
            Track_Angle = "T.A: " + String.Format("{0:0.00}", (Convert.ToInt32(string.Concat(message[pos + 2], message[pos + 3]), 2)) * (360 / (Math.Pow(2, 16)))) + "°";
            Track_Velocity_Polar_Coordinates = Ground_Speed + Track_Angle;
            pos += 4;
            return pos;
        }

        
        /// <summary>
        /// Data Item I010/202, Calculated Track Velocity in Cartesian Co-ordinates
        /// 
        /// Definition: Calculated track velocity expressed in Cartesian co-ordinates, in two’s complement representation.
        /// Format: Four-octet fixed length Data Item.
        /// </summary>
        public string Vx;
        public string Vy;
        public string Track_Velocity_in_Cartesian_Coordinates;
        public int Compute_Track_Velocity_in_Cartesian_Coordinates(string[] message, int pos)
        {
            double vx = (this.lib.TwoComplement2Decimal(string.Concat(message[pos], message[pos + 1])) * 0.25);
            Vx = "Vx: " + Convert.ToString(vx) + " m/s, ";
            double vy = (this.lib.TwoComplement2Decimal(string.Concat(message[pos + 2], message[pos + 3])) * 0.25);
            Vy = "Vy: " + Convert.ToString(vy) + " m/s";
            Track_Velocity_in_Cartesian_Coordinates = Vx + Vy;
            pos += 4;
            return pos;
        }

        /// <summary>
        /// Definition : Calculated Acceleration of the target, in two’s complement form.
        /// Format : Two-Octet fixed length data item.
        /// </summary>
        public string Ax;
        public string Ay;
        public string Calculated_Acceleration;
        public int Compute_Calculated_Acceleration(string[] message, int pos)
        {
            double ax = this.lib.TwoComplement2Decimal(message[pos]) * 0.25;
            double ay = this.lib.TwoComplement2Decimal(message[pos + 1]) * 0.25;
            if (Convert.ToInt32(ax) >= 31 || Convert.ToInt32(ax) <= -31) { Ax = "Ax exceed the max value or is the max value (+-31 m/s^2)"; }
            else { Ax = "Ax: " + Convert.ToString(ax) + "m/s^2"; }
            if (Convert.ToInt32(ay) >= 31 || Convert.ToInt32(ax) <= -31) { Ay = "Ay exceed the max value or is the max value (+-31 m/s^2)"; }
            else { Ay = "Ay: " + Convert.ToString(ay) + "m/s^2"; }
            Calculated_Acceleration = Ax + " " + Ay;
            pos += 2;
            return pos;
        }


        /// <summary> 
        /// Data Item I010/220, Target Address
        /// 
        /// Definition: Target address (24-bits address) assigned uniquely to each Target.
        /// Format: Three-octet fixed length Data Item.
        /// </summary>
        public string Target_Address;
        public int Compute_Target_Address(string[] message, int pos)
        {
            Target_Address = string.Concat(this.lib.Binary2Hex(message[pos]), this.lib.Binary2Hex(message[pos + 1]), this.lib.Binary2Hex(message[pos + 2]));
            pos += 3;
            return pos;
        }


        /// <summary>
        /// Data Item I010/245, Target Identification
        /// 
        /// Definition: Target (aircraft or vehicle) identification in 8 characters.
        /// Format: Seven-octet fixed length Data Item.
        /// </summary>
        public string STI;
        public string Target_Identification;
        public string TAR;
        public int Compute_Target_Identification(string[] message, int pos)
        {
            char[] OctetoChar = message[pos].ToCharArray(0, 8);
            int sti = Convert.ToInt32(string.Concat(OctetoChar[0], OctetoChar[1]), 2);
            if (sti == 0) { STI = "Callsign or registration downlinked from transponder"; }
            else if (sti == 1) { STI = "Callsign not downlinked from transponder"; }
            else if (sti == 2) { STI = "Registration not downlinked from transponder"; }
            StringBuilder Identification = new StringBuilder();
            string octets = string.Concat(message[pos + 1], message[pos + 2], message[pos + 3], message[pos + 4], message[pos + 5], message[pos + 6]);
            for (int i = 0; i < 8; i++) { Identification.Append(this.lib.Compute_Char(octets.Substring(i * 6, 6))); }
            TAR = Identification.ToString().Trim();
            pos += 7;
            return pos;
        }



        /// <summary>
        /// Data Item I010/250, Mode S MB Data
        /// 
        /// Definition: Mode S Comm B data as extracted from the aircraft transponder.
        /// Format: Repetitive Data Item starting with a one-octet Field Repetition Indicator(REP) followed by at least
        /// one BDS report comprising one seven octet BDS register and one octet BDS code.
        /// </summary>
        public string[] MB_Data;
        public string[] BDS1;
        public string[] BDS2;
        public int modeS_rep;
        public int Compute_Mode_S_MB_Data(string[] message, int pos)
        {
            modeS_rep = Convert.ToInt32(message[pos], 2);
            if (modeS_rep < 0) { MB_Data = new string[modeS_rep]; BDS1 = new string[modeS_rep]; BDS2 = new string[modeS_rep]; }
            pos++;
            for (int i = 0; i < modeS_rep; i++)
            {
                MB_Data[i] = String.Concat(message[pos], message[pos + 1], message[pos + 2], message[pos + 3], message[pos + 4], message[pos + 5], message[pos + 6]);
                BDS1[1] = message[pos + 7].Substring(0, 4);
                BDS2[1] = message[pos + 7].Substring(4, 4);
                pos += 8;
            }
            return pos;
        }


        /// <summary>
        /// Data Item I010/270, Target Size & Orientation
        /// 
        /// Definition: Target size defined as length and width of the detected target, and orientation.
        /// Format: Variable length Data Item comprising a first part of one octet, followed by one-octet extents as necessary.
        /// </summary>

        public string Target_size_and_orientation;
        public string LENGHT;
        public string ORIENTATION;
        public string WIDTH;
        public int Compute_Target_Size_and_Orientation(string[] message, int pos)
        {
            LENGHT = "Lenght:  " + Convert.ToString(Convert.ToInt32(message[pos].Substring(0, 7), 2)) + "m";
            Target_size_and_orientation = LENGHT;
            pos = pos++;
            if (message[pos - 1].Substring(7, 1) == "1")
            {
                ORIENTATION = "Orientation: " + Convert.ToString(Convert.ToDouble(Convert.ToInt32(message[pos].Substring(0, 7), 2)) * (360 / 128)) + "°";
                Target_size_and_orientation = Target_size_and_orientation + ", " + ORIENTATION;
                pos = pos++;
                if (message[pos - 1].Substring(7, 1) == "1")
                {
                    WIDTH = "Widht: " + Convert.ToString(Convert.ToInt32(message[pos].Substring(0, 7), 2)) + "m";
                    Target_size_and_orientation = Target_size_and_orientation + ", " + WIDTH;
                    pos = pos++;
                }
            }
            return pos;
        }


        /// <summary>
        /// Data Item I010/280, Presence
        ///
        /// Definition: Positions of all elementary presences constituting a plot.
        /// Format: Repetitive Data Item, starting with a one octet Field Repetition Indicator(REP) 
        /// indicating the number of presences associated to the plot, followed by series of two octets(co-ordinates differences) as necessary.
        /// </summary>
        public int REP_Presence = 0;
        public string[] DRHO;
        public string[] DTHETA;
        public int Compute_Presence(string[] message, int pos)
        {
            REP_Presence = Convert.ToInt32(string.Concat(message[pos]), 2);
            pos++;
            for (int i = 0; i < REP_Presence; i++)
            {
                this.DRHO[i] = Convert.ToString(Convert.ToInt32(message[pos], 2)) + "m";
                this.DTHETA[i] = Convert.ToString(Convert.ToDouble(Convert.ToInt32(message[pos + 1], 2)) * 0.15) + "º";
                pos += 2;
            }
            return pos;
        }

        /// <summary>
        /// Data Item I010/300, Vehicle Fleet Identification
        /// 
        /// Definition: Vehicle fleet identification number.
        /// Format: One octet fixed length Data Item.
        /// </summary>
        public string VFI;
        public int Compute_Vehicle_Fleet_Identificatior(string[] message, int pos)
        {
            int vfi = Convert.ToInt32(message[pos], 2);
            if (vfi == 0) { VFI = "Unknown"; }
            else if (vfi == 1) { VFI = "ATC equipment maintenance"; }
            else if (vfi == 2) { VFI = "Airport maintenance"; }
            else if (vfi == 3) { VFI = "Fire"; }
            else if (vfi == 4) { VFI = "Bird scarer"; }
            else if (vfi == 5) { VFI = "Snow plough"; }
            else if (vfi == 6) { VFI = "Runway sweeper"; }
            else if (vfi == 7) { VFI = "Emergency"; }
            else if (vfi == 8) { VFI = "Police"; }
            else if (vfi == 9) { VFI = "Bus"; }
            else if (vfi == 10) { VFI = "Tug (push/tow)"; }
            else if (vfi == 11) { VFI = "Grass cutter"; }
            else if (vfi == 12) { VFI = "Fuel"; }
            else if (vfi == 13) { VFI = "Baggage"; }
            else if (vfi == 14) { VFI = "Catering"; }
            else if (vfi == 15) { VFI = "Aircraft maintenance"; }
            else if (vfi == 16) { VFI = "Flyco (follow me)"; }
            pos = pos++;
            return pos;
        }

        
        /// <summary>
        /// Data Item I010/310, Pre-programmed Message
        /// 
        /// Definition: Number related to a pre-programmed message that can be transmitted by a vehicle.
        /// Format: One octet fixed length Data Item.
        /// </summary>
        public string TRB;
        public string MSG;
        public string Pre_programmed_message;
        public int Compute_Preprogrammed_Message(string[] message, int pos)
        {
            char[] OctetoChar = message[pos].ToCharArray(0, 8);
            if (OctetoChar[0] == '0') { TRB = "Trouble: Default"; }
            else if (OctetoChar[0] == '1') { TRB = "Trouble: In Trouble"; }
            int msg = Convert.ToInt32(message[pos].Substring(1, 7), 2);
            if (msg == 1) { MSG = "Message: Towing aircraft"; }
            else if (msg == 2) { MSG = "Message: “Follow me” operation"; }
            else if (msg == 3) { MSG = "Message: Runway check"; }
            else if (msg == 4) { MSG = "Message: Emergency operation (fire, medical…)"; }
            else if (msg == 5) { MSG = "Message: Work in progress (maintenance, birds scarer, sweepers…)"; }
            pos++;
            Pre_programmed_message = TRB + " " + MSG;
            return pos;
        }

        /// <summary>
        /// Data Item I010/500, Standard Deviation of Position
        /// 
        /// Definition: Standard Deviation of Position
        /// Format: Four octet fixed length Data Item.
        /// </summary>
        public string Deviation_X;
        public string Deviation_Y;
        public string Covariance_XY;
        public int Compute_Standard_Deviation_of_Position(string[] message, int pos)
        {
            Deviation_X = "Standard Deviation of X component (σx):" + Convert.ToString(Convert.ToDouble(Convert.ToInt32(message[pos], 2)) * 0.25) + "m";
            Deviation_Y = "Standard Deviation of Y component (σy): " + Convert.ToString(Convert.ToDouble(Convert.ToInt32(message[pos + 1], 2)) * 0.25) + "m";
            Covariance_XY = "Covariance (σxy): " + Convert.ToString(this.lib.TwoComplement2Decimal(string.Concat(message[pos + 2], message[pos + 3])) * 0.25) + "m^2";
            pos += 4;
            return pos;
        }

       
        /// <summary>
        /// Data Item I010/550, System Status
        /// 
        /// Definition: Information concerning the configuration and status of a System.
        /// Format: One-octet fixed length Data Item.
        /// </summary>
        public string NOGO;
        public string OVL;
        public string TSV;
        public string DIV;
        public string TIF;
        public int Compute_System_Status(string[] message, int pos)
        {
            char[] OctetoChar = message[pos].ToCharArray(0, 8);
            int nogo = Convert.ToInt32(string.Concat(OctetoChar[0], OctetoChar[1]), 2);
            if (nogo == 0) { NOGO = "Operational Release Status of the System (NOGO): Operational"; }
            else if (nogo == 1) { NOGO = "Operational Release Status of the System (NOGO): Degraded"; }
            else if (nogo == 2) { NOGO = "Operational Release Status of the System (NOGO): NOGO"; }
            if (OctetoChar[2] == '0') { OVL = "Overload indicator: No overload"; }
            else if (OctetoChar[2] == '1') { OVL = "Overload indicator: Overload"; }
            if (OctetoChar[3] == '0') { TSV = "Time Source Validity: Valid"; }
            else if (OctetoChar[3] == '1') { TSV = "Time Source Validity: Invalid"; }
            if (OctetoChar[4] == '0') { DIV = "DIV: Normal Operation"; }
            else if (OctetoChar[4] == '1') { DIV = "DIV: Diversity degraded"; }
            if (OctetoChar[5] == '0') { TIF = "TIF: Test Target Operative"; }
            else if (OctetoChar[5] == '1') { TIF = "TIF: Test Target Failure"; }
            pos = pos++;
            return pos;
        }

        
    }
    
}
