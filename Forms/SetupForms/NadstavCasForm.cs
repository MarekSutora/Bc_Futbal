using System;
using System.Windows.Forms;
using LGR_Futbal.Model;

namespace LGR_Futbal.Forms
{
    public delegate void NadstavenyCasConfirmedHandler(int hodnota);

    public partial class NadstavCasForm : Form
    {
        public event NadstavenyCasConfirmedHandler OnNadstavenyCasPotvrdeny;

        private int polcas = -1;
        private Zapas zapas = null;

        public NadstavCasForm(int aktualnaHodnota, int polcas, Zapas zapas)
        {
            InitializeComponent();
            this.zapas = zapas;
            this.polcas = polcas;

            dlzkaNadCasuNumUpDown.Value = aktualnaHodnota;
        }

        private void AktivovatBtn_Click(object sender, EventArgs e)
        {
            int novaHodnota = (int)dlzkaNadCasuNumUpDown.Value;
            if (polcas == 1)
            {
                zapas.NadstavenyCas1 = novaHodnota;
            }
            else if (polcas == 2)
            {
                zapas.NadstavenyCas2 = novaHodnota;
            }
            OnNadstavenyCasPotvrdeny?.Invoke(novaHodnota);
            Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int hodnota = (int)dlzkaNadCasuNumUpDown.Value;
            hodnota = (hodnota * 10) + 1;
            if (hodnota <= dlzkaNadCasuNumUpDown.Maximum)
                dlzkaNadCasuNumUpDown.Value = hodnota;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            int hodnota = (int)dlzkaNadCasuNumUpDown.Value;
            hodnota = (hodnota * 10) + 2;
            if (hodnota <= dlzkaNadCasuNumUpDown.Maximum)
                dlzkaNadCasuNumUpDown.Value = hodnota;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            int hodnota = (int)dlzkaNadCasuNumUpDown.Value;
            hodnota = (hodnota * 10) + 3;
            if (hodnota <= dlzkaNadCasuNumUpDown.Maximum)
                dlzkaNadCasuNumUpDown.Value = hodnota;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            int hodnota = (int)dlzkaNadCasuNumUpDown.Value;
            hodnota = (hodnota * 10) + 4;
            if (hodnota <= dlzkaNadCasuNumUpDown.Maximum)
                dlzkaNadCasuNumUpDown.Value = hodnota;
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            int hodnota = (int)dlzkaNadCasuNumUpDown.Value;
            hodnota = (hodnota * 10) + 5;
            if (hodnota <= dlzkaNadCasuNumUpDown.Maximum)
                dlzkaNadCasuNumUpDown.Value = hodnota;
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            int hodnota = (int)dlzkaNadCasuNumUpDown.Value;
            hodnota = (hodnota * 10) + 6;
            if (hodnota <= dlzkaNadCasuNumUpDown.Maximum)
                dlzkaNadCasuNumUpDown.Value = hodnota;
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            int hodnota = (int)dlzkaNadCasuNumUpDown.Value;
            hodnota = (hodnota * 10) + 7;
            if (hodnota <= dlzkaNadCasuNumUpDown.Maximum)
                dlzkaNadCasuNumUpDown.Value = hodnota;
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            int hodnota = (int)dlzkaNadCasuNumUpDown.Value;
            hodnota = (hodnota * 10) + 8;
            if (hodnota <= dlzkaNadCasuNumUpDown.Maximum)
                dlzkaNadCasuNumUpDown.Value = hodnota;
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            int hodnota = (int)dlzkaNadCasuNumUpDown.Value;
            hodnota = (hodnota * 10) + 9;
            if (hodnota <= dlzkaNadCasuNumUpDown.Maximum)
                dlzkaNadCasuNumUpDown.Value = hodnota;
        }

        private void Button0_Click(object sender, EventArgs e)
        {
            int hodnota = (int)dlzkaNadCasuNumUpDown.Value;
            hodnota = (hodnota * 10);
            if (hodnota <= dlzkaNadCasuNumUpDown.Maximum)
                dlzkaNadCasuNumUpDown.Value = hodnota;
        }

        private void ZmazatBtn_Click(object sender, EventArgs e)
        {
            int hodnota = (int)dlzkaNadCasuNumUpDown.Value;
            hodnota = hodnota / 10;
            dlzkaNadCasuNumUpDown.Value = hodnota;
        }
    }
}
