using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AE.HackerRank.Samples
{
    /// <summary>
    /// Given a word w, rearrange the letters of w to construct another word s in such a way that s is lexicographically greater than w. In case of multiple possible answers, find the lexicographically smallest one.
    /// </summary>
    /// <para>
    /// For each testcase, output a string lexicographically bigger than w in a separate line. In case of multiple possible answers, print the lexicographically smallest one, and if no answer exists, print no answer.
    /// </para>
    public class BiggerIsBetter
    {
        private IWordsReader _inputReader;
        private IOutputWriter _outputWriter;
        public string NoAnswerValue = "no answer";

        public IWordsReader InputReader
        {
            get { return _inputReader ?? (_inputReader = new ConsoleWordsReader()); }
            set { _inputReader = value; }
        }

        public IOutputWriter OutputWriter
        {
            get { return _outputWriter ?? (_outputWriter = new ConsoleOutputWriter()); }
            set { _outputWriter = value; }
        }

        public IEnumerable<string> Run()
        {
            return InputReader.GetNextWord().Select(GetNextLargestWord);
        }

        private string GetNextLargestWord(string word)
        {
            var sortIndex = 0;
            var orginalWord = word;
            for (var i = word.Length - 1; i > 0; i--)
            {
                if (word[i] > word[i - 1])
                {
                    var j = i;
                    while (j < word.Length && word[j] > word[i - 1])
                    {
                        j++;
                    }
                    j--;
                    word = Swap(word, j, i - 1);
                    word = SortLetterInWord(word, i);
                    break;
                }
            }


            return word.Equals(orginalWord) ? NoAnswerValue : word;
        }

        private string SortLetterInWord(string word, int sortStartIndex)
        {
            var sortedWord = new StringBuilder(word.Substring(0, sortStartIndex));
            word.Substring(sortStartIndex).OrderBy(x => x).ToList().ForEach(x => sortedWord.Append(x));

            return sortedWord.ToString();
        }

        private static string Swap(string word, int i, int j)
        {
            var result = new StringBuilder(word);
            result.Replace(word[i], word[j], i, 1);
            result.Replace(word[j], word[i], j, 1);
            return result.ToString();
        }
    }
}