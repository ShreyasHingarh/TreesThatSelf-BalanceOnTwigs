using System;

namespace DoubleLinkedListButBetter
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random(12);
            DoublyLinkedlyListButBetter<int> list = new DoublyLinkedlyListButBetter<int>();
            for(int i = 0;i < 10;i++)
            {
                list.Insert(random.Next(0, 101));
            }
            list.Print();
            list.Delete(4);
            list.Print();
        }
    }
}
