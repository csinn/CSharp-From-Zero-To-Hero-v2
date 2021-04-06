using System;
using System.IO;
using System.Security;
using CredentialsManager.FilesExceptions;

namespace CredentialsManager
{
  public static class Files
  {
    private static readonly string[] Delimiters = {"\r\n", "\n"};
    
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
                              || ex is ArgumentNullException
                              || ex is FileNotFoundException
                              || ex is DirectoryNotFoundException
                              || ex is IOException)
      {
        throw new MyFileNotFoundException($"{file} file not found ore not able to open!");
      }
    }

    public static string[] ReadAllLines(string file)
    {
      var content = ReadAllText(file);
      return content.Split(Delimiters, StringSplitOptions.None);
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
                              || ex is ArgumentException 
                              || ex is ArgumentNullException
                              || ex is DirectoryNotFoundException
                              || ex is PathTooLongException
                              || ex is IOException
                              || ex is SecurityException) 
      {
        throw new MyFileNotFoundException($"{file} file not found ore not able to open!");
      }
    }

    public static void WriteAllLines(string file, string[] data)
    {
      if (data.Length == 0)
      {
        WriteAllText(file, string.Empty);
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
                              || ex is ArgumentException 
                              || ex is ArgumentNullException
                              || ex is DirectoryNotFoundException
                              || ex is PathTooLongException
                              || ex is IOException
                              || ex is SecurityException) 
      {
        throw new MyFileNotFoundException($"{file} file not found ore not able to open!");
      }
    }
  }
}