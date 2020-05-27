using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace AlgoManual.Chapter3
{
    public class BinarySearchTree
    {
        public BinarySearchTree(int rootValue)
        {
            Item = rootValue;
        }
        public BinarySearchTree(int item, BinarySearchTree left, BinarySearchTree right, BinarySearchTree parent)
        {
            Item = item;
            Left = left;
            Right = right;
            Parent = parent;
        }
        public int Item { get; set; }
        public BinarySearchTree Parent { get; set; }
        public BinarySearchTree Left { get; set; }
        public BinarySearchTree Right { get; set; }

        //P78
        public BinarySearchTree SearchTree(BinarySearchTree tree, int x)
        {
            if (tree == null)
                return null;

            if (tree.Item == x)
                return tree;

            if (x < tree.Item)
                return SearchTree(tree.Left, x);
            else
                return SearchTree(tree.Right, x);
        }

        //P79
        public BinarySearchTree FindMinimum(BinarySearchTree tree)
        {
            BinarySearchTree minimum;
            if (tree == null)
                return null;

            minimum = tree;
            while (minimum.Left != null)
            {
                minimum = minimum.Left;
            }
            return minimum;
        }

        public void InOrderTraversal(BinarySearchTree tree)
        {
            // LPR
            if (tree != null)
            {
                InOrderTraversal(tree.Left);
                ProcessItem(tree.Item);
                InOrderTraversal(tree.Right);
            }
        }

        public void PreOrderTraversal(BinarySearchTree tree)
        {
            //PLR
            if (tree != null)
            {
                ProcessItem(tree.Item);

                PreOrderTraversal(tree.Left);
                PreOrderTraversal(tree.Right);
            }
        }

        public void PostOrderTraversal(BinarySearchTree tree)
        {
            //LRP
            if (tree != null)
            {
                PostOrderTraversal(tree.Left);
                PostOrderTraversal(tree.Right);

                ProcessItem(tree.Item);
            }
        }

        public void ProcessItem(int item)
        {
            Debug.WriteLine(item);
            Console.WriteLine(item);
        }

        //P80
        public void InsertTree(BinarySearchTree tree, int item)
        {
            // logic had to be switched for c#
            if (item <= tree.Item)
            {
                if (tree.Left != null)
                {
                    InsertTree(tree.Left, item);
                }
                else
                {
                    BinarySearchTree p = new BinarySearchTree(item, null, null, tree.Left);

                    tree.Left = p;
                }
            }
            if (item > tree.Item)
            {
                if (tree.Right != null)
                {
                    InsertTree(tree.Right, item);
                }
                else
                {
                    BinarySearchTree p = new BinarySearchTree(item, null, null, tree.Right);

                    tree.Right = p;
                }
            }
        }
    }
}
