using System;
using System.Collections.Generic;
using System.Linq;

namespace Self_BalancingTrees
{
    class Program
    {
        //static int CustomCompare(int a, int b)
        //{
        //    bool aEven = a % 2 == 0;
        //    bool bEven = b % 2 == 0;
        //    //Even numbers are sorted first
        //    if (aEven && !bEven)
        //    {
        //        return -1;
        //    }
        //    else if (!aEven && bEven)
        //    {
        //        return 1;
        //    }
        //    return a.CompareTo(b);
        //}

        static int CustomCompare(string a, string b)
        {
            if(a[0] == 'z' && b[0] != 'z')
            {
                return -1;
            }
            else if(b[0] == 'z' && a[0] != 'z')
            {
                return 1;
            }
            return a.CompareTo(b);
        }

        static void Main(string[] args)
        {
            #region
            //class Entry<TKey, TValue>
            //BST<Entry<TKey, TValue>> tree;
            //public Node<T> Find(Entry<TKey, TValue> nodeValue)
            //comparer.Compare(nodeValue, current.Value);
            //tree.Find(new Entry<TKey, TValue>(key, null)).Value.Value;

            //BinaryHeapTree<string> tree = new BinaryHeapTree<string>(Comparer<string>.Create(CustomCompare));
            #endregion
           
        }
    }

    static class RandomStringExtensions
    {
        public static string NextString(this Random random, int length)
        {
            string word = "";
            for (int i = 0; i < length; i++)
            {
                int num = random.Next('a', 'z' + 1);
                char c = (char)num;
                word += c;
            }
            return word;
        }
    }
}
