using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hegylancok
{
    class Program
    {
        static Hegylanc hegylanc = new Hegylanc();

        static void Main(string[] args)
        {
            Console.WriteLine("4. feladat:");
            hegylanc.Feladat_04(false);

            Console.WriteLine($"\n5. feladat: Hegyek száma: {hegylanc.hegyek_szama} db");

            hegylanc.Feladat_04(true);

            Console.WriteLine("\nProgram vége!");
            Console.ReadKey();
        }
    }
}
