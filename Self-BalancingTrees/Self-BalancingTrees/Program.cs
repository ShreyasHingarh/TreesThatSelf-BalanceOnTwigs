using System;
using System.Collections.Generic;

namespace Self_BalancingTrees
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryHeapTree<int> tree = new BinaryHeapTree<int>();

            Random rand = new Random();

            int[] nums = new int[20];// { 4,5,1,3,2};
            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = rand.Next(1, 100);
            }

            for (int i = 0;i < nums.Length;i++)
            {
                tree.Insert(nums[i]);
            }
            Console.WriteLine(IsValid(tree));
            List<int> s = new List<int>();
            while(tree.values.Count > 0)
            {
                s.Add(tree.Pop());
            }
        }

        static bool IsValid(BinaryHeapTree<int> heap)
        {
            return IsValid(heap, 0); 
        }
            
        static bool IsValid(BinaryHeapTree<int> heap, int index)
        {
            if(index >= heap.values.Count)
            {
                return true;
            }

            //Store curvalue, leftvalue,rightvalue
            int cur = heap.values[index];
            int lIndex = heap.GetLeftChild(index);
            int rIndex = heap.GetRightChild(index);
            if (lIndex < heap.values.Count && cur > heap.values[lIndex]) return false;
            if (rIndex < heap.values.Count && cur > heap.values[rIndex]) return false; 
            
            return IsValid(heap,index+1);
        }


    }
}
