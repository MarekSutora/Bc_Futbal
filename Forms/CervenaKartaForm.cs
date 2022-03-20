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
    public partial class CervenaKartaForm : Form
    {
        #region Konstanty

        private const string fotkyAdresar = "Databaza\\Fotky\\";
        private const string kartyAdresar = "Databaza\\Karty\\";

        #endregion

        #region Atributy

        private string adresar;
        private Hrac prezentovanyHrac;
        private int pocetZobrazenychPanelov;
        private List<Panel> zobrazovane;

        #endregion

        #region Konstruktor a metody

        public CervenaKartaForm(string folder, int sirka, int cas, Hrac hrac, bool sDruhouZltouKartou, FontyTabule pisma,
            string animZ, string animC)
        {
            InitializeComponent();

            if (Settings.Default.Jazyk == 0)
            {
                label3.Text = "vylúčený";
                label2.Text = "2. žltá karta";
                nadpisLabel1.Text = "ŽLTÁ\nKARTA";
            }
            else
            {
                label3.Text = "vyloučen";
                label2.Text = "2. žlutá karta";
                nadpisLabel1.Text = "ŽLUTÁ\nKARTA";
            }

            adresar = folder;
            casovac.Interval = 1000 * cas;

            if (animZ.Equals(string.Empty))
                pictureBox1.Image = null;
            else
            {
                try
                {
                    pictureBox1.Image = Image.FromFile(adresar + "\\" + kartyAdresar + animZ);
                }
                catch
                {
                    pictureBox1.Image = null;
                }
            }

            if (animC.Equals(string.Empty))
                pictureBox2.Image = null;
            else
            {
                try
                {
                    pictureBox2.Image = Image.FromFile(adresar + "\\" + kartyAdresar + animC);
                }
                catch
                {
                    pictureBox2.Image = null;
                }
            }

            prezentovanyHrac = hrac;
            pocetZobrazenychPanelov = 1;
            zobrazovane = new List<Panel>();

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

            if (prezentovanyHrac != null)
            {
                try
                {
                    if (prezentovanyHrac.FotkaImage != null)
                    {
                        fotkaPictureBox.Image = prezentovanyHrac.FotkaImage;
                        fotkaPB.Image = prezentovanyHrac.FotkaImage;
                    }
                    else
                    {
                        fotkaPictureBox.Image = Image.FromFile(adresar + "\\" + fotkyAdresar + "Default.png");
                        fotkaPB.Image = Image.FromFile(adresar + "\\" + fotkyAdresar + "Default.png");
                    }
                    
                }
                catch
                {
                    fotkaPictureBox.Image = Image.FromFile(adresar + "\\" + fotkyAdresar + "Default.png");
                    fotkaPB.Image = Image.FromFile(adresar + "\\" + fotkyAdresar + "Default.png");
                }

                cisloHracaLabel.Text = prezentovanyHrac.CisloDresu.ToString();
                chLabel.Text = cisloHracaLabel.Text;
                String identifikacia = prezentovanyHrac.Meno + " " + prezentovanyHrac.Priezvisko.ToUpper();

                menoHracaLabel.Text = identifikacia;
                mhLabel.Text = menoHracaLabel.Text;
            }

            cisloHracaLabel.Font = pisma.CreatePolcasFont();
            menoHracaLabel.Font = pisma.CreatePolcasFont();
            menoHracaLabel.ForeColor = Color.Black;
            chLabel.Font = pisma.CreatePolcasFont();
            mhLabel.Font = pisma.CreatePolcasFont();

            uvodnyPanel1.Visible = false;
            uvodnyPanel2.Visible = false;
            prezentacnyPanel1.Visible = false;
            prezentacnyPanel2.Visible = false;

            if (sDruhouZltouKartou)
            {
                zobrazovane.Add(uvodnyPanel1);
                uvodnyPanel1.Visible = true;

                if (prezentovanyHrac != null)
                    zobrazovane.Add(prezentacnyPanel1);
            }
            else
                this.BackColor = Color.Red;

            zobrazovane.Add(uvodnyPanel2);
            uvodnyPanel2.Visible = !sDruhouZltouKartou;

            if (prezentovanyHrac != null)
                zobrazovane.Add(prezentacnyPanel2);
        }

        private void CervenaKartaForm_Load(object sender, EventArgs e)
        {
            // Ak existuje externy monitor, svetelna tabula sa vykresli primarne nan,
            // ak nie, pouzije sa standardna obrazovka.
            var primaryDisplay = Screen.AllScreens.ElementAtOrDefault(0);
            var extendedDisplay = Screen.AllScreens.FirstOrDefault(s => s != primaryDisplay) ?? primaryDisplay;

            this.Left = extendedDisplay.WorkingArea.Left + (extendedDisplay.Bounds.Size.Width / 2) - (this.Size.Width / 2);
            this.Top = extendedDisplay.WorkingArea.Top + (extendedDisplay.Bounds.Size.Height / 2) - (this.Size.Height / 2);

            this.SpustiCas();
        }

        private void Casovac_Tick(object sender, EventArgs e)
        {
            if (pocetZobrazenychPanelov == zobrazovane.Count)
            {
                ZastavCas();
                this.Close();
            }
            else
            {
                zobrazovane[pocetZobrazenychPanelov - 1].Visible = false;
                zobrazovane[pocetZobrazenychPanelov].Visible = true;
                if (zobrazovane[pocetZobrazenychPanelov] == uvodnyPanel2)
                    this.BackColor = Color.Red;
                pocetZobrazenychPanelov++;
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
