using System.Collections.Generic;

namespace AE.HackerRank.Samples.Lib
{
    public interface IShortestHops<TNode, TEdgeWeight>
    {
        Dictionary<TNode, int> FindShortestHops(AbstractGraph<TNode, TEdgeWeight> graph, TNode sourceNode);
    }
}