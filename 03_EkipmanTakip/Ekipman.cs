using System;

public class Ekipman
{
    public string DemirbasNo { get; }
    public string Ad { get; }

    public string? OduncAlanNo { get; private set; }

    public bool Oduncte
    {
        get
        {
            return OduncAlanNo != null;
        }
    }

    public Ekipman(string demirbasNo, string ad)
    {
        if (string.IsNullOrWhiteSpace(demirbasNo)
            || string.IsNullOrWhiteSpace(ad))
        {
            throw new ArgumentException("Demirbaş no ve ad zorunludur.");
        }

        DemirbasNo = demirbasNo.Trim().ToUpperInvariant();
        Ad = ad.Trim();
    }

    public bool OduncVer(string ogrenciNo)
    {
        if (string.IsNullOrWhiteSpace(ogrenciNo))
            return false;

        if (Oduncte)
            return false;

        OduncAlanNo = ogrenciNo.Trim();
        return true;
    }

    public bool IadeAl()
    {
        if (!Oduncte)
            return false;

        OduncAlanNo = null;
        return true;
    }
}