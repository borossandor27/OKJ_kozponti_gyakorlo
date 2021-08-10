using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hegylancok
{
    class Hegylanc
    {
        byte[] hegymagassagok;
        int hegyek = 0;
        bool hegy = false;
        public int hegyek_szama = 0;
        bool hegylanc = false;
        public int leghosszabb_hegylanc_hossza = 0;
        double leghosszabb_hegylanc_atlaga;

        public Hegylanc()
        {
            Random r = new Random();
            //-- 2.a. Inicializálja a vektort 80 elemszámmal! -----------------------------
            hegymagassagok = new byte[80];
            hegymagassagok[0] = 0;
            hegymagassagok[1] = 0;
            hegymagassagok[2] = 0;
            for (int i = 3; i < hegymagassagok.Length-3; i++)
            {
                //-- 2.c. Töltse fel a vektor további elemeit véletlenszerűen 1−15 közötti egész számokkal!
                hegymagassagok[i] = (byte)r.Next(1, 15 + 1);
                //-- 2.d. A vektorban a páros számokat írja felül 0-val! ---------------------
                if (hegymagassagok[i] %2 == 0)
                {
                    hegymagassagok[i] = 0;
                }
            }
            hegymagassagok[77] = 0;
            hegymagassagok[78] = 0;
            hegymagassagok[79] = 0;
        }

        public void Feladat_04(bool kiemel)
        {
            int hegylanc_hossza = 0;
            Console.Write("000");
            for (int i = 3; i < hegymagassagok.Length-3; i++)
            {
                hegy = hegymagassagok[i - 1] == 0 && hegymagassagok[i + 1] == 0 ? true : false;
                if (hegy)
                {
                    hegyek_szama++;
                    if (kiemel)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                }
                else if (hegymagassagok[i - 1] == 0 && hegymagassagok[i + 1] != 0)
                {
                    hegylanc = true;
                    hegylanc_hossza = 1;
                }
                else if (hegylanc && hegymagassagok[i] != 0)
                {
                    hegylanc_hossza++;
                }
                else if (hegylanc && hegymagassagok[i] == 0)
                {
                    leghosszabb_hegylanc_hossza = (hegylanc_hossza > leghosszabb_hegylanc_hossza) ? hegylanc_hossza : leghosszabb_hegylanc_hossza;
                    hegylanc_hossza = 0;
                    hegylanc = false;
                }

                switch (hegymagassagok[i])
                {
                    case 1:
                        Console.Write('1');
                        break;
                    case 2:
                        Console.Write('2');
                        break;
                    case 3:
                        Console.Write('3');
                        break;
                    case 4:
                        Console.Write('4');
                        break;
                    case 5:
                        Console.Write('5');
                        break;
                    case 6:
                        Console.Write('6');
                        break;
                    case 7:
                        Console.Write('7');
                        break;
                    case 8:
                        Console.Write('8');
                        break;
                    case 9:
                        Console.Write('9');
                        break;
                    case 10:
                        Console.Write('A');
                        break;
                    case 11:
                        Console.Write('B');
                        break;
                    case 12:
                        Console.Write('C');
                        break;
                    case 13:
                        Console.Write('D');
                        break;
                    case 14:
                        Console.Write('E');
                        break;
                    case 15:
                        Console.Write('F');
                        break;
                    default:
                        Console.Write('0');
                        break;
                }
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine("000");
        }
    }
}
