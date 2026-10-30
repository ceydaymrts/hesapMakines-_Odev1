
using System;
using Microsoft.Maui.Controls;

namespace HesapMakinesi;

public partial class SettingsPage : ContentPage
{
    public SettingsPage()
    {
        InitializeComponent();

        string tema = Preferences.Default.Get("UygulamaTemasi", "Sistem");

        AcikTema.IsChecked = tema == "Acik";
        KoyuTema.IsChecked = tema == "Koyu";
        SistemTema.IsChecked = tema == "Sistem";
    }

    private void Tema_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (!e.Value)
            return;

        string tema;

        if (AcikTema.IsChecked)
            tema = "Acik";
        else if (KoyuTema.IsChecked)
            tema = "Koyu";
        else
            tema = "Sistem";

        Preferences.Default.Set("UygulamaTemasi", tema);

        if (Application.Current != null)
        {
            Application.Current.UserAppTheme = tema switch
            {
                "Acik" => AppTheme.Light,
                "Koyu" => AppTheme.Dark,
                _ => AppTheme.Unspecified
            };
        }
    }
}
