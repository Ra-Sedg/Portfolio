using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static void Main(String[] args) {
        string[] h_temp = Console.ReadLine().Split(' ');
        int[] h = Array.ConvertAll(h_temp,Int32.Parse);
        char[] word = Console.ReadLine().ToCharArray();
        
        
        int maxHeight = 0;
        
        foreach (char c in word) {
            int i = (int)c - 97;                     // acii - 97 = index of charater in h[] 
            maxHeight = Math.Max(maxHeight, h[i]);
        }
        
        Console.WriteLine(maxHeight * word.Length);
    }
}