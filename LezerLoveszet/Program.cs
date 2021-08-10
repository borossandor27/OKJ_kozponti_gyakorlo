using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LezerLoveszet
{
    class Program
    {
        static List<JatekosLovese> Lovesek = new List<JatekosLovese>();
        static void Main(string[] args)
        {
            Beolvas();
            Console.WriteLine($"\n5. feladat: Lövések száma: {Lovesek.Count} db");

            Console.WriteLine($"\n7. feladat: Legpontosabb lövés:");
            JatekosLovese Legpontosabb = Lovesek.Find(a => a.Distance == Lovesek.Min(b => b.Distance));
            Console.WriteLine($"\t{Legpontosabb.Ssz}; {Legpontosabb.Nev}; x={Legpontosabb.X}; y={Legpontosabb.Y}; tavolsag={Legpontosabb.Distance}");

            Console.WriteLine($"\n9. feladat: Nulla pontos lovesek száma: {Lovesek.Where(a => a.Pontszam ==0).Count()} db");

            //-- 10. Számolja meg és írja ki a képernyőre a játékban részvevő játékosok számát a minta szerint! -----
            Console.WriteLine($"\n10. feladat: Játékosok száma: {Lovesek.GroupBy(a => a.Nev).Count()}");

            //-- 11. Határozza meg játékosonként a leadott lövések számát! ------------------------------------------
            Console.WriteLine($"\n11. feladat: Lövések száma");
            foreach (var item in Lovesek.GroupBy(a => a.Nev).Select(b => new { nev = b.Key, db = b.Count()}))
            {
                Console.WriteLine($"\t{item.nev} - {item.db} db");
            }

            //-- 12. Számítsa ki az átlagpontszámokat, majd jelenítse meg a minta szerint! ---------------------------
            Console.WriteLine($"\n12. feladat: Átlag pontszámok");
            var atlagok = Lovesek.GroupBy(a => a.Nev).Select(b => new { nev = b.Key, atlag = b.Average(c => c.Pontszam) });
            foreach (var item in atlagok)
            {
                Console.WriteLine($"\t{item.nev} - {item.atlag}");
            }

            //-- 13. Határozza meg a legmagasabb átlagpontszám alapján a nyertes játékos nevét!  ----------------------
            Console.WriteLine($"\n13. feladat: A jatek nyertese: {atlagok.OrderBy(a => a.atlag).Last().nev}");
            Console.WriteLine("\nProgram vége!");
            Console.ReadKey();
        }
        static void Beolvas()
        {
            Console.WriteLine("Forrás beolvasása...");
            string forras = @"../../lovesek.txt";
            try
            {
                using (StreamReader sr = new StreamReader(forras))
                {
                    //-- A fájl első sora mindíg a Céltábla középpontjának a koordinátáit tartalmazza
                    string[] sor = sr.ReadLine().Split(';');
                    double celtablaX = double.Parse(sor[0]);
                    double celtablaY = double.Parse(sor[1]);
                    //-- A versenyzők lövéseit is beolvassuk ----------------------------------------
                    int i = 1;      //-- a lövések számozását 1-től indítjuk ------------------------
                    while (!sr.EndOfStream)
                    {
                        sor = sr.ReadLine().Split(';');
                        JatekosLovese uj = new JatekosLovese(i++, sor[0], double.Parse(sor[1]), double.Parse(sor[2]));
                        uj.Tavolsag(celtablaX, celtablaY);  //-- így nem kell majd külön meghívni a tavolság és a pontszám meghatározásához
                        Lovesek.Add(uj);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                Environment.Exit(0);    //-- Nincs forrás, akkor kilépa programból!
            }
            Console.WriteLine("Beolvasás vége!");
        }
    }
}
