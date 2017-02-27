using System;

namespace CodeSprint2._1
{
    class Program
    {
        static void Main(String[] args)
        {
            int games = Convert.ToInt32(Console.ReadLine());
            string[] scores_temp = Console.ReadLine().Split(' ');
            int[] scores = Array.ConvertAll(scores_temp, Int32.Parse);

            int maxRecord = 0;
            int minRecord = 0;
            int maxRecordCounter = 0;
            int minRecordCounter = 0;

            for (int i = 1; i < games; i++)
            {
               

                if (scores[i] > maxRecord)
                {
                    maxRecord = scores[i];
                    maxRecordCounter++;
                }

                if (scores[i] < minRecord)
                {
                    minRecord = scores[i];
                    minRecordCounter++;
                }

            }

            Console.WriteLine($"{maxRecordCounter}, {minRecordCounter}");
        }

        
    }
}
