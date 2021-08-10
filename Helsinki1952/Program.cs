using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Helsinki1952
{
    class Program
    {
        static List<Helyezes> helyezesek = new List<Helyezes>();

        static void Main(string[] args)
        {
            Beolvasas(@"..\..\helsinki.txt");
            Console.WriteLine("\n3. Feladat");
            Console.WriteLine($"\tPontszerző helyezések száma: {helyezesek.Count}");

            Console.WriteLine("\n4. Feladat");
            Console.WriteLine($"\tArany: {helyezesek.FindAll(a => a.Hely.Equals("1")).Count()}");
            Console.WriteLine($"\tEzüst: {helyezesek.FindAll(a => a.Hely.Equals("2")).Count()}");
            Console.WriteLine($"\tBronz: {helyezesek.FindAll(a => a.Hely.Equals("3")).Count()}");
            Console.WriteLine($"\tÖsszesen: {helyezesek.FindAll(a => a.Hely.Equals("1")|| a.Hely.Equals("2")|| a.Hely.Equals("3")).Count()}");

            Console.WriteLine("\n5. Feladat");
            Console.WriteLine($"\tOlimpiai pontok száma: {helyezesek.Sum(a => a.Pont)}");

            Console.WriteLine("\n6. Feladat");
            int uszas = helyezesek.FindAll(a => (a.Hely.Equals("1") || a.Hely.Equals("2") || a.Hely.Equals("3")) && a.Sportag.Equals("uszas")).Count();
            int torna = helyezesek.FindAll(a => (a.Hely.Equals("1") || a.Hely.Equals("2") || a.Hely.Equals("3")) && a.Sportag.Equals("torna")).Count();
            if (uszas > torna)
            {
                Console.WriteLine("\tÚszás sportágban szereztek több érmet");
            }
            else if (torna > uszas)
            {
                Console.WriteLine("\tTorna sportágban szereztek több éremt");
            }
            else
            {
                Console.WriteLine("\tEgyenlő volt az érmek száma");
            }

            Console.WriteLine("\n7. Feladat");
            using (StreamWriter sw = new StreamWriter("helsinki2.txt"))
            {
                foreach (Helyezes item in helyezesek)
                {
                    if (item.Sportag.Equals("kajakkenu"))
                    {
                        item.Sportag = Convert.ToString("kajak-kenu");
                    }
                    sw.WriteLine(item);
                }
                
            }
            //-- melyik pontszerző helyezéshez fűződik a legtöbb sportoló?
            Console.WriteLine("\n8. Feladat");
            Helyezes legtobb = helyezesek.Find(a => a.Letszam == helyezesek.Max(b => b.Letszam));
            Console.WriteLine($"\tHelyezés: {legtobb.Hely}");
            Console.WriteLine($"\tSportág: {legtobb.Sportag}");
            Console.WriteLine($"\tVersenyszam: {legtobb.Versenyszam}");
            Console.WriteLine($"\tSportolók száma: {legtobb.Letszam}");

            Console.WriteLine("\nProgram vége!");
            Console.ReadKey();
        }
        /// <summary>
        /// Forrásadatok beolvasása és tárolása dinamikus tömbben
        /// </summary>
        /// <param name="forras">Forrásfájl neve és elérési útja</param>
        static void Beolvasas(string forras)
        {
            Console.WriteLine("\nForrásadatok beolvasása...");
            try
            {
                using (StreamReader sr = new StreamReader(forras))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] sor = sr.ReadLine().Split();
                        helyezesek.Add(new Helyezes(sor[0], int.Parse(sor[1]), sor[2], sor[3]));
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                Environment.Exit(0);
            }
            Console.WriteLine("Sikeres beolvasás!");
        }
    }
}
