using System;
using System.Collections.Generic;
using System.Text;

namespace CredentialsManager.Models
{
  public class Menu
  {
    public string Header { get; }
    public IList<MenuItem> MenuItems { get; }
    public MenuItem ExitItem { get; }

    public Menu(string header, IList<MenuItem> menuItems, MenuItem exitItem)
    {
      Header = header;
      MenuItems = menuItems;
      ExitItem = exitItem;
    }

    public bool IsValidKey(ConsoleKey consoleKey)
    {
      foreach (var item in MenuItems)
      {
        if (item.ConsoleKeys.Contains(consoleKey))
        {
          return true;
        }
      }

      return ExitItem.ConsoleKeys.Contains(consoleKey);
    }

    public MenuItem this[ConsoleKey consoleKey]
    {
      get
      {
        foreach (var item in MenuItems)
        {
          if (item.ConsoleKeys.Contains(consoleKey))
          {
            return item;
          }
        }

        if (ExitItem.ConsoleKeys.Contains(consoleKey)) return ExitItem;

        return null;
      }
    }

    public override string ToString()
    {
      var sb = new StringBuilder();

      foreach (var item in MenuItems)
      {
        sb.Append(item);
        sb.AppendLine();
      }

      sb.Append(ExitItem);

      return sb.ToString();
    }
  }
}