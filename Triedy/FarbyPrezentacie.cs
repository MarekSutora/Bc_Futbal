using System;
using System.Drawing;

namespace LGR_Futbal.Triedy
{
    [Serializable]
    public class FarbyPrezentacieClass
    {
        private int nadpis_r;
        private int nadpis_g;
        private int nadpis_b;
        private int zaklad_r;
        private int zaklad_g;
        private int zaklad_b;
        private int udaje_r;
        private int udaje_g;
        private int udaje_b;
        private int cislo_r;
        private int cislo_g;
        private int cislo_b;
        private int meno_r;
        private int meno_g;
        private int meno_b;

        public int Zaklad_r { get => zaklad_r; set => zaklad_r = value; }
        public int Zaklad_g { get => zaklad_g; set => zaklad_g = value; }
        public int Zaklad_b { get => zaklad_b; set => zaklad_b = value; }
        public int Udaje_r { get => udaje_r; set => udaje_r = value; }
        public int Udaje_g { get => udaje_g; set => udaje_g = value; }
        public int Udaje_b { get => udaje_b; set => udaje_b = value; }
        public int Cislo_r { get => cislo_r; set => cislo_r = value; }
        public int Cislo_g { get => cislo_g; set => cislo_g = value; }
        public int Cislo_b { get => cislo_b; set => cislo_b = value; }
        public int Meno_r { get => meno_r; set => meno_r = value; }
        public int Meno_g { get => meno_g; set => meno_g = value; }
        public int Meno_b { get => meno_b; set => meno_b = value; }
        public int Nadpis_r { get => nadpis_r; set => nadpis_r = value; }
        public int Nadpis_g { get => nadpis_g; set => nadpis_g = value; }
        public int Nadpis_b { get => nadpis_b; set => nadpis_b = value; }

        public FarbyPrezentacieClass()
        {
            setNadpis(Color.White);
            setZaklad(Color.White);
            setUdaje(Color.White);
            setCislo(Color.White);
            setMeno(Color.White);
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

        public void setUdaje(Color f)
        {
            Udaje_r = f.R;
            Udaje_g = f.G;
            Udaje_b = f.B;
        }

        public Color UdajeFarba()
        {
            return Color.FromArgb(Udaje_r, Udaje_g, Udaje_b);
        }

        public void setCislo(Color f)
        {
            Cislo_r = f.R;
            Cislo_g = f.G;
            Cislo_b = f.B;
        }

        public Color CisloFarba()
        {
            return Color.FromArgb(Cislo_r, Cislo_g, Cislo_b);
        }

        public void setMeno(Color f)
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
