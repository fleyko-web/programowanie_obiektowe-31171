using SklepZoologiczny.Models;
using SklepZoologiczny.Services;
using System.Linq;


List<Produkt> produkty = new List<Produkt>();
bool dziala = true;

while (dziala)
{
    Console.WriteLine("\n--- SKLEP ZOOLOGICZNY ---");
    Console.WriteLine("1. Wyświetl dostępne zwierzęta");
    Console.WriteLine("2. Wyświetl karmy i zabawki");
    Console.WriteLine("3. Dodaj zwierzę");
    Console.WriteLine("4. Dodaj karmę lub zabawkę");
    Console.WriteLine("5. Aktualizuj zwierzę");
    Console.WriteLine("6. Aktualizuj karmę lub zabawkę");
    Console.WriteLine("7. Wyjdź z systemu");

    string wybor = Console.ReadLine();

    switch (wybor)
    {
        case "1":
            foreach (var p in produkty)
                if (p is Zwierze)
                    Console.WriteLine(p.Opis());
            break;

        case "2":
            foreach (var p in produkty)
                if (p is Karma || p is Zabawka)
                    Console.WriteLine(p.Opis());
            break;

        case "3":
            Console.Write("Nazwa zwierzęcia: ");
            string nz = Console.ReadLine();
            Console.Write("Cena: ");
            decimal cz = decimal.Parse(Console.ReadLine());
            Console.Write("Gatunek: ");
            string g = Console.ReadLine();

            produkty.Add(new Zwierze(
                produkty.Count + 1, nz, cz, g
            ));
            break;

        case "4":
            Console.WriteLine("1. Karma");
            Console.WriteLine("2. Zabawka");
            string typ = Console.ReadLine();

            Console.Write("Nazwa: ");
            string n = Console.ReadLine();
            Console.Write("Cena: ");
            decimal c = decimal.Parse(Console.ReadLine());

            if (typ == "1")
            {
                Console.Write("Waga (kg): ");
                int w = int.Parse(Console.ReadLine());
                produkty.Add(new Karma(produkty.Count + 1, n, c, w));
            }
            else if (typ == "2")
            {
                Console.Write("Materiał: ");
                string m = Console.ReadLine();
                produkty.Add(new Zabawka(produkty.Count + 1, n, c, m));
            }
            break;

        case "5": // aktualizacja zwierzęcia
            Console.Write("Podaj nazwę zwierzęcia: ");
            string nazwaZ = Console.ReadLine();

            var zw = produkty
                .FirstOrDefault(p => p is Zwierze && 
                                     p.Nazwa.Equals(nazwaZ, StringComparison.OrdinalIgnoreCase))
                as Zwierze;

            if (zw == null)
            {
                Console.WriteLine("Nie znaleziono zwierzęcia.");
            }
            else
            {
                Console.Write("Nowa cena: ");
                decimal nowaCena = decimal.Parse(Console.ReadLine());
                zw.ZmienCene(nowaCena);
                Console.WriteLine("Zwierzę zaktualizowane.");
            }
            break;

        case "6": // aktualizacja karmy lub zabawki
            Console.Write("Podaj nazwę produktu: ");
            string nazwaP = Console.ReadLine();

            var prod = produkty
                .FirstOrDefault(p =>
                    (p is Karma || p is Zabawka) &&
                    p.Nazwa.Equals(nazwaP, StringComparison.OrdinalIgnoreCase));

            if (prod == null)
            {
                Console.WriteLine("Nie znaleziono produktu.");
            }
            else
            {
                Console.Write("Nowa cena: ");
                decimal nc = decimal.Parse(Console.ReadLine());
                prod.ZmienCene(nc);
                Console.WriteLine("Produkt zaktualizowany.");
            }
            break;

        case "7":
            PlikManager.Zapisz(produkty);
            dziala = false;
            break;
    }
}
