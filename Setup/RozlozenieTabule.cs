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
        public int Cas_Sirka { get; set; }
        public int DomaciNazov_X { get; set; }
        public int DomaciNazov_Y { get; set; }
        public int DomaciNazov_Sirka { get; set; }
        public int HostiaNazov_X { get; set; }
        public int HostiaNazov_Y { get; set; }
        public int HostiaNazov_Sirka { get; set; }
        public int DomaciSkore_X { get; set; }
        public int DomaciSkore_Y { get; set; }
        public int DomaciSkore_Sirka { get; set; }
        public int HostiaSkore_X { get; set; }
        public int HostiaSkore_Y { get; set; }
        public int HostiaSkore_Sirka { get; set; }
        public int LogoDomaci_X { get; set; }
        public int LogoDomaci_Y { get; set; }
        public int LogoDomaci_Sirka { get; set; }
        public bool LogoDomaci_Zobrazit { get; set; }
        public int LogoHostia_X { get; set; }
        public int LogoHostia_Y { get; set; }
        public int LogoHostia_Sirka { get; set; }
        public bool LogoHostia_Zobrazit { get; set; }
        public int Polcas_X { get; set; }
        public int Polcas_Y { get; set; }
        public int Polcas_Sirka { get; set; }

        public RozlozenieTabule()
        {

        }

        public void NativneRozlozenie(int sirka, int vyska)
        {
            LogoDomaci_Zobrazit = true;
            LogoHostia_Zobrazit = true;

            Cas_X = (int)(sirka / (1920 / 540.0));
            Cas_Y = (int)(vyska / (1080 / 20.0));
            Cas_Sirka = (int)(sirka / (1920 / 840.0));

            DomaciNazov_X = (int)(sirka / (1920 / 112.0));
            DomaciNazov_Y = (int)(vyska / (1080 / 562.0));
            DomaciNazov_Sirka = (int)(sirka / (1920 / 440.0));

            HostiaNazov_X = (int)(sirka / (1920 / 1370.0));
            HostiaNazov_Y = (int)(vyska / (1080 / 562.0));
            HostiaNazov_Sirka = (int)(sirka / (1920 / 440.0));

            DomaciSkore_X = (int)(sirka / (1920 / 38.0));
            DomaciSkore_Y = (int)(vyska / (1080 / 674.0));
            DomaciSkore_Sirka = (int)(sirka / (1920 / 490.0));

            HostiaSkore_X = (int)(sirka / (1920 / 1388.0));
            HostiaSkore_Y = (int)(vyska / (1080 / 674.0));
            HostiaSkore_Sirka = (int)(sirka / (1920 / 490.0));

            LogoDomaci_X = (int)(sirka / (1920 / 20.0));
            LogoDomaci_Y = (int)(vyska / (1080 / 20.0));
            LogoDomaci_Sirka = (int)(sirka / (1920 / 510.0));

            LogoHostia_X = (int)(sirka / (1920 / 1390.0));
            LogoHostia_Y = (int)(vyska / (1080 / 20.0));
            LogoHostia_Sirka = (int)(sirka / (1920 / 510.0));

            Polcas_X = (int)(sirka / (1920 / 550.0));
            Polcas_Y = (int)(vyska / (1080 / 878.0));
            Polcas_Sirka = (int)(sirka / (1920 / 878.0));
        }
    }
}
