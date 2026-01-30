namespace SklepZoologiczny.Models;

class Zabawka : Produkt
{
    public string Material { get; private set; }

    public Zabawka(int id, string nazwa, decimal cena, string material)
        : base(id, nazwa, cena)
    {
        Material = material;
    }

    public override string Opis()
    {
        return $"Zabawka: {Nazwa}, Materiał: {Material}, Cena: {Cena} zł";
    }
}
