using System;
using System.Collections.Generic;
using System.Linq;
using AE.HackerRank.Samples.Lib;

namespace AE.HackerRank.Samples.PlusMinus
{
    internal class PlusMinusConsoleInputReader : IPlusMinusInputReader
    {
        public int GetLength()
        {
            return int.Parse(Console.ReadLine());
        }

        public IEnumerable<int> GetNextNumber()
        {
            return Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);
        }
    }
}