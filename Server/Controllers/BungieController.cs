using BungieSharper.Client;
using Microsoft.AspNetCore.Mvc;
using BungieSharper.Entities.Destiny;
using BungieSharper.Entities.Destiny.Responses;
using BungieSharper.Entities;
using CustomBungieApiClient;
using CustomBungieApiClient.DataModels;

namespace ModReminder.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class BungieController : ControllerBase
{
    public readonly ILogger<BungieController> _logger;
    public readonly BungieApiClient _client;
    private readonly HttpClient _httpClient;
    public readonly IConfiguration _config;

    public BungieController(ILogger<BungieController> logger, HttpClient httpClient, IConfiguration config)
    {
        _logger = logger;
        _httpClient = httpClient;
        //_client = client;
        _config = config;
    }

    //[HttpGet]
    //public async Task<DestinyVendorsResponse?> Get(long membershipId, BungieMembershipType membershipType)
    //{
    //    var linkedProfiles = await _client.Api.Destiny2_GetLinkedProfiles(membershipId, membershipType);

    //    var profile = linkedProfiles.Profiles.Where(p => p.IsCrossSavePrimary).FirstOrDefault();

    //    if (profile == null) return null;
        
    //    var user = await _client.Api.Destiny2_GetProfile(profile.MembershipId, profile.MembershipType);
    //    var characterId = user.Characters.Data.Keys.FirstOrDefault();

    //    return await _client.Api.Destiny2_GetVendors(characterId, membershipId, membershipType);
    //}

    //[HttpGet("/GetLinkedProfiles")]
    //public async Task<DestinyLinkedProfilesResponse?> GetLinkedProfiles(long membershipId, BungieMembershipType membershipType)
    //{
    //    return await _client.Api.Destiny2_GetLinkedProfiles(membershipId, membershipType);
    //}

    //[HttpGet("/GetProfile")]
    //public async Task<DestinyProfileResponse?> GetProfile(long membershipId, BungieMembershipType membershipType)
    //{
    //    return await _client.Api.Destiny2_GetProfile(membershipId, membershipType, components: new List<DestinyComponentType>());
    //}

    [HttpGet("/TestHttpClient")]
    public async Task<Profile?> GetBungieProfile(int membershipId)
    {
        var baseUri = "https://localhost:7208";

        //9819940

        _httpClient.DefaultRequestHeaders.Add("X-API-Key", _config["Bungie:ApiKey"]);
        var result = await _httpClient.GetAsync($"https://www.bungie.net/Platform/Destiny2/254/Profile/{membershipId}/LinkedProfiles/");
        return (await result.Content.ReadFromJsonAsync<LinkedProfilesResponce>()).Response.profiles.FirstOrDefault(x => x.isCrossSavePrimary);

        
    }

}
