using System.Collections.Generic;
using AlgoManual.Chapter3;
using NUnit.Framework;

namespace AlgoManual.Test.Chapter3
{
    public class Chapter3Tests
    {
        [Test]
        public void BstBuilder_BuildsCorrectly()
        {
            var tree = BstBuilder.BuildBstFromArray(new List<int>() {50, 34, 73, 72, 72, 81});
            tree.InOrderTraversal(tree);
        }
    }
}