using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Helsinki2017
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Versenyzo> versenyzok = Versenyzo.KurBeolvasas(Versenyzo.RovidProgramBeolvas());

            Console.WriteLine("2. feladat\n\tA rövidprogramban {0} induló volt", versenyzok.Count);

            Versenyzo hun = versenyzok.Where(v => v.Orszag == "HUN").FirstOrDefault();
            Console.WriteLine("3. feladat\n\tA magyar versenyző {0} a kűrbe", hun.Donto ? "bejutott" : "nem jutott be");

            Console.Write("5. feladat\n\tKérem a versenyző nevét: ");
            string nev = Console.ReadLine();
            if (versenyzok.Any(v=>v.Nev == nev))
            {
                Versenyzo versenyzo = versenyzok.Where(v => v.Nev == nev).FirstOrDefault();
                Console.WriteLine("6. feladat\n\tA versenyző összpontszáma: {0}", versenyzo.OsszPontszam);
            }
            else
            {
                Console.WriteLine("\tIlyen nevű induló nem volt");
            }

            Dictionary<string, int> osszesites = new Dictionary<string, int>();
            foreach (var v in versenyzok)
            {
                if (v.Donto)
                {
                    if (osszesites.ContainsKey(v.Orszag))
                        osszesites[v.Orszag]++;
                    else
                        osszesites.Add(v.Orszag, 1);
                }
            }
            Console.WriteLine("7. feladat");
            foreach (var item in osszesites)
                if (item.Value > 1)
                    Console.WriteLine("\t{0}: {1} versenyző", item.Key, item.Value);

            StreamWriter sw = new StreamWriter("vegeredmeny.csv", false, Encoding.UTF8);
            List<Versenyzo> rendezett = versenyzok.OrderByDescending(v => v.OsszPontszam).ToList();
            for (int i = 0; i < rendezett.Count; i++)
            {
                sw.WriteLine("{0};{1};{2};{3}", i + 1, rendezett[i].Nev, rendezett[i].Orszag, rendezett[i].OsszPontszam.ToString().Replace(".", ","));
            }
            sw.Close();
            Console.ReadKey();

        }
    }
}
