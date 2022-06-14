using System;

namespace SkippingThatLine
{
    class Program
    {
        static void Main(string[] args)
        {
            SkippingTheSteps<int> skip = new SkippingTheSteps<int>();
            Random gen = new Random();
            for(int i = 0;i < 7;i++)
            {
                skip.Add(i);
                
            }
        }
    }
}
