using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otszaz
{
    class VasaroltCikk
    {
        string cikknev;
        int fizetendo; //-- Eredetileg minde 500, de a kosarban változhat

        public VasaroltCikk(string cikknev, int ar)
        {
            this.Cikknev = cikknev;
            this.fizetendo = ar;
        }

        public string Cikknev { get => cikknev; set => cikknev = value; }
        public int Ertek { get => fizetendo; set => fizetendo = value; }
    }
}
