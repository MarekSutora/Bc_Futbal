using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LGR_Futbal.Model
{
    public class Kop : Udalost
    {
        public int IdKopu { get; set; }
        public int IdUdalost { get; set; }
        public Hrac Hrac { get; set; }
        public int IdTypKopu { get; set; }
    }
}
