using System;
using System.Collections.Generic;
using Oracle.ManagedDataAccess.Client;

namespace LGR_Futbal.Triedy
{
    

    [Serializable]
    public class Databaza
    {
        private List<FutbalovyTim> zoznamTimov;
        private OracleConnection conn = null;

        public List<FutbalovyTim> ZoznamTimov { get => zoznamTimov; set => zoznamTimov = value; }

        public Databaza()
        {
            zoznamTimov = new List<FutbalovyTim>();
        }

        public FutbalovyTim NajstTim(string hladanyNazov)
        {
            foreach(FutbalovyTim t in zoznamTimov)
            {
                if (t.NazovTimu.Equals(hladanyNazov))
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
                    pole[i] = zoznamTimov[i].NazovTimu;
                }

                Array.Sort(pole);

                FutbalovyTim t;
                List<FutbalovyTim> usporiadanyZoznam = new List<FutbalovyTim>();
                for (int i = 0; i < pocet; i++)
                {
                    t = null;
                    foreach (FutbalovyTim tim in zoznamTimov)
                    {
                        if (tim.NazovTimu.Equals(pole[i]))
                            t = tim;
                    }
                    zoznamTimov.Remove(t);
                    usporiadanyZoznam.Add(t);
                }

                zoznamTimov = usporiadanyZoznam;
                foreach (FutbalovyTim tim in zoznamTimov)
                {
                    tim.PostLoad();
                }
            }
        }

        public void resetKariet()
        {
            foreach (FutbalovyTim t in zoznamTimov)
            {
                t.resetKariet();
            }
        }

        public void PripojKDatabaze()
        {
            string constring = "User Id=sutora_bc;Password=bcproj84Qt;Data Source=obelix.fri.uniza.sk:1521/orcl.fri.uniza.sk"; ;
            using (conn = new OracleConnection())
            {
                conn.ConnectionString = constring;
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.ToString());
                }
            }
        }

        public void OdpojitDatabazu()
        {
            try
            {
                conn.Close();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
        }
    }
}
