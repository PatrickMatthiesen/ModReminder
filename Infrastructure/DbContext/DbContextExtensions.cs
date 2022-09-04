using Microsoft.EntityFrameworkCore;
using ModReminder.Infrastructure.DataModels;

namespace ModReminder.Infrastructure.DbContext;

public static class DbContextExtensions
{
    public static async Task<BungieToken?> GetUserTokensAsync(this ApplicationDbContext context, string userId)
    {
        return (await context.Users.Include("BungieToken").FirstOrDefaultAsync(t => t.Id == userId)).BungieToken;
    }

    public static async Task<ApplicationUser?> GetUserAsync(this ApplicationDbContext context, string userId)
    {
        return await context.Users.FirstOrDefaultAsync(t => t.Id == userId);
    }

}
