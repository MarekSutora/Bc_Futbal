using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LGR_Futbal.Model
{

    public class FutbalovyKlub
    {
        public int IdKlub { get; set; }
        public string NazovKlubu { get; set; }
        public DateTime DatumZalozenia { get; set; }
        public int MyProperty { get; set; }

        public FutbalovyKlub()
        {
            IdKlub = 0;
        }
    }
}
