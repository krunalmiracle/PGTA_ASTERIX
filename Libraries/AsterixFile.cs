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
        List<CAT21v21> listCAT21 = new List<CAT21v21>();
        

        List<CAT21> listCAT21 = new List<CAT21>();
        List<int> datablocks = new List<int>();
        

        public List<CAT10> getListCAT10()
        {
            return listCAT10;
        }
        public List<CAT21v21> getListCAT21()
        {
            return listCAT21;
        }

        public List<string[]> getHex()
        {
            return listhex;
        }

        public List<int> getDataBlocks()
        {
            return datablocks;
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
            int offset = 3;
            for (int q = 0; q < listhex.Count; q++)
            {
                string[] arraystring = listhex[q];
                int CAT = int.Parse(arraystring[0], System.Globalization.NumberStyles.HexNumber);

                if (CAT == 10)
                {
                    CAT10 newcat10 = new CAT10(arraystring,new HelpDecode(),q, offset);
                    listCAT10.Add(newcat10);
                    datablocks.Add(10);
                }
                else if (CAT == 21)
                {
                    CAT21v21 newcat21 = new CAT21v21(arraystring, new HelpDecode());
                    listCAT21.Add(newcat21);
                    datablocks.Add(21);
                }
                offset += arraystring.Length;
            }

        } 
    }
}
