using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSprint2._2
{
    class Program
    {
        static void Main(string[] args)
        {

            int q = 1;
            bool isBeautiful = true;
            for (int i = 0; i < q; i++)
            {


                string input = Console.ReadLine();
                
                // 8 9 1
                // 9 10 11
                // 123 125

                for (int subLength = 1; subLength <= input.Length/2; subLength++) {


                    for (int j = 0; j < input.Length; j += subLength)
                    {
                        int current = int.Parse(input.Substring(j, subLength));
                        int next = int.Parse(input.Substring(j + 1, subLength));

                        if (current +1 != next)
                        {
                            if (j + 1 < input.Length)
                            {
                                next = int.Parse(input.Substring(j + 1, subLength + 1));
                                if (current + 1 != next)
                                {
                                    isBeautiful = false;
                                    break;
                                }
                                else
                                {
                                    j -= subLength;
                                    subLength++;
                                }
                            }
                            else
                            {
                                isBeautiful = false;
                                break;
                            }
                        }
                    }

                    if (isBeautiful)
                    {
                        Console.WriteLine("Yes");
                    }
                    else
                    {
                        Console.WriteLine("No");
                    }
                    
                }

            }

            Console.ReadKey();
        }



        static List<List<int>> GetCombinations(string s)
        {
            List<List<int>> combos = new List<List<int>>();
            for (int j = 1; j <= s.Length / 2; j++)
            {
                combos.Add(SplitInParts(s, j));
            }
            return combos;
        }

        static List<int> SplitInParts(string str, int chunkSize)
        {
            List<string> tokens = Enumerable.Range(0, str.Length / chunkSize)
                .Select(i => str.Substring(i * chunkSize, chunkSize)).ToList();

            return tokens.Select(int.Parse).ToList();
        }
    
    }
}