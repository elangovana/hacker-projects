using System;

namespace AE.HackerRank.Samples
{
    internal class Solution
    {
        private static void Main(string[] args)
        {
            /* Enter your code here. Read input from STDIN. Print output to STDOUT */
            Run();
        }

        private static void Run()
        {
            var length = int.Parse(Console.ReadLine());
          
            long sumd1 = 0;
            long sumd2 = 0;
            for (var i = 0; i < length; i++)
            {
                var inputs = Console.ReadLine().Trim().Split(' ');
                sumd1 += int.Parse(inputs[i]);
                sumd2 += int.Parse(inputs[length - i]);

            }

            Console.WriteLine(Math.Abs (sumd1 - sumd2));
        }
    }
}