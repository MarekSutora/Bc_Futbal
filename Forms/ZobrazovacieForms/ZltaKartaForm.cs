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
    public partial class ZltaKartaForm : Form
    {
        #region Konstanty

        private const string fotkyAdresar = "\\Files\\Fotky\\";
        private const string kartyAdresar = "\\Files\\Karty\\";

        #endregion

        #region Atributy

        private Hrac prezentovanyHrac = null;
        private bool prezentaciaSkoncila;

        #endregion
        
        #region Konstruktor a metody

        public ZltaKartaForm(string adresar, int sirka, int cas, Hrac hrac, FontyTabule pisma, string animZ)
        {
            InitializeComponent();

            casovac.Interval = 1000 * cas;

            prezentovanyHrac = hrac;
            prezentaciaSkoncila = false;

            if (animZ.Equals(string.Empty))
                pictureBox1.Image = null;
            else
            {
                try
                {
                    pictureBox1.Image = Image.FromFile(adresar + kartyAdresar + animZ);
                }
                catch
                {
                    pictureBox1.Image = null;
                }
            }

            // Nastavenie velkosti zobrazovacej plochy - zvacsenie na pozadovanu velkost
            float pomer = (float)sirka / (float)this.Width;
            Scale(new SizeF(pomer, pomer));

            LayoutSetter.NastavVelkostiElementov(this, pomer);

            if (prezentovanyHrac != null)
            {
                try
                {
                    if(prezentovanyHrac.FotkaImage != null)
                    {
                        fotkaPictureBox.Image = prezentovanyHrac.FotkaImage;
                    }
                    else
                    {
                        fotkaPictureBox.Image = Image.FromFile(adresar + fotkyAdresar + "Default.png");
                    }          
                }
                catch
                {
                    fotkaPictureBox.Image = Image.FromFile(adresar + "\\" + fotkyAdresar + "Default.png");
                }

                cisloHracaLabel.Text = prezentovanyHrac.CisloDresu.ToString();
                
                string identifikacia = prezentovanyHrac.Meno + " " + prezentovanyHrac.Priezvisko.ToUpper();

                menoHracaLabel.Text = identifikacia;
            }

            cisloHracaLabel.Font = pisma.CreateCisloMenoPrezentaciaFont();
            menoHracaLabel.Font = pisma.CreateCisloMenoPrezentaciaFont();

            prezentacnyPanel.Visible = false;
            uvodnyPanel.Visible = true;
        }

        private void ZltaKartaForm_Load(object sender, EventArgs e)
        {
            LayoutSetter.ZobrazNaDruhejObrazovke(this);
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
