using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CredentialsManager
{
#pragma warning disable RCS1194 // Implement exception constructors.
  public class UserNameIsTakenException : Exception
#pragma warning restore RCS1194 // Implement exception constructors.
  {
    public UserNameIsTakenException() : base()
    {
    }

    public UserNameIsTakenException(string? message) : base(message)
    {
    }
  }
}