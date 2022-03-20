using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LGR_Futbal.Model
{
    public class Karta : Udalost
    {
        public Hrac Hrac { get; set; }
        public Rozhodca Rozhodca { get; set; }
        public char TypKarty { get; set; }

        public Karta()
        {
            Hrac = new Hrac();
            Rozhodca = new Rozhodca();
        }
    }
}
