using System;

namespace AE.HackerRank.Samples
{
    public class ConsoleNumberReader : INumberInputReader
    {
        public int ReadNumber()
        {
            return int.Parse(Console.ReadLine());
        }
    }
}