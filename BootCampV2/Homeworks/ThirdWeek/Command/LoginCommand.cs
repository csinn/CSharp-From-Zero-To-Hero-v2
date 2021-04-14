using System;
using System.Collections.Generic;


namespace BootCampV2.Homeworks.ThirdWeek.Command
{
    public class LoginCommand : ICommand
    {
        private readonly UserFileManager _userFileManager;

        public string Prefix { get; } = "-l";

        public string Description { get; } = "-l (Username) (Password)";

        public LoginCommand(UserFileManager userFileManager)
        {
            _userFileManager = userFileManager;
        }

        public void Execute(List<string> parameter)
        {
            if (parameter.Count < 2)
                throw new ArgumentException();

            LoginResult result = _userFileManager.Login(parameter[0], parameter[1], out Account account);

            switch (result)
            {
                case LoginResult.AccountWithUsernameDontExists:
                    Console.WriteLine("Cant find account with passed username");
                    break;
                case LoginResult.InvalidPassword:
                    Console.WriteLine("Wrong password");
                    break;
                case LoginResult.Success:
                    Console.WriteLine($"Weclone {account.Username}");
                    break;
            }
        }
    }
}
