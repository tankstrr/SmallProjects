using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// With only 32 digits of π (3.14159265358979323846264338327950), and a really good 
/// measurement of the diameter of the Milky Way galaxy, you could wrap a rope around 
/// the galaxy’s circumference that’s accurate to one atom in length. 
/// 
/// Taking pi to 39 digits allows you to measure the circumference of the observable 
/// universe to within the width of a single hydrogen atom.
/// </summary>

namespace Pi
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("  pi(15) = 3.141592653589793 (NASA GNC)");
            Console.WriteLine("  pi(16) = 3.1415926535897932 (NASA GPS)");
            Console.WriteLine("  pi(32) = 3.14159265358979323846264338327950 (Universe Constants)");
            Console.WriteLine("  pi(55) = 3.1415926535897932384626433832795028841971693993751058209");
            Console.WriteLine("pi(calc) = ");
            Console.WriteLine("pi(prec) = ");
            Console.WriteLine("");
            int stepCount = 0;
            Console.Write("Number of Steps (blank for 10M): ");
            string stepCountTxt = Console.ReadLine();
            if (stepCountTxt == "")
            {
                stepCount = 10000000;
            }
            else
            {
                stepCount = Convert.ToInt32(stepCountTxt);
            }

            /*          decimal pie = 1; 
                        decimal e = -1;
            */
            var stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start(); //added this nice stopwatch start routine 

            //leibniz formula in C# - code written completely by Todd Mandell 2014
            /*
                        for (decimal f = (e += 2); f < 1000001; f++)
                        {
                             e += 2;
                             pie -= 1 / e;
                             e += 2;
                             pie += 1 / e;
                             Console.WriteLine(pie * 4);
                        }

                             decimal finalDisplayString = (pie * 4);
                             Console.WriteLine("pie = {0}", finalDisplayString);
                             Console.WriteLine("Accuracy resulting from approximately {0} steps", e/4); 
            */

            // Nilakantha formula - code written completely by Todd Mandell 2014
            // π = 3 + 4/(2*3*4) - 4/(4*5*6) + 4/(6*7*8) - 4/(8*9*10) + 4/(10*11*12) - (4/(12*13*14) etc

            decimal pie = 0;
            decimal a = 2;
            decimal b = 3;
            decimal c = 4;
            decimal e = 1;
            decimal pix = 3.1415926535897932384626433832795028841971693993751058209m;
            int stepDisplay = 100000;
            decimal precpi = 0;

            for (decimal f = (e += 1); f < stepCount; f++)
            // Increase f where "f < 1000000" to increase number of steps
            {

                pie += 4 / (a * b * c);

                a += 2;
                b += 2;
                c += 2;

                pie -= 4 / (a * b * c);

                a += 2;
                b += 2;
                c += 2;

                e += 1;
                if (e % stepDisplay == 0)
                {
                    precpi = Math.Abs((pie + 3) - pix);
                    Console.SetCursorPosition(11, 4);
                    Console.WriteLine("{0}", pie + 3);
                    Console.SetCursorPosition(11, 5);
                    Console.WriteLine("{0}", prec(precpi));
                    Console.SetCursorPosition(0, 9);
                    decimal percentComplete = e / stepCount * 100;
                    Console.WriteLine("%{0:N1} - {1:N0} steps", percentComplete, e);
                }
                //Console.WriteLine("pi(calc) = {0}", pie + 3);
            }

            Console.SetCursorPosition(0, 10);
            //decimal finalDisplayString = (pie + 3);
            //Console.WriteLine("pi(calc) = {0}", finalDisplayString);
            //precpi = Math.Abs(finalDisplayString - pix);
            //Console.WriteLine("pi(prec) = {0}", prec(precpi));
            Console.WriteLine("Accuracy resulting from {0:N0} steps", e);

            stopwatch.Stop();
            TimeSpan ts = stopwatch.Elapsed;
            Console.WriteLine("Calc Time {0}", ts);

            Console.ReadKey();

        }

        static decimal prec(decimal j)
        {
            int i = 0;
            while (true)
            {
                j = j * 10;
                if (j > 1)
                {
                    break;
                }
                else
                {
                    i++;
                }

            }
            return i;

        }

    }
}