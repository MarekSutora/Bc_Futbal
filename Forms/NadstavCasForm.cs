﻿using LGR_Futbal.Properties;
using System;
using System.Windows.Forms;

namespace LGR_Futbal.Forms
{
    public delegate void NadstavenyCasConfirmedHandler(int hodnota);

    public partial class NadstavCasForm : Form
    {
        public event NadstavenyCasConfirmedHandler OnNadstavenyCasConfirmed;

        public NadstavCasForm(int aktualnaHodnota)
        {
            InitializeComponent();

            if (Settings.Default.Jazyk == 1)
            {
                this.Text = "Nastavení času";
                aktivovatButton.Text = aktivovatButton.Text.Replace("Uložiť", "Uložit");
                aktivovatButton.Text = aktivovatButton.Text.Replace("zmeny", "změny");
                zrusitButton.Text = zrusitButton.Text.Replace("Zrušiť", "Zrušit");

                label1.Text = "Nastavený čas [min]:";
                label2.Text = "Aktuální nastavený čas se přepíše, nepřipočítává se !!!";
            }

            dlzkaNadCasuNumUpDown.Value = aktualnaHodnota;
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

        private void Button10_Click(object sender, EventArgs e)
        {
            int hodnota = (int)dlzkaNadCasuNumUpDown.Value;
            hodnota = (hodnota * 10);
            if (hodnota <= dlzkaNadCasuNumUpDown.Maximum)
                dlzkaNadCasuNumUpDown.Value = hodnota;
        }

        private void Button11_Click(object sender, EventArgs e)
        {
            int hodnota = (int)dlzkaNadCasuNumUpDown.Value;
            hodnota = hodnota / 10;
            dlzkaNadCasuNumUpDown.Value = hodnota;
        }

        private void AktivovatButton_Click(object sender, EventArgs e)
        {
            int novaHodnota = (int)dlzkaNadCasuNumUpDown.Value;
            if (OnNadstavenyCasConfirmed != null)
                OnNadstavenyCasConfirmed(novaHodnota);
            this.Close();
        }

        private void ZrusitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NadstavCasForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}