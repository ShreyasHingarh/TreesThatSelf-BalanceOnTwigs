using System;
using System.Collections.Generic;
using System.Text;

namespace Self_BalancingTrees
{
    public enum TypesOfChildren
    {
        Zero,
        Left,
        Right,
        Both
    }
    class Node<T> where T : IComparable<T>
    {
        public T Value { get; set; }
        public Node<T> LeftChild { get; set; }
        public Node<T> RightChild { get; set; }

       
        public TypesOfChildren TypeOfChild
        {
            get
            {
                if(LeftChild != null && RightChild != null)
                {
                    return TypesOfChildren.Both;
                }
                else if(LeftChild == null && RightChild != null)
                {
                    return TypesOfChildren.Right;
                }
                else if(LeftChild != null && RightChild == null)
                {
                    return TypesOfChildren.Left;
                }
                return TypesOfChildren.Zero;
            }
        }
      
        public int Height
        {
            get
            {
                return Math.Max(LeftChild?.Height ?? 0, RightChild?.Height ?? 0) + 1;
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
        // delete, traversals
        public Node<T> Top;
        public int Count = 0;
        public Node<T> RotateRight(Node<T> root)
        {
            if (root.RightChild.RightChild == null && root.Balance == 2)
            {
                root.RightChild = RotateLeft(root.RightChild);
            }
            Node<T> newRoot = root.RightChild;
            root.RightChild = newRoot.LeftChild;
            newRoot.LeftChild = root;
            return newRoot;
        }
        public Node<T> RotateLeft(Node<T> root)
        {
            if(root.LeftChild.LeftChild == null && root.Balance == -2)
            {
                root.LeftChild = RotateRight(root.LeftChild);
            }
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
            return node;
        }

       
        public void Delete(T value)
        {
            if (Count == 0)
            {
                return;
            }
            else if (Count == 1)
            {
                Top = null;
                Count--;
                return;
            }
            Delete(Top,value);
            
        }

        public Node<T> Delete(Node<T> current, T value)
        {
            if (value.CompareTo(current.Value) < 0)
            {
                Delete(current.LeftChild, value);
                Rebalance(current.LeftChild);
                return current;
            }
            else if(value.CompareTo(current.Value) > 0)
            {
                Delete(current.RightChild, value);
                Rebalance(current.RightChild);
                return current;
            }
            else
            {
                if(Top == current)
                {
                    Top = Remove(current);
                }
                else
                {
                    current = Remove(current);
                }
                Count--;
                return current;
            }

        }
        private Node<T> Remove(Node<T> NodeToDelete)
        {

            if (NodeToDelete.TypeOfChild == TypesOfChildren.Zero)
            {
                return null;
            }
            else if (NodeToDelete.TypeOfChild == TypesOfChildren.Left)
            {
                return NodeToDelete.LeftChild;
            }
            else if (NodeToDelete.TypeOfChild == TypesOfChildren.Right)
            {
                return NodeToDelete.RightChild;
            }
            Node<T> temp = NodeToDelete.LeftChild;
            while (temp.RightChild != null)
            {
                temp = temp.RightChild;
            }
            NodeToDelete.Value = temp.Value;
            NodeToDelete. = Remove(temp);
            return NodeToDelete;

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
        public bool Contains(T value)
        {
            return Find(value) != null;
        }
        public Node<T> Find(T value)
        {
            if (Count == 0) return null;
            if (Top.Value.Equals(value))
            {
                return Top;
            }             
            return FindNode(value,Top);
        }
        private  Node<T> FindNode(T value,Node<T> StartingNode)
        {
            if (StartingNode == null) return null;
            if (StartingNode.Value.Equals(value)) return StartingNode;
            if (value.CompareTo(StartingNode.Value) <= 0)
            {
                return FindNode(value, StartingNode.LeftChild);
            }
            else
            {
                return FindNode(value, StartingNode.RightChild);
            }
        }
    }
}
