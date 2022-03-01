using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LGR_Futbal.Model
{
    public class Karta
    {
        public int IdKarta { get; set; }
        public Hrac Hrac { get; set; }
        public Rozhodca Rozhodca { get; set; }
        public int Typ { get; set; }
        public Udalost Udalost { get; set; }

    }
}
