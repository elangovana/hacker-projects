using System;
using System.Collections.Generic;
using System.Linq;
using AE.HackerRank.Samples.Lib;

namespace AE.HackerRank.Samples
{
    internal class CommandProblemShortestReach : IProblemCommand
    {
        private IGraphReader<int, int> _reader;
        private IShortestHops<int, int> _shortestReachAlgorithm;

        public IGraphReader<int, int> Reader
        {
            get { return _reader ?? (_reader = new ConsoleGraphReader(){ IgnoreDuplicateEdges = false}); }
            set { _reader = value; }
        }

        public IShortestHops<int, int> ShortestReachAlgorithm
        {
            get
            {
                return _shortestReachAlgorithm ?? (_shortestReachAlgorithm = new AlgorithmNearestHopsBfs<int, int>());
            }
            set { _shortestReachAlgorithm = value; }
        }

        public void Run()
        {
            var results = new List<List<int>>();
            foreach (var graph in Reader.GetGraphs())
            {
                var sourceNode = int.Parse(Console.ReadLine());
                var nodedistance = ShortestReachAlgorithm.FindShortestHops(graph, sourceNode);
                var distanceList = new List<int>();
                foreach (var node in graph.GetNodes().OrderBy(x => x))
                {
                    if (node == sourceNode) continue;

                    if (nodedistance.ContainsKey(node)) distanceList.Add(nodedistance[node]*Reader.DefaultEdgeWeight);
                    else
                    {
                        distanceList.Add(-1);
                    }
                }
                results.Add(distanceList);
            }
            Print(results);
        }

        private static void Print(List<List<int>> results)
        {
            foreach (var result in results)
            {
                Console.WriteLine(string.Join(" ", result));
            }
        }
    }
}