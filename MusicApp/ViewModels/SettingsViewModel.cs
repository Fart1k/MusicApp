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
        private readonly MainViewModel _mainViewModel;
        private readonly LocalizationService _localizationService;

        //Localization
        public LocalizationService L { get; }

        public bool IsDarkMode { get; set; }
        public string Language { get; set; }
        public ICommand ToggleThemeCommand { get; set; }
        public ICommand SetEnglishCommand { get; }
        public ICommand SetEstonianCommand { get; }

        public SettingsViewModel
            (
            SettingsService settingsService,
            ThemeService themeService,
            LanguageService languageService,
            MainViewModel mainViewModel,
            LocalizationService localizationService
            ) 
        {
            _settingsService = settingsService;
            _themeService = themeService;
            _languageService = languageService;
            _mainViewModel = mainViewModel;
            _localizationService = localizationService;
            L = localizationService;

            //Localization
            SetEnglishCommand = new Command(SetEnglish);
            SetEstonianCommand = new Command(SetEstonian);


            var settings = _settingsService.Load();
            IsDarkMode = settings.IsDarkMode;
            Language = settings.Language;

            _themeService.Apply(IsDarkMode);

            ToggleThemeCommand = new Command(ToggleTheme);
        }

        private void ToggleTheme()
        {
            IsDarkMode = !IsDarkMode;

            _themeService.Apply(IsDarkMode);

            _settingsService.Save(new AppSettings
            {
                IsDarkMode = IsDarkMode,
                Language = Language
            });
        }

        private void SetEnglish()
        {
            _languageService.SetLanguage("en");
            _localizationService.SetCulture("en");

            _settingsService.Save(new AppSettings
            {
                IsDarkMode = IsDarkMode,
                Language = "en"
            });
        }
        private void SetEstonian()
        {
            _languageService.SetLanguage("et");
            _localizationService.SetCulture("et");

            _settingsService.Save(new AppSettings
            {
                IsDarkMode = IsDarkMode,
                Language = "et"
            });
        }
    }
}
