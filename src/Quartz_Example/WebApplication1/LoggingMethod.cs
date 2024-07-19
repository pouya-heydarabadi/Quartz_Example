using Quartz;

namespace WebApplication1;

public class LoggingMethod(ILogger<LoggingMethod> logger):IJob
{
    public Task Execute(IJobExecutionContext context)
    {
        logger.LogInformation($"Log time {DateTime.Now}");
        return Task.CompletedTask;
    }
}