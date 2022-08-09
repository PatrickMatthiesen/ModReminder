using BungieSharper.Client;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using DotNetBungieAPI.AspNet.Security.OAuth.Providers;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication.OAuth;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Configuration.AddKeyPerFile("/run/secrets", true);
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ModReminder.Server", Version = "v1" });
    c.UseInlineDefinitionsForEnums();
});

builder.Services.AddSingleton(x => 
    new BungieApiClient( 
        new BungieClientConfig 
        {
            ApiKey = builder.Configuration["Bungie:ApiKey"], 
            OAuthClientId = Convert.ToUInt32(builder.Configuration["Bungie:ClientId"]),
            OAuthClientSecret = builder.Configuration["Bungie:ClientSecret"]
        }));
builder.Services.AddScoped(sp => new HttpClient());
builder.Services.AddMemoryCache();

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("MyCors",
//        policy =>
//        {
//            policy.WithOrigins("https://www.bungie.net").AllowAnyHeader();
//            policy.WithOrigins("https://localhost:7208").AllowAnyHeader();
//        });
//});

builder.Services.AddAuthentication(o =>
    {
        o.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        o.DefaultChallengeScheme = BungieNetAuthenticationDefaults.AuthenticationScheme;
        o.DefaultAuthenticateScheme = BungieNetAuthenticationDefaults.AuthenticationScheme;
    })
    .AddCookie()
    .AddBungieNet(c =>
    {
        c.ApiKey = builder.Configuration["Bungie:ApiKey"];
        c.ClientId = builder.Configuration["Bungie:ClientId"];
        c.ClientSecret = builder.Configuration["Bungie:ClientSecret"];
        c.Events = new OAuthEvents
        {
            OnCreatingTicket = oAuthCreatingTicketContext =>
            {
                //BungieAuthCacheService.TryAddContext(oAuthCreatingTicketContext);
                return Task.CompletedTask;
            }
        };
    });



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseDeveloperExceptionPage();
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.UseAuthentication();
//app.UseCors("MyCors");

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
