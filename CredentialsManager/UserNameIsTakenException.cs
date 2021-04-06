using System;

namespace CredentialsManager
{
#pragma warning disable RCS1194 // Implement exception constructors.

  public class UserNameIsTakenException : Exception
#pragma warning restore RCS1194 // Implement exception constructors.
  {
    public UserNameIsTakenException()
    {
    }

    public UserNameIsTakenException(string? message) : base(message)
    {
    }
  }
}