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
public class BungieAuthenticationController : ControllerBase
{
    private readonly BungieApiClient _client;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ApplicationDbContext _context;

    public BungieAuthenticationController(BungieApiClient client, UserManager<ApplicationUser> userManager, ApplicationDbContext context)
    {
        _client = client;
        _userManager = userManager;
        _context = context;
    }

    [HttpGet("Auth/{userId}/{code}")]
    public async Task<IActionResult> GetBungieToken(string userId, string code)
    {
        var tokenResponce = await _client.OAuth.GetOAuthToken(code);

        if (tokenResponce is not null && tokenResponce.Error is null && tokenResponce.MembershipId is not null)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            var token = new BungieToken
            {
                AccessToken = tokenResponce.AccessToken,
                ExpirationDate = DateTime.Now.AddSeconds(tokenResponce.ExpiresIn ?? 0),
                RefreshToken = tokenResponce.RefreshToken,
                RefreshExpirationDate = tokenResponce.RefreshExpiresIn is not null ? DateTime.Now.AddSeconds(tokenResponce.RefreshExpiresIn ?? 0) : null,
                MembershipId = tokenResponce.MembershipId ?? 0 // can never be null
            };

            _context.BungieTokens.Add(token);

            user.BungieToken = token;
            await _context.SaveChangesAsync();
        }

        return Ok();
    }

    [HttpGet("HasToken/{userId}")]
    public async Task<bool> VerifyUserHasTokken(string userId)
    {
        var tokens = await _context.GetUserTokensAsync(userId);

        return tokens is not null;
    }



}
