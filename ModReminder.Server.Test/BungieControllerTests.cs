using BungieSharper.Client;
using CustomBungieApiClient.DataModels;
using Microsoft.Extensions.Logging;
using RichardSzalay.MockHttp;
using System.Net;
using System.Net.Http.Json;
using System;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace ModReminder.Server.Test;

public class BungieControllerTests : TestBaseController<BungieController>
{
    private readonly MockHttpMessageHandler _handler = new();
    private readonly IConfiguration _configuration;

    public BungieControllerTests()
    {
        var builder = new ConfigurationBuilder().AddUserSecrets<BungieController>();

        _configuration = builder.Build();
    }

    [Fact]
    public async void Get_user_from_bungie_membership_id()
    {
        // Arrange
        var expected = new Profile
        {
            isOverridden = false,
            isCrossSavePrimary = true,
            crossSaveOverride = 2,
            isPublic = false,
            membershipType = 2,
            membershipId = "4611686018442057913",
            displayName = "HeyImStone",
            bungieGlobalDisplayName = "Stonecool",
            bungieGlobalDisplayNameCode = 6516
        };
        var controller = new BungieController(logger.Object, new HttpClient(), _configuration);

        // Act
        var actual = await controller.GetBungieProfile(9819940);

        // Assert
        Assert.Equal(expected, actual);
    }

    
}