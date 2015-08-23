using System.Collections.Generic;
using System.Dynamic;

namespace AE.HackerRank.Samples.Lib
{
    public interface IGraphReader<TNode, TEdgeWeight>
    {
        AbstractGraph<TNode, TEdgeWeight> GetGraph();
        IEnumerable<AbstractGraph<TNode, TEdgeWeight>> GetGraphs();
         TEdgeWeight DefaultEdgeWeight { get; set; }

        bool IgnoreDuplicateEdges { get; set; }
    }
}