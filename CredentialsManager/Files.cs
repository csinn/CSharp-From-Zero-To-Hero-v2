using System;
using System.IO;

namespace CredentialsManager
{
  public static class Files
  {
    public static string ReadAllText(string file)
    {
      using (var reader = new StreamReader(file))
      {
        var content = reader.ReadToEnd().Trim();
        return content;
      }
    }

    public static string[] ReadAllLines(string file)
    {
      var content = ReadAllText(file);
      var lines = content.Split($"{Environment.NewLine}");
      return lines;
    }

    public static void WriteAllText(string file, string data)
    {
      using (var writer = new StreamWriter(file))
      {
        writer.Write(data);
      }
    }

    public static void WriteAllLines(string file, string[] data)
    {
      if (data.Length == 0) WriteAllText(file, string.Empty);

      foreach (var line in data) WriteLine(file, line, true);
    }

    public static void WriteLine(string file, string data, bool append = false)
    {
      using (var writer = new StreamWriter(file, append))
      {
        writer.WriteLine(data);
      }
    }
  }
}