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

        public Tanulo(string sor, string[] tantargyak)
        {
            string[] adatok = sor.Split("\t");
            this.Nev = adatok[0];
            this.Azonosito = long.Parse(adatok[1]);
            this.Jegyek = new Dictionary<string, int>();
            for (int i = 2; i <= 9; i++)
            {
                this.Jegyek[tantargyak[i]] = int.Parse(adatok[i]);
            }
        }

        public override string ToString()
        {
            return $"{this.Nev,-15}|{this.Azonosito,-11}|{string.Join("; ", this.Jegyek)}";
        }
    }
}
