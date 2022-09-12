using BungieSharper.Client;
using Microsoft.OpenApi.Models;
using ModReminder.Infrastructure.DataModels;
using ModReminder.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using ModReminder.Server.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options =>  {
    options.SignIn.RequireConfirmedAccount = true;

    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 3;
    options.Password.RequiredUniqueChars = 0;
})
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddIdentityServer()
    .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();
builder.Services.AddAuthentication().AddIdentityServerJwt();

//builder.Configuration.AddKeyPerFile("/run/secrets", true);
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddHttpClient();

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

builder.Services.AddHostedService<BungieDailyUpdateService>();
builder.Services.AddHostedService<BungieManifestUpdateService>();

//builder.Services.AddScoped(sp => new HttpClient());
//builder.Services.AddMemoryCache();

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("MyCors",
//        policy =>
//        {
//            policy.WithOrigins("https://www.bungie.net").AllowAnyHeader();
//            policy.WithOrigins("https://localhost:7208").AllowAnyHeader();
//        });
//});

//builder.Services.AddAuthentication(o =>
//    {
//        o.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//        o.DefaultChallengeScheme = BungieNetAuthenticationDefaults.AuthenticationScheme;
//        o.DefaultAuthenticateScheme = BungieNetAuthenticationDefaults.AuthenticationScheme;
//    })
//    .AddCookie()
//    .AddBungieNet(c =>
//    {
//        c.ApiKey = builder.Configuration["Bungie:ApiKey"];
//        c.ClientId = builder.Configuration["Bungie:ClientId"];
//        c.ClientSecret = builder.Configuration["Bungie:ClientSecret"];
//        c.Events = new OAuthEvents
//        {
//            OnCreatingTicket = oAuthCreatingTicketContext =>
//            {
//                //BungieAuthCacheService.TryAddContext(oAuthCreatingTicketContext);
//                return Task.CompletedTask;
//            }
//        };
//    });



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

app.UseIdentityServer();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
