using System;
using System.Collections.Generic;
using System.Linq;

namespace Self_BalancingTrees
{
    class Program
    {
        static int CustomCompare(int a, int b)
        {
            bool aEven = a % 2 == 0;
            bool bEven = b % 2 == 0;
            //Even numbers are sorted first
            if (aEven && !bEven)
            {
                return -1;
            }
            else if (!aEven && bEven)
            {
                return 1;
            }
            return a.CompareTo(b);
        }

        static void Main(string[] args)
        {
            BinaryHeapTree<int> tree = new BinaryHeapTree<int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));

            Random rand = new Random(30);

            int[] nums = new int[20]; //{ 4,5,1,3,2,10,6,9,7,8};
            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = rand.Next(1, 100);
            }

            for (int i = 0; i < nums.Length; i++)
            {
                tree.Insert(nums[i]);
            }
            Console.WriteLine(tree.IsValid());
            List<int> s = new List<int>();
            while (tree.Count > 0)
            {
                int value = tree.Pop();
                s.Add(value);
                if (!tree.IsValid())
                {
                    Console.WriteLine($"Invalid after popping {value}");
                }
            }
            Console.WriteLine(tree.IsValid());
        }
    }
}
