using System;

namespace CredentialsManager.FilesExceptions
{
  public class UserNameIsTakenException : Exception
  {
    public UserNameIsTakenException(string message) : base(message)
    {
    }
  }
}