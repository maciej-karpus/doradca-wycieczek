using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoradcaWyjazdowWypoczynkowych.Models
{
    public class Atrakcja
    {
        public int AtrakcjaID { get; set; }
        public string AtrakcjaNazwa { get; set; }
        public string Lokalizacja { get; set; }
        public string ZdjecieURL { get; set; }

        public virtual ICollection<AtrakcjaKategoria> AtrakcjaKategoria { get; set; }
    }
}