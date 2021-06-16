using System;
using System.Collections.Generic;
using System.Text;
using AlgoManual.Chapter4.Heaps;

namespace AlgoManual.Chapter4
{
    public class HeapSort : SortAbstract
    {
        public override int[] Sort(int[] target)
        {
            int[] sortedArray = new int[target.Length];
            
            Heap heap= new Heap(target);
            for (int counterToExtract = 0; counterToExtract < target.Length; counterToExtract++)
            {
                sortedArray[counterToExtract] = heap.Extract_Minimum();
            }

            return sortedArray;
        }
    }
}
