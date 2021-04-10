using BootCampV2.Homeworks.SecondWeek;
using BootCampV2.Homeworks.ThirdWeek;
using BootCampV2.Homeworks.ThirdWeek.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BootCampV2
{
    public class Core
    {
        static public void Main(string[] args)
        {
            string path = @".\User.txt";

            UserFileManager userFileManager = new UserFileManager(path);

            ICommand[] commands = {
                new LoginCommand(userFileManager),
                new RegisterCommand(userFileManager),
                new ExitCommand()
            };

            CommandManager commandManager = new CommandManager(commands);

            commandManager.DisplayComamnds();

            string command = Console.ReadLine();

            commandManager.ExecuteComamnd(command);
        }       
    }
}
