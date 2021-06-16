using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoManual.Chapter4.Heaps
{
    public class FasterHeap : Heap
    {
        public FasterHeap(int[] source)
        {
            Queue = new int[source.Length + 1];
            
            HeapSize = source.Length;
            // Add all the elements in Heap
            for (int i = 0; i < source.Length; i++)
            {
                Queue[i + 1] = source[i];
            }

            // start from end and call BubbleDown
            for (int i = HeapSize; i >=1 ; i--)
            {
                BubbleDown(i);
            }
            ValidateHeap();
        }
    }
}
