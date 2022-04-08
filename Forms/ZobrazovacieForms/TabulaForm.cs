using System;
using System.Drawing;
using System.Windows.Forms;
using LGR_Futbal.Setup;

namespace LGR_Futbal.Forms
{
    public partial class TabulaForm : Form
    {
        private RozlozenieTabule rozlozenieTabule;

        public TabulaForm(int sirkaPlochy)
        {
            InitializeComponent();
            SetDefaultFarby();
            float pomer = (float)sirkaPlochy / Width;
            Scale(new SizeF(pomer, pomer));

            LayoutSetter.NastavVelkostiElementov(this, pomer);

            rozlozenieTabule = new RozlozenieTabule();
        }

        public RozlozenieTabule GetRozlozenie()
        {
            rozlozenieTabule.Cas_X = casLabel.Left;
            rozlozenieTabule.Cas_Y = casLabel.Top;
            rozlozenieTabule.Cas_Sirka = casLabel.Width;

            rozlozenieTabule.DomaciNazov_X = domaciLabel.Left;
            rozlozenieTabule.DomaciNazov_Y = domaciLabel.Top;
            rozlozenieTabule.DomaciNazov_Sirka = domaciLabel.Width;

            rozlozenieTabule.HostiaNazov_X = hostiaLabel.Left;
            rozlozenieTabule.HostiaNazov_Y = hostiaLabel.Top;
            rozlozenieTabule.HostiaNazov_Sirka = hostiaLabel.Width;

            rozlozenieTabule.DomaciSkore_X = skoreDomaciLabel.Left;
            rozlozenieTabule.DomaciSkore_Y = skoreDomaciLabel.Top;
            rozlozenieTabule.DomaciSkore_Sirka = skoreDomaciLabel.Width;

            rozlozenieTabule.HostiaSkore_X = skoreHostiaLabel.Left;
            rozlozenieTabule.HostiaSkore_Y = skoreHostiaLabel.Top;
            rozlozenieTabule.HostiaSkore_Sirka = skoreHostiaLabel.Width;

            rozlozenieTabule.LogoDomaci_X = logoDomaci.Left;
            rozlozenieTabule.LogoDomaci_Y = logoDomaci.Top;
            rozlozenieTabule.LogoDomaci_Sirka = logoDomaci.Width;
            rozlozenieTabule.LogoDomaci_Zobrazit = true;

            rozlozenieTabule.LogoHostia_X = logoHostia.Left;
            rozlozenieTabule.LogoHostia_Y = logoHostia.Top;
            rozlozenieTabule.LogoHostia_Sirka = logoHostia.Width;
            rozlozenieTabule.LogoHostia_Zobrazit = true;

            rozlozenieTabule.Polcas_X = polcasLabel.Left;
            rozlozenieTabule.Polcas_Y = polcasLabel.Top;
            rozlozenieTabule.Polcas_Sirka = polcasLabel.Width;

            return rozlozenieTabule;

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
                casLabel.ForeColor = Color.OrangeRed;
            }
            else
            {
                polcasLabel.Text = hodnota + ". polčas";
                polcasLabel.ForeColor = Color.Lime;
                casLabel.ForeColor = Color.Lime;
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
            double pom = logoDomaci.Width / logoDomaci.Height;
            if (!rozlozenie.LogoDomaci_Zobrazit)
            {
                logoDomaci.Visible = false;
            }
            else
            {
                logoDomaci.Left = rozlozenie.LogoDomaci_X;
                logoDomaci.Top = rozlozenie.LogoDomaci_Y;
                logoDomaci.Width = rozlozenie.LogoDomaci_Sirka;
                logoDomaci.Height = (int)(pom * logoDomaci.Width);
                logoDomaci.Visible = true;
            }

            if (!rozlozenie.LogoHostia_Zobrazit)
            {
                logoHostia.Visible = false;
            }
            else
            {
                logoHostia.Left = rozlozenie.LogoHostia_X;
                logoHostia.Top = rozlozenie.LogoHostia_Y;
                logoHostia.Width = rozlozenie.LogoHostia_Sirka;
                logoHostia.Height = (int)(pom * logoHostia.Width);
                logoHostia.Visible = true;
            }

            skoreDomaciLabel.Left = rozlozenie.DomaciSkore_X;
            skoreDomaciLabel.Top = rozlozenie.DomaciSkore_Y;
            skoreDomaciLabel.Width = rozlozenie.DomaciSkore_Sirka;

            skoreHostiaLabel.Left = rozlozenie.HostiaSkore_X;
            skoreHostiaLabel.Top = rozlozenie.HostiaSkore_Y;
            skoreHostiaLabel.Width = rozlozenie.HostiaSkore_Sirka;

            hostiaLabel.Left = rozlozenie.HostiaNazov_X;
            hostiaLabel.Top = rozlozenie.HostiaNazov_Y;
            hostiaLabel.Width = rozlozenie.HostiaNazov_Sirka;

            domaciLabel.Left = rozlozenie.DomaciNazov_X;
            domaciLabel.Top = rozlozenie.DomaciNazov_Y;
            domaciLabel.Width = rozlozenie.DomaciNazov_Sirka;

            casLabel.Left = rozlozenie.Cas_X;
            casLabel.Top = rozlozenie.Cas_Y;
            casLabel.Width = rozlozenie.Cas_Sirka;

            polcasLabel.Left = rozlozenie.Polcas_X;
            polcasLabel.Top = rozlozenie.Polcas_Y;
            polcasLabel.Width = rozlozenie.Polcas_Sirka;

        }

        private void TabulaForm_Load(object sender, EventArgs e)
        {
            LayoutSetter.ZobrazNaDruhejObrazovke(this);

            ControlExtension.Draggable(logoDomaci, true);
            ControlExtension.Draggable(logoHostia, true);
            ControlExtension.Draggable(casLabel, true);
            ControlExtension.Draggable(domaciLabel, true);
            ControlExtension.Draggable(hostiaLabel, true);
            ControlExtension.Draggable(skoreDomaciLabel, true);
            ControlExtension.Draggable(skoreHostiaLabel, true);
            ControlExtension.Draggable(polcasLabel, true);
        }
    }
}
