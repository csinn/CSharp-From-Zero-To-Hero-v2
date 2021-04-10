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
    private static IList<Credential> _credentials = new List<Credential>();

    public static void Initialize()
    {
      _credentials = GetCredentials();

      CheckForDuplicates();
    }

    private static IList<Credential> GetCredentials()
    {
      var content = Files.ReadAllLines(CredentialsFile);
      var credentials = new List<Credential>();

      foreach (var row in content)
      {
        var isValidCredential = Credential.TryParse(row, FieldDelimiter, out var credential);
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

    public static bool Login(Credential credential)
    {
      return _credentials.Contains(credential);
    }

    public static void Register(Credential credential)
    {
      if (IsUserNameTaken(credential))
      {
        throw new UserNameIsTakenException("User name is taken!");
      }

      Files.WriteLine(CredentialsFile, CreateString(credential), true);
    }

    private static bool IsUserNameTaken(Credential credential)
    {
      foreach (var storedCredential in _credentials)
      {
        if (storedCredential.UserName.Equals(credential.UserName))
        {
          return true;
        }
      }

      return false;
    }

    private static string CreateString(Credential credential)
    {
      return $"{credential.UserName}{FieldDelimiter}{credential.UserPassword}";
    }
  }
}