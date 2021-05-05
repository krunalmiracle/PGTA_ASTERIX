using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DecerixUPC.Libraries
{
    class HelpDecode
    {
        public string getFSPEC(string[] message)
        {
            string FSPEC = "";
            //Offset of 3 octets because of CAT (1 Octet) & LEN (2 Octets)
            int index = 3;
            bool  read = true;
            while (read == true)
            {
                //Convert octet and addd padding if necessary
                string newoctet = Convert.ToString(Convert.ToInt32(message[index], 16), 2).PadLeft(8, '0');
                //Pick the 7 significant FSPEC bits -- Leaving last bit
                FSPEC += newoctet.Substring(0, 7);
                //Check the extension bit -- Last Bit in the octet
                if (newoctet.Substring(7, 1) == "1")
                    index++;
                else
                //Stop reading when extension bit is 0
                    read = false;
            }
            return FSPEC;
        }

        public string[] MessageToBinary(string[] message)
        {
            string[] binaryMessage = new string[message.Length];
            for (int c = 0; c < message.Length; c++){
                binaryMessage[c] = this.OctetHexToBinary(message[c]);
            }
            return binaryMessage;
        }

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

        readonly private Dictionary<string, char> BinaryToHex = new Dictionary<string, char>
        {
            {"0000", '0' },
            {"0001", '1'},
            {"0010",'2' },
            {"0011",'3' },
            {"0100",'4' },
            {"0101",'5' },
            {"0110",'6' },
            {"0111",'7' },
            {"1000",'8' },
            {"1001",'9' },
            {"1010",'A' },
            {"1011",'B' },
            {"1100",'C' },
            {"1101",'D' },
            {"1110",'E' },
            {"1111",'F' }
        };

        public string OctetHexToBinary(string octetHexa)
        {
         
            if (octetHexa.Length == 1)
            {
                octetHexa = string.Concat('0', octetHexa);
            }
            StringBuilder Octet = new StringBuilder();
            foreach (char a in octetHexa)
            {
                Octet.Append(HexToBinary[char.ToUpper(Convert.ToChar(a))]);
            }
            return Octet.ToString();
        }

        public double TwoComplement2Decimal(string bits)
        {
            if (Convert.ToString(bits[0]) == "0")
            {
                int result = Convert.ToInt32(bits, 2);
                return Convert.ToSingle(result);
            }
            else
            {
                string bitsNegative = bits.Substring(1, bits.Length - 1);
                string newbits = "";
                int i = 0;
                while (i < bitsNegative.Length)
                {
                    if (Convert.ToString(bitsNegative[i]) == "1")
                        newbits += "0";
                    if (Convert.ToString(bitsNegative[i]) == "0")
                        newbits += "1";
                    i++;
                }
                double result = Convert.ToInt32(newbits, 2) + 1;
                return -result;
            }

        }
        /// Compute Char from bynary
        /// </summary>
        /// <param name="Char"></param>
        /// <returns>Computed Char</returns>
        public string Compute_Char(string Char)
        {
            int code = Convert.ToInt32(Char, 2);
            List<string> codelist = new List<string>() { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            if (code == 0)
                return "";
            else
                return codelist[code - 1];
        }
        public int Decimal2Octal(int number)
        {
            int octal = 0, i = 1;
            while (number != 0)
            {
                octal += (number % 8) * i;
                number /= 8;
                i *= 10;
            }
            return octal;
        }

        public string Binary2Hex(string octeto)
        {
            StringBuilder Octet = new StringBuilder();
            Octet.Append(BinaryToHex[octeto.Substring(0, 4)]);
            Octet.Append(BinaryToHex[octeto.Substring(4, 4)]);
            return Octet.ToString();
        }
        public string Code2Char(string Char)
        {
            int code = Convert.ToInt32(Char, 2);
            List<string> codelist = new List<string>() { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            if (code == 0)
                return "";
            else
                return codelist[code - 1];
        }
    }
}
