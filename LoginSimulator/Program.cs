using System;

namespace LoginSimulator
{
  internal static class Program
  {
    private static void Main(string[] args)
    {
      TestCredentials();
    }

    private static void TestCredentials()
    {
      const string storedUserName = "tEsT";
      const string storedUserPassword = "1234";
      
      const string successfulLoginMessage = "Logged in!";
      
      var userName = PromptString("Username: ");
      var userPassword = PromptString("Password: ");

      var isValidCredential = string.Equals(userName, storedUserName, StringComparison.OrdinalIgnoreCase) &&
                              string.Equals(userPassword, storedUserPassword);
      if (isValidCredential)
      {
        Console.WriteLine(successfulLoginMessage);
      }
    }
    
    private static string PromptString(string message, bool isKeyVisible = false)
    {
      if (string.IsNullOrWhiteSpace(message))
      {
        throw new ArgumentException("Value cannot be null or empty.", nameof(message));
      }
      
      Console.Write(message);
      
      var output = "";
      while (true)
      {
        var pressedKey = Console.ReadKey(!isKeyVisible);
        if (pressedKey.Key == ConsoleKey.Enter)
        {
          break;
        }

        output += pressedKey.KeyChar;
      }

      Console.WriteLine();

      return output;
    }
  }
}
