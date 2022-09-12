using BungieSharper.Client;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.Extensions.Http;
using Microsoft.AspNetCore.Identity;
using BungieSharper.Entities.Destiny.Responses;
using BungieSharper.Entities;
using Microsoft.EntityFrameworkCore;
using ModReminder.Infrastructure.DataModels;
using ModReminder.Infrastructure.DbContext;

namespace ModReminder.Server.Controllers;

[Route("api/Bungie")]
[ApiController]
public sealed class BungieAuthenticationController : ControllerBase
{
    private readonly BungieApiClient _client;
    private readonly ApplicationDbContext _context;

    public BungieAuthenticationController(BungieApiClient client, ApplicationDbContext context)
    {
        _client = client;
        _context = context;
    }

    [HttpGet("Auth/{userId}/{code}")]
    public async Task<IActionResult> GetBungieToken(string userId, string code)
    {
        var tokenResponce = await _client.OAuth.GetOAuthToken(code);

        await UpdateBungieToken(userId, tokenResponce);

        return Ok();
    }

    [HttpGet("HasToken/{userId}")]
    public async Task<bool> VerifyUserHasToken(string userId)
    {
        var tokens = await _context.GetUserTokensAsync(userId);
        if (tokens is not null)
        {
            if (DateTime.Now < tokens.ExpirationDate)
            {
                return true;
            }
            if (DateTime.Now < tokens.RefreshExpirationDate)
            {
                var tokenResponce = await _client.OAuth.RefreshOAuthToken(tokens.RefreshToken);

                if (tokenResponce is null || tokenResponce.Error is not null)
                {
                    return false;
                }

                await UpdateBungieToken(userId, tokenResponce);

                return true;
            }
        }
        return false;
    }

    private async Task UpdateBungieToken(string userId, TokenResponse tokenResponce)
    {
        if (tokenResponce is not null && tokenResponce.Error is null && tokenResponce.MembershipId is not null)
        {
            var user = await _context.Users.Include("BungieToken").FirstOrDefaultAsync(u => u.Id == userId);
            var token = new BungieToken
            {
                AccessToken = tokenResponce.AccessToken,
                ExpirationDate = DateTime.Now.AddSeconds(tokenResponce.ExpiresIn ?? 0),
                RefreshToken = tokenResponce.RefreshToken,
                RefreshExpirationDate = DateTime.Now.AddSeconds(tokenResponce.RefreshExpiresIn ?? 0),
                MembershipId = tokenResponce.MembershipId ?? 0 // can never be null
            };

            if (user.BungieToken is not null)
            {
                _context.Remove(user.BungieToken);
            }

            user.BungieToken = token;

            await _context.SaveChangesAsync();
        }
    }


}
