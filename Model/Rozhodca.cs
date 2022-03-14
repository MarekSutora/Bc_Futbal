using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LGR_Futbal.Model
{
    public class Rozhodca : Osoba
    {
        public int IdRozhodca { get; set; }
        public DateTime DatumUkoncenia { get; set; }

        public Rozhodca()
        {
            Meno = string.Empty;
            Priezvisko = string.Empty;
        }
    }
}
