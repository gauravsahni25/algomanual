using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using AlgoManual.Chapter5;
using NUnit.Framework;

namespace AlgoManual.Test.Chapter5
{
    [TestFixture]
    public class Tests
    {
        private List<Point> points;
        Graph graph = new Graph(5);
        [SetUp]
        public void Setup()
        {
            points = new List<Point>()
            {
                new Point(1,2),
                new Point(2,3),
                new Point(3,4),
                new Point(4,1),
                new Point(1,3)
            };
        }

        [Test]
        public void PrintGraph()
        {
            graph.ReadGraph(points, false);
            graph.NVertices = 5;
            graph.PrintGraph();
            Console.WriteLine("-- End of Test--");
        }

        [Test]
        public void WhenUndirected_For_12Edge_21Edge_IsAlsoPresent()
        {
            graph.ReadGraph(points, false);
            bool found = false;
            EdgeNode edge = graph.Edges[2];
            while (edge!=null && found == false)
            {
                if (edge.YValue == 1)
                {
                    found = true;
                }
                else
                    edge = edge.Next;
            }
            Assert.IsTrue(found);
        }

        [Test]
        public void WhenDirected_For_12Edge_21Edge_IsNotPresent()
        {
            graph.ReadGraph(points, true);
            bool found = false;
            EdgeNode edge = graph.Edges[2];
            while (edge != null && found == false)
            {
                if (edge.YValue == 1)
                {
                    found = true;
                }
                else
                    edge = edge.Next;
            }
            Assert.IsFalse(found);
        }

        [Test]
        public void WhenDirected_Total_NumberOfEdges_5()
        {
            graph.ReadGraph(points, true);
            
            Assert.IsTrue(graph.NEdges == 5);
        }

        [Test]
        public void WhenUnDirected_Total_NumberOfEdges_10()
        {
            graph.ReadGraph(points, false);

            Assert.IsTrue(graph.NEdges == 10);
        }

        [Test]
        public void Total_NumberOfVertices_Setup_Correcty()
        {
            graph.ReadGraph(points, false);

            Assert.IsTrue(graph.NVertices == 5);
        }

        [Test]
        public void MyLinkedList_TakesItems_Correctly()
        {
            MyLinkedList<int> linkedList = new MyLinkedList<int>();
            var data = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            foreach (var item in data)
            {
                linkedList.Add(item);
            }

            foreach (var item in linkedList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
