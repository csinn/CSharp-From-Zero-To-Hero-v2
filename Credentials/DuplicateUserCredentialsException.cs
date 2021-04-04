using System;

namespace Credentials
{
  public class DuplicateUserCredentialsException : Exception
  {
    public DuplicateUserCredentialsException(string? details) : base(details)
    {
    }
  }
}