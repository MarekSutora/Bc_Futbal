using System;

namespace LGR_Futbal.Triedy
{
    [Serializable]
    public class ParametreZapasu
    {
        private string nazov;
        private int minuty;
        private bool prerusenie;

        public string Nazov { get => nazov; set => nazov = value; }
        
        public int Minuty { get => minuty; set => minuty = value; }
        
        public bool Prerusenie { get => prerusenie; set => prerusenie = value; }

        public ParametreZapasu()
        {
            nazov = "unknown";
            minuty = 45;
            prerusenie = false;
        }

        public ParametreZapasu(string n, int m, bool p)
        {
            nazov = n;
            minuty = m;
            prerusenie = p;
        }

        public String toString()
        {
            if (prerusenie)
                return nazov + " - 2x" + minuty + " - P";
            else
                return nazov + " - 2x" + minuty + " - x";
        }
    }
}
