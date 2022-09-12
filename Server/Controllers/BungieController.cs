using BungieSharper.Entities.Destiny.Responses;
using BungieSharper.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BungieSharper.Client;
using Microsoft.EntityFrameworkCore;
using BungieSharper.Entities.Destiny;
using ModReminder.Infrastructure.DbContext;

namespace ModReminder.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BungieController : ControllerBase
{
    private readonly ILogger<BungieController> _logger;
    private readonly BungieApiClient _client;
    private readonly ApplicationDbContext _context;

    public BungieController(ILogger<BungieController> logger, BungieApiClient client, ApplicationDbContext context)
    {
        _logger = logger;
        _client = client;
        _context = context;
    }

    [HttpGet("LinkedProfiles/{userId}")]
    public async Task<ActionResult<DestinyLinkedProfilesResponse>> GetLinkedProfiles(string userId)
    {
        var user = _context.Users.Include(u => u.BungieToken).FirstOrDefault(u => u.Id == userId);

        if (user is null)
        {
            return NotFound("User not found");
        }
        if (user.BungieToken is null)
        {
            return NotFound("User has not authenticated with Bungie");
        }

        return await _client.Api.Destiny2_GetLinkedProfiles(user.BungieToken.MembershipId, BungieMembershipType.BungieNext);
    }

    [HttpGet("Vendors/{userId}/{membershipId}/{membershipType}")]
    public async Task<DestinyVendorsResponse> GetVendorSales(string userId, long membershipId, BungieMembershipType membershipType)
    {
        var userBungieToken = await _context.GetUserTokensAsync(userId);
        var components = new[] { DestinyComponentType.VendorSales, DestinyComponentType.ItemPerks };

        var profile = await _client.Api.Destiny2_GetProfile(membershipId, membershipType, new[] { DestinyComponentType.Characters });
        var characterId = profile.Characters.Data.Keys.First();

        return await _client.Api.Destiny2_GetVendors(characterId, membershipId, membershipType, components: components, authToken: userBungieToken.AccessToken);
    }

}
