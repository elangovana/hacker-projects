using System;
using System.Linq;
using AE.HackerRank.Samples.Lib;

namespace AE.HackerRank.Samples.DiagDifference
{
    internal class DiagonalDifferenceConsoleReader : IDiagonalDifferenceInputReader
    {
        public int GetLength()
        {
            return int.Parse(Console.ReadLine());
        }

        public int[] GetInputMatrixLine()
        {
            var strNumbers = Console.ReadLine().Split(' ');

            return strNumbers.Select(int.Parse).ToArray();
        }
    }
}