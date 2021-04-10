using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CredentialsManager.Models
{
  public class Menu
  {
    public string Header { get; set; }
    public IList<MenuItem> MenuItems { get; set; }

    public MenuItem ExitItem { get; set; }

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
        sb.Append(item.ToString());
        sb.AppendLine();
      }

      sb.Append(ExitItem.ToString());

      return sb.ToString();
    }
  }
}