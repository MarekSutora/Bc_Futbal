using System;
using System.Drawing;

namespace LGR_Futbal.Setup
{
    [Serializable]
    public class FarebnaSchema
    {
        private int casFarba_r;
        private int polcasFarba_r;
        private int predlzenieFarba_r;
        private int koniecFarba_r;
        private int nadpisDomFarba_r;
        private int nadpisHosFarba_r;
        private int skoreFarba_r;

        private int casFarba_g;
        private int polcasFarba_g;
        private int predlzenieFarba_g;
        private int koniecFarba_g;
        private int nadpisDomFarba_g;
        private int nadpisHosFarba_g;
        private int skoreFarba_g;

        private int casFarba_b;
        private int polcasFarba_b;
        private int predlzenieFarba_b;
        private int koniecFarba_b;
        private int nadpisDomFarba_b;
        private int nadpisHosFarba_b;
        private int skoreFarba_b;

        public int CasFarba_r { get => casFarba_r; set => casFarba_r = value; }
        public int PolcasFarba_r { get => polcasFarba_r; set => polcasFarba_r = value; }
        public int PredlzenieFarba_r { get => predlzenieFarba_r; set => predlzenieFarba_r = value; }
        public int KoniecFarba_r { get => koniecFarba_r; set => koniecFarba_r = value; }
        public int NadpisDomFarba_r { get => nadpisDomFarba_r; set => nadpisDomFarba_r = value; }
        public int NadpisHosFarba_r { get => nadpisHosFarba_r; set => nadpisHosFarba_r = value; }
        public int SkoreFarba_r { get => skoreFarba_r; set => skoreFarba_r = value; }
        public int CasFarba_g { get => casFarba_g; set => casFarba_g = value; }
        public int PolcasFarba_g { get => polcasFarba_g; set => polcasFarba_g = value; }
        public int PredlzenieFarba_g { get => predlzenieFarba_g; set => predlzenieFarba_g = value; }
        public int KoniecFarba_g { get => koniecFarba_g; set => koniecFarba_g = value; }
        public int NadpisDomFarba_g { get => nadpisDomFarba_g; set => nadpisDomFarba_g = value; }
        public int NadpisHosFarba_g { get => nadpisHosFarba_g; set => nadpisHosFarba_g = value; }
        public int SkoreFarba_g { get => skoreFarba_g; set => skoreFarba_g = value; }
        public int CasFarba_b { get => casFarba_b; set => casFarba_b = value; }
        public int PolcasFarba_b { get => polcasFarba_b; set => polcasFarba_b = value; }
        public int PredlzenieFarba_b { get => predlzenieFarba_b; set => predlzenieFarba_b = value; }
        public int KoniecFarba_b { get => koniecFarba_b; set => koniecFarba_b = value; }
        public int NadpisDomFarba_b { get => nadpisDomFarba_b; set => nadpisDomFarba_b = value; }
        public int NadpisHosFarba_b { get => nadpisHosFarba_b; set => nadpisHosFarba_b = value; }
        public int SkoreFarba_b { get => skoreFarba_b; set => skoreFarba_b = value; }

        public FarebnaSchema()
        {
            setCasFarba(Color.White);
            setPolcasFarba(Color.White);
            setPredlzenieFarba(Color.White);
            setKoniecFarba(Color.White);
            setNadpisDomFarba(Color.White);
            setNadpisHosFarba(Color.White);
            setSkoreFarba(Color.White);
        }

        public void setCasFarba(Color f)
        {
            CasFarba_r = f.R;
            CasFarba_g = f.G;
            CasFarba_b = f.B;
        }

        public void setPolcasFarba(Color f)
        {
            PolcasFarba_r = f.R;
            PolcasFarba_g = f.G;
            PolcasFarba_b = f.B;
        }

        public void setPredlzenieFarba(Color f)
        {
            PredlzenieFarba_r = f.R;
            PredlzenieFarba_g = f.G;
            PredlzenieFarba_b = f.B;
        }

        public void setKoniecFarba(Color f)
        {
            KoniecFarba_r = f.R;
            KoniecFarba_g = f.G;
            KoniecFarba_b = f.B;
        }

        public void setNadpisDomFarba(Color f)
        {
            NadpisDomFarba_r = f.R;
            NadpisDomFarba_g = f.G;
            NadpisDomFarba_b = f.B;
        }

        public void setNadpisHosFarba(Color f)
        {
            NadpisHosFarba_r = f.R;
            NadpisHosFarba_g = f.G;
            NadpisHosFarba_b = f.B;
        }

        public void setSkoreFarba(Color f)
        {
            SkoreFarba_r = f.R;
            SkoreFarba_g = f.G;
            SkoreFarba_b = f.B;
        }

        public Color CasFarba()
        {
            return Color.FromArgb(CasFarba_r, CasFarba_g, CasFarba_b);
        }

        public Color PolcasFarba()
        {
            return Color.FromArgb(PolcasFarba_r, PolcasFarba_g, PolcasFarba_b);
        }

        public Color PredlzenieFarba()
        {
            return Color.FromArgb(PredlzenieFarba_r, PredlzenieFarba_g, PredlzenieFarba_b);
        }

        public Color KoniecFarba()
        {
            return Color.FromArgb(KoniecFarba_r, KoniecFarba_g, KoniecFarba_b);
        }

        public Color NadpisDomFarba()
        {
            return Color.FromArgb(NadpisDomFarba_r, NadpisDomFarba_g, NadpisDomFarba_b);
        }

        public Color NadpisHosFarba()
        {
            return Color.FromArgb(NadpisHosFarba_r, NadpisHosFarba_g, NadpisHosFarba_b);
        }
        
        public Color SkoreFarba()
        {
            return Color.FromArgb(SkoreFarba_r, SkoreFarba_g, SkoreFarba_b);
        }
    }
}
