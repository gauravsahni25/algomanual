using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace AlgoManual.Chapter4
{
    public class QuickSortEasy
    {
        public int[] Target { get; set; }

        public QuickSortEasy(int[] target)
        {
            Target = target;
        }

        public void Sort(int low, int high)
        {
            if (high-low > 0)
            {
                int partition = Partition(low, high);
                Sort(low, partition - 1);
                Sort(partition + 1, high); 
            }
        }

        // Set Pivot as high
        // Compare each element with Pivot, if larger, move element to right and Pivot to left
        // Done!
        private int Partition(in int low, in int high)
        {
            int pivot = high;
            
            for (int i = low; i < high; i++)
            {
                if (Target[i] > Target[pivot])
                {
                    Swap(i, pivot);
                    pivot--;
                }
            }

            return pivot;
        }
        private void Swap(in int x, in int y)
        {
            int temp = Target[x];
            Target[x] = Target[y];
            Target[y] = temp;
        }
    }
}
