using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoManual.Chapter4
{
    public abstract class SortAbstract
    {
        /// <summary>
        /// target starts from 0
        /// </summary>
        /// <param name="target"></param>
        public abstract int[] Sort(int[] target);

        public void Swap(int[] target, int x, int y)
        {
            int temp = target[x];
            target[x] = target[y];
            target[y] = temp;
        }
    }
    
    public class InsertionSort : SortAbstract
    {
        public override int[] Sort(int[] target)
        {
            // First element is sorted by itself, so lets start from 1
            for (int i = 1; i < target.Length; i++)
            {
                int j = i;
                while ((j > 0) && target[j] < target[j - 1])
                {
                    Swap(target, j, j-1);

                    j--;
                }
            }

            return target;
        }
    }
}
