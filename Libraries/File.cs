using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;


namespace LibreriaClases
{
    public class File
    {
        string path;
        List<CAT10> listCAT10 = new List<CAT10>();
        List<CAT21> listCAT21 = new List<CAT21>();
        DataTable tableCAT10 = new DataTable();
        DataTable tableCAT21 = new DataTable();


        public Fichero(string name)
        {
            this.path = name;
        }

        public List<CAT10> getListCAT10()
        {
            return listCAT10;
        }
        public List<CAT21> getListCAT21()
        {
            return listCAT21;
        }

        public void read()
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

            List<string[]> listhex = new List<string[]>();
            for (int x = 0; x < listbyte.Count; x++)
            {
                byte[] buffer = listbyte[x];
                string[] arrayhex = new string[buffer.Length];
                for (int y = 0; y < buffer.Length; y++)
                {
                    arrayhex[y] = buffer[y].ToString("X");
                }
                listahex.Add(arrayhex);
            }


            for (int q = 0; q < listhex.Count; q++)
            {
                string[] arraystring = listahex[q];
                int CAT = int.Parse(arraystring[0], System.Globalization.NumberStyles.HexNumber);

                if (CAT == 10)
                {
                    CAT10 newcat10 = new CAT10(arraystring);
                    listCAT10.Add(newcat10);
                }
                else if (CAT == 21)
                {
                    CAT21 newcat21 = new CAT21(arraystring);
                    listCAT21.Add(newcat21);
                }
            }
            

        }

        public DataTable getTableCAT10()
        {
            return tableCAT10;
        }
        public DataTable getTableCAT21()
        {
            return tableCAT21;
        }
    }
}
