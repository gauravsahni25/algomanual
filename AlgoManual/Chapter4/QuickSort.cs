using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace AlgoManual.Chapter4
{
    public class QuickSort
    {
        public int[] Target { get; set; }

        public QuickSort(int[] target)
        {
            this.Target = target;
        }

        public void Sort(int low, int high)
        {
            if ((high - low) > 0)
            {
                int partition = Partition(low, high);
                Sort(low, partition-1);
                Sort(partition+1, high);
            }
        }

        private int Partition(in int low, in int high)
        {
            int firstHigh = low;
            int pivot = high;

            for (int i = low; i < high; i++)
            {
                if (Target[i] < Target[pivot])
                {
                    Swap(i, firstHigh);
                    firstHigh++;
                }
            }
            Swap(pivot, firstHigh);
            return firstHigh;
        }

        private void Swap(in int x, in int y)
        {
            int temp = Target[x];
            Target[x] = Target[y];
            Target[y] = temp;
        }
    }
}
