using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace KoPapirOllo
{
    class Program
    {

        static List<Jatek> jatekok = new List<Jatek>();
        static void Main(string[] args)
        {

            Feladat01();
            Feladat02();
            Feladat03();
            Feladat04();

            Console.WriteLine("\nProgram vége!");
            Console.ReadKey();
        }

        static void Feladat01()
        {
            Console.WriteLine("1. Feladat:");
            int elso = VersenyzoDontese("az első");
            int masodik = VersenyzoDontese("a második");
            jatekok.Add(new Jatek(elso, masodik));
        }

        static void Feladat02()
        {
            Console.WriteLine("\n2. Feladat:");
            //int kod = jatekok[0].EredmenyKodolva();
            Console.WriteLine($"\t\aEredmény kódolva (0-döntetlen, 1-első nyert, 2-második nyert): {jatekok[0].EredmenyKodolva}");
        }

        static void Feladat03()
        {
            Console.WriteLine("\n3. Feladat:");
            string forras = @"..\..\jatek.txt";
            using (StreamReader sr = new StreamReader(forras))
            {
                while (!sr.EndOfStream)
                {
                    string[] sor = sr.ReadLine().Split('-');
                    jatekok.Add(new Jatek(int.Parse(sor[0]), int.Parse(sor[1])));
                }
            }
            Console.WriteLine($"\tTovábbi játékok száma: {jatekok.Count - 1}");
        }

        static void Feladat04()
        {
            Console.WriteLine("\n4. Feladat:");
            var v = jatekok.Where(a => a.EredmenyKodolva == 0);
            Console.WriteLine($"\tDöntetlenek: {jatekok.Where(a => a.EredmenyKodolva == 0).Count()} db");
            Console.WriteLine($"\tElső játékos nyert: {jatekok.Where(a => a.EredmenyKodolva == 1).Count()} db");
            Console.WriteLine($"\tMásodik játékos nyert: {jatekok.Where(a => a.EredmenyKodolva == 2).Count()} db");
        }
        static int VersenyzoDontese(string nev)
        {
            int d = 0;
            do
            {
                Console.Write($"\n\tKérem {nev} játékos választását kódolva (0-kő, 1-papír, 2-olló): ");
            } while (!(int.TryParse(Console.ReadLine(),out d) && (d == 1 || d == 2 || d == 0)));
            return d;
        }
    }
}
