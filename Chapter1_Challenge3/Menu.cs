using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter1_Challenge3
{
    public static class Menu
    {
        public static void ShowMenu()
        {
            Console.WriteLine("    Menu   ");
            Console.WriteLine();
            Console.WriteLine("1) Register");
            Console.WriteLine("2) Login"); 
            Console.WriteLine("3) Exit programm");
            Console.WriteLine();
            Console.Write("Your Choice: "); 
        }

        public static int InputAndValidateChoice()
        {
           var valid = int.TryParse(Console.ReadLine(), out int choice);

            if (!valid && (choice < 1 || choice >3))
            {
                Console.WriteLine("Choice must between the 1 and 3");
                CustomMenu(); 
            }

            return choice; 

        }

        public static void ExecMenuChoice(int choice)
        {
            switch (choice)
            {
                case 1: Authentication.Register();
                    break;
                case 2: Authentication.Login("roelof", "secret");
                    break; 

                default: Stop();
                    break; 
            }
        }

        private static void Stop()
        {
            System.Environment.Exit(1);
        }

        public static void CustomMenu()
        {
            ShowMenu();
            var choice = InputAndValidateChoice();
            ExecMenuChoice(choice); 

            
        }
    }
}
