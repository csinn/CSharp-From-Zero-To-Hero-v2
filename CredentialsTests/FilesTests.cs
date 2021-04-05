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
  }
}