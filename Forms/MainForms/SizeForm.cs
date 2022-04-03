using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace LGR_Futbal.Forms
{
    public delegate void NastaveniaPotvrdenieHandler(bool zobrazovatPozadie, bool zobrazNastavenia, int sirka, int vyska);
    
    public partial class SizeForm : Form
    {
        #region Atributy a udalosti

        private bool aktivnaZmena = true;
        public event NastaveniaPotvrdenieHandler OnNastaveniaPotvrdenie;
        private bool koniec = true;
        private int sirka, vyska;
        #endregion

        #region Konstruktor a metody

        public SizeForm(bool zobrazitPozadie, bool zobrazitNastaveniaPoSpusteni)
        {
            InitializeComponent();

            sirka = ZistiSirku();
            vyska = ZistiVysku();

            rozlisenieLabel.Text = sirka.ToString() + " x " + vyska.ToString();


            sirkaNumUpDown.Value = sirka;
            vyskaNumUpDown.Value = vyska;

            pozadieCheckBox.Checked = zobrazitPozadie;
            initNastaveniaCheckBox.Checked = zobrazitNastaveniaPoSpusteni;
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
            if (OnNastaveniaPotvrdenie != null)
            {
                int s = (int)sirkaNumUpDown.Value;
                int v = (int)vyskaNumUpDown.Value;
                bool poz = pozadieCheckBox.Checked;
                bool initSet = initNastaveniaCheckBox.Checked;

                sirka = s;
                vyska = v;

                OnNastaveniaPotvrdenie(poz, initSet, s, v);
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
