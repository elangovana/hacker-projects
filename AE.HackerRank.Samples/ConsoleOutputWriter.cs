using System;
using System.Collections.Generic;
using AE.HackerRank.Samples.Lib;

namespace AE.HackerRank.Samples
{
    public class ConsoleOutputWriter : IOutputWriter
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