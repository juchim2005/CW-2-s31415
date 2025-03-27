namespace Kontenery;

public class Statek
{
    public static int Licznik = 1;
    public int IDStatku;
    public List<Kontener> kontenery = new List<Kontener>();
    public double MaxPredkosc { get; set; }
    public int MaxKontenerow { get; set; }
    public double MaxWaga { get; set; }
    
    public Statek(double maxPredkosc, int maxKontenerow, double maxwaga)
    {
        IDStatku = Licznik++;
        MaxPredkosc = maxPredkosc;
        MaxKontenerow = maxKontenerow;
        MaxWaga = maxwaga;
    }

    public void DodajKontener(Kontener kontener)
    {
        if (kontenery.Count > MaxKontenerow)
        {
            throw new Exception("Za dużo kontenerów");
        }
        if ((WagaZaladunku() + kontener.WagaWlasna + kontener.MasaLadunku) > MaxWaga*1000)
            throw new Exception("Za duża łączna waga wszyskich kontenerów");
        kontenery.Add(kontener);
    }
    
    public void LadujKontener(string idKontenera, double waga)
    {
        if (ZnajdzKontener(idKontenera) == null)
        {
            throw new Exception($"Kontenera {idKontenera} nie ma na statku");
        }
        if (waga+WagaZaladunku()>MaxWaga*1000)
        {
            throw new Exception("Za duża łączna waga wszyskich kontenerów");
        }
        ZnajdzKontener(idKontenera).Ladowanie(waga);
    }

    public void DodajWieleKontenerow(List<Kontener> kontener)
    {
        foreach (Kontener k in kontenery)
        {
            DodajKontener(k);
        }
    }
    
    public void UsunKontener(string idKontenera)
    {
        if (ZnajdzKontener(idKontenera) != null)
        {
            kontenery.Remove(ZnajdzKontener(idKontenera));
            return;
        }
        throw new Exception($"Kontenera {idKontenera} nie ma na statku");
    }
    public void ZamienKontener(Kontener kontener, string idKontenera)
    {
        if (ZnajdzKontener(idKontenera) == null)
        {
            throw new Exception($"Kontenera {idKontenera} nie ma na statku");
        }
        UsunKontener(idKontenera);
        DodajKontener(kontener);
    }
    
    public void PrzeniesKontener(Statek s, string idKontenera)
    {
        if (ZnajdzKontener(idKontenera) == null)
        {
            throw new System.Exception($"Brak kontenera {idKontenera} na statku");
        }
        
        s.DodajKontener(ZnajdzKontener(idKontenera));
        UsunKontener(idKontenera);
    }
    public void InfoKontener(string idKontenera)
    {
        if (ZnajdzKontener(idKontenera) != null)
        {
            Console.WriteLine(ZnajdzKontener(idKontenera).ToString());
        }
    }
    
    public string InformacjaStatek()
        
    {
        int licznik = 1;
        string str = $"Id statku: {IDStatku}\nMax prędkość: {MaxPredkosc} węzłów\nMax Kontenerów: {MaxKontenerow}\nAktualnie Kontenerów {kontenery.Count}\nMax załadunku: {MaxWaga} ton\nAktualnie Załadunku: {WagaZaladunku()}: \n";
        foreach (Kontener k in kontenery)
        {
            str += $"{licznik++}: {k}\n";
        }
        return str;
    }
    public double WagaZaladunku()
    {
        double waga = 0;
        foreach (Kontener k in kontenery)
            waga += k.WagaWlasna + k.MasaLadunku;
        return waga;
    }
    public Kontener? ZnajdzKontener(string idKontenera)
    {
        foreach (Kontener k in kontenery)
            if (k.NumerSeryjny.Equals(idKontenera))
                return k;
        return null;
    }
}