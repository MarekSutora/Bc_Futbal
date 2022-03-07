using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LGR_Futbal.Model
{
    public class Osoba
    {
        public int IdOsoba { get; set; }
        public string Meno { get; set; }
        public string Priezvisko { get; set; }
        public DateTime DatumNarodenia { get; set; }
        public int Pohlavie { get; set; }
    }
}
