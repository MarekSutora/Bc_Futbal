using LGR_Futbal.Properties;
using LGR_Futbal.Setup;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LGR_Futbal.Model;

namespace LGR_Futbal.Forms
{
    public partial class StriedanieForm : Form
    {
        #region Konstanty

        private const string fotkyAdresar = "Pripojenie\\Fotky\\";

        #endregion

        #region Atributy

        private string adresar;
        private Hrac prezentovanyHrac1;
        private Hrac prezentovanyHrac2;
        private bool prezentaciaSkoncila;

        #endregion

        #region Konstruktor a metody

        public StriedanieForm(string folder, int sirka, int cas, string nazovMuzstva, Hrac hracOdch, Hrac hracNast, FarbyPrezentacie farby, FontyTabule pismaPrezentacie, FontyTabule pisma)
        {
            InitializeComponent();

            if (Settings.Default.Jazyk == 0)
                label1.Text = "STRIEDANIE";
            else
                label1.Text = "STŘÍDÁNÍ";

            adresar = folder;
            casovac.Interval = 1000 * cas;

            prezentovanyHrac1 = hracOdch;
            prezentovanyHrac2 = hracNast;
            prezentaciaSkoncila = false;

            nazovLabel.Text = nazovMuzstva;

            // Nastavenie velkosti zobrazovacej plochy - zvacsenie na pozadovanu velkost
            float pomer = (float)sirka / this.Width;
            Scale(new SizeF(pomer, pomer));

            LayoutSetter.NastavVelkostiElementov(this, pomer);

            if (prezentovanyHrac1 != null)
            {
                try
                {
                    fotka1PictureBox.Image = prezentovanyHrac1.FotkaImage;
                }
                catch
                {
                    fotka1PictureBox.Image = Image.FromFile(adresar + "\\" + fotkyAdresar + "Default.png");
                    //fotka1PictureBox.Image = null;
                }

                cisloHraca1Label.Text = prezentovanyHrac1.CisloDresu.ToString();
               
                String identifikacia = prezentovanyHrac1.Meno + " " + prezentovanyHrac1.Priezvisko.ToUpper();
                //if (identifikacia.Length > 15)
                //    identifikacia = identifikacia.Replace(" ", "\n");

                menoHraca1Label.Text = identifikacia;
            }

            if (prezentovanyHrac2 != null)
            {
                try
                {
                    fotka2PictureBox.Image = prezentovanyHrac2.FotkaImage;
                }
                catch
                {
                    fotka2PictureBox.Image = Image.FromFile(adresar + "\\" + fotkyAdresar + "Default.png");
                    //fotka2PictureBox.Image = null;
                }

                cisloHraca2Label.Text = prezentovanyHrac2.CisloDresu.ToString();
                String identifikacia = prezentovanyHrac2.Meno + " " + prezentovanyHrac2.Priezvisko.ToUpper();
                //if (identifikacia.Length > 15)
                //    identifikacia = identifikacia.Replace(" ", "\n");

                menoHraca2Label.Text = identifikacia;
            }

            // Nastavenie farieb podla volby
            nazovLabel.ForeColor = farby.NadpisFarba();
            label1.ForeColor = farby.NadpisFarba();
            
            // Nastavenie fontov podla volby
            nazovLabel.Font = pismaPrezentacie.CreateNazvyFont();
            label1.Font = pismaPrezentacie.CreateSkoreFont();

            cisloHraca1Label.Font = pisma.CreateStriedaniaFont();
            menoHraca1Label.Font = pisma.CreateStriedaniaFont();
            cisloHraca2Label.Font = pisma.CreateStriedaniaFont();
            menoHraca2Label.Font = pisma.CreateStriedaniaFont();

            prezentacnyPanel.Visible = false;
            uvodnyPanel.Visible = true;
        }

        private void StriedanieForm_Load(object sender, EventArgs e)
        {
            // Ak existuje externy monitor, svetelna tabula sa vykresli primarne nan,
            // ak nie, pouzije sa standardna obrazovka.
            LayoutSetter.ZobrazNaDruhejObrazovke(this);

            this.SpustiCas();
        }

        private void Casovac_Tick(object sender, EventArgs e)
        {
            if ((prezentovanyHrac1 == null) || (prezentovanyHrac2 == null))
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
