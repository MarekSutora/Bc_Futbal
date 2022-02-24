using LGR_Futbal.Properties;
using System;
using System.Windows.Forms;

namespace LGR_Futbal.Forms
{
    public delegate void ZmenaCasuHandler(int novaMin, int novaSek);

    public partial class ZmenaCasuForm : Form
    {
        public event ZmenaCasuHandler OnZmenaCasu;

        #region Konstruktor a metody

        public ZmenaCasuForm(int m, int s, int dlzka)
        {
            InitializeComponent();

            if (Settings.Default.Jazyk == 1)
            {
                this.Text = "Změna aktuálního času";
                label1.Text = "Minuta:";
                label2.Text = "Vteřina:";
                potvrditButton.Text = "Potvrdit";
                backButton.Text = "Návrat zpět";
            }

            minuta.Minimum = 0;
            minuta.Maximum = 2 * dlzka;
            minuta.Value = m;

            sekunda.Minimum = 0;
            sekunda.Maximum = 59;
            sekunda.Value = s;
            
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void potvrditButton_Click(object sender, EventArgs e)
        {
            int nm = (int)minuta.Value;
            int ns = (int)sekunda.Value;
            if (minuta.Value == minuta.Maximum)
            {
                ns = 0;
            }
            if (OnZmenaCasu != null)
                OnZmenaCasu(nm, ns);
            this.Close();
        }

        private void ZmenaCasuForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        #endregion

        private void minuta_ValueChanged(object sender, EventArgs e)
        {
            if (minuta.Value == minuta.Maximum)
            {
                sekunda.Enabled = false;
                sekunda.Value = 0;
            } else
            {
                sekunda.Enabled = true;
            }
        }
    }
}
