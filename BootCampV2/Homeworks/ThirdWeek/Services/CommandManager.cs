using System;
using System.Collections.Generic;

namespace BootCampV2.Homeworks.ThirdWeek
{
    public class CommandManager
    {
        private readonly ICommand[] _commands;

        public CommandManager(ICommand[] commands)
        {
            _commands = commands;
        }

        public void DisplayComamnds()
        {
            Console.WriteLine("Commands: \n");

            for (int i = 0; i < _commands.Length; i++)
                Console.WriteLine($"({i}) {_commands[i].Description} \n");
        }

        public void ExecuteComamnd(string input)
        {
            string[] inputParts = input.Split(" ");

            foreach (var item in _commands)
            {
                if (inputParts[0].Equals(item.Prefix))
                {
                    List<string> parameters = new List<string>();

                    for (int i = 1; i < inputParts.Length; i++)
                    {
                        parameters.Add(inputParts[i]);
                    }

                    item.Execute(parameters);
                    break;
                }
            }
        }
    }
}
