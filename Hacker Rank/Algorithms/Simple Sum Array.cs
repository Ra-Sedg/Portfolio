using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static void Main(String[] args) {
       
        Console.ReadLine();
        
        int[] numbers = Console.ReadLine()
            .Split(' ')
            .Select(x => Convert.ToInt32(x))
            .ToArray();
        
        Console.WriteLine(numbers.Sum());
        
    }  
}