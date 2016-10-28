using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertToBaseN
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = 0;
            int baseNum = 0;
            var remainderStack = new Stack<int>();
            string hexideximalResult = String.Empty;

            if (args.Length < 2)
            {
                Console.WriteLine("Please include arguments for the number to be converted and the base for the conversion");
                return;
            }

            if (!int.TryParse(args[0], out number))
            {
                Console.WriteLine("The first argument must be of type Integer");
                return;
            }

            if (!int.TryParse(args[1], out baseNum) || baseNum > 16)
            {
                Console.WriteLine("The second argument must be of type Integer");
                return;
            }

            while (number != 0)
            {
                // Get the remainder (if performing a direct decimal division, get the decimal part and multiply it by the base number to get the remainder)
                var remainder = number % baseNum;
                // Push remainder on top of the stack. These numbers will be read to the result in reverse order.
                remainderStack.Push(remainder);
                // Update original number with whole part of the product
                number = (int)(number / baseNum);
            }

            // Read each remainder stored as a digit of the result in reverse order
            while (remainderStack.Count > 0)
            {
                try
                {
                    hexideximalResult += GetHexidecimalCharacter(remainderStack.Pop());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(hexideximalResult);
        }

        /// <summary>
        /// Translates a value into a digit of maximum base 16
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        static string GetHexidecimalCharacter(int number)
        {
            if (number > 15)
                throw new Exception("The number argument exceeds the maximum value for a base 16 conversion");

            switch (number)
            {
                case 10:
                    return "A";
                case 11:
                    return "B";
                case 12:
                    return "C";
                case 13:
                    return "D";
                case 14:
                    return "E";
                case 15:
                    return "F";
                default:
                    return number.ToString();
            }
        }
    }
}
