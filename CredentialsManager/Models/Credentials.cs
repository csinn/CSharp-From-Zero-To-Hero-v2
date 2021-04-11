using System;

namespace CredentialsManager.Models
{
  public class Credentials : IEquatable<Credentials>, IComparable<Credentials>, IComparable
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

    public override string ToString()
    {
      return $"{UserName},{UserPassword}";
    }

    public bool Equals(Credentials? other)
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

      return obj.GetType() == GetType() && Equals((Credentials)obj);
    }

    public override int GetHashCode()
    {
      return HashCode.Combine(UserName.ToLowerInvariant(), UserPassword);
    }

    public static bool operator ==(Credentials? left, Credentials? right)
    {
      return Equals(left, right);
    }

    public static bool operator !=(Credentials? left, Credentials? right)
    {
      return !Equals(left, right);
    }

    public int CompareTo(Credentials? other)
    {
      if (ReferenceEquals(this, other)) return 0;
      if (ReferenceEquals(null, other)) return 1;
      return string.Compare(UserName, other.UserName, StringComparison.OrdinalIgnoreCase);
    }

    public int CompareTo(object? obj)
    {
      if (ReferenceEquals(null, obj)) return 1;
      if (ReferenceEquals(this, obj)) return 0;
      return obj is Credentials other
        ? CompareTo(other)
        : throw new ArgumentException($"Object must be of type {nameof(Credentials)}");
    }
  }
}