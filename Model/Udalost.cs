using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Udalost()
        {

        }

        private bool FilterPolcas(bool polcas1, bool polcas2)
        {
            if (polcas1 && polcas2)
                return true;

            if (!polcas1 && !polcas2)
                return false;

            if ((polcas1 && Polcas == 1) && !polcas2)
                return true;

            if (!polcas1 && (polcas2 && Polcas == 2))
                return true;

            return false;
        }

        private bool FilterTimy(bool tim1, bool tim2, string nazovTim1, string nazovTim2)
        {
            if(tim1 && nazovTim1 == NazovTimu)
                return true;

            if (tim2 && nazovTim2 == NazovTimu)
                return true;

            return false;

        }

        public bool SplnaFilter(bool polcas1, bool polcas2, bool tim1, bool tim2, string nazovTim1, string nazovTim2)
        {
            bool splnaPolcas = false;

            splnaPolcas = FilterPolcas(polcas1, polcas2);

            bool splnaTim = FilterTimy(tim1, tim2, nazovTim1, nazovTim2);

            return splnaPolcas && splnaTim;
        }
    }
}
