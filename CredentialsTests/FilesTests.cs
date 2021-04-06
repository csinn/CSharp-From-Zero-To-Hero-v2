using System;
using CredentialsManager;
using FluentAssertions;
using System.IO;
using System.Linq;
using CredentialsManager.FilesExceptions;
using Xunit;

namespace CredentialsTests
{
  public class FilesTests
  {
    [Fact]
    public void ReadAllText_Should_Throw_MyFileNotFoundException_When_Path_Is_Not_Present_Or_Not_Able_To_Open()
    {
      const string file = "File123213.txt";

      Action actual = () => Files.ReadAllText(file);
      
      actual.Should().ThrowExactly<MyFileNotFoundException>(file);
    }
    
    [Theory]
    [InlineData(@"Files/Input/read1-CRLF.txt", "Test\r\nLine2")]
    [InlineData(@"Files/Input/read2-LF.txt", "Test\nLine2")]
    [InlineData(@"Files/Input/empty.txt", "")]
    [InlineData(@"Files/Input/empty-lines.txt", "\r\n\r\n\r\n\r\n")]
    public void ReadAllText_Should_Return_Expected_String(string file, string expected)
    {
      var actual = Files.ReadAllText(file);

      actual.Should().Be(expected);
    }

    [Theory]
    [InlineData(@"Files/Input/read1-CRLF.txt", new[] { "Test", "Line2" })]
    [InlineData(@"Files/Input/read2-LF.txt", new[] { "Test", "Line2" })]
    [InlineData(@"Files/Input/empty.txt", new string[] { })]
    [InlineData(@"Files/Input/empty-lines.txt", new string[] { })]
    public void ReadAllLines_Should_Return_Expected_Collection(string file, string[] expected)
    {
      var actual = Files.ReadAllLines(file);

      actual.Should().Equal(expected);
    }

    [Fact]
    public void WriteAllText_Should_Throw_MyFileNotFoundException_When_Path_Is_Not_Present_Or_Not_Able_To_Open()
    {
      const string file = @"GG/File45789.txt";

      Action actual = () => Files.WriteAllText(file, string.Empty);

      actual.Should().ThrowExactly<MyFileNotFoundException>();
    }
    
    [Theory]
    [InlineData(@"Files/Output/expected1.txt", "Test.w\r\nLine2.w")]
    [InlineData(@"Files/Output/expected_empty.txt", "")]
    [InlineData(@"Files/Output/expected_empty-CRLF.txt", "\r\n\r\n\r\n")]
    [InlineData(@"Files/Output/expected_empty-LF.txt", "\n\n\n")]
    public void WriteAllText_Should_Create_Expected_Output(string file, string expected)
    {
      File.Delete(file);
      Files.WriteAllText(file, expected);

      var actual = File.ReadAllText(file);

      actual.Should().Be(expected);
    }

    [Theory]
    [InlineData(@"Files/Output/expected_lines1.txt", new[] { "Test.l", "Line2.l" })]
    [InlineData(@"Files/Output/expected_lines_empty.txt", new string[] {})]
    [InlineData(@"Files/Output/expected_lines_empty2.txt", new[] { "", "", "" })]
    public void WriteAllLines_Should_Create_Expected_Output(string file, string[] expected)
    {
      File.Delete(file);
      Files.WriteAllLines(file, expected);

      var actual = File.ReadAllLines(file);

      actual.Should().Equal(expected);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void WriteLine_Should_Throw_MyFileNotFoundException_When_Path_Is_Not_Present_Or_Not_Able_To_Open(bool append)
    {
      const string file = @"GG/File9874.txt";

      Action actual = () => Files.WriteLine(file, string.Empty, append);

      actual.Should().ThrowExactly<MyFileNotFoundException>(file);

    }
    
    [Theory]
    [InlineData(@"Files/Output/expected_single_line.txt", "AllTheSingleLines", false)]
    [InlineData(@"Files/Output/expected_multi_line.txt", "Line1", true)]
    public void WriteLine_Should_Create_Expected_Output(string file, string expected, bool append)
    {
      File.Delete(file);
      Files.WriteLine(file, expected, append);

      var actual = File.ReadAllLines(file);

      actual.Last().Should().Be(expected);
    }
  }
}