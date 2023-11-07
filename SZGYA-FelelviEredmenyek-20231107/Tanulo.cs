using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZGYA_FelelviEredmenyek_20231107
{
    class Tanulo
    {
        public string Nev { get; set; }
        public long Azonosito { get; set; }
        public Dictionary<string, int> Jegyek { get; set; }

        public double Atlag => this.Jegyek.Values.Average();

        public Tanulo(string sor)
        {
            string[] adatok = sor.Split("\t");
            this.Nev = adatok[0];
            this.Azonosito = long.Parse(adatok[1]);
            this.Jegyek = new Dictionary<string, int>();
            this.Jegyek["halozatok1"] = int.Parse(adatok[2]);
            this.Jegyek["halozatok2"] = int.Parse(adatok[3]);
            this.Jegyek["programozas"] = int.Parse(adatok[4]);
            this.Jegyek["programozas_gyak"] = int.Parse(adatok[5]);
            this.Jegyek["angol"] = int.Parse(adatok[6]);
            this.Jegyek["magyar"] = int.Parse(adatok[7]);
            this.Jegyek["matek"] = int.Parse(adatok[8]);
            this.Jegyek["tori"] = int.Parse(adatok[9]);
        }
    }
}
