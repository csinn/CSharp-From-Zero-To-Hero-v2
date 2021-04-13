namespace Homework3
{
    public interface IUserInterface
    {
        public void PrintMenu();
        public int GetUserKeyInput();
        public string GetUserTextInput(string message);
        public void PrintTextToUI(string message);
    }
}