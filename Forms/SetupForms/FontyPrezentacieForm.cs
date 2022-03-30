using LGR_Futbal.Properties;
using LGR_Futbal.Setup;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace LGR_Futbal.Forms
{
    public partial class FontyPrezentacieForm : Form
    {
        private FontyTabule pisma;

        public FontyPrezentacieForm(FontyTabule fonty)
        {
            InitializeComponent();

            pisma = fonty;

            label5.Text = pisma.NazvyPrezentaciaFont;
            label6.Text = pisma.PodnadpisPrezentaciaFont;
            label7.Text = pisma.UdajePrezentaciaFont;
            label8.Text = pisma.CisloMenoPrezentaciaFont;
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

        private void button1_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            fd.Font = ConvertStringToFont(label5.Text);
            if (fd.ShowDialog() == DialogResult.OK)
                label5.Text = ConvertFontToString(fd.Font);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            fd.Font = ConvertStringToFont(label6.Text);
            if (fd.ShowDialog() == DialogResult.OK)
                label6.Text = ConvertFontToString(fd.Font);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            fd.Font = ConvertStringToFont(label7.Text);
            if (fd.ShowDialog() == DialogResult.OK)
                label7.Text = ConvertFontToString(fd.Font);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            fd.Font = ConvertStringToFont(label8.Text);
            if (fd.ShowDialog() == DialogResult.OK)
                label8.Text = ConvertFontToString(fd.Font);
        }

        private void aktivovatButton_Click(object sender, EventArgs e)
        {
            pisma.NazvyPrezentaciaFont = label5.Text;
            pisma.PodnadpisPrezentaciaFont = label6.Text;
            pisma.UdajePrezentaciaFont = label7.Text;
            pisma.CisloMenoPrezentaciaFont = label8.Text;

            this.Close();
        }

        private void zrusitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FontyPrezentacieForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
