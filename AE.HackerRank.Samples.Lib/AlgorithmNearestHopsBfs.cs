using System.Collections.Generic;
using System.Linq;

namespace AE.HackerRank.Samples.Lib
{
    public class AlgorithmNearestHopsBfs<TNode, TEdgeWeight> : IShortestHops<TNode, TEdgeWeight>
    {
        private Stack<TNode> _bfsStack;
        private AbstractGraph<TNode, TEdgeWeight> _graph;
        private Dictionary<TNode, int> _result;

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
            _bfsStack = new Stack<TNode>();
            _result = new Dictionary<TNode, int>();
        }

        private void BfsSearch(TNode sourceNode)
        {
            _bfsStack.Push(sourceNode);

            var unvisitedNeighbours = new List<TNode>();
            foreach (var neighbour in    _graph.GetNeighbours(sourceNode))
            {
                if (IsVisited(neighbour)) continue;
                unvisitedNeighbours.Add(neighbour);
                ReportDistance(neighbour, sourceNode);
            }

            foreach (var neighbour in unvisitedNeighbours)
            {
               BfsSearch(neighbour);
            }
         
        }

        private bool IsVisited(TNode node)
        {
            return _bfsStack.Contains(node);
        }

        private void ReportDistance(TNode node, TNode parentNode)
        {
            var nodeDist = _result.ContainsKey(parentNode) ? _result[parentNode] + 1 : 0;
           if (!_result.ContainsKey(node)) _result.Add(node, nodeDist);
        }
    }
}