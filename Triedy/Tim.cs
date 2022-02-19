using System;
using System.Collections.Generic;

namespace LGR_Futbal.Triedy
{
    [Serializable]
    public class Tim
    {
        private string nazov;
        private string logo;
        private List<Hrac> zoznamHracov;

        public string Nazov { get => nazov; set => nazov = value; }

        public string Logo { get => logo; set => logo = value; }

        public List<Hrac> ZoznamHracov { get => zoznamHracov; set => zoznamHracov = value; }

        public Tim()
        {
            zoznamHracov = new List<Hrac>();
        }

        public Hrac NajstHraca(string hladaneCisloHraca)
        {
            foreach(Hrac h in zoznamHracov)
            {
                if (h.CisloHraca.Equals(hladaneCisloHraca))
                    return h;
            }
            return null;
        }

        public void PostLoad()
        {
            int pocet = zoznamHracov.Count;
            if (pocet > 0)
            {
                string[] pole = new string[pocet];
                for (int i = 0; i < pocet; i++)
                {
                    pole[i] = zoznamHracov[i].Priezvisko + " " + zoznamHracov[i].Meno;
                }

                Array.Sort(pole);

                string s;
                Hrac h;
                List<Hrac> usporiadanyZoznam = new List<Hrac>();

                for (int i = 0; i < pocet; i++)
                {
                    h = null;
                    foreach (Hrac hrac in zoznamHracov)
                    {
                        s = hrac.Priezvisko + " " + hrac.Meno;
                        if (s.Equals(pole[i]))
                            h = hrac;
                    }
                    zoznamHracov.Remove(h);
                    usporiadanyZoznam.Add(h);
                }
                zoznamHracov = usporiadanyZoznam;
            }
        }

        public void resetKariet()
        {
            foreach (Hrac h in zoznamHracov)
            {
                h.resetKariet();
            }
        }
    }
}
