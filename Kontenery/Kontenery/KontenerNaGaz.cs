namespace Kontenery;

public class KontenerNaGaz : Kontener, IHazadNotifier
{
    public double Cisnienie { get; set; }

    public KontenerNaGaz(double wysokosc, double wagaWlasna, double glebokosc, double maxLadownosc, double cisnienie)
        : base(wysokosc, wagaWlasna, glebokosc, maxLadownosc, "L")
    {
        Cisnienie = cisnienie;
    }

    public void Notify(string message)
    {
        Console.WriteLine($"SOS! {message}");
    }

    public override void Oproznianie()
    {
        MasaLadunku *= 0.05;
    }

    public override void Ladowanie(double waga)
    {
        if (waga + MasaLadunku > MaxLadownosc)
        {
            MasaLadunku = MaxLadownosc;
            throw new OverfillException($"Próba przeładowania kontenera {NumerSeryjny}!!!");
        }
        MasaLadunku += waga;
        
    }
    public override string ToString()
    {
        return base.ToString() + $", Ciśnienie: {Cisnienie} atmosfer";
    }
    
}