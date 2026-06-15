using MusicApp.Models;

namespace MusicApp.Services
{
    public class SettingsService
    {
        private const string KEY = "app_settings";

        public AppSettings Load()
        {
            var dark = Preferences.Get("dark_mode", false);
            var language = Preferences.Get("Language", "en");

            return new AppSettings
            {
                IsDarkMode = dark,
                Language = language,
            };
        }

        public void Save(AppSettings settings)
        {
            Preferences.Set("dark_mode", settings.IsDarkMode);
            Preferences.Set("Language", settings.Language);
        }
    }
}
