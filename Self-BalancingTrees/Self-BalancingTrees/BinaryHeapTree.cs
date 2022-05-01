using System;
using System.Collections.Generic;
using System.Text;

namespace Self_BalancingTrees
{
    class BinaryHeapTree<T> where T:IComparable<T>
    {
        List<T> values = new List<T>();
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
        
        public void Print()
        {
            for(int i = 0;i < values.Count;i++)
            {
                Console.WriteLine(values[i]);
            }
        }
    }
}
