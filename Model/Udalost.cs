using System;

namespace LGR_Futbal.Model
{
    public class Udalost
    {
        public int IdUdalosti { get; set; }
        public string UdalostPopis { get; set; }
        public Zapas Zapas { get; set; }
        public int IdCasUdalosti { get; set; }
        public int Minuta { get; set; }
        public int Polcas { get; set; }
        public int Predlzenie { get; set; }
        public int NadstavenaMinuta { get; set; }
        public DateTime AktualnyCas { get; set; }
        public string NazovTimu { get; set; }
        public int Typ { get; set; }
        public int IdFutbalovyTim { get; set; }

        public Udalost()
        {

        }

        private bool FilterPolcas(bool p1, bool p2)
        {
            if (p1 && p2)
                return true;

            if (!p1 && !p2)
                return false;

            if ((p1 && Polcas == 1) && !p2)
                return true;

            if (!p1 && (p2 && Polcas == 2))
                return true;

            return false;
        }

        private bool FilterTimy(bool t1, bool t2, string nazovT1, string nazovT2)
        {
            if(t1 && nazovT1 == NazovTimu)
                return true;

            if (t2 && nazovT2 == NazovTimu)
                return true;

            return false;

        }

        public bool SplnaFilter(bool p1, bool p2, bool t1, bool t2, string nazovT1, string nazovT2)
        {
            bool splnaPolcas = FilterPolcas(p1, p2);

            bool splnaTim = FilterTimy(t1, t2, nazovT1, nazovT2);

            return splnaPolcas && splnaTim;
        }
    }
}
