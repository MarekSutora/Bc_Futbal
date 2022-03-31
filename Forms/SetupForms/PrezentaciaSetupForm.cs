using LGR_Futbal.Properties;
using LGR_Futbal.Setup;
using LGR_Futbal.Model;
using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace LGR_Futbal.Forms
{
    public delegate void VyberTimuNaPrezentaciuHandler(FutbalovyTim tim, FarbyPrezentacie farby);
    public delegate void ZastavenieHandlerPrezentacie();
    public delegate void NastaveniaPotvrdeneHandler(bool n);

    public partial class PrezentaciaSetupForm : Form
    {
        public event VyberTimuNaPrezentaciuHandler OnVyberTimuNaPrezentaciu;
        public event ZastavenieHandlerPrezentacie OnZastaveniePrezentacie;
        public event NastaveniaPotvrdeneHandler OnNastaveniaPotvrdene;

        private FutbalovyTim domaci = null;
        private FutbalovyTim hostia = null;
        private FarbyPrezentacie farbyDomaci = null;
        private FarbyPrezentacie farbyHostia = null;
        private FontyTabule fontyTabule = null;

        public PrezentaciaSetupForm(FutbalovyTim dom, FutbalovyTim host, FontyTabule fonty, bool nahr, FarbyPrezentacie farbyPrezDomaci, FarbyPrezentacie farbyPrezHostia)
        {
            InitializeComponent();

            nahradniciCheckBox.Checked = nahr;

            fontyTabule = fonty;
            domaci = dom;
            hostia = host;
            farbyDomaci = farbyPrezDomaci;
            farbyHostia = farbyPrezHostia;

            if (domaci == null)
                DomaciPrezentaciaBtn.Enabled = false;
            else if (domaci.ZoznamHracov.Count == 0)
                DomaciPrezentaciaBtn.Enabled = false;

            if (hostia == null)
                HostiaPrezentaciaBtn.Enabled = false;
            else if (hostia.ZoznamHracov.Count == 0)
                HostiaPrezentaciaBtn.Enabled = false;
        }
        private void DomaciPrezentaciaBtn_Click(object sender, EventArgs e)
        {
            OnNastaveniaPotvrdene?.Invoke(nahradniciCheckBox.Checked);
            OnVyberTimuNaPrezentaciu?.Invoke(domaci, farbyDomaci);
            Close();
        }
        private void HostiaPrezentaciaBtn_Click(object sender, EventArgs e)
        {
            OnNastaveniaPotvrdene?.Invoke(nahradniciCheckBox.Checked);
            OnVyberTimuNaPrezentaciu?.Invoke(hostia, farbyHostia);
            Close();
        }
        private void FarbyBtn_Click(object sender, EventArgs e)
        {
            FarbyPrezentacieForm fp = new FarbyPrezentacieForm(farbyDomaci, farbyHostia);
            fp.Show();
        }

        private void FontyBtn_Click(object sender, EventArgs e)
        {
            FontyPrezentacieForm fpf = new FontyPrezentacieForm(fontyTabule);
            fpf.Show();
        }
        private void ZastavitPrezentaciuBtn_Click(object sender, EventArgs e)
        {
            OnZastaveniePrezentacie?.Invoke();
            Close();
        }
        private void BackBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void PredstavenieSettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            OnNastaveniaPotvrdene?.Invoke(nahradniciCheckBox.Checked);
        }
    }
}
