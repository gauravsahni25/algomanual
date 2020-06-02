using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using AlgoManual.Chapter5;
using NUnit.Framework;

namespace AlgoManual.Test.Chapter5
{
    public class BFSTests
    {
        public Graph graph { get; set; }
        [SetUp]
        public void Setup()
        {
            List<Point> edges = new List<Point>()
            {
                new Point(1, 2),
                new Point(1, 5),
                new Point(1, 6),
                new Point(2, 3),
                new Point(3, 4),
                new Point(4, 5),
                new Point(2, 5),
            };
            graph = new Graph(6 + 1); // We do MaxV+1 when we are using Index starting from 1 
            graph.ReadGraph(edges, false );
        }

        [Test]
        public void BFSTraversal()
        {
            BreadthFirstSearch search = new BreadthFirstSearch(graph);
            search.PerformSearch(1);
            var sequenceEqual = search.Parent.SequenceEqual(new int[] {-1, -1, 1, 2, 5, 1, 1});
            Assert.IsTrue(sequenceEqual);
        }

        [Test]
        public void Shortest_Path_Test()
        {
            BreadthFirstSearch search = new BreadthFirstSearch(graph);
            var path = search.FindPathWith_PrintWithStrategyA(1, 4);
            var sequenceEqual = path.SequenceEqual(new List<int>() { 1, 5, 4 });
            Assert.IsTrue(sequenceEqual);
        }
    }
}
