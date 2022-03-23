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

            if (Settings.Default.Jazyk == 1)
            {
                this.Text = "Barvy prezentace";
                saveButton.Text = "Uložit   ";
                zrusitButton.Text = "Zavřít   ";

                button1.Text = "Změnit";
                button2.Text = "Změnit";
                button3.Text = "Změnit";
                button4.Text = "Změnit";
                button5.Text = "Změnit";
                button6.Text = "Změnit";
                button7.Text = "Změnit";
                button8.Text = "Změnit";
                button9.Text = "Změnit";
                button10.Text = "Změnit";

                label4.Text = "Číslo hráče:";
                label7.Text = "Číslo hráče:";
                label5.Text = "Jméno hráče:";
                label6.Text = "Jméno hráče:";
            }

            d = dom;
            h = hos;

            label1.ForeColor = d.NadpisFarba(); 
            label10.ForeColor = h.NadpisFarba();

            label2.ForeColor = d.ZakladFarba();
            label9.ForeColor = h.ZakladFarba();

            label3.ForeColor = d.UdajeFarba();
            label8.ForeColor = h.UdajeFarba();

            label4.ForeColor = d.CisloFarba();
            label7.ForeColor = h.CisloFarba();

            label5.ForeColor = d.MenoFarba();
            label6.ForeColor = h.MenoFarba();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            d.setNadpis(label1.ForeColor);
            d.setZaklad(label2.ForeColor);
            d.setUdaje(label3.ForeColor);
            d.setCislo(label4.ForeColor);
            d.setMeno(label5.ForeColor);

            h.setNadpis(label10.ForeColor);
            h.setZaklad(label9.ForeColor);
            h.setUdaje(label8.ForeColor);
            h.setCislo(label7.ForeColor);
            h.setMeno(label6.ForeColor);

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
                label1.ForeColor = cd.Color;
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
