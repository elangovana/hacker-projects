using System;
using AE.HackerRank.Samples.Lib;

namespace AE.HackerRank.Samples
{
    public class CommandTraceInsertionSort : IProblemCommand
    {
        public void Run()
        {
            var item = new InsertionSortTrace();
            var consoleReaderListOfNumbers = new ConsoleReaderListOfNumbers();
            var trace = item.TraceSort(consoleReaderListOfNumbers.GetNumbers());
            foreach (var traceItem in trace)
            {
                Console.WriteLine(string.Join(" ", traceItem));
            }

        }
    }
}