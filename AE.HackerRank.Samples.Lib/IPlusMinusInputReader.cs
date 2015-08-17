using System.Collections.Generic;

namespace AE.HackerRank.Samples.Lib
{
    public interface IPlusMinusInputReader
    {
        int GetLength();
        IEnumerable<int> GetNextNumber();
    }
}