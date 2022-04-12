using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using LGR_Futbal.Model;

namespace LGR_Futbal.Forms
{
    public partial class OffsideSettingsForm : Form
    {
        public event UdalostPridanaHandler OnUdalostPridana;

        private bool domaci = false;
        private bool uspech = false;
        private List<Hrac> zoznamHracov = null;
        private FutbalovyTim futbalovyTim = null;
        private Zapas zapas = null;
        private Offside offside = null;

        public OffsideSettingsForm(FutbalovyTim tim, Zapas zapas, bool domaci, Offside offside)
        {
            InitializeComponent();
            this.zapas = zapas;
            this.futbalovyTim = tim;
            this.domaci = domaci;
            this.offside = offside;

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
        }
        private void PotvrdOffside()
        {
            if (HraciLB.SelectedIndex >= 0)
            {
                offside.Hrac = zoznamHracov[HraciLB.SelectedIndex];
            }
            offside.NazovTimu = domaci ? zapas.NazovDomaci : zapas.NazovHostia;
            offside.IdFutbalovyTim = futbalovyTim != null ? futbalovyTim.IdFutbalovyTim : 0;
            zapas.Udalosti.Add(offside);
            uspech = true;
            Close();
        }
        private void PotvrditBtn_Click(object sender, EventArgs e)
        {
            PotvrdOffside();
        }
        private void SpatBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void HraciLB_DoubleClick(object sender, EventArgs e)
        {

            if (HraciLB.SelectedIndex >= 0)
                PotvrdOffside();
        }

        private void OffsideSettingsForm_Click(object sender, EventArgs e)
        {
            HraciLB.ClearSelected();
        }

        private void OffsideSettingsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (uspech && OnUdalostPridana != null && Screen.AllScreens.Length != 1)
                OnUdalostPridana("OFFSIDE ÚSPEŠNE PRIDANÝ");
        }


    }
}
