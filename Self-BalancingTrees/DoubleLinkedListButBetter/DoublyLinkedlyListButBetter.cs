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

    public class DoublyLinkedlyListButBetter<T> where T : IComparable<T>
    {
        Node<T> Head = new Node<T>(default);
        public void ConnectNodes(Node<T> previous, T value,Node<T> next)
        {
            previous.Child = new Node<T>(value);
            previous.Child.Parent = previous;
            previous.Child.Child = next;
            if (next != null) { next.Parent = previous.Child; }
        }
        public void Insert(T value)
        {
            Node<T> current = Head;
            while (current.Value.CompareTo(value) < 0 || current == Head)
            {
                if (current.Child == null || current.Child.Value.CompareTo(value) > 0)
                {
                    ConnectNodes(current, value, current.Child);
                    return;
                }
                current = current.Child;
            }
        }
        public void Print()
        {
            Node<T> node = Head.Child;
            while(node != null)
            {
                Console.WriteLine(node.Value);
                node = node.Child;
            }
        }
        public void Delete(T value)
        {
            
        }
        public void RemoveLinks(Node<T> node)
        {

        }
    }
}
