using LGR_Futbal.Properties;
using LGR_Futbal.Triedy;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LGR_Futbal.Forms
{
    public delegate void GoalSettingsConfirmedHandler(Hrac h, bool priznak, int novyStav);
    public delegate void GoalValueConfirmedHandler(bool domPriznak, int hodnota);

    public partial class GolSettingsForm : Form
    {
        #region Konstanty

        private const string nazovProgramuString = "Úprava skóre";

        #endregion

        #region Atributy

        public event GoalSettingsConfirmedHandler OnGoalSettingsConfirmed;
        public event GoalValueConfirmedHandler OnGoalValueConfirmed;

        private List<Hrac> zoznam;
        private Tim t;
        private bool priznak;
        private int stav;

        #endregion

        #region Konstruktor a metody

        public GolSettingsForm(Tim tim, bool domaciPriznak, int aktualneSkore)
        {
            InitializeComponent();
            
            if (Settings.Default.Jazyk == 1)
            {
                this.Text = "Gól - nastavení";
                potvrditButton.Text = "Potvrdit gól";
                znizitSkoreButton.Text = "Snížit skóre";
                resetSkoreButton.Text = "Resetovat skóre";
                button1.Text = "Nastavit";
                backButton.Text = "Návrat zpět";
            }
            
            t = tim;
            priznak = domaciPriznak;
            stav = aktualneSkore;
            numericUpDown1.Value = stav;

            if (stav == 0)
            {
                znizitSkoreButton.Enabled = false;
                resetSkoreButton.Enabled = false;
            }

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

        private void potvrdGol()
        {
            if (OnGoalSettingsConfirmed != null)
            {
                if (t == null)
                    OnGoalSettingsConfirmed(null, priznak, stav + 1);
                else
                    OnGoalSettingsConfirmed(zoznam[hraciLB.SelectedIndex], priznak, stav + 1);
            }

            this.Close();
        }

        private void PotvrditButton_Click(object sender, EventArgs e)
        {
            potvrdGol();
        }

        private void ZnizitSkoreButton_Click(object sender, EventArgs e)
        {
            if (stav > 0)
            {
                if (OnGoalSettingsConfirmed != null)
                    OnGoalSettingsConfirmed(null, priznak, stav - 1);
            }
            this.Close();
        }

        private void ResetSkoreButton_Click(object sender, EventArgs e)
        {
            if (stav > 0)
            {
                if (MessageBox.Show(Translate(1), nazovProgramuString, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (OnGoalSettingsConfirmed != null)
                        OnGoalSettingsConfirmed(null, priznak, 0);
                }
            }
            this.Close();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void hraciLB_DoubleClick(object sender, EventArgs e)
        {
            if (hraciLB.SelectedIndex >= 0)
                potvrdGol();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int hodnota = (int)numericUpDown1.Value;
            if (OnGoalValueConfirmed != null)
                OnGoalValueConfirmed(priznak, hodnota);
            this.Close();
        }

        private void GolSettingsForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private string Translate(int cisloVety)
        {
            if (Settings.Default.Jazyk == 0)
            {
                switch (cisloVety)
                {
                    case 1: return "Naozaj chcete resetovať skóre?";
                }
            }
            else if (Settings.Default.Jazyk == 1)
            {
                switch (cisloVety)
                {
                    case 1: return "Opravdu chcete resetovat skóre?";
                }
            }

            return string.Empty;
        }

        #endregion
    }
}
