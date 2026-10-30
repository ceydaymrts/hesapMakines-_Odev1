using Microsoft.Extensions.DependencyInjection;

namespace HesapMakinesi
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            string tema = Preferences.Default.Get("UygulamaTemasi", "Sistem");

            Application.Current.UserAppTheme = tema switch
            {
                "Açık" => AppTheme.Light,
                "Koyu" => AppTheme.Dark,
                _ => AppTheme.Unspecified
            };
        }
        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}