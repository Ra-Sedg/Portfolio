using System;
using System.Collections.Generic;
using System.IO;
class Solution 
{
    
    static void Main(string[] args)
    {
        int[] initialValues = Array.ConvertAll(Console.ReadLine().Split(' '), Int32.Parse);
        int leftShifts = initialValues[1];

        int[] array = Array.ConvertAll(Console.ReadLine().Split(' '), Int32.Parse);

        array = leftShift(array, leftShifts);

        foreach (int i in array)
        {
            Console.Write(i + " ");
        }

        Console.ReadKey();
    }


    static int[] leftShift(int[] array,  int shifts)
    {

        if (array.Length < 1)
        {
            return array;
        }

        int[] temp = new int[array.Length];

        for (int i = 0, j = 0; i < array.Length; i++)
        {

            if (i - shifts < 0)
            {
                j = (array.Length - shifts) + i;
            }
            else
            {
                j = i - shifts;
            }

            temp[j] = array[i];
        }

        return temp;
    }
    
}