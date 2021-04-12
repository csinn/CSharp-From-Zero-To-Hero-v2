using System;
using System.Collections.Generic;
using CredentialsManager.FilesExceptions;
using CredentialsManager.Models;

namespace CredentialsManager
{
  public static class App
  {
    private static readonly Menu MainMenu = CreateMenu();

    private const string Header = "Credentials Manager";
    private const string LoginMessage = "Welcome";
    private const string FailedLoginMessage = "Invalid credentials!";
    private const string RegisterMessage = "Registration succesfful!";
    private const string FailedRegisterMessage = "User name is taken!";
    private const string InvalidOptionMessage = "Not a valid option!";

    public static void Run()
    {
      while (true)
      {
        try
        {
          Manager.Initialize();
          PrintMenu();
          ExecuteUserRequest();
        }
        catch (MyFileNotFoundException ex)
        {
          Console.WriteLine(ex.Message);
          Pause("Press ENTER to exit..");
          break;
        }
        catch (DuplicateUserCredentialsException ex)
        {
          Console.WriteLine(ex.Message);
          Pause("Press ENTER to exit..");
          break;
        }
      }
    }

    private static IList<MenuItem> GetMenuItems()
    {
      return new List<MenuItem>
      {
        new MenuItem (1, "Login",ConsoleKey.D1, Login ),
        new MenuItem (2, "Register",ConsoleKey.D2, Register ),
      };
    }

    private static Menu CreateMenu()
    {
      return new Menu(Header, GetMenuItems(), new MenuItem(3, "Exit", ConsoleKey.D3, Exit));
    }

    private static void ConsoleInit(string? header)
    {
      Console.CursorVisible = false;
      Console.Clear();
      Console.WriteLine(header);
      Console.WriteLine();
    }

    private static void PrintMenu()
    {
      ConsoleInit(Header);

      Console.WriteLine(MainMenu.ToString());
    }

    private static void ExecuteUserRequest()
    {
      ConsoleKey pressedKey;
      do
      {
        pressedKey = Console.ReadKey(true).Key;
        if (!MainMenu.IsValidKey(pressedKey))
        {
          Console.WriteLine(InvalidOptionMessage);
          Pause();
          return;
        }

        ConsoleInit(MainMenu[pressedKey].Label);
        MainMenu[pressedKey].Action?.Invoke();
        Pause();
        return;
      } while (pressedKey != MainMenu.ExitItem.ConsoleKey);
    }

    private static void Login()
    {
      var userName = PromptString("Username: ");
      var userPassword = PromptString("Password: ");

      var credentials = new Credentials(userName, userPassword);
      var isLoginSuccessful = Manager.Login(credentials);
      var statusMessage = isLoginSuccessful ? $"{LoginMessage} {credentials.UserName}!" : FailedLoginMessage;

      Console.WriteLine(statusMessage);
    }

    private static void Register()
    {
      var userName = PromptString("Username: ");
      var userPassword = PromptString("Password: ");

      var isRegisterSuccessful = Manager.Register(new Credentials(userName, userPassword));
      var statusMessage = isRegisterSuccessful ? RegisterMessage : FailedRegisterMessage;
      Console.WriteLine(statusMessage);
    }

    private static void Exit()
    {
      Environment.Exit(0);
    }

    private static string PromptString(string message)
    {
      string? userInput;
      do
      {
        Console.Write(message);
        userInput = Console.ReadLine();
      } while (string.IsNullOrWhiteSpace(userInput));

      return userInput;
    }

    private static void Pause(string message = "Press ENTER to continue...")
    {
      Console.WriteLine(message);
      Console.ReadLine();
    }
  }
}