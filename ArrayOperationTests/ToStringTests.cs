using System;
using ArrayOperations;
using FluentAssertions;
using Xunit;

namespace ArrayOperationTests
{
  public class ToStringTests
  {
    [Fact]
    public void ToString_Should_Throw_ArgumentNullException_When_Input_Array_Is_Null()
    {
      int[] input = null;

      Action actual = () => Arrays.ToString(input);

      actual.Should().ThrowExactly<ArgumentNullException>();
    }

    [Theory]
    [InlineData(new[] {1}, "[ 1 ]")]
    [InlineData(new[] {0, 1}, "[ 0, 1 ]")]
    [InlineData(new int[] { }, "[ ]")]
    public void ToString_Should_Return_Expected_Data(int[] input, string expected)
    {
      var actual = Arrays.ToString(input);

      actual.Should().Be(expected);
    }
  }
}