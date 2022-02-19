using System;
using System.Text;

namespace LGR_Futbal.Triedy
{
    [Serializable]
    public class Hrac
    {
        private string cisloHraca;
        private string meno;
        private string priezvisko;
        private bool hraAktualnyZapas;
        private bool nahradnik;
        private bool funkcionar;
        private string fotografia;
        private string post;
        private DateTime datumNarodenia;
        private bool zltaKarta;
        private bool cervenaKarta;
        private string poznamka;

        public string CisloHraca { get => cisloHraca; set => cisloHraca = value; }

        public string Meno { get => meno; set => meno = value; }

        public string Priezvisko { get => priezvisko; set => priezvisko = value; }

        public bool HraAktualnyZapas { get => hraAktualnyZapas; set => hraAktualnyZapas = value; }

        public string Fotografia { get => fotografia; set => fotografia = value; }

        public string Post { get => post; set => post = value; }

        public DateTime DatumNarodenia { get => datumNarodenia; set => datumNarodenia = value; }

        public bool ZltaKarta { get => zltaKarta; set => zltaKarta = value; }

        public bool CervenaKarta { get => cervenaKarta; set => cervenaKarta = value; }

        public string Poznamka { get => poznamka; set => poznamka = value; }
        
        public bool Nahradnik { get => nahradnik; set => nahradnik = value; }
         
        public bool Funkcionar { get => funkcionar; set => funkcionar = value; }

        public Hrac()
        {
            cisloHraca = string.Empty;
            meno = string.Empty;
            priezvisko = string.Empty;
            hraAktualnyZapas = true;
            Nahradnik = false;
            Funkcionar = false;
            Fotografia = string.Empty;
            Post = string.Empty;
            DatumNarodenia = DateTime.Now;
            ZltaKarta = false;
            CervenaKarta = false;
            Poznamka = string.Empty;
        }

        public Hrac(string retazec)
        {
            string[] pole = retazec.Split(';');
            CisloHraca = pole[0];
            Meno = pole[1];
            Priezvisko = pole[2];
            HraAktualnyZapas = Convert.ToBoolean(pole[3]);
            Fotografia = pole[4];
            Post = pole[5];
            DatumNarodenia = Convert.ToDateTime(pole[6]);
            ZltaKarta = Convert.ToBoolean(pole[7]);
            CervenaKarta = Convert.ToBoolean(pole[8]);
            Poznamka = pole[9];
            Nahradnik = Convert.ToBoolean(pole[10]);
            Funkcionar = Convert.ToBoolean(pole[11]);
        }

        public int getVek()
        {
            var today = DateTime.Today;
            int age = today.Year - DatumNarodenia.Year;
            if (DatumNarodenia.Date > today.AddYears(-age))
                age--;
            return age;
        }

        public string toCSVString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(CisloHraca + ";");
            sb.Append(Meno + ";");
            sb.Append(Priezvisko + ";");
            sb.Append(HraAktualnyZapas + ";");
            sb.Append(Fotografia + ";");
            sb.Append(Post + ";");
            sb.Append(DatumNarodenia.ToShortDateString() + ";");
            sb.Append(ZltaKarta + ";");
            sb.Append(CervenaKarta + ";");
            sb.Append(Poznamka + ";");
            sb.Append(Nahradnik + ";");
            sb.Append(Funkcionar.ToString());
            return sb.ToString();
        }

        public void resetKariet()
        {
            ZltaKarta = false;
            CervenaKarta = false;
        }
    }
}
