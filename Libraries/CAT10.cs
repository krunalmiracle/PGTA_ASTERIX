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
        public string FSPEC1;
        public string CAT = "10";
        public string LEN;
        public int Id;
        public int CAT10Id;
        public int airportId;

        public Dictionary<char, string> HexToBinary = new Dictionary<char, string>
        {
            { '0', "0000" },
            { '1', "0001" },
            { '2', "0010" },
            { '3', "0011" },
            { '4', "0100" },
            { '5', "0101" },
            { '6', "0110" },
            { '7', "0111" },
            { '8', "1000" },
            { '9', "1001" },
            { 'A', "1010" },
            { 'B', "1011" },
            { 'C', "1100" },
            { 'D', "1101" },
            { 'E', "1110" },
            { 'F', "1111" }
        };
       
    }
}
