using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;

namespace ModReminder.Components;
public class ExternalAuthStateProvider : AuthenticationStateProvider
{
    private readonly Task<AuthenticationState> authenticationState;

    public ExternalAuthStateProvider(AuthenticatedUser user) =>
        authenticationState = Task.FromResult(new AuthenticationState(user.Principal));

    public override Task<AuthenticationState> GetAuthenticationStateAsync() =>
        authenticationState;
}

public class AuthenticatedUser
{
    public ClaimsPrincipal Principal { get; set; } = new();
}
