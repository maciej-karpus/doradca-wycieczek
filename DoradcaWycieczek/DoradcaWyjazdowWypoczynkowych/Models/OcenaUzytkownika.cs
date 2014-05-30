using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoradcaWyjazdowWypoczynkowych.Models
{
    public class OcenaUzytkownika
    {
        public int OcenaUzytkownikaID { get; set; }

        public int GlownaOcena { get; set; }

        public int Komfort { get; set; }
        public int Zwiedzanie { get; set; }
        public int Aktywnosc { get; set; }
        public int Imprezowosc { get; set; }
        public int BliskoNatury { get; set; }

        public virtual OfertaGotowa OfertaGotowa { get; set; }
    }
}