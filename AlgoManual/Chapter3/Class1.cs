using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoManual.Chapter3
{
    public class BinarySearchTree
    {
        public int Item { get; set; }
        public BinarySearchTree Left { get; set; }
        public BinarySearchTree Right { get; set; }

        public BinarySearchTree SearchTree(BinarySearchTree node, int x)
        {
            if (node == null)
                return null;

            if (node.Item == x)
                return node;

            if (x < node.Item)
                return SearchTree(node.Left, x);
            else
                return SearchTree(node.Right, x);
            
        }
    }
}
