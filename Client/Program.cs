using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

using ModReminder.Components;
using BungieSharper.Entities.Applications;
using Microsoft.AspNetCore.Components.Authorization;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("ModReminder.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("ModReminder.ServerAPI"));

builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, ExternalAuthStateProvider>();
builder.Services.AddSingleton<AuthenticatedUser>();
//builder.Services.AddOidcAuthentication(o =>
//{
//    o.ProviderOptions.Authority = "https://www.bungie.net/en/OAuth/Authorize";
//    o.ProviderOptions.ResponseType = "code";
//    o.ProviderOptions.ClientId = "";
//    o.ProviderOptions.MetadataUrl = "";

//});

builder.Services.AddApiAuthorization();

await builder.Build().RunAsync();
