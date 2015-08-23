using System;
using AE.HackerRank.Samples.Lib;

namespace AE.HackerRank.Samples
{
    internal class Program
    {
        private static void Main(string[] args)
        {
          
           
           IProblemCommand command = new CommandProblemShortestReach();
            command.Run();
            Console.ReadLine();

          
        }

        
    }
}