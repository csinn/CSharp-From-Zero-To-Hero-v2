using CredentialsManager.FilesExceptions;
using CredentialsManager.Models;
using System.Collections.Generic;

namespace CredentialsManager
{
  public static class Manager
  {
    private const string FieldDelimiter = ",";
    private const string CredentialsFile = "Users.txt";
    private static List<Credentials> _credentials = new();

    public static void Initialize()
    {
      _credentials = GetCredentials();

      CheckForDuplicates();
    }

    private static List<Credentials> GetCredentials()
    {
      var content = Files.ReadAllLines(CredentialsFile);
      var credentials = new List<Credentials>();

      foreach (var row in content)
      {
        var isValidCredential = Credentials.TryParse(row, FieldDelimiter, out var credential);
        if (isValidCredential)
        {
          credentials.Add(credential);
        }
      }

      return credentials;
    }

    private static void CheckForDuplicates()
    {
      _credentials.Sort();

      for (var index = 0; index + 1 < _credentials.Count; index++)
      {
        var currentCredential = _credentials[index];
        var nextCredential = _credentials[index + 1];

        if (currentCredential.CompareTo(nextCredential).Equals(0))
        {
          throw new DuplicateUserCredentialsException("Duplicate user names found!");
        }
      }
    }

    public static bool Login(Credentials credentials)
    {
      return _credentials.Contains(credentials);
    }

    public static bool Register(Credentials credentials)
    {
      if (!IsUserNameTaken(credentials))
      {
        Files.WriteLine(CredentialsFile, CreateString(credentials), true);
        return true;
      }

      return false;
    }

    private static bool IsUserNameTaken(Credentials credentials)
    {
      foreach (var storedCredential in _credentials)
      {
        if (storedCredential.UserName.Equals(credentials.UserName))
        {
          return true;
        }
      }

      return false;
    }

    private static string CreateString(Credentials credentials)
    {
      return $"{credentials.UserName}{FieldDelimiter}{credentials.UserPassword}";
    }
  }
}