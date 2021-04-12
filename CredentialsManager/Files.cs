using CredentialsManager.FilesExceptions;
using System;
using System.IO;
using System.Security;

namespace CredentialsManager
{
  public static class Files
  {
    private static readonly string[] Delimiters = { "\r\n", "\n" };

    public static string ReadAllText(string file)
    {
      try
      {
        using (var reader = new StreamReader(file))
        {
          return reader.ReadToEnd();
        }
      }
      catch (Exception ex) when (ex is ArgumentException
                              or ArgumentNullException
                              or FileNotFoundException
                              or DirectoryNotFoundException
                              or IOException)
      {
        throw new MyFileNotFoundException(file, ex);
      }
    }

    public static string[] ReadAllLines(string file)
    {
      var content = ReadAllText(file);
      return content.Split(Delimiters, StringSplitOptions.RemoveEmptyEntries);
    }

    public static void WriteAllText(string file, string data)
    {
      try
      {
        using (var writer = new StreamWriter(file))
        {
          writer.Write(data);
        }
      }
      catch (Exception ex) when (ex is UnauthorizedAccessException
                              or ArgumentException
                              or ArgumentNullException
                              or DirectoryNotFoundException
                              or PathTooLongException
                              or IOException
                              or SecurityException)
      {
        throw new MyFileNotFoundException(file, ex);
      }
    }

    public static void WriteAllLines(string file, string[] data)
    {
      if (data.Length == 0)
      {
        WriteAllText(file, string.Empty);
        return;
      }

      foreach (var line in data)
      {
        WriteLine(file, line, true);
      }
    }

    public static void WriteLine(string file, string data, bool append = false)
    {
      try
      {
        using (var writer = new StreamWriter(file, append))
        {
          writer.WriteLine(data);
        }
      }
      catch (Exception ex) when (ex is UnauthorizedAccessException
                              or ArgumentException
                              or ArgumentNullException
                              or DirectoryNotFoundException
                              or PathTooLongException
                              or IOException
                              or SecurityException)
      {
        throw new MyFileNotFoundException(file, ex);
      }
    }
  }
}