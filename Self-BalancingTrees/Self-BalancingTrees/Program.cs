using System;

namespace Self_BalancingTrees
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryHeapTree<int> tree = new BinaryHeapTree<int>();

            for(int i = 0;i < 10;i++)
            {
                tree.Insert(i);
            }
            tree.Print();
        }
    }
}
