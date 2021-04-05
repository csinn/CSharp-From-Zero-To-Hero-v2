using System;

namespace CredentialsManager
{
  internal static class Program
  {
    private static void Main(string[] args)
    {
      try
      {
        RegisterDemo();
      }
      catch (DuplicateUserCredentialsException ex)
      {
        Console.WriteLine(ex.Message);
      }

      LoginDemo();
    }

    private static void RegisterDemo()
    {
      var userName = "gregory";
      var userPassword = "1234";

      Credentials.Register(userName, userPassword);
    }

    private static void LoginDemo()
    {
      var userName = "test";
      var userPassword = "1234";
      var loginMessage = "Hello!";

      var isLoginSuccessful = Credentials.Login(userName, userPassword);
      if (isLoginSuccessful) Console.WriteLine(loginMessage);
    }
  }
}