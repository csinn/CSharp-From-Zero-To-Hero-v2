using System.Linq;
using Xunit;

namespace Homework2.Tests
{
    public class ArrayExtensionsTests
    {
        [Theory]
        [InlineData(999, 4)]
        [InlineData(999, 0)]
        [InlineData(999, 10)]
        public void AddAt_adds_at_idx(int item, int idx)
        {
            var testarray = new int[] { 11, 22, 33, 44, 55, 66, 77, 88, 99, 111 };

            var newarray = testarray.AddAt(item, idx);

            Assert.Equal(testarray.Length + 1, newarray.Length);
            Assert.Equal(newarray[idx], item);
        }

        [Theory]
        [InlineData(4)]
        [InlineData(0)]
        [InlineData(9)]
        public void RemoveAt_removes_at_idx(int idx)
        {
            var testarray = new int[] { 11, 22, 33, 44, 55, 66, 77, 88, 99, 111 };

            var newarray = testarray.RemoveAt(idx);

            Assert.Equal(testarray.Length - 1, newarray.Length);
            Assert.DoesNotContain(testarray[idx], newarray);
        }

        [Theory]
        [InlineData(new int[] { 4, 5, 6, 1, 3 }, new int[] { 1, 3, 4, 5, 6 })]
        [InlineData(new int[] { 0, 1, 2, 3, 9, -5 }, new int[] { -5, 0, 1, 2, 3, 9 })]
        public void Sort_sorts_the_int_array(int[] testData, int[] expected)
        {
            testData.Sort();

            Assert.Equal(expected, testData);
        }

        [Theory]
        [InlineData(new double[] { 9.1, 8.5, 1.0, -5.2 }, new double[] { -5.2, 1.0, 8.5, 9.1 })]
        public void Sort_sorts_the_double_array(double[] testData, double[] expected)
        {
            testData.Sort();

            Assert.Equal(expected, testData);
        }

    }
}