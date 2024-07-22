namespace Logs;

public class CustomLogs
{
    ILogger logger;

    public CustomLogs(ILogger logger)
    {
        this.logger = logger;
    }

    public void PrintLog(string message) => logger.Log(message);

}