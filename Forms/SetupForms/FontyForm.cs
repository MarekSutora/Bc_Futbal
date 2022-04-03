using LGR_Futbal.Setup;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;

namespace LGR_Futbal.Forms
{
    public partial class FontyForm : Form
    {
        public event ZmenaFontovHandler OnZmenaFontov;

        private string adresar;
        private FontyTabule fontyTabule = null;
        public FontyForm(string adresar, FontyTabule fonty)
        {
            InitializeComponent();

            fontyTabule = fonty;
            this.adresar = adresar;
            nazvyFontLabel.Text = fontyTabule.NazvyFont;
            skoreFontLabel.Text = fontyTabule.SkoreFont;
            casFontLabel.Text = fontyTabule.CasFont;
            polcasFontLabel.Text = fontyTabule.PolcasFont;
            striedanieFontLabel.Text = fontyTabule.StriedaniaFont;
        }

        private void AktivovatBtn_Click(object sender, EventArgs e)
        {
            fontyTabule.NazvyFont = nazvyFontLabel.Text;
            fontyTabule.SkoreFont = skoreFontLabel.Text;
            fontyTabule.CasFont = casFontLabel.Text;
            fontyTabule.PolcasFont = polcasFontLabel.Text;
            fontyTabule.StriedaniaFont = striedanieFontLabel.Text;

            OnZmenaFontov?.Invoke();

            Close();
        }
        private void NacitatBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            ofd.InitialDirectory = adresar;
            ofd.Filter = "xml files (*.xml)|*.xml";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                FontyTabule ft = null;
                TextReader textReader = null;
                bool uspech = true;
                try
                {
                    XmlSerializer deserializer = new XmlSerializer(typeof(FontyTabule));
                    textReader = new StreamReader(ofd.FileName);
                    ft = (FontyTabule)deserializer.Deserialize(textReader);
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
                        fontyTabule = ft;
                        nazvyFontLabel.Text = fontyTabule.NazvyFont;
                        skoreFontLabel.Text = fontyTabule.SkoreFont;
                        casFontLabel.Text = fontyTabule.CasFont;
                        polcasFontLabel.Text = fontyTabule.PolcasFont;
                        striedanieFontLabel.Text = fontyTabule.StriedaniaFont;
                        OnZmenaFontov?.Invoke();
                    }
                }
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
                bool uspech = true;
                try
                {
                    fontyTabule.NazvyFont = nazvyFontLabel.Text;
                    fontyTabule.SkoreFont = skoreFontLabel.Text;
                    fontyTabule.CasFont = casFontLabel.Text;
                    fontyTabule.PolcasFont = polcasFontLabel.Text;
                    fontyTabule.StriedaniaFont = striedanieFontLabel.Text;

                    XmlSerializer serializer = new XmlSerializer(typeof(FontyTabule));
                    textWriter = new StreamWriter(sfd.FileName);
                    serializer.Serialize(textWriter, fontyTabule);
                }
                catch (Exception ex)
                {
                    uspech = false;
                    MessageBox.Show(ex.Message, "FutbalApp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (textWriter != null)
                        textWriter.Close();

                    if (uspech)
                    {
                        OnZmenaFontov?.Invoke();
                    }
                    Close();
                }
            }
        }
        private void ObnovitBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Naozaj chcete obnoviť výrobné nastavenia rozloženia?", "FutbalApp", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                nazvyFontLabel.Text = "Arial; 53,25pt; style=Bold";
                skoreFontLabel.Text = "Arial; 147pt; style=Bold";
                casFontLabel.Text = "Arial; 147pt; style=Bold";
                polcasFontLabel.Text = "Arial; 66pt";
                striedanieFontLabel.Text = "Arial; 48pt";

                fontyTabule.NazvyFont = nazvyFontLabel.Text;
                fontyTabule.SkoreFont = skoreFontLabel.Text;
                fontyTabule.CasFont = casFontLabel.Text;
                fontyTabule.PolcasFont = polcasFontLabel.Text;
                fontyTabule.StriedaniaFont = striedanieFontLabel.Text;

                OnZmenaFontov?.Invoke();
            }
        }
        private string ConvertFontToString(Font f)
        {
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
            return converter.ConvertToString(f);
        }
        private Font ConvertStringToFont(string s)
        {
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
            return (Font)converter.ConvertFromString(s);
        }
        private void ZmenitNazvyBtn_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            fd.Font = ConvertStringToFont(nazvyFontLabel.Text);
            if (fd.ShowDialog() == DialogResult.OK)
                nazvyFontLabel.Text = ConvertFontToString(fd.Font);
        }
        private void ZmenitSkoreBtn_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            fd.Font = ConvertStringToFont(skoreFontLabel.Text);
            if (fd.ShowDialog() == DialogResult.OK)
                skoreFontLabel.Text = ConvertFontToString(fd.Font);
        }
        private void ZmenitCasBtn_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            fd.Font = ConvertStringToFont(casFontLabel.Text);
            if (fd.ShowDialog() == DialogResult.OK)
                casFontLabel.Text = ConvertFontToString(fd.Font);
        }
        private void ZmenitPolcasBtn_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            fd.Font = ConvertStringToFont(polcasFontLabel.Text);
            if (fd.ShowDialog() == DialogResult.OK)
                polcasFontLabel.Text = ConvertFontToString(fd.Font);
        }
        private void ZmenitStriedanieBtn_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            fd.Font = ConvertStringToFont(striedanieFontLabel.Text);
            if (fd.ShowDialog() == DialogResult.OK)
                striedanieFontLabel.Text = ConvertFontToString(fd.Font);
        }
    }
}
