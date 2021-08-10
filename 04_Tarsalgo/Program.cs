using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _04_Tarsalgo
{
    class Program
    {
        static List<Athaladas> Athaladasok = new List<Athaladas>();

        static void Main(string[] args)
        {
            Beolvas();
            Console.WriteLine("2. Feladat");
            Console.WriteLine($"Az első belépő: {Athaladasok[0].Azon}");
            Console.WriteLine($"Az utolsó kilépő: {Athaladasok.Last(a => a.Irany.Equals("ki")).Azon}");
            Feladat03();
            Feladat04();
            Feladat05();
            Console.WriteLine("\n6. Feladat");
            Console.Write("\tAdja meg a személy azonosítóját! ");
            int szemely = int.Parse(Console.ReadLine());
            Feladat07(szemely);
            Console.WriteLine("\nProgram vége!");
            Console.ReadKey();
        }

        static void Beolvas()
        {
            string forras = @"..\..\ajto.txt";
            using (StreamReader sr = new StreamReader(forras))
            {
                while (!sr.EndOfStream)
                {
                    string[] s = sr.ReadLine().Split();
                    Athaladasok.Add(new Athaladas(int.Parse(s[0]), int.Parse(s[1]), s[2], s[3]));
                }
            }
        }
        /// <summary>
        ///  Határozza meg a fájlban szereplő személyek közül, 
        ///  ki hányszor haladt át a társalgó ajtaján! 
        ///  A meghatározott értékeket azonosító szerint növekvő 
        ///  sorrendben írja az athaladas.txt fájlba! 
        ///  Soronként egy személy azonosítója, 
        ///  és tőle egy szóközzel elválasztva az áthaladások száma szerepeljen! 
        /// </summary>
        static void Feladat03()
        {
            using (StreamWriter sw = new StreamWriter("athaladas.txt"))
            {
                foreach (var item in Athaladasok.GroupBy(a => a.Azon).Select(b => new { azon=b.Key, db=b.Count()}).OrderByDescending(c => c.db))
                {
                    sw.WriteLine($"{item.azon} {item.db}");
                }
            }
        }

        /// <summary>
        /// 4. Írja a képernyőre azon személyek azonosítóját, 
        ///    akik a vizsgált időszak végén a társalgóban tartózkodtak! 
        /// </summary>
        static void Feladat04()
        {
            Console.WriteLine("4. Feladat");
            Console.Write("\tA végén a társalgóban voltak: ");
            foreach (var item in Athaladasok.GroupBy(a => a.Azon).Select(b => new { azon = b.Key, db = b.Count() }).Where(c => c.db % 2 != 0).OrderBy(d => d.azon))
            {
                Console.Write($"{item.azon} ");
            }
            Console.WriteLine("");
        }

        /// <summary>
        /// 5. Hányan voltak legtöbben egyszerre a társalgóban? 
        ///    Írjon a képernyőre egy olyan időpontot (óra:perc), 
        ///    amikor a legtöbben voltak bent!
        /// </summary>
        static void Feladat05()
        {
            Console.WriteLine("\n5. feladat");
            DateTime maxIdo = (DateTime)Athaladasok.Find(a => a.BentLevokSzama == Athaladasok.Max(b => b.BentLevokSzama)).Ido;
            Console.WriteLine($"\tPéldául {maxIdo.ToString("HH:mm")}-kor voltak legtöbben a társalgóban");
        }

        /// <summary>
        /// 7. Írja a képernyőre, hogy a beolvasott azonosítóhoz tartozó 
        ///    személy mettől meddig tartózkodott a társalgóban!  
        /// </summary>
        /// <param name="sz">A személy azonosítója</param>
        static void Feladat07(int sz)
        {
            Console.WriteLine("\n7. Feladat");
            var tartozkodott = Athaladasok.FindAll(a => a.Azon.Equals(sz.ToString()));
            if (tartozkodott.Count()%2 == 0)
            {
                int i;
                for (i = 0; i < tartozkodott.Count(); i = i + 2)
                {
                    Console.WriteLine($"\t{tartozkodott[i].Ido.ToString("HH:mm")} - {tartozkodott[i + 1].Ido.ToString("HH:mm")}");
                }
            }
            else
            {
                int i;
                for (i = 0; i < tartozkodott.Count()-1; i = i + 2)
                {
                    Console.WriteLine($"\t{tartozkodott[i].Ido.ToString("HH:mm")} - {tartozkodott[i + 1].Ido.ToString("HH:mm")}");
                }
                Console.WriteLine($"\t{tartozkodott[i].Ido.ToString("HH:mm")} - ");
            }
        }
    }
}
