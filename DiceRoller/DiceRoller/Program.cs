using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRoller
{
    class Program
    {
        static void Main(string[] args)
        {
            int diceSide = 6;
            int numDice = 2;
            int numRolls = 100000000;
            int rollDisplay = 1000000;
            //int numRolls = 100000;

            Console.WriteLine("tankstrr DiceRoller v0.1");
            Console.WriteLine("======== ========== ====");
            Console.WriteLine("");
            Console.Write("Enter the number of rolls to process (blank for 100M): ");
            string numRollsstring = Console.ReadLine();
            if (numRollsstring != "") { numRolls = Convert.ToInt32(numRollsstring); }
            Console.WriteLine("Roll {0}d{1} dice {2:N0} times.", numDice, diceSide, numRolls);

            //Start Stopwatch
            var stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start(); //added this nice stopwatch start routine 

            int arraySize = (numDice * diceSide) - (numDice - 1);
            //Console.WriteLine("Array Size = {0}", arraySize);

            int[] rollTotals = new int[11];
            Random randomObject = new Random();
            int rollCount = 0;
            for (int i = 1; i < numRolls + 1; i++)
            {
                int dieRoll = randomObject.Next(6) + 1;
                int dieRoll2 = randomObject.Next(6) + 1;
                int totalRoll = dieRoll + dieRoll2;
                if (rollCount == rollDisplay - 1)
                {
                    Console.SetCursorPosition(0, 5);
                    Console.WriteLine("Roll# {0:N0}", i);
                    rollCount = 0;
                }
                else
                {
                    rollCount++;
                }

                rollTotals[totalRoll - 2]++;

            }
            Console.SetCursorPosition(0, 5);
            Console.WriteLine("Roll# {0:N0}", numRolls);
            Console.WriteLine("");
            int count = numDice;
            foreach (int t in rollTotals)
            {
                Console.Write("{0:D2}", count);
                decimal averageRolls = Decimal.Divide(t, numRolls) * 100;
                int graphLength = Convert.ToInt32(averageRolls);

                string graph = new String('*', graphLength);
                Console.WriteLine(" - {0,12:N0} {1,7}% {2}", t, averageRolls.ToString("n2"), graph);
                count++;
            }
            Console.WriteLine("");

            //Stop Startwatch
            stopwatch.Stop();
            TimeSpan ts = stopwatch.Elapsed;
            Console.WriteLine("Calc Time {0}", ts);
            Console.WriteLine("..press any key to exit");
            Console.ReadKey();

        }
    }
}
