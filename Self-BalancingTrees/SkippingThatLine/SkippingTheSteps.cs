using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SkippingThatLine
{

    public class Node<T> where T : IComparable<T>
    {
        public T Value;
        public Node<T> Next;
        public Node<T> Down;
        public int Height;

        public Node(T value, int height)
        { 
            Value = value;
            Height = height;
        }
    }
    public class SkippingTheSteps<T> : ICollection<T>
        where T : IComparable<T>
    {
        Random generator = new Random();
        public Node<T> Head = new Node<T>(default, 0);

        
        public int Count { get; set; }

        public bool IsReadOnly => false;
        public void ConnectNodes()
        {
            
        }
        public void Add(T item)
        {
            int height = GetHeight();
            Node<T> start = Head;
            while (start.Height != height)
            {
                start = start.Down;
            }
            while (start.Height > -1)
            {
                while(start.Value.CompareTo(item) < 0 || start == Head)
                {
                    if (start.Next == null || start.Next.Value.CompareTo(item) > 0)
                    {
                        ConnectNodes();
                        break;
                    }
                    start = start.Next;
                }
                start.Height--;

            }
        }

        public void Clear()
        {
            Head = null;
            Head.Value = default;
            Head.Height = 0;
            Count = 0;
        }

        public int GetHeight()
        {
            int height = 0;
            int maxHeight = Head.Height + 1;
            int num = generator.Next(0, 2);
            while(num == 0)
            {
                if (height == maxHeight)
                {
                    Node<T> temp = Head.Down;
                    Head.Height = maxHeight;
                    Head.Down = new Node<T>(Head.Value,Head.Height--);
                    Head.Down.Down = temp;
                    break;
                }
                height++;
                num = generator.Next(0, 2);
            }
            return height;
        }
        public Node<T> Find(T value)
        {
            Node<T> startingPoint = Head;
            while(startingPoint != null)
            { 
                while(startingPoint != null)
                {
                    if (startingPoint.Next.Value.CompareTo(value) > 0)
                    {
                        break;
                    }
                    else if (startingPoint.Next.Value.Equals(value))
                    {
                        return startingPoint.Next;
                    }
                    
                    startingPoint = startingPoint.Next;
                }
                startingPoint = Head.Down;
            }
            return null;
        }
        public bool Contains(T item)
        {
            return Find(item) != null;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            T[] temp = new T[arrayIndex];
            Node<T> startingPoint = Head;
            while (startingPoint.Down != null)
            {
                startingPoint = startingPoint.Down;
            }
            for(int i = 0;i< temp.Length;i++)
            {  
                if(startingPoint.Next == null)
                {
                    break;
                }
                startingPoint = startingPoint.Next;
                temp[i] = startingPoint.Value;
            }
            array = temp;
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }
        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
       
    }
}
