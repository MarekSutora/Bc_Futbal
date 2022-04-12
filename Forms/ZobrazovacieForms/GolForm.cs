using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BC_Futbal.Model;
using BC_Futbal.Setup;

namespace BC_Futbal.Forms
{
    public partial class GolForm : Form
    {
        private const string fotkyAdresar = "\\Files\\Fotky\\";
        private const string gifyAdresar = "\\Files\\Gify\\";

        private string adresar;
        private Hrac prezentovanyHrac;
        private bool koniec;
        private int pocetTikov;
        private int casovyLimit;
        private bool zobrazitDefault;
        private List<string> subory;
        private int faza;
        private int pocetZobrazenychAnimacii;
        private int sirka;

        public GolForm(string adresar, int s, int cas, Hrac h, FontyTabule fonty, FarbyPrezentacie farby, AnimacnaKonfiguracia animacie, bool domaci)
        {
            InitializeComponent();
            this.adresar = adresar;
            sirka = s;
            if (domaci)
            {
                zobrazitDefault = animacie.ZobrazitAnimaciuDomaci;
                subory = animacie.AnimacieDomaci;
            }
            else
            {
                zobrazitDefault = animacie.ZobrazitAnimaciuHostia;
                subory = animacie.AnimacieHostia;
            }

            casovac.Interval = 500;
            prezentovanyHrac = h;
            koniec = false;
            pocetTikov = 0;
            casovyLimit = cas;

            // Nastavenie velkosti zobrazovacej plochy - zvacsenie na pozadovanu velkost
            float pomer = (float)sirka / Width;
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

                postLabel.Text = h.Pozicia;
            }

            // Nastavenie farieb podla volby
            cisloHracaLabel.ForeColor = farby.GetCisloFarba();
            menoHracaLabel.ForeColor = farby.GetMenoFarba();
            label2.ForeColor = farby.GetZakladFarba();
            label5.ForeColor = farby.GetZakladFarba();
            vekLabel.ForeColor = farby.GetUdajeFarba();
            infoRichTextBox.ForeColor = farby.GetUdajeFarba();
            postLabel.ForeColor = farby.GetUdajeFarba();

            // Nastavenie fontov podla volby
            cisloHracaLabel.Font = fonty.CreateCisloMenoPrezentaciaFont();
            menoHracaLabel.Font = fonty.CreateCisloMenoPrezentaciaFont();
            label2.Font = fonty.CreateUdajePrezentaciaFont();
            label5.Font = fonty.CreateUdajePrezentaciaFont();
            vekLabel.Font = fonty.CreateUdajePrezentaciaFont();
            infoRichTextBox.Font = fonty.CreateUdajePrezentaciaFont();
            postLabel.Font = fonty.CreateUdajePrezentaciaFont();

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
            if (Screen.AllScreens.Length == 1)
            {
                Location = Screen.PrimaryScreen.WorkingArea.Location;
                MaximumSize = Screen.PrimaryScreen.WorkingArea.Size;
                Left += (Screen.PrimaryScreen.Bounds.Width - sirka) / 2;
            }
            else
            {
                LayoutSetter.ZobrazNaDruhejObrazovke(this);
            }

            SpustiCas();
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
                            Close();
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
                                Close();
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
                        Close();
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
    }
}
