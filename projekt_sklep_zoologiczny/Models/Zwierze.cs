namespace SklepZoologiczny.Models;

class Zwierze : Produkt
{
    public string Gatunek { get; private set; }

    public Zwierze(int id, string nazwa, decimal cena, string gatunek)
        : base(id, nazwa, cena)
    {
        Gatunek = gatunek;
    }

    public override string Opis()
    {
        return $"Zwierzę: {Nazwa}, Gatunek: {Gatunek}, Cena: {Cena} zł";
    }
}
