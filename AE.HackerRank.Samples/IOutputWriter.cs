using System;
using System.Collections.Generic;

namespace AE.HackerRank.Samples
{
    public interface IOutputWriter
    {
        void Write(IEnumerable<string> strings);
    }

    class ConsoleOutputWriter : IOutputWriter
    {
        public void Write(IEnumerable<string> strings)
        {
            foreach (var item in strings)
            {
                Console.WriteLine(item);
            }
        }
    }
}