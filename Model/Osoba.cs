using System;

namespace LGR_Futbal.Model
{
    public class Osoba
    {
        public int IdOsoba { get; set; }
        public string Meno { get; set; }
        public string Priezvisko { get; set; }
        public DateTime DatumNarodenia { get; set; }
        public char Pohlavie { get; set; }

    }
}
