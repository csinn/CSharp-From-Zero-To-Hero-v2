using System;

namespace CredentialsManager.FilesExceptions
{
  public class MyFileNotFoundException : Exception
  {
    public MyFileNotFoundException(string file, Exception inner)
      : base($"{file} file not found or not able to open!", inner)
    {
    }
  }
}