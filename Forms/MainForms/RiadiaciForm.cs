using LGR_Futbal.Forms;
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
        #region ATRIBUTY

        private const string nazovProgramuString = "LGR Futbal";
        private string konfiguracnySubor = "\\Files\\Config.bin";
        private string animacieSubor = "\\Files\\Gify\\Settings.xml";
        private string rozlozenieSubor = "\\Files\\LastUsed\\PoslednePouziteRozlozenie.xml";
        private string farebnaSchemaSubor = "\\Files\\LastUsed\\PoslednePouzitaSchema.xml";

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
        private int aktualnaSekunda;
        private int zmenenaMinuta;
        private int zmenenaSekunda;

        private bool hraBezi = false;
        private bool poPreruseni = false;
        private bool odstranovatDiakritiku = true;
        private bool nadstavenyCas = false;
        private bool zobrazitPozadie = false;
        private bool zobrazitNastaveniaPoSpusteni = true;
        private bool povolitPrerusenieHry = false;
        private bool koniec = true;
        private bool zobrazitNahradnikov = true;

        private string nazovDomaci = "Domáci";
        private string nazovHostia = "Hostia";
        private string aktualnyAdresar = null;

        private Stopwatch stopky = null;
        private System.Timers.Timer casovac = null;
        private FutbalovyTim timDomaci = null;
        private FutbalovyTim timHostia = null;
        private Zapas zapas = null;
        private List<Rozhodca> rozhodcovia = null;

        private AnimacnaKonfiguracia animKonfig = null;
        private FontyTabule fontyTabule = null;
        private RozlozenieTabule rozlozenieTabule = null;
        private FarbyTabule farbyTabule = null;
        private FarbyPrezentacie farbyPrezHostia = null;
        private FarbyPrezentacie farbyPrezDomaci = null;

        private PozadieForm pozadieForm = null;
        private TabulaForm tabulaForm = null;
        private PrezentaciaForm prezentaciaForm = null;
        private ReklamaForm reklamaForm = null;

        private Pripojenie pripojenie = null;
        private DBHraci dbhraci = null;
        private DBRozhodcovia dbrozhodcovia = null;
        private DBTimy dbtimy = null;
        private DBZapasy dbzapasy = null;

        #endregion ATRIBUTY
        public RiadiaciForm()
        {
            InitializeComponent();

            SetDefaultColors();
            SizeForm sf = new SizeForm(zobrazitPozadie, zobrazitNastaveniaPoSpusteni);
            fontyTabule = new FontyTabule();
            aktualnyAdresar = Directory.GetCurrentDirectory();
            rozlozenieTabule = new RozlozenieTabule();
            farbyTabule = new FarbyTabule();
            farbyPrezHostia = new FarbyPrezentacie();
            farbyPrezDomaci = new FarbyPrezentacie();
            LoadSettings();

            // Zobrazenie formulara so zakladnymi nastaveniami tabule
            if (zobrazitNastaveniaPoSpusteni)
            {
                sf.OnNastaveniaPotvrdenie += (pozadie, nastavenia, s, v)  =>
                    {
                        zobrazitPozadie = pozadie;
                        zobrazitNastaveniaPoSpusteni = nastavenia;
                        sirkaTabule = s;
                        vyskaTabule = v;
                    };
                sf.ShowDialog();
                koniec = sf.Vypnut();
            }

            else koniec = false;
            if (!koniec)
            {
                rozhodcovia = new List<Rozhodca>();
                if (zobrazitPozadie)
                {
                    pozadieForm = new PozadieForm();
                    pozadieForm.Show();
                }
                NastavVelkosti();
                casovac = new System.Timers.Timer();
                casovac.Interval = 100;
                casovac.Elapsed += (o, e) => SpracujCas();

                InicializujDatabazu();

                stopky = new Stopwatch();

                polcasLabel.Text = dlzkaPolcasu.ToString();

                if (povolitPrerusenieHry)
                    prerusenieLabel.Text = "áno";
                else
                    prerusenieLabel.Text = "nie";

                NastavTabulu();
                LoadFarebnaSchemaConfig();
                LoadRozlozenieConfig();
            }
        }

        #region INICIALIZACIA

        private void NastavVelkosti()
        {
            Screen primarnyDisplej = Screen.AllScreens.ElementAtOrDefault(0);
            int sirkaObr = primarnyDisplej.Bounds.Width;
            pomer = (float)sirkaObr / (float)this.Width;
            Scale(new SizeF(pomer, pomer));

            LayoutSetter.NastavVelkostiElementov(this, pomer);
        }
        private void NastavTabulu()
        {
            tabulaForm = new TabulaForm(sirkaTabule);
            tabulaForm.SetLayout(rozlozenieTabule);
            tabulaForm.Show();
            tabulaForm.SetFonty(fontyTabule);
        }

        private void SetDefaultColors()
        {
            casLabel.ForeColor = Color.Lime;
            domaciLabel.ForeColor = Color.Aqua;
            hostiaLabel.ForeColor = Color.Aqua;
            skoreDomaciLabel.ForeColor = Color.Red;
            skoreHostiaLabel.ForeColor = Color.Red;
        }

        private void SetDefaults()
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
                Close();
        }

        #endregion INICIALIZACIA

        #region PRACA_S_CASOM

        private void VykresliCas(int min, int sek)
        {
            casLabel.Text = min.ToString("D2") + ":" + sek.ToString("D2");
            tabulaForm.SetCas(casLabel.Text);
        }

        private void SpustiCas(bool pouzitReset)
        {
            hraBezi = true;
            casovac.Start();
            if (pouzitReset)
                stopky.Reset();
            stopky.Start();
        }

        private void NadstCasBtn_Click(object sender, EventArgs e)
        {
            NadstavCasForm ncf = new NadstavCasForm(pocetNadstavenychMinut, polcas, zapas);
            ncf.OnNadstavenyCasPotvrdeny += Ncf_OnNadstavenyCasPotvrdeny;
            ncf.Show();
        }

        private void Ncf_OnNadstavenyCasPotvrdeny(int hodnota)
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
                    tabulaForm.SetPolcas(polcas, pocetNadstavenychMinut, nadstavenyCas);
                }
                else
                    MessageBox.Show("Počas nadstaveného času ho možno len predĺžiť!", nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void PolcasBtn_Click(object sender, EventArgs e)
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
                        minutaPolcasu = 0;
                        aktualnaSekunda = 0;

                    }
                    casLabel.ForeColor = Color.Lime;
                    casPodrobneLabel.ForeColor = Color.Lime;
                    polcas++;
                    //casPodrobneLabel.Text = ((polcas - 1) * dlzkaPolcasu).ToString("D2") + ":00.000";
                    //aktualnaMinuta = (polcas - 1) * dlzkaPolcasu;
                    minutaPolcasu = 0;
                    zmenenaMinuta = 0;
                    zmenenaSekunda = 0;
                    tabulaForm.SetPolcas(polcas, pocetNadstavenychMinut, nadstavenyCas);
                    //casLabel.Text = polcas == 2 ? (((polcas - 1) * dlzkaPolcasu) + 1) + ":00" : "00:00";
                    tabulaForm.SetCas(casLabel.Text);

                    SpustiCas(true);

                    if (povolitPrerusenieHry)
                        PolcasBtn.Text = PolcasBtn.Text.Replace("START", "STOP");
                    else
                        PolcasBtn.Text = polcas + ". polčas";
                }
                else
                {
                    // Spustenie casu po preruseni hry
                    SpustiCas(false);
                    PolcasBtn.Text = PolcasBtn.Text.Replace("START", "STOP");
                }
                poPreruseni = false;
            }
            else
            {
                if (povolitPrerusenieHry)
                {
                    poPreruseni = true;
                    PolcasBtn.Text = PolcasBtn.Text.Replace("STOP", "START");
                    ZastavCas();
                }
            }
        }

        private void ZastavCas()
        {
            hraBezi = false;
            casovac.Stop();
            stopky.Stop();
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
                    int m = zmenenaMinuta + ((polcas - 1) * dlzkaPolcasu) + stopky.Elapsed.Minutes;
                    int s = zmenenaSekunda + stopky.Elapsed.Seconds;
                    int milis = stopky.Elapsed.Milliseconds;

                    if (s == 60)
                    {
                        zmenenaSekunda = 0;
                        zmenenaMinuta++;
                        s = 0;
                        stopky.Restart();
                    }

                    casLabel.Text = m.ToString("D2") + ":" + s.ToString("D2");
                    tabulaForm.SetCas(m.ToString("D2") + ":" + s.ToString("D2"));

                    casPodrobneLabel.Text = m.ToString("D2") + ":" + s.ToString("D2") + "." + milis.ToString("D3");

                    File.AppendAllText("sekundy.txt", "minuty: " + m + " sekundy: " + s + " milisekundy: " + milis + "\n");

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
                                    KoniecPolcasu(polcas, m);
                                }
                                else
                                {
                                    nadstavenyCas = true;
                                    tabulaForm.SetPolcas(1, pocetNadstavenychMinut, true);
                                    casPodrobneLabel.ForeColor = Color.OrangeRed;
                                    casLabel.ForeColor = Color.OrangeRed;
                                }
                            }
                            else
                            {
                                if (pocetNadstavenychMinut == 0)
                                {
                                    KoniecPolcasu(polcas, m);
                                }
                                else
                                {
                                    nadstavenyCas = true;
                                    tabulaForm.SetPolcas(2, pocetNadstavenychMinut, true);
                                    casPodrobneLabel.ForeColor = Color.OrangeRed;
                                    casLabel.ForeColor = Color.OrangeRed;
                                }
                            }
                        }
                        else if (m == ((polcas * dlzkaPolcasu) + pocetNadstavenychMinut))
                        {
                            nadstavenyCas = false;
                            // Koniec nadstaveneho casu

                            KoniecPolcasu(polcas, m);
                            //if (polcas == 1)
                            //{
                            //    zapas.NadstavenyCas1 = pocetNadstavenychMinut;
                            //    PolcasBtn.Text = 2 + ". polčas\nSTART";
                            //}
                            //else
                            //{
                            //    zapas.NadstavenyCas2 = pocetNadstavenychMinut;
                            //    polcas = 0;
                            //    PolcasBtn.Text = 1 + ". polčas\nSTART";
                            //}
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
                        //aktualnaMinuta = m + (polcas - 1) * dlzkaPolcasu;
                        aktualnaSekunda = s;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Nastala chyba pri spracovávani času!", nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void KoniecPolcasu(int polcas, int minuty)
        {
            if (polcas == 1)
            {
                ZastavCas();
                minutaPolcasu = 0;
                aktualnaSekunda = 0;
                zmenenaSekunda = 0;
                zmenenaMinuta = 0;
                casPodrobneLabel.Text = minuty.ToString("D2") + ":00.000";
                casLabel.Text = minuty.ToString("D2") + ":00";
                tabulaForm.SetCas(minuty.ToString("D2") + ":00");
                PolcasBtn.Text = "2. polčas\nSTART";
            }
            else
            {
                ZastavCas();
                casLabel.Text = "00:00";
                casPodrobneLabel.Text = "00:00.000";
                skoreDomaci = 0;
                skoreHostia = 0;
                skoreDomaciLabel.Text = "0";
                skoreHostiaLabel.Text = "0";
                this.polcas = 0;
                pocetNadstavenychMinut = 0;
                poPreruseni = false;
                nadstavenyCas = false;
                minutaPolcasu = 0;
                aktualnaSekunda = 0;
                zmenenaSekunda = 0;
                zmenenaMinuta = 0;
                zapas = null;
                tabulaForm.SetPolcas(2, 0, false);
                casPodrobneLabel.Text = minuty.ToString("D2") + ":00.000";
                casLabel.Text = minuty.ToString("D2") + ":00";
                tabulaForm.SetCas(minuty.ToString("D2") + ":00");
                PolcasBtn.Text = "1. polčas\nSTART";
            }
        }

        private void ZmenitCasBtn_Click(object sender, EventArgs e)
        {
            if (nadstavenyCas)
            {
                MessageBox.Show("Nemožno meniť čas počas nadstaveného času", nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                ZmenaCasuForm zcf = new ZmenaCasuForm(minutaPolcasu, aktualnaSekunda, dlzkaPolcasu);
                zcf.OnZmenaCasu += Zcf_OnZmenaCasu;
                zcf.Show();
            }

        }

        private void Zcf_OnZmenaCasu(int novaMin, int novaSek)
        {
            if (polcas == 0)
                MessageBox.Show("Zmena času sa môže prejaviť len počas zápasu!", nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                if (pocetNadstavenychMinut == 0 && novaMin >= (polcas * dlzkaPolcasu) && novaSek > 0)
                {
                    polcas = 1 + (novaMin / dlzkaPolcasu);
                }
                else if (pocetNadstavenychMinut > 0 && novaMin >= (polcas * dlzkaPolcasu) && novaMin < (polcas * dlzkaPolcasu + pocetNadstavenychMinut))
                {
                    nadstavenyCas = true;
                    tabulaForm.SetPolcas(polcas, pocetNadstavenychMinut, true);
                    casPodrobneLabel.ForeColor = Color.OrangeRed;
                    casLabel.ForeColor = Color.OrangeRed;
                }

                zmenenaMinuta = novaMin - (dlzkaPolcasu * (polcas - 1));
                zmenenaSekunda = novaSek;
                minutaPolcasu = novaMin;
                aktualnaSekunda = novaSek;

                casLabel.Text = minutaPolcasu.ToString("D2") + ":" + aktualnaSekunda.ToString("D2");
                tabulaForm.SetCas(minutaPolcasu.ToString("D2") + ":" + aktualnaSekunda.ToString("D2"));
                casPodrobneLabel.Text = (minutaPolcasu).ToString("D2") + ":" + aktualnaSekunda.ToString("D2") + ".000";

                if ((minutaPolcasu == dlzkaPolcasu) && (aktualnaSekunda == 0) && !nadstavenyCas)
                {
                    KoniecPolcasu(1, dlzkaPolcasu);
                    //tabulaForm.SetCas(casLabel.Text);
                    //ZastavCas();
                    //minutaPolcasu = 0;
                    //tabulaForm.SetPolcas(1, 0, false);
                    //polcas = 2;
                    //PolcasBtn.Text = "2. polčas\nSTART";
                }
                else if ((minutaPolcasu == 2 * dlzkaPolcasu) && (aktualnaSekunda == 0) && !nadstavenyCas)
                {
                    KoniecPolcasu(2, 2 * dlzkaPolcasu);
                    //ZastavCas();
                    //Reset();
                }
                else
                {
                    tabulaForm.SetCas(casLabel.Text);
                    tabulaForm.SetPolcas(polcas, pocetNadstavenychMinut, nadstavenyCas);
                    //PolcasBtn.Text = PolcasBtn.Text.Replace("1", polcas.ToString());
                    PolcasBtn.Text = polcas + ". polčas\nSTART";

                    if (hraBezi)
                        stopky.Restart();
                    else
                        stopky.Reset();

                    if (minutaPolcasu >= dlzkaPolcasu)
                        minutaPolcasu -= dlzkaPolcasu;
                }
            }

        }

        #endregion PRACA_S_CASOM

        #region NACITANIE_ULOZENIE_NASTAVENI
        private void LoadSettings()
        {
            FileStream fs = null;
            BinaryReader br = null;

            try
            {
                fs = new FileStream(aktualnyAdresar + konfiguracnySubor, FileMode.OpenOrCreate);
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
            }
            catch (Exception ex)
            {
                SetDefaults();
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

        private void LoadAnimConfig()
        {
            TextReader textReader = null;
            try
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(AnimacnaKonfiguracia));
                textReader = new StreamReader(aktualnyAdresar + animacieSubor);
                animKonfig = (AnimacnaKonfiguracia)deserializer.Deserialize(textReader);
            }
            catch (Exception ex)
            {
                animKonfig = new AnimacnaKonfiguracia();
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
                string nazovSuboru = aktualnyAdresar + rozlozenieSubor;
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
                    tabulaForm.SetLayout(rozlozenieTabule);
            }
        }

        private void LoadFarebnaSchemaConfig()
        {
            TextReader textReader = null;
            bool uspech = true;

            try
            {
                string nazovSuboru = aktualnyAdresar + farebnaSchemaSubor;
                XmlSerializer deserializer = new XmlSerializer(typeof(FarbyTabule));
                textReader = new StreamReader(nazovSuboru);
                farbyTabule = (FarbyTabule)deserializer.Deserialize(textReader);
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
                    AplikujFarebnuSchemu(farbyTabule);
            }
            TextReader textReader1 = null;
            TextReader textReader2 = null;

            try
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(FarbyPrezentacie));
                textReader1 = new StreamReader(aktualnyAdresar + "\\Files\\DomaciPrezentacia.xml");
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
                textReader2 = new StreamReader(aktualnyAdresar + "\\Files\\HostiaPrezentacia.xml");
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

        private void SaveSettings()
        {
            FileStream fs = null;
            BinaryWriter bw = null;

            try
            {
                fs = new FileStream(aktualnyAdresar + konfiguracnySubor, FileMode.Create);
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
                textWriter = new StreamWriter(aktualnyAdresar + animacieSubor);
                serializer.Serialize(textWriter, animKonfig);
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
                textWriter = new StreamWriter(aktualnyAdresar + rozlozenieSubor);
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
                textWriter = new StreamWriter(aktualnyAdresar + farebnaSchemaSubor);
                serializer.Serialize(textWriter, farbyTabule);
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
                textWriter1 = new StreamWriter(aktualnyAdresar + "\\Files\\DomaciPrezentacia.xml");
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
                textWriter2 = new StreamWriter(aktualnyAdresar + "\\Files\\HostiaPrezentacia.xml");
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
        private void PrezentaciaBtn_Click(object sender, EventArgs e)
        {
            PrezentaciaSetupForm psf = new PrezentaciaSetupForm(timDomaci, timHostia, fontyTabule, zobrazitNahradnikov, farbyPrezDomaci, farbyPrezHostia);
            psf.OnVyberTimuNaPrezentaciu += Psf_OnVyberTimuNaPrezentaciu;
            psf.OnZastaveniePrezentacie += () =>
            {
                if (prezentaciaForm != null)
                    prezentaciaForm.Close();
            };
            psf.OnNastaveniaPotvrdene += n => zobrazitNahradnikov = n;
            psf.Show();
        }

        private void Psf_OnVyberTimuNaPrezentaciu(FutbalovyTim tim, FarbyPrezentacie fp)
        {
            prezentaciaForm = new PrezentaciaForm(aktualnyAdresar, sirkaTabule, animacnyCas, tim, fp, fontyTabule, zobrazitNahradnikov);
            prezentaciaForm.FormClosing += (o, e) => prezentaciaForm = null;
            prezentaciaForm.Show();
        }
        #endregion PREDSTAVENIE

        #region SETUP
        private void SetupBtn_Click(object sender, EventArgs e)
        {
            SetupForm sf = new SetupForm(zobrazitPozadie, zobrazitNastaveniaPoSpusteni, sirkaTabule, vyskaTabule, dlzkaPolcasu,
                povolitPrerusenieHry, odstranovatDiakritiku, domaciLabel.Text, hostiaLabel.Text, timDomaci, timHostia, aktualnyAdresar,
                animacnyCas, farbyTabule, animKonfig, rozhodcovia, dbtimy, dbhraci, dbrozhodcovia, dbzapasy, fontyTabule, rozlozenieTabule);
            sf.OnAnimacieKarietPotvrdene += (zlta, cervena) =>
            {
                animKonfig.ZltaKartaAnimacia = zlta;
                animKonfig.CervenaKartaAnimacia = cervena;
            };
            sf.OnDataPotvrdene += Sf_OnDataPotvrdene;
            sf.OnReset += () =>
            {
                if (hraBezi)
                    ZastavCas();

                KoniecPolcasu(2, 0);
                tabulaForm.Reset();
            };
            sf.OnZhasnut += () =>
            {
                tabulaForm.Hide();
                Focus();
            };
            sf.OnRozsvietit += () =>
            {
                tabulaForm.Show();
                Focus();
            };
            sf.OnNazvyLogaPotvrdene += Sf_OnNazvyLogaPotvrdene;
            sf.OnTimyVybrane += Sf_OnTimyVybrane;
            sf.OnObnovaFarieb += Sf_OnObnovaFarieb;
            sf.OnZmenaFarieb += () => AplikujFarebnuSchemu(farbyTabule); ;
            sf.OnZmenaFontov += () => tabulaForm.SetFonty(fontyTabule); ;
            sf.OnZmenaRozlozenia += () => tabulaForm.SetLayout(rozlozenieTabule); ;
            sf.Show();
        }

        private void Sf_OnObnovaFarieb()
        {
            SetDefaultColors();
            tabulaForm.SetDefaultFarby();
            farbyTabule.SetNadpisDomFarba(domaciLabel.ForeColor);
            farbyTabule.SetNadpisHosFarba(hostiaLabel.ForeColor);
            farbyTabule.SetCasFarba(casLabel.ForeColor);
            farbyTabule.SetSkoreFarba(skoreDomaciLabel.ForeColor);
            farbyTabule.SetPolcasFarba(casLabel.ForeColor);
        }

        private void AplikujFarebnuSchemu(FarbyTabule fs)
        {
            casLabel.ForeColor = fs.GetCasFarba();
            casPodrobneLabel.ForeColor = fs.GetCasFarba();
            domaciLabel.ForeColor = fs.GetNadpisDomFarba();
            hostiaLabel.ForeColor = fs.GetNadpisHosFarba();
            skoreDomaciLabel.ForeColor = fs.GetSkoreFarba();
            skoreHostiaLabel.ForeColor = fs.GetSkoreFarba();

            tabulaForm.SetFarby(fs);
        }

        private void Sf_OnTimyVybrane(FutbalovyTim domTim, FutbalovyTim hosTim)
        {
            if (polcas == 0)
            {
                timDomaci = domTim;
                timHostia = hosTim;
            }
            else
                if ((timDomaci != domTim) || (timHostia != hosTim))
                MessageBox.Show("Tímy nie je možné meniť po začiatku zápasu!", nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Sf_OnNazvyLogaPotvrdene(string domNazov, Image domLogo, string hosNazov, Image hosLogo)
        {
            if (polcas == 0)
            {
                if (domNazov.Equals(string.Empty))
                    domaciLabel.Text = "DOMÁCI";
                else
                    domaciLabel.Text = domNazov;

                if (hosNazov.Equals(string.Empty))
                    hostiaLabel.Text = "HOSTIA";
                else
                    hostiaLabel.Text = hosNazov;

                tabulaForm.ZobrazNazvy(domaciLabel.Text, hostiaLabel.Text);

                try
                {
                    logoDomaci.Image = domLogo;
                    tabulaForm.ZobrazLogoDomaci(domLogo);
                }
                catch
                {
                    logoDomaci.Image = null;
                    tabulaForm.ZobrazLogoDomaci(null);
                }

                try
                {
                    logoHostia.Image = hosLogo;
                    tabulaForm.ZobrazLogoHostia(hosLogo);
                }
                catch
                {
                    logoHostia.Image = null;
                    tabulaForm.ZobrazLogoHostia(null);
                }
            }
            nazovDomaci = domaciLabel.Text;
            nazovHostia = hostiaLabel.Text;
        }

        private void Sf_OnDataPotvrdene(bool zobrazovatPozadie, bool zobrazNastavenia, int sirka, int vyska, int cas, bool prerusenie, bool diakritika, int animacia)
        {
            if (cas == 0)
                MessageBox.Show("Dĺžka polčasu nemôže byť nulová!", nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (dlzkaPolcasu != cas)
                {
                    if (polcas == 2)
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
                            if (minutaPolcasu >= cas)
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
                if (pozadieForm == null)
                    pozadieForm = new PozadieForm();

                pozadieForm.Show();
                BringToFront();
                tabulaForm.BringToFront();
            }
            else
            {
                if (pozadieForm != null)
                    pozadieForm.Close();
                pozadieForm = null;
            }

            zobrazitNastaveniaPoSpusteni = zobrazNastavenia;

            sirkaTabule = sirka;
            vyskaTabule = vyska;
            SaveAnimConfig();
            SaveFarebnaSchemaConfig();
            SaveRozlozenieConfig();
        }

        #endregion SETUP

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

        private void DomKartyLabel_Click(object sender, EventArgs e)
        {
            if (timDomaci != null)
            {
                HraciKartyForm hkf = new HraciKartyForm(timDomaci);
                hkf.ShowDialog();
            }
        }

        private void HosKartyLabel_Click(object sender, EventArgs e)
        {
            if (timHostia != null)
            {
                HraciKartyForm hkf = new HraciKartyForm(timHostia);
                hkf.ShowDialog();
            }
        }

        private void UkoncitBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Naozaj chcete ukončiť beh aplikácie?", nazovProgramuString, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Close();
        }


        private void RiadiaciForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            SaveSettings();

            if (pozadieForm != null)
                pozadieForm.Close();

            if (tabulaForm != null)
                tabulaForm.Close();
        }

        #endregion INE

        #region UDALOSTI
        private void DomZltaKartaBtn_Click(object sender, EventArgs e)
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
            karta.Typ = 2;

            ZltaKartaSettingsForm zksf = new ZltaKartaSettingsForm(timDomaci, zapas, true, karta);
            zksf.OnHracZltaKartaSelected += Zksf_OnHracZltaKartaSelected;
            zksf.OnUdalostPridana += OnUdalostPridana;
            zksf.Show();
        }

        private void HosZltaKartaBtn_Click(object sender, EventArgs e)
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
            karta.Typ = 2;

            ZltaKartaSettingsForm zksf = new ZltaKartaSettingsForm(timHostia, zapas, false, karta);
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

                    ZltaKartaForm zkf = new ZltaKartaForm(aktualnyAdresar, sirkaTabule, animacnyCas, hrac, fontyTabule, animKonfig.ZltaKartaAnimacia);
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
                    CervenaKartaForm ckf = new CervenaKartaForm(aktualnyAdresar, sirkaTabule, animacnyCas, hrac, true,
                        fontyTabule, animKonfig.ZltaKartaAnimacia, animKonfig.CervenaKartaAnimacia);
                    ckf.Show();
                }
            }
            else
            {
                ZltaKartaForm zkf = new ZltaKartaForm(aktualnyAdresar, sirkaTabule, animacnyCas, hrac, fontyTabule, animKonfig.ZltaKartaAnimacia);
                zkf.Show();
            }
        }

        private void DomCervenaKartaBtn_Click(object sender, EventArgs e)
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

        private void HosCervenaKartaBtn_Click(object sender, EventArgs e)
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

        private void Cksf_OnHracCervenaKartaSelected(Hrac hrac)
        {
            if (hrac != null)
                hrac.CervenaKarta = true;

            CervenaKartaForm ckf = new CervenaKartaForm(aktualnyAdresar, sirkaTabule, animacnyCas, hrac, false, fontyTabule, animKonfig.ZltaKartaAnimacia, animKonfig.CervenaKartaAnimacia);
            ckf.Show();
        }

        private void DomZmenaStavuBtn_Click(object sender, EventArgs e)
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
            gol.Typ = 1;

            GolSettingsForm gsf = new GolSettingsForm(timDomaci, true, skoreDomaci, zapas, gol);
            gsf.OnGoalSettingsConfirmed += Gsf_OnGoalSettingsConfirmed;
            gsf.OnGoalValueConfirmed += Gsf_OnGoalValueConfirmed;
            gsf.OnUdalostPridana += OnUdalostPridana;
            gsf.Show();
        }

        private void HosZmenaStavuBtn_Click(object sender, EventArgs e)
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
            gol.Typ = 1;

            GolSettingsForm gsf = new GolSettingsForm(timHostia, false, skoreHostia, zapas, gol);
            gsf.OnGoalSettingsConfirmed += Gsf_OnGoalSettingsConfirmed;
            gsf.OnGoalValueConfirmed += Gsf_OnGoalValueConfirmed;
            gsf.OnUdalostPridana += OnUdalostPridana;
            gsf.Show();
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
                    if (polcas == 0)
                        MessageBox.Show("Góly možno pridávať len počas zápasu!", nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        SetSkoreDomaci(novyStav);
                        if ((animKonfig.ZobrazitAnimaciuDomaci) || (animKonfig.AnimacieDomaci.Count > 0))
                        {
                            GolForm gf = new GolForm(aktualnyAdresar, sirkaTabule, animacnyCas, h, fontyTabule, farbyPrezDomaci, animKonfig, true);
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
                    if (polcas == 0)
                        MessageBox.Show("Góly možno pridávať len počas zápasu!", nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        SetSkoreHostia(novyStav);
                        if ((animKonfig.ZobrazitAnimaciuHostia) || (animKonfig.AnimacieHostia.Count > 0))
                        {
                            GolForm gf = new GolForm(aktualnyAdresar, sirkaTabule, animacnyCas, h, fontyTabule, farbyPrezHostia, animKonfig, false);
                            gf.Show();
                        }
                    }
                }
            }
        }

        private void SetSkoreDomaci(int novaHodnota)
        {
            skoreDomaci = novaHodnota;
            skoreDomaciLabel.Text = skoreDomaci.ToString();
            zapas.DomaciSkore = skoreDomaci;
            tabulaForm.SetSkoreDomaci(skoreDomaci);
        }

        private void SetSkoreHostia(int novaHodnota)
        {
            skoreHostia = novaHodnota;
            zapas.HostiaSkore = skoreHostia;
            skoreHostiaLabel.Text = skoreHostia.ToString();
            tabulaForm.SetSkoreHostia(skoreHostia);
        }

        private void DomKopyBtn_Click(object sender, EventArgs e)
        {
            if (polcas == 0)
            {
                MessageBox.Show("Možné pridať len počas hry", nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Kop kop = new Kop();
            kop.Minuta = minutaPolcasu;
            kop.Polcas = polcas;
            kop.NadstavenaMinuta = nadstavenaMinuta;
            kop.AktualnyCas = DateTime.Now;
            kop.Typ = 3;

            KopySettingsForm kps = new KopySettingsForm(timDomaci, zapas, true, kop);
            kps.OnUdalostPridana += OnUdalostPridana;
            kps.ShowDialog();
        }

        private void HosKopyBtn_Click(object sender, EventArgs e)
        {
            if (polcas == 0)
            {
                MessageBox.Show("Možné pridať len počas hry", nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Kop kop = new Kop();
            kop.Minuta = minutaPolcasu;
            kop.Polcas = polcas;
            kop.NadstavenaMinuta = nadstavenaMinuta;
            kop.AktualnyCas = DateTime.Now;
            kop.Typ = 3;

            KopySettingsForm ksf = new KopySettingsForm(timHostia, zapas, false, kop);
            ksf.OnUdalostPridana += OnUdalostPridana;
            ksf.ShowDialog();
        }

        private void DomOffsideBtn_Click(object sender, EventArgs e)
        {
            if (polcas == 0)
            {
                MessageBox.Show("Možné pridať len počas hry", nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Offside offside = new Offside();
            offside.Minuta = minutaPolcasu;
            offside.Polcas = polcas;
            offside.NadstavenaMinuta = nadstavenaMinuta;
            offside.AktualnyCas = DateTime.Now;
            offside.Typ = 4;

            OffsideSettingsForm osf = new OffsideSettingsForm(timDomaci, zapas, true, offside);
            osf.OnUdalostPridana += OnUdalostPridana;
            osf.ShowDialog();
        }

        private void HosOffsideBtn_Click(object sender, EventArgs e)
        {
            if (polcas == 0)
            {
                MessageBox.Show("Možné pridať len počas hry", nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Offside offside = new Offside();
            offside.Minuta = minutaPolcasu;
            offside.Polcas = polcas;
            offside.NadstavenaMinuta = nadstavenaMinuta;
            offside.AktualnyCas = DateTime.Now;
            offside.Typ = 4;

            OffsideSettingsForm osf = new OffsideSettingsForm(timHostia, zapas, false, offside);
            osf.OnUdalostPridana += OnUdalostPridana;
            osf.ShowDialog();
        }

        private void DomOutBtn_Click(object sender, EventArgs e)
        {
            if (polcas == 0)
            {
                MessageBox.Show("Možné pridať len počas hry", nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Out _out = new Out();
            _out.Minuta = minutaPolcasu;
            _out.Polcas = polcas;
            _out.NadstavenaMinuta = nadstavenaMinuta;
            _out.AktualnyCas = DateTime.Now;
            _out.Typ = 5;

            OutSettingsForm osf = new OutSettingsForm(timDomaci, zapas, true, _out);
            osf.OnUdalostPridana += OnUdalostPridana;
            osf.ShowDialog();
        }

        private void HosOutBtn_Click(object sender, EventArgs e)
        {
            if (polcas == 0)
            {
                MessageBox.Show("Možné pridať len počas hry", nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Out _out = new Out();
            _out.Minuta = minutaPolcasu;
            _out.Polcas = polcas;
            _out.NadstavenaMinuta = nadstavenaMinuta;
            _out.AktualnyCas = DateTime.Now;
            _out.Typ = 5;

            OutSettingsForm osf = new OutSettingsForm(timHostia, zapas, false, _out);
            osf.OnUdalostPridana += OnUdalostPridana;
            osf.ShowDialog();
        }

        private void DomStriedanieBtn_Click(object sender, EventArgs e)
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
            striedanie.Typ = 6;

            StriedanieSettingsForm ssf = new StriedanieSettingsForm(timDomaci, true, zapas, striedanie);
            ssf.OnStriedanieHraciSelected += Ssf_OnStriedanieHraciSelected;
            ssf.OnUdalostPridana += OnUdalostPridana;
            ssf.Show();
        }

        private void HosStriedanieBtn_Click(object sender, EventArgs e)
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
            striedanie.Typ = 6;

            StriedanieSettingsForm ssf = new StriedanieSettingsForm(timHostia, false, zapas, striedanie);
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

            StriedanieForm sf = new StriedanieForm(aktualnyAdresar, sirkaTabule, animacnyCas, nazovTimu, odchadzajuci, nastupujuci, farbicky, fontyTabule);
            sf.Show();
        }

        private void OnUdalostPridana(string text)
        {
            UdalostPopupForm upf = new UdalostPopupForm(text, pomer);
            upf.StartPosition = FormStartPosition.Manual;
            upf.Size = new Size(PolcasBtn.Width, PolcasBtn.Height * 2 / 7);
            upf.Location = new Point(PolcasBtn.Left, PolcasBtn.Top - upf.Height + 10);
            upf.Show();
        }

        private void UdalostiBtn_Click(object sender, EventArgs e)
        {
            if (zapas != null)
            {
                UdalostiForm uf = new UdalostiForm(zapas, false, dbzapasy);
                uf.Show();
            }
        }

        #endregion UDALOSTI

        #region REKLAMA

        private void ReklamaBtn_Click(object sender, EventArgs e)
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
                reklamaForm = new ReklamaForm(sirkaTabule, video);
                reklamaForm.OnReklamaKoniec += Rf_OnReklamaKoniec;
                reklamaForm.Show();
                ReklamaBtn.Visible = false;
                ReklamaBtn.Enabled = false;
                VypnutVideoBtn.Enabled = true;
                VypnutVideoBtn.Visible = true;
            }
        }

        private void Rf_OnReklamaKoniec()
        {
            ReklamaBtn.Visible = true;
            ReklamaBtn.Enabled = true;
            VypnutVideoBtn.Enabled = false;
            VypnutVideoBtn.Visible = false;
        }

        private void VypnutVideoBtn_Click(object sender, EventArgs e)
        {
            try
            {
                reklamaForm.VypnutVideo();
                Rf_OnReklamaKoniec();
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
            DomZltaKartaBtn.BackColor = Color.Yellow;
        }

        private void domZltaKartaButton_Leave(object sender, EventArgs e)
        {
            DomZltaKartaBtn.BackColor = Color.FromArgb(255, 255, 128);
        }

        private void hosZltaKartaButton_Enter(object sender, EventArgs e)
        {
            HosZltaKartaBtn.BackColor = Color.Yellow;
        }

        private void hosZltaKartaButton_Leave(object sender, EventArgs e)
        {
            HosZltaKartaBtn.BackColor = Color.FromArgb(255, 255, 128);
        }

        private void domCervenaKartaButton_MouseEnter(object sender, EventArgs e)
        {
            DomCervenaKartaBtn.BackColor = Color.Red;
        }

        private void domCervenaKartaButton_MouseLeave(object sender, EventArgs e)
        {
            DomCervenaKartaBtn.BackColor = Color.FromArgb(255, 128, 128);
        }

        private void hosCervenaKartaButton_MouseEnter(object sender, EventArgs e)
        {
            HosCervenaKartaBtn.BackColor = Color.Red;
        }

        private void hosCervenaKartaButton_MouseLeave(object sender, EventArgs e)
        {
            HosCervenaKartaBtn.BackColor = Color.FromArgb(255, 128, 128);
        }

        private void domZmenaStavuButton_MouseEnter(object sender, EventArgs e)
        {
            DomZmenaStavuBtn.BackColor = Color.Green;
        }

        private void domZmenaStavuButton_MouseLeave(object sender, EventArgs e)
        {
            DomZmenaStavuBtn.BackColor = Color.FromArgb(128, 255, 128);
        }

        private void hosZmenaStavuButton_MouseEnter(object sender, EventArgs e)
        {
            HosZmenaStavuBtn.BackColor = Color.Green;
        }

        private void hosZmenaStavuButton_MouseLeave(object sender, EventArgs e)
        {
            HosZmenaStavuBtn.BackColor = Color.FromArgb(128, 255, 128);
        }

        private void setupButton_MouseEnter(object sender, EventArgs e)
        {
            SetupBtn.BackColor = Color.FromArgb(0, 192, 192);
        }

        private void setupButton_MouseLeave(object sender, EventArgs e)
        {
            SetupBtn.BackColor = Color.FromArgb(128, 255, 255);
        }

        private void predstavButton_MouseEnter(object sender, EventArgs e)
        {
            PrezentaciaBtn.BackColor = Color.FromArgb(0, 192, 192);
        }

        private void predstavButton_MouseLeave(object sender, EventArgs e)
        {
            PrezentaciaBtn.BackColor = Color.FromArgb(128, 255, 255);
        }

        private void closeButton_MouseEnter(object sender, EventArgs e)
        {
            UkoncitBtn.BackColor = Color.FromArgb(255, 192, 192);
        }

        private void closeButton_MouseLeave(object sender, EventArgs e)
        {
            UkoncitBtn.BackColor = Color.FromArgb(192, 255, 255);
        }

        private void polcasButton_MouseEnter(object sender, EventArgs e)
        {
            PolcasBtn.ForeColor = Color.Yellow;
        }

        private void polcasButton_MouseLeave(object sender, EventArgs e)
        {
            PolcasBtn.ForeColor = Color.Lime;
        }

        private void zmenitCasButton_MouseEnter(object sender, EventArgs e)
        {
            ZmenitCasBtn.ForeColor = Color.Yellow;
        }

        private void zmenitCasButton_MouseLeave(object sender, EventArgs e)
        {
            ZmenitCasBtn.ForeColor = Color.Lime;
        }

        private void casButton_MouseEnter(object sender, EventArgs e)
        {
            NadstCasBtn.BackColor = Color.FromArgb(0, 192, 192);
        }

        private void casButton_MouseLeave(object sender, EventArgs e)
        {
            NadstCasBtn.BackColor = Color.FromArgb(128, 255, 255);
        }

        private void domStriedanieButton_MouseEnter(object sender, EventArgs e)
        {
            mouseEnter(DomStriedanieBtn);
        }

        private void domStriedanieButton_MouseLeave(object sender, EventArgs e)
        {
            mouseLeave(DomStriedanieBtn);
        }

        private void domOffsideButton_MouseEnter(object sender, EventArgs e)
        {
            mouseEnter(DomOffsideBtn);
        }

        private void domOffsideButton_MouseLeave(object sender, EventArgs e)
        {
            mouseLeave(DomOffsideBtn);
        }

        private void domOutButton_MouseEnter(object sender, EventArgs e)
        {
            mouseEnter(DomOutBtn);
        }

        private void domOutButton_MouseLeave(object sender, EventArgs e)
        {
            mouseLeave(DomOutBtn);
        }

        private void hosKopyButton_MouseEnter(object sender, EventArgs e)
        {
            mouseEnter(HosKopyBtn);
        }

        private void hosKopyButton_MouseLeave(object sender, EventArgs e)
        {
            mouseLeave(HosKopyBtn);
        }

        private void hosOffsideButton_MouseEnter(object sender, EventArgs e)
        {
            mouseEnter(HosOffsideBtn);
        }

        private void hosOffsideButton_MouseLeave(object sender, EventArgs e)
        {
            mouseLeave(HosOffsideBtn);
        }

        private void hosOutButton_MouseEnter(object sender, EventArgs e)
        {
            mouseEnter(HosOutBtn);
        }

        private void hosOutButton_MouseLeave(object sender, EventArgs e)
        {
            mouseLeave(HosOutBtn);
        }
        private void hosStriedanieButton_MouseEnter(object sender, EventArgs e)
        {
            mouseEnter(HosStriedanieBtn);
        }

        private void hosStriedanieButton_MouseLeave(object sender, EventArgs e)
        {
            mouseLeave(HosStriedanieBtn);
        }


        private void domKopyButton_MouseEnter(object sender, EventArgs e)
        {
            mouseEnter(DomKopyBtn);
        }

        private void domKopyButton_MouseLeave(object sender, EventArgs e)
        {
            mouseLeave(DomKopyBtn);
        }

        private void udalostiButton_MouseEnter(object sender, EventArgs e)
        {
            UdalostiBtn.BackColor = Color.FromArgb(0, 192, 192);
        }

        private void udalostiButton_MouseLeave(object sender, EventArgs e)
        {
            UdalostiBtn.BackColor = Color.FromArgb(128, 255, 255);
        }

        private void vypnutVideoButton_MouseEnter(object sender, EventArgs e)
        {
            VypnutVideoBtn.BackColor = Color.Red;
        }

        private void vypnutVideoButton_MouseLeave(object sender, EventArgs e)
        {
            VypnutVideoBtn.BackColor = Color.FromArgb(255, 128, 128);
        }

        private void reklamaButton_MouseEnter(object sender, EventArgs e)
        {
            ReklamaBtn.BackColor = Color.FromArgb(0, 192, 192);
        }

        private void reklamaButton_MouseLeave(object sender, EventArgs e)
        {
            ReklamaBtn.BackColor = Color.FromArgb(128, 255, 255);
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
