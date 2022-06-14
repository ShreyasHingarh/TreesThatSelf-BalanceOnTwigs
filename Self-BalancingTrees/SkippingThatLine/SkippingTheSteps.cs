using System;
using System.Collections;
using System.Collections.Generic;

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
        public void ConnectNodes(Node<T> node,Node<T> newNode)
        {
            Node<T> temp = node.Next;
            node.Next = newNode;
            node.Next.Next = temp;            
        }
        public Node<T> GenerateNewNodes(T value, int Height)
        {
            Node<T> newnode = new Node<T>(value, Height);
            Node<T> temp = newnode;
            for(int i = Height - 1;i > -1;i--)
            {
                temp.Down = new Node<T>(value, i);
                temp = temp.Down;
            }
            return newnode;
        }

        public void Add(T item)
        {
            int height = GetHeight();
            Node<T> start = Head;
            while (start.Height != height)
            {
                start = start.Down;
            }
            Node<T> newNode = GenerateNewNodes(item, height);
            
            while (start != null)
            {
                Node<T> temp = start;
                while (temp.Value.CompareTo(item) <= 0)
                {
                    if (temp.Next == null || temp.Next.Value.CompareTo(item) >= 0)
                    {
                        ConnectNodes(temp, newNode);
                        break;
                    }
                    temp = temp.Next;
                }
                start = start.Down;
                newNode = newNode.Down;
            }
            Count++;
        }

        public void Clear()
        {
            Head = null;
            Head = new Node<T>(default, 0);
            Count = 0;
        }

        public int GetHeight()
        {
            int height = 0;
            int maxHeight = Head.Height + 1;
            int num = generator.Next(0, 2);
            while(num == 0)
            {
                height++;
                if (height == maxHeight)
                {
                    Node<T> newHead = new Node<T>(Head.Value,maxHeight);
                    newHead.Down = Head;
                    Head = newHead;
                    break;
                }
                
                num = generator.Next(0, 2);
            }
            return height;
        }
        public Node<T> Find(T value)
        {
            Node<T> startingPoint = Head;
            Node<T> temp;
            while(startingPoint != null)
            {
                temp = startingPoint;
                while(temp != null && temp.Value.CompareTo(value) <= 0)
                {
                    if(temp.Value.Equals(value))
                    {
                        return temp;
                    }
                    
                    temp = temp.Next;                  
                }
                startingPoint = startingPoint.Down;
            }
            return null;
        }
        public bool Contains(T item)
        {
            return Find(item) != null;
        }

        //fix
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
        public void DisconnectNodes(Node<T> previous,Node<T> oneToDelete)
        {

        }
        public bool Remove(T item)
        {
            Node<T> StartingNode = Head;
            Node<T> NodeToDelete = Find(item);
            if(NodeToDelete == null)
            {
                return false;
            }
            while (StartingNode.Height != NodeToDelete.Height)
            {
                StartingNode = StartingNode.Down;
            }
            
            while (StartingNode != null)
            {
                Node<T> temp = StartingNode;
                while (temp.Value.CompareTo(item) <= 0)
                {
                    if(temp.Next == NodeToDelete)
                    {
                        DisconnectNodes(temp,NodeToDelete);
                        break;
                    }
                    temp = temp.Next;
                }
                StartingNode = StartingNode.Down;
                NodeToDelete = NodeToDelete.Down;
            }
            return true;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
       
    }
}
