namespace SklepZoologiczny.Models;

abstract class Produkt
{
    public int Id { get; private set; }
    public string Nazwa { get; protected set; }
    public decimal Cena { get; protected set; }

    protected Produkt(int id, string nazwa, decimal cena)
    {
        Id = id;
        Nazwa = nazwa;
        Cena = cena;
    }

    public abstract string Opis();

    public void ZmienCene(decimal nowaCena)
{
    Cena = nowaCena;
}
}


