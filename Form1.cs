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
    public partial class Form1 : Form
    {   
        public Form1()
        {
            InitializeComponent();
            
            /*DataBlock.Columns[0].Name = "Block Offset";
            DataBlock.Columns[1].Name = "Length";
            DataBlock.Columns[2].Name = "Category";

            DataRecord.Columns[0].Name = "Block Offset";
            DataRecord.Columns[1].Name = "Time";
            DataRecord.Columns[2].Name = "Length";
            DataRecord.Columns[1].Name = "#Items";

            DataItems.Columns[0].Name = "Item Offset";
            DataItems.Columns[1].Name = "Length";
            DataItems.Columns[2].Name = "FRN";
            DataItems.Columns[3].Name = "Field Type";
            DataItems.Columns[4].Name = "Description";*/
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
            AsterixFileHex.Text = file.getHex();

           
        }

    }

    
}
