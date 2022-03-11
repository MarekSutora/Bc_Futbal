using LGR_Futbal.Forms;
using LGR_Futbal.Properties;
using LGR_Futbal.Model;
using LGR_Futbal.Triedy;
using System;
using System.ComponentModel;
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
    
    public partial class RiadiaciForm : Form
    {
        #region Konstanty

        private const string nazovProgramuString = "LGR Futbal";
        private const string konfiguracnySubor = "Config.bin";
        private const string databazaSubor = "Databaza\\Databaza.xml";
        private const string priebehSubor = "Databaza\\Priebeh.xml";
        private const string animacieSubor = "Databaza\\Gify\\Settings.xml";

        #endregion

        #region Atributy
        // Atributy - hodnoty a objekty
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
        private Stopwatch sw = null;
        private System.Timers.Timer casovac;
        private Databaza databaza = null;
        private FutbalovyTim timDomaci = null;
        private FutbalovyTim timHostia = null;
        private string currentDirectory = null;
        private int skoreDomaci = 0;
        private int skoreHostia = 0;
        private int animacnyCas = 3;
        private PriebehZapasu priebeh;
        private Zapas zapas = null;
        private int odohraneMinuty;
        private string defaultColorScheme = string.Empty;
        private FontyTabule pisma;
        private FontyTabule pismaPrezentacie;
        //private Font fontStriedania;
        private bool zobrazitNahradnikov = true;
        private bool zobrazitFunkcionarov = true;
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

            // Vytvorenie casovaca
            casovac = new System.Timers.Timer();
            casovac.Interval = 100;
            casovac.Elapsed += Casovac_Elapsed;

            pisma = new FontyTabule();
            pismaPrezentacie = new FontyTabule();

            // Nacitanie systemovej konfiguracie zo suboru
            LoadSettings();

            // Zobrazenie formulara so zakladnymi nastaveniami tabule
            if (zobrazitNastaveniaPoSpusteni)
            {
                SizeForm formular = new SizeForm(zobrazitPozadie, zobrazitNastaveniaPoSpusteni, sirkaTabule, vyskaTabule, indexJazyka);
                formular.OnSettingsConfirmation += Formular_OnSettingsConfirmation;
                formular.ShowDialog();
            }
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
            float pomer = (float)sirkaObr / (float)this.Width;
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

            currentDirectory = Directory.GetCurrentDirectory();

            LoadDatabase();    
            sw = new Stopwatch();

            // Pociatocne nastavenia
            hraBezi = false;
            priebeh = new PriebehZapasu();
            odohraneMinuty = 0;

            casPodrobneLabel.Text = "00:00.000";
            polcasLabel.Text = dlzkaPolcasu.ToString();
            nadCasLabel.Text = pocetNadstavenychMinut.ToString();

            if (povolitPrerusenieHry)
                prerusenieLabel.Text = Translate(8);
            else
                prerusenieLabel.Text = Translate(9);

            // Vytvorenie zobrazovacej svetelnej tabule
            formularTabule = new TabulaForm(indexJazyka, sirkaTabule, vyskaTabule);
            formularTabule.prelozTabuluDoJazyka(indexJazyka);
            formularTabule.Show();
            formularTabule.NastavFonty(pisma);


            if (!defaultColorScheme.Equals(string.Empty))
            {
                TextReader textReader = null;
                bool uspech = true;
                FarebnaSchema schema = null;

                try
                {
                    string nazovSuboru = currentDirectory + "\\" + "FarebneNastavenia\\" + Path.GetFileName(defaultColorScheme);
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

            if (!rozlozenieCesta.Equals(string.Empty))
            {
                TextReader textReader = null;
                bool uspech = true;
                RozlozenieTabule rt = null;

                try
                {
                    string nazovSuboru = currentDirectory + "\\" + "RozlozenieNastavenia\\" + Path.GetFileName(rozlozenieCesta);
                    XmlSerializer deserializer = new XmlSerializer(typeof(RozlozenieTabule));
                    textReader = new StreamReader(nazovSuboru);
                    rt = (RozlozenieTabule)deserializer.Deserialize(textReader);
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
                        formularTabule.setLayout(rt);
                }
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

        private String convertFontToString(Font f)
        {
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
            return converter.ConvertToString(f);
        }

        private Font convertStringToFont(String s)
        {
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
            return (Font)converter.ConvertFromString(s);
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
            zobrazitFunkcionarov = true;
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
                            if (milis <= 500)
                                casLabel.Text = casLabel.Text = (m + 1) + ".'";
                            else
                                casLabel.Text = casLabel.Text = (m + 1) + " '";

                            formularTabule.SetCas(casLabel.Text, true);
                        }
                        else
                        {
                            if (milis <= 500)
                                casLabel.Text = m.ToString("D2") + ":" + s.ToString("D2");
                            else
                                casLabel.Text = m.ToString("D2") + " " + s.ToString("D2");
                            formularTabule.SetCas(casLabel.Text, false);
                        }
                    }
                    else
                    {
                        aktSek = 0;

                        if ((m < polcas * dlzkaPolcasu) && !nadstavenyCas)
                        {
                            // Zakladne plynutie polcasu
                            if (milis <= 500)
                                casLabel.Text = casLabel.Text = (m + 1) + ".'";
                            else
                                casLabel.Text = casLabel.Text = (m + 1) + " '";
                            formularTabule.SetCas(casLabel.Text, true);
                        }
                        else if ((m == polcas * dlzkaPolcasu) && !nadstavenyCas)
                        {
                            // Koniec polcasu
                            if (polcas == 1)
                            {
                                if (pocetNadstavenychMinut == 0)
                                {
                                    aktMin = 0;
                                    odohraneMinuty = 0;
                                    casLabel.Text = m + ".'";
                                    formularTabule.SetCas(casLabel.Text, true);
                                    milis = 0;
                                    ZastavCas();
                                    polcasButton.Text = 2 + ". " + Translate(2) + "\nSTART";
                                }
                                else
                                {
                                    nadstavenyCas = true;
                                    casLabel.Text = m.ToString("D2") + ":" + s.ToString("D2");
                                    formularTabule.SetCas(casLabel.Text, false);
                                    odohraneMinuty = 0;
                                    aktMin = 0;
                                   // sw.Restart();
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
                                    formularTabule.SetCas(casLabel.Text, true);
                                    milis = 0;
                                    ZastavCas();
                                    odohraneMinuty = 0;
                                    aktMin = 0;
                                    polcas = 0;
                                    //resetKariet();
                                    formularTabule.SetPolcas(1, 0);
                                    polcasButton.Text = 2 + ". " + Translate(2) + "\nSTART";
                                }
                                else
                                {
                                    casLabel.Text = m.ToString("D2") + ":" + s.ToString("D2");
                                    formularTabule.SetCas(casLabel.Text, false);
                                    odohraneMinuty = 0;
                                    aktMin = 0;
                                    //sw.Restart();
                                    formularTabule.SetPolcas(1, pocetNadstavenychMinut);
                                    casPodrobneLabel.ForeColor = predlzenieColor;
                                    casLabel.ForeColor = predlzenieColor;
                                }
                            }
                        }
                        else if ((m == ((polcas) * dlzkaPolcasu) + pocetNadstavenychMinut))
                        {
                            nadstavenyCas = false;
                            // Koniec nadstaveneho casu
                            nadstavenaMinuta = 0;
                            pocetNadstavenychMinut = 0;
                            casLabel.Text = m.ToString("D2") + ":" + s.ToString("D2");
                            formularTabule.SetCas(casLabel.Text, false);
                            milis = 0;
                            ZastavCas();
                            //polcas = 0;
                            //odohraneMinuty += dlzkaPolcasu;
                            aktMin = 0;
                            //formularTabule.SetPolcas(4, 0);
                            //polcasButton.Text = (polcas + 1) + ". " + Translate(2) + "\nSTART";
                            if (polcas == 1)
                            {
                                polcasButton.Text = 2 + ". " + Translate(2) + "\nSTART";
                            }
                            else
                            {    
                                polcasButton.Text = 1 + ". " + Translate(2) + "\nSTART";
                            }
                            
                            
                        }
                        else
                        {
                            nadstavenaMinuta = m - (polcas * dlzkaPolcasu) + 1;
                            // Plynutie nadstaveneho casu
                            if (milis <= 500)
                                casLabel.Text = m.ToString("D2") + ":" + s.ToString("D2");
                            else
                                casLabel.Text = m.ToString("D2") + " " + s.ToString("D2");
                            formularTabule.SetCas(casLabel.Text, false);
                        }

                        priebeh.Polcas = polcas;
                        priebeh.Minuta = m;
                        priebeh.Dlzka = dlzkaPolcasu;
                        priebeh.Nadstavenie = pocetNadstavenychMinut;
                        priebeh.SkoreD = skoreDomaci;
                        priebeh.SkoreH = skoreHostia;
                        ulozPriebehHry();
                    }

                    if (!nadstavenyCas)
                    {
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

        private void SpustiCas(bool pouzitReset)
        {
            hraBezi = true;
            casovac.Start();
            if (pouzitReset)
                sw.Reset();
            sw.Start();
        }

        private void ulozPriebehHry()
        {
            TextWriter textWriter = null;

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(PriebehZapasu));
                textWriter = new StreamWriter(currentDirectory + "\\" + priebehSubor);
                serializer.Serialize(textWriter, priebeh);
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
                SaveDatabase();

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
                fs = new FileStream(konfiguracnySubor, FileMode.Open);
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
                zobrazitFunkcionarov = br.ReadBoolean();
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
                bw.Write(zobrazitFunkcionarov);
                bw.Write(animaciaZltaKarta);
                bw.Write(animaciaCervenaKarta);
                bw.Write(rozlozenieCesta);
                //bw.Write(fontStriedania);
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

        private void LoadDatabase()
        {
            TextReader textReader = null;

            try
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(Databaza));
                textReader = new StreamReader(databazaSubor);
                databaza = (Databaza)deserializer.Deserialize(textReader);
            }
            catch (Exception ex)
            {
                databaza = new Databaza();
                MessageBox.Show(ex.Message, nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (textReader != null)
                    textReader.Close();
                databaza.PostLoad();
            }
        }

        private void SaveDatabase()
        {
            TextWriter textWriter = null;

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Databaza));
                textWriter = new StreamWriter(databazaSubor);
                serializer.Serialize(textWriter, databaza);
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

        private void resetKariet()
        {
            if (timDomaci != null)
                timDomaci.resetKariet();
            if (timHostia != null)
                timHostia.resetKariet();
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

            //resetKariet();

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
            if (polcas != 3)
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
                    formularTabule.SetPolcas(3, pocetNadstavenychMinut);
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
                        zapas.DatumZapasu = DateTime.Today;
                        zapas.DlzkaPolcasu = dlzkaPolcasu;

                        //Zacina sa zapas, treba inicializovat hracov(pocet zapasov,
                        //zlte a cervene karty)
                        if (timDomaci == null || timDomaci.ZoznamHracov.Count <= 0)
                        {
                            domOffsideButton.Enabled = false;
                            domKopyButton.Enabled = false;
                            domOutButton.Enabled = false;
                            domUdalostButton.Enabled = false;
                        }
                        else
                        {
                            domOffsideButton.Enabled = true;
                            domKopyButton.Enabled = true;
                            domOutButton.Enabled = true;
                            domUdalostButton.Enabled = true;
                        }
                        if (timHostia == null || timHostia.ZoznamHracov.Count <= 0)
                        {
                            hosOffsideButton.Enabled = false;
                            hosKopyButton.Enabled = false;
                            hosOutButton.Enabled = false;
                            hosUdalostButton.Enabled = false;
                        }
                        else
                        {
                            hosOffsideButton.Enabled = true;
                            hosKopyButton.Enabled = true;
                            hosOutButton.Enabled = true;
                            hosUdalostButton.Enabled = true;
                        }
                        InicializaciaHracov();
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

                    priebeh.Polcas = polcas;
                    priebeh.Minuta = 0;
                    priebeh.Dlzka = dlzkaPolcasu;
                    priebeh.Nadstavenie = pocetNadstavenychMinut;
                    priebeh.SkoreD = skoreDomaci;
                    priebeh.SkoreH = skoreHostia;
                    ulozPriebehHry();
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

        private void InicializaciaHracov()
        {
            //if (timDomaci != null)
            //{
            //    foreach(Hrac h in timDomaci.ZoznamHracov)
            //    {
            //        h.ZltaKarta = false;
            //        h.CervenaKarta = false;
            //    }
            //}

            //if (timHostia != null)
            //{
            //    foreach (Hrac h in timHostia.ZoznamHracov)
            //    {
            //        h.ZltaKarta = false;
            //        h.CervenaKarta = false;
            //    }
            //}
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

            ZltaKartaSettingsForm zksf = new ZltaKartaSettingsForm(timDomaci, zapas, nadstavenyCas, nadstavenaMinuta, aktualnaMinuta, polcas);
            zksf.OnHracZltaKartaSelected += Zksf_OnHracZltaKartaSelected;
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
                    if(!ok)
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

            ZltaKartaSettingsForm zksf = new ZltaKartaSettingsForm(timHostia, zapas, nadstavenyCas, nadstavenaMinuta, aktualnaMinuta, polcas);
            zksf.OnHracZltaKartaSelected += Zksf_OnHracZltaKartaSelected;
            zksf.Show();
        }

        private void DomCervenaKartaButton_Click(object sender, EventArgs e)
        {
            if ((polcas == 0) || (polcas == 4))
            {
                MessageBox.Show(Translate(16), nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CervenaKartaSettingsForm cksf = new CervenaKartaSettingsForm(timDomaci, zapas, nadstavenyCas, nadstavenaMinuta, aktualnaMinuta, polcas);
            cksf.OnHracZltaKartaSelected += Cksf_OnHracZltaKartaSelected;
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

            CervenaKartaSettingsForm cksf = new CervenaKartaSettingsForm(timHostia, zapas, nadstavenyCas, nadstavenaMinuta, aktualnaMinuta, polcas);
            cksf.OnHracZltaKartaSelected += Cksf_OnHracZltaKartaSelected;
            cksf.Show();
        }

        private void DomZmenaStavuButton_Click(object sender, EventArgs e)
        {
            GolSettingsForm gsf = new GolSettingsForm(timDomaci, true, skoreDomaci, zapas, nadstavenyCas, nadstavenaMinuta, aktualnaMinuta, polcas);
            gsf.OnGoalSettingsConfirmed += Gsf_OnGoalSettingsConfirmed;
            gsf.OnGoalValueConfirmed += Gsf_OnGoalValueConfirmed;
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

                        PredstavenieSettingsForm psf = new PredstavenieSettingsForm(currentDirectory, null, null, null, zobrazitNahradnikov, zobrazitFunkcionarov);
                        FarbyPrezentacieClass farbicky = psf.GetFarbyDom();

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

                        PredstavenieSettingsForm psf = new PredstavenieSettingsForm(currentDirectory, null, null, null, zobrazitNahradnikov, zobrazitFunkcionarov);
                        FarbyPrezentacieClass farbicky = psf.GetFarbyHos();

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
            GolSettingsForm gsf = new GolSettingsForm(timHostia, false, skoreHostia, zapas, nadstavenyCas, nadstavenaMinuta, aktualnaMinuta, polcas);
            gsf.OnGoalSettingsConfirmed += Gsf_OnGoalSettingsConfirmed;
            gsf.OnGoalValueConfirmed += Gsf_OnGoalValueConfirmed;
            gsf.Show();
        }

        private void setSkoreDomaci(int novaHodnota)
        {
            skoreDomaci = novaHodnota;
            skoreDomaciLabel.Text = skoreDomaci.ToString();
            formularTabule.SetSkoreDomaci(skoreDomaci);
        }

        private void setSkoreHostia(int novaHodnota)
        {
            skoreHostia = novaHodnota;
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

            StriedanieSettingsForm ssf = new StriedanieSettingsForm(timDomaci, domaciLabel.Text, true, zapas, nadstavenyCas, nadstavenaMinuta, aktualnaMinuta, polcas);
            ssf.OnStriedanieHraciSelected += Ssf_OnStriedanieHraciSelected;
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

            PredstavenieSettingsForm psf = new PredstavenieSettingsForm(currentDirectory, null, null, null, zobrazitNahradnikov, zobrazitFunkcionarov);
            FarbyPrezentacieClass farbicky = psf.GetFarbyDom();
            
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

            StriedanieSettingsForm ssf = new StriedanieSettingsForm(timHostia, hostiaLabel.Text, false, zapas, nadstavenyCas, nadstavenaMinuta, aktualnaMinuta, polcas);
            ssf.OnStriedanieHraciSelected += Ssf_OnStriedanieHraciSelected;
            ssf.Show();
        }

        private void PredstavButton_Click(object sender, EventArgs e)
        {
            PredstavenieSettingsForm psf = new PredstavenieSettingsForm(currentDirectory, timDomaci, timHostia, pismaPrezentacie, zobrazitNahradnikov, zobrazitFunkcionarov);
            psf.OnVyberTimuNaPrezentaciu += Psf_OnVyberTimuNaPrezentaciu;
            psf.OnZastaveniePrezentacie += Psf_OnZastaveniePrezentacie;
            psf.OnNastaveniaConfirmed += Psf_OnNastaveniaConfirmed;
            psf.Show();
        }

        private void Psf_OnNastaveniaConfirmed(bool n, bool f)
        {
            zobrazitNahradnikov = n;
            zobrazitFunkcionarov = f;
        }

        private void Psf_OnZastaveniePrezentacie()
        {
            zastavPrezentaciu();
        }

        private void Psf_OnVyberTimuNaPrezentaciu(FutbalovyTim tim, FarbyPrezentacieClass fp)
        {
            PrezentaciaForm pf = new PrezentaciaForm(currentDirectory, sirkaTabule, animacnyCas, tim, fp, pismaPrezentacie, zobrazitNahradnikov, zobrazitFunkcionarov);
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
                databaza, timDomaci, timHostia, currentDirectory, animacnyCas, pisma, dajSchemu(),
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
            sf.OnFontPosted += Sf_OnFontPosted;
            sf.OnLayoutChanged += Sf_OnLayoutChanged;
            sf.OnFileSelectedRF += Sf_OnFileSelectedRF;
            sf.rozlozenieTabule = formularTabule.RozlozenieTabule;
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

        private void Sf_OnFontPosted(Font f)
        {
            //fontStriedania = f;
        }

        private void Sf_OnObnovaFontov()
        {
            this.pisma = sf.Pisma;
            //fontStriedania = pisma.CreateStriedaniaFont();
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

        private void TestovanieButton_Click(object sender, EventArgs e)
        {
            TestovaciForm testovaciForm = new TestovaciForm(formularTabule);
            testovaciForm.Show();
        }

        private void SpristupniHracovDomaci()
        {
            if (timDomaci != null)
            {
                HraciForm hf = new HraciForm(databaza, timDomaci, currentDirectory, true);
                hf.Show();
            }
        }

        private void SpristupniHracovHostia()
        {
            if (timHostia != null)
            {
                HraciForm hf = new HraciForm(databaza, timHostia, currentDirectory, true);
                hf.Show();
            }
        }

        private void obnovaHryButton_Click(object sender, EventArgs e)
        {
            TextReader textReader = null;

            try
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(PriebehZapasu));
                textReader = new StreamReader(currentDirectory + "\\" + priebehSubor);
                priebeh = (PriebehZapasu)deserializer.Deserialize(textReader);
                
                int cast = priebeh.Polcas;

                if (cast < 1 || cast > 3)
                    MessageBox.Show(Translate(3), nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    if (hraBezi)
                        ZastavCas();

                    odohraneMinuty = priebeh.Minuta;
                    polcas = priebeh.Polcas;
                    dlzkaPolcasu = priebeh.Dlzka;
                    pocetNadstavenychMinut = priebeh.Nadstavenie;
                    skoreDomaci = priebeh.SkoreD;
                    skoreHostia = priebeh.SkoreH;

                    hraBezi = false;
                    poPreruseni = true;

                    casPodrobneLabel.Text = ((polcas - 1) * dlzkaPolcasu + odohraneMinuty).ToString("D2") + ":00.000";
                    casLabel.Text = (((polcas - 1) * dlzkaPolcasu) + odohraneMinuty + 1) + ".'";
                    formularTabule.SetCas(casLabel.Text, true);

                    if (polcas < 3)
                        formularTabule.SetPolcas(polcas, 0);
                    else
                        formularTabule.SetPolcas(polcas, pocetNadstavenychMinut);

                    polcasLabel.Text = dlzkaPolcasu.ToString();
                    nadCasLabel.Text = pocetNadstavenychMinut.ToString();
                    skoreDomaciLabel.Text = skoreDomaci.ToString();
                    skoreHostiaLabel.Text = skoreHostia.ToString();
                    formularTabule.SetSkoreDomaci(skoreDomaci);
                    formularTabule.SetSkoreHostia(skoreHostia);

                    if (polcas > 2)
                    {
                        casPodrobneLabel.ForeColor = predlzenieColor;
                        casLabel.ForeColor = predlzenieColor;
                    }
                    else
                    {
                        casPodrobneLabel.ForeColor = casColor;
                        casLabel.ForeColor = casColor;
                    }

                    if (polcas == 1)
                        polcasButton.Text = "1. " + Translate(2) + "\nSTART";
                    else
                        polcasButton.Text = "2. " + Translate(2) + "\nSTART";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (textReader != null)
                    textReader.Close();
            }
        }

        private void domaciLabel_Click(object sender, EventArgs e)
        {
            SpristupniHracovDomaci();
        }

        private void hostiaLabel_Click(object sender, EventArgs e)
        {
            SpristupniHracovHostia();
        }

        private void logoDomaci_Click(object sender, EventArgs e)
        {
            SpristupniHracovDomaci();
        }

        private void logoHostia_Click(object sender, EventArgs e)
        {
            SpristupniHracovHostia();
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
                MessageBox.Show("Nemozno menit cas pocas nadstaveneho casu", nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                switch(cisloVety)
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

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            domKopyButton.BackColor = Color.FromArgb(255, 192, 128);
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            hosUdalostButton.BackColor = Color.FromArgb(255, 128, 0);
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

        private void domUdalostButton_MouseEnter(object sender, EventArgs e)
        {
            mouseEnter(domUdalostButton);
        }

        private void domUdalostButton_MouseLeave(object sender, EventArgs e)
        {
            mouseLeave(domUdalostButton);
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

        private void hosUdalostButton_MouseEnter(object sender, EventArgs e)
        {
            mouseEnter(hosUdalostButton);
        }

        private void hosUdalostButton_MouseLeave(object sender, EventArgs e)
        {
            mouseLeave(hosUdalostButton);
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
            KopySettingsForm kps = new KopySettingsForm(timDomaci, zapas, nadstavenyCas, nadstavenaMinuta, aktualnaMinuta, polcas);
            kps.ShowDialog();
        }

        private void domOffsideButton_Click(object sender, EventArgs e)
        {
            OffsideSettingsForm osf = new OffsideSettingsForm(timDomaci, zapas, nadstavenyCas, nadstavenaMinuta, aktualnaMinuta, polcas);
            osf.ShowDialog();
        }

        private void domOutButton_Click(object sender, EventArgs e)
        {
            OutSettingsForm osf = new OutSettingsForm(timDomaci, zapas, nadstavenyCas, nadstavenaMinuta, aktualnaMinuta, polcas);
            osf.ShowDialog();
        }

        private void domUdalostButton_Click(object sender, EventArgs e)
        {

        }

        private void hosKopyButton_Click(object sender, EventArgs e)
        {
            KopySettingsForm ksf = new KopySettingsForm(timHostia, zapas, nadstavenyCas, nadstavenaMinuta, aktualnaMinuta, polcas);
            ksf.ShowDialog();
        }

        private void hosOffsideButton_Click(object sender, EventArgs e)
        {
            OffsideSettingsForm osf = new OffsideSettingsForm(timHostia, zapas, nadstavenyCas, nadstavenaMinuta, aktualnaMinuta, polcas);
            osf.ShowDialog();
        }

        private void hosOutButton_Click(object sender, EventArgs e)
        {
            OutSettingsForm osf = new OutSettingsForm(timHostia, zapas, nadstavenyCas, nadstavenaMinuta, aktualnaMinuta, polcas);
            osf.ShowDialog();
        }

        private void hosUdalostButton_Click(object sender, EventArgs e)
        {

        }

        private void udalostiButton_Click(object sender, EventArgs e)
        {
            if (zapas != null)
            {
                UdalostiForm uf = new UdalostiForm(zapas);
                uf.Show();
            }
        }
    }

}
