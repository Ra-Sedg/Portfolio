using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static void Main(String[] args) {
        string[] tokens_a0 = Console.ReadLine().Split(' ');
        string[] tokens_b0 = Console.ReadLine().Split(' ');
        
        int[] aliceScore = new int[4];
        int[] bobScore = new int[4];
        
        aliceScore[3] = bobScore[3] = 0;
        
        for (int i = 0; i < 3; i++) {
            aliceScore[i] = Convert.ToInt32(tokens_a0[i]);
            bobScore[i] = Convert.ToInt32(tokens_b0[i]);
            
            if (aliceScore[i] > bobScore[i]) {
                aliceScore[3] += 1;
            }
            
            if (bobScore[i] > aliceScore[i]) {
                bobScore[3] += 1;
            }
        }
        
        Console.WriteLine(aliceScore[3] + " " + bobScore[3]);
    }
    
    
}