using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoManual.Chapter6.MinimumSpanningTree
{
    class UnionFind
    {
    }

    public class SetUnion
    {
        public int[] Parent { get; set; }
        public int[] Size { get; set; }
        public int NumberOfElements { get; set; }
        
        
        public SetUnion(int n) // set_union_init (p-200)
        {
            Parent = new int[n];
            Size = new int[n];

            for (int i = 0; i < n; i++)
            {
                Parent[i] = i;
                Size[i] = 1;
            }

            NumberOfElements = n;
        }

        public int Find(int x)
        {
            if (Parent[x] == x)
            {
                return x;
            }

            return Find(Parent[x]);
        }

        public void UnionSets(int s1, int s2)
        {
            var root1 = Find(s1);
            var root2 = Find(s2);

            if (root1 == root2)
            {
                return; // nothing to union, already same connected component
            }

            if (Size[root1] > Size[root2])
            {
                Size[root1] = Size[root1] + Size[root2];
                Parent[root2] = root1;
            }
            else
            {
                Size[root2] = Size[root1] + Size[root2];
                Parent[root1] = root2;
            }
        }

        public bool IsSameComponent(int s1, int s2) => Find(s1) == Find(s2);
    }
}
