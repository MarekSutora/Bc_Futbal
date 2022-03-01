using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LGR_Futbal.Model
{
    public class Striedanie
    {
        public int IdStriedania { get; set; }
        public Hrac Striedajuci { get; set; }
        public Hrac Striedany { get; set; }
    }
}
