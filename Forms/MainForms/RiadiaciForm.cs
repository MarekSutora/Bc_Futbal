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

namespace LGR_Futbal
{
    public delegate void SetTextCallback();
    public delegate void UdalostPridanaHandler(string text);

    public partial class RiadiaciForm : Form
    {
        #region Konstanty

        private const string nazovProgramuString = "LGR Futbal";
        private string konfiguracnySubor = "\\Files\\Config.bin";
        private string priebehSubor = "\\Files\\Priebeh.xml";
        private string animacieSubor = "\\Files\\Gify\\Settings.xml";

        #endregion

        #region Atributy
        private int indexJazyka = 0;
        private bool zobrazitPozadie = false;
        private bool zobrazitNastaveniaPoSpusteni = true;
        private bool povolitPrerusenieHry = false;
        private int sirkaTabule;
        private int vyskaTabule;
        private int dlzkaPolcasu;
        private int pocetNadstavenychMinut = 0;
        private int nadstavenaMinuta = 0;
        private int polcas = 0;
        private bool hraBezi = false;
        private bool poPreruseni = false;
        private bool odstranovatDiakritiku = true;
        private bool nadstavenyCas = false;
        private string logoDomaciFile = string.Empty;
        private string logoHostiaFile = string.Empty;
        private string rozlozenieCesta = string.Empty;
        private string nazovDomaci = string.Empty;
        private string nazovHostia = string.Empty;
        private Stopwatch sw = null;
        private System.Timers.Timer casovac;
        private FutbalovyTim timDomaci = null;
        private FutbalovyTim timHostia = null;
        private string currentDirectory = null;
        private int skoreDomaci = 0;
        private int skoreHostia = 0;
        private int animacnyCas = 3;
        private Zapas zapas = null;
        private int odohraneMinuty;
        private int minutaPolcasu;
        private string defaultColorScheme = string.Empty;
        private FontyTabule pisma;
        private FontyTabule pismaPrezentacie;
        private float pomer;
        private bool koniec = true;
        private bool zobrazitNahradnikov = true;
        private AnimacnaKonfiguracia animaciaGolov = null;
        private List<Rozhodca> rozhodcovia = null;
        // Farby
        private Color casColor;
        private Color polcasColor;
        private Color predlzenieColor;
        private Color koniecColor = Color.Red;
        // Formulare
        private PozadieForm formularPozadia = null;
        private TabulaForm formularTabule = null;
        private PrezentaciaForm prezentacia = null;
        private SetupForm sf = null;
        private ReklamaForm rf = null;
        private RozlozenieTabule RozlozenieTabule = null;
        // Aktualny hraci cas
        private int aktualnaMinuta;
        private int aktualnaSekunda;
        private int aktMin;
        private int aktSek;
        // Animacie kariet
        private string animaciaZltaKarta = string.Empty;
        private string animaciaCervenaKarta = string.Empty;
        #endregion

        #region Konstruktor a metody

        public RiadiaciForm()
        {
            InitializeComponent();
            setDefaultColors();
            pisma = new FontyTabule();
            pismaPrezentacie = new FontyTabule();
            currentDirectory = Directory.GetCurrentDirectory();
            konfiguracnySubor = currentDirectory + "\\" + konfiguracnySubor;
            animacieSubor = currentDirectory + "\\" + animacieSubor;
            priebehSubor = currentDirectory + "\\" + priebehSubor;
            RozlozenieTabule = new RozlozenieTabule();

            RozlozenieForm rf = new RozlozenieForm(null, RozlozenieTabule, sirkaTabule, vyskaTabule);
            rf.NativneRozlozenie();
            LoadSettings();

            // Vytvorenie casovaca
            casovac = new System.Timers.Timer();
            casovac.Interval = 100;
            casovac.Elapsed += Casovac_Elapsed;

            // Nacitanie systemovej konfiguracie zo suboru

            // Zobrazenie formulara so zakladnymi nastaveniami tabule
            if (zobrazitNastaveniaPoSpusteni)
            {
                SizeForm formular = new SizeForm(zobrazitPozadie, zobrazitNastaveniaPoSpusteni, indexJazyka);
                formular.OnSettingsConfirmation += Formular_OnSettingsConfirmation;
                formular.ShowDialog();
                koniec = formular.Vypnut();
            }

            if (!koniec)
            {
                nastavJazyk(indexJazyka);

                // Cierne pozadie obrazovky (prekrytie nevyuzitej plochy)
                if (zobrazitPozadie)
                {
                    formularPozadia = new PozadieForm();
                    formularPozadia.Show();
                }

                // Nastavenie velkosti zobrazovacej plochy - zvacsenie na pozadovanu velkost
                var primaryDisplay = Screen.AllScreens.ElementAtOrDefault(0);
                int sirkaObr = primaryDisplay.Bounds.Width;
                pomer = (float)sirkaObr / (float)this.Width;
                Scale(new SizeF(pomer, pomer));
                this.rozhodcovia = new List<Rozhodca>();
                // Nastavenie velkosti fontu pre jednotlive labely
                Label l;
                Button b;
                foreach (object item in Controls)
                {
                    if (item.GetType() == typeof(Label))
                    {
                        l = (Label)item;
                        l.Font = new Font(l.Font.Name, (float)Math.Floor(l.Font.Size * pomer));
                    }

                    if (item.GetType() == typeof(Button))
                    {
                        b = (Button)item;
                        b.Font = new Font(b.Font.Name, (float)Math.Floor(b.Font.Size * pomer));
                    }
                }
                this.WindowState = FormWindowState.Maximized;


                sw = new Stopwatch();

                // Pociatocne nastavenia
                hraBezi = false;
                odohraneMinuty = 0;

                casPodrobneLabel.Text = "00:00.000";
                polcasLabel.Text = dlzkaPolcasu.ToString();
                nadCasLabel.Text = pocetNadstavenychMinut.ToString();

                if (povolitPrerusenieHry)
                    prerusenieLabel.Text = Translate(8);
                else
                    prerusenieLabel.Text = Translate(9);

                // Vytvorenie zobrazovacej svetelnej tabule
                formularTabule = new TabulaForm(indexJazyka, sirkaTabule, vyskaTabule, RozlozenieTabule);
                formularTabule.prelozTabuluDoJazyka(indexJazyka);
                formularTabule.Show();
                formularTabule.NastavFonty(pisma);

            }
        }
        private string preloz(string povodnyText)
        {
            string text = povodnyText;

            if (indexJazyka == 0) // SK
            {
                text = text.Replace("DOMÁCÍ", "DOMÁCI");
                text = text.Replace("HOSTÉ", "HOSTIA");
                text = text.Replace("ŽLUTÁ", "ŽLTÁ");
                text = text.Replace("ZMĚNA", "ZMENA");
                text = text.Replace("STŘÍDÁNÍ", "STRIEDANIE");
                text = text.Replace("Povolit přerušení hry:", "Povoliť prerušenie hry:");
                text = text.Replace("Délka poločasu", "Dĺžka polčasu");
                text = text.Replace("Nastavený", "Nadstavený");
                text = text.Replace("UKONČIŤ", "UKONČIT");
                text = text.Replace("Změnit čas", "Zmeniť čas");
                text = text.Replace("PREZENTACE", "PREDSTAV");
                text = text.Replace("HRÁČŮ", "HRÁČOV");
                text = text.Replace("poločas", "polčas");
            }
            else if (indexJazyka == 1) // CZ
            {
                text = text.Replace("DOMÁCI", "DOMÁCÍ");
                text = text.Replace("HOSTIA", "HOSTÉ");
                text = text.Replace("ŽLTÁ", "ŽLUTÁ");
                text = text.Replace("ZMENA", "ZMĚNA");
                text = text.Replace("STRIEDANIE", "STŘÍDÁNÍ");
                text = text.Replace("Povoliť prerušenie hry:", "Povolit přerušení hry:");
                text = text.Replace("Dĺžka polčasu", "Délka poločasu");
                text = text.Replace("Nadstavený", "Nastavený");
                text = text.Replace("UKONČIŤ", "UKONČIT");
                text = text.Replace("Zmeniť čas", "Změnit čas");
                text = text.Replace("PREDSTAV", "PREZENTACE");
                text = text.Replace("HRÁČOV", "HRÁČŮ");
                text = text.Replace("polčas", "poločas");
            }
            return text;
        }

        private void nastavJazyk(int cisloJazyka)
        {
            indexJazyka = cisloJazyka;
            Settings.Default.Jazyk = indexJazyka;
            Settings.Default.Save();

            if (formularTabule != null)
                formularTabule.prelozTabuluDoJazyka(indexJazyka);

            domaciLabel.Text = preloz(domaciLabel.Text);
            hostiaLabel.Text = preloz(hostiaLabel.Text);
            domZltaKartaButton.Text = preloz(domZltaKartaButton.Text);
            hosZltaKartaButton.Text = preloz(hosZltaKartaButton.Text);
            domZmenaStavuButton.Text = preloz(domZmenaStavuButton.Text);
            hosZmenaStavuButton.Text = preloz(hosZmenaStavuButton.Text);
            domStriedanieButton.Text = preloz(domStriedanieButton.Text);
            hosStriedanieButton.Text = preloz(hosStriedanieButton.Text);
            infoLabel3.Text = preloz(infoLabel3.Text);
            infoLabel2.Text = preloz(infoLabel2.Text);
            infoLabel.Text = preloz(infoLabel.Text);
            casButton.Text = preloz(casButton.Text);
            closeButton.Text = preloz(closeButton.Text);
            zmenitCasButton.Text = preloz(zmenitCasButton.Text);
            predstavButton.Text = preloz(predstavButton.Text);
            polcasButton.Text = preloz(polcasButton.Text);

            this.Focus();
        }

        private FarebnaSchema dajSchemu()
        {
            FarebnaSchema schema = new FarebnaSchema();
            schema.setNadpisDomFarba(domaciLabel.ForeColor);
            schema.setNadpisHosFarba(hostiaLabel.ForeColor);
            schema.setKoniecFarba(koniecColor);
            schema.setCasFarba(casLabel.ForeColor);
            schema.setSkoreFarba(skoreDomaciLabel.ForeColor);
            schema.setPredlzenieFarba(predlzenieColor);
            schema.setPolcasFarba(polcasColor);
            return schema;
        }

        public void setDefaultColors()
        {
            casColor = Color.Lime;
            polcasColor = Color.Lime;
            predlzenieColor = Color.Yellow;

            domaciLabel.ForeColor = Color.Aqua;
            hostiaLabel.ForeColor = Color.Aqua;
            skoreDomaciLabel.ForeColor = Color.Red;
            skoreHostiaLabel.ForeColor = Color.Red;
        }

        private void setDefaults()
        {
            indexJazyka = 0;
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
                    int m = aktMin + odohraneMinuty + ((polcas - 1) * dlzkaPolcasu) + sw.Elapsed.Minutes;
                    int s = aktSek + sw.Elapsed.Seconds;
                    int milis = sw.Elapsed.Milliseconds;

                    if (s == 60)
                    {
                        s = 0;
                        m++;
                        aktMin++;
                        sw.Restart();
                    }

                    if (s != 0)
                    {
                        if (((polcas == 1) || (polcas == 2)) && !nadstavenyCas)
                        {
                            VykresliCas(m, s, milis, true);
                        }
                        else
                        {
                            VykresliCas(m, s, milis, false);
                        }
                    }
                    else
                    {
                        aktSek = 0;

                        if ((m < polcas * dlzkaPolcasu) && !nadstavenyCas)
                        {
                            // Zakladne plynutie polcasu
                            VykresliCas(m, s, milis, true);
                        }
                        else if ((m == polcas * dlzkaPolcasu) && !nadstavenyCas)
                        {
                            // Koniec polcasu
                            if (polcas == 1)
                            {
                                if (pocetNadstavenychMinut == 0)
                                {
                                    minutaPolcasu = 0;
                                    aktMin = 0;
                                    odohraneMinuty = 0;
                                    casLabel.Text = m + ".'";
                                    formularTabule.SetCas(m.ToString("D2") + ":" + s.ToString("D2"), true);
                                    milis = 0;
                                    ZastavCas();
                                    polcasButton.Text = 2 + ". " + Translate(2) + "\nSTART";
                                }
                                else
                                {
                                    nadstavenyCas = true;
                                    casLabel.Text = m.ToString("D2") + ":" + s.ToString("D2");
                                    formularTabule.SetCas(m.ToString("D2") + ":" + s.ToString("D2"), false);
                                    odohraneMinuty = 0;
                                    aktMin = 0;
                                    formularTabule.SetPolcas(2, pocetNadstavenychMinut);
                                    casPodrobneLabel.ForeColor = predlzenieColor;
                                    casLabel.ForeColor = predlzenieColor;
                                }
                            }
                            else
                            {
                                if (pocetNadstavenychMinut == 0)
                                {
                                    casLabel.Text = m + ".'";
                                    formularTabule.SetCas(m.ToString("D2")+ ":" + s.ToString("D2"), true);
                                    milis = 0;
                                    ZastavCas();
                                    odohraneMinuty = 0;
                                    aktMin = 0;
                                    polcas = 0;
                                    minutaPolcasu = 0;
                                    formularTabule.SetPolcas(1, 0);
                                    polcasButton.Text = 1 + ". " + Translate(2) + "\nSTART";
                                }
                                else
                                {
                                    nadstavenyCas = true;
                                    casLabel.Text = m.ToString("D2") + ":" + s.ToString("D2");
                                    formularTabule.SetCas(m.ToString("D2") + ":" + s.ToString("D2"), false);
                                    odohraneMinuty = 0;
                                    aktMin = 0;
                                    formularTabule.SetPolcas(1, pocetNadstavenychMinut);
                                    casPodrobneLabel.ForeColor = predlzenieColor;
                                    casLabel.ForeColor = predlzenieColor;
                                }
                            }
                        }
                        else if ((m == ((polcas) * dlzkaPolcasu) + pocetNadstavenychMinut))
                        {
                            nadstavenyCas = false;
                            minutaPolcasu = 0;
                            // Koniec nadstaveneho casu

                            casLabel.Text = m.ToString("D2") + ":" + s.ToString("D2");
                            formularTabule.SetCas(m.ToString("D2") + ":" + s.ToString("D2"), false);
                            milis = 0;
                            ZastavCas();
                            aktMin = 0;
                            if (polcas == 1)
                            {
                                zapas.NadstavenyCas1 = pocetNadstavenychMinut;
                                polcasButton.Text = 2 + ". " + Translate(2) + "\nSTART";
                            }
                            else
                            {
                                zapas.NadstavenyCas2 = pocetNadstavenychMinut;
                                polcas = 0;
                                polcasButton.Text = 1 + ". " + Translate(2) + "\nSTART";
                            }
                            nadstavenaMinuta = 0;
                            pocetNadstavenychMinut = 0;
                        }
                        else
                        {
                            nadstavenaMinuta = m - (polcas * dlzkaPolcasu) + 1;
                            // Plynutie nadstaveneho casu
                            VykresliCas(m, s, milis, false);
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

        private void VykresliCas(int min, int sek, int milis, bool b)
        {
            //if (milis <= 500)
            //{
                casLabel.Text = min < 10 ? (min.ToString("D1") + ":" + sek.ToString("D2")) : (min.ToString("D2") + ":" + sek.ToString("D2"));
                formularTabule.SetCas(casLabel.Text, b);
        //    }
        //    else
        //    {
        //        casLabel.Text = min < 10 ? (min.ToString("D1") + " " + sek.ToString("D2")) : (min.ToString("D2") + " " + sek.ToString("D2"));
        //        formularTabule.SetCas(casLabel.Text, b);
        //    }
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

        private void Formular_OnSettingsConfirmation(bool zobrazovatPozadie, bool zobrazNastavenia, int sirka, int vyska, int jazyk)
        {
            zobrazitPozadie = zobrazovatPozadie;
            zobrazitNastaveniaPoSpusteni = zobrazNastavenia;
            sirkaTabule = sirka;
            vyskaTabule = vyska;
            indexJazyka = jazyk;
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

        private void LoadAnimConfig()
        {
            TextReader textReader = null;
            try
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(AnimacnaKonfiguracia));
                textReader = new StreamReader(animacieSubor);
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
            if (!rozlozenieCesta.Equals(string.Empty))
            {
                TextReader textReader = null;
                bool uspech = true;
                try
                {
                    string nazovSuboru = rozlozenieCesta;
                    XmlSerializer deserializer = new XmlSerializer(typeof(RozlozenieTabule));
                    textReader = new StreamReader(nazovSuboru);
                    RozlozenieTabule = (RozlozenieTabule)deserializer.Deserialize(textReader);
                }
                catch (Exception ex)
                {
                    uspech = false;
                    MessageBox.Show(ex.Message, nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (textReader != null)
                        textReader.Close();

                    if (uspech)
                        formularTabule.setLayout(RozlozenieTabule);
                }
            }          
        }

        private void LoadFarebnaSchemaConfig()
        {
            if (!defaultColorScheme.Equals(string.Empty))
            {
                TextReader textReader = null;
                bool uspech = true;
                FarebnaSchema schema = null;

                try
                {
                    string nazovSuboru = defaultColorScheme;
                    XmlSerializer deserializer = new XmlSerializer(typeof(FarebnaSchema));
                    textReader = new StreamReader(nazovSuboru);
                    schema = (FarebnaSchema)deserializer.Deserialize(textReader);
                }
                catch (Exception ex)
                {
                    uspech = false;
                    MessageBox.Show(ex.Message, nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (textReader != null)
                        textReader.Close();

                    if (uspech)
                        AplikujFarebnuSchemu(schema);
                }
            }
        }

        private void SaveAnimConfig()
        {
            TextWriter textWriter = null;

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(AnimacnaKonfiguracia));
                textWriter = new StreamWriter(animacieSubor);
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

        private void LoadSettings()
        {
            FileStream fs = null;
            BinaryReader br = null;

            try
            {
                fs = new FileStream(konfiguracnySubor, FileMode.OpenOrCreate);
                br = new BinaryReader(fs);

                indexJazyka = br.ReadInt32();
                zobrazitPozadie = br.ReadBoolean();
                zobrazitNastaveniaPoSpusteni = br.ReadBoolean();
                sirkaTabule = br.ReadInt32();
                vyskaTabule = br.ReadInt32();
                dlzkaPolcasu = br.ReadInt32();
                povolitPrerusenieHry = br.ReadBoolean();
                odstranovatDiakritiku = br.ReadBoolean();
                animacnyCas = br.ReadInt32();
                defaultColorScheme = br.ReadString();
                pisma.NazvyFont = br.ReadString();
                pisma.PolcasFont = br.ReadString();
                pisma.SkoreFont = br.ReadString();
                pisma.CasFont = br.ReadString();
                pismaPrezentacie.NazvyFont = br.ReadString();
                pismaPrezentacie.PolcasFont = br.ReadString();
                pismaPrezentacie.SkoreFont = br.ReadString();
                pismaPrezentacie.CasFont = br.ReadString();
                pisma.StriedaniaFont = br.ReadString();
                zobrazitNahradnikov = br.ReadBoolean();
                animaciaZltaKarta = br.ReadString();
                animaciaCervenaKarta = br.ReadString();
                rozlozenieCesta = br.ReadString();
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
            LoadRozlozenieConfig();
            LoadFarebnaSchemaConfig();    
        }

        private void SaveSettings()
        {
            FileStream fs = null;
            BinaryWriter bw = null;

            try
            {
                fs = new FileStream(konfiguracnySubor, FileMode.Create);
                bw = new BinaryWriter(fs);

                bw.Write(indexJazyka);
                bw.Write(zobrazitPozadie);
                bw.Write(zobrazitNastaveniaPoSpusteni);
                bw.Write(sirkaTabule);
                bw.Write(vyskaTabule);
                bw.Write(dlzkaPolcasu);
                bw.Write(povolitPrerusenieHry);
                bw.Write(odstranovatDiakritiku);
                bw.Write(animacnyCas);
                bw.Write(defaultColorScheme);
                bw.Write(pisma.NazvyFont);
                bw.Write(pisma.PolcasFont);
                bw.Write(pisma.SkoreFont);
                bw.Write(pisma.CasFont);
                bw.Write(pismaPrezentacie.NazvyFont);
                bw.Write(pismaPrezentacie.PolcasFont);
                bw.Write(pismaPrezentacie.SkoreFont);
                bw.Write(pismaPrezentacie.CasFont);
                bw.Write(pisma.StriedaniaFont);
                bw.Write(zobrazitNahradnikov);
                bw.Write(animaciaZltaKarta);
                bw.Write(animaciaCervenaKarta);
                bw.Write(rozlozenieCesta);
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
        }

        private void Reset()
        {
            if (hraBezi)
                ZastavCas();

            casLabel.Text = "00:00";
            casPodrobneLabel.Text = "00:00.000";
            casPodrobneLabel.ForeColor = casColor;
            casLabel.ForeColor = casColor;
            skoreDomaci = 0;
            skoreHostia = 0;
            skoreDomaciLabel.Text = "0";
            skoreHostiaLabel.Text = "0";
            polcasButton.Text = "1. " + Translate(2) + "\nSTART";
            polcas = 0;
            pocetNadstavenychMinut = 0;
            nadCasLabel.Text = "0";
            poPreruseni = false;
            aktualnaMinuta = 0;
            aktualnaSekunda = 0;
            aktMin = 0;
            aktSek = 0;

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
                nadCasLabel.Text = pocetNadstavenychMinut.ToString();
            }
            else
            {
                if (hodnota > pocetNadstavenychMinut)
                {
                    pocetNadstavenychMinut = hodnota;
                    nadCasLabel.Text = pocetNadstavenychMinut.ToString();
                    formularTabule.SetPolcas(polcas, pocetNadstavenychMinut);
                }
                else
                    MessageBox.Show(Translate(18), nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    }

                    polcas++;
                    odohraneMinuty = 0;
                    casPodrobneLabel.Text = ((polcas - 1) * dlzkaPolcasu).ToString("D2") + ":00.000";
                    aktualnaMinuta = ((polcas - 1) * dlzkaPolcasu);
                    aktualnaSekunda = 0;
                    aktMin = 0;
                    aktSek = 0;
                    formularTabule.SetPolcas(polcas, 0);
                    casLabel.Text = (((polcas - 1) * dlzkaPolcasu) + 1) + ".'";
                    formularTabule.SetCas(casLabel.Text, true);
                    casPodrobneLabel.ForeColor = casColor;
                    casLabel.ForeColor = casColor;

                    SpustiCas(true);

                    if (povolitPrerusenieHry)
                        polcasButton.Text = polcasButton.Text.Replace("START", "STOP");
                    else
                        polcasButton.Text = polcas + ". " + Translate(2);
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

        private void DomZltaKartaButton_Click(object sender, EventArgs e)
        {
            if ((polcas == 0) || (polcas == 4))
            {
                MessageBox.Show(Translate(17), nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ZltaKartaSettingsForm zksf = new ZltaKartaSettingsForm(timDomaci, zapas, nadstavenyCas, nadstavenaMinuta, minutaPolcasu, polcas, true);
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

                    ZltaKartaForm zkf = new ZltaKartaForm(currentDirectory, sirkaTabule, animacnyCas, hrac, pismaPrezentacie, animaciaZltaKarta);
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
                    CervenaKartaForm ckf = new CervenaKartaForm(currentDirectory, sirkaTabule, animacnyCas, hrac, true, pismaPrezentacie, animaciaZltaKarta, animaciaCervenaKarta);
                    ckf.Show();
                }
            }
            else
            {
                ZltaKartaForm zkf = new ZltaKartaForm(currentDirectory, sirkaTabule, animacnyCas, hrac, pismaPrezentacie, animaciaZltaKarta);
                zkf.Show();
            }
        }

        private void HosZltaKartaButton_Click(object sender, EventArgs e)
        {
            if ((polcas == 0) || (polcas == 4))
            {
                MessageBox.Show(Translate(17), nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ZltaKartaSettingsForm zksf = new ZltaKartaSettingsForm(timHostia, zapas, nadstavenyCas, nadstavenaMinuta, minutaPolcasu, polcas, false);
            zksf.OnHracZltaKartaSelected += Zksf_OnHracZltaKartaSelected;
            zksf.OnUdalostPridana += OnUdalostPridana;
            zksf.Show();
        }

        private void DomCervenaKartaButton_Click(object sender, EventArgs e)
        {
            if ((polcas == 0) || (polcas == 4))
            {
                MessageBox.Show(Translate(16), nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CervenaKartaSettingsForm cksf = new CervenaKartaSettingsForm(timDomaci, zapas, nadstavenyCas, nadstavenaMinuta, minutaPolcasu, polcas, true);
            cksf.OnHracZltaKartaSelected += Cksf_OnHracZltaKartaSelected;
            cksf.OnUdalostPridana += OnUdalostPridana;
            cksf.Show();
        }

        private void Cksf_OnHracZltaKartaSelected(Hrac hrac)
        {
            if (hrac != null)
                hrac.CervenaKarta = true;

            CervenaKartaForm ckf = new CervenaKartaForm(currentDirectory, sirkaTabule, animacnyCas, hrac, false, pismaPrezentacie, animaciaZltaKarta, animaciaCervenaKarta);
            ckf.Show();
        }

        private void HosCervenaKartaButton_Click(object sender, EventArgs e)
        {
            if ((polcas == 0) || (polcas == 4))
            {
                MessageBox.Show(Translate(16), nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CervenaKartaSettingsForm cksf = new CervenaKartaSettingsForm(timHostia, zapas, nadstavenyCas, nadstavenaMinuta, minutaPolcasu, polcas, false);
            cksf.OnHracZltaKartaSelected += Cksf_OnHracZltaKartaSelected;
            cksf.OnUdalostPridana += OnUdalostPridana;
            cksf.Show();
        }

        private void DomZmenaStavuButton_Click(object sender, EventArgs e)
        {
            if ((polcas == 0) || (polcas == 4))
            {
                MessageBox.Show("Možné pridať len počas hry", nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            GolSettingsForm gsf = new GolSettingsForm(timDomaci, true, skoreDomaci, zapas, nadstavenyCas, nadstavenaMinuta, minutaPolcasu, polcas);
            gsf.OnGoalSettingsConfirmed += Gsf_OnGoalSettingsConfirmed;
            gsf.OnGoalValueConfirmed += Gsf_OnGoalValueConfirmed;
            gsf.OnUdalostPridana += OnUdalostPridana;
            gsf.Show();
        }

        private void Gsf_OnGoalValueConfirmed(bool domPriznak, int hodnota)
        {
            if (domPriznak)
                setSkoreDomaci(hodnota);
            else
                setSkoreHostia(hodnota);
        }

        private void Gsf_OnGoalSettingsConfirmed(Hrac h, bool priznak, int novyStav)
        {
            if (priznak)
            {
                if (novyStav <= skoreDomaci)
                    setSkoreDomaci(novyStav);
                else
                {
                    if ((polcas == 0) || (polcas == 4))
                        MessageBox.Show(Translate(15), nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        setSkoreDomaci(novyStav);

                        PredstavenieSettingsForm psf = new PredstavenieSettingsForm(currentDirectory, null, null, pismaPrezentacie, zobrazitNahradnikov);
                        FarbyPrezentacie farbicky = psf.GetFarbyDom();

                        if ((animaciaGolov.ZobrazitPreddefinovanuAnimaciuDomaci) || (animaciaGolov.AnimacieDomaci.Count > 0))
                        {
                            GolForm gf = new GolForm(currentDirectory, sirkaTabule, animacnyCas, h, pismaPrezentacie, farbicky, animaciaGolov, true);
                            gf.Show();
                        }
                    }
                }
            }
            else
            {
                if (novyStav <= skoreHostia)
                    setSkoreHostia(novyStav);
                else
                {
                    if ((polcas == 0) || (polcas == 4))
                        MessageBox.Show(Translate(15), nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        setSkoreHostia(novyStav);

                        PredstavenieSettingsForm psf = new PredstavenieSettingsForm(currentDirectory, null, null, pismaPrezentacie, zobrazitNahradnikov);
                        Setup.FarbyPrezentacie farbicky = psf.GetFarbyHos();

                        if ((animaciaGolov.ZobrazitPreddefinovanuAnimaciuHostia) || (animaciaGolov.AnimacieHostia.Count > 0))
                        {
                            GolForm gf = new GolForm(currentDirectory, sirkaTabule, animacnyCas, h, pismaPrezentacie, farbicky, animaciaGolov, false);
                            gf.Show();
                        }
                    }
                }
            }
        }

        private void HosZmenaStavuButton_Click(object sender, EventArgs e)
        {
            if ((polcas == 0) || (polcas == 4))
            {
                MessageBox.Show("Možné pridať len počas hry", nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            GolSettingsForm gsf = new GolSettingsForm(timHostia, false, skoreHostia, zapas, nadstavenyCas, nadstavenaMinuta, minutaPolcasu, polcas);
            gsf.OnGoalSettingsConfirmed += Gsf_OnGoalSettingsConfirmed;
            gsf.OnGoalValueConfirmed += Gsf_OnGoalValueConfirmed;
            gsf.OnUdalostPridana += OnUdalostPridana;
            gsf.Show();
        }

        private void setSkoreDomaci(int novaHodnota)
        {
            skoreDomaci = novaHodnota;
            skoreDomaciLabel.Text = skoreDomaci.ToString();
            zapas.DomaciSkore = skoreDomaci;
            formularTabule.SetSkoreDomaci(skoreDomaci);
        }

        private void setSkoreHostia(int novaHodnota)
        {
            skoreHostia = novaHodnota;
            zapas.HostiaSkore = skoreHostia;
            skoreHostiaLabel.Text = skoreHostia.ToString();
            formularTabule.SetSkoreHostia(skoreHostia);
        }

        private void DomStriedanieButton_Click(object sender, EventArgs e)
        {
            if ((polcas == 0) || (polcas == 4))
            {
                MessageBox.Show(Translate(14), nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            StriedanieSettingsForm ssf = new StriedanieSettingsForm(timDomaci, domaciLabel.Text, true, zapas, nadstavenyCas, nadstavenaMinuta, minutaPolcasu, polcas);
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

            PredstavenieSettingsForm psf = new PredstavenieSettingsForm(currentDirectory, null, null, pismaPrezentacie, zobrazitNahradnikov);
            Setup.FarbyPrezentacie farbicky = psf.GetFarbyDom();

            if (!jeDomaciTim)
                farbicky = psf.GetFarbyHos();
            StriedanieForm sf = new StriedanieForm(currentDirectory, sirkaTabule, animacnyCas, nazovTimu, odchadzajuci, nastupujuci, farbicky, pismaPrezentacie, pisma);
            sf.Show();
        }

        private void HosStriedanieButton_Click(object sender, EventArgs e)
        {
            if ((polcas == 0) || (polcas == 4))
            {
                MessageBox.Show(Translate(14), nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            StriedanieSettingsForm ssf = new StriedanieSettingsForm(timHostia, hostiaLabel.Text, false, zapas, nadstavenyCas, nadstavenaMinuta, minutaPolcasu, polcas);
            ssf.OnStriedanieHraciSelected += Ssf_OnStriedanieHraciSelected;
            ssf.OnUdalostPridana += OnUdalostPridana;
            ssf.Show();
        }

        private void PredstavButton_Click(object sender, EventArgs e)
        {
            PredstavenieSettingsForm psf = new PredstavenieSettingsForm(currentDirectory, timDomaci, timHostia, pismaPrezentacie, zobrazitNahradnikov);
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

        private void Psf_OnVyberTimuNaPrezentaciu(FutbalovyTim tim, Setup.FarbyPrezentacie fp)
        {
            PrezentaciaForm pf = new PrezentaciaForm(currentDirectory, sirkaTabule, animacnyCas, tim, fp, pismaPrezentacie, zobrazitNahradnikov);
            pf.FormClosing += Pf_FormClosing;
            prezentacia = pf;
            pf.Show();
        }

        private void Pf_FormClosing(object sender, FormClosingEventArgs e)
        {
            prezentacia = null;
        }

        private void SetupButton_Click(object sender, EventArgs e)
        {
            sf = new SetupForm(indexJazyka, zobrazitPozadie, zobrazitNastaveniaPoSpusteni, sirkaTabule, vyskaTabule, dlzkaPolcasu, povolitPrerusenieHry, odstranovatDiakritiku,
               logoDomaciFile, logoHostiaFile, domaciLabel.Text, hostiaLabel.Text,
               timDomaci, timHostia, currentDirectory, animacnyCas, pisma, dajSchemu(),
               animaciaGolov, animaciaZltaKarta, animaciaCervenaKarta, rozhodcovia);
            sf.OnAnimacieKarietConfirmed += Sf_OnAnimacieKarietConfirmed;
            sf.OnLanguageSelected += Sf_OnLanguageSelected;
            sf.OnDataConfirmed += Sf_OnDataConfirmed;
            sf.OnReset += Sf_OnReset;
            sf.OnZhasnut += Sf_OnZhasnut;
            sf.OnRozsvietit += Sf_OnRozsvietit;
            sf.OnNazvyLogaConfirmed += Sf_OnNazvyLogaConfirmed;
            sf.OnTimySelected += Sf_OnTimySelected;
            sf.OnObnovaFarieb += Sf_OnObnovaFarieb;
            sf.OnColorsLoaded += Sf_OnColorsLoaded;
            sf.OnFileSelected += Sf_OnFileSelected;
            sf.OnObnovaFontov += Sf_OnObnovaFontov;
            sf.OnLayoutChanged += Sf_OnLayoutChanged;
            sf.OnFileSelectedRF += Sf_OnFileSelectedRF;
            sf.rozlozenieTabule = RozlozenieTabule;
            sf.Pisma = this.pisma;
            sf.Show();
        }

        private void Sf_OnFileSelectedRF(string cesta)
        {
            this.rozlozenieCesta = cesta;
        }

        private void Sf_OnLayoutChanged()
        {
            if (sf != null)
            {
                formularTabule.setLayout(sf.rozlozenieTabule);
                formularTabule.RozlozenieTabule = sf.rozlozenieTabule;
            }
        }

        private void Sf_OnAnimacieKarietConfirmed(string s1, string s2)
        {
            animaciaZltaKarta = s1;
            animaciaCervenaKarta = s2;
        }

        private void Sf_OnLanguageSelected(int cislo)
        {
            nastavJazyk(cislo);
        }
        private void Sf_OnObnovaFontov()
        {
            this.pisma = sf.Pisma;

            formularTabule.NastavFonty(pisma);
        }

        private void Sf_OnFileSelected(string cesta)
        {
            defaultColorScheme = cesta;
        }

        private void AplikujFarebnuSchemu(FarebnaSchema fs)
        {
            casColor = fs.CasFarba();
            polcasColor = fs.PolcasFarba();
            predlzenieColor = fs.PredlzenieFarba();
            casLabel.ForeColor = casColor;
            casPodrobneLabel.ForeColor = casColor;

            domaciLabel.ForeColor = fs.NadpisDomFarba();
            hostiaLabel.ForeColor = fs.NadpisHosFarba();
            skoreDomaciLabel.ForeColor = fs.SkoreFarba();
            skoreHostiaLabel.ForeColor = fs.SkoreFarba();
            koniecColor = fs.KoniecFarba();

            formularTabule.setColors(fs);
        }

        private void Sf_OnColorsLoaded(FarebnaSchema fs)
        {
            AplikujFarebnuSchemu(fs);
        }

        private void Sf_OnObnovaFarieb()
        {

            setDefaultColors();
            formularTabule.setDefaultColors();
        }

        private void Sf_OnTimySelected(FutbalovyTim domTim, FutbalovyTim hosTim)
        {
            if ((polcas == 0) || (polcas == 4))
            {
                timDomaci = domTim;
                timHostia = hosTim;
            }
            else
                if ((timDomaci != domTim) || (timHostia != hosTim))
                MessageBox.Show(Translate(13), nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ZobrazLoga(Image domaci, Image hostia)
        {
            try
            {
                logoDomaci.Image = domaci;
                formularTabule.ZobrazLogoDomaci(domaci);
                logoDomaciFile = string.Empty;
            }
            catch
            {
                logoDomaci.Image = null;
                formularTabule.ZobrazLogoDomaci(null);
                logoDomaciFile = string.Empty;
            }

            try
            {
                logoHostia.Image = hostia;
                formularTabule.ZobrazLogoHostia(hostia);
                logoHostiaFile = string.Empty;
            }
            catch
            {
                logoHostia.Image = null;
                formularTabule.ZobrazLogoHostia(null);
                logoHostiaFile = string.Empty;
            }
        }

        private void Sf_OnNazvyLogaConfirmed(string domNazov, Image domLogo, string hosNazov, Image hosLogo)
        {
            if ((polcas == 0) || (polcas == 4))
            {
                if (domNazov.Equals(string.Empty))
                    domaciLabel.Text = Translate(11);
                else
                    domaciLabel.Text = domNazov;

                if (hosNazov.Equals(string.Empty))
                    hostiaLabel.Text = Translate(12);
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
                MessageBox.Show(Translate(5), nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (dlzkaPolcasu != cas)
                {
                    if ((polcas == 2) || (polcas == 3))
                        MessageBox.Show(Translate(6), nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                                MessageBox.Show(Translate(7), nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    prerusenieLabel.Text = Translate(8);
                else
                    prerusenieLabel.Text = Translate(9);
            }

            odstranovatDiakritiku = diakritika;
            animacnyCas = animacia;

            if ((sirka != sirkaTabule) || (vyska != vyskaTabule))
                MessageBox.Show(Translate(10), nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Warning);

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
            if (MessageBox.Show(Translate(4), nazovProgramuString, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }

        private void zastavPrezentaciu()
        {
            if (prezentacia != null)
                prezentacia.Close();
        }

        private void RiadiaciForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                zastavPrezentaciu();
        }

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
            if ((polcas == 0) || (polcas >= 3))
                MessageBox.Show(Translate(1), nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                polcas = 1 + (novaMin / dlzkaPolcasu);
                aktMin = novaMin;
                aktSek = novaSek;
                aktualnaMinuta = aktMin;
                aktualnaSekunda = aktSek;
                odohraneMinuty = 0;

                if ((aktMin == dlzkaPolcasu) && (aktSek == 0))
                {
                    casLabel.Text = dlzkaPolcasu + ".'";
                    casPodrobneLabel.Text = dlzkaPolcasu.ToString("D2") + ":00.000";
                    formularTabule.SetCas(casLabel.Text, true);
                    ZastavCas();
                    odohraneMinuty = 0;
                    aktMin = 0;
                    formularTabule.SetPolcas(1, 0);
                    polcas = 1;
                    polcasButton.Text = "2. " + Translate(2) + "\nSTART";
                }
                else if ((aktMin == 2 * dlzkaPolcasu) && (aktSek == 0))
                {
                    casLabel.Text = (2 * dlzkaPolcasu) + ".'";
                    casPodrobneLabel.Text = (2 * dlzkaPolcasu).ToString("D2") + ":00.000";
                    formularTabule.SetCas(casLabel.Text, true);
                    ZastavCas();
                    odohraneMinuty = 0;
                    aktMin = 0;
                    formularTabule.SetPolcas(4, 0);
                    polcas = 2;
                    polcasButton.Text = "1. " + Translate(2) + "\nSTART";
                }
                else
                {
                    casLabel.Text = (aktMin + 1) + ".'";
                    casPodrobneLabel.Text = (aktMin).ToString("D2") + ":" + aktSek.ToString("D2") + ".000";
                    formularTabule.SetCas(casLabel.Text, true);
                    odohraneMinuty = 0;
                    formularTabule.SetPolcas(polcas, 0);
                    polcasButton.Text = polcasButton.Text.Replace("1", polcas.ToString());
                    polcasButton.Text = polcasButton.Text.Replace("2", polcas.ToString());

                    if (hraBezi)
                        sw.Restart();
                    else
                        sw.Reset();

                    if (aktMin >= dlzkaPolcasu)
                        aktMin -= dlzkaPolcasu;
                }
            }
        }

        private string Translate(int cisloVety)
        {
            if (Settings.Default.Jazyk == 0) // SK
            {
                switch (cisloVety)
                {
                    case 1: return "Zmena času sa môže prejaviť len počas zápasu!";
                    case 2: return "polčas";
                    case 3: return "Ukončenú hru nie je možné obnoviť!";
                    case 4: return "Naozaj chcete ukončiť beh aplikácie?";
                    case 5: return "Dĺžka polčasu nemôže byť nulová!";
                    case 6: return "Dĺžku druhého polčasu nie je možné skracovať, musí byť rovnaká ako v prvom polčase!";
                    case 7: return "Dĺžku polčasu nie je možné skrátiť, aktuálny čas je za hranicou, ktorú chcete nastaviť!";
                    case 8: return "áno";
                    case 9: return "nie";
                    case 10: return "Zmena veľkosti zobrazovacej plochy sa prejaví až po reštarte aplikácie!";
                    case 11: return "DOMÁCI";
                    case 12: return "HOSTIA";
                    case 13: return "Tímy nie je možné meniť po začiatku zápasu!";
                    case 14: return "Striedanie je možné len počas hry!";
                    case 15: return "Góly možno pridávať len počas zápasu!";
                    case 16: return "Červenú kartu možno udeliť len počas zápasu!";
                    case 17: return "Žltú kartu možno udeliť len počas zápasu!";
                    case 18: return "Počas nadstaveného času ho možno len predĺžiť!";
                }
            }
            else if (Settings.Default.Jazyk == 1) // CZ
            {
                switch (cisloVety)
                {
                    case 1: return "Změna času se může projevit pouze během zápasu!";
                    case 2: return "poločas";
                    case 3: return "Ukončenou hru nelze obnovit!";
                    case 4: return "Opravdu chcete ukončit běh aplikace?";
                    case 5: return "Délka poločasu nemůže být nulová!";
                    case 6: return "Délku druhého poločasu nelze zkracovat, musí být stejná jako v prvním poločase!";
                    case 7: return "Délku poločasu nelze zkrátit, aktuální čas je za hranicí, kterou chcete nastavit!";
                    case 8: return "ano";
                    case 9: return "ne";
                    case 10: return "Změna velikosti zobrazovací plochy se projeví až po restartu aplikace!";
                    case 11: return "DOMÁCÍ";
                    case 12: return "HOSTÉ";
                    case 13: return "Týmy nelze měnit po začátku zápasu!";
                    case 14: return "Střídání je možné jen během hry!";
                    case 15: return "Góly lze přidávat jen během zápasu!";
                    case 16: return "Červenou kartu lze udělit pouze během zápasu!";
                    case 17: return "Žlutou kartu lze udělit pouze během zápasu!";
                    case 18: return "Během nastaveného času ho lze jen prodloužit!";
                }
            }

            return string.Empty;
        }

        private void RiadiaciForm_Load(object sender, EventArgs e)
        {
            if (koniec)
                this.Close();
        }

        #endregion

        #region

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
        #endregion

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
            if ((polcas == 0) || (polcas == 4))
            {
                MessageBox.Show("Možné pridať len počas hry", nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            KopySettingsForm kps = new KopySettingsForm(timDomaci, zapas, nadstavenyCas, nadstavenaMinuta, minutaPolcasu, polcas, true);
            kps.OnUdalostPridana += OnUdalostPridana;
            kps.ShowDialog();
        }

        private void domOffsideButton_Click(object sender, EventArgs e)
        {
            if ((polcas == 0) || (polcas == 4))
            {
                MessageBox.Show("Možné pridať len počas hry", nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            OffsideSettingsForm osf = new OffsideSettingsForm(timDomaci, zapas, nadstavenyCas, nadstavenaMinuta, minutaPolcasu, polcas, true);
            osf.OnUdalostPridana += OnUdalostPridana;
            osf.ShowDialog();
        }

        private void domOutButton_Click(object sender, EventArgs e)
        {
            if ((polcas == 0) || (polcas == 4))
            {
                MessageBox.Show("Možné pridať len počas hry", nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            OutSettingsForm osf = new OutSettingsForm(timDomaci, zapas, nadstavenyCas, nadstavenaMinuta, minutaPolcasu, polcas, true);
            osf.OnUdalostPridana += OnUdalostPridana;
            osf.ShowDialog();
        }

        private void hosOutButton_Click(object sender, EventArgs e)
        {
            if ((polcas == 0) || (polcas == 4))
            {
                MessageBox.Show("Možné pridať len počas hry", nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            OutSettingsForm osf = new OutSettingsForm(timHostia, zapas, nadstavenyCas, nadstavenaMinuta, minutaPolcasu, polcas, false);
            osf.OnUdalostPridana += OnUdalostPridana;
            osf.ShowDialog();
        }

        private void hosKopyButton_Click(object sender, EventArgs e)
        {
            if ((polcas == 0) || (polcas == 4))
            {
                MessageBox.Show("Možné pridať len počas hry", nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            KopySettingsForm ksf = new KopySettingsForm(timHostia, zapas, nadstavenyCas, nadstavenaMinuta, minutaPolcasu, polcas, false);
            ksf.OnUdalostPridana += OnUdalostPridana;
            ksf.ShowDialog();
        }

        private void hosOffsideButton_Click(object sender, EventArgs e)
        {
            if ((polcas == 0) || (polcas == 4))
            {
                MessageBox.Show("Možné pridať len počas hry", nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            OffsideSettingsForm osf = new OffsideSettingsForm(timHostia, zapas, nadstavenyCas, nadstavenaMinuta, minutaPolcasu, polcas, false);
            osf.OnUdalostPridana += OnUdalostPridana;
            osf.ShowDialog();
        }

        private void hosUdalostButton_Click(object sender, EventArgs e)
        {

        }

        private void domUdalostButton_Click(object sender, EventArgs e)
        {

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
                UdalostiForm uf = new UdalostiForm(zapas, false);
                uf.Show();
            }
        }

        private void reklamaButton_Click_1(object sender, EventArgs e)
        {
            string video = string.Empty;
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Multiselect = false;
                ofd.Filter = "(*.mp4) |*.mp4";
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
                rf = new ReklamaForm(sirkaTabule, video, this);
                rf.Show();
                this.reklamaButton.Visible = false;
                this.reklamaButton.Enabled = false;
                this.vypnutVideoButton.Enabled = true;
                this.vypnutVideoButton.Visible = true;
            }
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

        public void KoniecVidea()
        {
            this.reklamaButton.Visible = true;
            this.reklamaButton.Enabled = true;
            this.vypnutVideoButton.Enabled = false;
            this.vypnutVideoButton.Visible = false;

        }
    }

}
