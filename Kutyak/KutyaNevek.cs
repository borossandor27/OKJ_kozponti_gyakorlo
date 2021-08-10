using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutyak
{
    class KutyaNevek
    {
        int id;
        string kutyanev;

        public int Id { get => id; set => id = value; }
        public string Kutyanev { get => kutyanev; set => kutyanev = value; }

        public KutyaNevek(int id, string kutyanev)
        {
            this.id = id;
            this.kutyanev = kutyanev;
        }
    }
}
