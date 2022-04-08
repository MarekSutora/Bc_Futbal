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
        }

        private void PotvrdGol()
        {
            if (OnGoalSettingsConfirmed != null)
            {
                gol.TypGolu = PenaltaCheckBox.Checked ? 2 : 1;
                gol.NazovTimu = domaci ? zapas.NazovDomaci : zapas.NazovHostia;
                if (futbalovyTim == null)
                {

                    zapas.Udalosti.Add(gol);
                    uspech = true;
                    OnGoalSettingsConfirmed(null, domaci, stav + 1);
                }
                else
                {
                    bool strielajuciOznaceny = false;
                    if (HraciLB.SelectedIndex != -1)
                    {
                        gol.Strielajuci = zoznamHracov[HraciLB.SelectedIndex];
                        strielajuciOznaceny = true;
                    }

                    if (AsistHraciLB.SelectedIndex != -1)
                        gol.Asistujuci = zoznamHracov[AsistHraciLB.SelectedIndex];

                    gol.IdFutbalovyTim = futbalovyTim.IdFutbalovyTim;
                    zapas.Udalosti.Add(gol);
                    uspech = true;
                    if (strielajuciOznaceny)
                        OnGoalSettingsConfirmed(zoznamHracov[HraciLB.SelectedIndex], domaci, stav + 1);
                    else
                        OnGoalSettingsConfirmed(null, domaci, stav + 1);
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
                    OnGoalSettingsConfirmed?.Invoke(null, domaci, 0);
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
            OnGoalValueConfirmed?.Invoke(domaci, hodnota);
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

        private void OdznacVsetko(object sender, EventArgs e)
        {
            AsistHraciLB.ClearSelected();
            HraciLB.ClearSelected();
        }

        private void GolSettingsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (uspech && OnUdalostPridana != null)
                OnUdalostPridana("GÓl PRIDANÝ DO UDALOSTÍ");
        }
    }
}
