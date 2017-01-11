using System;
using System.Collections.Generic;
using System.IO;
class Solution 
{
    static void Main(string[] args)
    {

        int stringCount = Int32.Parse(Console.ReadLine());
        Dictionary<string, int> stringHash = new Dictionary<string, int>();

        for (int i = 0; i < stringCount; i++)
        {
            String s = Console.ReadLine();
            if (stringHash.ContainsKey(s))
            {
                stringHash[s] += 1;
            }
            else
            {
                stringHash.Add(s, 1);
            }
        }

        int queryCount = Int32.Parse(Console.ReadLine());

        for (int i = 0; i < queryCount; i++)
        {
            string query = Console.ReadLine();
            if (stringHash.ContainsKey(query))
            {
                Console.WriteLine(stringHash[query]);
            }
            else
            {
                Console.WriteLine(0);
            }
        }

    }
}