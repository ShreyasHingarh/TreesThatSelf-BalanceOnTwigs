using System;
using System.Collections.Generic;
using System.Linq;

using SkippingThatLine;
using Xunit;

namespace SkippingThatLine.Test
{
    public class MathTest
    {
        /*
        [Fact]
        public void MultiplicationTest()
        {
            Assert.Equal(9, 3 * 3);
            Assert.Equal(12, 4 * 3);
            Assert.Equal(1, 3 / 3);
        }

        [Fact]
        public void FailingTest()
        {
            int[] arr = { 1, 2, 3, 4, 5, 6 };

            //Assert.True(false);
            Assert.Contains(6, arr);
        }

        [Theory]
        [InlineData(2, 3, 5)]
        [InlineData(5, 5, 10)]
        [InlineData(7, 7, 14)]
        public void AdditionTest(int a, int b, int expected)
        {
            Assert.Equal(expected, a + b);
        }
        */
        [Fact]
        public void InsertTest()
        {
            SkippingTheSteps<int> skipList = new SkippingTheSteps<int>();
            skipList.Add(5);
            Assert.Contains(5, skipList);
        }
        [Fact]

        public void DeleteTest()
        {
            SkippingTheSteps<int> skip = new SkippingTheSteps<int>();
            for(int i = 0;i < 5;i++)
            {
                skip.Add(i);
            }
            skip.Remove(2);
            Assert.True(skip.Find(2) == null);
        }
        [Fact]
        public void FindTest()
        {
            SkippingTheSteps<int> skip = new SkippingTheSteps<int>();
            for (int i = 0; i < 5; i++)
            {
                skip.Add(i);
            }
            Assert.NotNull(skip.Find(1));
        }
        [Fact]
        public void EnumeratorTest()
        {
            SkippingTheSteps<int> skip = new SkippingTheSteps<int>();
            for (int i = 0; i < 5; i++)
            {
                skip.Add(i);
            }

            List<int> list= skip.ToList();
            Assert.Equal(new int[] { 0, 1, 2, 3, 4 }, list);
        }
    }
}
