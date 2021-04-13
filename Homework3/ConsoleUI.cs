using System;
using System.Collections.Generic;
using System.Text;

namespace Homework3
{
    public class ConsoleUI : IUserInterface
    {
        public void PrintMenu()
        {
            Console.WriteLine("Please choose:");
            Console.WriteLine("1. Login.");
            Console.WriteLine("2. Register new user.");
            Console.WriteLine("3. Exit program.");
        }

        public int GetUserKeyInput()
        {
            char keyInput = Console.ReadKey(true).KeyChar;

            int.TryParse(keyInput.ToString(), out int validInput);

            return validInput;
        }

        public string GetUserTextInput(string message)
        {
            Console.Write(message);

            return Console.ReadLine();
        }

        public void PrintTextToUI(string message)
        {
            Console.WriteLine(message);
        }
    }
}
