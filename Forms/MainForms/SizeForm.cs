using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace LGR_Futbal.Forms
{
    public delegate void PrenesNastaveniaHandler(bool zobrazovatPozadie, bool zobrazNastavenia, int sirka, int vyska, int vyberJazyka);
    
    public partial class SizeForm : Form
    {
        #region Atributy a udalosti

        private bool aktivnaZmena = true;
        public event PrenesNastaveniaHandler OnSettingsConfirmation;
        private bool koniec = true;
        private int sirka, vyska;
        #endregion

        #region Konstruktor a metody

        public SizeForm(bool zobrazitPozadie, bool zobrazitNastaveniaPoSpusteni, int jazyk)
        {
            InitializeComponent();
            if (jazyk == 1)
            {
                this.Text = "Nastavení velikosti zobrazovací plochy";
                aktivovatButton.Text = aktivovatButton.Text.Replace("Aktivovať", "Aktivovat");
                zrusitButton.Text = zrusitButton.Text.Replace("Zrušiť", "Zrušit");
                velkostGroupBox.Text = "Velikost zobrazovací plochy";
                sirkaLabel.Text = "Šířka:";
                vyskaLabel.Text = "Výška:";
                infoLabel.Text = "Poznámka: Poměr stran je fixován na 16:9!";
                aktLabel.Text = "Aktuálně rozlišení obrazovky je:";
                jazykGroupBox.Text = "Jazykové nastavení";
                pozadieCheckBox.Text = "Překrýt obrazovku černou barvou";
                initNastaveniaCheckBox.Text = "Zobrazovat toto okno při spuštění aplikace";
            }
            sirka = ZistiSirku();
            vyska = ZistiVysku();

            rozlisenieLabel.Text = sirka.ToString() + " x " + vyska.ToString();


            sirkaNumUpDown.Value = sirka;
            vyskaNumUpDown.Value = vyska;

            pozadieCheckBox.Checked = zobrazitPozadie;
            initNastaveniaCheckBox.Checked = zobrazitNastaveniaPoSpusteni;

            if (jazyk == 0)
            {
                skRadioButton.Checked = true;
                czRadioButton.Checked = false;
            }
            else
            {
                skRadioButton.Checked = false;
                czRadioButton.Checked = true;
            }
        }

        public int ZistiVysku()
        {
            Screen primaryDisplay = Screen.AllScreens.ElementAtOrDefault(0);
            Screen screen = Screen.AllScreens.FirstOrDefault(s => s != primaryDisplay) ?? primaryDisplay;
            return screen.Bounds.Height;
        }

        public int ZistiSirku()
        {
            Screen primaryDisplay = Screen.AllScreens.ElementAtOrDefault(0);
            Screen screen = Screen.AllScreens.FirstOrDefault(s => s != primaryDisplay) ?? primaryDisplay;
            return screen.Bounds.Width;
        }

        private void SirkaNumUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (aktivnaZmena)
            {
                // Prepocet vysky vzhladom na novu sirku v pomere 16:9
                int aktualnaHodnota = (int)sirkaNumUpDown.Value;
                aktivnaZmena = false;
                vyskaNumUpDown.Value = (9 * aktualnaHodnota) / 16;
                aktivnaZmena = true;
            }
        }

        private void VyskaNumUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (aktivnaZmena)
            {
                // Prepocet sirky vzhladom na novu vysku v pomere 16:9
                int aktualnaHodnota = (int)vyskaNumUpDown.Value;
                aktivnaZmena = false;
                sirkaNumUpDown.Value = (aktualnaHodnota * 16) / 9;
                aktivnaZmena = true;
            }
        }

        private void AktivovatButton_Click(object sender, EventArgs e)
        {
            if (OnSettingsConfirmation != null)
            {
                int s = (int)sirkaNumUpDown.Value;
                int v = (int)vyskaNumUpDown.Value;
                bool poz = pozadieCheckBox.Checked;
                bool initSet = initNastaveniaCheckBox.Checked;

                sirka = s;
                vyska = v;

                int j = -1;
                if (skRadioButton.Checked)
                    j = 0;
                else if(czRadioButton.Checked)
                    j = 1;

                OnSettingsConfirmation(poz, initSet, s, v, j);
            }
            koniec = false;
            this.Close();
        }

        

        public bool Vypnut()
        {
            return koniec;
        }

        private void ZrusitButton_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void SizeForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        #endregion

    }
}
