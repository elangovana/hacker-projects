using System;
using System.Collections.Generic;
using System.Linq;
using AE.HackerRank.Samples.Lib;

namespace AE.HackerRank.Samples
{
    internal class ConsoleGraphReader : IGraphReader<int, int>
    {
        private readonly char[] separator = {' '};
        private int _defaultEdgeWeight = 6;

        public int DefaultEdgeWeight
        {
            get { return _defaultEdgeWeight; }
            set { _defaultEdgeWeight = value; }
        }

        public bool IgnoreDuplicateEdges { get; set; }

        public AbstractGraph<int, int> GetGraph()
        {
            //Read no of nodes and edges
            var graph = new UndirectedGraph<int, int>();
            var noOfNodesAndEdges =
                Console.ReadLine().Split(separator, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            var noOfNodes = noOfNodesAndEdges.First();
            var noOfEdges = noOfNodesAndEdges.Last();

            for (int n = 0, e = 0; n < noOfNodes && e < noOfEdges;)
            {
                var nodeOrEdge =
                    Console.ReadLine()
                        .Split(separator, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToList();
                //Node only
                if (nodeOrEdge.Count == 1)
                {
                    graph.AddNode(nodeOrEdge.First());
                    n++;
                }
                //Edge without weight
                else if (nodeOrEdge.Count == 2)
                {
                    e++;

                    AddEdge(graph, nodeOrEdge[0], nodeOrEdge[1], DefaultEdgeWeight);
                }
                //edge with weight
                else
                {
                    e++;
                    AddEdge(graph, nodeOrEdge[0], nodeOrEdge[1], nodeOrEdge[2]);
                }
            }
            for (var n = 1; n <= noOfNodes; n++)
            {
                if (!graph.GetNodes().Contains(n))
                    graph.AddNode(n);
            }

            return graph;
        }

        public IEnumerable<AbstractGraph<int, int>> GetGraphs()
        {
            var noOfGraphs = int.Parse(Console.ReadLine());
            for (var i = 0; i < noOfGraphs; i++)
            {
                var graph = GetGraph();

                yield return graph;
            }
        }

        private void AddEdge(AbstractGraph<int, int> graph, int source, int dest, int weight)
        {
            var add = true;
            if (IgnoreDuplicateEdges)
            {
                if (graph.GetNodes().Contains(source))
                {
                    if (graph.GetNeighbours(source).Contains(dest)) add = false;
                }
            }
            if (add)
                graph.AddEdge(source, dest, weight);
        }
    }
}