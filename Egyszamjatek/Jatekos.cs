using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egyszamjatek
{
    class Jatekos
    {
        string nev;
        int[] tipp;

        public string Nev { get => nev; set => nev = value; }
        public int[] Tipp { get => tipp; set => tipp = value; }

        public Jatekos(string[] adatok)
        {
            this.nev = adatok[adatok.Length - 1];
            tipp = new int[adatok.Length - 1];
            for (int i = 0; i < tipp.Length; i++)
            {
                tipp[i] = int.Parse(adatok[i]);
            }
        }
    }
}
