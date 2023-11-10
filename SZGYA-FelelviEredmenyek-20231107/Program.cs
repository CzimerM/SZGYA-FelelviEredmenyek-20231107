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
            string[] tantargyak = sr.ReadLine().Split("\t");
            for (int i = 1; !sr.EndOfStream; i++)
            {
                string sor = sr.ReadLine();
                if (i % 2 == 0)
                {
                    tanulok.Add(new Tanulo(sor, tantargyak));
                }
            }
            sr.Close();
            Console.WriteLine($"1.feladat: osztályátlag: {osszAtlag(tanulok)}");
            foreach (var x in tantargyAtlag(tanulok))
            {
                Console.WriteLine($"\t{x.Key}: {x.Value}");
            }

            List<String> bukottak = tanulok.Where(t => t.Jegyek["Programozás"] == 1).Select(t => t.Nev).ToList();
            Console.WriteLine($"2.feladat: {String.Join(", ", bukottak)}");

            Tanulo angolHarmas = harmasAngol(tanulok);
            if (angolHarmas != null)
            {
                Console.WriteLine($"3.feladat: \n\t{angolHarmas}");
            }

            Console.Write("4.feladat: Írja be a tanuló nevét: ");
            string tanuloNev = Console.ReadLine();
            var (legjobb, lTan) = legjobbTantargy(tanuloNev, tanulok);
            if(legjobb.Key == null)
            {
                Console.WriteLine("[HIBA] nincs ilyen");
                return;
            }
            Console.WriteLine(legjobb);
            var sw = new StreamWriter("../../../src/legjobb.txt", false, Encoding.UTF8);
            sw.WriteLine($"{lTan.Nev}\t{lTan.Azonosito}");
            sw.Close();
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

        static Tanulo harmasAngol(List<Tanulo> tanulok)
        {
            return tanulok.FirstOrDefault(t => t.Jegyek["Angol nyelv"] == 3);
        }

        static (KeyValuePair<string,int>, Tanulo) legjobbTantargy(string nev, List<Tanulo> tanulok)
        {
            Tanulo legjobb = tanulok.FirstOrDefault(t => t.Nev.ToLower() == nev.ToLower());
            if (legjobb == null)
            {
                return (new KeyValuePair<string, int>(null,0),null);
            }
            return (legjobb.Jegyek.First(j => j.Value == legjobb.Jegyek.Max(j => j.Value)), legjobb);
        }
    }
}
