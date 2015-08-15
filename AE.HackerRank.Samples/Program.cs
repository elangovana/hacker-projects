using System;

namespace AE.HackerRank.Samples
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var stairCaseCreator = new StairCaseCreator();
            var stairCases = stairCaseCreator.Run();

            stairCaseCreator.OutputWriter.Write(stairCases);
            Console.WriteLine("Press enter to quit");
            Console.ReadLine();
        }

        
    }
}