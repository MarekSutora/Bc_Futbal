using System;
using System.Drawing;
using System.IO;
using System.Collections.Generic;
using LGR_Futbal.Model;

namespace LGR_Futbal.Triedy
{
    public enum Kategoria
    {
        DospeliZeny,

    }

    [Serializable]
    public class FutbalovyTim
    {
        private string nazov;
        private string logo;
        private List<Hrac> zoznamHracov;
        public string NazovTimu { get => nazov; set => nazov = value; }
        public FutbalovyKlub FutbalovyKlub { get; set; }
        public string Logo { get => logo; set => logo = value; }
        public byte[] LogoBlob { get; set; }
        public int BlobSize { get; set; }
        public Image LogoImage { get; set; }
        public List<Hrac> ZoznamHracov { get => zoznamHracov; set => zoznamHracov = value; }
        public int Kategoria { get; set; }
        public int IdFutbalovyTim { get; set; }

        public FutbalovyTim()
        {
            FutbalovyKlub = null;
            LogoBlob = null;
            LogoImage = null;
            zoznamHracov = new List<Hrac>();
        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            try
            {
                using (var ms = new MemoryStream(byteArrayIn))
                {
                    return Image.FromStream(ms);
                }
            }
            catch
            {

            }
            return null;
        }

        public Hrac NajstHraca(string hladaneCisloHraca)
        {
            foreach(Hrac h in zoznamHracov)
            {
                if (h.CisloDresu.Equals(hladaneCisloHraca))
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
            //foreach (Hrac h in zoznamHracov)
            //{
            //    h.resetKariet();
            //}
        }
    }
}
