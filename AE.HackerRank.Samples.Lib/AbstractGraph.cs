using System.Collections.Generic;
using System.Linq;

namespace AE.HackerRank.Samples.Lib
{
    public abstract class AbstractGraph<TNode, TEdgeWeight>
    {
        private readonly Dictionary<TNode, AdjacencyListEdge<TNode, TEdgeWeight>> _adjacencyListNodes;

        protected AbstractGraph()
        {
            _adjacencyListNodes = new Dictionary<TNode, AdjacencyListEdge<TNode, TEdgeWeight>>();
        }

        public virtual void AddNode(TNode node)
        {
            //   if (!_adjacencyListNodes.Any(x => x.SourceNode.Equals(node)))
            _adjacencyListNodes.Add(node, null);
        }

        public virtual IEnumerable<TNode> GetNodes()
        {
            return _adjacencyListNodes.Keys;
        }

        private void AddNodeIfItDoesntExist(TNode node)
        {
           
            if (!_adjacencyListNodes.ContainsKey(node)) _adjacencyListNodes.Add(node, null);
        }

        public virtual void AddEdge(TNode sourceNode, TNode destinationNode, TEdgeWeight edgeWeight)
        {
           AddNodeIfItDoesntExist(sourceNode);
           AddNodeIfItDoesntExist(destinationNode);


           var nextAdjacencyEdge = _adjacencyListNodes[sourceNode];
           _adjacencyListNodes[sourceNode] = new AdjacencyListEdge<TNode, TEdgeWeight>
            {
                DestinatioNode = destinationNode,
                Weight = edgeWeight,
                Next = nextAdjacencyEdge
            };
        }

        public IEnumerable<TNode> GetNeighbours(TNode isourceNode)
        {
            var edgeList = _adjacencyListNodes[isourceNode];    
            while (edgeList != null)
            {
                var currentEdgeList = edgeList;
                edgeList = edgeList.Next;
                yield return currentEdgeList.DestinatioNode;
            }
        }
    }
}