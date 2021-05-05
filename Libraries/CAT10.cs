using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecerixUPC.Libraries
{
    class CAT10
    {
        public string[] message;
        public int Id;
        
        public int numOctets;
        public int numItems = 0;

        public char[] FSPEC;

        //DATA SOURCE IDENTIFIER
        public string SAC;
        public string SIC;
        public string TAR;
        public int airportCode;
        //MESSAGE TYPE
        public string messageType;

        //TARGET REPORT DESCRIPTOR
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

        //TIME OF DAY
        public string TimeOfDay;
        public int TimeOfDayInSeconds;

        //POSITION IN WGS-84 CO-ORDINATES
        public string LatitudeWGS_84;
        public string LongitudeWGS_84;

        //MEASURED POSITION IN POLAR CO-ORDINATES
        public string RHO;
        public string THETA;

        //POSITION IN CARTESIAN CO-ORDINATES
        public string X_Component;
        public string Y_Component;
        public string Position_In_Polar;
        //CALCULATED TRACK VELOCITY IN POLAR CO-ORDINATES
        public string GroundSpeed;
        public string TrackAngle;

        //CALCULATED TRACK VELOCITY IN CARTESIAN CO-ORDINATES
        public string Vx;
        public string Vy;

        //TRACK NUMBER
        public string TrackNumber;

        //TRACK STATUS
        public string CNF;
        public string TRE;
        public string CST;
        public string MAH;
        public string TCC;
        public string STH;
        //First Extent
        public string TOM;
        public string DOU;
        public string MRS;
        //Second Extent
        public string GHO;


        //MODE-3/A CODE IN OCTAL REPRESANTATION
        public string VMode3A;
        public string GMode3A;
        public string LMode3A;
        public string Mode3A;

        //TARGET ADDRESS
        public string TargetAddress;

        //TARGET IDENTIFICATION
        public string STI;

        //MODE S MB DATA
        public string[] MBData;
        public string[] BDS1;
        public string[] BDS2;
        public int modeSrep;

        //VEHICLE FLEET IDENTIFICATION
        public string VFI;

        //FLIGHT LEVEL IN BINARY REPRESENTATION
        public string VFlightLevel;
        public string GFlightLevel;
        public string FlightLevelBinary;
        public string FlightLevel;

        //MEASURED HEIGHT
        public string MeasuredHeight;

        //TARGET SIZE & ORIENTATION
        public string LENGHT;
        public string ORIENTATION;
        public string WIDTH;

        //SYSTEM STATUS
        public string NOGO;
        public string OVL;
        public string TSV;
        public string DIV;
        public string TIF;

        //PRE-PROGRAMMED MESSAGE
        public string TRB;
        public string MSG;

        //STANDARD DEVIATION
        public string DeviationX;
        public string DeviationY;
        public string CovarianceXY;

        //PRESENCE
        public int REP = 0;
        public string[] DRHO;
        public string[] DTHETA;

        //AMPLITUDE OF PRIMARY PLOT
        public string PAM;

        //CALCULATED ACCELERATION
        public string Ax;
        public string Ay;

       
        public CAT10() {
            
        }
        /// <summary>
        ///  Clears the Cat10 Class, for reuse
        /// </summary>
        public void ClearCat()
        {
            this.message = null;
            this.Id = 0;

            this.numOctets = 0;
            this.FSPEC = null;

            //DATA SOURCE IDENTIFIER
            this.SAC = null;
            this.SIC = null;
            this.airportCode = 0;
            //MESSAGE TYPE
            this.messageType = null;

            //TARGET REPORT DESCRIPTOR
            this.TYP = null;
            this.DCR = null;
            this.CHN = null;
            this.GBS = null;
            this.CRT = null;
            //First extension
            this.SIM = null;
            this.TST = null;
            this.RAB = null;
            this.LOP = null;
            this.TOT = null;
            //Second extension
            this.SPI = null;

            //TIME OF DAY
            this.TimeOfDay = null;
            this.TimeOfDayInSeconds = 0;

            //POSITION IN WGS-84 CO-ORDINATES
            this.LatitudeWGS_84 = null;
            this.LongitudeWGS_84 = null;

            //MEASURED POSITION IN POLAR CO-ORDINATES
            this.RHO = null;
            this.THETA = null;

            //POSITION IN CARTESIAN CO-ORDINATES
            this.X_Component = null;
            this.Y_Component = null;

            //CALCULATED TRACK VELOCITY IN POLAR CO-ORDINATES
            this.GroundSpeed = null;
            this.TrackAngle = null;

            //CALCULATED TRACK VELOCITY IN CARTESIAN CO-ORDINATES
            this.Vx = null;
            this.Vy = null;

            //TRACK NUMBER
            this.TrackNumber = null;

            //TRACK STATUS
            this.CNF = null;
            this.TRE = null;
            this.CST = null;
            this.MAH = null;
            this.TCC = null;
            this.STH = null;
            //First Extent
            this.TOM = null;
            this.DOU = null;
            this.MRS = null;
            //Second Extent
            this.GHO = null;


            //MODE-3/A CODE IN OCTAL REPRESANTATION
            this.VMode3A = null;
            this.GMode3A = null;
            this.LMode3A = null;
            this.Mode3A = null;

            //TARGET ADDRESS
            this.TargetAddress = null;

            //TARGET IDENTIFICATION
            this.STI = null;

            //MODE S MB DATA
            this.MBData = null;
            this.BDS1 = null;
            this.BDS2 = null;
            this.modeSrep = 0;

            //VEHICLE FLEET IDENTIFICATION
            this.VFI = null;

            //FLIGHT LEVEL IN BINARY REPRESENTATION
            this.VFlightLevel = null;
            this.GFlightLevel = null;
            this.FlightLevelBinary = null;
            this.FlightLevel = null;

            //MEASURED HEIGHT
            this.MeasuredHeight = null;

            //TARGET SIZE & ORIENTATION
            this.LENGHT = null;
            this.ORIENTATION = null;
            this.WIDTH = null;

            //SYSTEM STATUS
            this.NOGO = null;
            this.OVL = null;
            this.TSV = null;
            this.DIV = null;
            this.TIF = null;

            //PRE-PROGRAMMED MESSAGE
            this.TRB = null;
            this.MSG = null;

            //STANDARD DEVIATION
            this.DeviationX = null;
            this.DeviationY = null;
            this.CovarianceXY = null;

            //PRESENCE
            this.REP = 0;
            this.DRHO = null;
            this.DTHETA = null;

            //AMPLITUDE OF PRIMARY PLOT
            this.PAM = null;

            //CALCULATED ACCELERATION
            this.Ax = null;
            this.Ay = null;

        }
        // Filled
        public CAT10(ref HelpDecode decode,ref CAT10Helper cat10Helper,string[] array, int id, string[] messageBinary)
        {   
            try
            {
                //Decode FSPEC
                string FSPEC0 = decode.getFSPEC(array);
                int octetsFSPEC = FSPEC0.Length / 7;
                int index = 3 + octetsFSPEC;
                this.FSPEC = FSPEC0.ToCharArray(0, FSPEC0.Length);
                message = messageBinary;
                this.Id = id;
                this.numOctets = array.Length;

                /* From now on each function looks to see if the decoding parameter exists in the 
                message (checking if the FSPEC in its position == 1) and if it exists calls the function to decode the parameter */

                if (FSPEC[0] == '1')
                {
                    index = cat10Helper.Compute_Data_Source_Identifier(message, index);
                    this.SAC = cat10Helper.SAC;
                    this.SIC = cat10Helper.SIC;
                    this.airportCode = cat10Helper.airportCode;
                    this.TAR = cat10Helper.TAR;
                } //
                if (FSPEC[1] == '1')
                {
                    index = cat10Helper.Compute_Message_Type(message, index);
                    this.messageType = cat10Helper.MESSAGE_TYPE;

                } //
                if (FSPEC[2] == '1')
                {
                    index = cat10Helper.Compute_Target_Report_Descriptor(message, index);
                    this.TYP = cat10Helper.TYP;
                    this.DCR = cat10Helper.DCR;
                    this.CHN = cat10Helper.CHN;
                    this.GBS = cat10Helper.GBS;
                    this.CRT = cat10Helper.CRT;
                    this.SIM = cat10Helper.SIM;
                    this.TST = cat10Helper.TST;
                    this.RAB = cat10Helper.RAB;
                    this.LOP = cat10Helper.LOP;
                    this.TOT = cat10Helper.TOT;
                    this.SPI = cat10Helper.SPI;

                } //
                if (FSPEC[3] == '1')
                {
                    index = cat10Helper.Compute_Time_of_Day(message, index);
                    this.TimeOfDay = cat10Helper.Time_Of_Day;
                    this.TimeOfDayInSeconds = cat10Helper.Time_of_day_sec;
                    

                } //
                if (FSPEC[4] == '1')
                {
                    index = cat10Helper.Compute_Position_in_WGS_84_Coordinates(message, index);
                    this.LatitudeWGS_84 = cat10Helper.Latitude_in_WGS_84;
                    this.LatitudeWGS_84 = cat10Helper.Longitude_in_WGS_84;
                    
                } //
                if (FSPEC[5] == '1')
                {
                    index = cat10Helper.Compute_Measured_Position_in_Polar_Coordinates(message, index);
                    this.RHO = cat10Helper.RHO;
                    this.THETA = cat10Helper.THETA;
                    
                }
                if (FSPEC[6] == '1')
                {
                    index = cat10Helper.Compute_Position_in_Cartesian_Coordinates(message, index);
                    this.X_Component = cat10Helper.X_Component;
                    this.Y_Component = cat10Helper.Y_Component;
                    this.Position_In_Polar = cat10Helper.Position_In_Polar;
                }  //
                if (FSPEC.Count() > 8)
                {
                    if (FSPEC[7] == '1')
                    {
                        index = cat10Helper.Compute_Track_Velocity_in_Polar_Coordinates(message, index);
                        this.GroundSpeed = cat10Helper.Ground_Speed;
                        this.TrackAngle = cat10Helper.Track_Angle;
                        
                    }  //
                    if (FSPEC[8] == '1')
                    {
                        index = cat10Helper.Compute_Track_Velocity_in_Cartesian_Coordinates(message, index);
                        this.Vx = cat10Helper.Vx;
                        this.Vy = cat10Helper.Vy;
                        
                    }  //
                    if (FSPEC[9] == '1')
                    {
                        index = cat10Helper.Compute_Track_Number(message, index);
                        this.TrackNumber = cat10Helper.Track_Number;
                        

                    }  //
                    if (FSPEC[10] == '1')
                    {
                        index = cat10Helper.Compute_Track_Status(message, index);
                        this.CNF = cat10Helper.CNF;
                        this.TRE = cat10Helper.TRE;
                        this.CST = cat10Helper.CST;
                        this.MAH = cat10Helper.MAH;
                        this.TCC = cat10Helper.TCC;
                        this.STH = cat10Helper.STH;
                        this.TOM = cat10Helper.TOM;
                        this.DOU = cat10Helper.DOU;
                        this.MRS = cat10Helper.MRS;
                        this.GHO = cat10Helper.GHO;

                    }  //
                    if (FSPEC[11] == '1')
                    {
                        index = cat10Helper.Compute_Mode_3A_Code_in_Octal_Representation(message, index);
                        this.VMode3A = cat10Helper.V_Mode_3A;
                        this.GMode3A = cat10Helper.G_Mode_3A;
                        this.LMode3A = cat10Helper.L_Mode_3A;
                        this.Mode3A = cat10Helper.Mode_3A;
                        
                    }  //
                    if (FSPEC[12] == '1')
                    {
                        index = cat10Helper.Compute_Target_Address(message, index);
                        this.TargetAddress = cat10Helper.Target_Address;

                    }  //
                    if (FSPEC[13] == '1')
                    {
                        index = cat10Helper.Compute_Target_Identification(message, index);
                        this.STI = cat10Helper.STI;
                        
                    }  //
                }
                if (FSPEC.Count() > 16)
                {
                    if (FSPEC[14] == '1')
                    {
                        index = cat10Helper.Compute_Mode_S_MB_Data(message, index);
                        this.MBData = cat10Helper.MB_Data;
                        this.BDS1 = cat10Helper.BDS1;
                        this.BDS2 = cat10Helper.BDS2;
                        this.modeSrep = cat10Helper.modeS_rep;
                        

                    }  //
                    if (FSPEC[15] == '1')
                    {
                        index = cat10Helper.Compute_Vehicle_Fleet_Identificatior(message, index);
                        this.VFI = cat10Helper.VFI;

                    }  //
                    if (FSPEC[16] == '1')
                    {
                        index = cat10Helper.Compute_Flight_Level_in_Binary_Representaion(message, index);
                        this.VFlightLevel = cat10Helper.V_Flight_Level;
                        this.GFlightLevel = cat10Helper.G_Flight_Level;
                        this.FlightLevelBinary = cat10Helper.Flight_Level_Binary;
                        this.FlightLevel = cat10Helper.Flight_Level;
                        

                    }  //
                    if (FSPEC[17] == '1')
                    {
                        index = cat10Helper.Compute_Measured_Height(message, index);
                        this.MeasuredHeight = cat10Helper.Measured_Height;
                        
                    }  //
                    if (FSPEC[18] == '1')
                    {
                        index = cat10Helper.Compute_Target_Size_and_Orientation(message, index);
                        this.LENGHT = cat10Helper.LENGHT;
                        this.ORIENTATION = cat10Helper.ORIENTATION;
                        this.WIDTH = cat10Helper.WIDTH;
                        
                    }  //
                    if (FSPEC[19] == '1')
                    {
                        index = cat10Helper.Compute_System_Status(message, index);
                        this.NOGO = cat10Helper.NOGO;
                        this.OVL = cat10Helper.OVL;
                        this.TSV = cat10Helper.TSV;
                        this.DIV = cat10Helper.DIV;
                        this.SAC = cat10Helper.TIF;
                        

                    }  //
                    if (FSPEC[20] == '1')
                    {
                        index = cat10Helper.Compute_Preprogrammed_Message(message, index);
                        this.TRB = cat10Helper.TRB;
                        this.MSG = cat10Helper.MSG;
                    } // 
                }
                if (FSPEC.Count() > 22)
                {
                    if (FSPEC[21] == '1')
                    {
                        index = cat10Helper.Compute_Standard_Deviation_of_Position(message, index);
                        this.DeviationX = cat10Helper.Deviation_X;
                        this.DeviationY = cat10Helper.Deviation_Y;
                        this.CovarianceXY = cat10Helper.Covariance_XY;
                        
                       
                    }
                    if (FSPEC[22] == '1')
                    {
                        index = cat10Helper.Compute_Presence(message, index);
                        this.REP = cat10Helper.REP_Presence;
                        this.DRHO = cat10Helper.DRHO;
                        this.DTHETA = cat10Helper.DTHETA;

                    }
                    if (FSPEC[23] == '1')
                    {
                        index = cat10Helper.Compute_Amplitude_of_Primary_Plot(message, index);
                        this.PAM = cat10Helper.PAM;
                        
                        
                    }
                    if (FSPEC[24] == '1')
                    {
                        index = cat10Helper.Compute_Calculated_Acceleration(message, index);
                        this.Ax = cat10Helper.Ax;
                        this.Ay = cat10Helper.Ay;
                        
                    }

                }
            }

            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }

    }
        
}
       

