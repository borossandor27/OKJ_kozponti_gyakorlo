using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutyak
{
    class Kutyak
    {
        int id;
        int fajta_id;
        int nev_id;
        int eletkor;
        DateTime utolso_orvosi_ellenorzes;

        public int Id { get => id; set => id = value; }
        public int Fajta_id { get => fajta_id; set => fajta_id = value; }
        public int Nev_id { get => nev_id; set => nev_id = value; }
        public int Eletkor { get => eletkor; set => eletkor = value; }
        public DateTime Utolso_orvosi_ellenorzes { get => utolso_orvosi_ellenorzes; set => utolso_orvosi_ellenorzes = value; }

        public Kutyak(int id, int fajta_id, int nev_id, int eletkor, DateTime utolso_orvosi_ellenorzes)
        {
            this.id = id;
            this.fajta_id = fajta_id;
            this.nev_id = nev_id;
            this.eletkor = eletkor;
            this.utolso_orvosi_ellenorzes = utolso_orvosi_ellenorzes;
        }
    }
}
