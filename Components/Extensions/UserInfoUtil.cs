using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace ModReminder.Components.Extensions;

public class UserInfoUtil
{
    private readonly AuthenticationStateProvider _authenticationStateProvider;

    public UserInfoUtil(AuthenticationStateProvider authenticationStateProvider)
    {
        _authenticationStateProvider = authenticationStateProvider;
    }

    public async Task<string> GetUserId()
    {
        var user = await GetUser();
        return user.FindFirst(c => c.Type == "sub").Value;
    }

    private async Task<ClaimsPrincipal> GetUser()
    {
        var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
        return authState.User;
    }


}
