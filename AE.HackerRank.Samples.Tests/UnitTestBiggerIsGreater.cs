using System.Globalization;
using AE.HackerRank.Samples.Lib;
using NUnit.Framework;
using Rhino.Mocks;

namespace AE.HackerRank.Samples.Tests
{
    [TestFixture]
    public class UnitTestBiggerIsGreater
    {
        private const char LineSeparator = ',';
        private const string NoAnswer = "no answer";

        [TestCase("ab,bb,hefg,dhck,dkhc,a", "ba," + NoAnswer + ",hegf,dhkc,hcdk," + NoAnswer)]
        [TestCase("ab", "ba")]
        [TestCase("a", NoAnswer)]
        [TestCase("ab", "ba")]
        [TestCase("aab", "aba")]
        [TestCase("bb", NoAnswer)]
        [TestCase("hefg", "hegf")]
        [TestCase("dkhc", "hcdk")]
        [TestCase("4753", "5347")]
        [TestCase("4253", "4325")]
        [TestCase("8573", "8735")]
        [TestCase("4375", "4537")]
        [TestCase("4357", "4375")]
        [TestCase("7531", NoAnswer)]
        [TestCase("bvulomthrfugqfbaknxginokekuemgb", "bvulomthrfugqfbaknxginokekugbem")]
        public void ShouldFindSmallest(string iwords, string expected)
        {
            //Arrange                       

            var mockReader = GetMockReader(iwords);
            var sut = new BiggerIsBetter {InputReader = mockReader, NoAnswerValue = NoAnswer};
            //Act
            var actual = sut.Run();


            //Assert
            Assert.AreEqual(expected.Split(LineSeparator), actual);
        }

        private static IWordsReader GetMockReader(string words)
        {
            var mockReader = MockRepository.GenerateStub<IWordsReader>();

            var wordsArray = words.Split(LineSeparator);
            mockReader.Stub(x => x.GetLength()).Return(wordsArray.Length);
            mockReader.Stub(x => x.GetNextWord()).Return(wordsArray);

            return mockReader;
        }
    }
}