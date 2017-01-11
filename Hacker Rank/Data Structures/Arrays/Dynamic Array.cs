using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution {
    
    static void Main(string[] args)
        {
        
            String[] initialValues = Console.ReadLine().Split(' ');
            int N = Int32.Parse(initialValues[0]);
            int Q = Int32.Parse(initialValues[1]);

            int lastAns = 0;
            List<List<int>> seqList = new List<List<int>>();
            
            for (int i = 0; i < N; i++)
            {
                seqList.Add(new List<int>());
            }

            for (int i = 0; i < Q; i++)
            {
                List<int> query = new List<int>();
                String[] temp = Console.ReadLine().Split(' ');
                
                foreach (String element in temp)
                {
                    query.Add(Int32.Parse(element));
                }

                int x = query[1];
                int y = query[2];
                int index = queryFunction(N, x, lastAns);


                if (query[0] == 1)
                {
                    seqList.ElementAt(index).Add(y);
                }
                else
                {
                    y = y % seqList.ElementAt(index).Count();
                    lastAns = seqList.ElementAt(index).ElementAt(y);
                    
                    Console.WriteLine(lastAns);
                }
            }
        }

        public static int queryFunction(int N, int x, int lastAns)
        {
            return ((x ^ lastAns) % N); 
        }
}