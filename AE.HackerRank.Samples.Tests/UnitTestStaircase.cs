using NUnit.Framework;
using Rhino.Mocks;

namespace AE.HackerRank.Samples.Tests
{
    [TestFixture]
    public class UnitTestStaircase
    {
        [TestCase(1, '#', "#")]
        [TestCase(1, '0', "0")]
        [TestCase(2, '0', " 0\n" +
                          "00")]
        public void ShouldReturnCorrectNumberOfStairsGivenLengthPattern(int ilength, char pattern, string expected)
        {
            //Arrange                       
            var mockInputReader = MockRepository.GenerateMock<INumberInputReader>();
            mockInputReader.Stub(x => x.ReadNumber()).Return(ilength);

            var sut = new StairCaseCreator {InputReader = mockInputReader, Pattern = pattern};

            //Act
            var actual = sut.Run();


            //Assert
            Assert.AreEqual(expected.Split(LineSeparator), actual);
        }

        public const char LineSeparator = '\n';
    }
}