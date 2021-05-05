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
        List<CAT21> cat21;
        List<CAT10> cat10;
        CAT10 selectedCat10;
        CAT21 selectedCat21;
        public DataTable tableCAT10 = new DataTable();
        public DecodeFile()
        {
            InitializeComponent();


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void loadFile_Click(object sender, EventArgs e)
        {
            // Open File Dialog -->
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "C:\\Users\\kruskechi\\Documents\\GitHub\\PGTA_ASTERIX\\FilesDemo";
            openFileDialog.Filter = "ast files (*.ast)|*.ast*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                // If Choose --> Read the File
                String filePath = openFileDialog.FileName;
                AsterixFile file = new AsterixFile();
                file.read(filePath);
                //AsterixFileHex.Text = file.getHex();
                // File Read --> Decode it to Categories and create a list of 

                //  Cat 10 for SMR y MLAT & Cat 21 para ADS-B
                tableCAT10 = file.tablaCAT10;
                cat10 = file.getListCAT10();
                cat21 = file.getListCAT21();
                // After the list creation --> Indicate the UI to choose to show different Categories
                cat10Table.DataSource = tableCAT10;
            }
            else if (result == DialogResult.Cancel)
            {
                // Else not choosen file --> Indicate nothing choosen and no errors
            }

           
        }

        private void about_Click(object sender, EventArgs e)
        {

        }

        private void dataView_Click(object sender, EventArgs e)
        {

        }

        private void mapView_Click(object sender, EventArgs e)
        {

        }

        private void cat10DataView_Click(object sender, EventArgs e)
        {
            if (tableCAT10!=null)
            {
                cat10Table.DataSource = tableCAT10;
            }
        }
    }
    
}
