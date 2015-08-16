using System.Globalization;
using NUnit.Framework;
using Rhino.Mocks;

namespace AE.HackerRank.Samples.Tests
{
    [TestFixture]
    public class UnitTestBiggerIsGreater
    {
        private const char LineSeparator = ',';
        private const string no_answer = "no answer";

        [TestCase("ab,bb,hefg,dhck,dkhc,a", "ba," + no_answer + ",hegf,dhkc,hcdk," + no_answer)]
        [TestCase("ab", "ba")]
        [TestCase("a", no_answer)]
        [TestCase("ab", "ba")]
        [TestCase("aab", "aba")]
        [TestCase("bb", no_answer)]
        [TestCase("hefg", "hegf")]
        [TestCase("dkhc", "hcdk")]
        [TestCase("4753", "5347")]
        [TestCase("4253", "4325")]
        [TestCase("8573", "8735")]
        [TestCase("4375", "4537")]
        [TestCase("4357", "4375")]
        [TestCase("7531", no_answer)]
        [TestCase("bvulomthrfugqfbaknxginokekuemgb", "bvulomthrfugqfbaknxginokekugbem")]
        public void ShouldFindSmallest(string iwords, string expected)
        {
            //Arrange                       

            var mockReader = GetMockReader(iwords);
            var sut = new BiggerIsBetter {InputReader = mockReader, NoAnswerValue = no_answer};
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