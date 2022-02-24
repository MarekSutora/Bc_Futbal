using LGR_Futbal.Triedy;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LGR_Futbal.Forms
{
    public partial class TabulaForm : Form
    {
        #region Atributy

        private Color casColor;
        private Color polcasColor;
        private int aktualnyJazyk;
        #endregion
        public RozlozenieTabule RozlozenieTabule { get; set; }
        public FontyTabule fontyTabule { get; set; }
        #region Kontruktor a metody

        public void prelozTabuluDoJazyka(int jazyk)
        {
            aktualnyJazyk = jazyk;

            domaciLabel.Text = preloz(domaciLabel.Text);
            hostiaLabel.Text = preloz(hostiaLabel.Text);
            polcasLabel.Text = preloz(polcasLabel.Text);
        }

        private string preloz(string povodnyText)
        {
            string text = povodnyText;

            if (aktualnyJazyk == 0) // SK
            {
                text = text.Replace("poločas", "polčas");
                text = text.Replace("DOMÁCÍ", "DOMÁCI");
                text = text.Replace("HOSTÉ", "HOSTIA");
            }
            else if (aktualnyJazyk == 1) // CZ
            {
                text = text.Replace("polčas", "poločas");
                text = text.Replace("DOMÁCI", "DOMÁCÍ");
                text = text.Replace("HOSTIA", "HOSTÉ");
            }

            return text;
        }

        public TabulaForm(int jazyk, int sirkaPlochy, int vyskaPlochy)
        {
            InitializeComponent();
            aktualnyJazyk = jazyk;
            RozlozenieTabule = new RozlozenieTabule();
            setDefaultColors();

            // Nastavenie velkosti zobrazovacej plochy - zvacsenie na pozadovanu velkost
            float pomer = (float)sirkaPlochy / (float)this.Width;
            Scale(new SizeF(pomer, pomer));

            // Nastavenie velkosti fontu pre jednotlive labely
            Label l;
            foreach (object item in Controls)
            {
                if (item.GetType() == typeof(Label))
                {
                    l = (Label)item;
                    l.Font = new Font(l.Font.Name, (float)Math.Floor(l.Font.Size * pomer));
                }
            }
            this.RozlozenieTabule.CasX = this.casLabel.Left;
            this.RozlozenieTabule.CasY = this.casLabel.Top;
            this.RozlozenieTabule.DomaciX = this.domaciLabel.Left;
            this.RozlozenieTabule.DomaciY = this.domaciLabel.Top;
            this.RozlozenieTabule.HostiaX = this.hostiaLabel.Left;
            this.RozlozenieTabule.HostiaY = this.hostiaLabel.Top;
            this.RozlozenieTabule.DomaciSkoreX = this.skoreDomaciLabel.Left;
            this.RozlozenieTabule.DomaciSkoreY = this.skoreDomaciLabel.Top;
            this.RozlozenieTabule.HostiaSkoreX = this.skoreHostiaLabel.Left;
            this.RozlozenieTabule.HostiaSkoreY = this.skoreHostiaLabel.Top;
            this.RozlozenieTabule.LogoDomaciX = this.logoDomaci.Left;
            this.RozlozenieTabule.LogoDomaciY = this.logoDomaci.Top;
            this.RozlozenieTabule.LogoDomaciZobrazit = true;
            this.RozlozenieTabule.LogoDomaciSirka = this.logoDomaci.Width;
            this.RozlozenieTabule.LogoHostiaX = this.logoHostia.Left;
            this.RozlozenieTabule.LogoHostiaY = this.logoHostia.Top;
            this.RozlozenieTabule.LogoHostiaZobrazit = true;
            this.RozlozenieTabule.LogoHostiaSirka = this.logoHostia.Width;
            this.RozlozenieTabule.polCasX = this.polcasLabel.Left;
            this.RozlozenieTabule.polCasY = this.polcasLabel.Top;
        }

        private void TabulaForm_Load(object sender, EventArgs e)
        {
            var primaryDisplay = Screen.AllScreens.ElementAtOrDefault(0);
            var extendedDisplay = Screen.AllScreens.FirstOrDefault(s => s != primaryDisplay) ?? primaryDisplay;

            this.Left = extendedDisplay.WorkingArea.Left;
            this.Top = extendedDisplay.WorkingArea.Top;
        }

        public void setDefaultColors()
        {
            casColor = Color.Lime;
            polcasColor = Color.Lime;
            casLabel.ForeColor = casColor;
            polcasLabel.ForeColor = polcasColor;

            domaciLabel.ForeColor = Color.Aqua;
            hostiaLabel.ForeColor = Color.Aqua;
            skoreDomaciLabel.ForeColor = Color.Red;
            skoreHostiaLabel.ForeColor = Color.Red;
        }

        public void setColors(FarebnaSchema fs)
        {
            casColor = fs.CasFarba();
            casLabel.ForeColor = casColor;
            polcasColor = fs.PolcasFarba();
            polcasLabel.ForeColor = polcasColor;

            domaciLabel.ForeColor = fs.NadpisDomFarba();
            hostiaLabel.ForeColor = fs.NadpisHosFarba();
            skoreDomaciLabel.ForeColor = fs.SkoreFarba();
            skoreHostiaLabel.ForeColor = fs.SkoreFarba();
        }

        public void ZobrazLogoDomaci(Image obrazok)
        {
            logoDomaci.Image = obrazok;
        }

        public void ZobrazLogoHostia(Image obrazok)
        {
            logoHostia.Image = obrazok;
        }

        public void ZobrazNazvy(string domaci, string hostia)
        {
            domaciLabel.Text = domaci;
            hostiaLabel.Text = hostia;
        }

        public void SetSkoreDomaci(int hodnota)
        {
            skoreDomaciLabel.Text = hodnota.ToString();
        }

        public void SetSkoreHostia(int hodnota)
        {
            skoreHostiaLabel.Text = hodnota.ToString();
        }

        public void SetPolcas(int hodnota, int nadstaveneMinuty)
        {
            switch (hodnota)
            {
                case 1:
                    polcasLabel.Text = preloz("1. polčas");
                    polcasLabel.ForeColor = polcasColor;
                    break;
                case 2:
                    polcasLabel.Text = preloz("2. polčas");
                    polcasLabel.ForeColor = polcasColor;
                    break;
                case 3:
                    polcasLabel.Text = preloz("2. polčas");
                    polcasLabel.ForeColor = polcasColor;
                    break;
                case 4:
                    polcasLabel.Text = preloz("2. polčas");
                    polcasLabel.ForeColor = polcasColor;
                    break;
                default:
                    polcasLabel.Text = string.Empty;
                    polcasLabel.ForeColor = Color.Black;
                    break;
            }
        }

        public void SetCas(string text, bool riadnyHraciCas)
        {
            casLabel.Text = text;
            casLabel.ForeColor = casColor;
        }

        public void Reset()
        {
            SetSkoreDomaci(0);
            SetSkoreHostia(0);
            SetPolcas(0, 0);
            SetCas("00:00", true);
        }

        public void NastavFonty(FontyTabule fonty)
        {
            skoreDomaciLabel.Font = fonty.CreateSkoreFont();
            skoreHostiaLabel.Font = fonty.CreateSkoreFont();

            domaciLabel.Font = fonty.CreateNazvyFont();
            hostiaLabel.Font = fonty.CreateNazvyFont();

            casLabel.Font = fonty.CreateCasFont();
            polcasLabel.Font = fonty.CreatePolcasFont();
            
        }

        public void setLayout(RozlozenieTabule rozlozenie)
        {
            double pom = this.logoDomaci.Width / this.logoDomaci.Height;
            this.RozlozenieTabule = rozlozenie;
            if (!rozlozenie.LogoDomaciZobrazit)
            {
                this.logoDomaci.Visible = false;
            }
            else
            {
                this.logoDomaci.Left = rozlozenie.LogoDomaciX;
                this.logoDomaci.Top = rozlozenie.LogoDomaciY;
                this.logoDomaci.Width = rozlozenie.LogoDomaciSirka;
                this.logoDomaci.Height = (int)(pom * this.logoDomaci.Width);
                this.logoDomaci.Visible = true;
            }
                
            if (!rozlozenie.LogoHostiaZobrazit)
            {
                this.logoHostia.Visible = false;
            }
            else
            {
                this.logoHostia.Left = rozlozenie.LogoHostiaX;
                this.logoHostia.Top = rozlozenie.LogoHostiaY;
                this.logoHostia.Width = rozlozenie.LogoHostiaSirka;
                this.logoHostia.Height = (int)(pom * this.logoHostia.Width);
                this.logoHostia.Visible = true;
            }

            this.skoreDomaciLabel.Left = rozlozenie.DomaciSkoreX;
            this.skoreDomaciLabel.Top = rozlozenie.DomaciSkoreY;

            this.skoreHostiaLabel.Left = rozlozenie.HostiaSkoreX;
            this.skoreHostiaLabel.Top = rozlozenie.HostiaSkoreY;

            this.hostiaLabel.Left = rozlozenie.HostiaX;
            this.hostiaLabel.Top = rozlozenie.HostiaY;

            this.domaciLabel.Left = rozlozenie.DomaciX;
            this.domaciLabel.Top = rozlozenie.DomaciY;

            this.casLabel.Left = rozlozenie.CasX;
            this.casLabel.Top = rozlozenie.CasY;

            this.polcasLabel.Left = rozlozenie.polCasX;
            this.polcasLabel.Top = rozlozenie.polCasY;

        }

        #endregion
    }
}
