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
    private const string RegistrationSuccessfulMessage = "Registration successful!";

    private static bool _isExitInvoked;

    public static void Run()
    {
      while (!_isExitInvoked)
      {
        try
        {
          Manager.Initialize();
          PrintMenu();
          GetUserInput();
        }
        catch (MyFileNotFoundException ex)
        {
          Console.WriteLine(ex.Message);
          break;
        }
        catch (DuplicateUserCredentialsException ex)
        {
          Console.WriteLine(ex.Message);
          Pause("Press ENTER to exit..");
          break;
        }
        catch (UserNameIsTakenException ex)
        {
          Console.WriteLine(ex.Message);
          Pause();
        }
      }
    }

    private static IList<MenuItem> GetMenuItems()
    {
      return new List<MenuItem>
      {
        new MenuItem { ItemId = 1, Label = "Login", Action = Login, ConsoleKey = ConsoleKey.D1 },
        new MenuItem { ItemId = 2, Label = "Register", Action = Register, ConsoleKey = ConsoleKey.D2 }
      };
    }

    private static Menu CreateMenu()
    {
      return new Menu
      {
        Header = "Credentials Manager",
        MenuItems = GetMenuItems(),
        ExitItem = new MenuItem { ItemId = 3, Label = "Exit", Action = Exit, ConsoleKey = ConsoleKey.D3 }
      };
    }

    private static void ConsoleInit(string header)
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

    private static void GetUserInput()
    {
      ConsoleKey pressedKey;
      do
      {
        pressedKey = Console.ReadKey(true).Key;
        if (!MainMenu.IsValidKey(pressedKey)) continue;

        ConsoleInit(MainMenu[pressedKey].Label);
        MainMenu[pressedKey].Action();
        Pause();
        break;
      } while (pressedKey != MainMenu.ExitItem.ConsoleKey);
    }

    private static void Login()
    {
      var userName = PromptString("Username: ");
      var userPassword = PromptString("Password: ", false);

      var isLoginSuccessful = Manager.Login(new Credentials(userName, userPassword));
      var statusMessage = isLoginSuccessful ? LoginMessage : FailedLoginMessage;

      Console.WriteLine(statusMessage);
    }

    private static void Register()
    {
      var userName = PromptString("Username: ");
      var userPassword = PromptString("Password: ", false);

      Manager.Register(new Credentials(userName, userPassword));
      Console.WriteLine(RegistrationSuccessfulMessage);
    }

    private static void Exit()
    {
      _isExitInvoked = true;
    }

    private static string PromptString(string message)
    {
      string userInput;
      do
      {
        Console.Write(message);
        userInput = Console.ReadLine() ?? string.Empty;
      } while (string.IsNullOrWhiteSpace(userInput));

      return userInput;
    }

    private static string PromptString(string message, bool isKeyVisible)
    {
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

    private static void Pause(string message = "Press ENTER to continue...")
    {
      Console.WriteLine(message);
      Console.ReadLine();
    }
  }
}