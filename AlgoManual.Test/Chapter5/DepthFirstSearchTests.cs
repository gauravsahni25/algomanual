using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AlgoManual.Chapter5.DepthFirstSearch;
using AlgoManual.Test.Chapter5.GraphTestData;
using NUnit.Framework;

namespace AlgoManual.Test.Chapter5
{
    [TestFixture]
    public class DepthFirstSearchTests
    {
        [Test]
        public void DFSTraversal()
        {
            DepthFirstSearch search = new DepthFirstSearch(GraphMothers.Figure59Graph);
            search.DepthFirstSearchOperation(1);

            search.PrintSearchState();
            var sequenceEqual = search.Parent.SequenceEqual(new int[] { -1, -1, 1, 2, 3, 4, 1 });
            Assert.IsTrue(sequenceEqual);
        }
        [Test]
        public void FindingCycles_Test()
        {
            GraphMothers.Fig511Graph.PrintGraphBetter();
            FindingCycles cycleFinder = new FindingCycles(GraphMothers.Fig511Graph, true);
            cycleFinder.DepthFirstSearchOperation(1);
            Assert.IsTrue(cycleFinder.Cycles.Count == 4);
        }

    }
}
