using System.Collections.Generic;
using System.Linq;

namespace AE.HackerRank.Samples.Lib
{
    public class AlgorithmNearestHopsBfs<TNode, TEdgeWeight> : IShortestHops<TNode, TEdgeWeight>
    {
        private Queue<TNode> _bfsQueue;
        private HashSet<TNode> _visitedNodes;
        private AbstractGraph<TNode, TEdgeWeight> _graph;
        private Dictionary<TNode, int> _result;
        private HashSet<TNode> _unvisitedNodes;

        public Dictionary<TNode, int> FindShortestHops(AbstractGraph<TNode, TEdgeWeight> graph, TNode sourceNode)
        {
            Init(graph);
            _result.Add(sourceNode, 0);
            BfsSearch(sourceNode);

            return _result;
        }

        private void Init(AbstractGraph<TNode, TEdgeWeight> graph)
        {
            _graph = graph;
            _bfsQueue = new Queue<TNode>();
            _result = new Dictionary<TNode, int>();
            _visitedNodes = new HashSet<TNode>();
            _unvisitedNodes = new HashSet<TNode>(_graph.GetNodes());
        }

        private void BfsSearch(TNode sourceNode)
        {
            AddToVisitedAndQueue(sourceNode);

            while (_bfsQueue.Any() && _unvisitedNodes.Any())
            {
                var currentNode = _bfsQueue.Peek();
               
                foreach ( var neighbour in _graph.GetNeighbours(currentNode).Where(x => !IsVisited(x)) )
                {
                    ReportDistance(neighbour, currentNode);

                   AddToVisitedAndQueue(neighbour);
                }
                _bfsQueue.Dequeue();
            }
        }

        private void AddToVisitedAndQueue(TNode node)
        {
            _bfsQueue.Enqueue(node);
            _visitedNodes.Add(node);
            _unvisitedNodes.Remove(node);
        }

        private bool IsVisited(TNode node)
        {
            return _visitedNodes.Contains(node);
        }

        private void ReportDistance(TNode node, TNode parentNode)
        {
            var nodeDist = _result.ContainsKey(parentNode) ? _result[parentNode] + 1 : 0;
            if (!_result.ContainsKey(node)) _result.Add(node, nodeDist);
        }
    }
}