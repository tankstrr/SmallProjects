using System;

namespace Conversion_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Conversion Test 1.0 by tankstrr");
            string baseUnit = "";
            Console.Write("Enter a Number: ");
            double baseNum = Convert.ToDouble(Console.ReadLine());
            double origNum = baseNum;
            while (true)
            {
                Console.SetCursorPosition(0, 3);
                Console.WriteLine("Converted number is {0,12}m", ToSI(baseNum, "##,##0.00"));
                baseNum = baseNum + origNum;

                //System.Threading.Thread.Sleep(100);
            }

        }

        static string ToSI(double d, string format = null)
        {
            char[] incPrefixes = new[] { 'k', 'M', 'G', 'T', 'P', 'E', 'Z', 'Y' };
            char[] decPrefixes = new[] { 'm', '\u03bc', 'n', 'p', 'f', 'a', 'z', 'y' };

            int degree = (int)Math.Floor(Math.Log10(Math.Abs(d)) / 3);
            double scaled = d * Math.Pow(1000, -degree);

            char? prefix = null;
            switch (Math.Sign(degree))
            {
                case 1: prefix = incPrefixes[degree - 1]; break;
                case -1: prefix = decPrefixes[-degree - 1]; break;
            }

            return scaled.ToString(format) + " " + prefix;
        }

    }
}