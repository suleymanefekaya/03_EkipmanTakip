using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;

        var ekipmanlar = new List<Ekipman>
        {
            new Ekipman("LAB-001", "Kamera"),
            new Ekipman("LAB-002", "Mikrofon"),
            new Ekipman("LAB-003", "Tripod")
        };

        var ogrenciler = new List<Ogrenci>
        {
            new Ogrenci("1001", "Ayşe Yılmaz"),
            new Ogrenci("1002", "Mehmet Demir")
        };

        string? secim = "";
        while (secim != "0")
        {
            Console.WriteLine();
            Console.WriteLine("1 Listele  2 Ödünç ver  3 İade al  0 Çıkış");
            Console.Write("Seçim: ");
            secim = Console.ReadLine();
            if (secim == null)
                break;

            switch (secim.Trim())
            {
                case "1":
                    Listele(ekipmanlar);
                    break;
                case "2":
                    OduncVerIslemi(ekipmanlar, ogrenciler);
                    break;
                case "3":
                    IadeAlIslemi(ekipmanlar);
                    break;
                case "0":
                    Console.WriteLine("Çıkış");
                    break;
                default:
                    Console.WriteLine("Geçersiz seçim");
                    break;
            }
        }
    }

    static void Listele(List<Ekipman> liste)
    {
        foreach (Ekipman e in liste)
        {
            string durum = e.Oduncte ? $"Ödünçte ({e.OduncAlanNo})" : "Müsait";
            Console.WriteLine($"{e.DemirbasNo}  {e.Ad,-10} {durum}");
        }
    }

    static void OduncVerIslemi(List<Ekipman> ekipmanlar, List<Ogrenci> ogrenciler)
    {
        Console.Write("Demirbaş no: ");
        Ekipman? ekipman = EkipmanBul(ekipmanlar, Console.ReadLine());
        if (ekipman == null)
        {
            Console.WriteLine("Ekipman bulunamadı.");
            return;
        }

        Console.Write("Öğrenci no: ");
        Ogrenci? ogrenci = OgrenciBul(ogrenciler, Console.ReadLine());
        if (ogrenci == null)
        {
            Console.WriteLine("Öğrenci bulunamadı.");
            return;
        }

        bool sonuc = ekipman.OduncVer(ogrenci.Numara);
        Console.WriteLine(sonuc
            ? $"Ödünç verildi: {ekipman.Ad} -> {ogrenci.AdSoyad}"
            : $"İşlem reddedildi: {ekipman.Ad} zaten ödünçte ({ekipman.OduncAlanNo}).");
    }

    static void IadeAlIslemi(List<Ekipman> ekipmanlar)
    {
        Console.Write("Demirbaş no: ");
        Ekipman? ekipman = EkipmanBul(ekipmanlar, Console.ReadLine());
        if (ekipman == null)
        {
            Console.WriteLine("Ekipman bulunamadı.");
            return;
        }

        bool sonuc = ekipman.IadeAl();
        Console.WriteLine(sonuc
            ? $"İade alındı: {ekipman.Ad} artık müsait."
            : $"İşlem reddedildi: {ekipman.Ad} zaten müsait.");
    }

    static Ekipman? EkipmanBul(List<Ekipman> liste, string? no)
    {
        if (string.IsNullOrWhiteSpace(no))
            return null;

        string aranan = no.Trim().ToUpperInvariant();
        foreach (Ekipman e in liste)
            if (e.DemirbasNo == aranan) return e;
        return null;
    }

    static Ogrenci? OgrenciBul(List<Ogrenci> liste, string? numara)
    {
        if (string.IsNullOrWhiteSpace(numara))
            return null;

        string aranan = numara.Trim();
        foreach (Ogrenci o in liste)
            if (o.Numara == aranan) return o;
        return null;
    }
}