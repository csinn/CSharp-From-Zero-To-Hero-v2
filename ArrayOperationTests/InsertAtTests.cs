using System;
using ArrayOperations;
using FluentAssertions;
using Xunit;

namespace ArrayOperationTests
{
  public class InsertAtTests
  {
    [Fact]
    public void InsertAt_Should_Throw_ArgumentNullException_When_Input_Is_Null()
    {
      int[] input = null;
      const int Element = 1;
      const int Index = 0;

      Action actual = () => Arrays.InsertAt(input, Element, Index);

      actual.Should().ThrowExactly<ArgumentNullException>();
    }

    [Theory]
    [InlineData(new[] {0, 1, 2}, 4)]
    [InlineData(new[] {0, 1, 2}, -1)]
    public void InsertAt_Should_Throw_ArgumentOutOfRange_When_Index_Is_Outside_Of_Array_Bounds(int[] input, int index)
    {
      const int Item = 9;

      Action actual = () => Arrays.InsertAt(input, Item, index);

      actual.Should().ThrowExactly<ArgumentOutOfRangeException>();
    }

    [Theory]
    [InlineData(new[] {0, 2, 3}, 1, 1, new[] {0, 1, 2, 3})]
    [InlineData(new[] {1, 2, 3}, 0, 0, new[] {0, 1, 2, 3})]
    [InlineData(new[] {0, 1, 2}, 3, 3, new[] {0, 1, 2, 3})]
    [InlineData(new[] {0}, 1, 1, new[] {0, 1})]
    [InlineData(new[] {1}, 0, 0, new[] {0, 1})]
    public void InsertAt_Should_Return_New_Array_With_Item_Inserted_At_Correct_Position(int[] input, int number,
      int index, int[] expected)
    {
      var actual = Arrays.InsertAt(input, number, index);

      actual.Should().Equal(expected);
    }
  }
}