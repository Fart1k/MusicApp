using MusicApp.ViewModels;

namespace MusicApp
{
    public partial class AppShell : Shell
    {
        public AppShell(ShellViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
    }
}
