using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoManual.Chapter4
{
    public class MergeSort
    {
        public int[] Target { get; set; }

        public MergeSort(int[] target)
        {
            this.Target = target;
        }

        public void Sort(int low, int high)
        {
            if (low < high)
            {
                int middle = (low + high) / 2;
                Sort(low, middle);
                Sort(middle + 1, high);
                Merge(low, middle, high);
            }
        }

        private void Merge(in int low, in int middle, in int high)
        {
            Queue<int> buffer1 = new Queue<int>();
            Queue<int> buffer2 =  new Queue<int>();
            for (int i = low; i <= middle; i++)
            {
                buffer1.Enqueue(Target[i]);
            }

            for (int i = middle+1; i <= high; i++)
            {
                buffer2.Enqueue(Target[i]);
            }

            int counter = low;
            while (buffer1.Count >0 && buffer2.Count > 0)
            {
                if (buffer1.Peek() <= buffer2.Peek())
                {
                    Target[counter++] = buffer1.Dequeue();
                }
                Target[counter++] = buffer2.Dequeue();
            }

            while (buffer1.Count > 0) Target[counter++] = buffer1.Dequeue();
            while (buffer2.Count > 0) Target[counter++] = buffer2.Dequeue();
        }
    }
}
