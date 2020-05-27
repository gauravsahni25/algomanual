using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoManual.Chapter3
{
    public static class BstBuilder
    {
        public static BinarySearchTree BuildBstFromArray(List<int> rawData)
        {
            BinarySearchTree tree = new BinarySearchTree(rawData[0]);

            for (int i = 1; i < rawData.Count; i++)
            {
                tree.InsertTree(tree, rawData[i]);
            }

            return tree;
        }
    }
}
