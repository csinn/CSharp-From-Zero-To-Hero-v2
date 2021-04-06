using System;
using CredentialsManager.FilesExceptions;

namespace CredentialsManager
{
  public static class App
  {
    private static readonly string[] MenuItems;
    private static readonly Action[] MenuActions;
    private static readonly ConsoleKey[] MenuKeys;

    private const string Header = "Credentials Manager";
    private const string LoginMessage = "Welcome";
    
    private static bool _isExitCalled;

    static App()
    {
      MenuItems = GetMenuItems();
      MenuActions = GetMenuActions();
      MenuKeys = GetMenuKeys();
    }

    public static void Run()
    {
      while (!_isExitCalled)
      {
        try
        {
          Credentials.Initialize();
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
          Pause("Press ENTER to exit...");
          break;
        }
        catch (UserNameIsTakenException ex)
        {
          Console.WriteLine(ex.Message);
          Pause();
        }
      }
    }

    private static string[] GetMenuItems()
    {
      return new[] { "Login", "Register", "Exit" };
    }

    private static Action[] GetMenuActions()
    {
      return new Action[] { Login, Register, Exit };
    }

    private static ConsoleKey[] GetMenuKeys()
    {
      return new[] { ConsoleKey.D1, ConsoleKey.D2, ConsoleKey.D3 };
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

      for (var index = 0; index < MenuItems.Length; index++)
      {
        var item = $"{index + 1}. {MenuItems[index]}";
        Console.WriteLine(item);
      }
    }

    private static void GetUserInput()
    {
      ConsoleKey pressedKey;
      var exitKeyIndex = Array.IndexOf(MenuItems, "Exit");
      do
      {
        pressedKey = Console.ReadKey(true).Key;
        var keyToIndex = Array.IndexOf(MenuKeys, pressedKey);

        var isValidKey = keyToIndex >= 0 && keyToIndex < MenuActions.Length;
        if (!isValidKey) continue;
        
        ConsoleInit(MenuItems[keyToIndex]);
        Invoke(MenuActions[keyToIndex]);
        
        Pause();
        break;
      } while (pressedKey != MenuKeys[exitKeyIndex]);
    }
    
    private static void Invoke(Action action)
    {
      action();
    }
    
    private static void Login()
    {
      var userName = PromptString("Username: ", true);
      var userPassword = PromptString("Password: ");

      var isLoginSuccessful = Credentials.Login(userName, userPassword);
      if (isLoginSuccessful)
      {
        Console.WriteLine(LoginMessage);
      }
    }

    private static void Register()
    {
      var userName = PromptString("Username: ", true);
      var userPassword = PromptString("Password: ");

      Credentials.Register(userName, userPassword);
    }

    private static void Exit()
    {
      _isExitCalled = true;
    }

    private static string PromptString(string message, bool isKeyVisible = false)
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