namespace Logs;

public class LogWriter : ILogger
{
    public async void Log(string text)
    {
        using(StreamWriter streamWriter = new("log.txt", true))
        {
            await streamWriter.WriteLineAsync(text);
        }
    }
}