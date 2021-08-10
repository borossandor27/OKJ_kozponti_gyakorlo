using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Helsinki2017
{
    class Versenyzo
    {
        public string Nev { get; set; }
        public string Orszag { get; set; }
        public double RovidPrTech { get; set; }
        public double RovidPrKomp { get; set; }
        public int RovidPrLevonas { get; set; }
        public double KurTech { get; set; }
        public double KurKomp { get; set; }
        public int KurLevonas { get; set; }
        public bool Donto { get; set; }

        public Versenyzo(string sor)
        {
            var a = sor.Split(';');
            Nev = a[0];
            Orszag = a[1];
            RovidPrTech = Convert.ToDouble(a[2].Replace(".", TizedesElvalaszto));
            RovidPrKomp = Convert.ToDouble(a[3].Replace(".", TizedesElvalaszto));
            RovidPrLevonas = Convert.ToInt32(a[4]);  
            Donto = false;
        }

        public static string TizedesElvalaszto
        {
            get
            {
                return (0.2).ToString().Substring(1, 1);
            }
        }

        public double OsszPontszam
        {
            get
            {
                return RovidPrTech + RovidPrKomp - RovidPrLevonas + KurTech + KurKomp + KurLevonas;
            }
        }


        public static List<Versenyzo> RovidProgramBeolvas()
        {
            var lista = new List<Versenyzo>();
            using (StreamReader sr = new StreamReader("rovidprogram.csv", Encoding.UTF8))
            {
                sr.ReadLine();
                while (!sr.EndOfStream)
                    lista.Add(new Versenyzo(sr.ReadLine()));
            }
            return lista;
        }

        public static List<Versenyzo> KurBeolvasas(List<Versenyzo> lista)
        {
            using (StreamReader sr = new StreamReader("donto.csv", Encoding.UTF8)) {
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    string sor = sr.ReadLine();
                    var a = sor.Split(';');
                    Versenyzo versenyzo = lista.Where(v => v.Nev == a[0]).FirstOrDefault();
                    versenyzo.KurTech = Convert.ToDouble(a[2].Replace(".", TizedesElvalaszto));
                    versenyzo.KurKomp = Convert.ToDouble(a[2].Replace(".", TizedesElvalaszto));
                    versenyzo.KurLevonas = Convert.ToInt32(a[4]);
                    versenyzo.Donto = true;
                }
            }
            return lista;
        }


    }
}
