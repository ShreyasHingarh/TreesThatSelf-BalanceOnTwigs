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

        //For now this is ok, but it should not be recursive!!!!
        public int Height
        {
            get
            {
                return Math.Max(LeftChild?.Height ?? 0, RightChild?.Height ?? 0) + 1;
            }
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
                return (RightChild?.Height ?? 0) - (LeftChild?.Height ?? 0);
            }
        }

        public Node(T value)
        {
            Value = value;
        }

    }
    class AVLoserTree<T> where T : IComparable<T>
    {
        //Height, delete, traversals, contains, find
        public Node<T> Top;
        public int Count = 0;
        private Node<T> FindParent(Node<T> node)
        {
            if (Top == null || Top == node)
            {
                return null;
            }
            Node<T> temp = Top;
            for (int i = 0; i < Count; i++)
            {

                if (node.Value.CompareTo(temp.Value) <= 0)
                {
                    if (temp.LeftChild == node)
                    {
                        return temp;
                    }
                    temp = temp.LeftChild;
                }
                else
                {
                    if (temp.RightChild == node)
                    {
                        return temp;
                    }
                    temp = temp.RightChild;
                }
            }
            return null;
        }

        public Node<T> RotateRight(Node<T> root)
        {
            Node<T> newRoot = root.RightChild;
            root.RightChild = newRoot.LeftChild;
            newRoot.LeftChild = root;
            return newRoot;
        }
        public Node<T> RotateLeft(Node<T> root)
        {
            Node<T> newRoot = root.LeftChild;
            root.LeftChild = newRoot.RightChild;
            newRoot.RightChild = root;
            return newRoot;
        }
        private Node<T> Rebalance(Node<T> node)
        {

            if (node.Balance < -1)
            {
                node = RotateLeft(node);
            }
            else if (node.Balance > 1)
            {
                node = RotateRight(node);
            }
            else if(node.Balance == 2)
            {
                 RotateRight(node);
               
            }
            return node;
        }

        public void Insert(T value)
        {
            Top = Insert(value, Top);
        }

        private Node<T> Insert(T value, Node<T> node)
        {
            if (node == null)
            {
                Count++;

                return new Node<T>(value);
            }

            if (node.Value.CompareTo(value) > 0)
            {
                node.LeftChild = Insert(value, node.LeftChild);
            }
            else
            {
                node.RightChild = Insert(value, node.RightChild);
            }
            return Rebalance(node);
        }
    }
}
