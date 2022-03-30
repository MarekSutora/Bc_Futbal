using LGR_Futbal.Properties;
using LGR_Futbal.Setup;
using LGR_Futbal.Model;
using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace LGR_Futbal.Forms
{
    public delegate void VyberTimuNaPrezentaciuHandler(FutbalovyTim tim, Setup.FarbyPrezentacie farby);
    public delegate void ZastavenieHandler();
    public delegate void NastaveniaConfirmedHandler(bool n);

    public partial class PredstavenieSettingsForm : Form
    {
        #region Atributy

        public event VyberTimuNaPrezentaciuHandler OnVyberTimuNaPrezentaciu;
        public event ZastavenieHandler OnZastaveniePrezentacie;
        public event NastaveniaConfirmedHandler OnNastaveniaConfirmed;

        private FutbalovyTim dom;
        private FutbalovyTim hos;
        private FarbyPrezentacie farbyDom;
        private FarbyPrezentacie farbyHos;
        private FontyTabule pisma;

        #endregion

        #region Konstruktor a metody

        public PredstavenieSettingsForm(string adr, FutbalovyTim domaci, FutbalovyTim hostia, FontyTabule fonty, bool nahr, FarbyPrezentacie farbyPrezDomaci, FarbyPrezentacie farbyPrezHostia)
        {
            InitializeComponent();

            checkBox1.Checked = nahr;

            pisma = fonty;
            dom = domaci;
            hos = hostia;
            farbyDom = farbyPrezDomaci;
            farbyHos = farbyPrezHostia;

            if (dom == null)
                domaciButton.Enabled = false;
            else if (dom.ZoznamHracov.Count == 0)
                domaciButton.Enabled = false;

            if (hos == null)
                hostiaButton.Enabled = false;
            else if (hos.ZoznamHracov.Count == 0)
                hostiaButton.Enabled = false;
        }

        public Setup.FarbyPrezentacie GetFarbyDom()
        {
            return farbyDom;
        }

        public Setup.FarbyPrezentacie GetFarbyHos()
        {
            return farbyHos;
        }

        private void PredstavenieSettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (OnNastaveniaConfirmed != null)
                OnNastaveniaConfirmed(checkBox1.Checked);
        }

        private void DomaciButton_Click(object sender, EventArgs e)
        {
            if (OnNastaveniaConfirmed != null)
                OnNastaveniaConfirmed(checkBox1.Checked);
            if (OnVyberTimuNaPrezentaciu != null)
                OnVyberTimuNaPrezentaciu(dom, farbyDom);
            this.Close();
        }

        private void HostiaButton_Click(object sender, EventArgs e)
        {
            if (OnNastaveniaConfirmed != null)
                OnNastaveniaConfirmed(checkBox1.Checked);
            if (OnVyberTimuNaPrezentaciu != null)
                OnVyberTimuNaPrezentaciu(hos, farbyHos);
            this.Close();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void farbyButton_Click(object sender, EventArgs e)
        {
            FarbyPrezentacieForm fp = new FarbyPrezentacieForm(farbyDom, farbyHos);
            fp.Show();
        }

        private void fontyButton_Click(object sender, EventArgs e)
        {
            FontyPrezentacieForm fpf = new FontyPrezentacieForm(pisma);
            fpf.Show();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            zastavPrezentaciu();
        }

        private void PredstavenieSettingsForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                zastavPrezentaciu();
        }

        private void zastavPrezentaciu()
        {
            if (OnZastaveniePrezentacie != null)
                OnZastaveniePrezentacie();
            this.Close();
        }

        #endregion
    }
}
