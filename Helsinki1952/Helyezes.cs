using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helsinki1952
{
    class Helyezes
    {
        string helyezes;
        int letszam;
        string sportag;
        string versenyszam;
        int pont;

        public string Hely { get => helyezes; set => helyezes = value; }
        public int Letszam { get => letszam; set => letszam = value; }
        public string Sportag { get => sportag; set => sportag = value; }
        public string Versenyszam { get => versenyszam; set => versenyszam = value; }
        public int Pont { get => pont; set => pont = value; }

        public Helyezes(string hely, int letszam, string sportag, string versenyszam)
        {
            Hely = hely;
            Letszam = letszam;
            Sportag = sportag;
            Versenyszam = versenyszam;
            switch (hely)
            {
                case "1":
                    pont = 7;
                    break;
                case "2":
                    pont = 5;
                    break;
                case "3":
                    pont = 4;
                    break;
                case "4":
                    pont = 3;
                    break;
                case "5":
                    pont = 2;
                    break;
                case "6":
                    pont = 1;
                    break;
                default:
                    pont = 0;
                    break;
            }
        }
        public override string ToString()
        {
            return string.Join(" ", helyezes, letszam, pont, sportag, versenyszam);
        }
    }
}
