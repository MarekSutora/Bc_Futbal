using System;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using LGR_Futbal.Setup;

namespace LGR_Futbal.Forms
{
    public partial class RozlozenieForm : Form
    {
        public event ZmenaRozlozeniaHandler OnZmenaRozlozenia;

        private string adresar;
        private int sirka;
        private int vyska;
        private RozlozenieTabule rozlozenieTabule = null;

        public RozlozenieForm(int sirka, int vyska, TabulaForm tf)
        {
            InitializeComponent();

            toolTip1.SetToolTip(CasXNumeric, "Zvyšovanie - doprava \nZnižovanie - doľava");
            toolTip1.SetToolTip(PolcasXNumeric, "Zvyšovanie - doprava \nZnižovanie - doľava");
            toolTip1.SetToolTip(SkoreDomaciXNumeric, "Zvyšovanie - doprava \nZnižovanie - doľava");
            toolTip1.SetToolTip(SkoreHostiaXNumeric, "Zvyšovanie - doprava \nZnižovanie - doľava");
            toolTip1.SetToolTip(DomaciXNumeric, "Zvyšovanie - doprava \nZnižovanie - doľava");
            toolTip1.SetToolTip(HostiaXNumeric, "Zvyšovanie - doprava \nZnižovanie - doľava");
            toolTip1.SetToolTip(LogoDomaciXNumeric, "Zvyšovanie - doprava \nZnižovanie - doľava");
            toolTip1.SetToolTip(LogoHostiaXNumeric, "Zvyšovanie - doprava \nZnižovanie - doľava");

            toolTip1.SetToolTip(CasYNumeric, "Zvyšovanie - dole \nZnižovanie - hore");
            toolTip1.SetToolTip(PolcasYNumeric, "Zvyšovanie - dole \nZnižovanie - hore");
            toolTip1.SetToolTip(SkoreDomaciYNumeric, "Zvyšovanie - dole \nZnižovanie - hore");
            toolTip1.SetToolTip(SkoreHostiaYNumeric, "Zvyšovanie - dole \nZnižovanie - hore");
            toolTip1.SetToolTip(DomaciYNumeric, "Zvyšovanie - dole \nZnižovanie - hore");
            toolTip1.SetToolTip(HostiaYNumeric, "Zvyšovanie - dole \nZnižovanie - hore");
            toolTip1.SetToolTip(LogoDomaciYNumeric, "Zvyšovanie - dole \nZnižovanie - hore");
            toolTip1.SetToolTip(LogoHostiaYNumeric, "Zvyšovanie - dole \nZnižovanie - hore");

            adresar = Directory.GetCurrentDirectory() + "\\Files\\RozlozenieNastavenia";
            this.sirka = sirka;
            this.vyska = vyska;
            rozlozenieTabule = tf.GetRozlozenie();
            NastavRozlozenie();
        }

        private void NastavRozlozenie()
        {
            CasXNumeric.Value = rozlozenieTabule.Cas_X;
            CasYNumeric.Value = rozlozenieTabule.Cas_Y;
            CasSirkaNumeric.Value = rozlozenieTabule.Cas_Sirka;

            DomaciXNumeric.Value = rozlozenieTabule.DomaciNazov_X;
            DomaciYNumeric.Value = rozlozenieTabule.DomaciNazov_Y;
            DomaciSirkaNumeric.Value = rozlozenieTabule.DomaciNazov_Sirka;

            HostiaXNumeric.Value = rozlozenieTabule.HostiaNazov_X;
            HostiaYNumeric.Value = rozlozenieTabule.HostiaNazov_Y;
            HostiaSirkaNumeric.Value = rozlozenieTabule.HostiaNazov_Sirka;

            SkoreDomaciXNumeric.Value = rozlozenieTabule.DomaciSkore_X;
            SkoreDomaciYNumeric.Value = rozlozenieTabule.DomaciSkore_Y;
            SkoreDomaciSirkaNumeric.Value = rozlozenieTabule.DomaciSkore_Sirka;

            SkoreHostiaXNumeric.Value = rozlozenieTabule.HostiaSkore_X;
            SkoreHostiaYNumeric.Value = rozlozenieTabule.HostiaSkore_Y;
            SkoreHostiaSirkaNumeric.Value = rozlozenieTabule.HostiaSkore_Sirka;

            LogoDomaciXNumeric.Value = rozlozenieTabule.LogoDomaci_X;
            LogoDomaciYNumeric.Value = rozlozenieTabule.LogoDomaci_Y;
            LogoDomaciSirkaNumeric.Value = rozlozenieTabule.LogoDomaci_Sirka;
            domaciLogoCB.Checked = rozlozenieTabule.LogoDomaci_Zobrazit;

            LogoHostiaXNumeric.Value = rozlozenieTabule.LogoHostia_X;
            LogoHostiaYNumeric.Value = rozlozenieTabule.LogoHostia_Y;
            LogoHostiaSirkaNumeric.Value = rozlozenieTabule.LogoHostia_Sirka;
            hostiaLogoCB.Checked = rozlozenieTabule.LogoHostia_Zobrazit;

            PolcasXNumeric.Value = rozlozenieTabule.Polcas_X;
            PolcasYNumeric.Value = rozlozenieTabule.Polcas_Y;
            PolcasSirkaNumeric.Value = rozlozenieTabule.Polcas_Sirka;
        }

        private void AktivovatBtn_Click(object sender, EventArgs e)
        {
            if (OnZmenaRozlozenia != null)
            {
                rozlozenieTabule.Cas_X = (int)CasXNumeric.Value;
                rozlozenieTabule.Cas_Y = (int)CasYNumeric.Value;
                rozlozenieTabule.Cas_Sirka = (int)CasSirkaNumeric.Value;

                rozlozenieTabule.DomaciNazov_X = (int)DomaciXNumeric.Value;
                rozlozenieTabule.DomaciNazov_Y = (int)DomaciYNumeric.Value;
                rozlozenieTabule.DomaciNazov_Sirka = (int)DomaciSirkaNumeric.Value;

                rozlozenieTabule.HostiaNazov_X = (int)HostiaXNumeric.Value;
                rozlozenieTabule.HostiaNazov_Y = (int)HostiaYNumeric.Value;
                rozlozenieTabule.HostiaNazov_Sirka = (int)HostiaSirkaNumeric.Value;

                rozlozenieTabule.DomaciSkore_X = (int)SkoreDomaciXNumeric.Value;
                rozlozenieTabule.DomaciSkore_Y = (int)SkoreDomaciYNumeric.Value;
                rozlozenieTabule.DomaciSkore_Sirka = (int)SkoreDomaciSirkaNumeric.Value;

                rozlozenieTabule.HostiaSkore_X = (int)SkoreHostiaXNumeric.Value;
                rozlozenieTabule.HostiaSkore_Y = (int)SkoreHostiaYNumeric.Value;
                rozlozenieTabule.HostiaSkore_Sirka = (int)SkoreHostiaSirkaNumeric.Value;

                rozlozenieTabule.LogoDomaci_X = (int)LogoDomaciXNumeric.Value;
                rozlozenieTabule.LogoDomaci_Y = (int)LogoDomaciYNumeric.Value;
                rozlozenieTabule.LogoDomaci_Sirka = (int)LogoDomaciSirkaNumeric.Value;
                rozlozenieTabule.LogoDomaci_Zobrazit = domaciLogoCB.Checked;

                rozlozenieTabule.LogoHostia_X = (int)LogoHostiaXNumeric.Value;
                rozlozenieTabule.LogoHostia_Y = (int)LogoHostiaYNumeric.Value;
                rozlozenieTabule.LogoHostia_Sirka = (int)LogoHostiaSirkaNumeric.Value;
                rozlozenieTabule.LogoHostia_Zobrazit = hostiaLogoCB.Checked;

                rozlozenieTabule.Polcas_X = (int)PolcasXNumeric.Value;
                rozlozenieTabule.Polcas_Y = (int)PolcasYNumeric.Value;
                rozlozenieTabule.Polcas_Sirka = (int)PolcasSirkaNumeric.Value;
                OnZmenaRozlozenia?.Invoke(rozlozenieTabule);
            }

        }

        private void UlozitBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = adresar;
            sfd.Filter = "xml files (*.xml)|*.xml";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                TextWriter textWriter = null;

                try
                {
                    RozlozenieTabule rt = new RozlozenieTabule();
                    rt.Cas_X = (int)CasXNumeric.Value;
                    rt.Cas_Y = (int)CasYNumeric.Value;
                    rt.Cas_Sirka = (int)CasSirkaNumeric.Value;

                    rt.DomaciNazov_X = (int)DomaciXNumeric.Value;
                    rt.DomaciNazov_Y = (int)DomaciYNumeric.Value;
                    rt.DomaciNazov_Sirka = (int)DomaciSirkaNumeric.Value;

                    rt.HostiaNazov_X = (int)HostiaXNumeric.Value;
                    rt.HostiaNazov_Y = (int)HostiaYNumeric.Value;
                    rt.HostiaNazov_Sirka = (int)HostiaSirkaNumeric.Value;

                    rt.DomaciSkore_X = (int)SkoreDomaciXNumeric.Value;
                    rt.DomaciSkore_Y = (int)SkoreDomaciYNumeric.Value;
                    rt.DomaciSkore_Sirka = (int)SkoreDomaciSirkaNumeric.Value;

                    rt.HostiaSkore_X = (int)SkoreHostiaXNumeric.Value;
                    rt.HostiaSkore_Y = (int)SkoreHostiaYNumeric.Value;
                    rt.HostiaSkore_Sirka = (int)SkoreHostiaSirkaNumeric.Value;

                    rt.LogoDomaci_X = (int)LogoDomaciXNumeric.Value;
                    rt.LogoDomaci_Y = (int)LogoDomaciYNumeric.Value;
                    rt.LogoDomaci_Sirka = (int)LogoDomaciSirkaNumeric.Value;
                    rt.LogoDomaci_Zobrazit = domaciLogoCB.Checked;

                    rt.LogoHostia_X = (int)LogoHostiaXNumeric.Value;
                    rt.LogoHostia_Y = (int)LogoHostiaYNumeric.Value;
                    rt.LogoHostia_Sirka = (int)LogoHostiaSirkaNumeric.Value;
                    rt.LogoHostia_Zobrazit = hostiaLogoCB.Checked;

                    rt.Polcas_X = (int)PolcasXNumeric.Value;
                    rt.Polcas_Y = (int)PolcasYNumeric.Value;
                    rt.Polcas_Sirka = (int)PolcasSirkaNumeric.Value;

                    XmlSerializer serializer = new XmlSerializer(typeof(RozlozenieTabule));
                    textWriter = new StreamWriter(sfd.FileName);
                    serializer.Serialize(textWriter, rt);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "LGR_Futbal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (textWriter != null)
                        textWriter.Close();

                    Close();
                }
            }
        }

        private void NacitatBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            ofd.InitialDirectory = adresar;
            ofd.Filter = "xml files (*.xml)|*.xml";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                RozlozenieTabule rt = null;
                TextReader textReader = null;
                bool uspech = true;
                try
                {

                    XmlSerializer deserializer = new XmlSerializer(typeof(RozlozenieTabule));
                    textReader = new StreamReader(ofd.FileName);
                    rt = (RozlozenieTabule)deserializer.Deserialize(textReader);
                }
                catch (Exception ex)
                {
                    uspech = false;
                    MessageBox.Show(ex.Message, "LGR_Futbal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (textReader != null)
                        textReader.Close();

                    if (uspech)
                    {
                        rozlozenieTabule = rt;
                        NastavRozlozenie();
                        OnZmenaRozlozenia?.Invoke(rozlozenieTabule);
                    }
                }
            }
        }

        private void ObnovitBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Naozaj chcete obnoviť výrobné nastavenia rozloženia?", "FutbalApp", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                rozlozenieTabule.NativneRozlozenie(sirka, vyska);

                NastavRozlozenie();

                OnZmenaRozlozenia?.Invoke(rozlozenieTabule);
            }
        }
    }
}
