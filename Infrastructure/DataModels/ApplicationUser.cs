using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ModReminder.Infrastructure.DataModels;

public class ApplicationUser : IdentityUser
{
    public BungieToken? BungieToken { get; set; }
}

public class BungieToken
{
    public int Id { get; set; }
    [Required]
    public string AccessToken { get; set; }
    public DateTime ExpirationDate { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime? RefreshExpirationDate { get; set; }
    /// <summary>
    /// The Bungie.net (membership type BungieNext / 254) membership ID of the authenticated user
    /// </summary>
    public long MembershipId { get; set; }
}