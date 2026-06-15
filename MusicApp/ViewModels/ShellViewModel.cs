using MusicApp.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicApp.ViewModels
{
    public class ShellViewModel
    {
        public LocalizationService L { get; }

        public ShellViewModel(LocalizationService localizationService)
        {
            L = localizationService;
        }
    }
}
