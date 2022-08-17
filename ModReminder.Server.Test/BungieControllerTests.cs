using BungieSharper.Client;
using Microsoft.Extensions.Logging;
using RichardSzalay.MockHttp;
using System.Net;
using System.Net.Http.Json;
using System;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using BungieSharper.Entities.Destiny.Responses;

namespace ModReminder.Server.Test;

public class BungieControllerTests : TestBaseController<BungieController>
{
    private readonly MockHttpMessageHandler _handler = new();
    private readonly IConfiguration _configuration;
    private readonly BungieApiClient bungieClient;

    public BungieControllerTests()
    {
        var builder = new ConfigurationBuilder().AddUserSecrets<BungieController>();

        _configuration = builder.Build();
        bungieClient = new BungieApiClient(new BungieClientConfig { ApiKey = _configuration["Bungie:ApiKey"], OAuthClientId = 40759u });
    }

    //[Fact]
    //public async void Get_user_from_bungie_membership_id()
    //{
    //    // Arrange
    //    var expected = new DestinyProfileUserInfoCard
    //    {
    //        IsOverridden = false,
    //        IsCrossSavePrimary = true,
    //        CrossSaveOverride = BungieSharper.Entities.BungieMembershipType.TigerPsn,
    //        IsPublic = false,
    //        MembershipType = BungieSharper.Entities.BungieMembershipType.TigerPsn,
    //        MembershipId = 4611686018442057913,
    //        DisplayName = "HeyImStone",
    //        BungieGlobalDisplayName = "Stonecool",
    //        BungieGlobalDisplayNameCode = 6516
    //    };
        
    //    var controller = new BungieController(logger.Object, bungieClient);
        
    //    // Act
    //    var actual = await controller.GetLinkedProfiles(9819940, BungieSharper.Entities.BungieMembershipType.BungieNext);
        
    //    // Assert
    //    Assert.Equal(expected.MembershipId, actual.Profiles.First().MembershipId);
    //}

    //[Fact]
    //public async void Get_vendor_responce_from_bungie_membership_id()
    //{
    //    // Arrange

    //    var controller = new BungieController(logger.Object, bungieClient);

    //    // Act
    //    var actual = await controller.Get(4611686018442109061, BungieSharper.Entities.BungieMembershipType.TigerPsn);

    //    // Assert
    //    Assert.Equal(88, actual.Sales.Data.Count);
    //}


}