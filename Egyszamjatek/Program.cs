using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Egyszamjatek
{
    class Program
    {
        static List<Jatekos> jatekosok = new List<Jatekos>();

        static void Main(string[] args)
        {
            Beolvas(@"..\..\egyszamjatek.txt");
            Console.WriteLine($"\n3. feladat: Játékosok száma: {jatekosok.Count}");
            Console.WriteLine($"\n4. feladat: Fordulók száma: {jatekosok[0].Tipp.Length}");
            if (jatekosok.FindAll(a => a.Tipp[0]==1).Count > 0)
            {
                Console.WriteLine("\n5. feladat: Az egyes fordulóban volt egyes tipp.");
            }
            else
            {
                Console.WriteLine("\n5. feladat: Az egyes fordulóban NEM volt egyes tipp.");
            }

            //-- 6. Határozza meg és írja ki a minta szerint, hogy a fordulók során melyik volt a legnagyobb tipp! 
            int max = jatekosok.Max(a => a.Tipp.Max());
            Console.WriteLine($"\n6. feladat: A legnagyobb tipp a fordulók során: {max}");

            int ssz = Fordulo() - 1;
            //int ssz = 0;
            int nyertesek = jatekosok.GroupBy(a => a.Tipp[ssz]).Select(b => new { tipp = b.Key, db = b.Count() }).Where(c => c.db == 1).Count();
            if (nyertesek == 0)
            {
                Console.WriteLine("8. feladat: Nem volt nyertes a megadott fordulóban!");
            }
            else
            {
                //-- A fordulónak volt nyertese ------------------------------------
                int nyertes_tipp = jatekosok.GroupBy(a => a.Tipp[ssz]).Select(b => new { tipp = b.Key, db = b.Count() }).Where(c => c.db == 1).OrderBy(d => d.tipp).First().tipp;
                Console.WriteLine($"8. feladat: A nyertes tipp a megadott fordulóban: {nyertes_tipp}");
                string nyertes_nev = jatekosok.Find(a => a.Tipp[ssz] == nyertes_tipp).Nev;
                Console.WriteLine($"9. feladat: A megadott forduló nyertese: {nyertes_nev}");
                using (StreamWriter sw = new StreamWriter("nyertes.txt"))
                {
                    sw.WriteLine($"Forduló sorszáma: {ssz}.");
                    sw.WriteLine($"Nyertes tipp: {nyertes_tipp}");
                    sw.WriteLine($"Nyertes játékos: {nyertes_nev}");
                }
            }

            Console.WriteLine("\nProgram vége!");
            Console.ReadKey();
        }
        static void Beolvas(string forras)
        {
            Console.WriteLine("Adatok beolvasása...");
            try
            {
                using (StreamReader sr = new StreamReader(forras))
                {
                    while (!sr.EndOfStream)
                    {
                        jatekosok.Add(new Jatekos(sr.ReadLine().Split()));
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                Environment.Exit(0);
            }
        }

        static int Fordulo()
        {
            Console.Write("7. feladat: Kérem a forduló sorszámát [1−" + jatekosok[0].Tipp.Length + "]: ");
            int f = int.Parse(Console.ReadLine());
            if (f > jatekosok[0].Tipp.Length )
            {
                f = 1;
            }
            return f;
        }
    }
}
