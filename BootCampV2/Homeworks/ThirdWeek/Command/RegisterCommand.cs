using System;
using System.Collections.Generic;
using System.Text;


namespace BootCampV2.Homeworks.ThirdWeek.Command
{
    public class RegisterCommand : ICommand
    {
        private readonly UserFileManager _userFileManager;

        private string _prefix = "-r";

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

        private string _description = "-r (Username) (Password)";

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

        public RegisterCommand(UserFileManager userFileManager)
        {
            _userFileManager = userFileManager;
        }

        public void Execute(List<string> parameter)
        {
            RegistrationResult registrationResult = _userFileManager.Register(parameter[0], parameter[1], parameter[2]);

            switch (registrationResult)
            {
                case RegistrationResult.InvalidUsername:
                    Console.WriteLine("Username already exists");
                    break;
                case RegistrationResult.NotMatchingPassword:
                    Console.WriteLine("Passwords dont match");
                    break;
                case RegistrationResult.Success:
                    Console.WriteLine("Done");
                    break;
            }
        }
    }
}
