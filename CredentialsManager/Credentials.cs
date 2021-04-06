using System;
using CredentialsManager.FilesExceptions;

namespace CredentialsManager
{
  public static class Credentials
  {
    private const char FieldDelimiter = ',';
    private const string CredentialsFile = "Users.txt";
    private static string[][] _credentials = Array.Empty<string[]>();

    public static void Initialize()
    {
      _credentials = GetCredentials();
      
      Array.Sort(_credentials, (currentCredential, nextCredential)
        => string.CompareOrdinal(currentCredential[0], nextCredential[0]));
      
      CheckForDuplicates();
    }

    private static string[][] GetCredentials()
    {
      var content = Files.ReadAllLines(CredentialsFile);
      var credentials = new string[content.Length][];

      for (var index = 0; index < credentials.Length; index++)
      {
        credentials[index] = CreateCredential(content[index]);
      }

      return credentials;
    }

    private static void CheckForDuplicates()
    {
      for (var index = 0; index + 1 < _credentials.Length; index++)
      {
        var currentCredential = _credentials[index];
        var nextCredential = _credentials[index + 1];

        if (IsUserNameEqual(currentCredential, nextCredential))
        {
          throw new DuplicateUserCredentialsException("Duplicate users found!");
        }
      }
    }

    public static bool Login(string userName, string userPassword)
    {
      UpdateCredentials();

      var credential = CreateCredential(userName, userPassword);
      foreach (var storedCredential in _credentials)
      {
        if (IsCredentialEqual(storedCredential, credential))
        {
          return true;
        }
      }

      return false;
    }

    public static void Register(string userName, string userPassword)
    {
      UpdateCredentials();

      var credential = CreateCredential(userName, userPassword);
      if (IsUserNameTaken(credential))
      {
        throw new UserNameIsTakenException("User name is taken!");
      }

      Files.WriteLine(CredentialsFile, CreateString(credential), true);
    }

    private static void UpdateCredentials()
    {
      _credentials = GetCredentials();
    }

    private static bool IsUserNameEqual(string[] left, string[] right)
    {
      return left[0].Equals(right[0], StringComparison.OrdinalIgnoreCase);
    }

    private static bool IsUserNameTaken(string[] credential)
    {
      foreach (var storedCredential in _credentials)
      {
        if (IsUserNameEqual(credential, storedCredential))
        {
          return true;
        }
      }

      return false;
    }

    private static string CreateString(string[] credential)
    {
      return string.Join(FieldDelimiter, credential);
    }

    private static string[] CreateCredential(string input)
    {
      return input.Split(FieldDelimiter);
    }

    private static string[] CreateCredential(string userName, string userPassword)
    {
      return new[] {userName, userPassword};
    }

    private static bool IsCredentialEqual(string[] left, string[] right)
    {
      var isPasswordEqual = left[1].Equals(right[1]);
      
      return IsUserNameEqual(left, right) && isPasswordEqual;
    }
  }
}