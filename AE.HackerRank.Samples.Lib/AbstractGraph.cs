using System.Collections.Generic;
using System.Linq;

namespace AE.HackerRank.Samples.Lib
{
    public abstract class AbstractGraph<TNode, TEdgeWeight>
    {
        private readonly List<AdjacencyListNode<TNode, TEdgeWeight>> _adjacencyListNodes;

        protected AbstractGraph()
        {
            _adjacencyListNodes = new List<AdjacencyListNode<TNode, TEdgeWeight>>();
        }

        public virtual void AddNode(TNode node)
        {
            if (!_adjacencyListNodes.Any(x => x.SourceNode.Equals(node)))
                _adjacencyListNodes.Add(new AdjacencyListNode<TNode, TEdgeWeight> {SourceNode = node});
        }

        public virtual IEnumerable<TNode> GetNodes()
        {
            return _adjacencyListNodes.Select(x => x.SourceNode);
        }

        public virtual void AddEdge(TNode sourceNode, TNode destinationNode, TEdgeWeight edgeWeight)
        {
            AddNode(sourceNode);
            AddNode(destinationNode);

            var adjacenyListNode = _adjacencyListNodes.Single(x => x.SourceNode.Equals(sourceNode));

            var anotherNeighbour = adjacenyListNode.EdgeList;
            adjacenyListNode.EdgeList = new AdjacencyListEdge<TNode, TEdgeWeight>
            {
                DestinatioNode = destinationNode,
                Weight = edgeWeight,
                Next = anotherNeighbour
            };
        }

        public IEnumerable<TNode> GetNeighbours(TNode isourceNode)
        {
            var neighbourNode = _adjacencyListNodes.Single(x => x.SourceNode.Equals(isourceNode));
            var edgeList = neighbourNode.EdgeList;
            while (edgeList != null)
            {
                var currentEdgeList = edgeList;
                edgeList = edgeList.Next;
                yield return currentEdgeList.DestinatioNode;
            }
        }
    }
}