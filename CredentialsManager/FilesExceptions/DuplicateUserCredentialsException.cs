using System;

namespace CredentialsManager.FilesExceptions
{
  public class DuplicateUserCredentialsException : Exception
  {
    public DuplicateUserCredentialsException(string details) : base(details)
    {
    }
  }
}