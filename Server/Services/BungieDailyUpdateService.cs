using System.Globalization;

namespace ModReminder.Server.Services;

public sealed class BungieDailyUpdateService : IHostedService
{
    private Timer? _timer;
    private readonly ILogger<BungieDailyUpdateService> _logger;

    public BungieDailyUpdateService(ILogger<BungieDailyUpdateService> logger)
    {
        _logger = logger;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _timer = new Timer(DoWork, null, getJobRunDelay(), TimeSpan.FromDays(1));
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _timer?.Dispose();
        return Task.CompletedTask;
    }


    private static TimeSpan getJobRunDelay()
    {
        TimeSpan scheduledParsedTime = TimeSpan.Parse("17:00");
        TimeSpan curentTimeOftheDay = DateTime.Now.TimeOfDay;
        TimeSpan delayTime =
            scheduledParsedTime >= curentTimeOftheDay
            ? scheduledParsedTime - curentTimeOftheDay
            : new TimeSpan(24, 0, 0) - curentTimeOftheDay + scheduledParsedTime;
        return delayTime;
    }
    private void DoWork(object? state)
    {
        _logger.LogInformation("hi so i am a daily update service");
    }

}
