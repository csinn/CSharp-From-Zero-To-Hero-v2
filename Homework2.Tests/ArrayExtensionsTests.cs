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
        [InlineData(4, 5, 6, 1, 3, 1, 3, 4, 5, 6)]
        [InlineData(0, 1, 2, 3, 9, -5, -5, 0, 1, 2, 3, 9)]
        [InlineData(9.1, 8.5, 1.0, -5.2, -5.2, 1.0, 8.5, 9.1)]
        public void Sort_sorts_the_array(params object[] objs)
        {
            int count = objs.Length / 2;

            var array = objs.Take(count).ToArray();
            array.Sort();

            var expected = objs.TakeLast(count).ToArray();

            Assert.Equal(array, expected);
        }
    }
}