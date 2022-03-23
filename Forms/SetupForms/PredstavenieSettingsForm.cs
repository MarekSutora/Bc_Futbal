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
        private Setup.FarbyPrezentacie farbyDom;
        private Setup.FarbyPrezentacie farbyHos;
        private string adresar;
        private FontyTabule pisma;

        #endregion

        #region Konstruktor a metody

        public PredstavenieSettingsForm(String adr, FutbalovyTim domaci, FutbalovyTim hostia, FontyTabule fonty, bool nahr)
        {
            InitializeComponent();

            if (Settings.Default.Jazyk == 1)
            {
                this.Text = "Představení hráčů";
                checkBox1.Text = "Zahrnout do prezentace náhradníky";

                domaciButton.Text = "Prezentace\ndomácího týmu";
                hostiaButton.Text = "Prezentace\ntýmu hostí";

                farbyButton.Text = "Nastavení\nbarev";
                fontyButton.Text = "Nastavení\nfontů";

                stopButton.Text = "Zastavit\nprezentaci";
                backButton.Text = "Návrat\nzpět";
            }

            checkBox1.Checked = nahr;

            adresar = adr;
            pisma = fonty;
            dom = domaci;
            hos = hostia;

            if (dom == null)
                domaciButton.Enabled = false;
            else if (dom.ZoznamHracov.Count == 0)
                domaciButton.Enabled = false;

            if (hos == null)
                hostiaButton.Enabled = false;
            else if (hos.ZoznamHracov.Count == 0)
                hostiaButton.Enabled = false;

            farbyDom = new Setup.FarbyPrezentacie();
            farbyHos = new Setup.FarbyPrezentacie();
            nacitajFarby();
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
            ulozFarby();
            if (OnNastaveniaConfirmed != null)
                OnNastaveniaConfirmed(checkBox1.Checked);
        }

        private void ulozFarby()
        {
            TextWriter textWriter1 = null;
            TextWriter textWriter2 = null;

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Setup.FarbyPrezentacie));
                textWriter1 = new StreamWriter(adresar + "\\Files\\DomaciPrezentacia.xml");
                serializer.Serialize(textWriter1, farbyDom);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "LGR Futbal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (textWriter1 != null)
                    textWriter1.Close();
            }

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Setup.FarbyPrezentacie));
                textWriter2 = new StreamWriter(adresar + "\\Files\\HostiaPrezentacia.xml");
                serializer.Serialize(textWriter2, farbyHos);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "LGR Futbal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (textWriter2 != null)
                    textWriter2.Close();
            }
        }

        private void nacitajFarby()
        {
            TextReader textReader1 = null;
            TextReader textReader2 = null;

            try
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(Setup.FarbyPrezentacie));
                textReader1 = new StreamReader(adresar + "\\Files\\DomaciPrezentacia.xml");
                farbyDom = (Setup.FarbyPrezentacie)deserializer.Deserialize(textReader1);
            }
            catch
            {
                farbyDom = new Setup.FarbyPrezentacie();
            }
            finally
            {
                if (textReader1 != null)
                    textReader1.Close();
            }

            try
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(Setup.FarbyPrezentacie));
                textReader2 = new StreamReader(adresar + "\\Files\\HostiaPrezentacia.xml");
                farbyHos = (Setup.FarbyPrezentacie)deserializer.Deserialize(textReader2);
            }
            catch
            {
                farbyHos = new Setup.FarbyPrezentacie();
            }
            finally
            {
                if (textReader2 != null)
                    textReader2.Close();
            }
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
