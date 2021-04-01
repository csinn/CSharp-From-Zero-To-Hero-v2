using System;
using System.Runtime.InteropServices;
using Xunit;
using ArrayOperations;

namespace ArrayOperationTests
{
  public class RemoveAtTests
  {
    [Fact]
    public void RemoveAt_Should_Throw_ArgumentException_When_Input_Array_Is_Empty()
    {
      var input = new int[] {};
      var index = 0;
      
      Action actual = () => Arrays.RemoveAt(input, index);
      
      Assert.Throws<ArgumentException>(actual);
    }

    [Fact]
    public void RemoveAt_Should_Throw_ArgumentNullException_When_Input_Is_Null()
    {
      int[] input = null;
      var index = 0;
      
      Action actual = () => Arrays.RemoveAt(input, index);
      
      Assert.Throws<ArgumentNullException>(actual);
    }

    [Theory]
    [InlineData(new[] {0, 1, 2}, 4)]
    [InlineData(new[] {0, 1, 2}, -1)]
    public void RemoveAt_Should_Throw_ArgumentOutOfRange_When_Index_Is_Outside_Of_Array_Bounds(int[] input, int index)
    {
      Action actual;
        
      actual = () => Arrays.RemoveAt(input, index);

      Assert.Throws<ArgumentOutOfRangeException>(actual);
    }
    
    [Theory]
    [InlineData(new[] {0, 1, 2, 3}, 1, new[] {0, 2, 3})]
    [InlineData(new[] {0, 1, 2, 3}, 0, new[] { 1, 2, 3})]
    [InlineData(new[] {0, 1, 2, 3}, 3, new[] {0, 1, 2})]
    [InlineData(new[] {0, 1}, 1, new[] {0})]
    [InlineData(new[] {0, 1}, 0, new[] {1})]
    [InlineData(new[] {0},0, new int[0])]
    public void RemoveAt_Should_Return_New_Array_With_Item_Removed_At_Correct_Position(int[] input, int index, int[] expected)
    { 
      int[] actual; 
       
      actual = Arrays.RemoveAt(input, index);
     
      Assert.Equal(expected, actual);
    }
  }
}