using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoradcaWyjazdowWypoczynkowych.Models
{
    public class OfertaGotowa
    {
        public int OfertaGotowaID { get; set; }
        public string Nazwa { get; set; }
        public string Opis { get; set; }
        public DateTime Data { get; set; }

        public int Komfort { get; set; }
        public int Zwiedzanie { get; set; }
        public int Aktywnosc { get; set; }
        public int Imprezowosc { get; set; }
        public int BliskoNatury { get; set; }

        //w domyśle w dniach?
        public int CzasTrwania { get; set; }
        public double Koszt { get; set; }
        // co znaczy to pole? może string?
        public int Kod { get; set; }
        public string Transport { get; set; }
        public int LiczbaOsob { get; set; }


        // bez wprowadzenia celowej denormalizacji
        //DostepnyWMiesiacach jest ciężkie do zobrazowania dla jednej kolumny
        //opuściłbym ten atrybut zupełnie
        // public int DostepnyWMiesiacach { get; set; }

    }
}