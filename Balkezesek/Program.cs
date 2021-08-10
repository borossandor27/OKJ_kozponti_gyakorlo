using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Balkezesek
{
    class Program
    {
        static List<Jetekos> jatekosok = new List<Jetekos>();
        static int ev = 0;
        static void Main(string[] args)
        {
            Beolvas(@"..\..\balkezesek.csv");
            Console.WriteLine($"3. feladat: {jatekosok.Count} db adatsor van.");
            Console.WriteLine("\n4. feladat:");
            Feladat_04();
            Feladat_05();
            Feladat_06();
            Console.WriteLine("\nProgram vége!");
            Console.ReadKey();
        }
        static void Beolvas(string forras) 
        {
            try
            {
                using (StreamReader sr = new StreamReader(forras))
                {
                    sr.ReadLine();
                    while (!sr.EndOfStream)
                    {
                        jatekosok.Add(new Jetekos(sr.ReadLine().Split(';')));
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(0);
            }
        }
        /// <summary>
        /// 4.	Határozza meg, és írja ki a minta szerint, azoknak a játékosoknak a nevét 
        ///     és testmagasságát centiméterben (1 inch 2,54 cm), 
        ///     akik utoljára 1999 októberében léptek pályára! 
        ///     Az eredményt egy tizedesjegyre kerekítve írja ki a képernyőre!
        /// </summary>
        static void Feladat_04()
        {
            foreach (Jetekos item in jatekosok.FindAll(a => a.Utolso.Year == 1999 && a.Utolso.Month == 10))
            {
                Console.WriteLine($"\t{item.Nev}, { item.Magassag*2.54:N1} cm");
            }
        }
        /// <summary>
        /// 5.	Kérjen be a felhasználótól egy évszámot a minta szerint! 
        ///     Az évszámra teljesülni kell az 1990 évszám 1999 feltételnek, 
        ///     amennyiben a felhasználó hibás évszámot
        /// </summary>
        static void Feladat_05()
        {
            Console.WriteLine("\n5. feladat:");
            int szamol = 0;
            do
            {
                if (szamol > 0)
                {
                    Console.Write("Hibás adat! ");
                }
                Console.Write("Kérek egy 1990 és 1999 közötti egész számot! ");
                szamol++;
            } while (!(int.TryParse(Console.ReadLine(),out ev) && ev >= 1990 && ev <= 1999));
        }
        /// <summary>
        /// 6.  Határozza meg és írja ki a minta szerint, mennyi az átlagsúlya a játékosoknak, 
        ///     akik az előző feladatban bekért évben pályára léptek! 
        ///     Az eredményt két tizedesjegyre kerekítve írja ki a képernyőre! 
        ///     Feltételezheti, hogy az első és az utolsó pályára lépés dátuma között minden évben játszottak a játékosok. 
        /// </summary>
        static void Feladat_06() 
        {
            double atlag = jatekosok.FindAll(a => a.Elso.Year >= ev && a.Utolso.Year <= ev).Average(b => b.Suly);
            Console.WriteLine($"\n6. feladat: {atlag:N2}");        
        }

    }
}
