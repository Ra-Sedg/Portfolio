using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static void Main(String[] args) {
       
        Int64 sum = 0;
        
        Console.ReadLine();
        Int64[] numbers = Console.ReadLine()
            .Split(' ')
            .Select(x => sum += Convert.ToInt64(x))
            .ToArray();
        
        
        Console.WriteLine(sum);
    }
}