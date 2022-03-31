using LGR_Futbal.Setup;
using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Drawing;

namespace LGR_Futbal.Forms
{
    public partial class FarbyForm : Form
    {
        public event ObnovaFariebHandler OnObnovaFarieb;
        public event ZmenaFariebHandler OnZmenaFarieb;

        private string adresar;  
        private FarbyTabule farbyTabule = null;

        public FarbyForm(string adresar, FarbyTabule ft)
        {
            InitializeComponent();

            farbyTabule = ft;
            this.adresar = adresar;

            domaciLabel.ForeColor = farbyTabule.GetNadpisDomFarba();
            hostiaLabel.ForeColor = farbyTabule.GetNadpisHosFarba();
            casLabel.ForeColor = farbyTabule.GetCasFarba();
            skoreLabel.ForeColor = farbyTabule.GetSkoreFarba();
            polcasLabel.ForeColor = farbyTabule.GetPolcasFarba();
        }

        private void AktivovatBtn_Click(object sender, EventArgs e)
        {
            farbyTabule.CasFarba_r = casLabel.ForeColor.R;
            farbyTabule.CasFarba_g = casLabel.ForeColor.G;
            farbyTabule.CasFarba_b = casLabel.ForeColor.B;

            farbyTabule.NadpisDomFarba_r = domaciLabel.ForeColor.R;
            farbyTabule.NadpisDomFarba_g = domaciLabel.ForeColor.G;
            farbyTabule.NadpisDomFarba_b = domaciLabel.ForeColor.B;

            farbyTabule.NadpisHosFarba_r = hostiaLabel.ForeColor.R;
            farbyTabule.NadpisHosFarba_g = hostiaLabel.ForeColor.G;
            farbyTabule.NadpisHosFarba_b = hostiaLabel.ForeColor.B;

            farbyTabule.SkoreFarba_r = skoreLabel.ForeColor.R;
            farbyTabule.SkoreFarba_g = skoreLabel.ForeColor.G;
            farbyTabule.SkoreFarba_b = skoreLabel.ForeColor.B;

            farbyTabule.PolcasFarba_r = polcasLabel.ForeColor.R;
            farbyTabule.PolcasFarba_g = polcasLabel.ForeColor.G;
            farbyTabule.PolcasFarba_b = polcasLabel.ForeColor.B;

            OnZmenaFarieb?.Invoke();
            Close();
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
                    FarbyTabule sch = new FarbyTabule();
                    sch.SetNadpisDomFarba(domaciLabel.ForeColor);
                    sch.SetNadpisHosFarba(hostiaLabel.ForeColor);
                    sch.SetCasFarba(casLabel.ForeColor);
                    sch.SetSkoreFarba(skoreLabel.ForeColor);
                    sch.SetPolcasFarba(polcasLabel.ForeColor);

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

        private void NacitatBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            ofd.InitialDirectory = adresar;
            ofd.Filter = "xml files (*.xml)|*.xml";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                TextReader textReader = null;
                bool uspech = true;
                FarbyTabule schema = null;

                try
                {
                    XmlSerializer deserializer = new XmlSerializer(typeof(FarbyTabule));
                    textReader = new StreamReader(adresar);
                    schema = (FarbyTabule)deserializer.Deserialize(textReader);
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
                        casLabel.ForeColor = Color.FromArgb(schema.CasFarba_r, schema.CasFarba_g, schema.CasFarba_b);
                        domaciLabel.ForeColor = Color.FromArgb(schema.NadpisDomFarba_r, schema.NadpisDomFarba_g, schema.NadpisDomFarba_b);
                        hostiaLabel.ForeColor = Color.FromArgb(schema.NadpisHosFarba_r, schema.NadpisHosFarba_g, schema.NadpisHosFarba_b);
                        skoreLabel.ForeColor = Color.FromArgb(schema.SkoreFarba_r, schema.SkoreFarba_g, schema.SkoreFarba_b);
                        polcasLabel.ForeColor = Color.FromArgb(schema.PolcasFarba_r, schema.PolcasFarba_g, schema.PolcasFarba_b);

                        OnZmenaFarieb?.Invoke();
                    }
                }
            }
        }

        private void ObnovitBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Naozaj chcete obnoviť výrobné nastavenia farieb?", "FutbalApp", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                OnObnovaFarieb?.Invoke();
            }
            casLabel.ForeColor = Color.Lime;
            domaciLabel.ForeColor = Color.Aqua;
            hostiaLabel.ForeColor = Color.Aqua;
            skoreLabel.ForeColor = Color.Red;
            polcasLabel.ForeColor = Color.Lime;
        }

        private void ZmenitDomaciBtn_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
                domaciLabel.ForeColor = cd.Color;
        }

        private void ZmenitHostiaBtn_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
                hostiaLabel.ForeColor = cd.Color;
        }

        private void ZmenitCasBtn_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
                casLabel.ForeColor = cd.Color;
        }

        private void ZmenitSkoreBtn_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
                skoreLabel.ForeColor = cd.Color;
        }

        private void ZmenitPolcasBtn_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
                polcasLabel.ForeColor = cd.Color;
        }
    }
}
