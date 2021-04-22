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
        

        public List<CAT10> getListCAT10()
        {
            return listCAT10;
        }
        public List<CAT21> getListCAT21()
        {
            return listCAT21;
        }

        public string getHex()
        {
            string hex = " " ;
            foreach(string[] hexa in listhex){

                hex = hex + String.Join("",hexa);
            }
            return hex;
        }

        public void read(string path)
        {
            byte[] fileBytes = File.ReadAllBytes(path);
            List<byte[]> listbyte = new List<byte[]>();
            int i = 0;
            int count = fileBytes[2];

            while (i < fileBytes.Length)
            {
                byte[] array = new byte[count];
                for (int j = 0; j < array.Length; j++)
                {
                    array[j] = fileBytes[i];
                    i++;
                }
                listbyte.Add(array);
                if (i + 2 < fileBytes.Length)
                {
                    count = fileBytes[i + 2];
                }
            }

            
            for (int x = 0; x < listbyte.Count; x++)
            {
                byte[] buffer = listbyte[x];
                string[] arrayhex = new string[buffer.Length];
                for (int y = 0; y < buffer.Length; y++)
                {
                    // Byte Buffer to String Hexadecimal
                    arrayhex[y] = buffer[y].ToString("X");
                   // file = file + arrayhex[y].PadLeft(2, '0');
                }
                // Save the packet in hex format
                listhex.Add(arrayhex);
            }
            
            // Loop through hex packet list
            for (int q = 0; q < listhex.Count; q++)
            {
                string[] arraystring = listhex[q];
                int CAT = int.Parse(arraystring[0], System.Globalization.NumberStyles.HexNumber);

                if (CAT == 10)
                {
                    CAT10 newcat10 = new CAT10(arraystring,new HelpDecode());
                    listCAT10.Add(newcat10);
                }
                else if (CAT == 21)
                {
                    CAT21 newcat21 = new CAT21(arraystring);
                    listCAT21.Add(newcat21);
                }
            }

        } 
    }
}
