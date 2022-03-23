using LGR_Futbal.Properties;
using LGR_Futbal.Setup;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;

namespace LGR_Futbal.Forms
{
    public delegate void FontsConfirmedHandler();
    public delegate void FontStriedaniaSelectedHandler(Font f);

    public partial class FontyForm : Form
    {
        private string adresa;
        public FontyTabule pisma { get; set; }
        //private Font striedaciFont;

        public event FontsConfirmedHandler OnFontsConfirmed;
        //public event FontStriedaniaSelectedHandler OnFontStriedaniaSelected;

        public FontyForm(string adresa, FontyTabule fonts)
        {
            InitializeComponent();

            if (Settings.Default.Jazyk == 1)
            {
                this.Text = "Nastavení fontů";
                aktivovatButton.Text = aktivovatButton.Text.Replace("Uložiť", "Uložit");
                aktivovatButton.Text = aktivovatButton.Text.Replace("zmeny", "změny");
                zrusitButton.Text = zrusitButton.Text.Replace("Zrušiť", "Zrušit");

                button1.Text = "Změnit";
                button2.Text = "Změnit";
                button3.Text = "Změnit";
                button4.Text = "Změnit";
                button5.Text = "Změnit";

                label1.Text = "Názvy týmů:";
                label4.Text = "Poločas:";
                label11.Text = "Střídání hráčů:";
            }

            pisma = fonts;
            this.adresa = adresa;
            label5.Text = pisma.NazvyFont;
            label6.Text = pisma.SkoreFont;
            label7.Text = pisma.CasFont;
            label8.Text = pisma.PolcasFont;
            label9.Text = pisma.StriedaniaFont;
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

        private void aktivovatButton_Click(object sender, EventArgs e)
        {
            pisma.NazvyFont = label5.Text;
            pisma.SkoreFont = label6.Text;
            pisma.CasFont = label7.Text;
            pisma.PolcasFont = label8.Text;
            pisma.StriedaniaFont = label9.Text;

            if (OnFontsConfirmed != null)
                OnFontsConfirmed();
            Close();
        }

        private void zrusitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            fd.Font = convertStringToFont(label5.Text);
            if (fd.ShowDialog() == DialogResult.OK)
                label5.Text = convertFontToString(fd.Font);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            fd.Font = convertStringToFont(label6.Text);
            if (fd.ShowDialog() == DialogResult.OK)
                label6.Text = convertFontToString(fd.Font);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            fd.Font = convertStringToFont(label7.Text);
            if (fd.ShowDialog() == DialogResult.OK)
                label7.Text = convertFontToString(fd.Font);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            fd.Font = convertStringToFont(label8.Text);
            if (fd.ShowDialog() == DialogResult.OK)
                label8.Text = convertFontToString(fd.Font);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            fd.Font = convertStringToFont(label9.Text);
            if (fd.ShowDialog() == DialogResult.OK)
                label9.Text = convertFontToString(fd.Font);
        }

        private void FontyFormForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void ulozitFonty_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = adresa;
            sfd.Filter = "xml files (*.xml)|*.xml";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                TextWriter textWriter = null;
                bool uspech = true;

                try
                {
                    pisma.NazvyFont = label5.Text;
                    pisma.SkoreFont = label6.Text;
                    pisma.CasFont = label7.Text;
                    pisma.PolcasFont = label8.Text;
                    pisma.StriedaniaFont = label9.Text;

                    FontyTabule ft = new FontyTabule();
                    ft.StriedaniaFont = pisma.StriedaniaFont;
                    ft.NazvyFont = pisma.NazvyFont;
                    ft.PolcasFont = pisma.PolcasFont;
                    ft.SkoreFont = pisma.SkoreFont;
                    ft.CasFont = pisma.CasFont;

                    XmlSerializer serializer = new XmlSerializer(typeof(FontyTabule));
                    textWriter = new StreamWriter(sfd.FileName);
                    serializer.Serialize(textWriter, ft);
                }
                catch (Exception ex)
                {
                    uspech = false;
                    MessageBox.Show(ex.Message, "LGR Futbal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (textWriter != null)
                        textWriter.Close();

                    if (uspech)
                    {

                    }
                    this.Close();
                }
            }
        }

        private void nacitatFonty_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            ofd.InitialDirectory = adresa;
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
                    MessageBox.Show(ex.Message, "LGR Futbal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (textReader != null)
                        textReader.Close();

                    if (uspech)
                    {
                        pisma = ft;
                        label5.Text = pisma.NazvyFont;
                        label6.Text = pisma.SkoreFont;
                        label7.Text = pisma.CasFont;
                        label8.Text = pisma.PolcasFont;
                        label9.Text = pisma.StriedaniaFont;
                        if (OnFontsConfirmed != null)
                            OnFontsConfirmed();
                    }
                }
            }
        }

        private void obnovaFontovButton_Click(object sender, EventArgs e)
        {
            label5.Text = "Arial; 53,25pt; style=Bold";
            label6.Text = "Arial; 147pt; style=Bold";
            label7.Text = "Arial; 147pt; style=Bold";
            label8.Text = "Arial; 66pt";
            label9.Text = "Arial; 48pt";

            pisma.NazvyFont = label5.Text;
            pisma.SkoreFont = label6.Text;
            pisma.CasFont = label7.Text;
            pisma.PolcasFont = label8.Text;
            pisma.StriedaniaFont = label9.Text;

            if (OnFontsConfirmed != null)
                OnFontsConfirmed();
        }
    }
}
