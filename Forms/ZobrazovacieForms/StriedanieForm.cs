using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using LGR_Futbal.Model;
using LGR_Futbal.Setup;

namespace LGR_Futbal.Forms
{
    public partial class StriedanieForm : Form
    {
        private const string fotkyAdresar = "Pripojenie\\Fotky\\";

        private Hrac striedanyHrac = null;
        private Hrac striedajuciHrac = null;
        private bool prezentaciaSkoncila;

        public StriedanieForm(int sirka, int cas, string nazovMuzstva, Hrac striedany, Hrac striedajuci, FarbyPrezentacie farby, FontyTabule pisma)
        {
            InitializeComponent();

            string adresar = Directory.GetCurrentDirectory();
            casovac.Interval = 1000 * cas;

            striedanyHrac = striedany;
            striedajuciHrac = striedajuci;
            prezentaciaSkoncila = false;

            nazovLabel.Text = nazovMuzstva;

            float pomer = (float)sirka / Width;
            Scale(new SizeF(pomer, pomer));

            LayoutSetter.NastavVelkostiElementov(this, pomer);

            if (striedanyHrac != null)
            {
                try
                {
                    fotka1PictureBox.Image = striedanyHrac.FotkaImage;
                }
                catch
                {
                    fotka1PictureBox.Image = Image.FromFile(adresar + "\\" + fotkyAdresar + "Default.png");
                }

                cisloHraca1Label.Text = striedanyHrac.CisloDresu.ToString();
               
                string identifikacia = striedanyHrac.Meno + " " + striedanyHrac.Priezvisko.ToUpper();

                menoHraca1Label.Text = identifikacia;
            }

            if (striedajuciHrac != null)
            {
                try
                {
                    fotka2PictureBox.Image = striedajuciHrac.FotkaImage;
                }
                catch
                {
                    fotka2PictureBox.Image = Image.FromFile(adresar + "\\" + fotkyAdresar + "Default.png");
                }

                cisloHraca2Label.Text = striedajuciHrac.CisloDresu.ToString();
                string identifikacia = striedajuciHrac.Meno + " " + striedajuciHrac.Priezvisko.ToUpper();

                menoHraca2Label.Text = identifikacia;
            }

            nazovLabel.ForeColor = farby.GetNadpisFarba();
            label1.ForeColor = farby.GetNadpisFarba();
            
            nazovLabel.Font = pisma.CreateNazvyPrezentaciaFont();
            label1.Font = pisma.CreatePodnadpisPrezentaciaFont();

            cisloHraca1Label.Font = pisma.CreateStriedaniaFont();
            menoHraca1Label.Font = pisma.CreateStriedaniaFont();
            cisloHraca2Label.Font = pisma.CreateStriedaniaFont();
            menoHraca2Label.Font = pisma.CreateStriedaniaFont();

            prezentacnyPanel.Visible = false;
            uvodnyPanel.Visible = true;
        }

        private void StriedanieForm_Load(object sender, EventArgs e)
        {
            LayoutSetter.ZobrazNaDruhejObrazovke(this);

            SpustiCas();
        }

        private void Casovac_Tick(object sender, EventArgs e)
        {
            if ((striedanyHrac == null) || (striedajuciHrac == null))
            {
                ZastavCas();
                Close();
            }
            else
            {
                if (prezentaciaSkoncila)
                {
                    ZastavCas();
                    Close();
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
    }
}
