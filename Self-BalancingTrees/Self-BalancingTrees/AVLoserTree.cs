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
        public Node<T> RotateLeft(Node<T> root)
        {
            if (root.Balance == 2 && root.RightChild.Balance < 0)
            {
                root.RightChild = RotateRight(root.RightChild);
            }
            Node<T> newRoot = root.RightChild;
            root.RightChild = newRoot.LeftChild;
            newRoot.LeftChild = root;
            return newRoot;
        }
        public Node<T> RotateRight(Node<T> root)
        {
            if(root.Balance == -2 && root.LeftChild.Balance > 0)
            {
                root.LeftChild = RotateLeft(root.LeftChild);
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
                node = RotateRight(node);
            }
            else if (node.Balance > 1)
            {  
                node = RotateLeft(node);
            }
            return node;
        }

       
        public void Delete(T value)
        {
            if (Count == 0 || Find(value) == null)
            {
                return;
            }
            else if (Count == 1)
            {
                Top = null;
                Count--;
                return;
            }
            
            if (Top.Value.Equals(value))
            {
                Top = Remove(Top);
                Top = Rebalance(Top);
                Count--;
            }
            else {Top = Delete(Top, value); }
            
        }

        public Node<T> Delete(Node<T> current, T value)
        {
            
            if (value.CompareTo(current.Value) < 0)
            {
                if(current.LeftChild.Value.Equals(value))
                {
                    current.LeftChild = Remove(current.LeftChild);
                    Count--;
                }
                else
                {
                    Delete(current.LeftChild, value);
                }
                return Rebalance(current);
            }
            else
            {
                if(current.RightChild.Value.Equals(value))
                {
                    current.RightChild = Remove(current.RightChild);
                    Count--;
                }
                else
                {
                    Delete(current.RightChild, value);
                }
                return Rebalance(current);
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
            Node<T> Parent = NodeToDelete;
            while (temp.RightChild != null)
            {
                Parent = temp;
                temp = temp.RightChild;
            }
            NodeToDelete.Value = temp.Value;
            if(Parent.Equals(NodeToDelete))
            {
                Parent.LeftChild = Remove(temp);
            }
            else
            {
                Parent.RightChild = Remove(temp);

            }
            Rebalance(Parent);
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
