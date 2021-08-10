using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Hianyzasok
{
    class Program
    {
        static List<Tanulo> tanulok = new List<Tanulo>();

        static void Main(string[] args)
        {
            Beolvas(@"..\..\naplo.txt");
            Console.WriteLine("2. feladat:");
            Console.WriteLine($"\tA naplóban {tanulok.Count} bejegyzés van.");

            Console.WriteLine("\n3. feladat:");
            Console.WriteLine($"Az igazolt hiányzások száma {tanulok.Sum(a => a.Igazolt)}, az igazolatlanoké {tanulok.Sum(a => a.Igazolatlan)} óra. ");
            Console.WriteLine("\nProgram vége!");
            Console.ReadKey();
        }

        static void Beolvas(string forras)
        {
            try
            {
                using (StreamReader sr = new StreamReader(forras))
                {
                    while (!sr.EndOfStream)
                    {
                        int honap = 0;
                        int nap = 0;
                        string nev;
                        string jelenlet;
                        string[] sor = sr.ReadLine().Split();
                        string egysor;
                        if (sor[0].Equals("#"))
                        {
                            honap = int.Parse(sor[1]);
                            nap = int.Parse(sor[2]);
                        }
                        else
                        {
                            egysor = string.Join(" ", sor);
                            nev = egysor.Substring(0, egysor.Length - 7).Trim();
                            jelenlet = egysor.Substring(egysor.Length - 7, 7);
                            tanulok.Add(new Tanulo(honap, nap, nev, jelenlet));
                        }
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
    }
}
