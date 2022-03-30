using LGR_Futbal.Properties;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LGR_Futbal.Model;

namespace LGR_Futbal.Forms.UdalostiForms
{
    public delegate void HracCervenaKartaSelectedHandler(Hrac hrac);
    public partial class CervenaKartaSettingsForm : Form
    {
        public event HracCervenaKartaSelectedHandler OnHracCervenaKartaSelected;
        public event UdalostPridanaHandler OnUdalostPridana;

        private bool domaci = false;
        private List<Hrac> zoznamHracov = null;
        private FutbalovyTim futbalovyTim = null;
        private Zapas zapas = null;
        private Karta karta = null;
        private bool uspech = false;

        #region Konstruktor a metody

        public CervenaKartaSettingsForm(FutbalovyTim tim, Zapas zapas, bool domaci, Karta karta)
        {
            InitializeComponent();

            this.domaci = domaci;
            futbalovyTim = tim;
            zoznamHracov = new List<Hrac>();
            this.zapas = zapas;
            this.karta = karta;

            if (tim != null)
            {
                foreach (Hrac h in tim.ZoznamHracov)
                {
                    if ((h.HraAktualnyZapas) && (!h.Nahradnik) && (!h.CervenaKarta))
                    {
                        zoznamHracov.Add(h);
                        if (!h.CisloDresu.Equals(string.Empty))
                            HraciLB.Items.Add(h.CisloDresu + ". " + h.Meno + " " + h.Priezvisko.ToUpper());
                        else
                            HraciLB.Items.Add(h.Meno + " " + h.Priezvisko.ToUpper());
                    }
                }
            }

            if (tim == null)
                PotvrditButton.Enabled = true;
            else
            {
                if (zoznamHracov.Count == 0)
                    PotvrditButton.Enabled = false;
                else
                {
                    HraciLB.SelectedIndex = 0;
                    PotvrditButton.Enabled = true;
                }
            }
        }

        private void PotvrdKartu()
        {
            if (OnHracCervenaKartaSelected != null)
            {
                if (futbalovyTim == null)
                {
                    karta.TypKarty = 'C';
                    karta.NazovTimu = domaci ? zapas.NazovDomaci : zapas.NazovHostia;
                    karta.IdFutbalovyTim = futbalovyTim != null ? futbalovyTim.IdFutbalovyTim : 0;
                    zapas.Udalosti.Add(karta);
                    uspech = true;
                    OnHracCervenaKartaSelected(null);
                }                   
                else
                {
                    karta.Hrac = zoznamHracov[HraciLB.SelectedIndex];
                    karta.TypKarty = 'C'; 
                    karta.NazovTimu = domaci ? zapas.NazovDomaci : zapas.NazovHostia;
                    karta.IdFutbalovyTim = futbalovyTim != null ? futbalovyTim.IdFutbalovyTim : 0;
                    zapas.Udalosti.Add(karta);
                    uspech = true;
                    OnHracCervenaKartaSelected(zoznamHracov[HraciLB.SelectedIndex]);
                }         
            }
            this.Close();
        }

        private void PotvrditButton_Click(object sender, EventArgs e)
        {
            PotvrdKartu();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HraciLB_DoubleClick(object sender, EventArgs e)
        {
            if (HraciLB.SelectedIndex >= 0)
                PotvrdKartu();
        }


        private void CervenaKartaSettingsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (uspech && OnUdalostPridana != null)
                OnUdalostPridana("ČERVENÁ KARTA PRIDANÁ DO UDALOSTÍ");
        }

        #endregion


    }
}
