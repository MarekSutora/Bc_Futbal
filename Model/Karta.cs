using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LGR_Futbal.Model
{
    public class Karta : Udalost
    {
        public int IdKarta { get; set; }
        public int IdHraca { get; set; }
        public Rozhodca Rozhodca { get; set; }
        public int Typ { get; set; }

    }
}
