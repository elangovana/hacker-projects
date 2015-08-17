using System;
using System.Collections.Generic;
using System.Linq;
using AE.HackerRank.Samples.Lib;
using NUnit.Framework;
using Rhino.Mocks;

namespace AE.HackerRank.Samples.Tests.Sorting
{
    [TestFixture]
    public class UnitTestInsertionSort
    {
        [TestCase("1", "1")]
        [TestCase("1 2", "1 2")]
        [TestCase("1 3 2", "1 3 3\n 1 2 3")]
        [TestCase("2 4 6 8 3", "2 4 6 8 8 \n" +
                               "2 4 6 6 8 \n" +
                               "2 4 4 6 8 \n" +
                               "2 3 4 6 8 ")]
        public void ShouldTraceInsertionSortWhenGivenAnAlmostSortedList(string almostSortedList, string expectedTrace)
        {
            var expected = ParseListOfArrays(expectedTrace);
            var sut = new InsertionSortTrace();

            //Act
            var actual = sut.TraceSortForAlmostSortedList(ParseListOfNumbers(almostSortedList));

            //Assert
            Assert.AreEqual(expected, actual);
        }

       

        private IEnumerable<int[]> ParseListOfArrays(string listOfArrays)
        {
            return listOfArrays.Split(LineSeparator, StringSplitOptions.RemoveEmptyEntries).Select(ParseListOfNumbers);
        }

        public char[] LineSeparator = {'\n'};

        private int[] ParseListOfNumbers(string almostSortedList)
        {
            return
                almostSortedList.Split(NumberSeparator, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
        }

        public char[] NumberSeparator = {' '};
    }

   
}