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
        public CasUdalosti CasUdalosti { get; set; }
    }
}
