using LGR_Futbal.Properties;
using LGR_Futbal.Triedy;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LGR_Futbal.Forms
{
    public delegate void StriedanieHraciSelectedHandler(string nazovTimu, Hrac odchadzajuci, Hrac nastupujuci, bool jeDomaciTim);

    public partial class StriedanieSettingsForm : Form
    {
        #region Atributy

        public event StriedanieHraciSelectedHandler OnStriedanieHraciSelected;
        private string nazov;
        private Tim spracovavanyTim;
        private List<Hrac> odchMoznosti;
        private List<Hrac> nastMoznosti;
        private bool domaciTim;

        #endregion

        #region Konstruktor a metody

        public StriedanieSettingsForm(Tim tim, string nazovTimu, bool jeDomaci)
        {
            InitializeComponent();

            if (Settings.Default.Jazyk == 1)
            {
                this.Text = "Střídání - nastavení";
                label1.Text = "Odcházející hráč:";
                label2.Text = "Nastupující hráč:";
                potvrditButton.Text = "Potvrdit";
                backButton.Text = "Návrat zpět";
            }

            domaciTim = jeDomaci;
            spracovavanyTim = tim;
            nazov = nazovTimu;

            odchMoznosti = new List<Hrac>();
            nastMoznosti = new List<Hrac>();

            if (spracovavanyTim != null)
            {
                foreach(Hrac h in spracovavanyTim.ZoznamHracov)
                {
                    if (!h.CervenaKarta)
                    {
                        if ((h.HraAktualnyZapas) && (!h.Nahradnik))
                        {
                            odchMoznosti.Add(h);
                            if (!h.CisloHraca.Equals(string.Empty))
                                hraciLBodch.Items.Add(h.CisloHraca.ToString() + ". " + h.Meno + " " + h.Priezvisko.ToUpper());
                            else
                                hraciLBodch.Items.Add(h.Meno + " " + h.Priezvisko.ToUpper());
                        }
                        else if ((!h.HraAktualnyZapas) && (h.Nahradnik))
                        {
                            nastMoznosti.Add(h);
                            if (!h.CisloHraca.Equals(string.Empty))
                                hraciLBnast.Items.Add(h.CisloHraca.ToString() + ". " + h.Meno + " " + h.Priezvisko.ToUpper());
                            else
                                hraciLBnast.Items.Add(h.Meno + " " + h.Priezvisko.ToUpper());
                        }
                    }
                }
            }

            if (hraciLBodch.Items.Count > 0)
                hraciLBodch.SelectedIndex = 0;

            if (hraciLBnast.Items.Count > 0)
                hraciLBnast.SelectedIndex = 0;

            if (tim == null)
                potvrditButton.Enabled = true;
            else
            {
                if ((odchMoznosti.Count > 0) && (nastMoznosti.Count > 0))
                    potvrditButton.Enabled = true;
                else
                    potvrditButton.Enabled = false;
            }
        }

        private void PotvrditButton_Click(object sender, EventArgs e)
        {
            if (OnStriedanieHraciSelected != null)
            {
                if (spracovavanyTim == null)
                    OnStriedanieHraciSelected(nazov, null, null, domaciTim);
                else
                {
                    Hrac h1 = odchMoznosti[hraciLBodch.SelectedIndex];
                    Hrac h2 = nastMoznosti[hraciLBnast.SelectedIndex];
                    OnStriedanieHraciSelected(nazov, h1, h2, domaciTim);
                }
            }
            this.Close();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void StriedanieSettingsForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        #endregion
    }
}
