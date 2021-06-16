using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AlgoManual.Chapter4.Heaps;
using NUnit.Framework;

namespace AlgoManual.Test.Chapter4
{
    [TestFixture]
    public class HeapTests
    {
        [Test]
        public void CreateHeap()
        {
            Heap heap = new Heap(new int[]{ 6, 5, 4, 3, 2, 1 });
            heap.Queue.ToList().ForEach(Console.WriteLine);
            Console.WriteLine($"Heap Size: {heap.HeapSize}");
        }

        [Test]
        public void CreateFastHeap()
        {
            FasterHeap heap = new FasterHeap(new int[] { 6, 5, 4, 3, 2, 1 });
            heap.Queue.ToList().ForEach(Console.WriteLine);
            Console.WriteLine($"Heap Size: {heap.HeapSize}");
        }
    }
}
