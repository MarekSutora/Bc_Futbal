using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using BC_Futbal.Model;
using BC_Futbal.Setup;

namespace BC_Futbal.Forms
{
    public partial class ZltaKartaForm : Form
    {
        private const string fotkyAdresar = "\\Files\\Fotky\\";
        private const string kartyAdresar = "\\Files\\Karty\\";

        private Hrac prezentovanyHrac = null;
        private bool prezentaciaSkoncila;
        private int sirka;

        public ZltaKartaForm(int s, int cas, Hrac hrac, FontyTabule pisma, string animZ)
        {
            InitializeComponent();

            sirka = s;
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
