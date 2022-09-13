using BungieSharper.Client;
using BungieSharper.Entities.Common.Models;
using BungieSharper.Entities.Destiny.Config;
using DotNetBungieAPI;
using DotNetBungieAPI.Clients;
using DotNetBungieAPI.Service.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Http.Headers;

namespace ModReminder.Server.Services;

internal sealed class BungieManifestUpdateService : IHostedService
{
    private Timer? _timer;
    private readonly ILogger<BungieManifestUpdateService> _logger;
    private readonly BungieApiClient _client;
    private readonly HttpClient _httpClient;
    private readonly IBungieClient bungieClient;

    public BungieManifestUpdateService(ILogger<BungieManifestUpdateService> logger, BungieApiClient client, HttpClient httpClient, IBungieClient bungieClient)
    {
        _logger = logger;
        _client = client;
        _httpClient = httpClient;
        this.bungieClient = bungieClient;
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
        if (today.DayOfWeek == DayOfWeek.Tuesday && today.Hour >= 17) daysUntilTuesday = 7;
        DateTime nextTuesday = today.AddDays(daysUntilTuesday);
        return nextTuesday - DateTime.Now;
    }
    private async void DownloadManifest(object? state)
    {
        var manifest = await _client.Api.Destiny2_GetDestinyManifest();
        var filePath = $@"SQLite_Manifests";

        if (File.Exists(filePath + @"\world_content_" + manifest.Version))
        {
            _logger.LogInformation($"Manifest already downloaded at: {filePath + @"\world_content_" + manifest.Version}");
            return;
        }

        _logger.LogInformation("Downloads new manifest file");


        await DownloadSqliteDatabase("world_content_" + manifest.Version, filePath, manifest.MobileWorldContentPaths["en"]);
        //await DownloadSqliteDatabases("world_content_" + manifest.Version, filePath, manifest.MobileWorldContentPaths);

        //await UseDotNetBungieApi();
    }

    private async Task DownloadSqliteDatabase(string propertyName, string path, string dbUrl)
    {
        _logger.LogInformation("Started loading {PropertyName}", propertyName);
        var rootDirectoryPath = Path.Combine(path, propertyName);
        EnsureDirectoryExists(rootDirectoryPath);

        var filePath = Path.Combine(path, propertyName, Path.GetFileName(dbUrl));
        if (!File.Exists(filePath))
            await DownloadAndUnpackSqliteFile(filePath, dbUrl);
        else
            _logger.LogInformation("File already exists, skipping");


        _logger.LogInformation("Finished loading {PropertyName}", propertyName);
    }

    internal static void EnsureDirectoryExists(string directoryPath)
    {
        if (!Directory.Exists(directoryPath))
            Directory.CreateDirectory(directoryPath);
    }

    private async Task DownloadAndUnpackSqliteFile(string filePath, string dbSourcePath)
    {
        _logger.LogInformation("Downloading and writing db file: {FilePath}", filePath);
        await using var fileStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write);
        var (httpContentStream, contentLength) = await GetStreamFromWebSourceAsync(dbSourcePath);

        using var archive = new ZipArchive(httpContentStream);
        foreach (var zipArchiveEntry in archive.Entries)
        {
            await using var zipArchiveEntryStream = zipArchiveEntry.Open();
            await zipArchiveEntryStream.CopyToAsync(fileStream);
        }

        await httpContentStream.DisposeAsync();
    }

    public async ValueTask<(Stream ContentStream, long? TotalLength)> GetStreamFromWebSourceAsync(string path)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "https://www.bungie.net" + path);
        var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
        return (await response.Content.ReadAsStreamAsync(), response.Content.Headers.ContentLength);
    }
    //private async Task UseDotNetBungieApi()
    //{
    //    var manifest2 = await bungieClient.ApiAccess.Destiny2.GetDestinyManifest();

    //    await bungieClient.DefinitionProvider.DownloadManifestData(manifest2.Response);
    //}

    //public async Task DownloadFileStreamFromCdnAsync(string query, string savePath)
    //{
    //    using var response = await _httpClient.GetAsync("https://www.bungie.net" + query, HttpCompletionOption.ResponseHeadersRead);
    //    await using var stream = await response.Content.ReadAsStreamAsync();
    //    await using Stream streamToWriteTo = File.Open(savePath, FileMode.Create);
    //    await stream.CopyToAsync(streamToWriteTo);
    //}

    //private async Task DownloadSqliteDatabases(string propertyName, string path, IDictionary<string, string> values)
    //{
    //    _logger.LogInformation("Started loading {PropertyName}", propertyName);
    //    var rootDirectoryPath = Path.Combine(path, propertyName);
    //    EnsureDirectoryExists(rootDirectoryPath);

    //    var downloadTasks = new List<Task>(values.Count);

    //    foreach (var (key, value) in values)
    //    {
    //        var task = Task.Run(async () =>
    //        {
    //            var entryPath = Path.Combine(path, propertyName, key);
    //            var filePath = Path.Combine(path, propertyName, key, Path.GetFileName(value));
    //            EnsureDirectoryExists(entryPath);
    //            if (!File.Exists(filePath))
    //                await DownloadAndUnpackSqliteFile(filePath, value);
    //            else
    //                _logger.LogInformation("File already exists, skipping");
    //        });

    //        downloadTasks.Add(task);
    //    }

    //    await Task.WhenAll(downloadTasks.ToArray());

    //    _logger.LogInformation("Finished loading {PropertyName}", propertyName);
    //}
}
