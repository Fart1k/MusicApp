using Microsoft.Extensions.DependencyInjection;
using MusicApp.Services;

namespace MusicApp
{
    public partial class App : Application
    {
        public App(SettingsService settingsService, ThemeService themeService)
        {
            InitializeComponent();

            var settings = settingsService.Load();

            themeService.Apply(settings.IsDarkMode);
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}