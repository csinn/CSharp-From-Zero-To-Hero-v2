using System;
using System.Collections.Generic;

namespace CredentialsManager.Models
{
  public class MenuItem
  {
    public uint ItemId { get; }
    public string? Label { get; }
    public Action? Action { get; }
    public IList<ConsoleKey> ConsoleKeys { get; }

    public MenuItem()
    {
    }

    public MenuItem(uint itemId, string label, Action action, IList<ConsoleKey> consoleKeys)
    {
      ItemId = itemId;
      Label = label;
      Action = action;
      ConsoleKeys = consoleKeys;
    }

    public override string ToString()
    {
      return $"{ItemId}. {Label}";
    }
  }
}