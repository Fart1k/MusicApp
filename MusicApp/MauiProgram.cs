using MusicApp.ViewModels;
using Microsoft.Extensions.Logging;
using MusicApp.Views;
using MusicApp.Services;
using Plugin.Maui.Audio;

namespace MusicApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            // DI
            builder.Services.AddSingleton<MainViewModel>();
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<DatabaseService>();
            builder.Services.AddSingleton(AudioManager.Current);
            builder.Services.AddSingleton<AudioServices>();
            builder.Services.AddSingleton<SettingsService>();
            builder.Services.AddSingleton<ThemeService>();
            builder.Services.AddSingleton<SettingsViewModel>();
            builder.Services.AddSingleton<SettingsPage>();
            builder.Services.AddSingleton<App>();
            builder.Services.AddSingleton<LanguageService>();
            builder.Services.AddSingleton<LocalizationService>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
