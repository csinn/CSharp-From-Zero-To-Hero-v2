using System;

namespace CredentialsManager
{
  public static class App
  {
    private static readonly string[] _menuItems;
    private static readonly Action[] _menuActions;
    private static readonly ConsoleKey[] _menuKeys;

    private const string Header = "Credentials Manager";
    private const string LoginMessage = "Welcome";

    static App()
    {
      _menuItems = GetMenuItems();
      _menuActions = GetMenuActions();
      _menuKeys = GetMenuKeys();
    }

    public static void Run()
    {
      while (true)
      {
        try
        {
          Credentials.Initialize();
          PrintMenu();
          GetUserInput();
        }
        catch (DuplicateUserCredentialsException ex)
        {
          Console.WriteLine(ex.Message);
          Pause("Press ENTER to exit...");
          break;
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
      return new ConsoleKey[] { ConsoleKey.D1, ConsoleKey.D2, ConsoleKey.D3 };
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

      for (var index = 0; index < _menuItems.Length; index++)
      {
        var item = $"{index + 1}. {_menuItems[index]}";
        Console.WriteLine(item);
      }
    }

    private static void GetUserInput()
    {
      ConsoleKey pressedKey;
      var exitKeyIndex = Array.IndexOf(_menuItems, "Exit");
      do
      {
        pressedKey = Console.ReadKey(true).Key;
        var keyToIndex = Array.IndexOf(_menuKeys, pressedKey);

        var isValidKey = keyToIndex >= 0 && keyToIndex < _menuActions.Length;
        if (isValidKey)
        {
          ConsoleInit(_menuItems[keyToIndex]);
          Invoke(_menuActions[keyToIndex]);
          Pause();
        }
        return;
      } while (pressedKey != _menuKeys[exitKeyIndex]);
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
      Environment.Exit(0);
    }

    private static void Invoke(Action action)
    {
      action();
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