using System;

namespace LGR_Futbal.Setup
{
    [Serializable]
    public class ParametreZapasu
    {

        public string Nazov { get; set; }
       
        public int Minuty { get; set; }
        
        public bool Prerusenie { get; set; }

        public ParametreZapasu()
        {
            Nazov = "unknown";
            Minuty = 45;
            Prerusenie = false;
        }

        public ParametreZapasu(string n, int m, bool p)
        {
            Nazov = n;
            Minuty = m;
            Prerusenie = p;
        }

        public String toString()
        {
            if (Prerusenie)
                return Nazov + " - 2x" + Minuty + " - P";
            else
                return Nazov + " - 2x" + Minuty + " - x";
        }
    }
}
