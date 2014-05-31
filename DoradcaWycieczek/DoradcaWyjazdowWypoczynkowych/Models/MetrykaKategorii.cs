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

        double PorownajDopasowanie(MetrykaKategorii celPorownania)
        {
            int K = Math.Abs((celPorownania.Komfort - this.Komfort) * 100);
            int Z = Math.Abs((celPorownania.Zwiedzanie - this.Zwiedzanie) * 100);
            int A = Math.Abs((celPorownania.Aktywnosc - this.Aktywnosc) * 100);
            int I = Math.Abs((celPorownania.Imprezowosc - this.Imprezowosc) * 100);
            int BN = Math.Abs((celPorownania.BliskoNatury - this.BliskoNatury) * 100);

            //zwraca średnie odchylenie
            return (100-((K + Z + A + I + BN) / 5));
        }
    }
}