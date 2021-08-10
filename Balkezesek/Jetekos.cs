using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balkezesek
{
    class Jetekos
    {
        string nev;
        DateTime elso;
        DateTime utolso;
        int suly;
        int magassag;

        public string Nev { get => nev; set => nev = value; }
        public DateTime Elso { get => elso; set => elso = value; }
        public DateTime Utolso { get => utolso; set => utolso = value; }
        public int Suly { get => suly; set => suly = value; }
        public int Magassag { get => magassag; set => magassag = value; }
  
        public Jetekos(string[] sor)
        {
            Nev = sor[0];
            Elso = DateTime.Parse(sor[1]);
            Utolso = DateTime.Parse(sor[2]);
            Suly = int.Parse(sor[3]);
            Magassag = int.Parse(sor[4]);
        }
    }
}
