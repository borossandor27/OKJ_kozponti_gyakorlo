using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LezerLoveszet
{
    class JatekosLovese
    {
        int ssz;
        string nev;
        double x;
        double y;
        double tavolsag;
        double pont;

        public int Ssz { get => ssz; }
        public string Nev { get => nev; }
        public double X { get => x; }
        public double Y { get => y; set => y = value; }

        public JatekosLovese(int ssz, string nev, double x, double y)
        {
            this.ssz = ssz;
            this.nev = nev;
            this.x = x;
            this.y = y;
        }

        public double Tavolsag(double CeltablaX, double CeltablaY)
        {
            //-- 6. feladat --------------------------------------------------------------------------
            double dx = CeltablaX - x;
            double dy = CeltablaY - y;
            tavolsag = Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2));
           //-- Ez már a 8. feladat, de itt a praktikus
            pont = Math.Round(10 - tavolsag > 0 ? 10 - tavolsag : 0, 2);   //-- A pont nem lehet negatív!
            return tavolsag;
        }
        public double Pontszam { get => pont; } //-- 8. feladat ---------------------------
        public double Distance { get => tavolsag; }
    }
}
