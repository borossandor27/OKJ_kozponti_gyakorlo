using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoPapirOllo
{
    class Jatek
    {
        static readonly string[] Lehetoseg = new string[] { "kő", "papír", "olló" };
        //-- Elso dim az elso valasztasa, masodik oszlop a második jatekos valasztasa -------------
        static readonly int[,] EredmenyTablazat = new int[,]
        {
            { 0,2,1},
            { 1,0,2},
            { 2,1,0}
        };
        //-- jelentése
        static readonly string[] EredmenySzoveg = new string[] { "döntetlen", "első játékos nyert", "második játékos nyert" };

        int elsoJatekosDontese;
        int masodikJatekosDontese;
        public int EredmenyKodolva;

        public Jatek(int elsoJatekosDontese, int masodikJatekosDontese)
        {
            this.elsoJatekosDontese = elsoJatekosDontese;
            this.masodikJatekosDontese = masodikJatekosDontese;
            this.EredmenyKodolva = EredmenyTablazat[elsoJatekosDontese, masodikJatekosDontese];
        }

    }
}
