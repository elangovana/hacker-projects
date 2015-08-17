using System;
using System.Collections.Generic;
using System.Linq;
using AE.HackerRank.Samples.Lib;
using AE.HackerRank.Samples.PlusMinus;
using NUnit.Framework;
using Rhino.Mocks;

namespace AE.HackerRank.Samples.Tests
{
    [TestFixture]
    public class UnitTestPlusMinus
    {
        private const char NumberSeparator = ' ';

        [TestCase(1, "11", 3, 1.000)]
        [TestCase(2, "11 -11", 3, .50)]
        [TestCase(3, "11 -11 -11", 4, .33330)]
        public void ShouldCalculatePercentagePostiveNumbersGivenLengthRoundDecimal(int ilength, string inumbers, int iroundToPlaces, double expectedFraction)
        {
            //Arrange           
            var matrix = ParseNumbers(inumbers);
            double actualPostiveNumbers, actualNegativeNumbers, actualZeroNumbers;

            var mockInputReader = PlusMinusInputReader(ilength, matrix);
            var sut = new Lib.PlusMinus {InputReader = mockInputReader, RoundToDecimalPlaces = iroundToPlaces};

            //Act
            sut.Run(out actualPostiveNumbers, out actualNegativeNumbers, out actualZeroNumbers);


            //Assert
            Assert.AreEqual(expectedFraction, actualPostiveNumbers);
        }



        [TestCase(1, "11",3, 0.000)]
        [TestCase(2, "11 -11",3, .50)]
        [TestCase(3, "11 -11 -11", 4,.6667)]
        public void ShouldCalculatePercentageNegativeNumbers(int ilength, string inumbers, int iroundToPlaces, double expectedFraction)
        {
            //Arrange
           
            var matrix = ParseNumbers(inumbers);
            double actualPostiveNumbers, actualNegativeNumbers, actualZeroNumbers;


            //Setup
            var mockInputReader = PlusMinusInputReader(ilength, matrix);
            var sut = new Lib.PlusMinus { InputReader = mockInputReader, RoundToDecimalPlaces = iroundToPlaces};

            //Act
            sut.Run(out actualPostiveNumbers, out actualNegativeNumbers, out actualZeroNumbers);


            //Assert
            Assert.AreEqual( expectedFraction, actualNegativeNumbers );
        }

        [TestCase(1, "11", 3, 0.000)]
        [TestCase(3, "11 -11 0", 3,.333)]
        [TestCase(5, "11 0 0 0 0", 4, .80)]
        public void ShouldCalculatePercentageZeroNumbers(int ilength, string inumbers, int iroundToPlaces, double expectedFraction)
        {
            //Arrange

            var matrix = ParseNumbers(inumbers);
            double actualPostiveNumbers, actualNegativeNumbers, actualZeroNumbers;


            //Setup
            var mockInputReader = PlusMinusInputReader(ilength, matrix);
            var sut = new Lib.PlusMinus { InputReader = mockInputReader, RoundToDecimalPlaces = iroundToPlaces};

            //Act
            sut.Run(out actualPostiveNumbers, out actualNegativeNumbers, out actualZeroNumbers);


            //Assert
            Assert.AreEqual(expectedFraction, actualZeroNumbers);
        }

        private static IPlusMinusInputReader PlusMinusInputReader(int ilength, int[] matrix)
        {
            var mockInputReader = MockRepository.GenerateMock<IPlusMinusInputReader>();
            mockInputReader.Stub(x => x.GetLength()).Return(ilength);
            mockInputReader.Stub(x => x.GetNextNumber()).Do((Func<IEnumerable<int>>) (() => matrix));
            return mockInputReader;
        }

        private static int[] ParseNumbers(string matrix)
        {
            var numbers =
                matrix.Split(new[] {NumberSeparator}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            return numbers;
        }
    }
}