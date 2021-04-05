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
        return reader.ReadToEnd().Trim();
      }
    }

    public static string[] ReadAllLines(string file)
    {
      var content = ReadAllText(file);
      return content.Split($"{Environment.NewLine}");
    }
  }
}