using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static void Main(String[] args) {
        int t = Convert.ToInt32(Console.ReadLine());
        for(int a0 = 0; a0 < t; a0++){
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(getSum(3, n-1) + getSum(5, n-1) - getSum(15, n-1));
        }
    }
    
    static long getSum(int div, int n) 
    {
       // Sum of Integer Series: N * (first + last) / 2
       long N = n/div;
        
       return div * N *(1 + N)/2;
    }
}