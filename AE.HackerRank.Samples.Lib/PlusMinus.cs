using System;

namespace AE.HackerRank.Samples.Lib
{
    public class PlusMinus
    {
        public int RoundToDecimalPlaces = 3;


        public IPlusMinusInputReader InputReader { get; set; }

        public void Run(out double fractionPostiveNumbers, out double fractionNegativeNumbers,
            out double fractionZeroNumbers)
        {
            var length = InputReader.GetLength();
            int countPostive = 0, countNegative = 0, countZero = 0;

            foreach (var number in InputReader.GetNextNumber())
            {
                if (number > 0) countPostive++;

                if (number < 0) countNegative++;

                if (number == 0) countZero++;
            }


        
            fractionNegativeNumbers = Math.Round( (double) countNegative/length , RoundToDecimalPlaces);
            fractionPostiveNumbers =  Math.Round( (double) countPostive/length, RoundToDecimalPlaces );
            fractionZeroNumbers = Math.Round((double)countZero / length, RoundToDecimalPlaces); ;
        }
    }
}