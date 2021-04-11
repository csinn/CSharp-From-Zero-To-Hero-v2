using System;
using System.Collections.Generic;
using System.Text;


namespace BootCampV2.Homeworks.ThirdWeek.Command
{
    public class ExitCommand : ICommand
    {
        public string Prefix { get; } = "-e";

        public string Description { get; } = "Exit";

        public void Execute(List<string> parameter)
        {
            Environment.Exit(0);
        }
    }
}
