using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace MusicApp.Services
{
    public class LanguageService
    {
        public void SetLanguage(string culture)
        {
            CultureInfo cultureInfo = new CultureInfo(culture);

            CultureInfo.CurrentCulture = cultureInfo;
            CultureInfo.CurrentUICulture = cultureInfo;
        }
    }
}
