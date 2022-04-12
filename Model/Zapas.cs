using System;
using System.Collections.Generic;

namespace BC_Futbal.Model
{
    public class Zapas
    {
        public int IdZapasu { get; set; }
        public FutbalovyTim Domaci { get; set; }
        public FutbalovyTim Hostia { get; set; }
        public DateTime DatumZapasu { get; set; }
        public int DomaciSkore { get; set; }
        public int HostiaSkore { get; set; }
        public int DlzkaPolcasu { get; set; }
        public int NadstavenyCas1 { get; set; }
        public int NadstavenyCas2 { get; set; }
        public List<Udalost> Udalosti { get; set; }
        public string NazovDomaci { get; set; }
        public string NazovHostia { get; set; }
        public List<Rozhodca> Rozhodcovia { get; set; }
        public Zapas()
        {
            Udalosti = new List<Udalost>();
            Rozhodcovia = new List<Rozhodca>();
        }

    }
}
