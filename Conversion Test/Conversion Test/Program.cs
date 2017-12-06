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
            decimal baseNum = Convert.ToDecimal(Console.ReadLine());
            decimal origNum = baseNum;
            decimal newNum = baseNum;
            string newUnit = baseUnit;
            while (true)
            {
                baseNum = baseNum + origNum;
                newNum = baseNum;
                newUnit = "";
                if (baseNum >= 10000)
                {
                    newNum = baseNum / 1000;
                    newUnit = "k";
                }
                if (baseNum >= 10000000)
                {
                    newNum = baseNum / 1000000;
                    newUnit = "M";
                }
                if (baseNum >= 10000000000)
                {
                    newNum = baseNum / 1000000000;
                    newUnit = "G";
                }
                Console.SetCursorPosition(0, 3);
                Console.WriteLine("Converted number is {0,12:N2} {1}m", newNum, newUnit);

                //System.Threading.Thread.Sleep(10);
            }

        }
    }
}
