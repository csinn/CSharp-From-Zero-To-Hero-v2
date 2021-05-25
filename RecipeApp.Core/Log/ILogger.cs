namespace BootCamp.Chapter
{
    public interface ILogger
    {
        string LogMessage(LogLevel loglevel, string message);
    }
}
