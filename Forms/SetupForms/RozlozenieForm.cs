using System;
using System.Windows.Forms;
using LGR_Futbal.Setup;
using System.Xml.Serialization;
using System.IO;

namespace LGR_Futbal.Forms
{
    public partial class RozlozenieForm : Form
    {
        public event ZmenaRozlozeniaHandler OnZmenaRozlozenia;

        private string adresar;
        private int sirka;
        private int vyska;
        private RozlozenieTabule rozlozenieTabule = null;

        public RozlozenieForm(RozlozenieTabule rt, int sirka, int vyska)
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
            rozlozenieTabule = rt;
            NastavRozlozenie();
        }

        private void NastavRozlozenie()
        {
            CasXNumeric.Value = rozlozenieTabule.Cas_X;
            CasYNumeric.Value = rozlozenieTabule.Cas_Y;

            DomaciXNumeric.Value = rozlozenieTabule.Domaci_X;
            DomaciYNumeric.Value = rozlozenieTabule.Domaci_Y;

            HostiaXNumeric.Value = rozlozenieTabule.Hostia_X;
            HostiaYNumeric.Value = rozlozenieTabule.Hostia_Y;

            SkoreDomaciXNumeric.Value = rozlozenieTabule.DomaciSkore_X;
            SkoreDomaciYNumeric.Value = rozlozenieTabule.DomaciSkore_Y;

            SkoreHostiaXNumeric.Value = rozlozenieTabule.HostiaSkore_X;
            SkoreHostiaYNumeric.Value = rozlozenieTabule.HostiaSkore_Y;

            LogoDomaciXNumeric.Value = rozlozenieTabule.LogoDomaci_X;
            LogoDomaciYNumeric.Value = rozlozenieTabule.LogoDomaci_Y;
            LogoDomaciSirkaNumeric.Value = rozlozenieTabule.LogoDomaciSirka;
            domaciLogoCB.Checked = rozlozenieTabule.LogoDomaciZobrazit;

            LogoHostiaXNumeric.Value = rozlozenieTabule.LogoHostia_X;
            LogoHostiaYNumeric.Value = rozlozenieTabule.LogoHostia_Y;
            LogoHostiaSirkaNumeric.Value = rozlozenieTabule.LogoHostiaSirka;
            hostiaLogoCB.Checked = rozlozenieTabule.LogoHostiaZobrazit;

            PolcasXNumeric.Value = rozlozenieTabule.Polcas_X;
            PolcasYNumeric.Value = rozlozenieTabule.Polcas_Y;
        }

        private void AktivovatBtn_Click(object sender, EventArgs e)
        {
            if (OnZmenaRozlozenia != null)
            {
                rozlozenieTabule.Cas_X = (int)CasXNumeric.Value;
                rozlozenieTabule.Cas_Y = (int)CasYNumeric.Value;

                rozlozenieTabule.Domaci_X = (int)DomaciXNumeric.Value;
                rozlozenieTabule.Domaci_Y = (int)DomaciYNumeric.Value;

                rozlozenieTabule.Hostia_X = (int)HostiaXNumeric.Value;
                rozlozenieTabule.Hostia_Y = (int)HostiaYNumeric.Value;

                rozlozenieTabule.DomaciSkore_X = (int)SkoreDomaciXNumeric.Value;
                rozlozenieTabule.DomaciSkore_Y = (int)SkoreDomaciYNumeric.Value;

                rozlozenieTabule.HostiaSkore_X = (int)SkoreHostiaXNumeric.Value;
                rozlozenieTabule.HostiaSkore_Y = (int)SkoreHostiaYNumeric.Value;

                rozlozenieTabule.LogoDomaci_X = (int)LogoDomaciXNumeric.Value;
                rozlozenieTabule.LogoDomaci_Y = (int)LogoDomaciYNumeric.Value;
                rozlozenieTabule.LogoDomaciSirka = (int)LogoDomaciSirkaNumeric.Value;
                rozlozenieTabule.LogoDomaciZobrazit = domaciLogoCB.Checked;

                rozlozenieTabule.LogoHostia_X = (int)LogoHostiaXNumeric.Value;
                rozlozenieTabule.LogoHostia_Y = (int)LogoHostiaYNumeric.Value;
                rozlozenieTabule.LogoHostiaSirka = (int)LogoHostiaSirkaNumeric.Value;
                rozlozenieTabule.LogoHostiaZobrazit = hostiaLogoCB.Checked;

                rozlozenieTabule.Polcas_X = (int)PolcasXNumeric.Value;
                rozlozenieTabule.Polcas_Y = (int)PolcasYNumeric.Value;
                OnZmenaRozlozenia?.Invoke();
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

                    rt.Domaci_X = (int)DomaciXNumeric.Value;
                    rt.Domaci_Y = (int)DomaciYNumeric.Value;

                    rt.Hostia_X = (int)HostiaXNumeric.Value;
                    rt.Hostia_Y = (int)HostiaYNumeric.Value;

                    rt.DomaciSkore_X = (int)SkoreDomaciXNumeric.Value;
                    rt.DomaciSkore_Y = (int)SkoreDomaciYNumeric.Value;

                    rt.HostiaSkore_X = (int)SkoreHostiaXNumeric.Value;
                    rt.HostiaSkore_Y = (int)SkoreHostiaYNumeric.Value;

                    rt.LogoDomaci_X = (int)LogoDomaciXNumeric.Value;
                    rt.LogoDomaci_Y = (int)LogoDomaciYNumeric.Value;
                    rt.LogoDomaciSirka = (int)LogoDomaciSirkaNumeric.Value;
                    rt.LogoDomaciZobrazit = domaciLogoCB.Checked;

                    rt.LogoHostia_X = (int)LogoHostiaXNumeric.Value;
                    rt.LogoHostia_Y = (int)LogoHostiaYNumeric.Value;
                    rt.LogoHostiaSirka = (int)LogoHostiaSirkaNumeric.Value;
                    rt.LogoHostiaZobrazit = hostiaLogoCB.Checked;

                    rt.Polcas_X = (int)PolcasXNumeric.Value;
                    rt.Polcas_Y = (int)PolcasYNumeric.Value;

                    XmlSerializer serializer = new XmlSerializer(typeof(RozlozenieTabule));
                    textWriter = new StreamWriter(sfd.FileName);
                    serializer.Serialize(textWriter, rt);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "FutbalApp", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show(ex.Message, "FutbalApp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (textReader != null)
                        textReader.Close();

                    if (uspech)
                    {
                        rozlozenieTabule = rt;
                        NastavRozlozenie();
                        OnZmenaRozlozenia?.Invoke();
                    }
                }
            }
        }

        private void ObnovitBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Naozaj chcete obnoviť výrobné nastavenia rozloženia?", "FutbalApp", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                rozlozenieTabule.NativneRozlozenie(sirka, vyska);

                CasXNumeric.Value = rozlozenieTabule.Cas_X;
                CasYNumeric.Value = rozlozenieTabule.Cas_Y;

                DomaciXNumeric.Value = rozlozenieTabule.Domaci_X;
                DomaciYNumeric.Value = rozlozenieTabule.Domaci_Y;

                HostiaXNumeric.Value = rozlozenieTabule.Hostia_X;
                HostiaYNumeric.Value = rozlozenieTabule.Hostia_Y;

                SkoreDomaciXNumeric.Value = rozlozenieTabule.DomaciSkore_X;
                SkoreDomaciYNumeric.Value = rozlozenieTabule.DomaciSkore_Y;

                SkoreHostiaXNumeric.Value = rozlozenieTabule.HostiaSkore_X;
                SkoreHostiaYNumeric.Value = rozlozenieTabule.HostiaSkore_Y;

                LogoDomaciXNumeric.Value = rozlozenieTabule.LogoDomaci_X;
                LogoDomaciYNumeric.Value = rozlozenieTabule.LogoDomaci_Y;
                LogoDomaciSirkaNumeric.Value = rozlozenieTabule.LogoDomaciSirka;
                domaciLogoCB.Checked = rozlozenieTabule.LogoDomaciZobrazit;

                LogoHostiaXNumeric.Value = rozlozenieTabule.LogoHostia_X;
                LogoHostiaYNumeric.Value = rozlozenieTabule.LogoHostia_Y;
                LogoHostiaSirkaNumeric.Value = rozlozenieTabule.LogoHostiaSirka;
                hostiaLogoCB.Checked = rozlozenieTabule.LogoHostiaZobrazit;

                PolcasXNumeric.Value = rozlozenieTabule.Polcas_X;
                PolcasYNumeric.Value = rozlozenieTabule.Polcas_Y;

                OnZmenaRozlozenia?.Invoke();
            } 
        }
    }
}
