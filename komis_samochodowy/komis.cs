using System.Text.Json;

public class Komis
{
    private const string Plik = "pojazdy.json";
    public List<Pojazd> Pojazdy { get; set; }

    public Komis()
    {
        Wczytaj();
    }

    public void Wczytaj()
    {
        if (File.Exists(Plik))
        {
            string json = File.ReadAllText(Plik);
            Pojazdy = JsonSerializer.Deserialize<List<Pojazd>>(json) ?? new List<Pojazd>();
        }
        else
        {
            Pojazdy = new List<Pojazd>();
        }
    }

    public void Zapisz()
    {
        string json = JsonSerializer.Serialize(Pojazdy, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(Plik, json);
    }

    public void DodajPojazd(Pojazd p)
    {
        p.Id = Pojazdy.Count == 0 ? 1 : Pojazdy.Max(x => x.Id) + 1;
        Pojazdy.Add(p);
        Zapisz();
    }

    public void UsunPojazd(int id)
    {
        Pojazdy.RemoveAll(p => p.Id == id);
        Zapisz();
    }

    public void Wyswietl()
    {
        if (Pojazdy.Count == 0)
        {
            Console.WriteLine("Brak pojazdów.");
            return;
        }

        foreach (var p in Pojazdy)
        {
            Console.WriteLine($"{p.Id}. {p.Marka} {p.Model}, {p.Rok}, {p.Cena} zł");
        }
    }
    public void ModyfikujPojazd(int id)
{
    var pojazd = Pojazdy.FirstOrDefault(p => p.Id == id);

    if (pojazd == null)
    {
        Console.WriteLine("Nie znaleziono pojazdu.");
        return;
    }

    Console.Write($"Nowa marka ({pojazd.Marka}): ");
    string marka = Console.ReadLine();
    if (!string.IsNullOrEmpty(marka))
        pojazd.Marka = marka;

    Console.Write($"Nowy model ({pojazd.Model}): ");
    string model = Console.ReadLine();
    if (!string.IsNullOrEmpty(model))
        pojazd.Model = model;

    Console.Write($"Nowy rok ({pojazd.Rok}): ");
    string rokInput = Console.ReadLine();
    if (!string.IsNullOrEmpty(rokInput))
        pojazd.Rok = int.Parse(rokInput);

    Console.Write($"Nowa cena ({pojazd.Cena}): ");
    string cenaInput = Console.ReadLine();
    if (!string.IsNullOrEmpty(cenaInput))
        pojazd.Cena = decimal.Parse(cenaInput);

    Zapisz();
    Console.WriteLine("Pojazd zmodyfikowany.");
}

}
