using System;

namespace CredentialsManager.Models
{
  public readonly struct Credentials : IEquatable<Credentials>, IComparable<Credentials>, IComparable
  {
    public string UserName { get; }
    public string UserPassword { get; }

    public Credentials(string userName, string userPassword)
    {
      UserName = string.IsNullOrWhiteSpace(userName)
        ? throw new ArgumentException("Value can not be null or empty", nameof(userName))
        : userName;
      UserPassword = string.IsNullOrWhiteSpace(userName)
        ? throw new ArgumentException("Value can not be null or empty", nameof(userPassword))
        : userPassword;
    }

    public static bool TryParse(string line, string delimiter, out Credentials credentials)
    {
      credentials = default;
      const int validRowLength = 2;

      if (string.IsNullOrWhiteSpace(line)) return false;

      var row = line.Split(delimiter);
      if (row.Length != validRowLength) return false;

      var userName = row[0].Trim();
      var userPassword = row[1].Trim();

      if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(userPassword))
      {
        return false;
      }

      credentials = new Credentials(userName, userPassword);

      return true;
    }

    public bool Equals(Credentials other)
    {
      return UserName.Equals(other.UserName, StringComparison.OrdinalIgnoreCase)
             && UserPassword.Equals(other.UserPassword);
    }

    public override bool Equals(object? obj)
    {
      return obj is Credentials other && Equals(other);
    }

    public override int GetHashCode()
    {
      var hashCode = new HashCode();
      hashCode.Add(UserName, StringComparer.OrdinalIgnoreCase);
      hashCode.Add(UserPassword);
      return hashCode.ToHashCode();
    }

    public static bool operator ==(Credentials left, Credentials right)
    {
      return left.Equals(right);
    }

    public static bool operator !=(Credentials left, Credentials right)
    {
      return !left.Equals(right);
    }

    public int CompareTo(Credentials other)
    {
      return string.Compare(UserName, other.UserName, StringComparison.OrdinalIgnoreCase);
    }

    public int CompareTo(object? obj)
    {
      if (ReferenceEquals(null, obj)) return 1;
      return obj is Credentials other
        ? CompareTo(other)
        : throw new ArgumentException($"Object must be of type {nameof(Credentials)}");
    }

    public static bool operator <(Credentials left, Credentials right)
    {
      return left.CompareTo(right) < 0;
    }

    public static bool operator <=(Credentials left, Credentials right)
    {
      return left.CompareTo(right) <= 0;
    }

    public static bool operator >(Credentials left, Credentials right)
    {
      return left.CompareTo(right) > 0;
    }

    public static bool operator >=(Credentials left, Credentials right)
    {
      return left.CompareTo(right) >= 0;
    }
  }
}