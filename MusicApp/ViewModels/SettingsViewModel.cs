using MusicApp.Models;
using MusicApp.Services;
using System.Windows.Input;

namespace MusicApp.ViewModels
{
    public class SettingsViewModel
    {
        private readonly SettingsService _settingsService;
        private readonly ThemeService _themeService;
        private readonly LanguageService _languageService;

        public bool IsDarkMode { get; set; }
        public ICommand ToggleThemeCommand { get; set; }
        public ICommand SetEnglishCommand { get; }
        public ICommand SetEstonianCommand { get; }

        public SettingsViewModel(SettingsService settingsService, ThemeService themeService, LanguageService languageService)
        {
            _settingsService = settingsService;
            _themeService = themeService;
            _languageService = languageService;

            //Localization
            SetEnglishCommand = new Command(() =>
            {
                _languageService.SetLanguage("en");
            });
            SetEstonianCommand = new Command(() =>
            {
                _languageService.SetLanguage("et");
            });


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
