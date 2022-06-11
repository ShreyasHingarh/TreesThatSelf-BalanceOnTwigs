using System;
using System.Collections.Generic;
using System.Text;

namespace DoubleLinkedListButBetter
{
    public class Node<T> where T : IComparable<T>
    {
        public T Value;
        public Node<T> Parent;
        public Node<T> Child;
        public Node(T value)
        {
            Value = value;
        }
    }
    class DoublyLinkedlyListButBetter<T> where T : IComparable<T>
    {
        Node<T> Head;
        Node<T> Tail;
        
        public void Insert()
        {
            Node<T> current = Head;

        }
        public void Delete()
        {

        }
    }
}
