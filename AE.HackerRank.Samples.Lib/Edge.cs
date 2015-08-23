namespace AE.HackerRank.Samples.Lib
{
    public class Edge<TNode, TEdgeWeight>
    {
        public TNode SourceNode { get; set; }
        public TNode DestinationNode { get; set; }
        public TEdgeWeight Weight { get; set; }
    }
}