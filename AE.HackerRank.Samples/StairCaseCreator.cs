using System.Collections.Generic;
using System.IO;

namespace AE.HackerRank.Samples
{
    public class StairCaseCreator
    {
        private INumberInputReader _inputReader;

        private char _pattern = '#';

        public INumberInputReader InputReader
        {
            get { return _inputReader ?? (_inputReader = new ConsoleNumberReader()); }
            set { _inputReader = value; }
        }

        private IOutputWriter _outputWriter;
        public char Pattern
        {
            get { return _pattern; }
            set { _pattern = value; }
        }

        public IOutputWriter OutputWriter
        {
            get { return _outputWriter ?? (_outputWriter = new ConsoleOutputWriter()); }
            set { _outputWriter = value; }
        }

        public IEnumerable<string> Run()
        {
            var length = InputReader.ReadNumber();
            for (var i = 0; i < length; i++)
            {
                yield return Pattern.ToString().PadLeft(i+1, Pattern).PadLeft(length);
               
            }
        }
    }
}