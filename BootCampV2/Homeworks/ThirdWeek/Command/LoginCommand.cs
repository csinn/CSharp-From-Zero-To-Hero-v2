using System;
using System.Collections.Generic;

namespace BootCampV2.Homeworks.ThirdWeek.Command
{
    public class LoginCommand : ICommand
    {
        private readonly UserFileManager _userFileManager;

        private string _prefix = "-l";

        public string Prefix
        {
            get
            {
                return _prefix;
            }

            set
            {
                _prefix = value;
            }
        }

        private string _description = "-l (Username) (Password)";

        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }

        public LoginCommand(UserFileManager userFileManager)
        {
            _userFileManager = userFileManager;
        }

        public void Execute(List<string> parameter)
        {
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
