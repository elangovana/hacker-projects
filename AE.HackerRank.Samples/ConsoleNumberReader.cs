using System;
using AE.HackerRank.Samples.Lib;

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