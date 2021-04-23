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

        public int numItems = 0;
        public List<string> items = new List<string>();

        public char[] FSPEC;
        public string time;


        //DATA SOURCE IDENTIFIER
        public string SAC;
        public string SIC;

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

        //MEASURED POSITION IN POLAR CO-ORDINATES
        public string RHO;
        public string THETA;

        //POSITION IN WGS-84 CO-ORDINATES
        public string LatitudeWGS_84;
        public string LongitudeWGS_84;

        //POSITION IN CARTESIAN CO-ORDINATES
        public string X_Component;
        public string Y_Component;

        //MODE-3/A CODE IN OCTAL REPRESANTATION
        public string VMode3A;
        public string GMode3A;
        public string LMode3A;
        public string Mode3A;

        //FLIGHT LEVEL IN BINARY REPRESENTATION
        public string VFlightLevel;
        public string GFlightLevel;
        public string FlightLevelBinary;
        public string FlightLevel;

        //MEASURED HEIGHT
        public string MeasuredHeight;

        //AMPLITUDE OF PRIMARY PLOT
        public string PAM;

        //TIME OF DAY
        public string TimeOfDay;
        public int TimeOfDayInSeconds;

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

        //CALCULATED TRACK VELOCITY IN POLAR CO-ORDINATES
        public string GroundSpeed;
        public string TrackAngle;
        public string TrackVelocityPolar;

        //CALCULATED TRACK VELOCITY IN CARTESIAN CO-ORDINATES
        public string Vx;
        public string Vy;

        //CALCULATED ACCELERATION
        public string Ax;
        public string Ay;

        //TARGET ADDRESS
        public string TargetAddress;

        //TARGET IDENTIFICATION
        public string STI;
        public string Target_Identification;
        public string TAR;

        //MODE S MB DATA
        public string[] MBData;
        public string[] BDS1;
        public string[] BDS2;
        public int modeSrep;

        //TARGET SIZE & ORIENTATION
        public string LENGHT;
        public string ORIENTATION;
        public string WIDTH;

        //PRESENCE
        public int REP = 0;
        public string[] DRHO;
        public string[] DTHETA;

        //VEHICLE FLEET IDENTIFICATION
        public string VFI;

        //PRE-PROGRAMMED MESSAGE
        public string TRB;
        public string MSG;

        //PRE-PROGRAMMED MESSAGE
        public string DeviationX;
        public string DeviationY;
        public string CovarianceXY;

        //SYSTEM STATUS
        public string NOGO;
        public string OVL;
        public string TSV;
        public string DIV;
        public string TIF;

        public CAT10(string[] array, HelpDecode decode)
        {
            try
            {
                //Decode FSPEC
                string FSPEC0 = decode.getFSPEC(array);
                int numOctets = FSPEC0.Length / 7;
                int index = 3 + numOctets;
                this.FSPEC = FSPEC0.ToCharArray(0, FSPEC0.Length);
                message = decode.MessageToBinary(array);

                // DATA ITEM I010/010, DATA SOURCE IDENTIFIER
                /*Definition: Identification of the system from which the data are received.
                  Format: Two-octet fixed length Data Item.*/
                if (FSPEC[0] == '1')
                {
                    SAC = Convert.ToString(Convert.ToInt32(message[index], 2));
                    SIC = Convert.ToString(Convert.ToInt32(message[index + 1], 2));
                    index += 2;
                    numItems++;
                    items.Add("Data Source Identifier");
                }

                //DATA ITEM I010/000, MESSAGE TYPE
                /*Definition: This Data Item allows for a more convenient handling of the
                  messages at the receiver side by further defining the type of
                  transaction.
                  Format: One-octet fixed length Data Item.*/
                if (FSPEC[1] == '1')
                {
                    int Message_Type = Convert.ToInt32(message[index], 2);
                    if (Message_Type == 1) { messageType = "Target Report"; }
                    if (Message_Type == 2) { messageType = "Start of Update Cycle"; }
                    if (Message_Type == 3) { messageType = "Periodic Status Message"; }
                    if (Message_Type == 4) { messageType = "Event-triggered Status Message"; }
                    index++;
                    numItems++;
                    items.Add("Message Type");
                }

                /*Data Item I010/020, TARGET REPORT DESCRIPTOR
                 Definition: Type and characteristics of the data as transmitted by a
                 system.
                 Format: Variable length Data Item comprising a first part of one-octet,
                 followed by one-octet extents as necessary.  */
                if (FSPEC[2] == '1')
                {
                    int count = 1;
                    string firstOctet = message[index];
                    string TYP = firstOctet.Substring(0, 3);
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

                    string DCR = firstOctet.Substring(3, 1);
                    if (DCR == "0")
                        this.DCR = "No differential correction";
                    if (DCR == "1")
                        this.DCR = "Differential correction";

                    string CHN = firstOctet.Substring(4, 1);
                    if (CHN == "1")
                        this.CHN = "Chain 2";
                    if (CHN == "0")
                        this.CHN = "Chain 1";

                    string GBS = firstOctet.Substring(5, 1);
                    if (GBS == "0")
                        this.GBS = "Transponder Ground bit not set";
                    if (GBS == "1")
                        this.GBS = "Transponder Ground bit set";

                    string CRT = firstOctet.Substring(6, 1);
                    if (CRT == "0")
                        this.CRT = "No Corrupted reply in multilateration";
                    if (CRT == "1")
                        this.CRT = "Corrupted replies in multilateration";
                    string FX = Convert.ToString(firstOctet[7]);
                    while (FX == "1")
                    {
                        string newoctet = message[index + count];
                        FX = Convert.ToString(newoctet[7]);
                        if (count == 1)
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
                        count++;
                    }

                    index = index + count;
                }

                /* Data Item I010/040, MEASURED POSITION IN POLAR CO-ORDINATES
                   Definition: Measured position of a target in local polar co-ordinates.
                   Format: Four-octet fixed length Data Item */
                if (FSPEC[3] == '1')
                {
                    double range = Convert.ToInt32(string.Concat(message[index], message[index + 1]), 2);
                    if (range >= 65536)
                    {
                        if (range == 65536) { RHO = "RHO is the max range 65536m (35.4NM)"; }
                        else { RHO = "RHO is over max range 65536m (35.4NM)"; }
                    }
                    else { RHO = "ρ:" + Convert.ToString(range) + "m"; }
                    THETA = ", θ:" + String.Format("{0:0.00}", Convert.ToDouble(Convert.ToInt32(string.Concat(message[index + 2], message[index + 3]), 2)) * (360 / (Math.Pow(2, 16)))) + "°";
                    index += 4;
                }

                /*Data Item I010/041, POSITION IN WGS-84 CO-ORDINATES
                  Definition : Position of a target in WGS-84 Co-ordinates.
                  Format : Eight-octet fixed length Data Item */
                if (FSPEC[4] == '1')
                {
                    double Latitude = decode.TwoComplement2Decimal(string.Concat(message[index], message[index + 1], message[index + 2], message[index + 3])) * (180 / (Math.Pow(2, 31))); index += 4;
                    double Longitude = decode.TwoComplement2Decimal(string.Concat(message[index], message[index + 1], message[index + 2], message[index + 3])) * (180 / (Math.Pow(2, 31))); index += 4;

                    //Latitude in degrees minutes and seconds
                    int LatitudeDegrees = Convert.ToInt32(Math.Truncate(Latitude));
                    int LatitudeMinutes = Convert.ToInt32(Math.Truncate((Latitude - LatitudeDegrees) * 60));
                    double LatitudeSeconds = Math.Round(((Latitude - (LatitudeDegrees + (Convert.ToDouble(LatitudeMinutes) / 60))) * 3600), 3);

                    //Longitude in degrees minutes and seconds
                    int LongitudeDegrees = Convert.ToInt32(Math.Truncate(Longitude));
                    int LongitudeMinutes = Convert.ToInt32(Math.Truncate((Longitude - LongitudeDegrees) * 60));
                    double LongitudeSeconds = Math.Round(((Longitude - (LongitudeDegrees + (Convert.ToDouble(LongitudeMinutes) / 60))) * 3600), 3);

                    LatitudeWGS_84 = Convert.ToString(LatitudeDegrees) + "º " + Convert.ToString(LatitudeMinutes) + "' " + Convert.ToString(LatitudeSeconds) + "''";
                    LongitudeWGS_84 = Convert.ToString(LongitudeDegrees) + "º" + Convert.ToString(LongitudeMinutes) + "' " + Convert.ToString(LongitudeSeconds) + "''";

                }

                /*Data Item I010/042, POSITION IN CARTESIAN CO-ORDINATES 
                  Definition: Position of a target in Cartesian co-ordinates, in two’s complement form.
                  Format: Four-octet fixed length Data Item . */
                if (FSPEC[5] == '1')
                {
                    double X_Coordinate = decode.TwoComplement2Decimal(string.Concat(message[index], message[index + 1])); index = +2;
                    double Y_Coordinate = decode.TwoComplement2Decimal(string.Concat(message[index], message[index + 1])); index = +2;
                    X_Component = Convert.ToString(X_Coordinate);
                    Y_Component = Convert.ToString(Y_Coordinate);

                }

                /* Data Item I010/060, MODE-3/A CODE IN OCTAL REPRESANTATION
                   Definition: Mode-3/A code converted into octal representation.
                   Format: Two-octet fixed length Data Item. */
                if (FSPEC[6] == '1')
                {
                    char[] Octet = message[index].ToCharArray(0, 8);
                    if (Octet[0] == '0') { VMode3A = "V: Code validated"; }
                    else { VMode3A = "V: Code not validated"; }
                    if (Octet[1] == '0') { GMode3A = "G: Default"; }
                    else { GMode3A = "G: Garbled code"; }
                    if (Octet[2] == '0') { LMode3A = "L: Mode-3/A code derived from the reply of the transponder"; }
                    else { LMode3A = "L: Mode-3/A code not extracted during the last scan"; }
                    Mode3A = Convert.ToString(decode.Decimal2Octal(Convert.ToInt32(string.Concat(message[index], message[index + 1]).Substring(4, 12), 2))).PadLeft(4, '0');
                    index += 2;
                }

                /*Data Item I010/090, FLIGHT LEVEL IN BINARY REPRESENTATION
                  Definition: Flight Level (Mode C / Mode S Altitude) converted into binary two's complement representation.
                  Format: Two-octet fixed length Data Item. */
                if (FSPEC[7] == '1')
                {
                    char[] Octet = message[index].ToCharArray(0, 8);
                    if (Octet[0] == '0') { VFlightLevel = "Code validated"; }
                    else { VFlightLevel = "Code not validated"; }
                    if (Octet[1] == '0') { GFlightLevel = "Default"; }
                    else { GFlightLevel = "Garbled code"; }
                    FlightLevelBinary = Convert.ToString(decode.TwoComplement2Decimal(string.Concat(message[index], message[index + 1]).Substring(2, 14)) * (1 / 4));
                    FlightLevel = Convert.ToString(Convert.ToDouble(FlightLevelBinary) * 100) + " ft";
                    index += 2;
                }

                /*Data Item I010/091, MEASURED HEIGHT ???????
                Definition: Height above local 2D co-ordinate reference system (two's
                complement) based on direct measurements not related to
                barometric pressure.
                Format: Two-octet fixed length Data Item. */
                if (FSPEC[8] == '1')
                {
                    MeasuredHeight = Convert.ToString(decode.TwoComplement2Decimal(string.Concat(message[index], message[index + 1])) * 6.25) + " ft";

                    if (Convert.ToInt32(MeasuredHeight) >= 204 || Convert.ToInt32(MeasuredHeight) <= -204)
                    {
                        MeasuredHeight = "Max value reached or exceeded (+/- 204 ft)";
                    }
                    index += 2;
                }

                /* Data Item I010/131, AMPLITUDE OF PRIMARY PLOT
                 Definition: Amplitude of Primary Plot.
                 Format: One-Octet fixed length Data Item. 
                */
                if (FSPEC[9] == '1')
                {
                    double pam = Convert.ToInt32(message[index], 2);
                    if (pam == 0) { PAM = "PAM: 0, the minimum detectable level for the radar"; }
                    if (pam == 255) { PAM = "PAM: 255, the maximum level for the radar"; }
                    if (pam > 255) { PAM = "PAM is over the maximum level for the radar"; }
                    else { PAM = "PAM: " + Convert.ToString(Convert.ToInt32(message[index], 2)); }
                    index++;
                }

                /* Data Item I010 / 140, TIME OF DAY
                   Definition: Absolute time stamping expressed as UTC.
                   Format: Three - octet fixed length Data Item.*/
                if (FSPEC[10] == '1')
                {
                    int str = Convert.ToInt32(string.Concat(message[index], message[index + 1], message[index + 2]), 2);
                    double seconds = (Convert.ToDouble(str) / 128);
                    TimeOfDayInSeconds = Convert.ToInt32(Math.Truncate(seconds));
                    TimeSpan time = TimeSpan.FromSeconds(seconds);
                    TimeOfDay = time.ToString(@"hh\:mm\:ss\:fff");
                    index += 3;
                }

                /*Data Item I010/161, TRACK NUMBER
                 Definition: An integer value representing a unique reference to a track
                 record within a particular track file.
                 Format: Two-octet fixed length Data Item.*/
                if (FSPEC[11] == '1')
                {
                    TrackNumber = Convert.ToString(Convert.ToInt32(string.Concat(message[index], message[index + 1]).Substring(4, 12), 2));
                    index += 2;
                }

                /*Data Item I010 / 170, TRACK STATUS
                 Definition: Status of track.
                 Format: Variable length Data Item comprising a first part of one-octet,
                 followed by one - octet extents as necessary.*/
                if (FSPEC[12] == '1')
                {
                    char[] Octet = message[index].ToCharArray(0, 8);
                    if (Octet[0] == '0') { CNF = "Confirmed track"; }
                    else { CNF = "Track in initialisation phase"; }
                    if (Octet[1] == '0') { TRE = "TRE: Default"; }
                    else { TRE = "TRE: Last report for a track"; }
                    int crt = Convert.ToInt32(string.Concat(Octet[2], Octet[3]), 2);
                    if (crt == 0) { CST = "No extrapolation"; }
                    else if (crt == 1) { CST = "Predictable extrapolation due to sensor refresh period"; }
                    else if (crt == 2) { CST = "Predictable extrapolation in masked area"; }
                    else if (crt == 3) { CST = "Extrapolation due to unpredictable absence of detection"; }
                    if (Octet[4] == '0') { MAH = "MAH: Default"; }
                    else { MAH = "MAH: Horizontal manoeuvre"; }
                    if (Octet[5] == '0') { TCC = "Tracking performed in 'Sensor Plane', i.e. neither slant range correction nor projection was applied"; }
                    else { TCC = "Slant range correction and a suitable projection technique are used to track in a 2D.reference plane, tangential to the earth model at the Sensor Site co-ordinates"; }
                    if (Octet[6] == '0') { STH = "Measured position"; }
                    else { STH = "Smoothed position"; }
                    index++;
                    //First Extent
                    if (Octet[7] == '1')
                    {
                        Octet = message[index].ToCharArray(0, 8);
                        int tom = Convert.ToInt32(string.Concat(Octet[0], Octet[1]), 2);
                        if (tom == 0) { TOM = "TOM: Unknown type of movement"; }
                        else if (tom == 1) { TOM = "TOM: Taking-off"; }
                        else if (tom == 2) { TOM = "TOM: Landing"; }
                        else if (tom == 3) { TOM = "TOM: Other types of movement"; }
                        int dou = Convert.ToInt32(string.Concat(Octet[2], Octet[3], Octet[4]), 2);
                        if (dou == 0) { DOU = "No doubt"; }
                        else if (dou == 1) { DOU = "Doubtful correlation (undetermined reason)"; }
                        else if (dou == 2) { DOU = "Doubtful correlation in clutter"; }
                        else if (dou == 3) { DOU = "Loss of accuracy"; }
                        else if (dou == 4) { DOU = "Loss of accuracy in clutter"; }
                        else if (dou == 5) { DOU = "Unstable track"; }
                        else if (dou == 6) { DOU = "Previously coasted"; }
                        int mrs = Convert.ToInt32(string.Concat(Octet[5], Octet[6]), 2);
                        if (mrs == 0) { MRS = "Merge or split indication undetermined"; }
                        else if (mrs == 1) { MRS = "Track merged by association to plot"; }
                        else if (mrs == 2) { MRS = "Track merged by non-association to plot"; }
                        else if (mrs == 3) { MRS = "Split track"; }
                        index++;
                        //Second Extent
                        if (Octet[7] == '1')
                        {
                            Octet = message[index].ToCharArray(0, 8);
                            if (Octet[0] == '0') { GHO = "GHO: Default"; }
                            else { GHO = "Ghost track"; }
                            index++;
                        }
                    }
                }

                /*Data Item I010/200, CALCULATED TRACK VELOCITY IN POLAR CO-ORDINATES
                Definition: Calculated track velocity expressed in polar co-ordinates.
                Format : Four-Octet fixed length data item. */
                if (FSPEC[13] == '1')
                {
                    double groundspeed = Convert.ToDouble(Convert.ToInt32(string.Concat(message[index], message[index + 1]), 2)) * Math.Pow(2, -14);
                    double meters = groundspeed * 1852;
                    if (groundspeed > 2) { GroundSpeed = "Ground Speed exceeds the max value (2 NM/s) or is the max value, "; }
                    if (groundspeed == 2) { GroundSpeed = "Ground Speed in the max value of  2 NM/s "; }
                    else { GroundSpeed = "GS: " + String.Format("{0:0.00}", meters) + " m/s, "; }
                    TrackAngle = "T.A: " + String.Format("{0:0.00}", (Convert.ToInt32(string.Concat(message[index + 2], message[index + 3]), 2)) * (360 / (Math.Pow(2, 16)))) + "°";
                    index += 4;
                }

                /*Data Item I010/202, CALCULATED TRACK VELOCITY IN CARTESIAN CO-ORDINATES
                Definition: Calculated track velocity expressed in Cartesian coordinates, in two’s complement representation.
                Format: Four-octet fixed length Data Item .*/
                if (FSPEC[14] == '1')
                {
                    double vx = (decode.TwoComplement2Decimal(string.Concat(message[index], message[index + 1])) * 0.25);
                    Vx = "Vx: " + Convert.ToString(vx) + " m/s, ";
                    double vy = (decode.TwoComplement2Decimal(string.Concat(message[index + 2], message[index + 3])) * 0.25);
                    Vy = "Vy: " + Convert.ToString(vy) + " m/s";
                    index += 4;
                }

                /* Data Item I010/210, CALCULATED ACCELERATION
                   Definition : Calculated Acceleration of the target, in two’s complement form.
                   Format : Two-Octet fixed length data item.*/
                if (FSPEC[15] == '1')
                {
                    double ax = decode.TwoComplement2Decimal(message[index]) * 0.25;
                    double ay = decode.TwoComplement2Decimal(message[index + 1]) * 0.25;
                    if (Convert.ToInt32(ax) >= 31 || Convert.ToInt32(ax) <= -31)
                    {
                        Ax = "Ax reached or exceeded the max value (+-31 m/s^2)";
                    }
                    else { Ax = "Ax: " + Convert.ToString(ax) + "m/s^2"; }
                    if (Convert.ToInt32(ay) >= 31 || Convert.ToInt32(ax) <= -31)
                    {
                        Ay = "Ay reached or exceeded the max value (+-31 m/s^2)";
                    }
                    else { Ay = "Ay: " + Convert.ToString(ay) + "m/s^2"; }
                    index += 2;
                }

                /*Data Item I010/220, TARGET ADDRESS
                Definition: Target address (24-bits address) assigned uniquely to each
                Target.
                Format: Three-octet fixed length Data Item. */
                if (FSPEC[16] == '1')
                {
                    TargetAddress = string.Concat(decode.Binary2Hex(message[index]), decode.Binary2Hex(message[index + 1]), decode.Binary2Hex(message[index + 2]));
                    index += 3;
                }

                /*Data Item I010/245, TARGET IDENTIFICATION ??????????
                Definition: Target (aircraft or vehicle) identification in 8 characters.
                Format: Seven-octet fixed length Data Item. */
                if (FSPEC[17] == '1')
                {
                    char[] Octet = message[index].ToCharArray(0, 8);
                    int sti = Convert.ToInt32(string.Concat(Octet[0], Octet[1]), 2);
                    if (sti == 0) { STI = "Callsign or registration downlinked from transponder"; }
                    else if (sti == 1) { STI = "Callsign not downlinked from transponder"; }
                    else if (sti == 2) { STI = "Registration not downlinked from transponder"; }
                    string IdentificationOctets = string.Concat(message[index + 1], message[index + 2], message[index + 3], message[index + 4], message[index + 5], message[index + 6]);
                    index += 7;
                }

                /*Data Item I010/250, MODE S MB DATA
                Definition: Mode S Comm B data as extracted from the aircraft
                transponder.
                Format: Repetitive Data Item starting with a one-octet Field Repetition
                Indicator (REP) followed by at least one BDS report comprising
                one seven octet BDS register and one octet BDS code. */
                if (FSPEC[18] == '1')
                {
                    modeSrep = Convert.ToInt32(message[index], 2);
                    if (modeSrep < 0) { MBData = new string[modeSrep]; BDS1 = new string[modeSrep]; BDS2 = new string[modeSrep]; }
                    index++;
                    for (int i = 0; i < modeSrep; i++)
                    {
                        MBData[i] = String.Concat(message[index], message[index + 1], message[index + 2], message[index + 3], message[index + 4], message[index + 5], message[index + 6]);
                        BDS1[1] = message[index + 7].Substring(0, 4);
                        BDS2[1] = message[index + 7].Substring(4, 4);
                        index += 8;
                    }
                }

                /*Data Item I010/270, TARGET SIZE & ORIENTATION
                Definition: Target size defined as length and width of the detected
                target, and orientation.
                 Format: Variable length Data Item comprising a first part of one octet,
                followed by one-octet extents as necessary. */
                if (FSPEC[19] == '1')
                {
                    LENGHT = "Lenght:  " + Convert.ToString(Convert.ToInt32(message[index].Substring(0, 7), 2)) + "m";
                    index++;
                    if (message[index - 1].Substring(7, 1) == "1")
                    {
                        ORIENTATION = "Orientation: " + Convert.ToString(Convert.ToDouble(Convert.ToInt32(message[index].Substring(0, 7), 2)) * (360 / 128)) + "°";
                        index++;
                        if (message[index - 1].Substring(7, 1) == "1")
                        {
                            WIDTH = "Widht: " + Convert.ToString(Convert.ToInt32(message[index].Substring(0, 7), 2)) + "m";
                            index++;
                        }
                    }
                }

                /* Data Item I010 / 280, PRESENCE
                   Definition: Positions of all elementary presences constituting a plot.
                   Format: Repetitive Data Item, starting with a one octet Field
                   Repetition Indicator(REP) indicating the number of
                   presences associated to the plot, followed by series of two
                   octets(co - ordinates differences) as necessary.*/
                if (FSPEC[20] == '1')
                {
                    REP = Convert.ToInt32(string.Concat(message[index]), 2);
                    index++;
                    for (int i = 0; i < REP; i++)
                    {
                        DRHO[i] = Convert.ToString(Convert.ToInt32(message[index], 2)) + "m";
                        DTHETA[i] = Convert.ToString(Convert.ToDouble(Convert.ToInt32(message[index + 1], 2)) * 0.15) + "º";
                        index += 2;
                    }
                }

                /* Data Item I010/300, VEHICLE FLEET IDENTIFICATION
                   Definition: Vehicle fleet identification number.
                   Format: One octet fixed length Data Item. */
                if (FSPEC[21] == '1')
                {
                    int vfi = Convert.ToInt32(message[index], 2);
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
                    index++;
                }

                /* Data Item I010/310, PRE-PROGRAMMED MESSAGE
                   Definition: Number related to a pre-programmed message that can be
                   transmitted by a vehicle.
                   Format: One octet fixed length Data Item.*/
                if (FSPEC[22] == '1')
                {

                    char[] Octet = message[index].ToCharArray(0, 8);
                    if (Octet[0] == '0') { TRB = "Trouble: Default"; }
                    else if (Octet[0] == '1') { TRB = "Trouble: In Trouble"; }
                    int msg = Convert.ToInt32(message[index].Substring(1, 7), 2);
                    if (msg == 1) { MSG = "Message: Towing aircraft"; }
                    else if (msg == 2) { MSG = "Message: “Follow me” operation"; }
                    else if (msg == 3) { MSG = "Message: Runway check"; }
                    else if (msg == 4) { MSG = "Message: Emergency operation (fire, medical…)"; }
                    else if (msg == 5) { MSG = "Message: Work in progress (maintenance, birds scarer, sweepers…)"; }
                    index++;
                }

                /*Data Item I010/500, STANDARD DEVIATION OF POSITION
                 Definition: Standard Deviation of Position
                 Format: Four octet fixed length Data Item. */
                if (FSPEC[23] == '1')
                {
                    DeviationX = "Standard Deviation of X component (σx):" + Convert.ToString(Convert.ToDouble(Convert.ToInt32(message[index], 2)) * 0.25) + "m";
                    DeviationY = "Standard Deviation of Y component (σy): " + Convert.ToString(Convert.ToDouble(Convert.ToInt32(message[index + 1], 2)) * 0.25) + "m";
                    CovarianceXY = "Covariance (σxy): " + Convert.ToString(decode.TwoComplement2Decimal(string.Concat(message[index + 2], message[index + 3])) * 0.25) + "m^2";
                    index += 4;
                }

                /*Data Item I010/550, SYSTEM STATUS
                  Definition: Information concerning the configuration and status of a
                  System.
                  Format: One-octet fixed length Data Item. */
                if (FSPEC[24] == '1')
                {
                    char[] Octet = message[index].ToCharArray(0, 8);
                    int nogo = Convert.ToInt32(string.Concat(Octet[0], Octet[1]), 2);
                    if (nogo == 0) { NOGO = "Operational Release Status of the System (NOGO): Operational"; }
                    else if (nogo == 1) { NOGO = "Operational Release Status of the System (NOGO): Degraded"; }
                    else if (nogo == 2) { NOGO = "Operational Release Status of the System (NOGO): NOGO"; }
                    if (Octet[2] == '0') { OVL = "Overload indicator: No overload"; }
                    else if (Octet[2] == '1') { OVL = "Overload indicator: Overload"; }
                    if (Octet[3] == '0') { TSV = "Time Source Validity: Valid"; }
                    else if (Octet[3] == '1') { TSV = "Time Source Validity: Invalid"; }
                    if (Octet[4] == '0') { DIV = "DIV: Normal Operation"; }
                    else if (Octet[4] == '1') { DIV = "DIV: Diversity degraded"; }
                    if (Octet[5] == '0') { TIF = "TIF: Test Target Operative"; }
                    else if (Octet[5] == '1') { TIF = "TIF: Test Target Failure"; }
                    index++;
                }
            }


            catch { }
        }

    }

}


