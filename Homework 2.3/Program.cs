using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_2._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задание №2.");
            Console.WriteLine();
            double x;
            double z;
            double k;
            x = GetNum("x");
            z = GetNum("z");
            k = GetNum("k");
            GetAnswer(x, z, k);
            Console.ReadKey();
        }
        static double GetNum(string input)
        {
            Console.Write("Введите число {0} = ", input);
            string str = string.Empty;
            ConsoleKeyInfo inputKeyInfo = new ConsoleKeyInfo();
            while (inputKeyInfo.Key != ConsoleKey.Enter ||
                str == "-" || str.Length == 0)
            {
                inputKeyInfo = Console.ReadKey(true);
                char inputChar = inputKeyInfo.KeyChar;
                if (inputChar == '.' || inputChar == ',')
                {
                    inputChar = System.Globalization.CultureInfo.CurrentCulture.
                        NumberFormat.NumberDecimalSeparator[0];
                }
                if (IsCharForNum(str + inputChar))
                {
                    Console.Write(inputChar);
                    str += inputChar;
                }
                if (inputKeyInfo.Key == ConsoleKey.Backspace && str.Length > 0)
                {
                    Console.Write("\b \b");
                    str = str.Remove(str.Length - 1);
                }
            }
            Console.WriteLine();
            return double.Parse(str);
        }
        private static bool IsCharForNum(string st)
        {
            if (st.Contains('\0'))
            {
                return false;
            }
            if (double.TryParse(st, out double num))
            {
                return true;
            }
            if (st == "-")
            {
                return true;
            }
            return false;
        }
        static void GetAnswer(double x, double z, double k)
        {
            double y = (Math.Sqrt(2 * x + 3 * Math.Pow(x, 2) + 
                4 * Math.Pow(x, 3)) + (19 * z / 15 * k)) / 
                (Math.Sqrt(2 * z + Math.Pow(x, 4)) - 24 * z * (x + 7));
            Console.WriteLine($"y = {y}");
        }
    }
}
