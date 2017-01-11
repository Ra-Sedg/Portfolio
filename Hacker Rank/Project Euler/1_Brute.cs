using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static void Main(String[] args) 
    {
        
        int t = Convert.ToInt32(Console.ReadLine());
        
        for(int a0 = 0; a0 < t; a0++)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine(getSum(n));
        }
    }
    
    static int getSum(int n) {
        
        int sum = 0;
        
        for (int i = 0; i < n; i++) 
        {
            if ((i % 3 == 0) || (i % 5 == 0)) 
            {
                sum += i;   
            }
        }
        
        return sum;
    }
}