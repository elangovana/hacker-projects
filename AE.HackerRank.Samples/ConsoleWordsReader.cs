using System;
using System.Collections.Generic;

namespace AE.HackerRank.Samples
{
    class ConsoleWordsReader : IWordsReader
    {
        public int GetLength()
        {
            return int.Parse(Console.ReadLine());
        }

        public IEnumerable<string> GetNextWord()
        {
            var length = GetLength();
            for (var i = 0; i < length; i++)
            {
                yield return Console.ReadLine();
            }
        }
    }
}