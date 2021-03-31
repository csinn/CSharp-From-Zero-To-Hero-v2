using System;
using System.Runtime.InteropServices;
using Xunit;
using ArrayOperations;

namespace ArrayOperationTests
{
  public class SortTests
  {
    [Fact]
    public void Sort_Should_Throw_ArgumentException_When_Input_Array_Is_Empty()
    {
      var input = new int[] {};
      
      Action test = () => Arrays.Sort(input);
      
      Assert.Throws<ArgumentException>(test);
    }

    [Fact]
    public void Sort_Should_Throw_ArgumentNullException_When_Input_Is_Null()
    {
      int[] input = null;
      
      Action test = () => Arrays.Sort(input);
      
      Assert.Throws<ArgumentNullException>(test);
    }

    [Theory]
    [InlineData(new [] {9001})]
    [InlineData(new [] {0})]
    public void Sort_Should_Return_Input_When_Array_Has_One_Element(int[] input)
    {
      int[] test;
      
      test = Arrays.Sort(input);
      
      Assert.Equal(input,test);
    }

    [Theory]
    [InlineData(new[] {9, 2, 6, 10}, new[] {2, 6, 9, 10})]
    [InlineData(new[] {3, 2, 1}, new[] {1, 2, 3})]
    [InlineData(new[] {2, 1, 3}, new[] {1, 2, 3})]
    [InlineData(new[] {'a', 1, 7, 'b', 'D'}, new[] {1, 7, 'D', 'a', 'b'})]
    public void Sort_Should_Return_Ordered_Array(int[] input, int[] expected)
    {
      int[] test; 
      
      test= Arrays.Sort(input);
      
      Assert.Equal(expected, test);
    }
  }
}