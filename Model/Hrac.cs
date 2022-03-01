using System;
using System.Text;

namespace LGR_Futbal.Model
{
    public class Hrac : Osoba
    {
        public int IdHrac { get; set; }
        public DateTime DatumNastupu { get; set; }
        public string RodneCislo { get; set; }
        public int IdKlub { get; set; }
        public string CisloDresu { get; set; }
        public DateTime DatumUkoncenia { get; set; }
        public int IdPozicia { get; set; }
        public string Fotka { get; set; }
        public bool ZltaKarta { get; set; }
        public bool CervenaKarta { get; set; }
        public String Poznamka { get; set; }
        public bool Nahradnik { get; set; }
        public bool Funkcionar { get; set; }
        public bool HraAktualnyZapas { get; set; }
        public string Pozicia { get; set; }
        public DateTime DatumNarodenia { get; set; }

        public Hrac(string retazec)
        {
            string[] pole = retazec.Split(';');
            CisloDresu = pole[0];
            Meno = pole[1];
            Priezvisko = pole[2];
            HraAktualnyZapas = Convert.ToBoolean(pole[3]);
            Fotka = pole[4];
            Pozicia = pole[5];
            DatumNarodenia = Convert.ToDateTime(pole[6]);
            ZltaKarta = Convert.ToBoolean(pole[7]);
            CervenaKarta = Convert.ToBoolean(pole[8]);
            Poznamka = pole[9];
            Nahradnik = Convert.ToBoolean(pole[10]);
            Funkcionar = Convert.ToBoolean(pole[11]);
        }

        public string toCSVString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(CisloDresu + ";");
            sb.Append(Meno + ";");
            sb.Append(Priezvisko + ";");
            sb.Append(HraAktualnyZapas + ";");
            sb.Append(Fotka + ";");
            sb.Append(Pozicia + ";");
            sb.Append(DatumNarodenia.ToShortDateString() + ";");
            sb.Append(ZltaKarta + ";");
            sb.Append(CervenaKarta + ";");
            sb.Append(Poznamka + ";");
            sb.Append(Nahradnik + ";");
            sb.Append(Funkcionar.ToString());
            return sb.ToString();
        }

        public Hrac()
        {
            CisloDresu = string.Empty;
            Meno = string.Empty;
            Priezvisko = string.Empty;
            HraAktualnyZapas = true;
            Nahradnik = false;
            Funkcionar = false;
            Fotka = string.Empty;
            Pozicia = string.Empty;
            DatumNarodenia = DateTime.Now;
            ZltaKarta = false;
            CervenaKarta = false;
            Poznamka = string.Empty;
        }

        public int getVek()
        {
            var today = DateTime.Today;
            int age = today.Year - DatumNarodenia.Year;
            if (DatumNarodenia.Date > today.AddYears(-age))
                age--;
            return age;
        }
    }

    

}
