using System;
using System.IO;

namespace Credentials
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
  }
}