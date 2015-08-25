using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AE.HackerRank.Samples.Lib;
using NUnit;
using NUnit.Framework;

namespace AE.HackerRank.Samples.Tests
{
    [TestFixture]
   public class LoadTestNearestNodes
    {
       // [TestCase( 1000, 1000*999/2, 1*1000 )]
         [TestCase(1000, 1000 * 999 / 2, 1)]
        // [TestCase(1001, 1001 * 1000 / 2, 1)]
        public void ShouldGetNearestNodes(int noOfNodes, int maxNoOfEdges,
         int  timeInMilliSeconds)
        {
            //Arrange
            
            var graph = GetGraph(noOfNodes, maxNoOfEdges);
            var sourceNode = 1;
          
     
            var startTime = DateTime.UtcNow;
            IShortestHops<int, int> sut = new AlgorithmNearestHopsBfs<int, int>();

            //Act
            sut.FindShortestHops(graph, sourceNode);
            var endTime = DateTime.UtcNow;


            //Assert
            Assert.LessOrEqual(endTime.Subtract(startTime).TotalMilliseconds, timeInMilliSeconds);
           
        }

        private UndirectedGraph<int,int> GetGraph(int noOfNodes, int maxNoOfEdges)
        {
            var startTime = DateTime.UtcNow;
            var graph = new UndirectedGraph<int, int>();
            var e = 0;
            for (int n = 1; n <= noOfNodes && e<= maxNoOfEdges; n++)
            {
                for (int i = n + 1; i <= noOfNodes && e <= maxNoOfEdges; i++, e++)
                {
                    graph.AddEdge(n, i, 1);
                }
               
            }

          
            var endTime = DateTime.UtcNow;
            System.Diagnostics.Trace.WriteLine(String.Format("Completed graph construction in {0}",endTime. Subtract(startTime).TotalMilliseconds));
            return graph;
        }
    }
}
