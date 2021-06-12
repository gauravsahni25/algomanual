using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoManual.Chapter4
{
    public class SelectionSort : SortAbstract
    {
        public override int[] Sort(int[] target)
        {
            for (int i = 0; i < target.Length-1; i++)
            {
                int min = i;
                for (int j = i; j < target.Length; j++)
                {
                    if (target[j]< target[min])
                    {
                        min = j;
                    }
                }
                Swap(target, i, min);
            }

            return target;
        }
    }
}
