using System;

public class Ogrenci
{
    public string Numara { get; }
    public string AdSoyad { get; }

    public Ogrenci(string numara, string adSoyad)
    {
        if (string.IsNullOrWhiteSpace(numara)
            || string.IsNullOrWhiteSpace(adSoyad))
            throw new ArgumentException("Numara ve ad soyad zorunludur.");

        Numara = numara.Trim();
        AdSoyad = adSoyad.Trim();
    }
}