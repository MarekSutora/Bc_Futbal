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
    public partial class PrezentaciaForm : Form
    {
        #region Konstanty

        private const string fotkyAdresar = "\\Files\\Fotky\\";

        #endregion

        #region Atributy

        private string adresar;
        private FutbalovyTim prezentovanyTim = null;
        private int pocetPrezentovanychHracov;
        private List<Hrac> zakladnaJedenastka = null;
        private List<Hrac> nahradnici = null;
        private List<Hrac> aktualnyZoznam = null;

        #endregion

        #region Konstruktor a metody

        public PrezentaciaForm(string adresar, int sirka, int cas, FutbalovyTim tim, FarbyPrezentacie farby, FontyTabule fonty, bool ajNahradnici)
        {
            InitializeComponent();

            this.adresar = adresar;
            casovac.Interval = 2 * 1000 * cas;
            prezentovanyTim = tim;

            zakladnaJedenastka = new List<Hrac>();
            nahradnici = new List<Hrac>();

            foreach (Hrac h in prezentovanyTim.ZoznamHracov)
            {
                if ((h.HraAktualnyZapas) && (!h.CervenaKarta))
                    zakladnaJedenastka.Add(h);
                if ((h.Nahradnik) && (!h.CervenaKarta))
                    nahradnici.Add(h);
            }

            if (!ajNahradnici)
                nahradnici.Clear();

            aktualnyZoznam = zakladnaJedenastka;
            pocetPrezentovanychHracov = 0;

            float pomer = (float)sirka / (float)this.Width;
            Scale(new SizeF(pomer, pomer));

            LayoutSetter.NastavVelkostiElementov(this, pomer);

            nazovLabel.Text = tim.NazovTimu;
            prezentacnyPanel.Visible = false;
            nahradniciPanel.Visible = false;
            uvodnyPanel.Visible = true;

            // Nastavenie farieb podla volby
            nazovLabel.ForeColor = farby.GetNadpisFarba();
            nahradniciLabel.ForeColor = farby.GetNadpisFarba();
            podnadpisLabel.ForeColor = farby.GetNadpisFarba();
            cisloHracaLabel.ForeColor = farby.GetCisloFarba();
            menoHracaLabel.ForeColor = farby.GetMenoFarba();
            vekTextLabel.ForeColor = farby.GetZakladFarba();
            postTextLabel.ForeColor = farby.GetZakladFarba();
            vekLabel.ForeColor = farby.GetUdajeFarba();
            infoRichTextBox.ForeColor = farby.GetUdajeFarba();
            postLabel.ForeColor = farby.GetUdajeFarba();

            // Nastavenie fontov podla volby
            nazovLabel.Font = fonty.CreateNazvyPrezentaciaFont();
            podnadpisLabel.Font = fonty.CreatePodnadpisPrezentaciaFont();
            cisloHracaLabel.Font = fonty.CreateCisloMenoPrezentaciaFont();
            menoHracaLabel.Font = fonty.CreateCisloMenoPrezentaciaFont();
            vekTextLabel.Font = fonty.CreateUdajePrezentaciaFont();
            postTextLabel.Font = fonty.CreateUdajePrezentaciaFont();
            vekLabel.Font = fonty.CreateUdajePrezentaciaFont();
            infoRichTextBox.Font = fonty.CreateUdajePrezentaciaFont();
            postLabel.Font = fonty.CreateUdajePrezentaciaFont();
        }

        private void PrezentaciaForm_Load(object sender, EventArgs e)
        {
            LayoutSetter.ZobrazNaDruhejObrazovke(this);

            this.SpustiCas();
        }

        private void Casovac_Tick(object sender, EventArgs e)
        {
            if ((zakladnaJedenastka.Count == 0) && (nahradnici.Count == 0))
            {
                ZastavCas();
                this.Close();
            }
            else
            {
                uvodnyPanel.Visible = false;
                nahradniciPanel.Visible = false;
                prezentacnyPanel.Visible = true;

                if (pocetPrezentovanychHracov < aktualnyZoznam.Count)
                {
                    Hrac h = aktualnyZoznam[pocetPrezentovanychHracov];
                    try
                    {
                        fotkaPictureBox.Image = Image.FromFile(adresar + "\\" + fotkyAdresar + h.Fotka);
                    }
                    catch
                    {
                        fotkaPictureBox.Image = Image.FromFile(adresar + "\\" + fotkyAdresar + "Default.png");
                    }

                    cisloHracaLabel.Text = h.CisloDresu.ToString();
                    
                    String identifikacia = h.Meno + " " + h.Priezvisko.ToUpper();
                    menoHracaLabel.Text = identifikacia;
                    
                    if (h.Poznamka.Equals(string.Empty))
                        infoRichTextBox.Visible = false;
                    else
                    {
                        infoRichTextBox.Text = h.Poznamka;
                        infoRichTextBox.Visible = true;
                    }
                    postLabel.Text = h.Pozicia;

                    pocetPrezentovanychHracov++;
                }
                else
                {
                    if (aktualnyZoznam == nahradnici)
                    {
                        ZastavCas();
                        this.Close();
                    }
                    else if (aktualnyZoznam == zakladnaJedenastka)
                    {
                        if (nahradnici.Count > 0)
                        {
                            aktualnyZoznam = nahradnici;
                            pocetPrezentovanychHracov = 0;
                            prezentacnyPanel.Visible = false;
                            nahradniciPanel.Visible = true;
                        }
                    }
                    else
                    {
                        ZastavCas();
                        this.Close();
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
