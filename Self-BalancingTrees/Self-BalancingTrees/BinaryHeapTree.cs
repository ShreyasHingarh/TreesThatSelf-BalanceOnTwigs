using System;
using System.Collections.Generic;
using System.Text;

namespace Self_BalancingTrees
{
    class BinaryHeapTree<T>
    {
        private List<T> values;
        private IComparer<T> comparer;
        public int Count => values.Count;

        public BinaryHeapTree()
            : this(Comparer<T>.Default)
        {
        }

        public BinaryHeapTree(IComparer<T> comparer)
        {
            values = new List<T>();
            this.comparer = comparer;
        }

        public void Insert(T value)
        {
            values.Add(value);
            HeapifyUp(values.Count - 1);
        }

        public int GetRightChild(int index)
        {
            return index * 2 + 2;
        }
        
        public int GetLeftChild(int index)
        {
            return index * 2 + 1;
        }
        
        public int GetParent(int index)
        {
            return (index - 1) / 2;
        }

        public void HeapifyUp(int index)
        {
            while (index != 0)
            {
                if (comparer.Compare(values[index], values[GetParent(index)]) <= 0)
                {
                    T temp = values[index];
                    values[index] = values[GetParent(index)];
                    values[GetParent(index)] = temp;

                    index = GetParent(index);
                }
                else
                {
                    break;
                }
            }
        }

        public T Pop()
        {
            T temp = values[0];
            values[0] = values[values.Count - 1];
            values.RemoveAt(values.Count - 1);
            HeapifyDown(0);
            return temp;
        }

        public void HeapifyDown(int index)
        {
            while (true)
            {
                int rIndex = GetRightChild(index);
                int lIndex = GetLeftChild(index);
                if (lIndex >= values.Count && rIndex >= values.Count)
                {
                    break;
                }

                //Figure out which child is smaller
                int swapIndex = rIndex;
                if (rIndex >= values.Count)
                {
                    swapIndex = lIndex;
                }
                else if (comparer.Compare(values[lIndex], values[rIndex]) < 0)//Both indexes must be in the array
                {
                    swapIndex = lIndex;
                }

                //Check if the smaller child is smaller than the parent
                if (comparer.Compare(values[swapIndex], values[index]) < 0)
                {
                    T temp = values[index];
                    values[index] = values[swapIndex];
                    values[swapIndex] = temp;
                    index = swapIndex;
                }
                else
                {
                    break;
                }
            }
        }
        public void Print()
        {
            for (int i = 0; i < values.Count; i++)
            {
                Console.WriteLine(values[i]);
            }
        }
        public bool IsValid()
        {
            return IsValid(0);
        }

        private bool IsValid(int index)
        {
            if (index >= Count)
            {
                return true;
            }

            //Store curvalue, leftvalue,rightvalue
            T cur = values[index];
            int lIndex = GetLeftChild(index);
            int rIndex = GetRightChild(index);
            if (lIndex < Count && comparer.Compare(cur, values[lIndex]) > 0) return false;
            if (rIndex < Count && comparer.Compare(cur, values[rIndex]) > 0) return false;

            return IsValid(index + 1);
        }
    }
}
