using System;
using System.Drawing;

namespace LGR_Futbal.Setup
{
    [Serializable]
    public class FarbyPrezentacie
    {
        public int ZakladFarba_r { get; set; }
        public int ZakladFarba_g { get; set; }
        public int ZakladFarba_b { get; set; }
        public int UdajeFarba_r { get; set; }
        public int UdajeFarba_g { get; set; }
        public int UdajeFarba_b { get; set; }
        public int CisloFarba_r { get; set; }
        public int CislFarbao_g { get; set; }
        public int CisloFarba_b { get; set; }
        public int MenoFarba_r { get; set; }
        public int MenoFarba_g { get; set; }
        public int MenoFarba_b { get; set; }
        public int NadpisFarba_r { get; set; }
        public int NadpisFarba_g { get; set; }
        public int NadpisFarba_b { get; set; }

        public FarbyPrezentacie()
        {
            SetNadpisFarba(Color.White);
            SetZakladFarba(Color.White);
            SetUdajeFarba(Color.White);
            SetCisloFarba(Color.White);
            SetMenoFarba(Color.White);
        }

        public void SetZakladFarba(Color f)
        {
            ZakladFarba_r = f.R;
            ZakladFarba_g = f.G;
            ZakladFarba_b = f.B;
        }

        public void SetNadpisFarba(Color f)
        {
            NadpisFarba_r = f.R;
            NadpisFarba_g = f.G;
            NadpisFarba_b = f.B;
        }

        public void SetUdajeFarba(Color f)
        {
            UdajeFarba_r = f.R;
            UdajeFarba_g = f.G;
            UdajeFarba_b = f.B;
        }

        public void SetCisloFarba(Color f)
        {
            CisloFarba_r = f.R;
            CislFarbao_g = f.G;
            CisloFarba_b = f.B;
        }
        public void SetMenoFarba(Color f)
        {
            MenoFarba_r = f.R;
            MenoFarba_g = f.G;
            MenoFarba_b = f.B;
        }
        public Color GetZakladFarba()
        {
            return Color.FromArgb(ZakladFarba_r, ZakladFarba_g, ZakladFarba_b);
        }

        public Color GetNadpisFarba()
        {
            return Color.FromArgb(NadpisFarba_r, NadpisFarba_g, NadpisFarba_b);
        }
        
        public Color GetUdajeFarba()
        {
            return Color.FromArgb(UdajeFarba_r, UdajeFarba_g, UdajeFarba_b);
        }

        public Color GetCisloFarba()
        {
            return Color.FromArgb(CisloFarba_r, CislFarbao_g, CisloFarba_b);
        }

        public Color GetMenoFarba()
        {
            return Color.FromArgb(MenoFarba_r, MenoFarba_g, MenoFarba_b);
        }
    }
}