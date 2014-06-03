using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoradcaWyjazdowWypoczynkowych.Models
{
    public class MetrykaKategorii
    {
        public int Komfort { get; set; }
        public int Zwiedzanie { get; set; }
        public int Aktywnosc { get; set; }
        public int Imprezowosc { get; set; }
        public int BliskoNatury { get; set; }

        public MetrykaKategorii(int Komfort, int Zwiedzanie, int Aktywnosc, int Imprezowosc, int BliskoNatury)
        {
            this.Komfort = Komfort;
            this.Zwiedzanie = Zwiedzanie;
            this.Aktywnosc = Aktywnosc;
            this.Imprezowosc = Imprezowosc;
            this.BliskoNatury = BliskoNatury;
        }

        public MetrykaKategorii(Kategoria cat)
             : this(cat.Komfort, cat.Zwiedzanie, cat.Aktywnosc, cat.Imprezowosc, cat.BliskoNatury)
        {
        }

        public double PorownajDopasowanie(MetrykaKategorii celPorownania)
        {
            int K = Math.Abs(celPorownania.Komfort - this.Komfort);
            int Z = Math.Abs(celPorownania.Zwiedzanie - this.Zwiedzanie);
            int A = Math.Abs(celPorownania.Aktywnosc - this.Aktywnosc);
            int I = Math.Abs(celPorownania.Imprezowosc - this.Imprezowosc);
            int BN = Math.Abs(celPorownania.BliskoNatury - this.BliskoNatury);

            //zwraca średnie odchylenie
            return ((double)(K + Z + A + I + BN) / 5);
        }
    }
}