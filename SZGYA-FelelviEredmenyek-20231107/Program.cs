using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SZGYA_FelelviEredmenyek_20231107
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Tanulo> tanulok = new List<Tanulo>();
            StreamReader sr = new StreamReader("../../../src/tanulok.txt", Encoding.UTF8);
            _ = sr.ReadLine();
            for (int i = 1; !sr.EndOfStream; i++)
            {
                string sor = sr.ReadLine();
                if (i % 2 == 0)
                {
                    tanulok.Add(new Tanulo(sor));
                }
            }

            Console.WriteLine($"1.feladat: osztályátlag: {osszAtlag(tanulok)}");
            foreach (var x in tantargyAtlag(tanulok))
            {
                Console.WriteLine($"\t{x.Key}: {x.Value}");
            }

        }

        static double osszAtlag(List<Tanulo> tanulok)
        {
            return tanulok.Average(t => t.Atlag);
        }

        static Dictionary<string, double> tantargyAtlag(List<Tanulo> tanulok)
        {
            Dictionary<string, double> atlagok = new Dictionary<string, double>();
            foreach (var x in tanulok.First().Jegyek.Keys)
            {
                atlagok[x] = tanulok.Average(t => t.Jegyek[x]);
            }
            return atlagok;
        }
    }
}
