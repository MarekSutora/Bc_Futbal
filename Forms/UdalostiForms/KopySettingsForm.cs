using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using LGR_Futbal.Model;

namespace LGR_Futbal.Forms.UdalostiForms
{
    public partial class KopySettingsForm : Form
    {
        public event UdalostPridanaHandler OnUdalostPridana;

        private bool domaci = false;
        private bool uspech = false;
        private List<Hrac> zoznamHracov = null;
        private FutbalovyTim futbalovyTim = null;
        private Zapas zapas = null;
        private Kop kop = null;

        public KopySettingsForm(FutbalovyTim tim, Zapas zapas,  bool domaci, Kop kop)
        {
            InitializeComponent();
            this.Text = "Kop";
            this.zapas = zapas;
            this.futbalovyTim = tim;
            this.domaci = domaci;
            this.kop = kop;

            zoznamHracov = new List<Hrac>();
            if (futbalovyTim != null)
            {
                for (int i = 0; i < tim.ZoznamHracov.Count; i++)
                {
                    Hrac h = tim.ZoznamHracov[i];
                    if (h.HraAktualnyZapas && !h.CervenaKarta)
                    {
                        zoznamHracov.Add(h);
                        if (!h.CisloDresu.Equals(string.Empty))
                        {
                            HraciLB.Items.Add(h.CisloDresu + ". " + h.Meno + " " + h.Priezvisko.ToUpper());
                        }
                        else
                        {
                            HraciLB.Items.Add(h.Meno + " " + h.Priezvisko.ToUpper());
                        }
                    }
                }
            }
            if (futbalovyTim == null)
                PotvrditButton.Enabled = true;
            else
            {
                if (zoznamHracov.Count == 0)
                    PotvrditButton.Enabled = false;
                else
                {
                    PotvrditButton.Enabled = true;
                }
            }
        }
        private void PotvrdKop()
        {
            Hrac hrac = new Hrac();
            if (HraciLB.SelectedIndex >= 0)
            {
                hrac = zoznamHracov[HraciLB.SelectedIndex];
            }
            kop.Hrac = hrac;
            kop.NazovTimu = domaci ? zapas.NazovDomaci : zapas.NazovHostia;
            kop.IdFutbalovyTim = futbalovyTim != null ? futbalovyTim.IdFutbalovyTim : 0;
            if (PriamyRB.Checked)
            {
                kop.IdTypKopu = 1;
            }
            else if (NepriamyRB.Checked)
            {
                kop.IdTypKopu = 2;
            }
            else if (RohovyRB.Checked)
            {
                kop.IdTypKopu = 3;
            }
            else
            {
                kop.IdTypKopu = 4;
            }
            zapas.Udalosti.Add(kop);
            uspech = true;
            this.Close();
        }
        private void PotvrditBtn_Click(object sender, EventArgs e)
        {
            PotvrdKop();
        }
        private void SpatBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void HraciLB_DoubleClick(object sender, EventArgs e)
        {
            if (HraciLB.SelectedIndex >= 0)
                PotvrdKop();
        }
        private void KopySettingsForm_MouseClick(object sender, MouseEventArgs e)
        {
            HraciLB.ClearSelected();
        }
        private void KopySettingsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (uspech && OnUdalostPridana != null)
                OnUdalostPridana("KOP PRIDANÝ DO UDALOSTÍ");
        } 
    }
}
