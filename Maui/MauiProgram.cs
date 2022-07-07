using Microsoft.AspNetCore.Components.WebView.Maui;
using ModReminder.Components.Data;

namespace ModReminder.Maui
{
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

            return builder.Build();
        }
    }
}