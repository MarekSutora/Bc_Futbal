using LGR_Futbal.Properties;
using LGR_Futbal.Triedy;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LGR_Futbal.Model;

namespace LGR_Futbal.Forms
{
    public partial class ZltaKartaForm : Form
    {
        #region Konstanty

        private const string fotkyAdresar = "Databaza\\Fotky\\";
        private const string kartyAdresar = "Databaza\\Karty\\";

        #endregion

        #region Atributy

        private string adresar;
        private Hrac prezentovanyHrac;
        private bool prezentaciaSkoncila;

        #endregion
        
        #region Konstruktor a metody

        public ZltaKartaForm(string folder, int sirka, int cas, Hrac hrac, FontyTabule pisma, string animZ)
        {
            InitializeComponent();

            if (Settings.Default.Jazyk == 0)
            {
                nadpisLabel1.Text = "ŽLTÁ\nKARTA";
                label2.Text = "1. žltá karta";
            }
            else
            {
                nadpisLabel1.Text = "ŽLUTÁ\nKARTA";
                label2.Text = "1. žlutá karta";
            }

            adresar = folder;
            casovac.Interval = 1000 * cas;

            prezentovanyHrac = hrac;
            prezentaciaSkoncila = false;

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
                    fotkaPictureBox.Image = Image.FromFile(adresar + "\\" + fotkyAdresar + prezentovanyHrac.Fotka);
                }
                catch
                {
                    fotkaPictureBox.Image = Image.FromFile(adresar + "\\" + fotkyAdresar + "Default.png");
                    //fotkaPictureBox.Image = null;
                }

                cisloHracaLabel.Text = prezentovanyHrac.CisloDresu.ToString();
                
                String identifikacia = prezentovanyHrac.Meno + " " + prezentovanyHrac.Priezvisko.ToUpper();
                //if (identifikacia.Length > 15)
                //    identifikacia = identifikacia.Replace(" ", "\n");

                menoHracaLabel.Text = identifikacia;
            }

            cisloHracaLabel.Font = pisma.CreatePolcasFont();
            menoHracaLabel.Font = pisma.CreatePolcasFont();

            prezentacnyPanel.Visible = false;
            uvodnyPanel.Visible = true;
        }

        private void ZltaKartaForm_Load(object sender, EventArgs e)
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
            if (prezentovanyHrac == null)
            {
                ZastavCas();
                this.Close();
            }
            else
            {
                if (prezentaciaSkoncila)
                {
                    ZastavCas();
                    this.Close();
                }
                else
                {
                    uvodnyPanel.Visible = false;
                    prezentacnyPanel.Visible = true;
                    prezentaciaSkoncila = true;
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
