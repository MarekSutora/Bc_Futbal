using LGR_Futbal.Properties;
using LGR_Futbal.Triedy;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using LGR_Futbal.Model;

namespace LGR_Futbal.Forms
{
    public partial class HraciForm : Form
    {
        #region Konstanty

        private const string nazovProgramuString = "LGR Futbal";
        private const string fotkyAdresar = "Databaza\\Fotky\\";

        #endregion

        #region Atributy

        private FutbalovyTim tim;
        private Databaza databaza;
        private Hrac hrac = null;
        private string adresar;
        private string originalFotkaCesta = string.Empty;
        private List<FutbalovyTim> zoznamMoznychCielovHraca = null;
        private List<Hrac> zoznamVyfiltrovanychHracov = null;

        #endregion

        #region Konstruktor a metody

        private void vyfiltrujHracov()
        {
            zoznamVyfiltrovanychHracov = new List<Hrac>();
            hraciListBox.Items.Clear();

            foreach (Hrac hrac in tim.ZoznamHracov)
            {
                if ((hrac.HraAktualnyZapas) || (hrac.Nahradnik))
                {
                    zoznamVyfiltrovanychHracov.Add(hrac);

                    if (!hrac.CisloDresu.Equals(string.Empty))
                        hraciListBox.Items.Add(hrac.CisloDresu + ". " + hrac.Meno + " " + hrac.Priezvisko.ToUpper());
                    else
                        hraciListBox.Items.Add(hrac.Meno + " " + hrac.Priezvisko.ToUpper());
                }
            }

            if (zoznamVyfiltrovanychHracov.Count > 0)
            {
                hraciListBox.SelectedIndex = 0;
                editButton.Enabled = true;
                removeButton.Enabled = true;
            }
            else
            {
                editButton.Enabled = false;
                removeButton.Enabled = false;
            }

            spristupniPrestup();
        }

        private void zobrazVsetkychHracov()
        {
            zoznamVyfiltrovanychHracov = tim.ZoznamHracov;
            hraciListBox.Items.Clear();

            foreach (Hrac hrac in zoznamVyfiltrovanychHracov)
            {
                if (!hrac.CisloDresu.Equals(string.Empty))
                    hraciListBox.Items.Add(hrac.CisloDresu + ". " + hrac.Meno + " " + hrac.Priezvisko.ToUpper());
                else
                    hraciListBox.Items.Add(hrac.Meno + " " + hrac.Priezvisko.ToUpper());
            }

            if (zoznamVyfiltrovanychHracov.Count > 0)
            {
                hraciListBox.SelectedIndex = 0;
                editButton.Enabled = true;
                removeButton.Enabled = true;
            }
            else
            {
                editButton.Enabled = false;
                removeButton.Enabled = false;
            }

            spristupniPrestup();
        }

        private void spristupniPrestup()
        {
            if (cieleListBox.Items.Count > 0)
            {
                cieleListBox.SelectedIndex = 0;
                if (zoznamVyfiltrovanychHracov.Count > 0)
                    prestupButton.Enabled = true;
                else
                    prestupButton.Enabled = false;
            }
            else
                prestupButton.Enabled = false;
        }

        public HraciForm(Databaza d, FutbalovyTim t, string adr, bool aplikovatZapasovyFilter)
        {
            InitializeComponent();
            
            if (Settings.Default.Jazyk == 1)
            {
                this.Text = "Evidence hráčů";
                infoLabel1.Text = "Seznam hráčů";
                addButton.Text = addButton.Text.Replace("Pridať", "Přidat");
                addButton.Text = addButton.Text.Replace("hráča", "hráče");
                editButton.Text = editButton.Text.Replace("Zmeniť", "Změnit");
                prestupButton.Text = prestupButton.Text.Replace("Prestup", "Přestup");
                prestupButton.Text = prestupButton.Text.Replace("iného tímu", "jiného týmu");
                removeButton.Text = removeButton.Text.Replace("Odstrániť", "Odstranit");
                removeButton.Text = removeButton.Text.Replace("hráča", "hráče");
                showAllButton.Text = showAllButton.Text.Replace("tím", "tým");
                filterButton.Text = filterButton.Text.Replace("filter", "filtr ");

                zrusitButton.Text = "Zavřít   ";

                addGroupBox.Text = "Vložení nového hráče";
                label1.Text = "Číslo hráče:";
                label2.Text = "Jméno (*):";
                label3.Text = "Příjmení (*):";
                label5.Text = "Datum narození:";
                label8.Text = "Jiné záznamy:";

                zapasCheckBox.Text = "Hraje zápas";
                funkcionarCheckBox.Text = "Funkcionář";
                zltaKartaCheckBox.Text = "Žlutá karta";

                spatButton.Text = spatButton.Text.Replace("Späť", "Zpět");
                zmenaUdajovButton.Text = zmenaUdajovButton.Text.Replace("Uložiť", "Uložit");
                zmenaUdajovButton.Text = zmenaUdajovButton.Text.Replace("zmeny", "změny");
                vlozitButton.Text = vlozitButton.Text.Replace("Vložiť", "Vložit");
                vlozitButton.Text = vlozitButton.Text.Replace("hráča", "hráče");

                zmenaObrazkaButton.Text = "Změnit fotografii";
                zrusitObrazokButton.Text = "Zrušit fotografii";

                prestupGroupBox.Text = "Přestup hráče";
                label10.Text = "Seznam možných nových týmů";
                prestupSpatButton.Text = prestupSpatButton.Text.Replace("Späť", "Zpět");
                prestupConfirmButton.Text = prestupConfirmButton.Text.Replace("Presunúť ", "Přesunout");
                prestupConfirmButton.Text = prestupConfirmButton.Text.Replace("hráča", "hráče");
            }

            Text = Text + Translate(1) + t.NazovTimu;
            databaza = d;
            tim = t;
            adresar = adr;

            zoznamMoznychCielovHraca = new List<FutbalovyTim>();
            foreach (FutbalovyTim team in databaza.ZoznamTimov)
            {
                if (team != tim)
                {
                    zoznamMoznychCielovHraca.Add(team);
                    cieleListBox.Items.Add(team.NazovTimu);
                }
            }

            if (aplikovatZapasovyFilter)
                vyfiltrujHracov();
            else
                zobrazVsetkychHracov();
        }

        private void ZrusitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HraciListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            addGroupBox.Visible = false;
            prestupGroupBox.Visible = false;
        }

        private void InicializovatAddGroupBox()
        {
            originalFotkaCesta = string.Empty;
            fotkaPictureBox.Image = null;

            cisloHracaTextBox.Text = string.Empty;
            menoTextBox.Text = string.Empty;
            priezviskoTextBox.Text = string.Empty;
            postTextBox.Text = string.Empty;
            datumPicker.Value = DateTime.Today;
            poznamkaRichTextBox.Text = string.Empty;

            zapasCheckBox.Checked = false;
            zltaKartaCheckBox.Checked = false;
            cervenaKartaCheckBox.Checked = false;

            nahradnikCheckBox.Checked = false;
            funkcionarCheckBox.Checked = false;

            nahradnikCheckBox.Visible = false;
            zapasCheckBox.Visible = false;
            zltaKartaCheckBox.Visible = false;
            cervenaKartaCheckBox.Visible = false;

            addGroupBox.Text = Translate(2);

            zmenaUdajovButton.Visible = false;
            vlozitButton.Visible = true;

            menoTextBox.Focus();
        }

        private void InicializovatAddGroupBoxHracom()
        {
            try
            {
                originalFotkaCesta = adresar + "\\" + fotkyAdresar + hrac.Fotka;
                fotkaPictureBox.Image = Image.FromFile(originalFotkaCesta);
            }
            catch
            {
                originalFotkaCesta = string.Empty;
                fotkaPictureBox.Image = null;
            }

            cisloHracaTextBox.Text = hrac.CisloDresu;
            menoTextBox.Text = hrac.Meno;
            priezviskoTextBox.Text = hrac.Priezvisko;
            postTextBox.Text = hrac.Pozicia;
            datumPicker.Value = hrac.DatumNarodenia.Date;
            poznamkaRichTextBox.Text = hrac.Poznamka;

            zapasCheckBox.Checked = hrac.HraAktualnyZapas;
            zltaKartaCheckBox.Checked = hrac.ZltaKarta;
            cervenaKartaCheckBox.Checked = hrac.CervenaKarta;

            nahradnikCheckBox.Checked = hrac.Nahradnik;
            funkcionarCheckBox.Checked = hrac.Funkcionar;

            nahradnikCheckBox.Visible = true;
            zapasCheckBox.Visible = true;
            zltaKartaCheckBox.Visible = true;
            cervenaKartaCheckBox.Visible = true;

            addGroupBox.Text = Translate(3);

            vlozitButton.Visible = false;
            zmenaUdajovButton.Visible = true;

            menoTextBox.Focus();
        }

        private void VlozitButton_Click(object sender, EventArgs e)
        {
            string cisloHraca = cisloHracaTextBox.Text.Trim();
            string menoHraca = menoTextBox.Text.Trim();
            if (menoHraca.Equals(string.Empty))
            {
                MessageBox.Show(Translate(4), nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string priezviskoHraca = priezviskoTextBox.Text.Trim();
            if (priezviskoHraca.Equals(string.Empty))
            {
                MessageBox.Show(Translate(5), nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if ((zapasCheckBox.Checked) && (nahradnikCheckBox.Checked))
            {
                MessageBox.Show(Translate(10), nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string postHraca = postTextBox.Text.Trim();
            string poznamka = poznamkaRichTextBox.Text.Trim();

            Hrac novyHrac = new Hrac();
            novyHrac.CisloDresu = cisloHraca;
            novyHrac.Meno = menoHraca;
            novyHrac.Priezvisko = priezviskoHraca;
            novyHrac.Pozicia = postHraca;
            novyHrac.DatumNarodenia = datumPicker.Value.Date;
            novyHrac.Poznamka = poznamka;

            novyHrac.HraAktualnyZapas = zapasCheckBox.Checked;
            novyHrac.ZltaKarta = zltaKartaCheckBox.Checked;
            novyHrac.CervenaKarta = cervenaKartaCheckBox.Checked;
            novyHrac.Nahradnik = nahradnikCheckBox.Checked;
            novyHrac.Funkcionar = funkcionarCheckBox.Checked;

            if (originalFotkaCesta.Equals(string.Empty))
                novyHrac.Fotka = string.Empty;
            else
            {
                FileInfo fi = new FileInfo(originalFotkaCesta);
                if (!originalFotkaCesta.Contains(adresar + "\\" + fotkyAdresar))
                {
                    if (!File.Exists(adresar + "\\" + fotkyAdresar + fi.Name))
                        File.Copy(originalFotkaCesta, adresar + "\\" + fotkyAdresar + fi.Name);
                }
                novyHrac.Fotka = fi.Name;
            }

            tim.ZoznamHracov.Add(novyHrac);
            if (zoznamVyfiltrovanychHracov != tim.ZoznamHracov)
                zoznamVyfiltrovanychHracov.Add(novyHrac);

            if (!novyHrac.CisloDresu.Equals(string.Empty))
                hraciListBox.Items.Add(novyHrac.CisloDresu + ". " + novyHrac.Meno + " " + novyHrac.Priezvisko.ToUpper());
            else
                hraciListBox.Items.Add(novyHrac.Meno + " " + novyHrac.Priezvisko.ToUpper());
            
            hraciListBox.SelectedIndex = hraciListBox.Items.Count - 1;
            editButton.Enabled = true;
            
            if (cieleListBox.Items.Count > 0)
                prestupButton.Enabled = true;
            removeButton.Enabled = true;
            addGroupBox.Visible = false;
        }

        private void ZmenaUdajovButton_Click(object sender, EventArgs e)
        {
            string cisloHraca = cisloHracaTextBox.Text.Trim();
            string menoHraca = menoTextBox.Text.Trim();
            if (menoHraca.Equals(string.Empty))
            {
                MessageBox.Show(Translate(4), nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string priezviskoHraca = priezviskoTextBox.Text.Trim();
            if (priezviskoHraca.Equals(string.Empty))
            {
                MessageBox.Show(Translate(5), nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if ((zapasCheckBox.Checked) && (nahradnikCheckBox.Checked))
            {
                MessageBox.Show(Translate(10), nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string postHraca = postTextBox.Text.Trim();
            string poznamka = poznamkaRichTextBox.Text.Trim();

            hrac.CisloDresu = cisloHraca;
            hrac.Meno = menoHraca;
            hrac.Priezvisko = priezviskoHraca;
            hrac.Pozicia = postHraca;
            hrac.DatumNarodenia = datumPicker.Value.Date;
            hrac.Poznamka = poznamka;
            hrac.HraAktualnyZapas = zapasCheckBox.Checked;
            hrac.ZltaKarta = zltaKartaCheckBox.Checked;
            hrac.CervenaKarta = cervenaKartaCheckBox.Checked;
            hrac.Nahradnik = nahradnikCheckBox.Checked;
            hrac.Funkcionar = funkcionarCheckBox.Checked;

            if (originalFotkaCesta.Equals(string.Empty))
                hrac.Fotka = string.Empty;
            else
            {
                FileInfo fi = new FileInfo(originalFotkaCesta);
                if (!originalFotkaCesta.Contains(adresar + "\\" + fotkyAdresar))
                {
                    if (!File.Exists(adresar + "\\" + fotkyAdresar + fi.Name))
                        File.Copy(originalFotkaCesta, adresar + "\\" + fotkyAdresar + fi.Name);
                }
                hrac.Fotka = fi.Name;
            }

            if (!hrac.CisloDresu.Equals(string.Empty))
                hraciListBox.Items[hraciListBox.SelectedIndex] = hrac.CisloDresu + ". " + hrac.Meno + " " + hrac.Priezvisko.ToUpper();
            else
                hraciListBox.Items[hraciListBox.SelectedIndex] = hrac.Meno + " " + hrac.Priezvisko.ToUpper();

            addGroupBox.Visible = false;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            InicializovatAddGroupBox();

            prestupGroupBox.Visible = false;
            addGroupBox.Visible = true;
        }

        private void ZmenaObrazkaButton_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Multiselect = false;
                ofd.Filter = "jpeg files (*.jpg)|*.jpg|gif files (*.gif)|*.gif|png files (*.png)|*.png|All files (*.*)|*.*";
                ofd.FilterIndex = 1;
                ofd.RestoreDirectory = true;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    fotkaPictureBox.Image = Image.FromFile(ofd.FileName);
                    originalFotkaCesta = ofd.FileName;
                }
            }
            catch
            {
                fotkaPictureBox.Image = null;
                originalFotkaCesta = string.Empty;
            }
        }

        private void ZrusitObrazokButton_Click(object sender, EventArgs e)
        {
            fotkaPictureBox.Image = null;
            originalFotkaCesta = string.Empty;
        }

        private void SpatButton_Click(object sender, EventArgs e)
        {
            addGroupBox.Visible = false;
        }

        private void zmenaUdajov()
        {
            hrac = zoznamVyfiltrovanychHracov[hraciListBox.SelectedIndex];
            InicializovatAddGroupBoxHracom();

            prestupGroupBox.Visible = false;
            addGroupBox.Visible = true;
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            zmenaUdajov();
        }

        private void PrestupButton_Click(object sender, EventArgs e)
        {
            hrac = zoznamVyfiltrovanychHracov[hraciListBox.SelectedIndex];
            addGroupBox.Visible = false;

            if (!hrac.CisloDresu.Equals(string.Empty))
                prestupGroupBox.Text = Translate(6) + hrac.CisloDresu + ". " + hrac.Meno + " " + hrac.Priezvisko.ToUpper();
            else
                prestupGroupBox.Text = Translate(6) + hrac.Meno + " " + hrac.Priezvisko.ToUpper();

            prestupGroupBox.Visible = true;
        }

        private void PrestupConfirmButton_Click(object sender, EventArgs e)
        {
            FutbalovyTim cielovyTim = zoznamMoznychCielovHraca[cieleListBox.SelectedIndex];
            if (MessageBox.Show(Translate(7) + cielovyTim.NazovTimu + "?", nazovProgramuString, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                tim.ZoznamHracov.Remove(hrac);
                if (zoznamVyfiltrovanychHracov != tim.ZoznamHracov)
                    zoznamVyfiltrovanychHracov.Remove(hrac);

                var i = hraciListBox.Items[hraciListBox.SelectedIndex];
                hraciListBox.Items.Remove(i);
                cielovyTim.ZoznamHracov.Add(hrac);
                if (hraciListBox.Items.Count > 0)
                    hraciListBox.SelectedIndex = 0;
                else
                {
                    editButton.Enabled = false;
                    prestupButton.Enabled = false;
                    removeButton.Enabled = false;
                }
                prestupGroupBox.Visible = false;
            }
        }

        private void PrestupSpatButton_Click(object sender, EventArgs e)
        {
            prestupGroupBox.Visible = false;
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            addGroupBox.Visible = false;
            prestupGroupBox.Visible = false;

            Hrac h = tim.ZoznamHracov[hraciListBox.SelectedIndex];
            var i = hraciListBox.Items[hraciListBox.SelectedIndex];
            if (MessageBox.Show(Translate(8) + tim.NazovTimu + Translate(9), nazovProgramuString, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                tim.ZoznamHracov.Remove(h);
                hraciListBox.Items.Remove(i);
                if (hraciListBox.Items.Count > 0)
                    hraciListBox.SelectedIndex = 0;
                else
                {
                    editButton.Enabled = false;
                    prestupButton.Enabled = false;
                    removeButton.Enabled = false;
                }
            }
        }

        private void showAllButton_Click(object sender, EventArgs e)
        {
            addGroupBox.Visible = false;
            prestupGroupBox.Visible = false;
            zobrazVsetkychHracov();
        }

        private void filterButton_Click(object sender, EventArgs e)
        {
            addGroupBox.Visible = false;
            prestupGroupBox.Visible = false;
            vyfiltrujHracov();
        }

        private void hraciListBox_DoubleClick(object sender, EventArgs e)
        {
            if (hraciListBox.SelectedIndex >= 0)
                zmenaUdajov();
        }

        private void HraciForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private string Translate(int cisloVety)
        {
            if (Settings.Default.Jazyk == 0)
            {
                switch (cisloVety)
                {
                    case 1: return " - tím ";
                    case 2: return "Vloženie nového hráča";
                    case 3: return "Zmena údajov o hráčovi";
                    case 4: return "Nezadali ste správne meno hráča!";
                    case 5: return "Nezadali ste správne priezvisko hráča!";
                    case 6: return "Prestup hráča - ";
                    case 7: return "Naozaj chcete presunúť hráča do tímu ";
                    case 8: return "Naozaj chcete odstrániť z tímu ";
                    case 9: return " tohto hráča?";
                    case 10: return "Hráč nemôže hrať zápas na ihrisku a súčasne byť náhradníkom!";
                }
            }
            else if (Settings.Default.Jazyk == 1)
            {
                switch (cisloVety)
                {
                    case 1: return " - tým ";
                    case 2: return "Vložení nového hráče";
                    case 3: return "Změna údajů o hráči";
                    case 4: return "Nezadali jste správně jméno hráče!";
                    case 5: return "Nezadali jste správné příjmení hráče!";
                    case 6: return "Přestup hráče - ";
                    case 7: return "Opravdu chcete přesunout hráče do týmu ";
                    case 8: return "Opravdu chcete odstranit z týmu ";
                    case 9: return " tohoto hráče?";
                    case 10: return "Hráč nemůže hrát zápas na hřišti a současně být náhradníkem!";
                }
            }

            return string.Empty;
        }

        #endregion
    }
}
