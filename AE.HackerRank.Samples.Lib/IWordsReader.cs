using System.Collections.Generic;

namespace AE.HackerRank.Samples.Lib
{
    public interface IWordsReader
    {
        int GetLength();
        IEnumerable<string> GetNextWord();
    }
}