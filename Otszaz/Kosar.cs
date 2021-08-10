using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otszaz
{
    class Kosar
    {
        public List<VasaroltCikk> cikkek = new List<VasaroltCikk>();
        int kosarErteke = 0;
        static int ssz = 0;
        int kosarSzam;

        public int KosarSzam { get => kosarSzam; }
        public int Ertek { get => kosarErteke; set => kosarErteke = value; }

        public Kosar()
        {
            kosarSzam = ++ssz;
        }

        public void ujCikk(string cikknev)
        {

            int db = cikkek.FindAll(a => a.Cikknev.Equals(cikknev)).Count() + 1;
            int ar = (db == 1 ? 500 : (db == 2) ? 450 : 400);
            cikkek.Add(new VasaroltCikk(cikknev, ar));
            kosarErteke += ar;
            
            
        }
    }
}
