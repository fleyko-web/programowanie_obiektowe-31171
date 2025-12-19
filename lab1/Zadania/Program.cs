using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== WYBIERZ ZADANIE ===\n");
            Console.WriteLine("1 - Zadanie 1");
            Console.WriteLine("2 - Zadanie 2");
            Console.WriteLine("3 - Zadanie 3");
            Console.WriteLine("4 - Zadanie 4");
            Console.WriteLine("5 - Zadanie 5");
            Console.WriteLine("6 - Zadanie 6");
            Console.WriteLine("7 - Zadanie 7");
            Console.WriteLine("0 - Wyjazd ;D");
            Console.Write("\nPodaj numer zadania: ");

            string wybor = Console.ReadLine();

            Console.Clear();

            switch (wybor)
            {
                case "1": Zadanie1(); break;
                case "2": Zadanie2(); break;
                case "3": Zadanie3(); break;
                case "4": Zadanie4(); break;
                case "5": Zadanie5(); break;
                case "6": Zadanie6(); break;
                case "7": Zadanie7(); break;
                case "0": return;
                default:
                    Console.WriteLine("Bruh takie zadanie nie istnieje");
                    break;
            }

            Console.WriteLine("\nNacisnij dowolny klawisz aby wrocic do menu");
            Console.ReadKey();
        }
    }

    // Zadanie 1
    static void Zadanie1()
    {
        Console.WriteLine("=== Zadanie 1 ===\n");
        string password;
        do
        {
            Console.Write("Podaj hasło: ");
            password = Console.ReadLine();
        } while (password != "admin123");

        Console.WriteLine("WOW!!!!!!!!!! Poprawne hasło :D ;D :D");
    }

    // Zadanie 2
    static void Zadanie2()
    {
        Console.WriteLine("=== Zadanie 2 ===\n");
        int liczba;
        do
        {
            Console.Write("Podaj liczbę większą od zera: ");
            liczba = Convert.ToInt32(Console.ReadLine());
        } while (liczba <= 0);

        Console.WriteLine("To faktycznie była liczba wieksza od zera... ");
        Console.WriteLine("co? chcesz oklaski? brothaaaa...");
    }

    // Zadanie 3
    static void Zadanie3()
    {
        Console.WriteLine("=== Zadanie 3 ===\n");
        string[] miasta = { "Warszawa", "Kraków", "Gdańsk", "Wrocław", "Poznań" };
        foreach (string miasto in miasta)
        {
            Console.WriteLine(miasto);
        }
    }

    // Zadanie 4
    static void Zadanie4()
    {
        Console.WriteLine("=== Zadanie 4 ===\n");
        Osoba o1 = new Osoba { Imie = "Mieszko 1", Wiek = 21, Zawód = "Książe" };
        Osoba o2 = new Osoba { Imie = "Bolesław", Wiek = 25, Zawód = "Król" };
        Osoba o3 = new Osoba { Imie = "Jania", Wiek = 35, Zawód = "Strongmenka" };
        o1.PrzedstawSie();
        o2.PrzedstawSie();
        o3.PrzedstawSie();
    }

    class Osoba
    {
        public string Imie;
        public int Wiek;
        public string Zawód;
        public void PrzedstawSie() => Console.WriteLine($"Nazywam się {Imie} i mam {Wiek} lat i mój zawód to {Zawód}.");
    }

    // Zadanie 5
    static void Zadanie5()
    {
        Console.WriteLine("=== Zadanie 5 ===\n");
        KontoBankowe konto = new KontoBankowe();
        Console.WriteLine($"Saldo: {konto.PobierzSaldo()}");
        konto.Wyplata(500);
        konto.Wyplata(600);
        konto.Wplata(200);
        konto.Wyplata(300);
    }

    class KontoBankowe
    {
        private double saldo = 1000;
        public void Wplata(double k) => saldo += k;

        public void Wyplata(double k)
        {
            if (k > saldo) Console.WriteLine("Brak środków na koncie sadek chyba trzeba wpłacic ehhh?? sugar daddy <3");
            else
            {
                saldo -= k;
                Console.WriteLine($"Wypłacono {k}. Pozostało: {saldo}");
            }
        }

        public double PobierzSaldo() => saldo;
    }

    // Zadanie 6
    static void Zadanie6()
    {
        Console.WriteLine("=== Zadanie 6 ===\n");
        Pies pies = new Pies();
        Kot kot = new Kot();
        pies.Jedz();
        pies.Szczekaj();
        kot.Jedz();
        kot.Miaucz();
    }

    class Zwierze
    {
        public void Jedz() => Console.WriteLine("Zwierzę je");
    }

    class Pies : Zwierze
    {
        public void Szczekaj() => Console.WriteLine("Hau hau wouf wouf");
    }

    class Kot : Zwierze
    {
        public void Miaucz() => Console.WriteLine("Miau Miau Miau");
    }

    // Zadanie 7
    static void Zadanie7()
    {
        Console.WriteLine("=== Zadanie 7 ===\n");
        ZwierzePoly[] zoo = { new PiesPoly(), new KotPoly(), new PiesPoly(), new KotPoly() };
        foreach (ZwierzePoly z in zoo) z.DajGlos();
    }

    class ZwierzePoly
    {
        public virtual void DajGlos() => Console.WriteLine("Zwierzę wydaje dźwięk");
    }

    class PiesPoly : ZwierzePoly
    {
        public override void DajGlos() => Console.WriteLine("Hau hau!");
    }

    class KotPoly : ZwierzePoly
    {
        public override void DajGlos() => Console.WriteLine("Miau!");
    }
}
