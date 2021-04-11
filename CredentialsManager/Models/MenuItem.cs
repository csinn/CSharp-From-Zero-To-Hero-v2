using System;

namespace CredentialsManager.Models
{
  public class MenuItem
  {
    public uint ItemId { get; }
    public string? Label { get; }
    public ConsoleKey? ConsoleKey { get; }
    public Action? Action { get; }

    public MenuItem()
    {
    }

    public MenuItem(uint itemId, string label, ConsoleKey? consoleKey, Action action)
    {
      ItemId = itemId;
      Label = string.IsNullOrWhiteSpace(label)
        ? throw new ArgumentException("Value can not be null or empty!", nameof(label))
        : label;
      ConsoleKey = consoleKey ?? throw new ArgumentNullException(nameof(label), "Value can not be null!");
      Action = action ?? throw new ArgumentNullException(nameof(label), "Value can not be null!");
    }

    public override string ToString()
    {
      return $"{ItemId}. {Label}";
    }
  }
}