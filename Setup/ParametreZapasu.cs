using System;

namespace LGR_Futbal.Setup
{
    [Serializable]
    public class ParametreZapasu
    {

        public string Nazov { get; set; }
       
        public int DlzkaPolcasu { get; set; }
        
        public bool Prerusenie { get; set; }

        public ParametreZapasu()
        {
            Nazov = "unknown";
            DlzkaPolcasu = 45;
            Prerusenie = false;
        }

        public override string ToString()
        {
            if (Prerusenie)
                return Nazov + " - 2x" + DlzkaPolcasu + " - P";
            else
                return Nazov + " - 2x" + DlzkaPolcasu + " - x";
        }
    }
}
