using Microsoft.Extensions.DependencyInjection;
using MusicApp.Services;

namespace MusicApp
{
    public partial class App : Application
    {
        public App(IServiceProvider services, SettingsService settingsService, ThemeService themeService, LanguageService languageService)
        {
            InitializeComponent();

            var settings = settingsService.Load();

            themeService.Apply(settings.IsDarkMode);
            languageService.SetLanguage(settings.Language);

            var shell = services.GetRequiredService<AppShell>();
            MainPage = shell;
        }

    }
}