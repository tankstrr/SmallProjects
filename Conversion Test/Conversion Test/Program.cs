using System;

namespace Conversion_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Conversion Test 1.0 by tankstrr");
            while (true)
            {
                string baseUnit = "m";
                Console.Write("Enter a Number: ");
                decimal baseNum = Convert.ToDecimal(Console.ReadLine());
                decimal newNum = baseNum;
                string newUnit = baseUnit;
                if (baseNum >= 10000)
                {
                    newNum = baseNum / 1000;
                    newUnit = "km";
                }
                if (baseNum >= 10000000)
                {
                    newNum = baseNum / 1000000;
                    newUnit = "Mm";
                }
                if (baseNum >= 10000000000)
                {
                    newNum = baseNum / 1000000000;
                    newUnit = "Gm";
                }
                Console.WriteLine("Converted number is {0:N2} {1}", newNum, newUnit);
            }

        }
    }
}
