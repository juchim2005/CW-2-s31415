namespace Kontenery;

public abstract class Kontener
{
    private static int Licznik;
    public double MasaLadunku { get; set; }
    public double Wysokosc { get; set; }
    public double WagaWlasna { get; set; }
    public double Glebokosc { get; set; }
    public string NumerSeryjny { get; set; }
    public double MaxLadownosc { get; set; }
    
    public Kontener(double wysokosc, double wagaWlasna, double glebokosc, double maxLadownosc, string typ)
    {

        Wysokosc = wysokosc;
        WagaWlasna = wagaWlasna;
        Glebokosc = glebokosc;
        MaxLadownosc = maxLadownosc;
        NumerSeryjny = $"KON-{typ}-{Licznik++}";
    }
    

    public abstract void Oproznianie();
    public abstract void Ladowanie(double waga);

    public override string ToString()
    {
        return $"Numer seryjny: {NumerSeryjny}, Waga Ładunku: {MasaLadunku} kg, Waga własna: {WagaWlasna} kg, Maksymalna ładowność: {MaxLadownosc} kg, Wysokość: {Wysokosc}, Głębokość: {Glebokosc}";
    }



}