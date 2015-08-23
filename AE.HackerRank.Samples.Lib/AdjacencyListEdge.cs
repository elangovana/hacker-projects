namespace AE.HackerRank.Samples.Lib
{
    public class AdjacencyListEdge<TNode, TEdgeWeight>
    {
        public TNode DestinatioNode { get; set; }
        public TEdgeWeight Weight { get; set; }
        public AdjacencyListEdge<TNode, TEdgeWeight> Next { get; set; }
    }
}