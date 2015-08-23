using System;
using System.Collections.Generic;
using System.Linq;
using AE.HackerRank.Samples.Lib;
using NUnit.Framework;

namespace AE.HackerRank.Samples.Tests
{
    [TestFixture]
    public class UnitTestUndirectedGraph
    {
        private readonly char[] nodeSeparator = {',', ' '};

        [TestCase("A")]
        [TestCase("A, B")]
        public void ShouldAddNodes(string inodes)
        {
            //Arrange
            var expectedNodes =
                inodes.Split(nodeSeparator, StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .OrderBy(x => x)
                    .ToList();
            AbstractGraph<char, int> sut = new UndirectedGraph<char, int>();

            //Act
            expectedNodes.ForEach(x => sut.AddNode(x));
            var actual = sut.GetNodes().OrderBy(x => x);

            //Assert
            Assert.AreEqual(expectedNodes, actual);
        }

        [TestCase("AB6", 'A', "B")]
        [TestCase("AB6", 'B', "A")]
        [TestCase("AB6, BC5", 'A', "B")]
        [TestCase("AB6, BC5, BD6", 'B', "C, D, A")]
        public void ShouldAddEdgeGivenSourceDestinationNodeAndEdgeWeight(string iedges, char isourceNode,
            string iexpectedNeighbourNodes)
        {
            //Arrange
            var expectedNeighbourNodes =
                iexpectedNeighbourNodes.Split(nodeSeparator, StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .OrderBy(x => x);
            var edges =
                ParseEdges(iedges).OrderBy(x => x.SourceNode).ThenBy(x => x.DestinationNode).ThenBy(x => x.Weight);
            var sut = new UndirectedGraph<char, int>();

            //Act
            foreach (var edge in edges)
            {
                sut.AddEdge(edge.SourceNode, edge.DestinationNode, edge.Weight);
            }

            var actual = sut.GetNeighbours(isourceNode).OrderBy(x => x);

            //Assert
            Assert.AreEqual(expectedNeighbourNodes, actual);
        }

        [TestCase("AB6", "A,B")]
        [TestCase("AB6, BC5", "A,B, C")]
        public void ShouldAutomaticallyAddNodesWhenAddingEdges(string iedges, string iexpectedNodes)
        {
            //Arrange
            var edges =
                ParseEdges(iedges).OrderBy(x => x.SourceNode).ThenBy(x => x.DestinationNode).ThenBy(x => x.Weight);
            var sut = new UndirectedGraph<char, int>();
            var expectedNodes =
                iexpectedNodes.Split(nodeSeparator, StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .OrderBy(x => x);

            //Act
            foreach (var edge in edges)
            {
                sut.AddEdge(edge.SourceNode, edge.DestinationNode, edge.Weight);
            }
            var actual = sut.GetNodes().OrderBy(x => x);

            //Assert
            Assert.AreEqual(expectedNodes, actual.Select(x => x));
        }

        private IEnumerable<Edge<char, int>> ParseEdges(string iedges)
        {
            var result = new List<Edge<char, int>>();
            var strEdges = iedges.Split(nodeSeparator, StringSplitOptions.RemoveEmptyEntries).ToList();
            foreach (var strEdge in strEdges)
            {
                var edge = new Edge<char, int>();
                edge.SourceNode = char.Parse(strEdge.Substring(0, 1));
                edge.DestinationNode = char.Parse(strEdge.Substring(1, 1));
                edge.Weight = int.Parse(strEdge.Substring(2));

                result.Add(edge);
            }

            return result;
        }
    }
}