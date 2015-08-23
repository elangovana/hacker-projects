namespace AE.HackerRank.Samples.Lib
{
    public class UndirectedGraph<TNode, TEdgeWeight> : AbstractGraph<TNode, TEdgeWeight>
    {
        public override void AddEdge(TNode sourceNode, TNode destinationNode, TEdgeWeight edgeWeight)
        {
            base.AddEdge(sourceNode, destinationNode, edgeWeight);
            base.AddEdge(destinationNode, sourceNode, edgeWeight);
        }
    }
}