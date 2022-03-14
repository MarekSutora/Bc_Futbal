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
        public Hrac Hrac { get; set; }
        public Rozhodca Rozhodca { get; set; }
        public int TypKarty { get; set; }

        public Karta()
        {
            Hrac = new Hrac();
            Rozhodca = new Rozhodca();
        }
    }
}
