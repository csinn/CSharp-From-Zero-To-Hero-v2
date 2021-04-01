using System;
using System.Runtime.InteropServices;
using Xunit;
using ArrayOperations;

namespace ArrayOperationTests
{
  public class InsertAtTests
  {
    [Fact]
    public void InsertAt_Should_Throw_ArgumentException_When_Input_Array_Is_Empty()
    {
      var input = new int[] {};
      var element = 1;
      var index = 0;
      
      Action actual = () => Arrays.InsertAt(input,element, index);
      
      Assert.Throws<ArgumentException>(actual);
    }

    [Fact]
    public void InsertAt_Should_Throw_ArgumentNullException_When_Input_Is_Null()
    {
      int[] input = null;
      var element = 1;
      var index = 0;
      
      Action actual = () => Arrays.InsertAt(input,element, index);
      
      Assert.Throws<ArgumentNullException>(actual);
    }

    [Theory]
    [InlineData(new[] {0,2,3}, 1, 1, new[] {0, 1, 2, 3})]
    [InlineData(new[] {1,2,3}, 0, 0, new[] {0, 1, 2, 3})]
    [InlineData(new[] {0,1,2}, 3, 3, new[] {0, 1, 2, 3})]
    [InlineData(new[] {0},1,1, new[] {0,1})]
    [InlineData(new[] {1},0,0, new[] {0,1})]
    public void InsertAt_Should_Return_New_Array_With_Item_Inserted_At_Correct_Position(int[] input, int number, int index, int[] expected)
    { 
      int[] actual; 
       
      actual = Arrays.InsertAt(input, number, index);
     
      Assert.Equal(expected, actual);
    }
  }
}
