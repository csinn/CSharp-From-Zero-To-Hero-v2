using System;

namespace CredentialsManager.FilesExceptions
{
  public class MyFileNotFoundException : Exception
  {
    public MyFileNotFoundException()
    {
    }

    public MyFileNotFoundException(string details) : base(details)
    {
    }
  }
}