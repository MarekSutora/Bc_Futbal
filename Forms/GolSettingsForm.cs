using LGR_Futbal.Properties;
using LGR_Futbal.Triedy;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LGR_Futbal.Model;

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
        private FutbalovyTim t;
        private bool priznak;
        private int stav;
        private Zapas zapas = null;
        private FutbalovyTim futbalovyTim = null;
        private List<Hrac> hrajuci = null;
        private bool nadstavenyCas = false;
        private int nadstavenaMinuta = 0;
        private int lastIndex = -1;
        private int minuta = -1;
        private int polcas = -1;
        private DateTime cas;

        #endregion

        #region Konstruktor a metody

        public GolSettingsForm(FutbalovyTim tim, bool domaciPriznak, int aktualneSkore, Zapas zapas, bool nadstavenyCas, int nadstavenaMinuta, int minuta, int polcas)
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
            this.zapas = zapas;
            futbalovyTim = tim;
            cas = DateTime.Now;
            this.nadstavenaMinuta = nadstavenaMinuta;
            this.nadstavenyCas = nadstavenyCas;
            this.minuta = minuta;
            this.polcas = polcas;

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
                        if (!h.CisloDresu.Equals(string.Empty))
                        {
                            hraciLB.Items.Add(h.CisloDresu + ". " + h.Meno + " " + h.Priezvisko.ToUpper());
                            asistHraciLB.Items.Add(h.CisloDresu + ". " + h.Meno + " " + h.Priezvisko.ToUpper());
                        }   
                        else
                        {
                            hraciLB.Items.Add(h.Meno + " " + h.Priezvisko.ToUpper());
                            asistHraciLB.Items.Add(h.Meno + " " + h.Priezvisko.ToUpper());
                        }         
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
                    //hraciLB.SelectedIndex = 0;
                    potvrditButton.Enabled = true;
                }
            }
        }

        private void potvrdGol()
        {
            if (OnGoalSettingsConfirmed != null)
            {
                if (t == null)
                {
                    OnGoalSettingsConfirmed(null, priznak, stav + 1);
                }    
                else
                {
                    if (hraciLB.SelectedIndex != -1)
                    {
                        Gol gol = new Gol();
                        gol.Strielajuci = zoznam[hraciLB.SelectedIndex];
                        if(asistHraciLB.SelectedIndex != -1)
                        {
                            gol.Asistujuci = zoznam[asistHraciLB.SelectedIndex];
                        }
                        gol.TypGolu = checkBox1.Checked ? 2 : 1;
                        gol.Minuta = minuta;
                        gol.NadstavenaMinuta = nadstavenaMinuta;
                        gol.Predlzenie = nadstavenyCas ? 1 : 0;
                        gol.Polcas = polcas;
                        gol.AktualnyCas = cas;
                        zapas.Udalosti.Add(gol);
                        OnGoalSettingsConfirmed(zoznam[hraciLB.SelectedIndex], priznak, stav + 1);
                    } 
                    else
                    {
                        MessageBox.Show("Nevybrali ste strelca gólu!", nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }      
                }
                    
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                asistHraciLB.SelectedIndex = -1;
                asistHraciLB.Enabled = false;
            } else
            {
                asistHraciLB.Enabled = true;
            }
        }
    }
}
