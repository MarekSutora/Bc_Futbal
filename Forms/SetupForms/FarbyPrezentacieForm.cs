using LGR_Futbal.Properties;
using LGR_Futbal.Setup;
using System;
using System.Windows.Forms;

namespace LGR_Futbal.Forms
{
    public partial class FarbyPrezentacieForm : Form
    {
        private FarbyPrezentacie d;
        private FarbyPrezentacie h;

        public FarbyPrezentacieForm(FarbyPrezentacie dom, FarbyPrezentacie hos)
        {
            InitializeComponent();

            d = dom;
            h = hos;

            NadpisDomaciLabel.ForeColor = d.GetNadpisFarba(); 
            label10.ForeColor = h.GetNadpisFarba();

            label2.ForeColor = d.GetZakladFarba();
            label9.ForeColor = h.GetZakladFarba();

            label3.ForeColor = d.GetUdajeFarba();
            label8.ForeColor = h.GetUdajeFarba();

            label4.ForeColor = d.GetCisloFarba();
            label7.ForeColor = h.GetCisloFarba();

            label5.ForeColor = d.GetMenoFarba();
            label6.ForeColor = h.GetMenoFarba();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            d.SetNadpisFarba(NadpisDomaciLabel.ForeColor);
            d.SetZakladFarba(label2.ForeColor);
            d.SetUdajeFarba(label3.ForeColor);
            d.SetCisloFarba(label4.ForeColor);
            d.SetMenoFarba(label5.ForeColor);

            h.SetNadpisFarba(label10.ForeColor);
            h.SetZakladFarba(label9.ForeColor);
            h.SetUdajeFarba(label8.ForeColor);
            h.SetCisloFarba(label7.ForeColor);
            h.SetMenoFarba(label6.ForeColor);

            this.Close();
        }

        private void zrusitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
                NadpisDomaciLabel.ForeColor = cd.Color;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
                label2.ForeColor = cd.Color;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
                label3.ForeColor = cd.Color;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
                label4.ForeColor = cd.Color;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
                label5.ForeColor = cd.Color;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
                label6.ForeColor = cd.Color;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
                label7.ForeColor = cd.Color;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
                label8.ForeColor = cd.Color;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
                label9.ForeColor = cd.Color;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
                label10.ForeColor = cd.Color;
        }

        private void FarbyPrezentacieForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
