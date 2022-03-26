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
        public int CasX { get; set; }
        public int CasY { get; set; }
        public int DomaciX { get; set; }
        public int DomaciY { get; set; }
        public int HostiaX { get; set; }
        public int HostiaY { get; set; }
        public int DomaciSkoreX { get; set; }
        public int DomaciSkoreY { get; set; }
        public int HostiaSkoreX { get; set; }
        public int HostiaSkoreY { get; set; }
        public int LogoDomaciX { get; set; }
        public int LogoDomaciY { get; set; }
        public int LogoDomaciSirka { get; set; }
        public bool LogoDomaciZobrazit { get; set; }
        public int LogoHostiaX { get; set; }
        public int LogoHostiaY { get; set; }
        public int LogoHostiaSirka { get; set; }
        public bool LogoHostiaZobrazit { get; set; }
        public int polCasX { get; set; }
        public int polCasY { get; set; }

        public RozlozenieTabule()
        {

        }

        public void NativneRozlozenie(int sirka, int vyska)
        {
            CasX = (int)(sirka / (1920 / 540.0));
            CasY = (int)(vyska / (1080 / 20.0));

            DomaciX = (int)(sirka / (1920 / 20.0));
            DomaciY = (int)(vyska / (1080 / 544.0));

            HostiaX = (int)(sirka / (1920 / 1098.0));
            HostiaY = (int)(vyska / (1080 / 544.0));

            DomaciSkoreX = (int)(sirka / (1920 / 38.0));
            DomaciSkoreY = (int)(vyska / (1080 / 674.0));

            HostiaSkoreX = (int)(sirka / (1920 / 1118.0));
            HostiaSkoreY = (int)(vyska / (1080 / 674.0));

            LogoDomaciX = (int)(sirka / (1920 / 20.0));
            LogoDomaciY = (int)(vyska / (1080 / 20.0));
            LogoDomaciSirka = (int)(sirka / (1920 / 510.0));

            LogoHostiaX = (int)(sirka / (1920 / 1390.0));
            LogoHostiaY = (int)(vyska / (1080 / 20.0));
            LogoHostiaSirka = (int)(sirka / (1920 / 510.0));

            polCasX = (int)(sirka / (1920 / 550.0));
            polCasY = (int)(vyska / (1080 / 878.0));
        }
    }
}
