using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Robot
{
    class Program
    {
        static List<Kodsorozat> Kodok = new List<Kodsorozat>();
        static void Main(string[] args)
        {
            ForrastBeolvas();
            Console.WriteLine($"\n2. Feladat: Tanulók száma: {Kodok.Count} fő");
            Console.WriteLine($"\n3. Feladat: Helytelen kódsorozatok száma: {Kodok.Where(a => a.Hibas).Count()}");
            Feladat04();
            double max = Kodok.Where(a => !a.Hibas).Max(b => b.Tavolsag);
            Console.WriteLine($"\n5. Feladat: Legtávolabbra jutó robot vezérlését készítette: {Kodok.Find(b => b.Tavolsag == max).Nev}");
            Console.WriteLine("\nProgram vége!");
            Console.ReadKey();
        }

        static void ForrastBeolvas()
        {
            string forras = @"..\..\progs.txt";
            using (StreamReader sr = new StreamReader(forras))
            {
                while (!sr.EndOfStream)
                {
                    string[] sor = sr.ReadLine().Split();
                    Kodok.Add(new Kodsorozat(sor[0], sor[1]));
                }
            }
        }

        static void Feladat04()
        {
            using (StreamWriter sw = new StreamWriter("ivsz.txt"))
            {
                foreach (Kodsorozat item in Kodok.Where(a => !a.Hibas))
                {
                    Console.WriteLine($"{item.Nev} {item.Ivsz}");
                    sw.WriteLine($"{item.Nev} {item.Ivsz}");
                }
            }
        }
    }
}
