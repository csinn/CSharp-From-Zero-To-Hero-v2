using System;
using Xunit;

namespace Homework2.Tests
{
    public class ArrayExtensionsTests
    {
        private int[] _testArray;

        public ArrayExtensionsTests()
        {
            _testArray = new int[] { 1, 3, 3, 7 };
        }

        [Theory]
        [InlineData(999, 2)]
        [InlineData(999, 0)]
        [InlineData(999, 3)]
        public void AddAt_adds_at_idx(int item, int idx)
        {
            var newarray = _testArray.AddAt(item, idx);

            Assert.Equal(_testArray.Length + 1, newarray.Length);
            Assert.Equal(newarray[idx], item);
        }

        [Fact]
        public void AddAt_TryingToAddAtNegativeOutOfRangeIndex_Throws_ArgumentOutOfRangeException()
        {
            var arrayLength = _testArray.Length;
            Action faultyAddCall = () => _testArray.AddAt(999, -5);

            Assert.Throws<IndexOutOfRangeException>(faultyAddCall);
        }

        [Fact]
        public void AddAt_TryingToAddAtOutOfRangeIndex_Throws_ArgumentOutOfRangeException()
        {
            var arrayLength = _testArray.Length;
            Action faultyAddCall = () => _testArray.AddAt(999, arrayLength + 5);

            Assert.Throws<IndexOutOfRangeException>(faultyAddCall);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(0)]
        [InlineData(3)]
        public void RemoveAt_removes_at_idx(int idx)
        {
            var newarray = _testArray.RemoveAt(idx);

            Assert.Equal(_testArray.Length - 1, newarray.Length);

            for (int i = 0; i < newarray.Length; i++)
            {
                if (i >= idx)
                {
                    Assert.Equal(_testArray[i + 1], newarray[i]);
                    continue;
                }

                Assert.Equal(_testArray[i], newarray[i]);
            }
        }

        [Fact]
        public void RemoveAt_TryingToRemoveAtNegativeOutOfRangeIndex_Throws_ArgumentOutOfRangeException()
        {
            var arrayLength = _testArray.Length;
            Action faultyAddCall = () => _testArray.RemoveAt(-5);

            Assert.Throws<IndexOutOfRangeException>(faultyAddCall);
        }

        [Fact]
        public void RemoveAt_TryingToRemoveAtOutOfRangeIndex_Throws_ArgumentOutOfRangeException()
        {
            var arrayLength = _testArray.Length;
            Action faultyAddCall = () => _testArray.RemoveAt(arrayLength + 5);

            Assert.Throws<IndexOutOfRangeException>(faultyAddCall);
        }

        [Theory]
        [InlineData(new double[] { 9.1, 8.5, 1.0, -5.2 }, new double[] { -5.2, 1.0, 8.5, 9.1 })]
        public void Sort_sorts_the_double_array(double[] testData, double[] expected)
        {
            testData.Sort();

            Assert.Equal(expected, testData);
        }

        [Theory]
        [InlineData(new int[] { 4, 5, 6, 1, 3 }, new int[] { 1, 3, 4, 5, 6 })]
        [InlineData(new int[] { 0, 1, 2, 3, 9, -5 }, new int[] { -5, 0, 1, 2, 3, 9 })]
        public void Sort_sorts_the_int_array(int[] testData, int[] expected)
        {
            testData.Sort();

            Assert.Equal(expected, testData);
        }
    }
}