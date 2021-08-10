using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutyak
{
    class KutyaFajtak
    {
        int id;
        string nev;
        string eredeti_nev;

        public int Id { get => id; set => id = value; }
        public string Nev { get => nev; set => nev = value; }
        public string Eredeti_nev { get => eredeti_nev; set => eredeti_nev = value; }

        public KutyaFajtak(int id, string nev, string eredeti_nev)
        {
            this.id = id;
            this.nev = nev;
            this.eredeti_nev = eredeti_nev;
        }
    }
}
