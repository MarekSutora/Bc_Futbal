using System;
using System.Collections.Generic;

namespace LGR_Futbal.Triedy
{
    [Serializable]
    public class Databaza
    {
        private List<Tim> zoznamTimov;

        public List<Tim> ZoznamTimov { get => zoznamTimov; set => zoznamTimov = value; }

        public Databaza()
        {
            zoznamTimov = new List<Tim>();
        }

        public Tim NajstTim(string hladanyNazov)
        {
            foreach(Tim t in zoznamTimov)
            {
                if (t.Nazov.Equals(hladanyNazov))
                    return t;
            }
            return null;
        }

        public void PostLoad()
        {
            int pocet = zoznamTimov.Count;
            if (pocet > 0)
            {
                string[] pole = new string[pocet];
                for (int i = 0; i < pocet; i++)
                {
                    pole[i] = zoznamTimov[i].Nazov;
                }

                Array.Sort(pole);

                Tim t;
                List<Tim> usporiadanyZoznam = new List<Tim>();
                for (int i = 0; i < pocet; i++)
                {
                    t = null;
                    foreach (Tim tim in zoznamTimov)
                    {
                        if (tim.Nazov.Equals(pole[i]))
                            t = tim;
                    }
                    zoznamTimov.Remove(t);
                    usporiadanyZoznam.Add(t);
                }

                zoznamTimov = usporiadanyZoznam;
                foreach (Tim tim in zoznamTimov)
                {
                    tim.PostLoad();
                }
            }
        }

        public void resetKariet()
        {
            foreach (Tim t in zoznamTimov)
            {
                t.resetKariet();
            }
        }
    }
}
