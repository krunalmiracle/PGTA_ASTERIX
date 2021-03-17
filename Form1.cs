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
        }
    }

    
}
