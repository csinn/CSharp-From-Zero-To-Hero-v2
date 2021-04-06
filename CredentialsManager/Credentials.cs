using System;

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
        credentials[index] = ConvertToCredential(content[index]);
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

    public static void Register(string userName, string userPassword)
    {
      _credentials = GetCredentials();

      var credential = new[] { userName, userPassword };
      if (IsUserNameTaken(credential))
      {
        throw new UserNameIsTakenException("User name is taken!");
      }

      Files.WriteLine(CredentialsFile, ConvertToString(credential), true);
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

    private static string ConvertToString(string[] credential)
    {
      return string.Join(FieldDelimiter, credential);
    }

    private static string[] ConvertToCredential(string input)
    {
      return input.Split(FieldDelimiter);
    }

    public static bool Login(string userName, string userPassword)
    {
      _credentials = GetCredentials();

      var credential = new[] { userName, userPassword };
      foreach (var storedCredential in _credentials)
      {
        if (IsCredentialEqual(storedCredential, credential))
        {
          return true;
        }
      }

      return false;
    }

    private static bool IsCredentialEqual(string[] left, string[] right)
    {
      return left[0].Equals(right[0]) && left[1].Equals(right[1]);
    }
  }
}