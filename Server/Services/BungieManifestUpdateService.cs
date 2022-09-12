using BungieSharper.Client;
using System;

namespace ModReminder.Server.Services;

internal sealed class BungieManifestUpdateService : IHostedService
{
    private Timer? _timer;
    private readonly ILogger<BungieManifestUpdateService> _logger;
    private readonly BungieApiClient _client;
    private readonly HttpClient _httpClient;

    public BungieManifestUpdateService(ILogger<BungieManifestUpdateService> logger, BungieApiClient client, HttpClient httpClient)
    {
        _logger = logger;
        _client = client;
        _httpClient = httpClient;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        DownloadManifest(null);
        _timer = new Timer(DownloadManifest, null, getJobRunDelay(), TimeSpan.FromDays(7));
        return Task.CompletedTask;
    }
    
    public Task StopAsync(CancellationToken cancellationToken)
    {
        _timer?.Dispose();
        return Task.CompletedTask;
    }

    private static TimeSpan getJobRunDelay()
    {
        DateTime today = DateTime.Today.AddHours(17);
        // The (... + 7) % 7 ensures we end up with a value in the range [0, 6]
        int daysUntilTuesday = ((int) DayOfWeek.Tuesday - (int) today.DayOfWeek + 7) % 7;
        DateTime nextTuesday = today.AddDays(daysUntilTuesday);
        return nextTuesday - DateTime.Now;
    }
    private async void DownloadManifest(object? state)
    {
        var manifest = await _client.Api.Destiny2_GetDestinyManifest();
        
        if (File.Exists($@"SQLite_Manifests\world_content.sqlite"))
        {
            return;
        }

        _logger.LogInformation("Downloads new manifest file");

        using (var streamToReadFrom = await _httpClient.GetStreamAsync("https://www.bungie.net" + manifest.JsonWorldContentPaths["en"]))
        {
            string fileToWriteTo = $@"SQLite_Manifests\world_content.sqlite"; // add manifest version somehow _{manifest.Version}
            using (Stream streamToWriteTo = File.Open(fileToWriteTo, FileMode.Create))
            {
                await streamToReadFrom.CopyToAsync(streamToWriteTo);
            }
        }
    }
}
