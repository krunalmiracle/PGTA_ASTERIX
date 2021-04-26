using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DecerixUPC.Libraries;
namespace DecerixUPC
{
    public partial class DecodeFile : Form
    {
        List<CAT21v21> cat21;
        List<CAT10> cat10;
        CAT10 selectedCat10;
        public DecodeFile()
        {
            InitializeComponent();


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataBlock.ColumnCount = 3;
            DataBlock.Columns[0].Name = "Block Offset";
            DataBlock.Columns[1].Name = "Length";
            DataBlock.Columns[2].Name = "Category";

            DataRecord.ColumnCount = 4;
            DataRecord.Columns[0].Name = "Block Offset";
            DataRecord.Columns[1].Name = "Time";
            DataRecord.Columns[2].Name = "Length";
            DataRecord.Columns[3].Name = "#Items";

            DataItems.ColumnCount = 5;
            DataItems.Columns[0].Name = "Item Offset";
            DataItems.Columns[1].Name = "Length";
            DataItems.Columns[2].Name = "FRN";
            DataItems.Columns[3].Name = "Field Type";
            DataItems.Columns[4].Name = "Description";

        }

        private void loadFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "txt files (*.txt)|*.txt*|ast files (*.ast)|*.ast*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.ShowDialog();
            String filePath = openFileDialog.FileName;
            AsterixFile file = new AsterixFile();
            file.read(filePath);
            //AsterixFileHex.Text = file.getHex();

            List<int> DataBlocks = file.getDataBlocks();
            cat10 = file.getListCAT10();
            cat21 = file.getListCAT21();
            DataBlock.RowCount = DataBlocks.Count;


            int index10 = 0;
            int index21 = 0;
            for (int i = 0; i < DataBlocks.Count; i++)
            {
                if (DataBlocks[i] == 10)
                {
                    DataBlock.Rows[i].HeaderCell.Value = i + 1;
                    DataBlock.Rows[i].Cells[0].Value = cat10[index10].offset[0];
                    DataBlock.Rows[i].Cells[1].Value = cat10[index10].numOctets;
                    DataBlock.Rows[i].Cells[2].Value = 10;
                    index10++;

                }
            }


        }

        private void DataBlock_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            selectedCat10 = cat10.Find(CAT10 => CAT10.Id == rowIndex);
            if (selectedCat10 != null)
            {
                DataRecord.Rows[0].HeaderCell.Value = 1;
                DataRecord.Rows[0].Cells[0].Value = selectedCat10.offset;
                DataRecord.Rows[0].Cells[1].Value = selectedCat10.TimeOfDayInSeconds;
                DataRecord.Rows[0].Cells[2].Value = selectedCat10.numOctets - 3;
                DataRecord.Rows[0].Cells[3].Value = selectedCat10.numItems;



            }

        }

        private void DataRecord_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            for (int i = 0; i < selectedCat10.numItems - 1; i++)
            {

                DataItems.Rows[i].HeaderCell.Value = i + 1;
                DataItems.Rows[i].Cells[0].Value = selectedCat10.offset[i];
                DataItems.Rows[i].Cells[1].Value = selectedCat10.FRN[i];
                DataItems.Rows[i].Cells[2].Value = selectedCat10.FieldType[i];
                DataItems.Rows[i].Cells[3].Value = selectedCat10.Description[i];
            }
        }

        private void DataItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int FRN = selectedCat10.FRN[rowIndex];
            string title = selectedCat10.FieldType[rowIndex] + " " + selectedCat10.Description[rowIndex] + "\n";
            switch (FRN)
            {
                case 1:
                    //DATA SOURCE IDENTIFIER
                    FieldType.Text = title + "SAC=" + selectedCat10.SAC + "\n" + "SIC=" + selectedCat10.SIC;
                    break;
                case 2:
                    //MESSAGE TYPE
                    FieldType.Text = title + selectedCat10.messageType;
                    break;

                case 3:
                    //TARGET REPORT DESCRIPTOR
                    string TYP= "TYP=" + selectedCat10.TYP + "\n";
                    string DCR= "DCR=" + selectedCat10.DCR + "\n"; 
                    string CHN ="CHN=" + selectedCat10.CHN + "\n";
                    string GBS = "GBS=" + selectedCat10.GBS + "\n";
                    string CRT = "CRT=" + selectedCat10.CRT + "\n";
                    string target_report = title + TYP + DCR + CHN + GBS + CRT;
                    if (selectedCat10.SIM != null)
                    {
                        //First extension
                        string SIM = "SIM=" + selectedCat10.SIM + "\n";
                        string TST = "TST=" + selectedCat10.TST + "\n";
                        string RAB = "RAB=" + selectedCat10.RAB + "\n";
                        string LOP = "LOP=" + selectedCat10.LOP + "\n";
                        string TOT = "TOT=" + selectedCat10.TOT + "\n";
                        target_report = target_report + SIM + TST + RAB + LOP + TOT;
                    }
                    if (selectedCat10.SPI != null)
                    {
                        //Second extension
                        string SPI = "SPI=" + selectedCat10.SPI + "\n";
                        target_report = target_report + SPI;
                    }
                    FieldType.Text = target_report;
                    break;

                case 4:
                     //TIME OF DAY
                    string TIME= "Time of the Day=" + selectedCat10.TimeOfDay;
                    FieldType.Text = title+TIME;
                    break;

                case 5:
                    //POSITION IN WGS-84 CO-ORDINATES
                    string LatitudeWGS_84 = "Latitude in WGS-84" + selectedCat10.LatitudeWGS_84 + "\n";
                    string LongitudeWGS_84 = "Longitude in WGS-84" + selectedCat10.LongitudeWGS_84 + "\n";
                    FieldType.Text = title + LatitudeWGS_84 + LongitudeWGS_84;
                    break;

                case 6:
                     //MEASURED POSITION IN POLAR CO-ORDINATES
                    string RHO= "RHO="+selectedCat10.RHO+"\n";
                    string THETA = "THETA=" + selectedCat10.THETA + "\n";
                    FieldType.Text = title + RHO + THETA;
                    break;

                case 7:
                    //POSITION IN CARTESIAN CO-ORDINATES
                    string X_Component="X =" + selectedCat10.X_Component + "\n"; 
                    string Y_Component = "Y =" + selectedCat10.X_Component + "\n";
                    FieldType.Text = title + X_Component + Y_Component;
                    break;

                case 8:
                    //CALCULATED TRACK VELOCITY IN POLAR CO-ORDINATES
                    string GroundSpeed = "Ground Speed=" + selectedCat10.GroundSpeed + "\n";
                    string TrackAngle = "Track Angle=" + selectedCat10.TrackAngle + "\n";
                    FieldType.Text = title + GroundSpeed + TrackAngle;
                    break;

                case 9:
                    //CALCULATED TRACK VELOCITY IN CARTESIAN CO-ORDINATES
                    string Vx = "Vx=" + selectedCat10.Vx + "\n";
                    string Vy = "Vy=" + selectedCat10.Vy + "\n";
                    FieldType.Text = title + Vx + Vy;
                    break;

                case 10:
                     //TRACK NUMBER
                    string TrackNumber = "Track Number=" + selectedCat10.TrackNumber + "\n";
                    FieldType.Text = title + TrackNumber;
                    break;

                case 11:
                     //TRACK STATUS
                    string CNF = "CNF=" + selectedCat10.CNF + "\n";
                    string TRE = "TRE=" + selectedCat10.TRE + "\n";
                    string CST = "CST=" + selectedCat10.CST + "\n";
                    string MAH = "MAH=" + selectedCat10.MAH + "\n";
                    string TCC = "TCC=" + selectedCat10.TCC + "\n";
                    string STH = "STH=" + selectedCat10.STH + "\n";
                    string track = title + CNF + TRE + CST + MAH + TCC + STH;
                    //First Extent
                    if (selectedCat10.TOM != null)
                    {
                        string TOM = "TOM=" + selectedCat10.TOM + "\n";
                        string DOU = "DOU=" + selectedCat10.DOU + "\n";
                        string MRS = "MRS=" + selectedCat10.MRS + "\n";
                        track = track + TOM + DOU + MRS;
                    }
                    if (selectedCat10.GHO != null)
                    {
                        //Second Extent
                        string GHO = "GHO=" + selectedCat10.GHO + "\n";
                        track = track + GHO;
                    }
                    FieldType.Text = title + track;

                    break;

                case 12:
                     //MODE-3/A CODE IN OCTAL REPRESANTATION
                    string VMode3A = "V=" + selectedCat10.VMode3A + "\n";
                    string GMode3A = "G=" + selectedCat10.GMode3A + "\n";
                    string LMode3A = "L=" + selectedCat10.LMode3A + "\n";
                    string Mode3A = "Mode 3A=" + selectedCat10.Mode3A + "\n";
                    FieldType.Text = title + VMode3A + GMode3A+LMode3A+Mode3A;
                    break;

                case 13:
                     //TARGET ADDRESS
                    string TargetAddress = "Target Address" + selectedCat10.TargetAddress + "\n";
                    FieldType.Text = title + TargetAddress;
                    break;

                case 14:
                    //TARGET IDENTIFICATION
                    string STI = "STI=" + selectedCat10.STI + "\n";
                    FieldType.Text = title + STI;
                    break;

                case 15:
                    //MODE S MB DATA
                    string MBData = "MBData=" + String.Join(" ", selectedCat10.MBData) + "\n";
                    string BDS1 = "BDS1=" + String.Join(" ", selectedCat10.BDS1) + "\n";
                    string BDS2 = "BDS2=" + String.Join(" ", selectedCat10.BDS2) + "\n";
                    FieldType.Text = title + MBData+BDS1+BDS2;
                    break;

                case 16:
                    //VEHICLE FLEET IDENTIFICATION
                    string VFI = "VFI=" + selectedCat10.VFI + "\n";
                    FieldType.Text = title + VFI;
                    break;

                case 17:
                    //FLIGHT LEVEL IN BINARY REPRESENTATION
                    string VFlightLevel = "V=" + selectedCat10.VFlightLevel + "\n";
                    string GFlightLevel = "G=" + selectedCat10.GFlightLevel + "\n";
                    string FlightLevelBinary = "Flight Level in Binary=" + selectedCat10.FlightLevelBinary + "\n";
                    string FlightLevel = "Flight Level=" + selectedCat10.FlightLevel + "\n";
                    FieldType.Text = title + VFlightLevel+GFlightLevel;
                    break;

                case 18:
                    //MEASURED HEIGHT
                    string MeasuredHeight = "Measured Height=" + selectedCat10.MeasuredHeight + "\n";
                    FieldType.Text = title + MeasuredHeight;
                    break;

                case 19:
                     //TARGET SIZE & ORIENTATION
                    string LENGHT = "Length=" + selectedCat10.LENGHT + "\n";
                    string ORIENTATION = "Orientation=" + selectedCat10.ORIENTATION + "\n";
                    string WIDTH = "Width=" + selectedCat10.WIDTH + "\n";
                    FieldType.Text = title + LENGHT + WIDTH + ORIENTATION;
                    break;

                case 20:
                    //SYSTEM STATUS
                    string NOGO = "NOGO=" + selectedCat10.NOGO + "\n";
                    string OVL = "OVL=" + selectedCat10.OVL + "\n";
                    string TSV = "TSV=" + selectedCat10.TSV + "\n";
                    string DIV = "DIV=" + selectedCat10.DIV + "\n";
                    string TIF = "TIF=" + selectedCat10.TIF + "\n";
                    FieldType.Text = title + NOGO + OVL+TSV+DIV+TIF;
                    break;
                case 21:
                     //PRE-PROGRAMMED MESSAGE
                    string TRB = "TRB=" + selectedCat10.TRB + "\n";
                    string MSG = "MSG=" + selectedCat10.MSG + "\n";
                    FieldType.Text = title + TRB + MSG;
                    break;
                case 22:
                    //STANDARD DEVIATION
                    string DeviationX = "X deviation=" + selectedCat10.DeviationX + "\n";
                    string DeviationY = "Y deviation=" + selectedCat10.DeviationY + "\n";
                    string CovarianceXY = "XY covariance=" + selectedCat10.CovarianceXY + "\n";
                    FieldType.Text = title + DeviationX + DeviationY+CovarianceXY;
                    break;
                case 23:
                    //PRESENCE
                    string REP = "REP=" + selectedCat10.REP + "\n";
                    string DRHO= "DRHO=" + String.Join(" ", selectedCat10.DRHO) + "\n"; 
                    string DTHETA ="DTHETA=" + String.Join(" ", selectedCat10.DTHETA) + "\n";
                    FieldType.Text = title + REP + DRHO + DTHETA;
                    break;
                case 24:
                    //AMPLITUDE OF PRIMARY PLOT
                    string PAM = "PAM=" + selectedCat10.PAM + "\n";
                    FieldType.Text = title + PAM;
                    break;
                case 25:
                    //CALCULATED ACCELERATION
                    string Ax = "Ax=" + selectedCat10.Ax + "\n";
                    string Ay = "Ay=" + selectedCat10.Ay + "\n";
                    FieldType.Text = title + Ax + Ay;
                    break;
       
   
   
             }
        }

    }
    
}
