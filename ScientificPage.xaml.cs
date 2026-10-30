
using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace HesapMakinesi;

public partial class ScientificPage : ContentPage
{
    public ScientificPage()
    {
        InitializeComponent();
    }

    private bool SayiOku(out double sayi)
    {
        string metin = SayiEntry.Text ?? "";

        if (double.TryParse(metin, NumberStyles.Float,
            CultureInfo.CurrentCulture, out sayi))
            return true;

        if (double.TryParse(metin, NumberStyles.Float,
            CultureInfo.InvariantCulture, out sayi))
            return true;

        SonucLabel.Text = "Geçerli bir sayı gir";
        return false;
    }

    private void Hesapla(Func<double, double> fonksiyon)
    {
        if (!SayiOku(out double sayi))
            return;

        try
        {
            double sonuc = fonksiyon(sayi);

            if (double.IsNaN(sonuc) || double.IsInfinity(sonuc))
            {
                SonucLabel.Text = "Geçersiz işlem";
                return;
            }

            SonucLabel.Text = sonuc.ToString("G", CultureInfo.CurrentCulture);
        }
        catch
        {
            SonucLabel.Text = "İşlem yapılamadı";
        }
    }

    private void Karekok_Clicked(object sender, EventArgs e)
    {
        if (SayiOku(out double sayi) && sayi < 0)
        {
            SonucLabel.Text = "Negatif sayının karekökü alınamaz";
            return;
        }

        Hesapla(Math.Sqrt);
    }

    private void Kare_Clicked(object sender, EventArgs e)
        => Hesapla(x => x * x);

    private void Kup_Clicked(object sender, EventArgs e)
        => Hesapla(x => x * x * x);

    private void Sin_Clicked(object sender, EventArgs e)
        => Hesapla(x => Math.Sin(x * Math.PI / 180));

    private void Cos_Clicked(object sender, EventArgs e)
        => Hesapla(x => Math.Cos(x * Math.PI / 180));

    private void Tan_Clicked(object sender, EventArgs e)
        => Hesapla(x => Math.Tan(x * Math.PI / 180));

    private void Log_Clicked(object sender, EventArgs e)
    {
        if (SayiOku(out double sayi) && sayi <= 0)
        {
            SonucLabel.Text = "Logaritma için sayı pozitif olmalı";
            return;
        }

        Hesapla(Math.Log10);
    }

    private void Ln_Clicked(object sender, EventArgs e)
    {
        if (SayiOku(out double sayi) && sayi <= 0)
        {
            SonucLabel.Text = "Sayı pozitif olmalı";
            return;
        }

        Hesapla(Math.Log);
    }

    private void Temizle_Clicked(object sender, EventArgs e)
    {
        SayiEntry.Text = "";
        SonucLabel.Text = "0";
    }
}
