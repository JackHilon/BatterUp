using System;

namespace BatterUp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Batter up
            // https://open.kattis.com/problems/batterup 
            // -- weighted average calculation --

            var bats = EnterAtBatNum();

            var myScores = EnterScoresLine(bats);

            Console.WriteLine(BatScoresAverage(myScores));
        }
        private static double BatScoresAverage(int[] scores)
        {
            double result = 0;
            var sum = BatSum(scores);
            var num = ArrayNegOneNum(scores);
            result = (double)sum / (scores.Length - num);
            return result;
        }

        private static int BatSum(int[] scores)
        {
            int sum = 0;
            for (int i = 0; i < scores.Length; i++)
            {
                if (scores[i] != -1)
                    sum = sum + scores[i];
            }
            return sum;
        }

        private static int ArrayNegOneNum(int[] array)
        {
            int num = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == -1)
                    num = num + 1;
            }
            return num;
        }

        private static int[] EnterScoresLine(int BatNo)
        {
            var arr = new string[BatNo];
            var scores = new int[BatNo];
            try
            {
                arr = Console.ReadLine().Split(' ', BatNo);
                for (int i = 0; i < scores.Length; i++)
                {
                    scores[i] = int.Parse(arr[i]);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return EnterScoresLine(BatNo);
            }
            return scores;
        }

        private static int EnterAtBatNum()
        {
            int a = 0;
            try
            {
                a = int.Parse(Console.ReadLine());
                if (a < 1 || a > 100)
                    throw new ArgumentException();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return EnterAtBatNum();
            }
            return a;
        }
    }
}
