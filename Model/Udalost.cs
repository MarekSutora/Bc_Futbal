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
        public double Minuta { get; set; }
        public int Polcas { get; set; }
        public int Predlzenie { get; set; }

        public Udalost()
        {

        }
    }
}
