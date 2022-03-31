using LGR_Futbal.Forms;
using LGR_Futbal.Properties;
using LGR_Futbal.Model;
using LGR_Futbal.Setup;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;
using LGR_Futbal.Databaza;
using LGR_Futbal.Forms.UdalostiForms;

namespace LGR_Futbal
{
    public delegate void SetTextCallback();
    public delegate void UdalostPridanaHandler(string text);

    public partial class RiadiaciForm : Form
    {
        #region KONSTANTY

        private const string nazovProgramuString = "LGR Futbal";
        private string konfiguracnySubor = "\\Files\\Config.bin";
        private string animacieSubor = "\\Files\\Gify\\Settings.xml";
        private string rozlozenieSubor = "\\Files\\LastUsed\\PoslednePouziteRozlozenie.xml";
        private string farebnaSchemaSubor = "\\Files\\LastUsed\\PoslednePouzitaSchema.xml";

        #endregion KONSTANTY

        #region ATRIBUTY

        private float pomer;
        private int sirkaTabule;
        private int vyskaTabule;
        private int dlzkaPolcasu;
        private int pocetNadstavenychMinut = 0;
        private int nadstavenaMinuta = 0;
        private int polcas = 0;
        private int minutaPolcasu;
        private int skoreDomaci = 0;
        private int skoreHostia = 0;
        private int animacnyCas = 3;
        // Aktualny hraci cas
        private int aktualnaMinuta;
        private int aktualnaSekunda;

        private bool hraBezi = false;
        private bool poPreruseni = false;
        private bool odstranovatDiakritiku = true;
        private bool nadstavenyCas = false;
        private bool zobrazitPozadie = false;
        private bool zobrazitNastaveniaPoSpusteni = true;
        private bool povolitPrerusenieHry = false;
        private bool koniec = true;
        private bool zobrazitNahradnikov = true;
        // Animacie kariet
        private string animaciaZltaKarta = string.Empty;
        private string animaciaCervenaKarta = string.Empty;

        private string nazovDomaci = "Domáci";
        private string nazovHostia = "Hostia";
        private string currentDirectory = null;

        private Stopwatch sw = null;
        private System.Timers.Timer casovac;
        private FutbalovyTim timDomaci = null;
        private FutbalovyTim timHostia = null;
        private Zapas zapas = null;
        private FontyTabule fontyTabule;

        private AnimacnaKonfiguracia animaciaGolov = null;
        private List<Rozhodca> rozhodcovia = null;
        private RozlozenieTabule rozlozenieTabule = null;
        private FarbyTabule farebnaSchema = null;
        private FarbyPrezentacie farbyPrezHostia = null;
        private FarbyPrezentacie farbyPrezDomaci = null;

        // Formulare
        private PozadieForm formularPozadia = null;
        private TabulaForm formularTabule = null;
        private PrezentaciaForm prezentacia = null;
        private SetupForm sf = null;
        private ReklamaForm rf = null;

        private Pripojenie pripojenie = null;
        private DBHraci dbhraci = null;
        private DBRozhodcovia dbrozhodcovia = null;
        private DBTimy dbtimy = null;
        private DBZapasy dbzapasy = null;

        #endregion ATRIBUTY

        public RiadiaciForm()
        {
            InitializeComponent();

            setDefaultColors();
            SizeForm formular = new SizeForm(zobrazitPozadie, zobrazitNastaveniaPoSpusteni);
            fontyTabule = new FontyTabule();
            //pismaPrezentacie = new FontyTabule();
            currentDirectory = Directory.GetCurrentDirectory();

            rozlozenieTabule = new RozlozenieTabule();
            farebnaSchema = new FarbyTabule();
            farbyPrezHostia = new FarbyPrezentacie();
            farbyPrezDomaci = new FarbyPrezentacie();
            LoadSettings();

            // Zobrazenie formulara so zakladnymi nastaveniami tabule
            if (zobrazitNastaveniaPoSpusteni)
            {
                formular.OnSettingsConfirmation += Formular_OnSettingsConfirmation;
                formular.ShowDialog();
                koniec = formular.Vypnut();
            }
            else koniec = false;
            if (!koniec)
            {
                this.rozhodcovia = new List<Rozhodca>();
                // Cierne pozadie obrazovky (prekrytie nevyuzitej plochy)
                if (zobrazitPozadie)
                {
                    formularPozadia = new PozadieForm();
                    formularPozadia.Show();
                }
                NastavVelkosti();
                // Vytvorenie casovaca
                casovac = new System.Timers.Timer();
                casovac.Interval = 100;
                casovac.Elapsed += Casovac_Elapsed;

                InicializujDatabazu();

                sw = new Stopwatch();

                // Pociatocne nastavenia
                hraBezi = false;
                casPodrobneLabel.Text = "00:00.000";
                polcasLabel.Text = dlzkaPolcasu.ToString();

                if (povolitPrerusenieHry)
                    prerusenieLabel.Text = "áno";
                else
                    prerusenieLabel.Text = "nie";

                // Nastavenie zobrazovacej svetelnej tabule

                NastavTabulu();
                LoadFarebnaSchemaConfig();
                LoadRozlozenieConfig();
            }
        }

        #region PRACA_S_CASOM

        private void SpracujCas()
        {
            try
            {
                if (casLabel.InvokeRequired)
                {
                    SetTextCallback d = new SetTextCallback(SpracujCas);
                    Invoke(d, new object[] { });
                }
                else
                {
                    int m = ((polcas - 1) * dlzkaPolcasu) + sw.Elapsed.Minutes;
                    int s = sw.Elapsed.Seconds;
                    int milis = sw.Elapsed.Milliseconds;

                    if (s != 0)
                    {
                        if (((polcas == 1) || (polcas == 2)) && !nadstavenyCas)
                        {
                            VykresliCas(m, s);
                        }
                        else
                        {
                            VykresliCas(m, s);
                        }
                    }
                    else
                    {

                        if ((m < polcas * dlzkaPolcasu) && !nadstavenyCas)
                        {
                            // Zakladne plynutie polcasu
                            VykresliCas(m, s);
                        }
                        else if ((m == polcas * dlzkaPolcasu) && !nadstavenyCas)
                        {
                            // Koniec polcasu
                            if (polcas == 1)
                            {
                                if (pocetNadstavenychMinut == 0)
                                {
                                    minutaPolcasu = 0;
                                    casLabel.Text = m + ".'";
                                    formularTabule.SetCas(m.ToString("D2") + ":" + s.ToString("D2"));
                                    milis = 0;
                                    ZastavCas();
                                    polcasButton.Text = 2 + ". polčas\nSTART";
                                }
                                else
                                {
                                    nadstavenyCas = true;
                                    casLabel.Text = m.ToString("D2") + ":" + s.ToString("D2");
                                    formularTabule.SetCas(m.ToString("D2") + ":" + s.ToString("D2"));
                                    formularTabule.SetPolcas(1, pocetNadstavenychMinut, true);
                                    casPodrobneLabel.ForeColor = Color.OrangeRed;
                                    casLabel.ForeColor = Color.OrangeRed;
                                }
                            }
                            else
                            {
                                if (pocetNadstavenychMinut == 0)
                                {
                                    casLabel.Text = m + ".'";
                                    formularTabule.SetCas(m.ToString("D2") + ":" + s.ToString("D2"));
                                    ZastavCas();
                                    polcas = 0;
                                    minutaPolcasu = 0;
                                    formularTabule.SetPolcas(1, 0, false);
                                    polcasButton.Text = 1 + ". polčas\nSTART";
                                }
                                else
                                {
                                    nadstavenyCas = true;
                                    casLabel.Text = m.ToString("D2") + ":" + s.ToString("D2");
                                    formularTabule.SetCas(m.ToString("D2") + ":" + s.ToString("D2"));
                                    formularTabule.SetPolcas(1, pocetNadstavenychMinut, true);
                                    casPodrobneLabel.ForeColor = Color.OrangeRed;
                                    casLabel.ForeColor = Color.OrangeRed;
                                }
                            }
                        }
                        else if ((m == ((polcas) * dlzkaPolcasu) + pocetNadstavenychMinut))
                        {
                            nadstavenyCas = false;
                            minutaPolcasu = 0;
                            // Koniec nadstaveneho casu

                            casLabel.Text = m.ToString("D2") + ":" + s.ToString("D2");
                            formularTabule.SetCas(m.ToString("D2") + ":" + s.ToString("D2"));
                            milis = 0;
                            ZastavCas();
                            if (polcas == 1)
                            {
                                zapas.NadstavenyCas1 = pocetNadstavenychMinut;
                                polcasButton.Text = 2 + ". polčas\nSTART";
                            }
                            else
                            {
                                zapas.NadstavenyCas2 = pocetNadstavenychMinut;
                                polcas = 0;
                                polcasButton.Text = 1 + ". polčas\nSTART";
                            }
                            nadstavenaMinuta = 0;
                            pocetNadstavenychMinut = 0;
                        }
                        else
                        {
                            nadstavenaMinuta = m - (polcas * dlzkaPolcasu) + 1;
                            // Plynutie nadstaveneho casu
                            VykresliCas(m, s);
                        }
                    }
                    if (!nadstavenyCas)
                    {
                        minutaPolcasu = m - (polcas - 1) * dlzkaPolcasu;
                        aktualnaMinuta = m;
                        aktualnaSekunda = s;
                    }

                    casPodrobneLabel.Text = m.ToString("D2")
                        + ":" + s.ToString("D2")
                        + "." + milis.ToString("D3");
                }
            }
            catch
            {

            }
        }

        private void VykresliCas(int min, int sek)
        {
            casLabel.Text = min.ToString("D2") + ":" + sek.ToString("D2");
            formularTabule.SetCas(casLabel.Text);
        }

        private void SpustiCas(bool pouzitReset)
        {
            hraBezi = true;
            casovac.Start();
            if (pouzitReset)
                sw.Reset();
            sw.Start();
        }

        private void Casovac_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            SpracujCas();
        }

        private void Reset()
        {
            if (hraBezi)
                ZastavCas();

            casLabel.Text = "00:00";
            casPodrobneLabel.Text = "00:00.000";
            skoreDomaci = 0;
            skoreHostia = 0;
            skoreDomaciLabel.Text = "0";
            skoreHostiaLabel.Text = "0";
            polcasButton.Text = "1. " + "polčas\nSTART";
            polcas = 0;
            pocetNadstavenychMinut = 0;
            poPreruseni = false;
            aktualnaMinuta = 0;
            aktualnaSekunda = 0;
            zapas = null;

            formularTabule.Reset();
        }

        private void CasButton_Click(object sender, EventArgs e)
        {
            NadstavCasForm formular = new NadstavCasForm(pocetNadstavenychMinut, polcas, zapas);
            formular.OnNadstavenyCasConfirmed += Formular_OnNadstavenyCasConfirmed;
            formular.Show();
        }

        private void Formular_OnNadstavenyCasConfirmed(int hodnota)
        {
            if (!nadstavenyCas)
            {
                pocetNadstavenychMinut = hodnota;
            }
            else
            {
                if (hodnota > pocetNadstavenychMinut)
                {
                    pocetNadstavenychMinut = hodnota;
                    formularTabule.SetPolcas(polcas, pocetNadstavenychMinut, nadstavenyCas);
                }
                else
                    MessageBox.Show("Počas nadstaveného času ho možno len predĺžiť!", nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void PolcasButton_Click(object sender, EventArgs e)
        {
            if (!hraBezi)
            {
                // Spustenie casu
                if (!poPreruseni)
                {
                    // Ak to nie je po preruseni, spusta sa novy polcas
                    if (polcas == 0)
                    {
                        zapas = new Zapas();
                        zapas.Domaci = timDomaci;
                        zapas.Hostia = timHostia;
                        zapas.DatumZapasu = DateTime.Now;
                        zapas.DlzkaPolcasu = dlzkaPolcasu;
                        zapas.NazovDomaci = nazovDomaci;
                        zapas.NazovHostia = nazovHostia;
                        zapas.Rozhodcovia = rozhodcovia;

                        casLabel.ForeColor = Color.Lime;
                        casPodrobneLabel.ForeColor = Color.Lime;
                    }

                    polcas++;
                    casPodrobneLabel.Text = ((polcas - 1) * dlzkaPolcasu).ToString("D2") + ":00.000";
                    aktualnaMinuta = ((polcas - 1) * dlzkaPolcasu);
                    aktualnaSekunda = 0;
                    formularTabule.SetPolcas(polcas, 0, nadstavenyCas);
                    casLabel.Text = polcas == 2 ? (((polcas - 1) * dlzkaPolcasu) + 1) + ":00" : "00:00";
                    formularTabule.SetCas(casLabel.Text);

                    SpustiCas(true);

                    if (povolitPrerusenieHry)
                        polcasButton.Text = polcasButton.Text.Replace("START", "STOP");
                    else
                        polcasButton.Text = polcas + ". polčas";
                }
                else
                {
                    // Spustenie casu po preruseni hry
                    SpustiCas(false);
                    polcasButton.Text = polcasButton.Text.Replace("START", "STOP");
                }
                poPreruseni = false;
            }
            else
            {
                if (povolitPrerusenieHry)
                {
                    poPreruseni = true;
                    polcasButton.Text = polcasButton.Text.Replace("STOP", "START");
                    ZastavCas();
                }
            }
        }

        private void ZastavCas()
        {
            hraBezi = false;
            casovac.Stop();
            sw.Stop();
        }
        #endregion PRACA_S_CASOM

        #region NACITANIE_ULOZENIE_NASTAVENI
        private void LoadAnimConfig()
        {
            TextReader textReader = null;
            try
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(AnimacnaKonfiguracia));
                textReader = new StreamReader(currentDirectory + animacieSubor);
                animaciaGolov = (AnimacnaKonfiguracia)deserializer.Deserialize(textReader);
            }
            catch (Exception ex)
            {
                animaciaGolov = new AnimacnaKonfiguracia();
                MessageBox.Show(ex.Message, nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (textReader != null)
                    textReader.Close();
            }
        }

        private void LoadRozlozenieConfig()
        {
            TextReader textReader = null;
            bool uspech = true;
            try
            {
                string nazovSuboru = currentDirectory + rozlozenieSubor;
                XmlSerializer deserializer = new XmlSerializer(typeof(RozlozenieTabule));
                textReader = new StreamReader(nazovSuboru);
                rozlozenieTabule = (RozlozenieTabule)deserializer.Deserialize(textReader);
            }
            catch
            {
                uspech = false;
            }
            finally
            {
                if (textReader != null)
                    textReader.Close();

                if (uspech)
                    formularTabule.SetLayout(rozlozenieTabule);
            }
        }

        private void LoadFarebnaSchemaConfig()
        {
            TextReader textReader = null;
            bool uspech = true;

            try
            {
                string nazovSuboru = currentDirectory + farebnaSchemaSubor;
                XmlSerializer deserializer = new XmlSerializer(typeof(FarbyTabule));
                textReader = new StreamReader(nazovSuboru);
                farebnaSchema = (FarbyTabule)deserializer.Deserialize(textReader);
            }
            catch
            {
                uspech = false;
            }
            finally
            {
                if (textReader != null)
                    textReader.Close();

                if (uspech)
                    AplikujFarebnuSchemu(farebnaSchema);
            }
            TextReader textReader1 = null;
            TextReader textReader2 = null;

            try
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(Setup.FarbyPrezentacie));
                textReader1 = new StreamReader(currentDirectory + "\\Files\\DomaciPrezentacia.xml");
                farbyPrezDomaci = (FarbyPrezentacie)deserializer.Deserialize(textReader1);
            }
            catch
            {
                farbyPrezDomaci = new FarbyPrezentacie();
            }
            finally
            {
                if (textReader1 != null)
                    textReader1.Close();
            }

            try
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(Setup.FarbyPrezentacie));
                textReader2 = new StreamReader(currentDirectory + "\\Files\\HostiaPrezentacia.xml");
                farbyPrezHostia = (FarbyPrezentacie)deserializer.Deserialize(textReader2);
            }
            catch
            {
                farbyPrezHostia = new FarbyPrezentacie();
            }
            finally
            {
                if (textReader2 != null)
                    textReader2.Close();
            }

        }
        private void LoadSettings()
        {
            FileStream fs = null;
            BinaryReader br = null;

            try
            {
                fs = new FileStream(currentDirectory + konfiguracnySubor, FileMode.OpenOrCreate);
                br = new BinaryReader(fs);

                zobrazitPozadie = br.ReadBoolean();
                zobrazitNastaveniaPoSpusteni = br.ReadBoolean();
                sirkaTabule = br.ReadInt32();
                vyskaTabule = br.ReadInt32();
                dlzkaPolcasu = br.ReadInt32();
                povolitPrerusenieHry = br.ReadBoolean();
                odstranovatDiakritiku = br.ReadBoolean();
                animacnyCas = br.ReadInt32();
                fontyTabule.NazvyFont = br.ReadString();
                fontyTabule.PolcasFont = br.ReadString();
                fontyTabule.SkoreFont = br.ReadString();
                fontyTabule.CasFont = br.ReadString();
                fontyTabule.NazvyPrezentaciaFont = br.ReadString();
                fontyTabule.PodnadpisPrezentaciaFont = br.ReadString();
                fontyTabule.UdajePrezentaciaFont = br.ReadString();
                fontyTabule.CisloMenoPrezentaciaFont = br.ReadString();
                fontyTabule.StriedaniaFont = br.ReadString();
                zobrazitNahradnikov = br.ReadBoolean();
                animaciaZltaKarta = br.ReadString();
                animaciaCervenaKarta = br.ReadString();
            }
            catch (Exception ex)
            {
                setDefaults();
                MessageBox.Show(ex.Message, nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (br != null)
                    br.Close();
                if (fs != null)
                    fs.Close();
            }

            LoadAnimConfig();
        }

        private void SaveSettings()
        {
            FileStream fs = null;
            BinaryWriter bw = null;

            try
            {
                fs = new FileStream(currentDirectory + konfiguracnySubor, FileMode.Create);
                bw = new BinaryWriter(fs);

                bw.Write(zobrazitPozadie);
                bw.Write(zobrazitNastaveniaPoSpusteni);
                bw.Write(sirkaTabule);
                bw.Write(vyskaTabule);
                bw.Write(dlzkaPolcasu);
                bw.Write(povolitPrerusenieHry);
                bw.Write(odstranovatDiakritiku);
                bw.Write(animacnyCas);
                bw.Write(fontyTabule.NazvyFont);
                bw.Write(fontyTabule.PolcasFont);
                bw.Write(fontyTabule.SkoreFont);
                bw.Write(fontyTabule.CasFont);
                bw.Write(fontyTabule.NazvyPrezentaciaFont);
                bw.Write(fontyTabule.PodnadpisPrezentaciaFont);
                bw.Write(fontyTabule.UdajePrezentaciaFont);
                bw.Write(fontyTabule.CisloMenoPrezentaciaFont);
                bw.Write(fontyTabule.StriedaniaFont);
                bw.Write(zobrazitNahradnikov);
                bw.Write(animaciaZltaKarta);
                bw.Write(animaciaCervenaKarta);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (bw != null)
                    bw.Close();
                if (fs != null)
                    fs.Close();
            }

            SaveAnimConfig();
            SaveRozlozenieConfig();
            SaveFarebnaSchemaConfig();
        }

        private void SaveAnimConfig()
        {
            TextWriter textWriter = null;
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(AnimacnaKonfiguracia));
                textWriter = new StreamWriter(currentDirectory + animacieSubor);
                serializer.Serialize(textWriter, animaciaGolov);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (textWriter != null)
                    textWriter.Close();
            }
        }

        private void SaveRozlozenieConfig()
        {
            TextWriter textWriter = null;
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(RozlozenieTabule));
                textWriter = new StreamWriter(currentDirectory + rozlozenieSubor);
                serializer.Serialize(textWriter, rozlozenieTabule);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (textWriter != null)
                    textWriter.Close();
            }
        }

        private void SaveFarebnaSchemaConfig()
        {
            TextWriter textWriter = null;
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(FarbyTabule));
                textWriter = new StreamWriter(currentDirectory + farebnaSchemaSubor);
                serializer.Serialize(textWriter, farebnaSchema);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (textWriter != null)
                    textWriter.Close();
            }
            TextWriter textWriter1 = null;
            TextWriter textWriter2 = null;

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(FarbyPrezentacie));
                textWriter1 = new StreamWriter(currentDirectory + "\\Files\\DomaciPrezentacia.xml");
                serializer.Serialize(textWriter1, farbyPrezDomaci);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FutbalApp", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (textWriter1 != null)
                    textWriter1.Close();
            }

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Setup.FarbyPrezentacie));
                textWriter2 = new StreamWriter(currentDirectory + "\\Files\\HostiaPrezentacia.xml");
                serializer.Serialize(textWriter2, farbyPrezHostia);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FutbalApp", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (textWriter2 != null)
                    textWriter2.Close();
            }
        }

        #endregion NACITANIE_ULOZENIE_NASTAVENI

        #region PREDSTAVENIE
        private void PredstavButton_Click(object sender, EventArgs e)
        {
            PredstavenieSettingsForm psf = new PredstavenieSettingsForm(timDomaci, timHostia, fontyTabule, zobrazitNahradnikov, farbyPrezDomaci, farbyPrezHostia);
            psf.OnVyberTimuNaPrezentaciu += Psf_OnVyberTimuNaPrezentaciu;
            psf.OnZastaveniePrezentacie += Psf_OnZastaveniePrezentacie;
            psf.OnNastaveniaConfirmed += Psf_OnNastaveniaConfirmed;
            psf.Show();
        }


        private void Psf_OnNastaveniaConfirmed(bool n)
        {
            zobrazitNahradnikov = n;
        }

        private void Psf_OnZastaveniePrezentacie()
        {
            zastavPrezentaciu();
        }

        private void Psf_OnVyberTimuNaPrezentaciu(FutbalovyTim tim, FarbyPrezentacie fp)
        {
            PrezentaciaForm pf = new PrezentaciaForm(currentDirectory, sirkaTabule, animacnyCas, tim, fp, fontyTabule, zobrazitNahradnikov);
            pf.FormClosing += Pf_FormClosing;
            prezentacia = pf;
            pf.Show();
        }

        private void Pf_FormClosing(object sender, FormClosingEventArgs e)
        {
            prezentacia = null;
        }
        #endregion PREDSTAVENIE

        #region SETUP
        private void SetupButton_Click(object sender, EventArgs e)
        {
            sf = new SetupForm(zobrazitPozadie, zobrazitNastaveniaPoSpusteni, sirkaTabule, vyskaTabule, dlzkaPolcasu, povolitPrerusenieHry, odstranovatDiakritiku,
               domaciLabel.Text, hostiaLabel.Text,
               timDomaci, timHostia, currentDirectory, animacnyCas, farebnaSchema,
               animaciaGolov, animaciaZltaKarta, animaciaCervenaKarta, rozhodcovia,
               dbtimy, dbhraci, dbrozhodcovia, dbzapasy, fontyTabule, rozlozenieTabule);
            sf.OnAnimacieKarietConfirmed += Sf_OnAnimacieKarietConfirmed;
            sf.OnDataConfirmed += Sf_OnDataConfirmed;
            sf.OnReset += Sf_OnReset;
            sf.OnZhasnut += Sf_OnZhasnut;
            sf.OnRozsvietit += Sf_OnRozsvietit;
            sf.OnNazvyLogaConfirmed += Sf_OnNazvyLogaConfirmed;
            sf.OnTimySelected += Sf_OnTimySelected;
            sf.OnObnovaFarieb += Sf_OnObnovaFarieb;
            sf.OnZmenaFarieb += () => AplikujFarebnuSchemu(farebnaSchema); ;
            sf.OnZmenaFontov += () => formularTabule.SetFonty(fontyTabule); ;
            sf.OnZmenaRozlozenia += () => formularTabule.SetLayout(rozlozenieTabule); ;
            sf.Show();
        }

        private void Sf_OnAnimacieKarietConfirmed(string s1, string s2)
        {
            animaciaZltaKarta = s1;
            animaciaCervenaKarta = s2;
        }

        private void AplikujFarebnuSchemu(FarbyTabule fs)
        {
            casLabel.ForeColor = fs.GetCasFarba();
            casPodrobneLabel.ForeColor = fs.GetCasFarba();

            domaciLabel.ForeColor = fs.GetNadpisDomFarba();
            hostiaLabel.ForeColor = fs.GetNadpisHosFarba();
            skoreDomaciLabel.ForeColor = fs.GetSkoreFarba();
            skoreHostiaLabel.ForeColor = fs.GetSkoreFarba();

            formularTabule.SetFarby(fs);
        }

        private void Sf_OnObnovaFarieb()
        {
            setDefaultColors();
            formularTabule.SetDefaultFarby();
            farebnaSchema = dajSchemu();
        }

        private void Sf_OnTimySelected(FutbalovyTim domTim, FutbalovyTim hosTim)
        {
            if ((polcas == 0))
            {
                timDomaci = domTim;
                timHostia = hosTim;
            }
            else
                if ((timDomaci != domTim) || (timHostia != hosTim))
                MessageBox.Show("Tímy nie je možné meniť po začiatku zápasu!", nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ZobrazLoga(Image domaci, Image hostia)
        {
            try
            {
                logoDomaci.Image = domaci;
                formularTabule.ZobrazLogoDomaci(domaci);
            }
            catch
            {
                logoDomaci.Image = null;
                formularTabule.ZobrazLogoDomaci(null);
            }

            try
            {
                logoHostia.Image = hostia;
                formularTabule.ZobrazLogoHostia(hostia);
            }
            catch
            {
                logoHostia.Image = null;
                formularTabule.ZobrazLogoHostia(null);
            }
        }

        private void Sf_OnNazvyLogaConfirmed(string domNazov, Image domLogo, string hosNazov, Image hosLogo)
        {
            if ((polcas == 0) || (polcas == 4))
            {
                if (domNazov.Equals(string.Empty))
                    domaciLabel.Text = "DOMÁCI";
                else
                    domaciLabel.Text = domNazov;

                if (hosNazov.Equals(string.Empty))
                    hostiaLabel.Text = "HOSTIA";
                else
                    hostiaLabel.Text = hosNazov;

                formularTabule.ZobrazNazvy(domaciLabel.Text, hostiaLabel.Text);
                ZobrazLoga(domLogo, hosLogo);
            }
            nazovDomaci = domaciLabel.Text;
            nazovHostia = hostiaLabel.Text;
        }

        private void Sf_OnRozsvietit()
        {
            Rozsvietit();
        }

        private void Sf_OnZhasnut()
        {
            Zhasnut();
        }

        private void Sf_OnReset()
        {
            Reset();
        }

        private void Sf_OnDataConfirmed(bool zobrazovatPozadie, bool zobrazNastavenia, int sirka, int vyska, int cas, bool prerusenie, bool diakritika, int animacia)
        {
            if (cas == 0)
                MessageBox.Show("Dĺžka polčasu nemôže byť nulová!", nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (dlzkaPolcasu != cas)
                {
                    if ((polcas == 2))
                        MessageBox.Show("Dĺžku druhého polčasu nie je možné skracovať, musí byť rovnaká ako v prvom polčase!", nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        if (dlzkaPolcasu < cas)
                        {
                            dlzkaPolcasu = cas;
                            polcasLabel.Text = dlzkaPolcasu.ToString();
                        }
                        else
                        {
                            if (aktualnaMinuta >= cas)
                                MessageBox.Show("Dĺžku polčasu nie je možné skrátiť, aktuálny čas je za hranicou, ktorú chcete nastaviť!", nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            else
                            {
                                dlzkaPolcasu = cas;
                                polcasLabel.Text = dlzkaPolcasu.ToString();
                            }
                        }
                    }
                }
            }

            if (povolitPrerusenieHry != prerusenie)
            {
                povolitPrerusenieHry = prerusenie;
                if (povolitPrerusenieHry)
                    prerusenieLabel.Text = "áno";
                else
                    prerusenieLabel.Text = "nie";
            }

            odstranovatDiakritiku = diakritika;
            animacnyCas = animacia;

            if ((sirka != sirkaTabule) || (vyska != vyskaTabule))
                MessageBox.Show("Zmena veľkosti zobrazovacej plochy sa prejaví až po reštarte aplikácie!", nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Warning);

            zobrazitPozadie = zobrazovatPozadie;
            if (zobrazitPozadie)
            {
                if (formularPozadia == null)
                    formularPozadia = new PozadieForm();

                formularPozadia.Show();
                this.BringToFront();
                formularTabule.BringToFront();
            }
            else
            {
                if (formularPozadia != null)
                    formularPozadia.Close();
                formularPozadia = null;
            }

            zobrazitNastaveniaPoSpusteni = zobrazNastavenia;

            sirkaTabule = sirka;
            vyskaTabule = vyska;
            SaveAnimConfig();
            SaveFarebnaSchemaConfig();
            SaveRozlozenieConfig();
        }

        #endregion SETUP

        #region ZMENA_CASU
        private void zmenitCasButton_Click(object sender, EventArgs e)
        {
            if (nadstavenyCas)
            {
                MessageBox.Show("Nemožno meniť čas počas nadstaveného času", nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                ZmenaCasuForm zcf = new ZmenaCasuForm(aktualnaMinuta, aktualnaSekunda, dlzkaPolcasu);
                zcf.OnZmenaCasu += Zcf_OnZmenaCasu;
                zcf.Show();
            }

        }

        private void Zcf_OnZmenaCasu(int novaMin, int novaSek)
        {
            if ((polcas == 0))
                MessageBox.Show("Zmena času sa môže prejaviť len počas zápasu!", nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                polcas = 1 + (novaMin / dlzkaPolcasu);

                aktualnaMinuta = novaMin;
                aktualnaSekunda = novaSek;

                if ((aktualnaMinuta == dlzkaPolcasu) && (aktualnaSekunda == 0))
                {
                    casLabel.Text = dlzkaPolcasu + ".'";
                    casPodrobneLabel.Text = dlzkaPolcasu.ToString("D2") + ":00.000";
                    formularTabule.SetCas(casLabel.Text);
                    ZastavCas();
                    aktualnaMinuta = 0;
                    formularTabule.SetPolcas(1, 0, false);
                    polcas = 1;
                    polcasButton.Text = "2. " + "polčas\nSTART";
                }
                else if ((aktualnaMinuta == 2 * dlzkaPolcasu) && (aktualnaSekunda == 0))
                {
                    casLabel.Text = (2 * dlzkaPolcasu) + ".'";
                    casPodrobneLabel.Text = (2 * dlzkaPolcasu).ToString("D2") + ":00.000";
                    formularTabule.SetCas(casLabel.Text);
                    ZastavCas();
                    aktualnaMinuta = 0;
                    polcas = 0;
                    minutaPolcasu = 0;
                    nadstavenyCas = false;
                    formularTabule.SetPolcas(1, 0, false);
                    polcas = 0;
                    polcasButton.Text = "1. " + "polčas\nSTART";
                }
                else
                {
                    casLabel.Text = (aktualnaMinuta + 1) + ".'";
                    casPodrobneLabel.Text = (aktualnaMinuta).ToString("D2") + ":" + aktualnaSekunda.ToString("D2") + ".000";
                    formularTabule.SetCas(casLabel.Text);
                    formularTabule.SetPolcas(polcas, 0, false);
                    polcasButton.Text = polcasButton.Text.Replace("1", polcas.ToString());
                    polcasButton.Text = polcasButton.Text.Replace("2", polcas.ToString());

                    if (hraBezi)
                        sw.Restart();
                    else
                        sw.Reset();

                    if (aktualnaMinuta >= dlzkaPolcasu)
                        aktualnaMinuta -= dlzkaPolcasu;
                }
            }
        }

        #endregion ZMENA_CASU

        #region INE
        private void InicializujDatabazu()
        {
            try
            {
                pripojenie = new Pripojenie();
                dbhraci = new DBHraci(pripojenie);
                dbrozhodcovia = new DBRozhodcovia(pripojenie, dbhraci);
                dbtimy = new DBTimy(pripojenie, dbhraci);
                dbzapasy = new DBZapasy(pripojenie, dbhraci, dbrozhodcovia, dbtimy);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void NastavVelkosti()
        {
            // Nastavenie velkosti zobrazovacej plochy - zvacsenie na pozadovanu velkost
            Screen primarnyDisplej = Screen.AllScreens.ElementAtOrDefault(0);
            int sirkaObr = primarnyDisplej.Bounds.Width;
            pomer = (float)sirkaObr / (float)this.Width;
            Scale(new SizeF(pomer, pomer));

            // Nastavenie velkosti fontu pre jednotlive labely
            LayoutSetter.NastavVelkostiElementov(this, pomer);
            this.WindowState = FormWindowState.Maximized;
        }
        private void NastavTabulu()
        {
            formularTabule = new TabulaForm(sirkaTabule);
            formularTabule.SetLayout(rozlozenieTabule);
            formularTabule.Show();
            formularTabule.SetFonty(fontyTabule);
        }

        private void Formular_OnSettingsConfirmation(bool zobrazovatPozadie, bool zobrazNastavenia, int sirka, int vyska)
        {
            zobrazitPozadie = zobrazovatPozadie;
            zobrazitNastaveniaPoSpusteni = zobrazNastavenia;
            sirkaTabule = sirka;
            vyskaTabule = vyska;
        }
        private void Zhasnut()
        {
            formularTabule.Hide();
            this.Focus();
        }

        private void Rozsvietit()
        {
            formularTabule.Show();
            this.Focus();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Naozaj chcete ukončiť beh aplikácie?", nazovProgramuString, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }

        private void RiadiaciForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                zastavPrezentaciu();
        }

        private void zastavPrezentaciu()
        {
            if (prezentacia != null)
                prezentacia.Close();
        }

        private FarbyTabule dajSchemu()
        {
            FarbyTabule schema = new FarbyTabule();
            schema.SetNadpisDomFarba(domaciLabel.ForeColor);
            schema.SetNadpisHosFarba(hostiaLabel.ForeColor);
            schema.SetCasFarba(casLabel.ForeColor);
            schema.SetSkoreFarba(skoreDomaciLabel.ForeColor);
            schema.SetPolcasFarba(casLabel.ForeColor);
            return schema;
        }

        public void setDefaultColors()
        {

            casLabel.ForeColor = Color.Lime;

            domaciLabel.ForeColor = Color.Aqua;
            hostiaLabel.ForeColor = Color.Aqua;
            skoreDomaciLabel.ForeColor = Color.Red;
            skoreHostiaLabel.ForeColor = Color.Red;
        }

        private void setDefaults()
        {
            zobrazitPozadie = false;
            zobrazitNastaveniaPoSpusteni = true;
            povolitPrerusenieHry = false;
            sirkaTabule = 1280;
            vyskaTabule = 720;
            dlzkaPolcasu = 45;
            odstranovatDiakritiku = true;
            animacnyCas = 3;
            zobrazitNahradnikov = true;
        }

        private void RiadiaciForm_Load(object sender, EventArgs e)
        {
            if (koniec)
                this.Close();
        }

        private void RiadiaciForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                SaveSettings();

                if (formularPozadia != null)
                    formularPozadia.Close();

                if (formularTabule != null)
                    formularTabule.Close();
            }
            catch
            {

            }
        }
        #endregion INE

        #region UDALOSTI
        private void DomZltaKartaButton_Click(object sender, EventArgs e)
        {
            if ((polcas == 0))
            {
                MessageBox.Show("Žltú kartu možno udeliť len počas zápasu!", nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Karta karta = new Karta();
            karta.Minuta = minutaPolcasu;
            karta.Polcas = polcas;
            karta.NadstavenaMinuta = nadstavenaMinuta;
            karta.AktualnyCas = DateTime.Now;

            ZltaKartaSettingsForm zksf = new ZltaKartaSettingsForm(timDomaci, zapas, true, karta);
            zksf.OnHracZltaKartaSelected += Zksf_OnHracZltaKartaSelected;
            zksf.OnUdalostPridana += OnUdalostPridana;
            zksf.Show();
        }

        private void Zksf_OnHracZltaKartaSelected(Hrac hrac)
        {
            bool ok = false;
            if (hrac != null)
            {
                if (!hrac.ZltaKarta)
                {
                    hrac.ZltaKarta = true;
                    for (int i = 0; i < timDomaci.ZoznamHracov.Count; i++)
                    {
                        if (timDomaci.ZoznamHracov[i].IdHrac == hrac.IdHrac)
                        {
                            timDomaci.ZoznamHracov[i].ZltaKarta = true;
                            ok = true;
                            break;
                        }
                    }
                    if (!ok)
                    {
                        for (int i = 0; i < timHostia.ZoznamHracov.Count; i++)
                        {
                            if (timHostia.ZoznamHracov[i].IdHrac == hrac.IdHrac)
                            {
                                timHostia.ZoznamHracov[i].ZltaKarta = true;
                            }
                        }
                    }

                    ZltaKartaForm zkf = new ZltaKartaForm(currentDirectory, sirkaTabule, animacnyCas, hrac, fontyTabule, animaciaZltaKarta);
                    zkf.Show();
                }
                else
                {
                    hrac.CervenaKarta = true;

                    for (int i = 0; i < timDomaci.ZoznamHracov.Count; i++)
                    {
                        if (timDomaci.ZoznamHracov[i].IdHrac == hrac.IdHrac)
                        {
                            timDomaci.ZoznamHracov[i].ZltaKarta = false;
                            timDomaci.ZoznamHracov[i].CervenaKarta = true;
                            //timDomaci.ZoznamHracov[i].HraAktualnyZapas = false;
                            ok = true;
                            break;
                        }
                    }
                    if (!ok)
                    {
                        for (int i = 0; i < timHostia.ZoznamHracov.Count; i++)
                        {
                            if (timHostia.ZoznamHracov[i].IdHrac == hrac.IdHrac)
                            {
                                timDomaci.ZoznamHracov[i].ZltaKarta = false;
                                timHostia.ZoznamHracov[i].CervenaKarta = true;
                                //timDomaci.ZoznamHracov[i].HraAktualnyZapas = false;
                            }
                        }
                    }
                    CervenaKartaForm ckf = new CervenaKartaForm(currentDirectory, sirkaTabule, animacnyCas, hrac, true, fontyTabule, animaciaZltaKarta, animaciaCervenaKarta);
                    ckf.Show();
                }
            }
            else
            {
                ZltaKartaForm zkf = new ZltaKartaForm(currentDirectory, sirkaTabule, animacnyCas, hrac, fontyTabule, animaciaZltaKarta);
                zkf.Show();
            }
        }

        private void Gsf_OnGoalValueConfirmed(bool domPriznak, int hodnota)
        {
            if (domPriznak)
                SetSkoreDomaci(hodnota);
            else
                SetSkoreHostia(hodnota);
        }

        private void Gsf_OnGoalSettingsConfirmed(Hrac h, bool priznak, int novyStav)
        {
            if (priznak)
            {
                if (novyStav <= skoreDomaci)
                    SetSkoreDomaci(novyStav);
                else
                {
                    if ((polcas == 0))
                        MessageBox.Show("Góly možno pridávať len počas zápasu!", nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        SetSkoreDomaci(novyStav);
                        if ((animaciaGolov.ZobrazitAnimaciuDomaci) || (animaciaGolov.AnimacieDomaci.Count > 0))
                        {
                            GolForm gf = new GolForm(currentDirectory, sirkaTabule, animacnyCas, h, fontyTabule, farbyPrezDomaci, animaciaGolov, true);
                            gf.Show();
                        }
                    }
                }
            }
            else
            {
                if (novyStav <= skoreHostia)
                    SetSkoreHostia(novyStav);
                else
                {
                    if ((polcas == 0))
                        MessageBox.Show("Góly možno pridávať len počas zápasu!", nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        SetSkoreHostia(novyStav);
                        if ((animaciaGolov.ZobrazitAnimaciuHostia) || (animaciaGolov.AnimacieHostia.Count > 0))
                        {
                            GolForm gf = new GolForm(currentDirectory, sirkaTabule, animacnyCas, h, fontyTabule, farbyPrezHostia, animaciaGolov, false);
                            gf.Show();
                        }
                    }
                }
            }
        }

        private void HosZmenaStavuButton_Click(object sender, EventArgs e)
        {
            if ((polcas == 0))
            {
                MessageBox.Show("Možné pridať len počas hry", nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Gol gol = new Gol();
            gol.Minuta = minutaPolcasu;
            gol.Polcas = polcas;
            gol.NadstavenaMinuta = nadstavenaMinuta;
            gol.AktualnyCas = DateTime.Now;

            GolSettingsForm gsf = new GolSettingsForm(timHostia, false, skoreHostia, zapas, gol);
            gsf.OnGoalSettingsConfirmed += Gsf_OnGoalSettingsConfirmed;
            gsf.OnGoalValueConfirmed += Gsf_OnGoalValueConfirmed;
            gsf.OnUdalostPridana += OnUdalostPridana;
            gsf.Show();
        }

        private void SetSkoreDomaci(int novaHodnota)
        {
            skoreDomaci = novaHodnota;
            skoreDomaciLabel.Text = skoreDomaci.ToString();
            zapas.DomaciSkore = skoreDomaci;
            formularTabule.SetSkoreDomaci(skoreDomaci);
        }

        private void SetSkoreHostia(int novaHodnota)
        {
            skoreHostia = novaHodnota;
            zapas.HostiaSkore = skoreHostia;
            skoreHostiaLabel.Text = skoreHostia.ToString();
            formularTabule.SetSkoreHostia(skoreHostia);
        }

        private void DomStriedanieButton_Click(object sender, EventArgs e)
        {
            if ((polcas == 0))
            {
                MessageBox.Show("Striedanie je možné len počas hry!", nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Striedanie striedanie = new Striedanie();
            striedanie.Minuta = minutaPolcasu;
            striedanie.Polcas = polcas;
            striedanie.NadstavenaMinuta = nadstavenaMinuta;
            striedanie.AktualnyCas = DateTime.Now;

            StriedanieSettingsForm ssf = new StriedanieSettingsForm(timDomaci, true, zapas, striedanie);
            ssf.OnStriedanieHraciSelected += Ssf_OnStriedanieHraciSelected;
            ssf.OnUdalostPridana += OnUdalostPridana;
            ssf.Show();
        }

        private void Ssf_OnStriedanieHraciSelected(string nazovTimu, Hrac odchadzajuci, Hrac nastupujuci, bool jeDomaciTim)
        {
            if ((odchadzajuci != null) && (nastupujuci != null))
            {
                odchadzajuci.HraAktualnyZapas = false;
                odchadzajuci.Nahradnik = false;

                nastupujuci.HraAktualnyZapas = true;
                nastupujuci.Nahradnik = false;
            }
            
            FarbyPrezentacie farbicky = jeDomaciTim ? farbyPrezDomaci : farbyPrezHostia;

            StriedanieForm sf = new StriedanieForm(currentDirectory, sirkaTabule, animacnyCas, nazovTimu, odchadzajuci, nastupujuci, farbicky, fontyTabule);
            sf.Show();
        }

        private void HosStriedanieButton_Click(object sender, EventArgs e)
        {
            if (polcas == 0)
            {
                MessageBox.Show("Striedanie je možné len počas hry!", nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Striedanie striedanie = new Striedanie();
            striedanie.Minuta = minutaPolcasu;
            striedanie.Polcas = polcas;
            striedanie.NadstavenaMinuta = nadstavenaMinuta;
            striedanie.AktualnyCas = DateTime.Now;

            StriedanieSettingsForm ssf = new StriedanieSettingsForm(timHostia, false, zapas, striedanie);
            ssf.OnStriedanieHraciSelected += Ssf_OnStriedanieHraciSelected;
            ssf.OnUdalostPridana += OnUdalostPridana;
            ssf.Show();
        }
        private void HosZltaKartaButton_Click(object sender, EventArgs e)
        {
            if (polcas == 0)
            {
                MessageBox.Show("Žltú kartu možno udeliť len počas zápasu!", nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Karta karta = new Karta();
            karta.Minuta = minutaPolcasu;
            karta.Polcas = polcas;
            karta.NadstavenaMinuta = nadstavenaMinuta;
            karta.AktualnyCas = DateTime.Now;

            ZltaKartaSettingsForm zksf = new ZltaKartaSettingsForm(timHostia, zapas, false, karta);
            zksf.OnHracZltaKartaSelected += Zksf_OnHracZltaKartaSelected;
            zksf.OnUdalostPridana += OnUdalostPridana;
            zksf.Show();
        }

        private void DomCervenaKartaButton_Click(object sender, EventArgs e)
        {
            if (polcas == 0)
            {
                MessageBox.Show("Červenú kartu možno udeliť len počas zápasu!", nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Karta karta = new Karta();
            karta.Minuta = minutaPolcasu;
            karta.Polcas = polcas;
            karta.NadstavenaMinuta = nadstavenaMinuta;
            karta.AktualnyCas = DateTime.Now;

            CervenaKartaSettingsForm cksf = new CervenaKartaSettingsForm(timDomaci, zapas, true, karta);
            cksf.OnHracCervenaKartaSelected += Cksf_OnHracCervenaKartaSelected;
            cksf.OnUdalostPridana += OnUdalostPridana;
            cksf.Show();
        }

        private void Cksf_OnHracCervenaKartaSelected(Hrac hrac)
        {
            if (hrac != null)
                hrac.CervenaKarta = true;

            CervenaKartaForm ckf = new CervenaKartaForm(currentDirectory, sirkaTabule, animacnyCas, hrac, false, fontyTabule, animaciaZltaKarta, animaciaCervenaKarta);
            ckf.Show();
        }

        private void HosCervenaKartaButton_Click(object sender, EventArgs e)
        {
            if ((polcas == 0))
            {
                MessageBox.Show("Červenú kartu možno udeliť len počas zápasu!", nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Karta karta = new Karta();
            karta.Minuta = minutaPolcasu;
            karta.Polcas = polcas;
            karta.NadstavenaMinuta = nadstavenaMinuta;
            karta.AktualnyCas = DateTime.Now;

            CervenaKartaSettingsForm cksf = new CervenaKartaSettingsForm(timHostia, zapas, false, karta);
            cksf.OnHracCervenaKartaSelected += Cksf_OnHracCervenaKartaSelected;
            cksf.OnUdalostPridana += OnUdalostPridana;
            cksf.Show();
        }

        private void DomZmenaStavuButton_Click(object sender, EventArgs e)
        {
            if ((polcas == 0))
            {
                MessageBox.Show("Možné pridať len počas hry", nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Gol gol = new Gol();
            gol.Minuta = minutaPolcasu;
            gol.Polcas = polcas;
            gol.NadstavenaMinuta = nadstavenaMinuta;
            gol.AktualnyCas = DateTime.Now;

            GolSettingsForm gsf = new GolSettingsForm(timDomaci, true, skoreDomaci, zapas, gol);
            gsf.OnGoalSettingsConfirmed += Gsf_OnGoalSettingsConfirmed;
            gsf.OnGoalValueConfirmed += Gsf_OnGoalValueConfirmed;
            gsf.OnUdalostPridana += OnUdalostPridana;
            gsf.Show();
        }

        private void domKartyLabel_Click(object sender, EventArgs e)
        {
            if (timDomaci != null)
            {
                HraciKartyForm hkf = new HraciKartyForm(timDomaci);
                hkf.ShowDialog();
            }
        }

        private void hosKartyLabel_Click(object sender, EventArgs e)
        {
            if (timHostia != null)
            {
                HraciKartyForm hkf = new HraciKartyForm(timHostia);
                hkf.ShowDialog();
            }
        }

        private void domKopyButton_Click(object sender, EventArgs e)
        {
            if ((polcas == 0))
            {
                MessageBox.Show("Možné pridať len počas hry", nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Kop kop = new Kop();
            kop.Minuta = minutaPolcasu;
            kop.Polcas = polcas;
            kop.NadstavenaMinuta = nadstavenaMinuta;
            kop.AktualnyCas = DateTime.Now;

            KopySettingsForm kps = new KopySettingsForm(timDomaci, zapas, true, kop);
            kps.OnUdalostPridana += OnUdalostPridana;
            kps.ShowDialog();
        }

        private void domOffsideButton_Click(object sender, EventArgs e)
        {
            if ((polcas == 0))
            {
                MessageBox.Show("Možné pridať len počas hry", nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Offside offside = new Offside();
            offside.Minuta = minutaPolcasu;
            offside.Polcas = polcas;
            offside.NadstavenaMinuta = nadstavenaMinuta;
            offside.AktualnyCas = DateTime.Now;

            OffsideSettingsForm osf = new OffsideSettingsForm(timDomaci, zapas, true, offside);
            osf.OnUdalostPridana += OnUdalostPridana;
            osf.ShowDialog();
        }

        private void domOutButton_Click(object sender, EventArgs e)
        {
            if ((polcas == 0))
            {
                MessageBox.Show("Možné pridať len počas hry", nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Out _out = new Out();
            _out.Minuta = minutaPolcasu;
            _out.Polcas = polcas;
            _out.NadstavenaMinuta = nadstavenaMinuta;
            _out.AktualnyCas = DateTime.Now;

            OutSettingsForm osf = new OutSettingsForm(timDomaci, zapas, true, _out);
            osf.OnUdalostPridana += OnUdalostPridana;
            osf.ShowDialog();
        }

        private void hosOutButton_Click(object sender, EventArgs e)
        {
            if ((polcas == 0))
            {
                MessageBox.Show("Možné pridať len počas hry", nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Out _out = new Out();
            _out.Minuta = minutaPolcasu;
            _out.Polcas = polcas;
            _out.NadstavenaMinuta = nadstavenaMinuta;
            _out.AktualnyCas = DateTime.Now;

            OutSettingsForm osf = new OutSettingsForm(timHostia, zapas, false, _out);
            osf.OnUdalostPridana += OnUdalostPridana;
            osf.ShowDialog();
        }

        private void hosKopyButton_Click(object sender, EventArgs e)
        {
            if ((polcas == 0))
            {
                MessageBox.Show("Možné pridať len počas hry", nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Kop kop = new Kop();
            kop.Minuta = minutaPolcasu;
            kop.Polcas = polcas;
            kop.NadstavenaMinuta = nadstavenaMinuta;
            kop.AktualnyCas = DateTime.Now;

            KopySettingsForm ksf = new KopySettingsForm(timHostia, zapas, false, kop);
            ksf.OnUdalostPridana += OnUdalostPridana;
            ksf.ShowDialog();
        }

        private void hosOffsideButton_Click(object sender, EventArgs e)
        {
            if ((polcas == 0))
            {
                MessageBox.Show("Možné pridať len počas hry", nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Offside offside = new Offside();
            offside.Minuta = minutaPolcasu;
            offside.Polcas = polcas;
            offside.NadstavenaMinuta = nadstavenaMinuta;
            offside.AktualnyCas = DateTime.Now;

            OffsideSettingsForm osf = new OffsideSettingsForm(timHostia, zapas, false, offside);
            osf.OnUdalostPridana += OnUdalostPridana;
            osf.ShowDialog();
        }

        private void OnUdalostPridana(string text)
        {
            UdalostPopupForm upf = new UdalostPopupForm(text, pomer);
            upf.StartPosition = FormStartPosition.Manual;
            upf.Size = new Size(polcasButton.Width, polcasButton.Height * 2 / 7);
            upf.Location = new Point(polcasButton.Left, polcasButton.Top - upf.Height + 10);
            upf.Show();
        }

        private void udalostiButton_Click(object sender, EventArgs e)
        {
            if (zapas != null)
            {
                UdalostiForm uf = new UdalostiForm(zapas, false, dbzapasy);
                uf.Show();
            }
        }

        #endregion UDALOSTI

        #region REKLAMA

        private void reklamaButton_Click(object sender, EventArgs e)
        {
            string video = string.Empty;
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Multiselect = false;
                ofd.Filter = "(*.mp4) |*.mp4|(*.avi) |*.avi|(*.mov) |*.mov|(*.mkv) |*.mkv";
                ofd.FilterIndex = 1;
                ofd.RestoreDirectory = true;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    video = ofd.FileName;
                }
            }
            catch
            {
                video = string.Empty;
            }

            if (video != string.Empty)
            {
                rf = new ReklamaForm(sirkaTabule, video);
                rf.OnReklamaKoniec += rf_OnReklamaKoniec;
                rf.Show();
                this.reklamaButton.Visible = false;
                this.reklamaButton.Enabled = false;
                this.vypnutVideoButton.Enabled = true;
                this.vypnutVideoButton.Visible = true;
            }
        }

        private void rf_OnReklamaKoniec()
        {
            this.reklamaButton.Visible = true;
            this.reklamaButton.Enabled = true;
            this.vypnutVideoButton.Enabled = false;
            this.vypnutVideoButton.Visible = false;
        }

        private void vypnutVideoButton_Click(object sender, EventArgs e)
        {
            try
            {
                rf.VypnutVideo();
                this.reklamaButton.Visible = true;
                this.reklamaButton.Enabled = true;
                this.vypnutVideoButton.Enabled = false;
                this.vypnutVideoButton.Visible = false;
            }
            catch
            {
                MessageBox.Show("Nepodarilo sa vypnúť video!", nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion REKLAMA

        #region FARBENIE_BUTTONOV

        private void domZltaKartaButton_Enter(object sender, EventArgs e)
        {
            domZltaKartaButton.BackColor = Color.Yellow;
        }

        private void domZltaKartaButton_Leave(object sender, EventArgs e)
        {
            domZltaKartaButton.BackColor = Color.FromArgb(255, 255, 128);
        }

        private void hosZltaKartaButton_Enter(object sender, EventArgs e)
        {
            hosZltaKartaButton.BackColor = Color.Yellow;
        }

        private void hosZltaKartaButton_Leave(object sender, EventArgs e)
        {
            hosZltaKartaButton.BackColor = Color.FromArgb(255, 255, 128);
        }

        private void domCervenaKartaButton_MouseEnter(object sender, EventArgs e)
        {
            domCervenaKartaButton.BackColor = Color.Red;
        }

        private void domCervenaKartaButton_MouseLeave(object sender, EventArgs e)
        {
            domCervenaKartaButton.BackColor = Color.FromArgb(255, 128, 128);
        }

        private void hosCervenaKartaButton_MouseEnter(object sender, EventArgs e)
        {
            hosCervenaKartaButton.BackColor = Color.Red;
        }

        private void hosCervenaKartaButton_MouseLeave(object sender, EventArgs e)
        {
            hosCervenaKartaButton.BackColor = Color.FromArgb(255, 128, 128);
        }

        private void domZmenaStavuButton_MouseEnter(object sender, EventArgs e)
        {
            domZmenaStavuButton.BackColor = Color.Green;
        }

        private void domZmenaStavuButton_MouseLeave(object sender, EventArgs e)
        {
            domZmenaStavuButton.BackColor = Color.FromArgb(128, 255, 128);
        }

        private void hosZmenaStavuButton_MouseEnter(object sender, EventArgs e)
        {
            hosZmenaStavuButton.BackColor = Color.Green;
        }

        private void hosZmenaStavuButton_MouseLeave(object sender, EventArgs e)
        {
            hosZmenaStavuButton.BackColor = Color.FromArgb(128, 255, 128);
        }

        private void setupButton_MouseEnter(object sender, EventArgs e)
        {
            setupButton.BackColor = Color.FromArgb(0, 192, 192);
        }

        private void setupButton_MouseLeave(object sender, EventArgs e)
        {
            setupButton.BackColor = Color.FromArgb(128, 255, 255);
        }

        private void predstavButton_MouseEnter(object sender, EventArgs e)
        {
            predstavButton.BackColor = Color.FromArgb(0, 192, 192);
        }

        private void predstavButton_MouseLeave(object sender, EventArgs e)
        {
            predstavButton.BackColor = Color.FromArgb(128, 255, 255);
        }

        private void closeButton_MouseEnter(object sender, EventArgs e)
        {
            closeButton.BackColor = Color.FromArgb(255, 192, 192);
        }

        private void closeButton_MouseLeave(object sender, EventArgs e)
        {
            closeButton.BackColor = Color.FromArgb(192, 255, 255);
        }

        private void polcasButton_MouseEnter(object sender, EventArgs e)
        {
            polcasButton.ForeColor = Color.Yellow;
        }

        private void polcasButton_MouseLeave(object sender, EventArgs e)
        {
            polcasButton.ForeColor = Color.Lime;
        }

        private void zmenitCasButton_MouseEnter(object sender, EventArgs e)
        {
            zmenitCasButton.ForeColor = Color.Yellow;
        }

        private void zmenitCasButton_MouseLeave(object sender, EventArgs e)
        {
            zmenitCasButton.ForeColor = Color.Lime;
        }

        private void casButton_MouseEnter(object sender, EventArgs e)
        {
            casButton.BackColor = Color.FromArgb(0, 192, 192);
        }

        private void casButton_MouseLeave(object sender, EventArgs e)
        {
            casButton.BackColor = Color.FromArgb(128, 255, 255);
        }

        private void domStriedanieButton_MouseEnter(object sender, EventArgs e)
        {
            mouseEnter(domStriedanieButton);
        }

        private void domStriedanieButton_MouseLeave(object sender, EventArgs e)
        {
            mouseLeave(domStriedanieButton);
        }

        private void domOffsideButton_MouseEnter(object sender, EventArgs e)
        {
            mouseEnter(domOffsideButton);
        }

        private void domOffsideButton_MouseLeave(object sender, EventArgs e)
        {
            mouseLeave(domOffsideButton);
        }

        private void domOutButton_MouseEnter(object sender, EventArgs e)
        {
            mouseEnter(domOutButton);
        }

        private void domOutButton_MouseLeave(object sender, EventArgs e)
        {
            mouseLeave(domOutButton);
        }

        private void hosKopyButton_MouseEnter(object sender, EventArgs e)
        {
            mouseEnter(hosKopyButton);
        }

        private void hosKopyButton_MouseLeave(object sender, EventArgs e)
        {
            mouseLeave(hosKopyButton);
        }

        private void hosOffsideButton_MouseEnter(object sender, EventArgs e)
        {
            mouseEnter(hosOffsideButton);
        }

        private void hosOffsideButton_MouseLeave(object sender, EventArgs e)
        {
            mouseLeave(hosOffsideButton);
        }

        private void hosOutButton_MouseEnter(object sender, EventArgs e)
        {
            mouseEnter(hosOutButton);
        }

        private void hosOutButton_MouseLeave(object sender, EventArgs e)
        {
            mouseLeave(hosOutButton);
        }
        private void hosStriedanieButton_MouseEnter(object sender, EventArgs e)
        {
            mouseEnter(hosStriedanieButton);
        }

        private void hosStriedanieButton_MouseLeave(object sender, EventArgs e)
        {
            mouseLeave(hosStriedanieButton);
        }


        private void domKopyButton_MouseEnter(object sender, EventArgs e)
        {
            mouseEnter(domKopyButton);
        }

        private void domKopyButton_MouseLeave(object sender, EventArgs e)
        {
            mouseLeave(domKopyButton);
        }

        private void udalostiButton_MouseEnter(object sender, EventArgs e)
        {
            udalostiButton.BackColor = Color.FromArgb(0, 192, 192);
        }

        private void udalostiButton_MouseLeave(object sender, EventArgs e)
        {
            udalostiButton.BackColor = Color.FromArgb(128, 255, 255);
        }

        private void vypnutVideoButton_MouseEnter(object sender, EventArgs e)
        {
            vypnutVideoButton.BackColor = Color.Red;
        }

        private void vypnutVideoButton_MouseLeave(object sender, EventArgs e)
        {
            vypnutVideoButton.BackColor = Color.FromArgb(255, 128, 128);
        }

        private void reklamaButton_MouseEnter(object sender, EventArgs e)
        {
            reklamaButton.BackColor = Color.FromArgb(0, 192, 192);
        }

        private void reklamaButton_MouseLeave(object sender, EventArgs e)
        {
            reklamaButton.BackColor = Color.FromArgb(128, 255, 255);
        }

        private void mouseEnter(Button b)
        {
            b.BackColor = Color.White;
            b.ForeColor = Color.MidnightBlue;
            b.FlatAppearance.BorderColor = Color.MidnightBlue;
        }

        private void mouseLeave(Button b)
        {
            b.BackColor = Color.MidnightBlue;
            b.ForeColor = Color.White;
            b.FlatAppearance.BorderColor = Color.White;
        }
        #endregion FARBENIE_BUTTONOV
    }

}
