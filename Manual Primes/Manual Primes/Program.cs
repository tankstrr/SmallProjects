using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manual_Primes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("tankstrr Primes v1.01");
            Console.WriteLine("-------- ------ -----");
            // bool isPrime = true;
            Console.Write("Please Enter # of primes to find (blank = 10K): ");
            string maxNumTxt = Console.ReadLine();
            int primesToFind = 0;
            if (maxNumTxt == "")
            {
                primesToFind = 10000;
            }
            else
            {
                primesToFind = Convert.ToInt32(maxNumTxt);
            }

            //double halfNumber = Math.Truncate(number * 0.5);
            //Console.WriteLine("Half of {0} is {1}", primes, primes/2);

            //Start Stopwatch
            var stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start(); //added this nice stopwatch start routine 

            int foundPrimes = 0;
            int displayedPrimes = 10;
            Console.WriteLine("Showing every {0}th prime", displayedPrimes);
            int number = 2;
            while (foundPrimes < primesToFind)
            {
                int halfNumber = (number / 2);
                int notPrime = 0;
                if (number == 2)
                {
                    Console.SetCursorPosition(0, 4);
                    Console.WriteLine("{0,10}, {1} ", foundPrimes + 1, number);
                    foundPrimes++;
                }
                for (int i = 2; i <= halfNumber + 1; i++)
                {
                    int remainder = number % i;
                    if (remainder == 0)
                    {
                        notPrime = 1;
                        break;
                    }
                }
                if (notPrime == 0)
                {
                    if ((foundPrimes + 1) % displayedPrimes == 0)
                    {
                        Console.SetCursorPosition(0, 4);
                        Console.WriteLine("{0,10}, {1} ", foundPrimes + 1, number);
                    }
                    foundPrimes++;
                }
                number++;
            }
            Console.WriteLine("");
            Console.WriteLine("Last Prime");
            Console.WriteLine("{0,10}, {1} ", foundPrimes, number - 1);
            Console.WriteLine("");

            //Stop Startwatch
            stopwatch.Stop();
            TimeSpan ts = stopwatch.Elapsed;
            Console.WriteLine("Calc Time {0}", ts);
            Console.ReadKey();

        }
    }
}
