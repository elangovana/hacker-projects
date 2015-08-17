using System.Collections.Generic;

namespace AE.HackerRank.Samples.Lib
{
    public interface IOutputWriter
    {
        void Write(IEnumerable<string> strings);
    }
}