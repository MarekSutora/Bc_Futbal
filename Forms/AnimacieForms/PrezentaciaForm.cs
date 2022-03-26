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
        private FutbalovyTim prezentovanyTim;
        private int pocetPrezentovanychHracov;
        private List<Hrac> zakladnaJedenastka;
        private List<Hrac> nahradnici;
        private List<Hrac> aktualnyZoznam;

        #endregion

        #region Konstruktor a metody

        public PrezentaciaForm(string folder, int sirka, int cas, FutbalovyTim tim, Setup.FarbyPrezentacie farby, FontyTabule fonty, bool ajNahradnici)
        {
            InitializeComponent();

            if (Settings.Default.Jazyk == 1)
            {
                label1.Text = "představení hráčů";
                label2.Text = "Věk:";
            }

            adresar = folder;
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

            // Nastavenie velkosti zobrazovacej plochy - zvacsenie na pozadovanu velkost
            float pomer = (float)sirka / (float)this.Width;
            Scale(new SizeF(pomer, pomer));

            LayoutSetter.NastavVelkostiElementov(this, pomer);

            nazovLabel.Text = tim.NazovTimu;
            prezentacnyPanel.Visible = false;
            nahradniciPanel.Visible = false;
            uvodnyPanel.Visible = true;

            // Nastavenie farieb podla volby
            nazovLabel.ForeColor = farby.NadpisFarba();
            nahradniciLabel.ForeColor = farby.NadpisFarba();
            label1.ForeColor = farby.NadpisFarba();
            cisloHracaLabel.ForeColor = farby.CisloFarba();
            menoHracaLabel.ForeColor = farby.MenoFarba();
            label2.ForeColor = farby.ZakladFarba();
            label5.ForeColor = farby.ZakladFarba();
            vekLabel.ForeColor = farby.UdajeFarba();
            infoRichTextBox.ForeColor = farby.UdajeFarba();
            postLabel.ForeColor = farby.UdajeFarba();

            // Nastavenie fontov podla volby
            nazovLabel.Font = fonty.CreateNazvyFont();
            label1.Font = fonty.CreateSkoreFont();
            cisloHracaLabel.Font = fonty.CreatePolcasFont();
            menoHracaLabel.Font = fonty.CreatePolcasFont();
            label2.Font = fonty.CreateCasFont();
            label5.Font = fonty.CreateCasFont();
            vekLabel.Font = fonty.CreateCasFont();
            infoRichTextBox.Font = fonty.CreateCasFont();
            postLabel.Font = fonty.CreateCasFont();
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
                    if (Settings.Default.Jazyk == 0)
                        vekLabel.Text = h.GetVek().ToString() + " rokov";
                    else
                        vekLabel.Text = h.GetVek().ToString() + " let";
                    
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

        private void PrezentaciaForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        #endregion
    }
}
