using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace ModReminder.Components.Extensions;
public static class AuthenticationStateExtention
{
    public static async Task<string> GetUserId(this AuthenticationStateProvider authenticationStateProvider)
    {
        return await _GetUserId(authenticationStateProvider);
    }

    public static async Task<ClaimsPrincipal> GetUser(this AuthenticationStateProvider authenticationStateProvider)
    {
        return await _GetUser(authenticationStateProvider);
    }

    private static async Task<string> _GetUserId(AuthenticationStateProvider authenticationStateProvider)
    {
        var user = await GetUser(authenticationStateProvider);
        return user.FindFirst(c => c.Type == "sub").Value;
    }

    private static async Task<ClaimsPrincipal> _GetUser(AuthenticationStateProvider authenticationStateProvider)
    {
        var authState = await authenticationStateProvider.GetAuthenticationStateAsync();
        return authState.User;
    }
}
