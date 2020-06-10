using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AlgoManual.Chapter5.BreadthFirstSearch;
using AlgoManual.Test.Chapter5.GraphTestData;
using NUnit.Framework;

namespace AlgoManual.Test.Chapter5
{
    public class BreadthFirstSearchTests
    {
        [Test]
        public void BFSTraversal()
        {
            BreadthFirstSearch search = new BreadthFirstSearch(GraphMothers.Figure59Graph);
            search.PerformSearch(1);

            search.PrintSearchState();
            var sequenceEqual = search.Parent.SequenceEqual(new int[] {-1, -1, 1, 2, 5, 1, 1});
            Assert.IsTrue(sequenceEqual);
        }

        [Test]
        public void Shortest_Path_Test()
        {
            PathFinding search = new PathFinding(GraphMothers.Figure59Graph);
            var path = search.FindPathWith_PrintWithStrategyA(1, 4);
            var sequenceEqual = path.SequenceEqual(new List<int>() { 1, 5, 4 });
            Assert.IsTrue(sequenceEqual);
        }

        [Test]
        public void Correctly_Returns_ConnectedComponents()
        {
            ConnectedComponents search = new ConnectedComponents(GraphMothers.ZeroBasedHandDrawnOnPage167);
            var count = search.FindConnectedComponents();
            Assert.AreEqual(count, 2);
        }

        [Test]
        public void Fig59_Is_Not_Bipartite()
        {
            BipartitieTest biPartiteTest = new BipartitieTest(GraphMothers.Figure59Graph);
            biPartiteTest.RunTest();
            Assert.IsFalse(biPartiteTest.IsGraphBipartite);
        }

        [Test]
        public void Fig59_Minus25_Minus34_Is_Bipartite()
        {
            BipartitieTest biPartiteTest = new BipartitieTest(GraphMothers.Figure59GraphBipartitie);
            biPartiteTest.RunTest();
            Assert.IsTrue(biPartiteTest.IsGraphBipartite);
        }
    }
}
