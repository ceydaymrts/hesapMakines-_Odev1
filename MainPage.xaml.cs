
using System;
using Microsoft.Maui.Controls;

namespace HesapMakinesi;

public partial class MainPage : ContentPage
{
    private string giris = "0";
    private double ilkSayi = 0;
    private string islem = "";
    private bool yeniGiris = false;

    public MainPage()
    {
        InitializeComponent();
    }

    private void Sayi_Clicked(object sender, EventArgs e)
    {
        if (sender is not Button buton) return;

        if (giris == "0" || yeniGiris)
        {
            giris = buton.Text;
            yeniGiris = false;
        }
        else
        {
            giris += buton.Text;
        }

        SonucLabel.Text = giris;
    }

    private void Islem_Clicked(object sender, EventArgs e)
    {
        if (sender is not Button buton) return;

        if (!double.TryParse(giris, out ilkSayi))
        {
            SonucLabel.Text = "Geçersiz sayı";
            return;
        }

        islem = buton.Text;
        yeniGiris = true;
    }

    private void Esittir_Clicked(object sender, EventArgs e)
    {
        if (!double.TryParse(giris, out double ikinciSayi))
        {
            SonucLabel.Text = "Geçersiz sayı";
            return;
        }

        double sonuc;

        switch (islem)
        {
            case "+": sonuc = ilkSayi + ikinciSayi; break;
            case "−": sonuc = ilkSayi - ikinciSayi; break;
            case "×": sonuc = ilkSayi * ikinciSayi; break;
            case "÷":
                if (ikinciSayi == 0)
                {
                    SonucLabel.Text = "Sıfıra bölünemez";
                    giris = "0";
                    yeniGiris = true;
                    return;
                }
                sonuc = ilkSayi / ikinciSayi;
                break;
            default: return;
        }

        giris = sonuc.ToString();
        SonucLabel.Text = giris;
        yeniGiris = true;
        islem = "";
    }

    private void Temizle_Clicked(object sender, EventArgs e)
    {
        giris = "0";
        ilkSayi = 0;
        islem = "";
        yeniGiris = false;
        SonucLabel.Text = "0";
    }

    private void Sil_Clicked(object sender, EventArgs e)
    {
        if (giris.Length > 1)
            giris = giris[..^1];
        else
            giris = "0";

        SonucLabel.Text = giris;
    }

    private void Isaret_Clicked(object sender, EventArgs e)
    {
        if (double.TryParse(giris, out double sayi))
        {
            giris = (-sayi).ToString();
            SonucLabel.Text = giris;
        }
    }

    private void Virgul_Clicked(object sender, EventArgs e)
    {
        if (!giris.Contains(",") && !giris.Contains("."))
        {
            giris += ",";
            SonucLabel.Text = giris;
        }
    }
}
