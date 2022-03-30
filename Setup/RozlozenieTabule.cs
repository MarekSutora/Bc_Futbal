using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LGR_Futbal.Setup
{
    [Serializable]
    public class RozlozenieTabule
    {
        public int Cas_X { get; set; }
        public int Cas_Y { get; set; }
        public int Domaci_X { get; set; }
        public int Domaci_Y { get; set; }
        public int Hostia_X { get; set; }
        public int Hostia_Y { get; set; }
        public int DomaciSkore_X { get; set; }
        public int DomaciSkore_Y { get; set; }
        public int HostiaSkore_X { get; set; }
        public int HostiaSkore_Y { get; set; }
        public int LogoDomaci_X { get; set; }
        public int LogoDomaci_Y { get; set; }     
        public int LogoHostia_X { get; set; }
        public int LogoHostia_Y { get; set; }
        public int Polcas_X { get; set; }
        public int Polcas_Y { get; set; }
        public int LogoDomaciSirka { get; set; }
        public int LogoHostiaSirka { get; set; }
        public bool LogoDomaciZobrazit { get; set; }
        public bool LogoHostiaZobrazit { get; set; } 
      
        public RozlozenieTabule()
        {

        }

        public void NativneRozlozenie(int sirka, int vyska)
        {
            Cas_X = (int)(sirka / (1920 / 540.0));
            Cas_Y = (int)(vyska / (1080 / 20.0));

            Domaci_X = (int)(sirka / (1920 / 20.0));
            Domaci_Y = (int)(vyska / (1080 / 544.0));

            Hostia_X = (int)(sirka / (1920 / 1098.0));
            Hostia_Y = (int)(vyska / (1080 / 544.0));

            DomaciSkore_X = (int)(sirka / (1920 / 38.0));
            DomaciSkore_Y = (int)(vyska / (1080 / 674.0));

            HostiaSkore_X = (int)(sirka / (1920 / 1388.0));
            HostiaSkore_Y = (int)(vyska / (1080 / 674.0));

            LogoDomaci_X = (int)(sirka / (1920 / 20.0));
            LogoDomaci_Y = (int)(vyska / (1080 / 20.0));
            LogoDomaciSirka = (int)(sirka / (1920 / 510.0));

            LogoHostia_X = (int)(sirka / (1920 / 1390.0));
            LogoHostia_Y = (int)(vyska / (1080 / 20.0));
            LogoHostiaSirka = (int)(sirka / (1920 / 510.0));

            Polcas_X = (int)(sirka / (1920 / 550.0));
            Polcas_Y = (int)(vyska / (1080 / 878.0));
        }
    }
}
