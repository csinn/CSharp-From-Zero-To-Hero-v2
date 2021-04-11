using System;

namespace CredentialsManager.FilesExceptions
{
  public class MyFileNotFoundException : Exception
  {
    public MyFileNotFoundException(string file) 
      : base($"{file} file not found or not able to open!")
    {
    }
  }
}