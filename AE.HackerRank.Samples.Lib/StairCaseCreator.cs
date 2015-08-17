using System.Collections.Generic;

namespace AE.HackerRank.Samples.Lib
{
    public class StairCaseCreator
    {
       

        private char _pattern = '#';

        public INumberInputReader InputReader { get; set; }

      
        public char Pattern
        {
            get { return _pattern; }
            set { _pattern = value; }
        }

        public IOutputWriter OutputWriter { get; set; }

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