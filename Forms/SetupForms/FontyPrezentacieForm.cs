using LGR_Futbal.Setup;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace LGR_Futbal.Forms
{
    public partial class FontyPrezentacieForm : Form
    {
        private FontyTabule fontyTabule = null;
        public FontyPrezentacieForm(FontyTabule fonty)
        {
            InitializeComponent();

            fontyTabule = fonty;

            nazvyFontLabel.Text = fontyTabule.NazvyPrezentaciaFont;
            podnadpisFontLabel.Text = fontyTabule.PodnadpisPrezentaciaFont;
            udajeFontLabel.Text = fontyTabule.UdajePrezentaciaFont;
            cisloMenoFontLabel.Text = fontyTabule.CisloMenoPrezentaciaFont;
        }
        private void AktivovatBtn_Click(object sender, EventArgs e)
        {
            fontyTabule.NazvyPrezentaciaFont = nazvyFontLabel.Text;
            fontyTabule.PodnadpisPrezentaciaFont = podnadpisFontLabel.Text;
            fontyTabule.UdajePrezentaciaFont = udajeFontLabel.Text;
            fontyTabule.CisloMenoPrezentaciaFont = cisloMenoFontLabel.Text;

            Close();
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
        private void ZmenitPodnadpisBtn_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            fd.Font = ConvertStringToFont(podnadpisFontLabel.Text);
            if (fd.ShowDialog() == DialogResult.OK)
                podnadpisFontLabel.Text = ConvertFontToString(fd.Font);
        }
        private void ZmenitUdajeBtn_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            fd.Font = ConvertStringToFont(udajeFontLabel.Text);
            if (fd.ShowDialog() == DialogResult.OK)
                udajeFontLabel.Text = ConvertFontToString(fd.Font);
        }
        private void ZmenitCisloMenoBtn_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            fd.Font = ConvertStringToFont(cisloMenoFontLabel.Text);
            if (fd.ShowDialog() == DialogResult.OK)
                cisloMenoFontLabel.Text = ConvertFontToString(fd.Font);
        }       
    }
}
