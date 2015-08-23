namespace AE.HackerRank.Samples.Lib
{
    public class AdjacencyListNode<TNode, TEdgeWeight>
    {
        public TNode SourceNode { get; set; }
        public AdjacencyListEdge<TNode, TEdgeWeight> EdgeList { get; set; }
    }
}