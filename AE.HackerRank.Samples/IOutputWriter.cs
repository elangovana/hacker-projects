using System.Collections.Generic;

namespace AE.HackerRank.Samples
{
    public interface IOutputWriter
    {
        void Write(IEnumerable<string> strings);
    }
}