using System.Collections.Generic;

namespace AE.HackerRank.Samples.PlusMinus
{
    public interface IPlusMinusInputReader
    {
        int GetLength();
        IEnumerable<int> GetNextNumber();
    }
}