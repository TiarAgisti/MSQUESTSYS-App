using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace MQUESTSYS.Util
{
    public class IDNumericSayer
    {

        public string Capitalize(string input)
        {
            var result = "";

            if (!string.IsNullOrEmpty(input))
            {
                var inputChunk = input.Split(' ');

                foreach (var word in inputChunk)
                {
                    if (string.IsNullOrEmpty(word))
                        continue;

                    if (!string.IsNullOrEmpty(result))
                        result += " ";

                    result += word.First().ToString().ToUpper() + string.Join("", word.Skip(1));
                }
            }

            return result;
        }

        public string DateFormatingEng(DateTime date)
        {
            //date.ToString("ddMMyyyy");
            return SayMonth(date.Month) + " " + date.ToString("dd") + ", " + date.Year;
        }

        public string SayMonthRomawii(int MonthNum)
        {
            String MonthString = "";
            switch (MonthNum)
            {
                case 1:
                    MonthString = "I";
                    break;
                case 2:
                    MonthString = "II";
                    break;
                case 3:
                    MonthString = "III";
                    break;
                case 4:
                    MonthString = "IV";
                    break;
                case 5:
                    MonthString = "V";
                    break;
                case 6:
                    MonthString = "VI";
                    break;
                case 7:
                    MonthString = "VII";
                    break;
                case 8:
                    MonthString = "VIII";
                    break;
                case 9:
                    MonthString = "IX";
                    break;
                case 10:
                    MonthString = "X";
                    break;
                case 11:
                    MonthString = "XI";
                    break;
                case 12:
                    MonthString = "XII";
                    break;
                default:
                    MonthString = "";
                    break;
            }
            return MonthString;
        }

        public string SayMonth(int MonthNum)
        {
            String MonthString = "";
            switch (MonthNum)
            {
                case 1:
                    MonthString = "January";
                    break;
                case 2:
                    MonthString = "February";
                    break;
                case 3:
                    MonthString = "March";
                    break;
                case 4:
                    MonthString = "April";
                    break;
                case 5:
                    MonthString = "May";
                    break;
                case 6:
                    MonthString = "June";
                    break;
                case 7:
                    MonthString = "July";
                    break;
                case 8:
                    MonthString = "August";
                    break;
                case 9:
                    MonthString = "September";
                    break;
                case 10:
                    MonthString = "October";
                    break;
                case 11:
                    MonthString = "November";
                    break;
                case 12:
                    MonthString = "December";
                    break;
                default:
                    MonthString = "";
                    break;
            }
            return MonthString;
        }

        private string SayChunk(decimal number)
        {
            string str = number.ToString();

            List<string> list = new List<string>();

            int length = str.Length - 3;
            for (int x = length; x >= 0; x = x - 3)
            {
                if (x <= 0)
                    break;

                str = str.Insert(x, " ");
            }

            string[] chunks = str.Split(new char[] { ' ' });

            string say = "";
            int chunkPos = 0;
            for (int x = chunks.Length - 1; x >= 0; x--)
            {
                say = InterpretChunkSay(chunks[x], chunkPos++) + say;
            }

            return say;
        }

        public string Say(decimal number, string currencySay)
        {
            NumberFormatInfo numInfo = CultureInfo.CurrentCulture.NumberFormat;
            string decimalSeparator = numInfo.CurrencyDecimalSeparator;

            string strNumber = number.ToString("N2");

            string strFrontNumber = "";
            string decimalSay = "";

            if (strNumber.Contains(decimalSeparator))
            {
                int index = strNumber.IndexOf(decimalSeparator);
                string strDecimalChunk = strNumber.Substring(index + 1);

                if (Convert.ToInt32(strDecimalChunk) != 0)
                {
                    decimalSay = " koma " + SayChunk(Convert.ToDecimal(strDecimalChunk)) + " cents";
                }

                strFrontNumber = strNumber.Substring(0, index);
            }
            else
                strFrontNumber = number.ToString("N0");

            //if (!string.IsNullOrEmpty(currencySay))
            //    currencySay = currencySay;

            return SayChunk(Convert.ToDecimal(strFrontNumber)) + currencySay + decimalSay;

        }

        private string InterpretChunkSay(string chunk, int chunkPos)
        {
            if (chunk.Length == 1)
                chunk = "  " + chunk;
            else if (chunk.Length == 2)
                chunk = " " + chunk;


            string str = "";

            if (chunk[1] == '1')
            {
                if (chunk[2] == '0')
                    str = "ten ";
                else if (chunk[2] == '1')
                    str = "eleven ";
                else
                    str = InterpretSingleTone(chunk[2].ToString(), chunk, 2, chunkPos);

                chunk = chunk[0] + "00";
            }

            for (int x = 2; x >= 0; x--)
            {
                if (x >= chunk.Length)
                    continue;

                str = InterpretSingle(chunk.Substring(x, 1), chunk, x, chunkPos) + str;
            }

            if (str != "")
                str += InterpretChunkPosSay(chunkPos);

            return str;
        }

        private string InterpretChunkPosSay(int chunkPos)
        {
            string say = "";

            switch (chunkPos)
            {
                case 1:
                    say = "thousand ";
                    break;
                case 2:
                    say = "million ";
                    break;
            }

            return say;
        }

        private string InterpretSingle(string single, string chunk, int hundredPos, int chunkPos)
        {
            string str = "";
            switch (single)
            {
                case "1":
                    if (hundredPos == 2 && (chunkPos == 0 || chunkPos > 1 || (chunkPos == 1 && chunk[hundredPos - 1] != ' ')))
                        str = "one ";
                    else
                        str = "one ";
                    break;
                case "2":
                    str = "two ";
                    break;
                case "3":
                    str = "three ";
                    break;
                case "4":
                    str = "four ";
                    break;
                case "5":
                    str = "five ";
                    break;
                case "6":
                    str = "six ";
                    break;
                case "7":
                    str = "seven ";
                    break;
                case "8":
                    str = "eight ";
                    break;
                case "9":
                    str = "nine ";
                    break;
            }

            if (str != "")
            {
                if (hundredPos == 0)
                    str += "hundred ";
                else if (hundredPos == 1)
                    str = InterpretDoubleTone(single, chunk, hundredPos, chunkPos);
            }

            return str;
        }

        private string InterpretSingleTone(string single, string chunk, int hundredPos, int chunkPos)
        {
            string str = "";
            switch (single)
            {
                case "1":
                    str = "eleven ";
                    break;
                case "2":
                    str = "twelve ";
                    break;
                case "3":
                    str = "thirteen ";
                    break;
                case "4":
                    str = "fourteen ";
                    break;
                case "5":
                    str = "fifteen ";
                    break;
                case "6":
                    str = "sixteen ";
                    break;
                case "7":
                    str = "seventeen ";
                    break;
                case "8":
                    str = "eightteen ";
                    break;
                case "9":
                    str = "nineteen ";
                    break;
            }

            if (str != "")
            {
                if (hundredPos == 0)
                    str += "hundred ";
            }

            return str;
        }


        private string InterpretDoubleTone(string single, string chunk, int hundredPos, int chunkPos)
        {
            string str = "";
            switch (single)
            {
                case "1":
                    str = "eleven ";
                    break;
                case "2":
                    str = "twenty ";
                    break;
                case "3":
                    str = "thirty ";
                    break;
                case "4":
                    str = "fourty ";
                    break;
                case "5":
                    str = "fifty ";
                    break;
                case "6":
                    str = "sixty ";
                    break;
                case "7":
                    str = "seventy ";
                    break;
                case "8":
                    str = "eighty ";
                    break;
                case "9":
                    str = "ninety ";
                    break;
            }

            return str;
        }
    }
}
