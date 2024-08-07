﻿using System;
using System.Drawing;

namespace BC_Futbal.Model
{
    public class Hrac : Osoba
    {
        public int IdHrac { get; set; }
        public int IdFutbalovyTim { get; set; }
        public string CisloDresu { get; set; }
        public byte[] FotkaBlob { get; set; }
        public Image FotkaImage { get; set; }
        public string Fotka { get; set; }
        public bool ZltaKarta { get; set; }
        public bool CervenaKarta { get; set; }
        public String Poznamka { get; set; }
        public bool Nahradnik { get; set; }
        public bool HraAktualnyZapas { get; set; }
        public string Pozicia { get; set; }
        public char TypHraca { get; set; }
        public Hrac()
        {
            TypHraca = 'X';
            Poznamka = " ";
            Meno = string.Empty;
            Priezvisko = string.Empty;
        }

        public int GetVek()
        {
            var today = DateTime.Today;
            int age = today.Year - DatumNarodenia.Year;
            if (DatumNarodenia.Date > today.AddYears(-age))
                age--;
            return age;
        }
    }
}
