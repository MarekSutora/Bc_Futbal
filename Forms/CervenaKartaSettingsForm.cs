using LGR_Futbal.Properties;
using LGR_Futbal.Triedy;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LGR_Futbal.Model;
namespace LGR_Futbal.Forms
{
    public delegate void HracCervenaKartaSelectedHandler(Hrac hrac);
    public partial class CervenaKartaSettingsForm : Form
    {
        public event HracCervenaKartaSelectedHandler OnHracZltaKartaSelected;
        public event UdalostPridanaHandler OnUdalostPridana;
        private List<Hrac> zoznam;
        private FutbalovyTim t;
        private Zapas zapas = null;
        private bool nadstavenyCas = false;
        private int nadstavenaMinuta = 0;
        private int minuta = -1;
        private int polcas = -1;
        private DateTime cas;
        private bool uspech = false;
        private bool domaci = false;

        #region Konstruktor a metody

        public CervenaKartaSettingsForm(FutbalovyTim tim, Zapas zapas, bool nadstavenyCas, int nadstavenaMinuta, int minuta, int polcas, bool domaci)
        {
            InitializeComponent();

            if (Settings.Default.Jazyk == 1)
            {
                this.Text = "Červená karta - nastavení";
                potvrditButton.Text = "Potvrdit";
                backButton.Text = "Návrat zpět";
            }
            this.domaci = domaci;
            t = tim;
            zoznam = new List<Hrac>();
            this.zapas = zapas;
            cas = DateTime.Now;
            this.nadstavenaMinuta = nadstavenaMinuta;
            this.nadstavenyCas = nadstavenyCas;
            this.minuta = minuta;
            this.polcas = polcas;
            if (tim != null)
            {
                foreach (Hrac h in tim.ZoznamHracov)
                {
                    if ((h.HraAktualnyZapas) && (!h.Nahradnik) && (!h.CervenaKarta))
                    {
                        zoznam.Add(h);
                        if (!h.CisloDresu.Equals(string.Empty))
                            hraciLB.Items.Add(h.CisloDresu + ". " + h.Meno + " " + h.Priezvisko.ToUpper());
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
                {
                    Karta karta = new Karta();
                    Hrac hrac = zoznam[hraciLB.SelectedIndex];
                    karta.Hrac = hrac;
                    karta.IdKarta = 2; //2 - cervena, 1 - zlta
                    karta.Minuta = minuta;
                    karta.NadstavenaMinuta = nadstavenaMinuta;
                    karta.Predlzenie = nadstavenyCas ? 1 : 0;
                    karta.Polcas = polcas;
                    karta.AktualnyCas = cas;
                    karta.NazovTimu = domaci ? zapas.NazovDomaci : zapas.NazovHostia;
                    zapas.Udalosti.Add(karta);
                    uspech = true;
                    OnHracZltaKartaSelected(zoznam[hraciLB.SelectedIndex]);
                }         
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

        private void CervenaKartaSettingsForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void CervenaKartaSettingsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (uspech && OnUdalostPridana != null)
                OnUdalostPridana("ČERVENÁ KARTA PRIDANÁ DO UDALOSTÍ");
        }

        #endregion


    }
}
