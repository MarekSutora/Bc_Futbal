using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LGR_Futbal.Model
{
    public class Zapas
    {
        public int IdZapasu { get; set; }
        public FutbalovyKlub Domaci { get; set; }
        public FutbalovyKlub Hostia { get; set; }
        public DateTime DatumZapasu { get; set; }
        public int DomaciSkore { get; set; }
        public int HostiaSkore { get; set; }
        public int DlzkaPolcasu { get; set; }
        public int NadstavenyCas1 { get; set; }
        public int NadstavenyCas2 { get; set; }


    }
}
