using System.IO;
using System.Linq;
using CredentialsManager;
using FluentAssertions;
using Xunit;

namespace CredentialsTests
{
  public class FilesTests
  {
    [Theory]
    [InlineData(@"Input/read1.txt", "Test\r\nLine2")]
    [InlineData(@"Input/read2.txt", "Test\nLine2")]
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
      File.Delete(file);
      Files.WriteAllText(file, expected);

      var actual = File.ReadAllText(file);

      actual.Should().Be(expected);
    }

    [Theory]
    [InlineData(@"Output/expected_lines1.txt", new[] {"Test.l", "Line2.l"})]
    [InlineData(@"Output/expected_lines_empty.txt", new string[0])]
    [InlineData(@"Output/expected_lines_empty2.txt", new[] {"", "", ""})]
    public void WriteAllLines_Should_Create_Expected_Output(string file, string[] expected)
    {
      File.Delete(file);
      Files.WriteAllLines(file, expected);

      var actual = File.ReadAllLines(file);

      actual.Should().Equal(expected);
    }

    [Theory]
    [InlineData(@"Output/expected_single_line.txt", "AllTheSingleLines")]
    [InlineData(@"Output/expected_multi_line.txt", "Line1", true)]
    public void WriteLine_Should_Create_Expected_Output(string file, string expected, bool append = false)
    {
      File.Delete(file);
      Files.WriteLine(file, expected, append);

      var actual = File.ReadAllLines(file);

      actual.Last().Should().Be(expected);
    }
  }
}