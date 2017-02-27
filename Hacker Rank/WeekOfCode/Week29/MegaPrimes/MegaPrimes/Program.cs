using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaPrimes
{
    class Program
    {
        static HashSet<ulong> primes = new HashSet<ulong>();


        static void Main(string[] args)
        {
            int megaPrimes = 0;
            for (ulong i = 0; i <= 100; i++)
            {
                string digits = i.ToString();
                bool isMegaPrime = true; 

           

                for (int j = 0; j < digits.Length; j++)
                {
                    ulong n = ulong.Parse(digits.Substring(j, 1));
                    if (!IsPrime(n))
                    {
                        isMegaPrime = false;
                    }

                    ulong candidate = ulong.Parse(digits.Substring(0, j+1));
                    if (!IsPrime(candidate)) {
                        isMegaPrime = false;
                    }
                }
                if (isMegaPrime)
                {
                    //Console.WriteLine("MegaPrine: " + i);
                    megaPrimes++;
                }
            }
            Console.WriteLine(megaPrimes);
            Console.ReadKey();

        }

        

        public static bool IsPrime(ulong candidate)
        {

            if (primes.Contains(candidate))
            {
                return true;
            }

            // Test whether the parameter is a prime number.
            if ((candidate & 1) == 0)
            {
                if (candidate == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            // Note:
            // ... This version was changed to test the square.
            // ... Original version tested against the square root.
            // ... Also we exclude 1 at the end.
            for (ulong i = 3; (i * i) <= candidate; i += 2)
            {
                if ((candidate % i) == 0)
                {
                    return false;
                }
            }

            if (candidate != 1)
            {
                primes.Add(candidate);
            }

            return candidate != 1;
        }
    }
}
