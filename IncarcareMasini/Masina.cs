using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncarcareMasini
{
    public class Masina
    {
        const int kwPeOra = 11;
        public string name { get; set; }
        public int availableBattery { get; set; } // baterie disponibila
        public int capacitateTotala  {get; set; } // capacitatea total a masini in kW
        public int procentFinal  {get; set; } // procentual cat sa fie incarcata masina
        public DateTime oraAlimentare {get; set; } // ora sosirii masinii
        public int durataIncarcarii { get; set; } // in minute
        public int nrOreAsteptare { get; set; } // nr de ore dupa care se va intoarce proprietarul
        public int nrMinimDeAsteptare { get; set; } // nr Minim dintre nr de Ore de asteptare si numarul de Ore de incarcare


        public Masina(string name, int availableBattery, int capacitateTotala, int procentFinal, DateTime oraAlimentare, int nrOreAsteptare)
        {
            this.name = name;
            this.availableBattery = availableBattery;
            this.capacitateTotala = capacitateTotala;
            this.procentFinal = procentFinal;
            this.oraAlimentare = oraAlimentare;
            this.nrOreAsteptare = nrOreAsteptare;
        }

        public void calculeazaDurataIncarcarii()
        {
            int procentNecesar = this.procentFinal - this.availableBattery;
            float kwNecesari = (procentNecesar * capacitateTotala) / 100;
            this.durataIncarcarii = (int) Math.Round(((capacitateTotala / kwNecesari) * 60));
        }

        public void ordonareDupaTimp()
        {
            this.nrMinimDeAsteptare = nrOreAsteptare * 60 - durataIncarcarii;
        }

    }
}
