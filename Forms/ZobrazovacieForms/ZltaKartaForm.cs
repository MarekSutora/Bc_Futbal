using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using LGR_Futbal.Model;
using LGR_Futbal.Setup;

namespace LGR_Futbal.Forms
{
    public partial class ZltaKartaForm : Form
    {
        private const string fotkyAdresar = "\\Files\\Fotky\\";
        private const string kartyAdresar = "\\Files\\Karty\\";

        private Hrac prezentovanyHrac = null;
        private bool prezentaciaSkoncila;

        public ZltaKartaForm(int sirka, int cas, Hrac hrac, FontyTabule pisma, string animZ)
        {
            InitializeComponent();

            string adresar = Directory.GetCurrentDirectory();
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

            float pomer = (float)sirka / Width;
            Scale(new SizeF(pomer, pomer));

            LayoutSetter.NastavVelkostiElementov(this, pomer);

            if (prezentovanyHrac != null)
            {
                try
                {
                    if (prezentovanyHrac.FotkaImage != null)
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
            SpustiCas();
        }

        private void Casovac_Tick(object sender, EventArgs e)
        {
            if (prezentovanyHrac == null)
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
