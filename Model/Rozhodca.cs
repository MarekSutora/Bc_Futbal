using System;

namespace BC_Futbal.Model
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
