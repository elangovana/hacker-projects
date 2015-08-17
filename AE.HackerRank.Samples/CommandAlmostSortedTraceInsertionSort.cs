using System;
using AE.HackerRank.Samples.Lib;

namespace AE.HackerRank.Samples
{
    public class CommandAlmostSortedTraceInsertionSort : IProblemCommand
    {
        public void Run()
        {
            var item = new InsertionSortTrace();
            var consoleReaderListOfNumbers = new ConsoleReaderListOfNumbers();
            var trace = item.TraceSortForAlmostSortedList(consoleReaderListOfNumbers.GetNumbers());
            foreach (var traceItem in trace)
            {
                Console.WriteLine(string.Join(" ", traceItem));
            }

        }
    }
}