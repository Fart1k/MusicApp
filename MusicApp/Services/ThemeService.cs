using System;
using System.Collections.Generic;
using System.Text;

namespace MusicApp.Services
{
    public class ThemeService
    {
        public void Apply(bool isDark)
        {
            Application.Current.UserAppTheme = isDark ? AppTheme.Dark : AppTheme.Light;
        }
    }
}
