using Homework3;

namespace start
{
    class Program
    {
        static void Main(string[] args)
        {
            IUserInterface consoleUI = new ConsoleUI();

            Menu menu = new Menu(consoleUI);
            menu.Run();
        }
    }
}
