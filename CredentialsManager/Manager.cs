using System;
using System.Collections.Generic;
using CredentialsManager.FilesExceptions;
using CredentialsManager.Models;

namespace CredentialsManager
{
  public static class Manager
  {
    private const string FieldDelimiter = ",";
    private const string CredentialsFile = "Users.txt";
    private static IList<Credentials> _credentials = new List<Credentials>();

    public static void Initialize()
    {
      _credentials = GetCredentials();

      CheckForDuplicates();
    }

    private static IList<Credentials> GetCredentials()
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
      for (var index = 0; index + 1 < _credentials.Count; index++)
      {
        var currentCredential = _credentials[index];
        var nextCredential = _credentials[index + 1];

        if (currentCredential.Equals(nextCredential))
        {
          throw new DuplicateUserCredentialsException("Duplicate users found!");
        }
      }
    }

    public static bool Login(Credentials credentials)
    {
      return _credentials.Contains(credentials);
    }

    public static void Register(Credentials credentials)
    {
      if (IsUserNameTaken(credentials))
      {
        throw new UserNameIsTakenException("User name is taken!");
      }

      Files.WriteLine(CredentialsFile, CreateString(credentials), true);
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