using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hianyzasok
{
    class Tanulo
    {
        int honap;
        int nap;
        string nev;
        string jelenlet;
        int igazolt;
        int igazolatlan;

        public int Honap { get => honap; set => honap = value; }
        public int Nap { get => nap; set => nap = value; }
        public string Nev { get => nev; set => nev = value; }
        public string Jelenlet { get => jelenlet; set => jelenlet = value; }
        public int Igazolt { get => igazolt; set => igazolt = value; }
        public int Igazolatlan { get => igazolatlan; set => igazolatlan = value; }

        public Tanulo(int honap, int nap, string nev, string jelenlet)
        {
            this.honap = honap;
            this.nap = nap;
            this.nev = nev;
            this.jelenlet = jelenlet;
            for (int i = 0; i < jelenlet.Length; i++)
            {
                switch (jelenlet[i])
                {
                    case 'X':
                        igazolt++;
                        break;
                    case 'I':
                        igazolatlan++;
                        break;
                    default:
                        break;
                }
            }
        }

        string hetnapja(int honap, int nap)
        {
            string[] napnev = new string[] { "vasarnap", "hetfo", "kedd", "szerda", "csutortok", "pentek", "szombat" };
            int[] napszam = new int[] { 0, 31, 59, 90, 120, 151, 181, 212, 243, 273, 304, 335 };
            int napsorszam = (napszam[honap - 1] + nap) % 7;
            return napnev[napsorszam];
        }
    }
}
