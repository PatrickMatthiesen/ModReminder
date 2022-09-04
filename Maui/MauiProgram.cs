using Microsoft.AspNetCore.Components.WebView.Maui;
using ModReminder.Components.Data;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using ModReminder.Components;

namespace ModReminder.Maui;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var baseUri = "https://localhost:7208";

        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        builder.Services.AddMauiBlazorWebView();
#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
#endif

        builder.Services.AddSingleton<WeatherForecastService>();
        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseUri) });

        builder.Services.AddAuthorizationCore();
        builder.Services.AddScoped<AuthenticationStateProvider, ExternalAuthStateProvider>();
        builder.Services.AddSingleton<AuthenticatedUser>();
        var host = builder.Build();

        var authenticatedUser = host.Services.GetRequiredService<AuthenticatedUser>();

        /*
        Provide OpenID/MSAL code to authenticate the user. See your identity provider's 
        documentation for details.

        The user is represented by a new ClaimsPrincipal based on a new ClaimsIdentity.
        */
        var user = new ClaimsPrincipal(new ClaimsIdentity());

        authenticatedUser.Principal = user;

        return host;
    }
}