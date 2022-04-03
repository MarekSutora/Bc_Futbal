using LGR_Futbal.Properties;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LGR_Futbal.Model;

namespace LGR_Futbal.Forms.UdalostiForms
{
    public delegate void GoalSettingsConfirmedHandler(Hrac h, bool priznak, int novyStav);
    public delegate void GoalValueConfirmedHandler(bool domPriznak, int hodnota);

    public partial class GolSettingsForm : Form
    {
        public event GoalSettingsConfirmedHandler OnGoalSettingsConfirmed;
        public event GoalValueConfirmedHandler OnGoalValueConfirmed;
        public event UdalostPridanaHandler OnUdalostPridana;

        private bool domaci = false;
        private int stav;
        private bool uspech = false;
        private List<Hrac> zoznamHracov = null;
        private FutbalovyTim futbalovyTim = null;
        private Zapas zapas = null;
        private Gol gol = null;

        #region Konstruktor a metody
        public GolSettingsForm(FutbalovyTim tim, bool domaci, int aktualneSkore, Zapas zapas, Gol gol)
        {
            InitializeComponent();            

            futbalovyTim = tim;
            this.domaci = domaci;
            stav = aktualneSkore;
            HodnotaNumericUpDown.Value = stav;
            this.zapas = zapas;
            this.gol = gol;

            if (stav == 0)
            {
                ZnizitSkoreBtn.Enabled = false;
                ResetSkoreBtn.Enabled = false;
            }

            zoznamHracov = new List<Hrac>();
            if (tim != null)
            {
                AsistHraciLB.Items.Add("");
                foreach (Hrac h in tim.ZoznamHracov)
                {
                    if ((h.HraAktualnyZapas) && (!h.Nahradnik) && (!h.CervenaKarta))
                    {
                        zoznamHracov.Add(h);
                        if (!h.CisloDresu.Equals(string.Empty))
                        {
                            HraciLB.Items.Add(h.CisloDresu + ". " + h.Meno + " " + h.Priezvisko.ToUpper());
                            AsistHraciLB.Items.Add(h.CisloDresu + ". " + h.Meno + " " + h.Priezvisko.ToUpper());
                        }   
                        else
                        {
                            HraciLB.Items.Add(h.Meno + " " + h.Priezvisko.ToUpper());
                            AsistHraciLB.Items.Add(h.Meno + " " + h.Priezvisko.ToUpper());
                        }         
                    }
                }
            }

            if (tim == null)
                PotvrditBtn.Enabled = true;
            else
            {
                if (zoznamHracov.Count == 0)
                    PotvrditBtn.Enabled = false;
                else
                {
                    HraciLB.SelectedIndex = 0;
                    PotvrditBtn.Enabled = true;
                }
            }
        }

        private void PotvrdGol()
        {
            if (OnGoalSettingsConfirmed != null)
            {
                if (futbalovyTim == null)
                {
                    gol.TypGolu = PenaltaCheckBox.Checked ? 2 : 1;
                    gol.NazovTimu = domaci ? zapas.NazovDomaci : zapas.NazovHostia;
                    
                    zapas.Udalosti.Add(gol);
                    uspech = true;
                    OnGoalSettingsConfirmed(null, domaci, stav + 1);
                }    
                else
                {
                    if (HraciLB.SelectedIndex != -1)
                    {
                        gol.Strielajuci = zoznamHracov[HraciLB.SelectedIndex];
                        if(AsistHraciLB.SelectedIndex != -1 && AsistHraciLB.SelectedIndex != 0)
                        {
                            gol.Asistujuci = zoznamHracov[AsistHraciLB.SelectedIndex - 1];
                        }
                        gol.TypGolu = PenaltaCheckBox.Checked ? 2 : 1;
                        gol.NazovTimu = domaci ? zapas.NazovDomaci : zapas.NazovHostia;
                        gol.IdFutbalovyTim = futbalovyTim.IdFutbalovyTim;
                        zapas.Udalosti.Add(gol);
                        uspech = true;
                        OnGoalSettingsConfirmed(zoznamHracov[HraciLB.SelectedIndex], domaci, stav + 1);
                    } 
                    else
                    {
                        MessageBox.Show("Nevybrali ste strelca gólu!", "Úprava skóre", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }      
                }
                    
            }
            Close();
        }
        private void PotvrditBtn_Click(object sender, EventArgs e)
        {
            PotvrdGol();
        }
        private void ZnizitSkoreBtn_Click(object sender, EventArgs e)
        {
            if (stav > 0)
            {
                OnGoalSettingsConfirmed?.Invoke(null, domaci, stav - 1);
            }
            Close();
        }
        private void ResetSkoreBtn_Click(object sender, EventArgs e)
        {
            if (stav > 0)
            {
                if (MessageBox.Show("Naozaj chcete resetovať skóre?", "Úprava skóre", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (OnGoalSettingsConfirmed != null)
                        OnGoalSettingsConfirmed(null, domaci, 0);
                }
            }
            Close();
        }
        private void SpatBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void HraciLB_DoubleClick(object sender, EventArgs e)
        {
            if (HraciLB.SelectedIndex >= 0)
                PotvrdGol();
        }
        private void NastavitBtn_Click(object sender, EventArgs e)
        {
            int hodnota = (int)HodnotaNumericUpDown.Value;
            if (OnGoalValueConfirmed != null)
                OnGoalValueConfirmed(domaci, hodnota);
            Close();
        }
        private void PenaltaCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (PenaltaCheckBox.Checked)
            {
                AsistHraciLB.SelectedIndex = -1;
                AsistHraciLB.Enabled = false;
            }
            else
            {
                AsistHraciLB.Enabled = true;
            }
        }
        private void GolSettingsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (uspech && OnUdalostPridana != null)
                OnUdalostPridana("GÓl PRIDANÝ DO UDALOSTÍ");
        }
        #endregion    
    }
}
