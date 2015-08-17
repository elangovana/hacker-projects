using System;
using System.Linq;

namespace AE.HackerRank.Samples.Lib
{
    public class ConsoleReaderListOfNumbers : IReaderListOfNumbers
    {
        private int? _length;
        public int GetLength()
        {
            return (int) ( _length?? (_length = int.Parse(Console.ReadLine())));
        }

        public int[] GetNumbers()
        {
            GetLength();
            return
                Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        }
    }
}