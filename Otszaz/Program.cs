using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Otszaz
{
    class Program
    {
        static List<Kosar> kosarak = new List<Kosar>();
        static void Main(string[] args)
        {
            Beolvas("penztar.txt");
            Console.WriteLine("adatok beolvasa!");
            Console.WriteLine("\n2. feladat");
            Console.WriteLine($"\tA fizetések száma: {kosarak.Count}");

            Console.WriteLine("\n3. feladat");
 
            Console.WriteLine($"\tAz első vásárló {kosarak.First().cikkek.Count} darab árucikket vásárolt.");

            Console.WriteLine("\n4. feladat");
            int ssz = 0;
            do
            {
                Console.Write("\tAdja meg egy vásárlás sorszámát! ");
            } while (!int.TryParse(Console.ReadLine(), out ssz) || ssz < 1 || ssz > kosarak.Count);
            string cikk = string.Empty;
            do
            {
                Console.Write("\tAdja meg egy árucikk nevét! ");
                cikk = Console.ReadLine();
            } while (string.IsNullOrEmpty(cikk));

            int darab = 0;
            do
            {
                Console.Write("\tAdja meg a vásárolt darabszámot! ");
            } while (!int.TryParse(Console.ReadLine(),out darab) || darab < 1 );

            Console.WriteLine("\n5.feladat");
            var valami = kosarak.FindAll(a => a.cikkek.Any(b => b.Cikknev.Equals(cikk)));
            Console.WriteLine($"\tAz első vásárlás sorszáma: {valami.First().KosarSzam}");
            Console.WriteLine($"\tAz utolsó vásárlás sorszáma: {valami.Last().KosarSzam}");
            Console.WriteLine($"\t{valami.Count} vásárlás során vettek belőle.");

            Console.WriteLine("\n6. feladat");
            Console.WriteLine($"\t{darab} darab vételekor fizetendő: {ertek(darab)}");

            Console.WriteLine("\n7. feladat");
            foreach (var item in kosarak[ssz-1].cikkek.GroupBy(a => a.Cikknev).Select(b => new { cikknev = b.Key, db = b.Count() }))
            {
                Console.WriteLine($"\t{item.db} {item.cikknev}");
            }

            Console.WriteLine("\n8. feladat");
            using (StreamWriter sw = new StreamWriter("osszeg.txt"))
            {
                foreach (var item in kosarak)
                {
                    sw.WriteLine($"{item.KosarSzam}: {item.Ertek}");
                }
            }
            Console.WriteLine("\tosszeg.txt létrehozva");
            Console.WriteLine("\nProgram vége");
            Console.ReadKey();
        }
         static void Beolvas(string fajl)
        {
            using (StreamReader sr = new StreamReader(fajl))
            {
                Kosar kosar = new Kosar();
                while(!sr.EndOfStream)
                {
                    string cikk = sr.ReadLine();
                    if (cikk.Equals("F"))
                    {
                        kosarak.Add(kosar);
                        kosar = new Kosar();
                    }
                    else
                    {
                        kosar.ujCikk(cikk);
                    }
                }
            }
        }

        public static int ertek(int db)
        {
            int v = 0;
            if (db == 1)
            {
                v = 500;
            }
            if (db==2)
            {
                v = 500 + 450;
            }
            if (db == 3)
            {
                v = 500 + 450 + 400;
            }
            if (db > 3)
            {
                v = 500 + 450 + 400 * (db - 2);
            }
            return v;
        }
    }
}
