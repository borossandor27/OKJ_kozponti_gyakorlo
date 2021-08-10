using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Kutyak
{
    class Program
    {
        static List<Kutyak> kutyak = new List<Kutyak>();
        static List<KutyaNevek> kutyaNevek = new List<KutyaNevek>();
        static List<KutyaFajtak> kutyaFajtak = new List<KutyaFajtak>();
        static void Main(string[] args)
        {
            KutyaNevek_Beolvasasa(@"..\..\KutyaNevek.csv");
            KutyaFajtak_Beolvasasa(@"..\..\KutyaFajtak.csv");
            Kutyak_Beolvasasa(@"..\..\Kutyak.csv");
            Console.WriteLine($"\n3. feladat: A kutyanevek száma: {kutyaNevek.Count}");
            Console.WriteLine($"\n6. feladat: A kutyák átlagéletkora: {kutyak.Average(a => a.Eletkor):N2}");
            Kutyak legidosebb = kutyak.Find(a => a.Eletkor == kutyak.Max(b => b.Eletkor));
            Console.WriteLine($"\n7. feladat: A Legidősebb kutya neve és fajtája: {kutyaNevek.Find(a => a.Id == legidosebb.Nev_id).Kutyanev}, {kutyaFajtak.Find(a => a.Id == legidosebb.Fajta_id).Nev}");
            //-- 2018. január 10-én a rendelőben járt kutyák ----
            Console.WriteLine($"\n8. feladat: január 10.-én vizsgált kutya fajták");
            foreach (var item in kutyak.FindAll(a => a.Utolso_orvosi_ellenorzes.Year == 2018 && a.Utolso_orvosi_ellenorzes.Month == 1 && a.Utolso_orvosi_ellenorzes.Day == 10).GroupBy(b => b.Fajta_id).Select(c => new { fajta_id = c.Key, db = c.Count() }))
            {
                Console.WriteLine($"\t{kutyaFajtak.Find(a => a.Id == item.fajta_id).Nev}: {item.db} kutya");
            }
            var ll = kutyak.GroupBy(a => a.Utolso_orvosi_ellenorzes).Select(b => new { datum = b.Key, db = b.Count() }).OrderByDescending(c => c.db).First();
            Console.WriteLine($"\n9. feladat: A legjobban leterhelt nap: {ll.datum.ToString("yyyy.MM.dd")}: {ll.db} kutya");
            Console.WriteLine("\n10.feladat: nevstatisztika.txt");
            using (StreamWriter sw = new StreamWriter("nevstatisztika.txt"))
            {
                foreach (var item in kutyak.GroupBy(a => a.Nev_id).Select(b => new { nev_id = b.Key, db = b.Count() }).OrderByDescending(c => c.db))
                {
                    sw.WriteLine($"{kutyaNevek.Find(a => a.Id == item.nev_id).Kutyanev};{item.db}");
                }
            }
            Console.WriteLine("\nProgram vége!");
            Console.ReadKey();
        }

        static void KutyaNevek_Beolvasasa(string forras)
        {
            try
            {
                using (StreamReader sr = new StreamReader(forras))
                {
                    sr.ReadLine(); //-- fejléc átugrása
                    while (!sr.EndOfStream)
                    {
                        string[] sor = sr.ReadLine().Split(';');
                        kutyaNevek.Add(new KutyaNevek(int.Parse(sor[0]), sor[1]));
                    }
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message + "\nA program leáll!");
                Environment.Exit(0);
            }
        }
        static void KutyaFajtak_Beolvasasa(string forras)
        {
            try
            {
                using (StreamReader sr = new StreamReader(forras))
                {
                    sr.ReadLine(); //-- fejléc átugrása
                    while (!sr.EndOfStream)
                    {
                        string[] sor = sr.ReadLine().Split(';');
                        kutyaFajtak.Add(new KutyaFajtak(int.Parse(sor[0]), sor[1], sor[2]));
                    }
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message + "\nA program leáll!");
                Environment.Exit(0);
            }
        }
        static void Kutyak_Beolvasasa(string forras)
        {
            try
            {
                using (StreamReader sr = new StreamReader(forras))
                {
                    sr.ReadLine(); //-- fejléc átugrása
                    while (!sr.EndOfStream)
                    {
                        string[] sor = sr.ReadLine().Split(';');
                        kutyak.Add(new Kutyak(int.Parse(sor[0]), int.Parse(sor[1]), int.Parse(sor[2]), int.Parse(sor[3]), DateTime.Parse(sor[4])));
                    }
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message + "\nA program leáll!");
                Environment.Exit(0);
            }
        }
    }
}
