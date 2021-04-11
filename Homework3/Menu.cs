using System;

namespace start
{
    public static class Menu
    {
        public static void Run()
        {
            Console.WriteLine("Please choose:");
            Console.WriteLine("1. Login.");
            Console.WriteLine("2. Register new user.");
            Console.WriteLine("3. Exit program.");

            switch (ReturnValidUserInput())
            {
                case 1:
                    Login();
                    break;
                case 2:
                    Register();
                    break;
                case 3:
                    Quit();
                    break;
                default:
                    break;
            }
        }

        public static int ReturnValidUserInput()
        {
            int validInput;

            do
            {
                char keyInput = Console.ReadKey(true).KeyChar;

                int.TryParse(keyInput.ToString(), out validInput);
            } while (validInput < 1 || validInput > 3);

            return validInput;
        }

        private static void Login()
        {
            Console.Write("Please enter username: ");
            string userName = Console.ReadLine();

            Console.Write("Please enter password: ");
            string password = Console.ReadLine();

            User user = new User { Name = userName, Password = password };

            if (IsUserAuthorized(user))
            {
                Console.WriteLine("Hello!");
            }
            else
            {
                Console.WriteLine("Wrong username or password.");
            }
        }

        private static bool IsUserAuthorized(User user)
        {
            if (DataAccess.GetUsers().Contains(user))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static void Register()
        {
            Console.Write("Enter username: ");
            string userName = Console.ReadLine();

            if (DataAccess.DoesUserExits(userName))
            {
                throw new DuplicateUserCredentialsException("Username already taken. Please try again.", new Exception());
            }
            else
            {
                Console.Write("Enter password: ");

                string password = Console.ReadLine();

                User newUser = new User { Name = userName, Password = password };
                DataAccess.AddUserToFile(newUser);
                Console.WriteLine("User added.");

                Console.WriteLine(Environment.NewLine);
                Menu.Run();
            }
        }

        private static void Quit()
        {
            Console.WriteLine("Exiting program. Goodbye!");
        }
    }

    internal class DuplicateUserCredentialsException : Exception
    {
        public DuplicateUserCredentialsException(string message, Exception innerException) : base(message, innerException)
        {
            Console.WriteLine(message);
            Console.WriteLine(Environment.NewLine);
            Menu.Run();
        }
    }
}