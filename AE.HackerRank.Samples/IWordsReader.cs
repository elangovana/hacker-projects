using System.Collections.Generic;

namespace AE.HackerRank.Samples
{
    public interface IWordsReader
    {
        int GetLength();
        IEnumerable<string> GetNextWord();
    }
}