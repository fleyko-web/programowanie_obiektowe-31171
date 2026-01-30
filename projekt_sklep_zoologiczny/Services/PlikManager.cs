using System.Text.Json;
using SklepZoologiczny.Models;

namespace SklepZoologiczny.Services;

class PlikManager
{
    private static string sciezka = "produkty.json";

    public static void Zapisz(List<Produkt> produkty)
    {
        var opcje = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(produkty, opcje);
        File.WriteAllText(sciezka, json);
    }

    public static List<Produkt> Wczytaj()
    {
        if (!File.Exists(sciezka))
            return new List<Produkt>();

        string json = File.ReadAllText(sciezka);
        return JsonSerializer.Deserialize<List<Produkt>>(json)
               ?? new List<Produkt>();
    }
}
