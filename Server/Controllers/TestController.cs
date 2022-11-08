using DotNetBungieAPI.Extensions;
using DotNetBungieAPI.Models;
using DotNetBungieAPI.Models.Authorization;
using DotNetBungieAPI.Models.Destiny;
using DotNetBungieAPI.Service.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModReminder.Infrastructure.DbContext;

namespace ModReminder.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TestController : ControllerBase
{
    private readonly IBungieClient _bungieClient;
    private readonly ApplicationDbContext _context;

    public TestController(IBungieClient bungieClient, ApplicationDbContext context)
    {
        _bungieClient = bungieClient;
        _context = context;
    }

    [HttpGet("Vendors/{userId}/{membershipId}/{membershipType}")]
    public async Task<List<string>> GetVendorSales(string userId, long membershipId, BungieMembershipType membershipType)
    {
        var userBungieToken = await _context.GetUserTokensAsync(userId);
        var components = new[] { DestinyComponentType.VendorSales, DestinyComponentType.ItemPerks };

        var profile = await _bungieClient.ApiAccess.Destiny2.GetProfile(membershipType, membershipId, new[] { DestinyComponentType.Characters });
        //var profile = await _client.Api.Destiny2_GetProfile(membershipId, membershipType, new[] { DestinyComponentType.Characters });
        var characterId = profile.Response.Characters.Data.Keys.First();

        //return await _client.Api.Destiny2_GetVendors(characterId, membershipId, membershipType, components: components, authToken: userBungieToken.AccessToken);
        var token = new AuthorizationTokenData()
        {
            AccessToken = userBungieToken.AccessToken,
        };
        var vendors = await _bungieClient.ApiAccess.Destiny2.GetVendors(membershipType, membershipId, characterId, componentTypes: components, authorizationToken: token);

        var sales = vendors.Response.Sales.Data.Values.SelectMany(s => 
            s.SaleItems.Select(i => {
                if (i.Value.Item.TryGetDefinition(out var item, BungieLocales.EN))
                {
                    return item.ItemTypeDisplayName; // is not correct
                }
                return null;
        })).ToList();

        return sales;
    }
}
