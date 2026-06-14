using MusicApp.Models;
using MusicApp.Services;
using System.Windows.Input;

namespace MusicApp.ViewModels
{
    public class SettingsViewModel
    {
        private readonly SettingsService _settingsService;
        private readonly ThemeService _themeService;

        public bool IsDarkMode { get; set; }
        public ICommand ToggleThemeCommand { get; set; }
        public SettingsViewModel(SettingsService settingsService, ThemeService themeService)
        {
            _settingsService = settingsService;
            _themeService = themeService;

            var settings = _settingsService.Load();
            IsDarkMode = settings.IsDarkMode;

            _themeService.Apply(IsDarkMode);

            ToggleThemeCommand = new Command(ToggleTheme);
        }

        private void ToggleTheme()
        {
            IsDarkMode = !IsDarkMode;

            _themeService.Apply(IsDarkMode);

            _settingsService.Save(new AppSettings
            {
                IsDarkMode = IsDarkMode
            });
        }
    }
}
