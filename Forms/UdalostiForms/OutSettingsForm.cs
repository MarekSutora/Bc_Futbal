using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BC_Futbal.Model;

namespace BC_Futbal.Forms
{

    public partial class OutSettingsForm : Form
    {
        public event UdalostPridanaHandler OnUdalostPridana;

        private bool domaci = false;
        private bool uspech = false;
        private List<Hrac> zoznamHracov = null;
        private FutbalovyTim futbalovyTim = null;
        private Zapas zapas = null;
        private Out _out = null;

        public OutSettingsForm(FutbalovyTim tim, Zapas zapas, bool domaci, Out _out)
        {
            InitializeComponent();
            this.zapas = zapas;
            futbalovyTim = tim;
            this.domaci = domaci;
            this._out = _out;

            zoznamHracov = new List<Hrac>();
            if (tim != null)
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
        private void PotvrdOut()
        {
            if (HraciLB.SelectedIndex >= 0)
            {
                _out.Hrac = zoznamHracov[HraciLB.SelectedIndex];
            }
            _out.NazovTimu = domaci ? zapas.NazovDomaci : zapas.NazovHostia;
            _out.IdFutbalovyTim = futbalovyTim != null ? futbalovyTim.IdFutbalovyTim : 0;
            zapas.Udalosti.Add(_out);
            uspech = true;
            Close();
        }

        private void PotvrditBtn_Click(object sender, EventArgs e)
        {
            PotvrdOut();
        }

        private void SpatBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void HraciLB_DoubleClick(object sender, EventArgs e)
        {
            if (HraciLB.SelectedIndex >= 0)
                PotvrdOut();
        }

        private void OutSettingsForm_Click(object sender, EventArgs e)
        {
            HraciLB.ClearSelected();
        }

        private void OutSettingsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (uspech && OnUdalostPridana != null && Screen.AllScreens.Length != 1)
                OnUdalostPridana("OUT ÚSPEŠNE PRIDANÝ");
        }


    }
}
