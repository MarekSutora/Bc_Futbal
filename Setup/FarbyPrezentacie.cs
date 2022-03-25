using System;
using System.Drawing;

namespace LGR_Futbal.Setup
{
    [Serializable]
    public class FarbyPrezentacie
    {
        public int Zaklad_r { get; set; }
        public int Zaklad_g { get; set; }
        public int Zaklad_b { get; set; }
        public int Udaje_r { get; set; }
        public int Udaje_g { get; set; }
        public int Udaje_b { get; set; }
        public int Cislo_r { get; set; }
        public int Cislo_g { get; set; }
        public int Cislo_b { get; set; }
        public int Meno_r { get; set; }
        public int Meno_g { get; set; }
        public int Meno_b { get; set; }
        public int Nadpis_r { get; set; }
        public int Nadpis_g { get; set; }
        public int Nadpis_b { get; set; }

        public FarbyPrezentacie()
        {
            setNadpis(Color.White);
            setZaklad(Color.White);
            SetUdaje(Color.White);
            SetCislo(Color.White);
            SetMeno(Color.White);
        }

        public void setZaklad(Color f)
        {
            Zaklad_r = f.R;
            Zaklad_g = f.G;
            Zaklad_b = f.B;
        }

        public Color NadpisFarba()
        {
            return Color.FromArgb(Nadpis_r, Nadpis_g, Nadpis_b);
        }

        public void setNadpis(Color f)
        {
            Nadpis_r = f.R;
            Nadpis_g = f.G;
            Nadpis_b = f.B;
        }

        public Color ZakladFarba()
        {
            return Color.FromArgb(Zaklad_r, Zaklad_g, Zaklad_b);
        }

        public void SetUdaje(Color f)
        {
            Udaje_r = f.R;
            Udaje_g = f.G;
            Udaje_b = f.B;
        }

        public Color UdajeFarba()
        {
            return Color.FromArgb(Udaje_r, Udaje_g, Udaje_b);
        }

        public void SetCislo(Color f)
        {
            Cislo_r = f.R;
            Cislo_g = f.G;
            Cislo_b = f.B;
        }

        public Color CisloFarba()
        {
            return Color.FromArgb(Cislo_r, Cislo_g, Cislo_b);
        }

        public void SetMeno(Color f)
        {
            Meno_r = f.R;
            Meno_g = f.G;
            Meno_b = f.B;
        }

        public Color MenoFarba()
        {
            return Color.FromArgb(Meno_r, Meno_g, Meno_b);
        }
    }
}
