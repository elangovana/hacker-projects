using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AE.HackerRank.Samples.Lib
{
    public class InsertionSortTrace
    {
        
        public IEnumerable<int[]> TraceSortForAlmostSortedList(int[] almostSortedList)
        {
            var lastItem = almostSortedList.Last();
            var i = almostSortedList.Length - 1;
            var needSorting = false;
            for (; i > 0 && almostSortedList[i - 1] > lastItem; i--)
            {
                needSorting = true;
                almostSortedList[i] = almostSortedList[i - 1];

                yield return almostSortedList.ToArray();
            }
            if (needSorting)
            {
                almostSortedList[i] = lastItem;
            }

            yield return almostSortedList;
        }


       
    }
}
