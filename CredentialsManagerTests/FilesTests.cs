using System;
using System.IO;
using System.Linq;
using CredentialsManager;
using CredentialsManager.FilesExceptions;
using FluentAssertions;
using Xunit;

namespace CredentialsManagerTests
{
  public static class FilesTests
  {
    public class ReadAllText
    {
      [Fact]
      public void Should_Throw_MyFileNotFoundException_When_File_Is_Not_Present_Or_Not_Able_To_Open_File()
      {
        // Arrange
        const string file = "File123213.txt";

        // Act
        Action actual = () => Files.ReadAllText(file);

        // Assert
        actual.Should().ThrowExactly<MyFileNotFoundException>(file);
      }

      [Fact]
      public void Should_Return_Strings_Delimited_By_CRLF_When_Line_Terminator_Is_CRLF()
      {
        // Arrange
        const string file = @"Files/Input/read1-CRLF.txt";
        const string expected = "Test\r\nLine2";

        // Act
        var actual = Files.ReadAllText(file);

        // Assert
        actual.Should().Be(expected);
      }

      [Fact]
      public void Should_Return_Strings_Delimited_By_LF_When_Line_Terminator_Is_LF()
      {
        // Arrange
        const string file = @"Files/Input/read2-LF.txt";
        const string expected = "Test\nLine2";

        // Act
        var actual = Files.ReadAllText(file);

        // Assert
        actual.Should().Be(expected);
      }

      [Fact]
      public void Should_Return_An_Empty_String_When_File_Is_Empty()
      {
        // Arrange
        const string file = @"Files/Input/empty.txt";
        const string expected = "";

        // Act
        var actual = Files.ReadAllText(file);

        // Assert
        actual.Should().Be(expected);
      }

      [Fact]
      public void Should_Return_Empty_Strings_Delimited_By_Line_Terminator_When_File_Contains_Empty_Lines()
      {
        // Arrange
        const string file = @"Files/Input/empty-lines.txt";
        const string expected = "\r\n\r\n\r\n\r\n";

        // Act
        var actual = Files.ReadAllText(file);

        // Assert
        actual.Should().Be(expected);
      }
    }

    public class ReadAllLines
    {
      [Fact]
      public void Should_Return_String_Array_With_Two_Items_When_File_Contains_Two_Lines_And_Line_Terminator_Is_CRLF()
      {
        // Arrange
        const string file = @"Files/Input/read1-CRLF.txt";
        var expected = new[] { "Test", "Line2" };

        // Act
        var actual = Files.ReadAllLines(file);

        // Assert
        actual.Should().Equal(expected);
      }

      [Fact]
      public void Should_Return_String_Array_With_Two_Items_When_File_Contains_Two_Lines_And_Line_Terminator_Is_LF()
      {
        // Arrange
        const string file = @"Files/Input/read1-CRLF.txt";
        var expected = new[] { "Test", "Line2" };

        // Act
        var actual = Files.ReadAllLines(file);

        // Assert
        actual.Should().Equal(expected);
      }

      [Fact]
      public void Should_Return_Empty_String_Array_When_Files_Is_Empty()
      {
        // Arrange
        const string file = @"Files/Input/empty.txt";
        var expected = Array.Empty<string>();

        // Act
        var actual = Files.ReadAllLines(file);

        // Assert
        actual.Should().Equal(expected);
      }

      [Fact]
      public void Should_Return_Empty_String_Array_When_File_Contains_Only_Empty_Lines()
      {
        // Arrange
        const string file = @"Files/Input/empty-lines.txt";
        var expected = Array.Empty<string>();

        // Act
        var actual = Files.ReadAllLines(file);

        // Assert
        actual.Should().Equal(expected);
      }
    }

    public class WriteAllText
    {
      [Fact]
      public void Should_Throw_MyFileNotFoundException_When_Path_Is_Not_Present_Or_Not_Able_To_Open()
      {
        // Arrange
        const string file = @"GG/File45789.txt";

        // Act
        Action actual = () => Files.WriteAllText(file, string.Empty);

        // Assert
        actual.Should().ThrowExactly<MyFileNotFoundException>();
      }

      [Fact]
      public void Should_Create_File_With_Empty_Lines_When_Written_Data_Is_Three_Empty_Lines_Terminated_By_LF()
      {
        // Arrange
        const string file = @"Files/Output/expected_empty-LF.txt";
        const string expected = "\n\n\n";
        File.Delete(file);

        // Act
        Files.WriteAllText(file, expected);

        // Assert
        var actual = File.ReadAllText(file);
        actual.Should().Be(expected);
      }

      [Fact]
      public void Should_Create_File_With_Empty_Lines_When_Written_Data_Is_Three_Empty_Lines_Terminated_By_CRLF()
      {
        // Arrange
        const string file = @"Files/Output/expected_empty-CRLF.txt";
        const string expected = "\r\n\r\n\r\n";
        File.Delete(file);

        // Act
        Files.WriteAllText(file, expected);

        // Assert
        var actual = File.ReadAllText(file);
        actual.Should().Be(expected);
      }

      [Fact]
      public void Should_Create_Empty_File_When_Written_Data_Is_Empty_String()
      {
        // Arrange
        const string file = @"Files/Output/expected_empty.txt";
        const string expected = "";
        File.Delete(file);

        // Act
        Files.WriteAllText(file, expected);

        // Assert
        var actual = File.ReadAllText(file);
        actual.Should().Be(expected);
      }

      [Fact]
      public void Should_Create_File_With_Two_Lines_Of_Text_Each_Terminated_With_CRLF()
      {
        // Arrange
        const string file = @"Files/Output/expected1.txt";
        const string expected = "Test.w\r\nLine2.w";
        File.Delete(file);

        // Act
        Files.WriteAllText(file, expected);

        // Assert
        var actual = File.ReadAllText(file);
        actual.Should().Be(expected);
      }
    }

    public class WriteAllLines
    {
      [Fact]
      public void Should_Create_A_File_With_Empty_Lines_When_Input_Array_Items_Are_Empty_Strings()
      {
        // Arrange
        const string file = @"Files/Output/expected_lines_empty2.txt";
        File.Delete(file);
        var output = Array.Empty<string>();

        // Act
        File.WriteAllLines(file, output);

        // Assert
        var actual = File.ReadLines(file);
        actual.Should().Equal(output);
      }

      [Fact]
      public void Should_Create_An_Empty_File_When_Input_Array_Is_Empty()
      {
        // Arrange
        const string file = @"Files/Output/expected_lines_empty.txt";
        File.Delete(file);
        var output = Array.Empty<string>();

        // Act
        File.WriteAllLines(file, output);

        // Assert
        var actual = File.ReadLines(file);
        actual.Should().Equal(output);
      }

      [Fact]
      public void Should_Create_A_File_With_Two_Lines_Of_Text_With_Array_Items_As_Expected_Data()
      {
        // Arrange
        const string file = @"Files/Output/expected_lines1.txt";
        File.Delete(file);
        var output = new[] { "Test.l", "Line2.l" };

        // Act
        File.WriteAllLines(file, output);

        // Assert
        var actual = File.ReadLines(file);
        actual.Should().Equal(output);
      }
    }

    public class WriteLine
    {
      [Fact]
      public void Should_Throw_MyFileNotFoundException_When_Path_Is_Not_Present_Or_Not_Able_To_Open()
      {
        // Arrange
        const bool anyBool = true;
        const string nonexistentFile = @"GG/File9874.txt";

        // Act
        Action actual = () => Files.WriteLine(nonexistentFile, string.Empty, anyBool);

        // Assert
        actual.Should().ThrowExactly<MyFileNotFoundException>(nonexistentFile);
      }

      [Fact]
      public void Should_Create_A_File_And_Write_One_Line_With_Expected_Data()
      {
        // Arrange
        const string file = @"Files/Output/expected_single_line.txt";
        const string expected = "AllTheSingleLines";

        // Act
        Files.WriteLine(file, expected);

        // Assert
        var actual = File.ReadLines(file);
        actual.First().Should().Be(expected);
      }

      [Fact]
      public void Should_Append_A_New_Line_With_Expected_Data_At_The_End_Of_An_Existing_File()
      {
        // Arrange
        const string file = @"Files/Output/existing_not_empty.txt";
        const string expected = "NewLine13213";
        var initialLinesCount = File.ReadLines(file).Count();

        // Act
        Files.WriteLine(file, expected, true);

        // Assert
        var actual = File.ReadLines(file);
        actual.Count().Should().Be(initialLinesCount + 1);
        actual.Last().Should().Be(expected);
      }

      [Fact]
      public void Should_Overwrite_Existing_File_When_Append_Is_Set_To_False()
      {
        // Arrange
        const string file = @"Files/Output/existing_not_empty.txt";
        const string expected = "NewLine1333";

        // Act
        Files.WriteLine(file, expected);

        // Assert
        var actual = File.ReadLines(file);
        actual.Count().Should().Be(1);
        actual.First().Should().Be(expected);
      }
    }
  }
}