using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler2
{
    class Program
    {
        static double GOLDEN_RATIO = ((1.0 + Math.Sqrt(5.0)) / 2.0);


        public static void Main(string[] args)
        {
            List<double> seq = fibGenerator(100);
            seq.ForEach(x => Console.Write(x + ", "));

            Console.ReadKey();
                
        }

        public static List<double> fibGenerator(int i)
        {
            double n = 0.0;
            List<double> seq = new List<double>();
            
            for (int j = 0; j <= i; j++)
            {
                //Console.Write(n + " ");
                n = (Math.Pow(GOLDEN_RATIO, 3 * i) - Math.Pow((-1 * GOLDEN_RATIO), -3 * i)) / Math.Sqrt(5.0);
                seq.Add(n);
            }

            return seq;
        }
    }
}