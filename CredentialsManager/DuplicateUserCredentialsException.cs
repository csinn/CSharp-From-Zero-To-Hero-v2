using System;

namespace CredentialsManager
{
  public class DuplicateUserCredentialsException : Exception
  {
    public DuplicateUserCredentialsException(string? details) : base(details)
    {
    }
  }
}