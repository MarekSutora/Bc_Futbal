using LGR_Futbal.Setup;
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

        public TabulaForm(int jazyk, int sirkaPlochy, RozlozenieTabule rt)
        {
            
            InitializeComponent();
            aktualnyJazyk = jazyk;
            setDefaultColors();
            this.RozlozenieTabule = rt;
            // Nastavenie velkosti zobrazovacej plochy - zvacsenie na pozadovanu velkost
            float pomer = (float)sirkaPlochy / (float)this.Width;
            Scale(new SizeF(pomer, pomer));

            LayoutSetter.NastavVelkostiElementov(this, pomer);

            this.RozlozenieTabule.Cas_X = this.casLabel.Left;
            this.RozlozenieTabule.Cas_Y = this.casLabel.Top;
            this.RozlozenieTabule.Domaci_X = this.domaciLabel.Left;
            this.RozlozenieTabule.Domaci_Y = this.domaciLabel.Top;
            this.RozlozenieTabule.Hostia_X = this.hostiaLabel.Left;
            this.RozlozenieTabule.Hostia_Y = this.hostiaLabel.Top;
            this.RozlozenieTabule.DomaciSkore_X = this.skoreDomaciLabel.Left;
            this.RozlozenieTabule.DomaciSkore_Y = this.skoreDomaciLabel.Top;
            this.RozlozenieTabule.HostiaSkore_X = this.skoreHostiaLabel.Left;
            this.RozlozenieTabule.HostiaSkore_Y = this.skoreHostiaLabel.Top;
            this.RozlozenieTabule.LogoDomaci_X = this.logoDomaci.Left;
            this.RozlozenieTabule.LogoDomaci_Y = this.logoDomaci.Top;
            this.RozlozenieTabule.LogoDomaciZobrazit = true;
            this.RozlozenieTabule.LogoDomaciSirka = this.logoDomaci.Width;
            this.RozlozenieTabule.LogoHostia_X = this.logoHostia.Left;
            this.RozlozenieTabule.LogoHostia_Y = this.logoHostia.Top;
            this.RozlozenieTabule.LogoHostiaZobrazit = true;
            this.RozlozenieTabule.LogoHostiaSirka = this.logoHostia.Width;
            this.RozlozenieTabule.Polcas_X = this.polcasLabel.Left;
            this.RozlozenieTabule.Polcas_Y = this.polcasLabel.Top;
        }

        private void TabulaForm_Load(object sender, EventArgs e)
        {
            LayoutSetter.ZobrazNaDruhejObrazovke(this);
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

        public void setColors(FarbyTabule fs)
        {
            casColor = fs.GetCasFarba();
            casLabel.ForeColor = casColor;
            polcasColor = fs.GetPolcasFarba();
            polcasLabel.ForeColor = polcasColor;

            domaciLabel.ForeColor = fs.GetNadpisDomFarba();
            hostiaLabel.ForeColor = fs.GetNadpisHosFarba();
            skoreDomaciLabel.ForeColor = fs.GetSkoreFarba();
            skoreHostiaLabel.ForeColor = fs.GetSkoreFarba();
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

            //polcasLabel.Text = hodnota + " " + nadstaveneMinuty;
            //polcasLabel.ForeColor = polcasColor;
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
                this.logoDomaci.Left = rozlozenie.LogoDomaci_X;
                this.logoDomaci.Top = rozlozenie.LogoDomaci_Y;
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
                this.logoHostia.Left = rozlozenie.LogoHostia_X;
                this.logoHostia.Top = rozlozenie.LogoHostia_Y;
                this.logoHostia.Width = rozlozenie.LogoHostiaSirka;
                this.logoHostia.Height = (int)(pom * this.logoHostia.Width);
                this.logoHostia.Visible = true;
            }

            this.skoreDomaciLabel.Left = rozlozenie.DomaciSkore_X;
            this.skoreDomaciLabel.Top = rozlozenie.DomaciSkore_Y;

            this.skoreHostiaLabel.Left = rozlozenie.HostiaSkore_X;
            this.skoreHostiaLabel.Top = rozlozenie.HostiaSkore_Y;

            this.hostiaLabel.Left = rozlozenie.Hostia_X;
            this.hostiaLabel.Top = rozlozenie.Hostia_Y;

            this.domaciLabel.Left = rozlozenie.Domaci_X;
            this.domaciLabel.Top = rozlozenie.Domaci_Y;

            this.casLabel.Left = rozlozenie.Cas_X;
            this.casLabel.Top = rozlozenie.Cas_Y;

            this.polcasLabel.Left = rozlozenie.Polcas_X;
            this.polcasLabel.Top = rozlozenie.Polcas_Y;

        }

        #endregion
    }
}
