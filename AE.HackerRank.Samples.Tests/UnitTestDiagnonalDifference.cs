using System;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using AE.HackerRank.Samples.DiagDifference;
using NUnit.Framework;
using Rhino.Mocks;

namespace AE.HackerRank.Samples.Tests
{
    [TestFixture]
    public class UnitTestDiagnonalDifference
    {
        private const char LineSeparator = '\n';
        private const char NumberSeparator = ' ';

        [TestCase(3, "11 2 4 \n" +
                     "4 5 6 \n" +
                     "10 8 -12", 15)]
        [TestCase(1, "11", 0)]
        public void ShouldCalculateDiagonalSum(int ilength, string imatrix, int expectedDiagnoalDiff)
        {
            //Arrange
            var i = -1;
            var matrix = ParseMatrix(imatrix);
            //Setup
            var mockInputReader = MockRepository.GenerateMock<IDiagonalDifferenceInputReader>();
            mockInputReader.Stub(x => x.GetLength()).Return(ilength);
            mockInputReader.Stub(x => x.GetInputMatrixLine()).Do((Func<int[]>) (() =>
            {
                i++;
                return matrix[i];
            }));
            var sut = new DiagonalDifference {InputReader = mockInputReader};

            //Act
            var actual =  sut.Run();


            //Assert
            Assert.AreEqual(expectedDiagnoalDiff, actual);
        }


        static int[][] ParseMatrix(string matrix)
        {
            var matrixLines = matrix.Split(LineSeparator);
            var result = new int[matrixLines.Length][];
            for (int i = 0; i < matrixLines.Length; i++)
            {
                var line = matrixLines[i];
                result[i] = line.Split(new []{NumberSeparator}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }

            return result;
        }


    }
}