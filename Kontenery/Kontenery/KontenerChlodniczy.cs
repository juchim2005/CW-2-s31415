namespace Kontenery;

public class KontenerChlodniczy : Kontener
{
    public string Typ { get; set; }
    public double Temperatura { get; set; }
    private static Dictionary<string, double> Produkty = new()
    {
        { "Bananas", 13.3 },
        { "Chocolate", 18.0 },
        { "Fish", 2.0 },
        { "Meat", -15.0 },
        { "Ice Cream", -18.0 },
        { "Frozen Pizza", -30.0 },
        { "Cheese", 7.2 },
        { "Sausages", 5.0 },
        { "Butter", 20.5 },
        { "Eggs", 19.0 }
    };

    public KontenerChlodniczy(double wysokosc, double wagaWlasna, double glebokosc, double maxLadownosc, string typ)
        : base(wysokosc, wagaWlasna, glebokosc, maxLadownosc, "C")
    {
        Typ = typ;
        Temperatura = Produkty[typ];
    }

    public override void Oproznianie()
    {
        MasaLadunku = 0;
    }

    public override void Ladowanie(double waga)
    {
        if (waga > (MaxLadownosc-MasaLadunku))
        {
            MasaLadunku += waga; 
            throw new OverfillException($"Próba przeładowania kontenera {NumerSeryjny}");
        }
        MasaLadunku += waga;
    }
    
    public override string ToString()
    {
        return base.ToString() + $", Produkt: {Typ}, Temperatura: {Temperatura}°C";
    }
}