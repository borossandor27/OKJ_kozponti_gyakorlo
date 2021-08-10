using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot
{
    class Kodsorozat
    {
        readonly string nev;
        readonly string kod; //-- EJBH
        int ivsz;   //-- irányváltások száma
        int vegpontX = 0;
        int vegpontY = 0;
        double tavolsag;
        bool hibas = false;

        public string Nev => nev;

        public string Kod => kod;

        public int Ivsz { get => ivsz; set => ivsz = value; }
        public int VegpontX { get => vegpontX; set => vegpontX = value; }
        public int VegpontY { get => vegpontY; set => vegpontY = value; }
        public double Tavolsag { get => tavolsag; set => tavolsag = value; }

        public bool Hibas => hibas;

        public Kodsorozat(string nev, string kod)
        {
            this.nev = nev;
            this.kod = kod;
            this.ivsz = Iranyvaltasok();
            this.tavolsag = Math.Sqrt(Math.Pow(vegpontX, 2) + Math.Pow(vegpontY, 2));
        }
        int Iranyvaltasok()
        {
            int v = 0;
            char elozo = kod[0];
            foreach (char item in kod)
            {
                if (!item.Equals(elozo)) { v++; elozo = item; }
                switch (item)
                {
                    case 'J':
                        vegpontX++;
                        break;
                    case 'B':
                        vegpontX--;
                        break;
                    case 'E':
                        vegpontY++;
                        break;
                    case 'H':
                        vegpontY--;
                        break;
                    default:
                        hibas = true;
                        break;
                }
            }
            return v;
        }
    }
}
