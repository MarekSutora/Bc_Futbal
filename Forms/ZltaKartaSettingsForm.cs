using LGR_Futbal.Properties;
using LGR_Futbal.Triedy;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LGR_Futbal.Forms
{
    public delegate void HracZltaKartaSelectedHandler(Hrac hrac);

    public partial class ZltaKartaSettingsForm : Form
    {
        public event HracZltaKartaSelectedHandler OnHracZltaKartaSelected;
        private List<Hrac> zoznam;
        private Tim t;

        #region Konstruktor a metody

        public ZltaKartaSettingsForm(Tim tim)
        {
            InitializeComponent();
            
            if (Settings.Default.Jazyk == 1)
            {
                this.Text = "Žlutá karta - nastavení";
                potvrditButton.Text = "Potvrdit";
                backButton.Text = "Návrat zpět";
            }
                        
            t = tim;
            zoznam = new List<Hrac>();

            if (tim != null)
            {
                foreach (Hrac h in tim.ZoznamHracov)
                {
                    if ((h.HraAktualnyZapas) && (!h.Nahradnik) && (!h.CervenaKarta))
                    {
                        zoznam.Add(h);
                        if (!h.CisloHraca.Equals(string.Empty))
                            hraciLB.Items.Add(h.CisloHraca + ". " + h.Meno + " " + h.Priezvisko.ToUpper());
                        else
                            hraciLB.Items.Add(h.Meno + " " + h.Priezvisko.ToUpper());
                    }
                }
            }

            if (tim == null)
                potvrditButton.Enabled = true;
            else
            {
                if (zoznam.Count == 0)
                    potvrditButton.Enabled = false;
                else
                {
                    hraciLB.SelectedIndex = 0;
                    potvrditButton.Enabled = true;
                }
            }
        }

        private void potvrdKartu()
        {
            if (OnHracZltaKartaSelected != null)
            {
                if (t == null)
                    OnHracZltaKartaSelected(null);
                else
                    OnHracZltaKartaSelected(zoznam[hraciLB.SelectedIndex]);
            }

            this.Close();
        }

        private void PotvrditButton_Click(object sender, EventArgs e)
        {
            potvrdKartu();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void hraciLB_DoubleClick(object sender, EventArgs e)
        {
            if (hraciLB.SelectedIndex >= 0)
                potvrdKartu();
        }

        private void ZltaKartaSettingsForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        #endregion
    }
}
