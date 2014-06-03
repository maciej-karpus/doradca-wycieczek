using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoradcaWyjazdowWypoczynkowych.Models
{
    public class ChartData
    {
        public static List<ChartData> GetData(MetrykaKategorii uzytkownik, MetrykaKategorii oferta1, MetrykaKategorii oferta2, MetrykaKategorii oferta3)
        {
            var data = new List<ChartData>();

            data.Add(new ChartData("Komfort", uzytkownik.Komfort, oferta1.Komfort, oferta2.Komfort, oferta3.Komfort));
            data.Add(new ChartData("Zwiedzanie", uzytkownik.Zwiedzanie, oferta1.Zwiedzanie, oferta2.Zwiedzanie, oferta3.Zwiedzanie));
            data.Add(new ChartData("Aktywnosc", uzytkownik.Aktywnosc, oferta1.Aktywnosc, oferta2.Aktywnosc, oferta3.Aktywnosc));
            data.Add(new ChartData("Imprezowosc", uzytkownik.Imprezowosc, oferta1.Imprezowosc, oferta2.Imprezowosc, oferta3.Imprezowosc));
            data.Add(new ChartData("Blisko Natury", uzytkownik.BliskoNatury, oferta1.BliskoNatury, oferta2.BliskoNatury, oferta3.BliskoNatury));

            return data;
        }

        public ChartData(string label, double value1, double value2, double value3, double value4)
        {
            this.Label = label;
            this.Value1 = value1;
            this.Value2 = value2;
            this.Value3 = value3;
            this.Value4 = value4;
        }

        public string Label { get; set; }
        public double Value1 { get; set; }
        public double Value2 { get; set; }
        public double Value3 { get; set; }
        public double Value4 { get; set; }
    }
}