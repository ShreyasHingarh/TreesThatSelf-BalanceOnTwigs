using System;
using System.Collections.Generic;
using System.Text;

namespace Self_BalancingTrees
{
    class Node<T> where T : IComparable<T>
    {
        public T Value { get; set; }
        public Node<T> LeftChild { get; set; }
        public Node<T> RightChild { get; set; }   
        public int Height(int amount)
        {
            int Amount = amount;
            if (ChildCount == 0)
            {
                return 1;
            }
            else if (RightChild == null && LeftChild != null)
            {
                LeftChild.Height(Amount + 1);
            }
            else if (RightChild != null && LeftChild == null)
            {
                RightChild.Height(Amount + 1);
            }
            else if (ChildCount == 2)
            {
                if(RightChild.Height(0) == LeftChild.Height(0) + 1)
                {
                    RightChild.Height(Amount + 1);
                }
                if (RightChild.Height(0) + 1 == LeftChild.Height(0))
                {
                    LeftChild.Height(Amount + 1);
                }
            }
            return Amount + 1;
        }
        public int ChildCount 
        {
            get
            {
                if (LeftChild != null && RightChild != null)
                {
                    return 2;
                }
                else if (LeftChild != null && RightChild == null || LeftChild == null && RightChild != null)
                {
                    return 1;
                }
                return 0;
            }
        }
        public int Balance 
        {
            get
            {
                if (ChildCount == 0)
                {
                    return 0;
                }
                else if (LeftChild != null && RightChild == null)
                {
                    return LeftChild.Height(0);
                }
                else if (RightChild != null && LeftChild == null)
                {
                    return RightChild.Height(0);
                }
                return RightChild.Height(0) - LeftChild.Height(0);
            }
        }

        public Node(T value)
        {
            Value = value;
        }

    }
    class AVLoserTree<T> where T : IComparable<T>
    {
        //Height, rotations, double rotations, delete, traversals, contains, find
        public Node<T> Top;
        public int Count = 0;
        public void Balance(Node<T> NodeAt)
        {
            
        }
        public void Insert(T value)
        {
            if (Count == 0)
            {
                Top = new Node<T>(value);
                Count++;
                return;
            }
            var result = Insert(value, Top);
            
        }
        private Node<T> Insert(T value,Node<T> nodeAt)
        {
            
            if (value.CompareTo(nodeAt.Value) <= 0)
            {
                if(nodeAt.LeftChild == null)
                {
                    nodeAt.LeftChild = new Node<T>(value);
                    Count++;
                    return nodeAt;
                }
                return Insert(value, nodeAt.LeftChild);
            }
            else
            {
                if (nodeAt.RightChild == null)
                {
                    nodeAt.RightChild = new Node<T>(value);
                    Count++;
                    return nodeAt;
                }
                return Insert(value, nodeAt.RightChild);
            }
        }

       
    }
}
