using BungieSharper.Client;
using Microsoft.AspNetCore.Mvc;
using BungieSharper.Entities.Destiny;
using BungieSharper.Entities.Destiny.Responses;
using BungieSharper.Entities;
using Microsoft.Extensions.Caching.Memory;
using BungieSharper.Entities.Destiny.Config;
using Microsoft.AspNetCore.Authentication;

namespace ModReminder.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class BungieController : ControllerBase
{
    public readonly ILogger<BungieController> _logger;
    public readonly BungieApiClient _client;

    public BungieController(ILogger<BungieController> logger, BungieApiClient client)
    {
        _logger = logger;
        _client = client;
    }

    [HttpGet]
    public async Task<DestinyVendorsResponse?> Get(long membershipId, BungieMembershipType membershipType)
    {
        var linkedProfiles = await _client.Api.Destiny2_GetLinkedProfiles(membershipId, membershipType);

        var profile = linkedProfiles.Profiles.Where(p => p.IsCrossSavePrimary).FirstOrDefault();

        if (profile == null) return null;

        var user = await _client.Api.Destiny2_GetProfile(profile.MembershipId, profile.MembershipType, components: new List<DestinyComponentType> { DestinyComponentType.Characters });
        var characterId = user.Characters.Data.Keys.FirstOrDefault();

        var components = new List<DestinyComponentType>() { DestinyComponentType.VendorSales, DestinyComponentType.ItemPerks };

        return await _client.Api.Destiny2_GetVendors(characterId, membershipId, membershipType);
    }

    [HttpGet("/GetLinkedProfiles/{membershipId}/{membershipType}")]
    public async Task<DestinyLinkedProfilesResponse> GetLinkedProfiles(long membershipId, BungieMembershipType membershipType)
    {
        return await _client.Api.Destiny2_GetLinkedProfiles(membershipId, membershipType);
    }

    [HttpGet("/GetProfile")]
    public async Task<DestinyProfileResponse?> GetProfile(long membershipId, BungieMembershipType membershipType)
    {
        return await _client.Api.Destiny2_GetProfile(membershipId, membershipType, components: new List<DestinyComponentType>());
    }

    [HttpGet("/GetManifest")]
    public async Task<DestinyManifest?> GetManifest()
    {
        return await _client.Api.Destiny2_GetDestinyManifest();
    }

    [HttpGet("/BungieToken/{code}/{state}")]
    public async Task<string> GetBungieToken(string code, string state)
    {
        var token = await _client.OAuth.GetOAuthToken(code);
        
        return "/";
    }

    [HttpGet("/bungie_net")]
    public async Task RedirectToBungieNet()
    {
        await HttpContext.ChallengeAsync(
            "BungieNet",
            new AuthenticationProperties());
    }

}
