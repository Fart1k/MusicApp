using MusicApp.Resources.Localization;
using System.ComponentModel;
using System.Globalization;

namespace MusicApp.Services
{
    public class LocalizationService : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public string this[string key] => AppResources.ResourceManager.GetString(key, CultureInfo.CurrentUICulture);

        public void SetCulture(string culture)
        {
            CultureInfo.CurrentUICulture = new CultureInfo(culture);
            CultureInfo.CurrentCulture = new CultureInfo(culture);

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }
    }
}
