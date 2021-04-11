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
      Header = string.IsNullOrWhiteSpace(header)
        ? throw new ArgumentException("Value can not be null or empty!", nameof(header))
        : header;
      MenuItems = menuItems ?? throw new ArgumentNullException(nameof(menuItems));
      ExitItem = exitItem ?? throw new ArgumentNullException(nameof(exitItem));
    }

    public bool IsValidKey(ConsoleKey consoleKey)
    {
      foreach (var item in MenuItems)
      {
        if (item.ConsoleKey.Equals(consoleKey))
        {
          return true;
        }
      }

      return consoleKey.Equals(ExitItem.ConsoleKey);
    }

    public MenuItem this[ConsoleKey consoleKey]
    {
      get
      {
        foreach (var item in MenuItems)
        {
          if (item.ConsoleKey.Equals(consoleKey))
          {
            return item;
          }
        }

        if (consoleKey.Equals(ExitItem.ConsoleKey)) return ExitItem;

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