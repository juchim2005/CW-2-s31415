namespace Kontenery;

public class KontenerNaPlyny : Kontener, IHazadNotifier
{
    public bool Niebezpieczne { get; set; }
    
    public KontenerNaPlyny(double wysokosc, double wagaWlasna, double glebokosc, double maxLadownosc, bool niebezpieczne)
        : base(wysokosc, wagaWlasna, glebokosc, maxLadownosc, "L")
    {
        Niebezpieczne = niebezpieczne;
    }
    
    public void Notify(string message)
    {
        Console.WriteLine($"SOS! {message}");
    }
    
    public override void Oproznianie()
    {
        MasaLadunku = 0;
    }

    public override void Ladowanie(double waga)
    {
        double limit;
        if (Niebezpieczne) limit = (MaxLadownosc*0.5)-MasaLadunku;
        else limit = (MaxLadownosc*0.9)-MasaLadunku;

        if (waga > limit)
        {
            Notify($"Próba przeładowania w kontenerze {NumerSeryjny}!!!");
            MasaLadunku = limit;
            throw new OverfillException($"Próba przeładowania kontenera {NumerSeryjny}!!!");
        }
        MasaLadunku += waga;
    }
    public override string ToString()
    {
        return base.ToString() + $", Czy niebezpieczny: {Niebezpieczne}";
    }
}