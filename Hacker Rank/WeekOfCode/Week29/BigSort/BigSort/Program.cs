using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigSort
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> numbers = new List<string>();
            numbers.Add("10");
            numbers.Add("1");
            numbers.Add("31415926535897932384626433832795");
            numbers.Add("3");
            numbers.Add("3");

            NumericStringComparer nsc = new NumericStringComparer();
            numbers.Sort(nsc);

            
            numbers.ForEach(n => Console.WriteLine(n));
            
            Console.ReadKey();
        }
    }

    public class NumericStringComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            if (x.Length > y.Length)
            {
                return 1;
            }
            else if (x.Length < y.Length)
            {
                return -1;
            }
            else
            {
                for (int i = 0; i < x.Length; i++)
                {
                    if (x[i] > y[i])
                    {
                        return 1;
                    }
                    else if (x[i] < y[i])
                    {
                        return -1;
                    }
                }
                return 0;
            }
        }
    }
    

    

 
}
