using System;

namespace CredentialsManager
{
#pragma warning disable RCS1194 // Implement exception constructors.

  public class DuplicateUserCredentialsException : Exception
#pragma warning restore RCS1194 // Implement exception constructors.
  {
    public DuplicateUserCredentialsException()
    {
    }

    public DuplicateUserCredentialsException(string? details) : base(details)
    {
    }
  }
}