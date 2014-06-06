using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoradcaWyjazdowWypoczynkowych.Models
{
    public class ChartData
    {
        public static List<ChartData> GetData(MetrykaKategorii uzytkownik, MetrykaKategorii oferta1, MetrykaKategorii oferta2, MetrykaKategorii oferta3, MetrykaKategorii oferta4, MetrykaKategorii oferta5, MetrykaKategorii oferta6, MetrykaKategorii oferta7)
        {
            var data = new List<ChartData>();

            data.Add(new ChartData("Komfort", uzytkownik.Komfort, oferta1.Komfort, oferta2.Komfort, oferta3.Komfort, oferta4.Komfort, oferta5.Komfort, oferta6.Komfort, oferta7.Komfort));
            data.Add(new ChartData("Zwiedzanie", uzytkownik.Zwiedzanie, oferta1.Zwiedzanie, oferta2.Zwiedzanie, oferta3.Zwiedzanie, oferta4.Zwiedzanie, oferta5.Zwiedzanie, oferta6.Zwiedzanie, oferta7.Zwiedzanie));
            data.Add(new ChartData("Aktywnosc", uzytkownik.Aktywnosc, oferta1.Aktywnosc, oferta2.Aktywnosc, oferta3.Aktywnosc, oferta4.Aktywnosc, oferta5.Aktywnosc, oferta6.Aktywnosc, oferta7.Aktywnosc));
            data.Add(new ChartData("Imprezowosc", uzytkownik.Imprezowosc, oferta1.Imprezowosc, oferta2.Imprezowosc, oferta3.Imprezowosc, oferta4.Imprezowosc, oferta5.Imprezowosc, oferta6.Imprezowosc, oferta7.Imprezowosc));
            data.Add(new ChartData("Blisko Natury", uzytkownik.BliskoNatury, oferta1.BliskoNatury, oferta2.BliskoNatury, oferta3.BliskoNatury, oferta4.BliskoNatury, oferta5.BliskoNatury, oferta6.BliskoNatury, oferta7.BliskoNatury));

            return data;
        }

        public ChartData(string label, double value1, double value2, double value3, double value4, double value5, double value6, double value7, double value8)
        {
            this.Label = label;
            this.Value1 = value1;
            this.Value2 = value2;
            this.Value3 = value3;
            this.Value4 = value4;
            this.Value5 = value5;
            this.Value6 = value6;
            this.Value7 = value7;
            this.Value8 = value8;
        }

        public string Label { get; set; }
        public double Value1 { get; set; }
        public double Value2 { get; set; }
        public double Value3 { get; set; }
        public double Value4 { get; set; }
        public double Value5 { get; set; }
        public double Value6 { get; set; }
        public double Value7 { get; set; }
        public double Value8 { get; set; }
    }
}