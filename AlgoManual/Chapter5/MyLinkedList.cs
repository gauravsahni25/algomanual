using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace AlgoManual.Chapter5
{
    [DebuggerDisplay("Value:{ItemValue}, Next:{Next.ItemValue}, Previous: {Previous.ItemValue}")]
    public class MyListNode<T>
    {
        public MyListNode(T item, MyListNode<T> next, MyListNode<T> previous)
        {
            ItemValue = item;
            Next = next;
            Previous = previous;
        }

        public T ItemValue { get; set; }
        public MyListNode<T> Next { get; set; }
        public MyListNode<T> Previous { get; set; }

    }

    [DebuggerDisplay("Count: {Count}, Head:{Head.ItemValue}, Tail:{Tail.ItemValue}")]
    public class MyLinkedList<T> : IEnumerable<T>
    {
        public int Count { get; private set; } = 0;
        public MyListNode<T> Head { get; private set; }
        public MyListNode<T> Tail { get; private set; }
        public void Add(T item)

        {
            if (item != null)
            {
                if (Count == 0)
                {
                    MyListNode<T> newNode = new MyListNode<T>(item, null, null);
                    Head = newNode;
                    Tail = newNode;
                }
                else
                {
                    // always add to front O(1)
                    
                    MyListNode<T> newNode = new MyListNode<T>(item, Head, null);
                    Head.Previous = newNode;

                    Head = newNode;
                }
                Count++;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            MyListNode<T> node = Head;
            while (node!=null)
            {
                yield return node.ItemValue;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
