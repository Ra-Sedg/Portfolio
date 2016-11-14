using System;
using System.Collections.Generic;

public class SandBox
{
    public static void Main()
    {
        int[,] matrix = new int[3, 3];
        int c = 0;

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                matrix[i, j] = c++;
            }
        }

        for (int i = 0; i <3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                System.Console.WriteLine("index: " + i + "," + j + " : Value: " + matrix[i, j]);
            }
        }

        int[] arr = { 1, 2, 3 };

        List<int> list1 = new List<int>();
        list1.AddRange(arr);

        for (int i = 0; i < list1.)
    }
}