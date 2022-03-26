using LGR_Futbal.Properties;
using LGR_Futbal.Setup;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LGR_Futbal.Model;

namespace LGR_Futbal.Forms
{
    public partial class GolForm : Form
    {
        #region Konstanty

        private const string fotkyAdresar = "\\Files\\Fotky\\";
        private const string gifyAdresar = "\\Files\\Gify\\";

        #endregion

        #region Atributy

        private string adresar;
        private Hrac prezentovanyHrac;
        private bool koniec;
        private int pocetTikov;
        private int casovyLimit;
        private bool zobrazitDefault;
        private List<string> subory;
        private int faza;
        private int pocetZobrazenychAnimacii;

        #endregion

        #region Konstruktor a metody

        public GolForm(string folder, int sirka, int cas, Hrac h, FontyTabule fonty, Setup.FarbyPrezentacie farby, AnimacnaKonfiguracia animacie, bool domaci)
        {
            InitializeComponent();
            adresar = folder;

            if (domaci)
            {
                zobrazitDefault = animacie.ZobrazitPreddefinovanuAnimaciuDomaci;
                subory = animacie.AnimacieDomaci;
            }
            else
            {
                zobrazitDefault = animacie.ZobrazitPreddefinovanuAnimaciuHostia;
                subory = animacie.AnimacieHostia;
            }

            if (Settings.Default.Jazyk == 1)
                label2.Text = "Věk:";

            casovac.Interval = 500;
            prezentovanyHrac = h;
            koniec = false;
            pocetTikov = 0;
            casovyLimit = cas;

            // Nastavenie velkosti zobrazovacej plochy - zvacsenie na pozadovanu velkost
            float pomer = (float)sirka / (float)this.Width;
            Scale(new SizeF(pomer, pomer));

            LayoutSetter.NastavVelkostiElementov(this, pomer);

            if (h != null)
            {
                try
                {
                    fotkaPictureBox.Image = Image.FromFile(adresar + "\\" + fotkyAdresar + h.Fotka);
                }
                catch
                {
                    fotkaPictureBox.Image = Image.FromFile(adresar + "\\" + fotkyAdresar + "Default.png");
                }

                cisloHracaLabel.Text = h.CisloDresu.ToString();
                string identifikacia = h.Meno + " " + h.Priezvisko.ToUpper();

                menoHracaLabel.Text = identifikacia;

                if (Settings.Default.Jazyk == 1)
                    vekLabel.Text = h.GetVek().ToString() + " let";
                else
                    vekLabel.Text = h.GetVek().ToString() + " rokov";
                postLabel.Text = h.Pozicia;
            }

            // Nastavenie farieb podla volby
            cisloHracaLabel.ForeColor = farby.CisloFarba();
            menoHracaLabel.ForeColor = farby.MenoFarba();
            label2.ForeColor = farby.ZakladFarba();
            label5.ForeColor = farby.ZakladFarba();
            vekLabel.ForeColor = farby.UdajeFarba();
            infoRichTextBox.ForeColor = farby.UdajeFarba();
            postLabel.ForeColor = farby.UdajeFarba();

            // Nastavenie fontov podla volby
            cisloHracaLabel.Font = fonty.CreatePolcasFont();
            menoHracaLabel.Font = fonty.CreatePolcasFont();
            label2.Font = fonty.CreateCasFont();
            label5.Font = fonty.CreateCasFont();
            vekLabel.Font = fonty.CreateCasFont();
            infoRichTextBox.Font = fonty.CreateCasFont();
            postLabel.Font = fonty.CreateCasFont();

            pocetZobrazenychAnimacii = 0;
            if (subory.Count > 0)
            {
                pocetZobrazenychAnimacii = 1;
                try
                {
                    animaciaPB.Image = Image.FromFile(adresar + "\\" + gifyAdresar + subory[0]);
                }
                catch
                {
                    animaciaPB.Image = null;
                }
            }

            if (zobrazitDefault)
            {
                faza = 1;
                animacnyPanel.Visible = false;
                prezentacnyPanel.Visible = false;
                uvodnyPanel.Visible = true;
            }
            else
            {
                faza = 2;
                prezentacnyPanel.Visible = false;
                uvodnyPanel.Visible = false;
                animacnyPanel.Visible = true;
            }
        }

        private void GolForm_Load(object sender, EventArgs e)
        {
            LayoutSetter.ZobrazNaDruhejObrazovke(this);

            this.SpustiCas();
        }

        private void Casovac_Tick(object sender, EventArgs e)
        {
            pocetTikov++;
            if (pocetTikov % 2 == 0)
                nadpisLabel1.ForeColor = Color.Yellow;
            else
                nadpisLabel1.ForeColor = Color.Red;

            if (pocetTikov == casovyLimit * 2)
            {
                if (faza == 1)
                {
                    if (prezentovanyHrac == null)
                    {
                        if (subory.Count > 0)
                        {
                            pocetTikov = 0;
                            faza = 2;
                            pocetZobrazenychAnimacii = 1;
                            prezentacnyPanel.Visible = false;
                            uvodnyPanel.Visible = false;
                            animacnyPanel.Visible = true;
                        }
                        else
                        {
                            ZastavCas();
                            this.Close();
                        }
                    }
                    else
                    {
                        if (koniec)
                        {
                            if (subory.Count > 0)
                            {
                                pocetTikov = 0;
                                faza = 2;
                                pocetZobrazenychAnimacii = 1;
                                prezentacnyPanel.Visible = false;
                                uvodnyPanel.Visible = false;
                                animacnyPanel.Visible = true;
                            }
                            else
                            {
                                ZastavCas();
                                this.Close();
                            }
                        }
                        else
                        {
                            pocetTikov = 0;
                            uvodnyPanel.Visible = false;
                            prezentacnyPanel.Visible = true;
                            koniec = true;
                        }
                    }
                }
                else if (faza == 2)
                {
                    if (pocetZobrazenychAnimacii == subory.Count)
                    {
                        ZastavCas();
                        this.Close();
                    }
                    else
                    {
                        pocetTikov = 0;
                        try
                        {
                            animaciaPB.Image = Image.FromFile(adresar + "\\" + gifyAdresar + subory[pocetZobrazenychAnimacii]);
                        }
                        catch
                        {
                            animaciaPB.Image = null;
                        }
                        pocetZobrazenychAnimacii++;
                    }
                }
            }
        }

        private void SpustiCas()
        {
            casovac.Enabled = true;
        }

        private void ZastavCas()
        {
            casovac.Enabled = false;
        }

        #endregion
    }
}
