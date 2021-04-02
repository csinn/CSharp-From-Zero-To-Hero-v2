using System;
using System.Runtime.InteropServices;
using Xunit;
using ArrayOperations;

namespace ArrayOperationTests
{
  public class SortTests
  {
    [Fact]
    public void Sort_Should_Throw_ArgumentNullException_When_Input_Is_Null()
    {
      int[] input = null;
      
      Action actual = () => Arrays.Sort(input);
      
      Assert.Throws<ArgumentNullException>(actual);
    }

    [Theory]
    [InlineData(new int[] {}, new int[] {})]
    [InlineData(new[] {0}, new[] {0})]
    [InlineData(new[] {1, 0}, new[] {0, 1})]
    [InlineData(new[] {0, 1}, new[] {0, 1})]
    [InlineData(new[] {1, 0, 2, -1, 3}, new[] {-1, 0, 1, 2, 3})]
    [InlineData(new[] {1, -1, 1}, new[] {-1, 1, 1})]
    [InlineData(new[] {1, 1, 1}, new[] {1, 1, 1})]
    public void Sort_Should_Return_Expected_Array(int[] input, int[] expected)
    {
      int[] actual; 
      
      actual = Arrays.Sort(input);
      
      Assert.Equal(expected, actual);
    }
  }
}