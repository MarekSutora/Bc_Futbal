using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LGR_Futbal.Model
{
    public class Offside : Udalost
    {
        public int IdOut { get; set; }
        public int IdUdalost { get; set; }
        public Hrac Hrac { get; set; }

        public Offside()
        {
            Hrac = new Hrac();
        }
    }
}
