using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AlgoManual.Chapter4;
using AlgoManual.Chapter5.Common;
using NUnit.Framework;

namespace AlgoManual.Test.Chapter4
{
    [TestFixture]
    public class SortingTests
    {
        [Test]
        public void InsertionSortTest()
        {
            InsertionSort sort = new InsertionSort();
            var result = sort.Sort(new int[] {6, 5, 4, 3, 2, 1});
            Console.WriteLine(Commons.ListPrinter("Insertion Sort", result.ToList()));
        }

        [Test]
        public void SelectionSortTest()
        {
            SelectionSort sort = new SelectionSort();
            var result = sort.Sort(new int[] { 6, 5, 4, 3, 2, 1 });
            Console.WriteLine(Commons.ListPrinter("Selection Sort", result.ToList()));
        }

        [Test]
        public void HeapSortTest()
        {
            HeapSort sort = new HeapSort();
            var result = sort.Sort(new int[] { 6, 5, 4, 3, 2, 1 });
            Console.WriteLine(Commons.ListPrinter("Heap Sort", result.ToList()));
        }
    }
}
