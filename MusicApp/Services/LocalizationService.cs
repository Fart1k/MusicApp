using MusicApp.Resources.Localization;
using System.Globalization;

namespace MusicApp.Services
{
    public class LocalizationService
    {
        public string this[string key] => AppResources.ResourceManager.GetString(key, CultureInfo.CurrentUICulture);
    }
}
