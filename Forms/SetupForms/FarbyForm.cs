using LGR_Futbal.Properties;
using LGR_Futbal.Setup;
using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Drawing;

namespace LGR_Futbal.Forms
{
    public delegate void FileSavedHandler(string s);
    public delegate void ObnovaFariebHandlerFF();
    public delegate void ColorsLoadedHandlerFF(FarbyTabule fs);
    public delegate void FileSelectedHandlerFF(string cesta);

    public partial class FarbyForm : Form
    {
        private string adresar;
        public event ObnovaFariebHandlerFF OnObnovaFariebFF;
        public event ColorsLoadedHandlerFF OnColorsLoadedFF;
        private FarbyTabule fs = null;

        public FarbyForm(string adresar, FarbyTabule fs)
        {
            InitializeComponent();

            this.fs = fs;
            this.adresar = adresar;

            DomaciLabel.ForeColor = fs.GetNadpisDomFarba();
            HostiaLabel.ForeColor = fs.GetNadpisHosFarba();
            CasLabel.ForeColor = fs.GetCasFarba();
            SkoreLabel.ForeColor = fs.GetSkoreFarba();
            PolcasLabel.ForeColor = fs.GetPolcasFarba();
        }

        private void AktivovatFarbyButton_Click(object sender, EventArgs e)
        {
            fs.CasFarba_r = CasLabel.ForeColor.R;
            fs.CasFarba_g = CasLabel.ForeColor.G;
            fs.CasFarba_b = CasLabel.ForeColor.B;

            fs.NadpisDomFarba_r = DomaciLabel.ForeColor.R;
            fs.NadpisDomFarba_g = DomaciLabel.ForeColor.G;
            fs.NadpisDomFarba_b = DomaciLabel.ForeColor.B;

            fs.NadpisHosFarba_r = HostiaLabel.ForeColor.R;
            fs.NadpisHosFarba_g = HostiaLabel.ForeColor.G;
            fs.NadpisHosFarba_b = HostiaLabel.ForeColor.B;

            fs.SkoreFarba_r = SkoreLabel.ForeColor.R;
            fs.SkoreFarba_g = SkoreLabel.ForeColor.G;
            fs.SkoreFarba_b = SkoreLabel.ForeColor.B;

            fs.PolcasFarba_r = PolcasLabel.ForeColor.R;
            fs.PolcasFarba_g = PolcasLabel.ForeColor.G;
            fs.PolcasFarba_b = PolcasLabel.ForeColor.B;

            if (OnColorsLoadedFF != null)
            {
                OnColorsLoadedFF(fs);
            }
            Close();
        }

        private void UlozitFarbyButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = adresar;
            sfd.Filter = "xml files (*.xml)|*.xml";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                TextWriter textWriter = null;

                try
                {
                    FarbyTabule sch = new FarbyTabule();
                    sch.SetNadpisDomFarba(DomaciLabel.ForeColor);
                    sch.SetNadpisHosFarba(HostiaLabel.ForeColor);
                    sch.SetCasFarba(CasLabel.ForeColor);
                    sch.SetSkoreFarba(SkoreLabel.ForeColor);
                    sch.SetPolcasFarba(PolcasLabel.ForeColor);

                    XmlSerializer serializer = new XmlSerializer(typeof(FarbyTabule));
                    textWriter = new StreamWriter(sfd.FileName);
                    serializer.Serialize(textWriter, sch);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "FutbalApp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (textWriter != null)
                        textWriter.Close();
                }
            }
        }

        private void NacitatFarbyButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            ofd.InitialDirectory = adresar;
            ofd.Filter = "xml files (*.xml)|*.xml";
            if (ofd.ShowDialog() == DialogResult.OK)
                NacitajFarby(ofd.FileName);
        }

        private void ObnovitFarbyButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Naozaj chcete obnoviť výrobné nastavenia farieb?", "LGR Futbal", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (OnObnovaFariebFF != null)
                    OnObnovaFariebFF();
                //this.Close();
            }

            CasLabel.ForeColor = Color.Lime;

            DomaciLabel.ForeColor = Color.Aqua;

            HostiaLabel.ForeColor = Color.Aqua;

            SkoreLabel.ForeColor = Color.Red;

            PolcasLabel.ForeColor = Color.Lime;
        }

        private void ZmenitFarbaDomaciBtn_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
                DomaciLabel.ForeColor = cd.Color;
        }

        private void ZmenitFarbaHostiaBtn_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
                HostiaLabel.ForeColor = cd.Color;
        }

        private void ZmenitFarbaCasBtn_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
                CasLabel.ForeColor = cd.Color;
        }

        private void ZmenitFarbaSkoreBtn_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
                SkoreLabel.ForeColor = cd.Color;
        }

        private void ZmenitFarbaPolcasBtn_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
                PolcasLabel.ForeColor = cd.Color;
        }

        private void FarbyForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
        private void NacitajFarby(string cesta)
        {
            TextReader textReader = null;
            bool uspech = true;
            FarbyTabule schema = null;

            try
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(FarbyTabule));
                textReader = new StreamReader(cesta);
                schema = (FarbyTabule)deserializer.Deserialize(textReader);
            }
            catch (Exception ex)
            {
                uspech = false;
                MessageBox.Show(ex.Message, "LGR futbal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (textReader != null)
                    textReader.Close();

                if (uspech)
                {
                    CasLabel.ForeColor = Color.FromArgb(schema.CasFarba_r, schema.CasFarba_g, schema.CasFarba_b);

                    DomaciLabel.ForeColor = Color.FromArgb(schema.NadpisDomFarba_r, schema.NadpisDomFarba_g, schema.NadpisDomFarba_b);

                    HostiaLabel.ForeColor = Color.FromArgb(schema.NadpisHosFarba_r, schema.NadpisHosFarba_g, schema.NadpisHosFarba_b);

                    SkoreLabel.ForeColor = Color.FromArgb(schema.SkoreFarba_r, schema.SkoreFarba_g, schema.SkoreFarba_b);

                    PolcasLabel.ForeColor = Color.FromArgb(schema.PolcasFarba_r, schema.PolcasFarba_g, schema.PolcasFarba_b);

                    if (OnColorsLoadedFF != null)
                        OnColorsLoadedFF(schema);

                }
            }
        }
    }
}
