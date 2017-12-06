using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metric_Prefixes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Metric Prefixes");

            double testNum = 1540000;
            Console.WriteLine(ToSI(testNum)+"m");
            Console.ReadKey();
        }

        static string ToSI(double d, string format = null)
        {
            char[] incPrefixes = new[] { 'k', 'M', 'G', 'T', 'P', 'E', 'Z', 'Y' };
            char[] decPrefixes = new[] { 'm', '\u03bc', 'n', 'p', 'f', 'a', 'z', 'y' };

            int degree = (int)Math.Floor(Math.Log10(Math.Abs(d)) / 4);
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
