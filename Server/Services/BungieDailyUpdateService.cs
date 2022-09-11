using System.Globalization;

namespace ModReminder.Server.Services;

public class BungieDailyUpdateService : IHostedService
{
    private Timer _timer;


    public Task StartAsync(CancellationToken cancellationToken)
    {
        _timer = new Timer(DoWork, null, getJobRunDelay(), TimeSpan.FromDays(1));
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _timer.Dispose();
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
        Console.WriteLine(" timer fired me ");
    }

}
