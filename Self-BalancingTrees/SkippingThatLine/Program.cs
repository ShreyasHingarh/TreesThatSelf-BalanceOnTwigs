using System;

namespace SkippingThatLine
{
    class Program
    {
        static void Main(string[] args)
        {
            SkippingTheSteps<int> skip = new SkippingTheSteps<int>();
            Random gen = new Random();
            for(int i = -1;i < 7;i++)
            {
                skip.Add(i);
            }
            skip.Remove(4);
            Console.WriteLine(skip.ToString());

            foreach(var num in skip)
            {
                Console.WriteLine(num);
            }
        }
    }
}
