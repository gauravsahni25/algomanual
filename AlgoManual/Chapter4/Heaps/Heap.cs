using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoManual.Chapter4.Heaps
{
    public class Heap
    {
        public int[] Queue { set; get; }
        public int HeapSize { get; set; }

        protected Heap()
        {
        }
        public Heap(int lengthOfSource)
        {
            HeapSize = 0;
            Queue = new int[lengthOfSource + 1];
        }
        public Heap(int[] source)
        {
            HeapSize = 0;
            Queue = new int[source.Length + 1];
            for (int i = 0; i < source.Length; i++)
            {
                HeapInsert(source[i]);
            }
            ValidateHeap();
        }

        public int Extract_Minimum()
        {
            if (HeapSize <= 0)
            {
                throw new Exception("Warning: Empty Priority Queue");
            }
            
            int min = Queue[1];
            Queue[1] = Queue[HeapSize];
            HeapSize--;
            
            BubbleDown(1);
            return min;
        }

        protected void BubbleDown(int index)
        {
            int childIndex = HeapYoungChild(index);
            int minIndex = index;
            
            for (int i = 0; i < 2; i++)
            {
                if ((childIndex + i) <= HeapSize)
                {
                    if (Queue[minIndex] > Queue[childIndex + i])
                    {
                        minIndex = childIndex + i;
                    }
                }    
            }

            if (minIndex!= index)
            {
                Swap(index, minIndex);
                BubbleDown(minIndex);
            }
        }

        public int HeapParent(int n) // => n==1 ? -1 : n/2;
        {
            if (n==1)
            {
                // notice we are not returning 0
                return -1;
            }

            return n / 2;
        }

        public int HeapYoungChild(int n) => 2 * n;

        public void HeapInsert(int x)
        {
            if (HeapSize >= Queue.Length)
            {
                throw new Exception($"Warning: Queue Overflow while inserting {x}");
            }

            HeapSize = HeapSize + 1;
            Queue[HeapSize] = x;
            BubbleUp(HeapSize);
        }

        /// <param name="index">This is the index to be bubbled | Used in Insertion</param>
        protected void BubbleUp(int index)
        {
            if (HeapParent(index) == -1)
            {
                return;
            }
            
            if(Queue[HeapParent(index)] > Queue[index])
            {
                Swap(index, HeapParent(index));
                BubbleUp(HeapParent(index));
            }
        }

        protected void Swap(in int index, in int heapParentOrChild)
        {
            int temp = Queue[index];
            Queue[index] = Queue[heapParentOrChild];
            Queue[heapParentOrChild] = temp;
        }

        public void ValidateHeap()
        {
            for (int i = 1; i < Queue.Length; i++)
            {
                if (!TestHeapProperty(i))
                {
                    throw new Exception($"Invalid Heap Property at {i}");
                }
            }
        }

        protected bool TestHeapProperty(in int i)
        {
            int child = HeapYoungChild(i);
            int minIndex = i;
            for (int j = 0; j < 2; j++)
            {
                if ((child+i)<HeapSize)
                {
                    if (Queue[minIndex] > Queue[(child+i)])
                    {
                        minIndex = child + i;
                    }
                }
            }

            return minIndex == i;
        }
    }
}
