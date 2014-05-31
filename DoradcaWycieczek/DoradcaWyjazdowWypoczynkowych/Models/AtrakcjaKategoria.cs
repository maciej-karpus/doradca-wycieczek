using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoradcaWyjazdowWypoczynkowych.Models
{
    public class AtrakcjaKategoria
    {
        public int AtrakcjaKategoriaID { get; set; }

        public virtual Kategoria Kategoria { get; set; }
        public virtual Atrakcja Atrakcja { get; set; }
    }
}