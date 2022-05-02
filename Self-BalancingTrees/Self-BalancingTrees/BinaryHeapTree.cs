using System;
using System.Collections.Generic;
using System.Text;

namespace Self_BalancingTrees
{
    class BinaryHeapTree<T> where T:IComparable<T>
    {
        public List<T> values { get; } = new List<T>();
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
            while(index != 0)
            {
                if (values[index].CompareTo(values[GetParent(index)]) <= 0)
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
            values.Remove(values[values.Count - 1]);
            HeapifyDown(0);
            return temp;
        }
        public void HeapifyDown(int index)
        {
            while(true)
            {
                int rIndex = GetRightChild(index);
                int lIndex = GetLeftChild(index);
                if (lIndex >= values.Count && rIndex >= values.Count)
                {
                    break;
                }

                //Figure out which child is smaller
                //Check if the smaller child is smaller than the parent
                int swapIndex = rIndex;
                if(rIndex >= values.Count)
                {
                    swapIndex = lIndex;
                }
                else if(values[lIndex].CompareTo(values[rIndex]) < 0)//Both indexes must be in the array
                {
                    swapIndex = lIndex;
                }
                

                if(values[swapIndex].CompareTo(values[index]) < 0)
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
            for(int i = 0;i < values.Count;i++)
            {
                Console.WriteLine(values[i]);
            }
        }
    }
}
