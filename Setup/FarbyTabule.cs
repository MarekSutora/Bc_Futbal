using System;
using System.Drawing;

namespace BC_Futbal.Setup
{
    [Serializable]
    public class FarbyTabule
    {
        public int CasFarba_r { get; set; }
        public int CasFarba_g { get; set; }
        public int CasFarba_b { get; set; }
        public int PolcasFarba_r { get; set; }
        public int PolcasFarba_g { get; set; }
        public int PolcasFarba_b { get; set; }
        public int NadpisDomFarba_r { get; set; }
        public int NadpisDomFarba_g { get; set; }
        public int NadpisDomFarba_b { get; set; }
        public int NadpisHosFarba_r { get; set; }
        public int NadpisHosFarba_g { get; set; }
        public int NadpisHosFarba_b { get; set; }
        public int SkoreFarba_r { get; set; }
        public int SkoreFarba_g { get; set; }
        public int SkoreFarba_b { get; set; }

        public FarbyTabule()
        {
            SetCasFarba(Color.White);
            SetPolcasFarba(Color.White);
            SetNadpisDomFarba(Color.White);
            SetNadpisHosFarba(Color.White);
            SetSkoreFarba(Color.White);
        }

        public void SetCasFarba(Color f)
        {
            CasFarba_r = f.R;
            CasFarba_g = f.G;
            CasFarba_b = f.B;
        }

        public void SetPolcasFarba(Color f)
        {
            PolcasFarba_r = f.R;
            PolcasFarba_g = f.G;
            PolcasFarba_b = f.B;
        }

        public void SetNadpisDomFarba(Color f)
        {
            NadpisDomFarba_r = f.R;
            NadpisDomFarba_g = f.G;
            NadpisDomFarba_b = f.B;
        }

        public void SetNadpisHosFarba(Color f)
        {
            NadpisHosFarba_r = f.R;
            NadpisHosFarba_g = f.G;
            NadpisHosFarba_b = f.B;
        }

        public void SetSkoreFarba(Color f)
        {
            SkoreFarba_r = f.R;
            SkoreFarba_g = f.G;
            SkoreFarba_b = f.B;
        }

        public Color GetCasFarba()
        {
            return Color.FromArgb(CasFarba_r, CasFarba_g, CasFarba_b);
        }

        public Color GetPolcasFarba()
        {
            return Color.FromArgb(PolcasFarba_r, PolcasFarba_g, PolcasFarba_b);
        }


        public Color GetNadpisDomFarba()
        {
            return Color.FromArgb(NadpisDomFarba_r, NadpisDomFarba_g, NadpisDomFarba_b);
        }

        public Color GetNadpisHosFarba()
        {
            return Color.FromArgb(NadpisHosFarba_r, NadpisHosFarba_g, NadpisHosFarba_b);
        }

        public Color GetSkoreFarba()
        {
            return Color.FromArgb(SkoreFarba_r, SkoreFarba_g, SkoreFarba_b);
        }
    }
}
