using LGR_Futbal.Properties;
using LGR_Futbal.Triedy;
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

        private const string fotkyAdresar = "Databaza\\Fotky\\";

        #endregion

        #region Atributy

        private string adresar;
        private FutbalovyTim prezentovanyTim;
        private int pocetPrezentovanychHracov;
        private List<Hrac> zakladnaJedenastka;
        private List<Hrac> nahradnici;
        private List<Hrac> funkcionari;
        private List<Hrac> aktualnyZoznam;

        #endregion

        #region Konstruktor a metody

        public PrezentaciaForm(string folder, int sirka, int cas, FutbalovyTim tim, FarbyPrezentacieClass farby, FontyTabule fonty, bool ajNahradnici, bool ajFunkcionari)
        {
            InitializeComponent();

            if (Settings.Default.Jazyk == 1)
            {
                funkcionariLabel.Text = "Funkcionáři";
                label1.Text = "představení hráčů";
                label2.Text = "Věk:";
            }

            adresar = folder;
            casovac.Interval = 2 * 1000 * cas;
            prezentovanyTim = tim;

            zakladnaJedenastka = new List<Hrac>();
            nahradnici = new List<Hrac>();
            funkcionari = new List<Hrac>();

            foreach (Hrac h in prezentovanyTim.ZoznamHracov)
            {
                if ((h.HraAktualnyZapas) && (!h.CervenaKarta))
                    zakladnaJedenastka.Add(h);
                if ((h.Nahradnik) && (!h.CervenaKarta))
                    nahradnici.Add(h);
                if (h.Funkcionar)
                    funkcionari.Add(h);
            }

            if (!ajNahradnici)
                nahradnici.Clear();

            if (!ajFunkcionari)
                funkcionari.Clear();

            aktualnyZoznam = zakladnaJedenastka;
            pocetPrezentovanychHracov = 0;

            // Nastavenie velkosti zobrazovacej plochy - zvacsenie na pozadovanu velkost
            float pomer = (float)sirka / (float)this.Width;
            Scale(new SizeF(pomer, pomer));

            // Nastavenie velkosti fontu pre jednotlive labely
            Label l;
            Panel p;
            foreach (object item in Controls)
            {
                if (item.GetType() == typeof(Label))
                {
                    l = (Label)item;
                    l.Font = new Font(l.Font.Name, (float)Math.Floor(l.Font.Size * pomer));
                }
                else if (item.GetType() == typeof(Panel))
                {
                    p = (Panel)item;
                    foreach (object prvok in p.Controls)
                    {
                        if (prvok.GetType() == typeof(Label))
                        {
                            l = (Label)prvok;
                            l.Font = new Font(l.Font.Name, (float)Math.Floor(l.Font.Size * pomer));
                        }
                    }
                }
            }

            nazovLabel.Text = tim.NazovTimu;
            prezentacnyPanel.Visible = false;
            nahradniciPanel.Visible = false;
            funkcionariPanel.Visible = false;
            uvodnyPanel.Visible = true;

            // Nastavenie farieb podla volby
            nazovLabel.ForeColor = farby.NadpisFarba();
            nahradniciLabel.ForeColor = farby.NadpisFarba();
            funkcionariLabel.ForeColor = farby.NadpisFarba();
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
            var primaryDisplay = Screen.AllScreens.ElementAtOrDefault(0);
            var extendedDisplay = Screen.AllScreens.FirstOrDefault(s => s != primaryDisplay) ?? primaryDisplay;

            this.Left = extendedDisplay.WorkingArea.Left + (extendedDisplay.Bounds.Size.Width / 2) - (this.Size.Width / 2);
            this.Top = extendedDisplay.WorkingArea.Top + (extendedDisplay.Bounds.Size.Height / 2) - (this.Size.Height / 2);

            this.SpustiCas();
        }

        private void Casovac_Tick(object sender, EventArgs e)
        {
            if ((zakladnaJedenastka.Count == 0) && (nahradnici.Count == 0) && (funkcionari.Count == 0))
            {
                ZastavCas();
                this.Close();
            }
            else
            {
                uvodnyPanel.Visible = false;
                nahradniciPanel.Visible = false;
                funkcionariPanel.Visible = false;
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
                        vekLabel.Text = h.getVek().ToString() + " rokov";
                    else
                        vekLabel.Text = h.getVek().ToString() + " let";
                    
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
                        if (funkcionari.Count > 0)
                        {
                            aktualnyZoznam = funkcionari;
                            pocetPrezentovanychHracov = 0;
                            prezentacnyPanel.Visible = false;
                            nahradniciPanel.Visible = false;
                            funkcionariPanel.Visible = true;
                        }
                        else
                        {
                            ZastavCas();
                            this.Close();
                        }
                    }
                    else if (aktualnyZoznam == zakladnaJedenastka)
                    {
                        if (nahradnici.Count > 0)
                        {
                            aktualnyZoznam = nahradnici;
                            pocetPrezentovanychHracov = 0;
                            prezentacnyPanel.Visible = false;
                            funkcionariPanel.Visible = false;
                            nahradniciPanel.Visible = true;
                        }
                        else
                        {
                            if (funkcionari.Count > 0)
                            {
                                aktualnyZoznam = funkcionari;
                                pocetPrezentovanychHracov = 0;
                                prezentacnyPanel.Visible = false;
                                nahradniciPanel.Visible = false;
                                funkcionariPanel.Visible = true;
                            }
                            else
                            {
                                ZastavCas();
                                this.Close();
                            }
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
