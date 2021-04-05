using System.IO;
using Credentials;
using FluentAssertions;
using Xunit;

namespace CredentialsTests
{
  public class FilesTests
  {
    [Theory]
    [InlineData(@"Input/read1.txt", "Test\r\nLine2")]
    [InlineData(@"Input/empty.txt", "")]
    [InlineData(@"Input/emptylines.txt", "")]
    public void ReadAllText_Should_Return_Expected_Output(string file, string expected)
    {
      var actual = Files.ReadAllText(file);

      actual.Should().Be(expected);
    }

    [Theory]
    [InlineData(@"Input/read1.txt", new[] {"Test", "Line2"})]
    [InlineData(@"Input/empty.txt", new[] {""})]
    [InlineData(@"Input/emptylines.txt", new[] {""})]
    public void ReadAllLines_Should_Return_Expected_Output(string file, string[] expected)
    {
      var actual = Files.ReadAllLines(file);

      actual.Should().Equal(expected);
    }

    [Theory]
    [InlineData(@"Output/expected1.txt", "Test.w\r\nLine2.w")]
    [InlineData(@"Output/expected_empty.txt", "")]
    [InlineData(@"Output/expected_empty2.txt", "\r\n\r\n\r\n")]
    [InlineData(@"Output/expected_empty_3.txt", "\n\n\n")]
    public void WriteAllText_Should_Create_Expected_Output(string file, string expected)
    {
      Files.WriteAllText(file, expected);
      var actual = File.ReadAllText(file);
      actual.Should().Be(expected);
    }
  }
}