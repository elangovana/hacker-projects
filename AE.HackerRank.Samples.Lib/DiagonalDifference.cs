using System;

namespace AE.HackerRank.Samples.Lib
{
    public class DiagonalDifference
    {
      

        public IDiagonalDifferenceInputReader InputReader { get; set; }

        public int Run()
        {
            var length = InputReader.GetLength();
            var sumd1 = 0;
            var sumd2 = 0;
            for (var i = 0; i < length; i++)
            {
                var inputLineNumbers = InputReader.GetInputMatrixLine();
                sumd1 += (inputLineNumbers[i]);

                sumd2 +=(inputLineNumbers[length -1 - i]);

            }
            return Math.Abs( sumd2 - sumd1);
        }
    }
}