using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoradcaWyjazdowWypoczynkowych.Models
{
    public class Atrakcja
    {
        public int AtrakcjaID { get; set; }
        public string Lokalizacja { get; set; }

        public virtual Kategoria Kategoria { get; set; }
    }
}