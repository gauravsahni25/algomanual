using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using AlgoManual.Chapter5;
using AlgoManual.Chapter5.BreadthFirstSearch;
using NUnit.Framework;

namespace AlgoManual.Test.Chapter5
{
    public class BreadthFirstSearchTests
    {
        public Graph Graph;// Refer Fig 5.9
        public Graph GraphBiPartite;// Refer Fig 5.9

        public Graph ZeroBasedGraph; // Refer hand drawn image on 167

        [SetUp]
        public void Setup()
        {
            SetupGraph();
            SetupZeroBasedGraph();
        }

        [Test]
        public void BFSTraversal()
        {
            BreadthFirstSearch search = new BreadthFirstSearch(Graph);
            search.PerformSearch(1);
            var sequenceEqual = search.Parent.SequenceEqual(new int[] {-1, -1, 1, 2, 5, 1, 1});
            Assert.IsTrue(sequenceEqual);
        }

        [Test]
        public void Shortest_Path_Test()
        {
            PathFinding search = new PathFinding(Graph);
            var path = search.FindPathWith_PrintWithStrategyA(1, 4);
            var sequenceEqual = path.SequenceEqual(new List<int>() { 1, 5, 4 });
            Assert.IsTrue(sequenceEqual);
        }

        [Test]
        public void Correctly_Returns_ConnectedComponents()
        {
            ConnectedComponents search = new ConnectedComponents(ZeroBasedGraph);
            var count = search.FindConnectedComponents();
            Assert.AreEqual(count, 2);
        }

        [Test]
        public void Fig59_Is_Not_Bipartite()
        {
            BipartitieTest biPartiteTest = new BipartitieTest(Graph);
            biPartiteTest.RunTest();
            Assert.IsFalse(biPartiteTest.IsGraphBipartite);
        }
        [Test]
        public void Fig59_Minus25_Minus34_Is_Bipartite()
        {
            BipartitieTest biPartiteTest = new BipartitieTest(GraphBiPartite);
            biPartiteTest.RunTest();
            Assert.IsTrue(biPartiteTest.IsGraphBipartite);
        }

        private void SetupGraph()
        {
            List<Point> edges1 = new List<Point>()
            {
                new Point(1, 2),
                new Point(1, 5),
                new Point(1, 6),
                new Point(2, 3),
                new Point(3, 4),
                new Point(4, 5),
                new Point(2, 5),
            };
            Graph = new Graph(6 + 1); // We do MaxV+1 when we are using Index starting from 1 
            Graph.ReadGraph(edges1, false);

            List<Point> edges2 = new List<Point>()
            {
                new Point(1, 2),
                new Point(1, 5),
                new Point(1, 6),
                new Point(2, 3),
                new Point(4, 5),
            };
            GraphBiPartite = new Graph(6 + 1); // We do MaxV+1 when we are using Index starting from 1 
            GraphBiPartite.ReadGraph(edges2, false);
        }

        private void SetupZeroBasedGraph()
        {
            List<Point> edges = new List<Point>()
            {
                new Point(0, 1),
                new Point(1, 2),
                new Point(2, 0),
                new Point(3, 4),
                new Point(4, 5),
                new Point(5, 3),
            };
            ZeroBasedGraph = new Graph(6); // Here just MaxV, We do MaxV+1 when we are using Index starting from 1 
            ZeroBasedGraph.ReadGraph(edges, false);
        }
    }
}
