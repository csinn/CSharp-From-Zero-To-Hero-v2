using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CredentialsManager.Models
{
  public class MenuItem
  {
    public int ItemId { get; set; }
    public string Label { get; set; }
    public ConsoleKey ConsoleKey { get; set; }
    public Action Action { get; set; }

    public override string ToString()
    {
      return $"{ItemId}. {Label}";
    }
  }
}