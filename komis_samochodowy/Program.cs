class Program
{
    static void Main()
    {
        Komis komis = new Komis();
        bool dziala = true;

        while (dziala)
        {
            Console.WriteLine("\n--- KOMIS SAMOCHODOWY ---");
            Console.WriteLine("1. Dodaj pojazd");
            Console.WriteLine("2. Usuń pojazd");
            Console.WriteLine("3. Wyświetl pojazdy");
            Console.WriteLine("4. Modyfikuj pojazd");
            Console.WriteLine("0. Wyjście");

            Console.Write("Wybór: ");
            string wybor = Console.ReadLine();

            switch (wybor)
            {
                case "1":
                    Dodaj(komis);
                    break;
                case "2":
                    Console.Write("Podaj ID: ");
                    int id = int.Parse(Console.ReadLine());
                    komis.UsunPojazd(id);
                    break;
                case "3":
                    komis.Wyswietl();
                    break;
                case "4":
                  Console.Write("Podaj ID pojazdu do modyfikacji: ");
                   int modId = int.Parse(Console.ReadLine());
                    komis.ModyfikujPojazd(modId);
                    break;
                case "0":
                    dziala = false;
                    break;
            }
        }
    }

    static void Dodaj(Komis komis)
    {
        Console.Write("Marka: ");
        string marka = Console.ReadLine();

        Console.Write("Model: ");
        string model = Console.ReadLine();

        Console.Write("Rok: ");
        int rok = int.Parse(Console.ReadLine());

        Console.Write("Cena: ");
        decimal cena = decimal.Parse(Console.ReadLine());

        komis.DodajPojazd(new Pojazd
        {
            Marka = marka,
            Model = model,
            Rok = rok,
            Cena = cena
        });
    }
}
