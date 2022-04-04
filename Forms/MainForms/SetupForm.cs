using LGR_Futbal.Properties;
using LGR_Futbal.Setup;
using LGR_Futbal.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using LGR_Futbal.Databaza;

namespace LGR_Futbal.Forms
{
    public delegate void DataPotvrdeneHandler(bool zobrazovatPozadie, bool zobrazNastavenia, int sirka, int vyska, int cas, bool prerusenie, bool diakritika, int animacia);
    public delegate void ResetHandler();
    public delegate void ZhasniHandler();
    public delegate void RozsvietHandler();
    public delegate void NazvyLogaPotvrdeneHandler(string domNazov, Image domaciLogo, string hosNazov, Image hosLogo);
    public delegate void TimyVybraneHandler(FutbalovyTim domTim, FutbalovyTim hosTim);
    public delegate void ObnovaFariebHandler();
    public delegate void ZmenaFariebHandler();
    public delegate void ZmenaFontovHandler();
    public delegate void AnimacieKarietPotvrdeneHandler(string s1, string s2);
    public delegate void ZmenaRozlozeniaHandler();

    public partial class SetupForm : Form
    {
        #region ATRIBUTY
        public event DataPotvrdeneHandler OnDataPotvrdene;
        public event ResetHandler OnReset;
        public event ZhasniHandler OnZhasnut;
        public event RozsvietHandler OnRozsvietit;
        public event NazvyLogaPotvrdeneHandler OnNazvyLogaPotvrdene;
        public event TimyVybraneHandler OnTimyVybrane;
        public event ObnovaFariebHandler OnObnovaFarieb;
        public event ZmenaFariebHandler OnZmenaFarieb;
        public event ZmenaFontovHandler OnZmenaFontov;
        public event AnimacieKarietPotvrdeneHandler OnAnimacieKarietPotvrdene;
        public event ZmenaRozlozeniaHandler OnZmenaRozlozenia;

        private const string nazovProgramuString = "FutbalApp";
        private const string gifyAdresar = "Files\\Gify\\";
        private const string kartyAdresar = "Files\\Karty\\";
        private const string typyZapasovSubor = "Files\\Typy.xml";

        private int sirka;
        private int vyska;
        private bool aktivnaZmena = true;
        private string adresar;

        private FutbalovyTim domaciT = null;
        private FutbalovyTim hostiaT = null;

        private FarbyTabule farbyTabule = null;
        private List<ParametreZapasu> zoznamTypovZapasu = null;
        private AnimacnaKonfiguracia animKonfig = null;
        private List<string> zoznamSuborov = null;
        private List<Rozhodca> rozhodcovia = null;
        private RozlozenieTabule rozlozenieTabule = null;
        private FontyTabule fontyTabule = null;

        private DBTimy dbtimy = null;
        private DBHraci dbhraci = null;
        private DBRozhodcovia dbrozhodcovia = null;
        private DBZapasy dbzapasy = null;

        #endregion ATRIBUTY


        public SetupForm(bool zobrazitPozadie, bool zobrazitNastaveniaPoSpusteni, int si, int vy, int dlzkaPolcasu, bool prerusenie, bool diakritika,
            string nazovDom, string nazovHos, FutbalovyTim domaci, FutbalovyTim hostia, string adr, int animacia, FarbyTabule farby, 
            AnimacnaKonfiguracia konfiguracia, List<Rozhodca> roz, DBTimy dbt, DBHraci dbh, DBRozhodcovia dbr, DBZapasy dbz, FontyTabule f, RozlozenieTabule r)
        {
            InitializeComponent();

            sirka = si;
            vyska = vy;
            rozlozenieTabule = r;
            dbtimy = dbt;
            dbhraci = dbh;
            dbrozhodcovia = dbr;
            dbzapasy = dbz;
            fontyTabule = f;
            rozhodcovia = roz;
            domaciT = domaci;
            hostiaT = hostia;
            zoznamSuborov = new List<string>();
            animKonfig = konfiguracia;
            adresar = adr;
            NacitajNastaveniaAnimaciiGolov();
            farbyTabule = farby;
            NastavHracovDomBtn.Enabled = true;
            if (domaciT == null)
            {
                NastavHracovDomBtn.Enabled = false;
            }
            NastavHracovHosBtn.Enabled = true;
            if (hostiaT == null)
            {
                NastavHracovHosBtn.Enabled = false;
            }

            if (animKonfig.ZltaKartaAnimacia.Equals(string.Empty))
                zltaKartaPictureBox.Image = null;
            else
            {
                try
                {
                    zltaKartaPictureBox.Image = Image.FromFile(adresar + "\\" + kartyAdresar + animKonfig.ZltaKartaAnimacia);
                }
                catch
                {
                    zltaKartaPictureBox.Image = null;
                    animKonfig.ZltaKartaAnimacia = string.Empty;
                }
            }

            if (animKonfig.CervenaKartaAnimacia.Equals(string.Empty))
                cervenaKartaPictureBox.Image = null;
            else
            {
                try
                {
                    cervenaKartaPictureBox.Image = Image.FromFile(adresar + "\\" + kartyAdresar + animKonfig.CervenaKartaAnimacia);
                }
                catch
                {
                    cervenaKartaPictureBox.Image = null;
                    animKonfig.CervenaKartaAnimacia = string.Empty;
                }
            }

            Screen pd = Screen.AllScreens.ElementAtOrDefault(0);
            Screen sd = Screen.AllScreens.FirstOrDefault(s => s != pd) ?? pd;
            rozlisenieLabel.Text = sd.Bounds.Width.ToString() + " x " + sd.Bounds.Height.ToString();

            sirkaNumUpDown.Value = sirka;
            vyskaNumUpDown.Value = vyska;
            dlzkaPolcasuNumUpDown.Value = dlzkaPolcasu;
            prerusenieCheckBox.Checked = prerusenie;
            diakritikaCheckBox.Checked = diakritika;

            pozadieCheckBox.Checked = zobrazitPozadie;
            initNastaveniaCheckBox.Checked = zobrazitNastaveniaPoSpusteni;

            ovladace.SelectedIndex = 2;

            if ((domaciT != null) && (hostiaT != null))
            {
                ZobrazLoga(domaciT.LogoImage, hostiaT.LogoImage);
                domNazov.Text = domaciT.NazovTimu;
                hosNazov.Text = hostiaT.NazovTimu;
                ZrusitTimyBtn.Enabled = true;
            }
            else
            {
                domNazov.Text = nazovDom;
                hosNazov.Text = nazovHos;
                ZrusitTimyBtn.Enabled = false;
            }

            animaciaNumUpDown.Value = animacia;

            zoznamTypovZapasu = new List<ParametreZapasu>();
            TypyZapasovListBox.Items.Clear();
            NacitajTypyZapasov();
        }

        #region VYSLEDKOVA TABULA

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Naozaj chcete resetovať výsledkovú tabuľu?", nazovProgramuString, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                OnReset?.Invoke();

            Close();
        }

        private void ZhasnutBtn_Click(object sender, EventArgs e)
        {
            OnZhasnut?.Invoke();
            Close();
        }

        private void RozsvietitBtn_Click(object sender, EventArgs e)
        {
            OnRozsvietit?.Invoke();
            Close();
        }

        private void SirkaNumUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (aktivnaZmena)
            {
                // Prepocet vysky vzhladom na novu sirku v pomere 16:9
                int aktualnaHodnota = (int)sirkaNumUpDown.Value;
                aktivnaZmena = false;
                vyskaNumUpDown.Value = (9 * aktualnaHodnota) / 16;
                aktivnaZmena = true;
            }
        }

        private void VyskaNumUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (aktivnaZmena)
            {
                // Prepocet sirky vzhladom na novu vysku v pomere 16:9
                int aktualnaHodnota = (int)vyskaNumUpDown.Value;
                aktivnaZmena = false;
                sirkaNumUpDown.Value = (aktualnaHodnota * 16) / 9;
                aktivnaZmena = true;
            }
        }

        private void ZmenitFarbyBtn_Click(object sender, EventArgs e)
        {
            FarbyForm ff = new FarbyForm(adresar + "\\Files\\FarebneNastavenia", farbyTabule);
            ff.OnZmenaFarieb += () => this.OnZmenaFarieb?.Invoke();
            ff.OnObnovaFarieb += () => this.OnObnovaFarieb?.Invoke();
            ff.Show();
        }

        private void ZmenitFontyBtn_Click(object sender, EventArgs e)
        {
            FontyForm fontyForm = new FontyForm(adresar + "\\Files\\FontyNastavenia", fontyTabule);
            fontyForm.OnZmenaFontov += () => this.OnZmenaFontov?.Invoke();
            fontyForm.Show();
        }

        private void ZmenitRozlozenieBtn_Click(object sender, EventArgs e)
        {
            RozlozenieForm rf = new RozlozenieForm(adresar + "\\Files\\RozlozenieNastavenia", rozlozenieTabule, sirka, vyska);
            rf.OnZmenaRozlozenia += () => this.OnZmenaRozlozenia?.Invoke();
            rf.Show();
        }

        #endregion VYSLEDKOVA TABULA

        #region PRIEBEH HRY

        private void Button1_Click(object sender, EventArgs e)
        {
            int hodnota = (int)dlzkaPolcasuNumUpDown.Value;
            hodnota = (hodnota * 10) + 1;
            if (hodnota <= dlzkaPolcasuNumUpDown.Maximum)
                dlzkaPolcasuNumUpDown.Value = hodnota;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            int hodnota = (int)dlzkaPolcasuNumUpDown.Value;
            hodnota = (hodnota * 10) + 2;
            if (hodnota <= dlzkaPolcasuNumUpDown.Maximum)
                dlzkaPolcasuNumUpDown.Value = hodnota;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            int hodnota = (int)dlzkaPolcasuNumUpDown.Value;
            hodnota = (hodnota * 10) + 3;
            if (hodnota <= dlzkaPolcasuNumUpDown.Maximum)
                dlzkaPolcasuNumUpDown.Value = hodnota;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            int hodnota = (int)dlzkaPolcasuNumUpDown.Value;
            hodnota = (hodnota * 10) + 4;
            if (hodnota <= dlzkaPolcasuNumUpDown.Maximum)
                dlzkaPolcasuNumUpDown.Value = hodnota;
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            int hodnota = (int)dlzkaPolcasuNumUpDown.Value;
            hodnota = (hodnota * 10) + 5;
            if (hodnota <= dlzkaPolcasuNumUpDown.Maximum)
                dlzkaPolcasuNumUpDown.Value = hodnota;
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            int hodnota = (int)dlzkaPolcasuNumUpDown.Value;
            hodnota = (hodnota * 10) + 6;
            if (hodnota <= dlzkaPolcasuNumUpDown.Maximum)
                dlzkaPolcasuNumUpDown.Value = hodnota;
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            int hodnota = (int)dlzkaPolcasuNumUpDown.Value;
            hodnota = (hodnota * 10) + 7;
            if (hodnota <= dlzkaPolcasuNumUpDown.Maximum)
                dlzkaPolcasuNumUpDown.Value = hodnota;
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            int hodnota = (int)dlzkaPolcasuNumUpDown.Value;
            hodnota = (hodnota * 10) + 8;
            if (hodnota <= dlzkaPolcasuNumUpDown.Maximum)
                dlzkaPolcasuNumUpDown.Value = hodnota;
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            int hodnota = (int)dlzkaPolcasuNumUpDown.Value;
            hodnota = (hodnota * 10) + 9;
            if (hodnota <= dlzkaPolcasuNumUpDown.Maximum)
                dlzkaPolcasuNumUpDown.Value = hodnota;
        }

        private void Button0_Click(object sender, EventArgs e)
        {
            int hodnota = (int)dlzkaPolcasuNumUpDown.Value;
            hodnota = (hodnota * 10);
            if (hodnota <= dlzkaPolcasuNumUpDown.Maximum)
                dlzkaPolcasuNumUpDown.Value = hodnota;
        }

        private void ZmazatBtn_Click(object sender, EventArgs e)
        {
            int hodnota = (int)dlzkaPolcasuNumUpDown.Value;
            hodnota = hodnota / 10;
            dlzkaPolcasuNumUpDown.Value = hodnota;
        }

        private void NacitajTypyZapasov()
        {
            TextReader textReader = null;

            try
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(List<ParametreZapasu>));
                textReader = new StreamReader(adresar + "\\" + typyZapasovSubor);
                zoznamTypovZapasu = (List<ParametreZapasu>)deserializer.Deserialize(textReader);

                if (zoznamTypovZapasu.Count > 0)
                {
                    foreach (ParametreZapasu pz in zoznamTypovZapasu)
                        TypyZapasovListBox.Items.Add(pz.ToString());

                    TypyZapasovListBox.SelectedIndex = 0;
                    OdstranitTypBtn.Enabled = true;
                    VybratTypBtn.Enabled = true;
                }
            }
            catch
            {
                TypyZapasovListBox.Items.Clear();
                zoznamTypovZapasu.Clear();

                OdstranitTypBtn.Enabled = false;
                VybratTypBtn.Enabled = false;
            }
            finally
            {
                if (textReader != null)
                    textReader.Close();
            }
        }

        private void UlozTypyZapasov()
        {
            TextWriter textWriter = null;

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<ParametreZapasu>));
                textWriter = new StreamWriter(adresar + "\\" + typyZapasovSubor);
                serializer.Serialize(textWriter, zoznamTypovZapasu);
            }
            catch
            {

            }
            finally
            {
                if (textWriter != null)
                    textWriter.Close();
            }
        }

        private void PridatTypBtn_Click(object sender, EventArgs e)
        {
            TypZapasuForm tzf = new TypZapasuForm();
            tzf.OnNovyTypZapasu += Tzf_OnNovyTypZapasu;
            tzf.Show();
        }

        private void Tzf_OnNovyTypZapasu(ParametreZapasu parZap)
        {
            zoznamTypovZapasu.Add(parZap);
            TypyZapasovListBox.Items.Add(parZap.ToString());
            TypyZapasovListBox.SelectedIndex = 0;

            OdstranitTypBtn.Enabled = true;
            VybratTypBtn.Enabled = true;
        }

        private void VybratTypBtn_Click(object sender, EventArgs e)
        {
            VyberTypZapasu();
        }
        private void TypyZapasovListBox_DoubleClick(object sender, EventArgs e)
        {
            VyberTypZapasu();
        }

        private void VyberTypZapasu()
        {
            int index = TypyZapasovListBox.SelectedIndex;
            if (index >= 0)
            {
                ParametreZapasu pz = zoznamTypovZapasu[index];
                dlzkaPolcasuNumUpDown.Value = pz.DlzkaPolcasu;
                prerusenieCheckBox.Checked = pz.Prerusenie;
            }
        }

        private void OdstranitTypBtn_Click(object sender, EventArgs e)
        {
            int index = TypyZapasovListBox.SelectedIndex;
            if (index >= 0)
            {
                zoznamTypovZapasu.RemoveAt(index);
                TypyZapasovListBox.Items.RemoveAt(index);

                if (TypyZapasovListBox.Items.Count > 0)
                    TypyZapasovListBox.SelectedIndex = 0;
                else
                {
                    OdstranitTypBtn.Enabled = false;
                    VybratTypBtn.Enabled = false;
                }
            }
        }

        #endregion PRIEBEH HRY

        #region MUZSTVA A LOGA

        private void ZobrazLoga(Image domaci, Image hostia)
        {
            try
            {
                logoDomaciPictureBox.Image = domaci;
            }
            catch
            {
                logoDomaciPictureBox.Image = null;
            }

            try
            {
                logoHostiaPictureBox.Image = hostia;
            }
            catch
            {
                logoHostiaPictureBox.Image = null;
            }
        }

        private void ZmenitLogoDomBtn_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Multiselect = false;
                ofd.Filter = "jpeg files (*.jpg)|*.jpg|png files (*.png)|*.png|All files (*.*)|*.*";
                ofd.FilterIndex = 1;
                ofd.RestoreDirectory = true;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    logoDomaciPictureBox.Image = Image.FromFile(ofd.FileName);
                    if (domaciT != null)
                    {
                        domaciT.LogoImage = Image.FromFile(ofd.FileName);
                    }
                }
            }
            catch
            {
                logoDomaciPictureBox.Image = null;
            }
        }

        private void ZmenitLogoHosBtn_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Multiselect = false;
                ofd.Filter = "jpeg files (*.jpg)|*.jpg|png files (*.png)|*.png|All files (*.*)|*.*";
                ofd.FilterIndex = 1;
                ofd.RestoreDirectory = true;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    logoHostiaPictureBox.Image = Image.FromFile(ofd.FileName);
                    if (hostiaT != null)
                    {
                        hostiaT.LogoImage = Image.FromFile(ofd.FileName);
                    }
                }
            }
            catch
            {
                logoHostiaPictureBox.Image = null;
            }
        }

        private void ZrusitLogoDomBtn_Click(object sender, EventArgs e)
        {
            logoDomaciPictureBox.Image = null;
            domaciT.LogoImage = null;
        }

        private void ZrusitLogoHosBtn_Click(object sender, EventArgs e)
        {
            logoHostiaPictureBox.Image = null;
            hostiaT.LogoImage = null;
        }

        private void NastavHracovDomBtn_Click(object sender, EventArgs e)
        {
            HraciZapasForm hraciZapasForm = new HraciZapasForm(domaciT);
            hraciZapasForm.ShowDialog();
        }

        private void NastavHracovHosBtn_Click(object sender, EventArgs e)
        {
            HraciZapasForm hraciZapasForm = new HraciZapasForm(hostiaT);
            hraciZapasForm.ShowDialog();
        }

        private void ZrusitTimyBtn_Click(object sender, EventArgs e)
        {
            domaciT = null;
            hostiaT = null;
            domNazov.Text = "Domáci";
            hosNazov.Text = "Hostia";
            ZrusitTimyBtn.Enabled = false;
            NastavHracovDomBtn.Enabled = false;
            NastavHracovHosBtn.Enabled = false;
        }

        private void NacitatTimyBtn_Click(object sender, EventArgs e)
        {
            TimyForm tf = new TimyForm(domaciT, hostiaT, dbtimy, dbhraci);
            tf.OnTimyVybrane += Tf_OnTimyVybrane;
            tf.ShowDialog();
        }

        private void Tf_OnTimyVybrane(FutbalovyTim t1, FutbalovyTim t2)
        {
            domaciT = t1;
            hostiaT = t2;
            if (domaciT != null && hostiaT != null)
            {
                ZobrazLoga(domaciT.LogoImage, hostiaT.LogoImage);
                domNazov.Text = domaciT.NazovTimu;
                hosNazov.Text = hostiaT.NazovTimu;
                NastavHracovDomBtn.Enabled = true;
                NastavHracovHosBtn.Enabled = true;
            }
            else if (domaciT != null && hostiaT == null)
            {
                ZobrazLoga(domaciT.LogoImage, null);
                domNazov.Text = domaciT.NazovTimu;
                hosNazov.Text = "Hostia";
                NastavHracovDomBtn.Enabled = true;
                NastavHracovHosBtn.Enabled = false;
            }
            else if (domaciT == null && hostiaT != null)
            {
                ZobrazLoga(null, hostiaT.LogoImage);
                domNazov.Text = "Domáci";
                hosNazov.Text = hostiaT.NazovTimu;
                NastavHracovDomBtn.Enabled = false;
                NastavHracovHosBtn.Enabled = true;
            }

            ZrusitTimyBtn.Enabled = true;
        }

        private string OdstranDiakritiku(string vstup)
        {
            // Pomocna metoda na odstranenie diakritiky z retazca
            vstup = vstup.Normalize(NormalizationForm.FormD);

            StringBuilder stb = new StringBuilder();
            for (int i = 0; i < vstup.Length; i++)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(vstup[i]) != UnicodeCategory.NonSpacingMark)
                    stb.Append(vstup[i]);
            }

            return stb.ToString();
        }

        private void RozhodcoviaZapasBtn_Click(object sender, EventArgs e)
        {
            RozhodcoviaForm rf = new RozhodcoviaForm(rozhodcovia, dbrozhodcovia);
            rf.Show();
        }

        #endregion MUZSTVA A LOGA

        #region ANIMACIE GOLOV

        private void NacitajNastaveniaAnimaciiGolov()
        {
            domaciGooolCheckBox.Checked = animKonfig.ZobrazitAnimaciuDomaci;
            hostiaGooolCheckBox.Checked = animKonfig.ZobrazitAnimaciuHostia;

            FileInfo fi;
            string nazov;
            string[] pole = Directory.GetFiles(adresar + "\\" + gifyAdresar);
            for (int i = 0; i < pole.Length; i++)
            {
                if (pole[i].EndsWith(".gif"))
                {
                    fi = new FileInfo(pole[i]);
                    nazov = fi.Name;
                    zoznamSuborov.Add(pole[i]);

                    if (animKonfig.AnimacieDomaci.Contains(nazov))
                        animDomBox.Items.Add(nazov, true);
                    else
                        animDomBox.Items.Add(nazov, false);

                    if (animKonfig.AnimacieHostia.Contains(nazov))
                        animHosBox.Items.Add(nazov, true);
                    else
                        animHosBox.Items.Add(nazov, false);
                }
            }
        }

        private void UlozNastaveniaAnimaciiGolov()
        {
            animKonfig.ZobrazitAnimaciuDomaci = domaciGooolCheckBox.Checked;
            animKonfig.ZobrazitAnimaciuHostia = hostiaGooolCheckBox.Checked;

            animKonfig.AnimacieDomaci.Clear();
            animKonfig.AnimacieHostia.Clear();

            FileInfo fi;
            string nazov;
            for (int i = 0; i < animDomBox.Items.Count; i++)
            {
                if (animDomBox.GetItemChecked(i))
                {
                    fi = new FileInfo(zoznamSuborov[i]);
                    nazov = fi.Name;
                    animKonfig.AnimacieDomaci.Add(nazov);
                }

                if (animHosBox.GetItemChecked(i))
                {
                    fi = new FileInfo(zoznamSuborov[i]);
                    nazov = fi.Name;
                    animKonfig.AnimacieHostia.Add(nazov);
                }
            }
        }

        private void ImportAnimacieGolBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            ofd.InitialDirectory = adresar;
            ofd.Filter = "gif files (*.gif)|*.gif";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                FileInfo fi = new FileInfo(ofd.FileName);
                string nazov = fi.Name;
                string novyNazov = adresar + "\\" + gifyAdresar + "\\" + nazov;
                if (File.Exists(novyNazov))
                    MessageBox.Show("Súbor s takýmto názvon už existuje!", nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    File.Copy(ofd.FileName, novyNazov);
                    zoznamSuborov.Add(novyNazov);
                    animDomBox.Items.Add(nazov, false);
                    animHosBox.Items.Add(nazov, false);
                }
            }
        }

        #endregion ANIMACIE GOLOV

        #region ANIMACIE KARIET

        private void ZmenitZltaAnimBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = adresar + "\\" + kartyAdresar;
            ofd.Multiselect = false;
            ofd.Filter = "jpeg files (*.jpg)|*.jpg|gif files (*.gif)|*.gif|png files (*.png)|*.png|All files (*.*)|*.*";
            ofd.FilterIndex = 1;
            ofd.RestoreDirectory = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string povodnySubor = ofd.FileName;
                FileInfo fi = new FileInfo(povodnySubor);
                string nazov = fi.Name;
                string novyNazov = adresar + "\\" + kartyAdresar + nazov;
                if (!File.Exists(novyNazov))
                    File.Copy(povodnySubor, novyNazov);

                try
                {
                    zltaKartaPictureBox.Image = Image.FromFile(novyNazov);
                    animKonfig.ZltaKartaAnimacia = nazov;
                }
                catch
                {
                    zltaKartaPictureBox.Image = null;
                    animKonfig.ZltaKartaAnimacia = string.Empty;
                }
            }
        }

        private void ZmenitCervenaAnimBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = adresar + "\\" + kartyAdresar;
            ofd.Multiselect = false;
            ofd.Filter = "jpeg files (*.jpg)|*.jpg|gif files (*.gif)|*.gif|png files (*.png)|*.png|All files (*.*)|*.*";
            ofd.FilterIndex = 1;
            ofd.RestoreDirectory = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string povodnySubor = ofd.FileName;
                FileInfo fi = new FileInfo(povodnySubor);
                string nazov = fi.Name;
                string novyNazov = adresar + "\\" + kartyAdresar + nazov;
                if (!File.Exists(novyNazov))
                    File.Copy(povodnySubor, novyNazov);

                try
                {
                    cervenaKartaPictureBox.Image = Image.FromFile(novyNazov);
                    animKonfig.CervenaKartaAnimacia = nazov;
                }
                catch
                {
                    cervenaKartaPictureBox.Image = null;
                    animKonfig.CervenaKartaAnimacia = string.Empty;
                }
            }
        }

        private void ZrusitZltaAnimBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Naozaj chcete zrušiť obrázok (animáciu)?", nazovProgramuString, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                zltaKartaPictureBox.Image = null;
                animKonfig.ZltaKartaAnimacia = string.Empty;
            }
        }

        private void ZrusitCervenaAnimBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Naozaj chcete zrušiť obrázok (animáciu)?", nazovProgramuString, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                cervenaKartaPictureBox.Image = null;
                animKonfig.CervenaKartaAnimacia = string.Empty;
            }
        }


        #endregion ANIMACIE KARIET

        #region INE

        private void TabulaBtn_Click(object sender, EventArgs e)
        {
            ovladace.SelectedIndex = 0;
        }

        private void HraBtn_Click(object sender, EventArgs e)
        {
            ovladace.SelectedIndex = 1;
        }

        private void TimyBtn_Click(object sender, EventArgs e)
        {
            ovladace.SelectedIndex = 2;
        }

        private void GolyAnimacieBtn_Click(object sender, EventArgs e)
        {
            ovladace.SelectedIndex = 3;
        }

        private void KartyAnimacieBtn_Click(object sender, EventArgs e)
        {
            ovladace.SelectedIndex = 4;
        }

        private void DatabazaBtn_Click(object sender, EventArgs e)
        {

            DatabazaForm df = new DatabazaForm(dbtimy, dbhraci, dbrozhodcovia, dbzapasy);
            df.Show();
        }

        private void UlozitBtn_Click(object sender, EventArgs e)
        {
            UlozNastaveniaAnimaciiGolov();

            OnAnimacieKarietPotvrdene?.Invoke(animKonfig.ZltaKartaAnimacia, animKonfig.CervenaKartaAnimacia);

            if (OnDataPotvrdene != null)
            {
                bool poz = pozadieCheckBox.Checked;
                bool initSet = initNastaveniaCheckBox.Checked;
                int sirka = (int)sirkaNumUpDown.Value;
                int vyska = (int)vyskaNumUpDown.Value;
                int dlzkaPolcasu = (int)dlzkaPolcasuNumUpDown.Value;
                bool prerusenie = prerusenieCheckBox.Checked;
                bool diak = diakritikaCheckBox.Checked;
                int animCas = (int)animaciaNumUpDown.Value;
                OnDataPotvrdene(poz, initSet, sirka, vyska, dlzkaPolcasu, prerusenie, diak, animCas);
            }

            if (OnNazvyLogaPotvrdene != null)
            {
                string dn = domNazov.Text;
                string hn = hosNazov.Text;

                if (diakritikaCheckBox.Checked)
                {
                    dn = OdstranDiakritiku(dn);
                    hn = OdstranDiakritiku(hn);
                }
                if (domaciT != null && hostiaT != null)
                {
                    OnNazvyLogaPotvrdene(dn, domaciT.LogoImage, hn, hostiaT.LogoImage);
                }
                else
                {
                    OnNazvyLogaPotvrdene(dn, logoDomaciPictureBox.Image, hn, logoHostiaPictureBox.Image);
                }

            }

            OnTimyVybrane?.Invoke(domaciT, hostiaT);

            Close();
        }

        private void ZrusitBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SetupForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            UlozTypyZapasov();
        }

        #endregion INE
    }
}
