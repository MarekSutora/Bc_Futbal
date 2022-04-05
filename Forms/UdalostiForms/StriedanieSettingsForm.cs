using LGR_Futbal.Properties;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LGR_Futbal.Model;

namespace LGR_Futbal.Forms.UdalostiForms
{
    public delegate void StriedanieHraciSelectedHandler(string nazovTimu, Hrac odchadzajuci, Hrac nastupujuci, bool jeDomaciTim);

    public partial class StriedanieSettingsForm : Form
    {
        public event StriedanieHraciSelectedHandler OnStriedanieHraciSelected;
        public event UdalostPridanaHandler OnUdalostPridana;

        private bool domaci = false;
        private bool uspech = false;
        private List<Hrac> odchMoznosti = null;
        private List<Hrac> nastMoznosti = null;
        private FutbalovyTim futbalovyTim = null;
        private Zapas zapas = null;
        private Striedanie striedanie = null;

        #region Konstruktor a metody
        public StriedanieSettingsForm(FutbalovyTim tim, bool domaci, Zapas zapas, Striedanie striedanie)
        {
            InitializeComponent();

            this.domaci = domaci;
            futbalovyTim = tim;
            this.zapas = zapas;
            this.striedanie = striedanie;

            odchMoznosti = new List<Hrac>();
            nastMoznosti = new List<Hrac>();

            if (futbalovyTim != null)
            {
                foreach(Hrac h in futbalovyTim.ZoznamHracov)
                {
                    if (!h.CervenaKarta)
                    {
                        if ((h.HraAktualnyZapas) && (!h.Nahradnik))
                        {
                            odchMoznosti.Add(h);
                            if (!h.CisloDresu.Equals(string.Empty))
                                HraciLBodch.Items.Add(h.CisloDresu.ToString() + ". " + h.Meno + " " + h.Priezvisko.ToUpper());
                            else
                                HraciLBodch.Items.Add(h.Meno + " " + h.Priezvisko.ToUpper());
                        }
                        else if ((!h.HraAktualnyZapas) && (h.Nahradnik))
                        {
                            nastMoznosti.Add(h);
                            if (!h.CisloDresu.Equals(string.Empty))
                                HraciLBnast.Items.Add(h.CisloDresu.ToString() + ". " + h.Meno + " " + h.Priezvisko.ToUpper());
                            else
                                HraciLBnast.Items.Add(h.Meno + " " + h.Priezvisko.ToUpper());
                        }
                    }
                }
            }

            //if (HraciLBodch.Items.Count > 0)
            //    HraciLBodch.SelectedIndex = 0;

            //if (HraciLBnast.Items.Count > 0)
            //    HraciLBnast.SelectedIndex = 0;

            //if (tim == null)
            //    PotvrditButton.Enabled = true;
            //else
            //{
            //    if ((odchMoznosti.Count > 0) && (nastMoznosti.Count > 0))
            //        PotvrditButton.Enabled = true;
            //    else
            //        PotvrditButton.Enabled = false;
            //}
        }
        private void PotvrditBtn_Click(object sender, EventArgs e)
        {
            if (OnStriedanieHraciSelected != null)
            {

                string nazovTimu = domaci ? zapas.NazovDomaci : zapas.NazovHostia;
                striedanie.NazovTimu = nazovTimu;
                if (futbalovyTim == null)
                {
                    zapas.Udalosti.Add(striedanie);
                    uspech = true;
                    OnStriedanieHraciSelected(nazovTimu, null, null, domaci);
                }            
                else
                {
                    Hrac h1 = null;
                    Hrac h2 = null;
                    if (HraciLBodch.SelectedIndex != -1)
                    {
                        h1 = odchMoznosti[HraciLBodch.SelectedIndex];
                        striedanie.Striedany = h1;
                    }
                    if (HraciLBnast.SelectedIndex != -1)
                    {
                        h2 = nastMoznosti[HraciLBnast.SelectedIndex];
                        striedanie.Striedajuci = h2;
                    }
                        
                    striedanie.IdFutbalovyTim = futbalovyTim != null ? futbalovyTim.IdFutbalovyTim : 0;
                    zapas.Udalosti.Add(striedanie);
                    uspech = true;

                    OnStriedanieHraciSelected(nazovTimu, h1, h2, domaci);

                    //if (h1 != null && h2 != null)
                    //     OnStriedanieHraciSelected(nazovTimu, h1, h2, domaci);
                    //else if (h1 == null && h2 != null)
                    //    OnStriedanieHraciSelected(nazovTimu, null, h2, domaci);
                    //else if(h1 != null && h2 == null)
                    //    OnStriedanieHraciSelected(nazovTimu, h1, null, domaci);
                    //else
                    //    OnStriedanieHraciSelected(nazovTimu, null, null, domaci);
                }
                
            }
            Close();
        }
        private void SpatBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void StriedanieSettingsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (uspech && OnUdalostPridana != null)
                OnUdalostPridana("STRIEDANIE PRIDANÝ DO UDALOSTÍ");
        }

        private void OdznacVsetko(object sender, EventArgs e)
        {
            HraciLBnast.ClearSelected();
            HraciLBodch.ClearSelected();
        }

        #endregion
    }
}
