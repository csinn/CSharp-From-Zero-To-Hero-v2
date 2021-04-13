using Homework3;
using System;

namespace start
{
    public class Menu
    {
        public readonly IUserInterface currentUI;

        private const int login = 1;
        private const int register = 2;
        private const int quit = 3;

        public Menu(IUserInterface userChoosenUI)
        {
            currentUI = userChoosenUI;
        }
        
        public void Run()
        {
            currentUI.PrintMenu();

            switch (ReturnValidUserInput())
            {
                case login:
                    Login();
                    break;
                case register:
                    Register();
                    break;
                case quit:
                    Quit();
                    break;
                default:
                    break;
            }
        }

        public int ReturnValidUserInput()
        {
            int validInput;

            do
            {
                validInput = currentUI.GetUserKeyInput();

            } while (validInput < 1 || validInput > 3);

            return validInput;
        }

        private void Login()
        {
            string userName = currentUI.GetUserTextInput("Please enter username: ");

            string password = currentUI.GetUserTextInput("Please enter password: ");

            User user = new User { Name = userName, Password = password };

            if (IsUserAuthorized(user))
            {
                currentUI.PrintTextToUI("Hello!");
            }
            else
            {
                currentUI.PrintTextToUI("Wrong username or password.");
            }
        }

        private bool IsUserAuthorized(User user)
        {
            if (UserFileLogic.GetUsers().Contains(user))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void Register()
        {
            string userName = currentUI.GetUserTextInput("Enter username: ");

            if (UserFileLogic.DoesUserExits(userName))
            {
                throw new DuplicateUserCredentialsException("Username already taken. Please try again.", new Exception(), this);
            }
            else
            {
                string password = currentUI.GetUserTextInput("Enter password: ");

                User newUser = new User { Name = userName, Password = password };
                UserFileLogic.AddUserToFile(newUser);
                currentUI.PrintTextToUI("User added.");

                Console.WriteLine(Environment.NewLine);
                Run();
            }
        }

        private void Quit()
        {
            currentUI.PrintTextToUI("Exiting program. Goodbye!");
        }
    }

    internal class DuplicateUserCredentialsException : Exception
    {
        public DuplicateUserCredentialsException(string message, Exception innerException, Menu currentMenu) : base(message, innerException)
        {
            currentMenu.currentUI.PrintTextToUI("Exiting program. Goodbye!");
            currentMenu.Run();
        }
    }
}