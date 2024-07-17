namespace Dependency;

public class Log : ILog
{
    public void Logging(string message) => Console.WriteLine(message);
}