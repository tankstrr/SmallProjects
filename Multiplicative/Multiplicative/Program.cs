using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Numerics;

namespace Multiplicative
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("tankstrr Multiplicative Checker v0.1");
            Console.WriteLine("======== ============== ======= ====");
            Console.WriteLine("");
            Console.WriteLine("1. Check a Number");
            Console.WriteLine("2. Run full test");
            Console.WriteLine("");
            Console.Write("Pick an option: ");
            string option = Console.ReadLine();
            if (option == "1") { Option1(); }
            if (option == "2") { Option2(); }
            Console.WriteLine("BYE");
            Console.WriteLine();
        }

        public static void Option1()
        {
            Console.WriteLine("");
            BigInteger numBigint = 0;
            int steps = 0;
            Console.Write("Enter the number to check: ");
            string numString = Console.ReadLine();
            if (numString != "") { numBigint = BigInteger.Parse(numString); }
            Console.WriteLine("Checking...");
            Console.WriteLine(numBigint);
            int digits = (int)Math.Floor(BigInteger.Log10(numBigint) + 1);
            while (digits > 1)
            {
                numBigint = CalcProduct(numBigint);
                Console.WriteLine(numBigint);
                digits = (int)Math.Floor(BigInteger.Log10(numBigint) + 1);
                steps++;
            }
            Console.WriteLine();
            Console.WriteLine("Number of steps: {0}", steps);
        }

        public static void Option2()
        {
            BigInteger maxNum = 1000000000;
            int maxSteps = 0;
            Console.Write("Enter the number to check (default 1 Billion) : ");
            string numString = Console.ReadLine();
            if (numString != "") { maxNum = BigInteger.Parse(numString); }
            Console.WriteLine("Checking up to {0:N0}", maxNum);
            
            //Start Stopwatch
            var stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start(); //added this nice stopwatch start routine 

            Console.WriteLine("0 steps: 0");
            TimeSpan ts = stopwatch.Elapsed;
            Console.WriteLine("  {0}", ts);
            for (BigInteger i = 1; i < maxNum + 1; i++)
            {
                BigInteger j = i;
                int digits = (int)Math.Floor(BigInteger.Log10(j) + 1);
                int steps = 0;
                while (digits > 1)
                {
                    j = CalcProduct(j);
                    digits = (int)Math.Floor(BigInteger.Log10(j) + 1);
                    steps++;
                }
                if (steps > maxSteps)
                {
                    ts = stopwatch.Elapsed;
                    Console.WriteLine("{0} steps: {1}", steps, i);
                    Console.WriteLine("  {0}",ts);
                    maxSteps++;
                }
                //Thread.Sleep(200);
            }
        }

        public static BigInteger CalcProduct(BigInteger num)
        {
            int length = num.ToString().Length;
            if (length == 1)
            {
                return num;
            }
            return (num % 10) * CalcProduct(num / 10);
        }
    }
}
