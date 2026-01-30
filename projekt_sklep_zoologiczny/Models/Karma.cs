namespace SklepZoologiczny.Models;

class Karma : Produkt
{
    public int WagaKg { get; private set; }

    public Karma(int id, string nazwa, decimal cena, int wagaKg)
        : base(id, nazwa, cena)
    {
        WagaKg = wagaKg;
    }

    public override string Opis()
    {
        return $"Karma: {Nazwa}, Waga: {WagaKg} kg, Cena: {Cena} zł";
    }
}
