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
        public TabulaForm(int sirkaPlochy)
        {

            InitializeComponent();
            SetDefaultFarby();
            // Nastavenie velkosti zobrazovacej plochy - zvacsenie na pozadovanu velkost
            float pomer = (float)sirkaPlochy / (float)this.Width;
            Scale(new SizeF(pomer, pomer));

            LayoutSetter.NastavVelkostiElementov(this, pomer);
        }

        public void SetDefaultFarby()
        {
            casLabel.ForeColor = Color.Lime;
            polcasLabel.ForeColor = Color.Lime;
            domaciLabel.ForeColor = Color.Aqua;
            hostiaLabel.ForeColor = Color.Aqua;
            skoreDomaciLabel.ForeColor = Color.Red;
            skoreHostiaLabel.ForeColor = Color.Red;
        }

        public void SetFarby(FarbyTabule fs)
        {
            casLabel.ForeColor = fs.GetCasFarba();
            polcasLabel.ForeColor = fs.GetPolcasFarba();
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

        public void SetPolcas(int hodnota, int nadstaveneMinuty, bool nadstavenyCas)
        {
            if (nadstavenyCas)
            {
                polcasLabel.Text = hodnota + ". polčas + " + nadstaveneMinuty + " !";
                polcasLabel.ForeColor = Color.OrangeRed;
            }
            else
            {
                polcasLabel.Text = hodnota + ". polčas";
                polcasLabel.ForeColor = Color.Lime;
            }
            
        }

        public void SetCas(string text)
        {
            casLabel.Text = text;
        }

        public void Reset()
        {
            SetSkoreDomaci(0);
            SetSkoreHostia(0);
            SetPolcas(0, 0, false);
            SetCas("00:00");
        }

        public void SetFonty(FontyTabule fonty)
        {
            skoreDomaciLabel.Font = fonty.CreateSkoreFont();
            skoreHostiaLabel.Font = fonty.CreateSkoreFont();

            domaciLabel.Font = fonty.CreateNazvyFont();
            hostiaLabel.Font = fonty.CreateNazvyFont();

            casLabel.Font = fonty.CreateCasFont();
            polcasLabel.Font = fonty.CreatePolcasFont();

        }

        public void SetLayout(RozlozenieTabule rozlozenie)
        {
            double pom = this.logoDomaci.Width / this.logoDomaci.Height;
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

        private void TabulaForm_Load(object sender, EventArgs e)
        {
            LayoutSetter.ZobrazNaDruhejObrazovke(this);
        }
    }
}
