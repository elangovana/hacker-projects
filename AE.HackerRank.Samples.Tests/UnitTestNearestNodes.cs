using System;
using System.Collections.Generic;
using System.Linq;
using AE.HackerRank.Samples.Lib;
using NUnit.Framework;

namespace AE.HackerRank.Samples.Tests
{
    [TestFixture]
    public class UnitTestNearestNodes
    {
        private readonly char[] _nodeSeparator = {'-'};
        private readonly char[] _resultSeparater = {' '};
        private readonly char[] _nodeDistanceSeparator = {'-'};
        private readonly char[] _edgeSeparator = {','};

        [TestCase("1", 6, 1, "0")]
        [TestCase("1-2", 6, 1, "0 1")]
        [TestCase("1-2, 1-3, 3-2", 6, 1, "0 1 1")]
        [TestCase("1-2,1-3", 6, 1, "0 1 1")]
        [TestCase("1-1", 6, 1, "0")]
        [TestCase("10-6,3-1,10-1,10-1,3-1,1-8,5-2", 6, 3, "1 0 3 2 2")]

        [TestCase("1-2, 2-3, 2-4, 4-5,3-6 ",3,1, "0 1 2 2 3 3" )]
        [TestCase("1-2,1-3,1-4,2-5,3-7,2-6,2-7,7-8,4-8 ", 3, 1, "0 1 1 1 2 2 2 2")]
        public void ShouldGetNearestNodes(string igraph, int edgeWeight, int sourceNode,
            string iexpectedShortestDistances)
        {
            //Arrange
            var mockGraph = GetMockGraph(igraph, edgeWeight);
            var expectedShortestDistances = ParseResult(iexpectedShortestDistances);
            IShortestHops<int, int> sut = new AlgorithmNearestHopsBfs<int, int>();

            //Act
            var actual = sut.FindShortestHops(mockGraph, sourceNode).OrderBy(x => x.Key).Select(x=>x.Value).ToArray();
           

            //Assert
            Assert.AreEqual(expectedShortestDistances, actual);
        }

        private int[] ParseResult(string iexpectedShortestDistances)
        {
           
            var nodeAndDistances = iexpectedShortestDistances.Split(_resultSeparater,
                StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
           
            return nodeAndDistances;
        }

        private AbstractGraph<int, int> GetMockGraph(string igraph, int edgeWeight)
        {
            var edges = igraph.Split(_edgeSeparator, StringSplitOptions.RemoveEmptyEntries);
            var graph = new UndirectedGraph<int, int>();
            foreach (var edge in edges)
            {
                var nodesConnectingEdge =
                    edge.Split(_nodeSeparator, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
                if (nodesConnectingEdge.Count == 1)
                {
                    graph.AddNode(nodesConnectingEdge.Single());
                }
                else
                {
                    graph.AddEdge(nodesConnectingEdge.First(), nodesConnectingEdge.Last(), edgeWeight);
                }
            }

            return graph;
            //var mockGraph = MockRepository.GenerateStub<AbstractGraph<int, int>>();

            //var nodes = new List<int>();
            //foreach (var edge in edges)
            //{
            //    var nodesConnectingEdge = edge.Split(nodeSeparator).Select(int.Parse).ToList();
            //    if (nodes.Contains(nodesConnectingEdge.First()))
            //    {
            //        nodes.Add(nodesConnectingEdge.First());
            //    }
            //    if (nodes.Contains(nodesConnectingEdge.Last()))
            //    {
            //        nodes.Add(nodesConnectingEdge.Last());
            //    }
            //}
            //mockGraph.Stub(x => x.GetNodes()).Return(nodes);
            ////      mockGraph.Stub(x=>x.GetNeighbours(1)).IgnoreArguments().Do()
            //return mockGraph;
        }
    }
}