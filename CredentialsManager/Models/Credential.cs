using System;

namespace CredentialsManager.Models
{
  public class Credential : IEquatable<Credential>
  {
    public string UserName { get; }
    public string UserPassword { get; }

    public Credential(string userName, string userPassword)
    {
      if (string.IsNullOrWhiteSpace(userName))
      {
        throw new ArgumentException("Value can not be null or empty", nameof(userName));
      }

      if (string.IsNullOrWhiteSpace(userPassword))
      {
        throw new ArgumentException("Value can not be null or empty", nameof(userName));
      }
      
      UserName = userName;
      UserPassword = userPassword;
    }

    public static bool TryParse(string line, string delimiter, out Credential credential)
    {
      credential = default;
      const int validRowLength = 2;

      if (string.IsNullOrWhiteSpace(line)) return false;

      var row = line.Split(delimiter);
      if (row.Length != validRowLength) return false;

      var userName = row[0];
      var userPassword = row[1];

      if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(userPassword))
      {
        return false;
      }

      credential = new Credential(userName, userPassword);

      return true;
    }

    public override string ToString()
    {
      return $"{UserName},{UserPassword}";
    }

    public bool Equals(Credential? other)
    {
      if (other is null) return false;
      if (ReferenceEquals(this, other)) return true;

      return UserName.Equals(other.UserName, StringComparison.OrdinalIgnoreCase)
             && UserPassword.Equals(other.UserPassword, StringComparison.Ordinal);
    }

    public override bool Equals(object? obj)
    {
      if (obj is null) return false;
      if (ReferenceEquals(this, obj)) return true;

      return obj.GetType() == GetType() && Equals((Credential)obj);
    }

    public override int GetHashCode()
    {
      return HashCode.Combine(UserName.ToLowerInvariant(), UserPassword);
    }

    public static bool operator ==(Credential? left, Credential? right)
    {
      return Equals(left, right);
    }

    public static bool operator !=(Credential? left, Credential? right)
    {
      return !Equals(left, right);
    }
  }
}