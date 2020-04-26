using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Multiplicative_Persistence
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("tankstrr Multiplicative Persistence v1.0");
            Console.WriteLine("======== ============== =========== ====");
            Console.WriteLine("");
            Console.Write("Enter # to check: ");
            string origNum = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("Checking {0}...", origNum);
            Console.WriteLine("======================");

            double origNumber = Convert.ToDouble(origNum);
            double numLength = Math.Floor(Math.Log10(origNumber) + 1);
            Console.WriteLine("00: {0}", origNumber);

            // string stringNum = Convert.ToString(origNumber);
            // Array.ForEach(arrDigits, Console.WriteLine);

            int steps = 0;
            while (numLength > 1)
            {
                double[] arrDigits = Array.ConvertAll<string, double>(
                System.Text.RegularExpressions.Regex.Split(origNumber.ToString(), @"(?!^)(?!$)"),
                str => double.Parse(str)); double newNumber = 1;

                foreach (int i in arrDigits)
                {
                    newNumber = newNumber * i;
                }
                origNumber = newNumber;
                numLength = Math.Floor(Math.Log10(origNumber) + 1);
                steps++;
                Console.WriteLine("{0:D2}: {1}", steps, newNumber);
            }
            Console.WriteLine("======================");
            Console.WriteLine("Total Steps = {0}", steps);
        }

    }
}
