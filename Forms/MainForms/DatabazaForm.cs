using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using LGR_Futbal.Model;
using LGR_Futbal.Databaza;

namespace LGR_Futbal.Forms
{
    public partial class DatabazaForm : Form
    {

        #region ATRIBUTY

        private string logoCesta = string.Empty;
        private string fotoCesta = string.Empty;
        private int rozhodcaIndex;
        private int timIndex;
        private int hracIndex;
        private int poslednyFilterHraci;

        private FutbalovyTim aktTim = null;
        private Hrac aktHrac = null;
        private Rozhodca aktRozhodca = null;
        private List<FutbalovyTim> timy = null;
        private List<Hrac> hraci = null;
        private List<Zapas> zapasy = null;
        private List<Rozhodca> rozhodcovia = null;
        private DBTimy dbtimy = null;
        private DBHraci dbhraci = null;
        private DBRozhodcovia dbrozhodcovia = null;
        private DBZapasy dbzapasy = null;

        #endregion ATRIBUTY

        public DatabazaForm(DBTimy dbt, DBHraci dbh, DBRozhodcovia dbr, DBZapasy dbz)
        {
            InitializeComponent();

            dbtimy = dbt;
            dbhraci = dbh;
            dbrozhodcovia = dbr;
            dbzapasy = dbz;

            hracPohlavieCB.Items.Add("");
            hracPohlavieCB.Items.Add("Muž");
            hracPohlavieCB.Items.Add("Žena");
            upravaPohlavieCB.Items.Add("");
            upravaPohlavieCB.Items.Add("Muž");
            upravaPohlavieCB.Items.Add("Žena");
            rozhodcaPohlavieCB.Items.Add("");
            rozhodcaPohlavieCB.Items.Add("Muž");
            rozhodcaPohlavieCB.Items.Add("Žena");
            upravaRozhodcaPohlavieCB.Items.Add("");
            upravaRozhodcaPohlavieCB.Items.Add("Muž");
            upravaRozhodcaPohlavieCB.Items.Add("Žena");

            OdstranitHracaBtn.Enabled = false;
            UpravitHracaBtn.Enabled = false;
        }

        #region TIMY

        private async void DatabazaForm_Load(object sender, EventArgs e)
        {
            timy = await dbtimy.GetTimyAsync();
            NaplnTimyLB();

            if (kategoriaComboBox.Items.Count == 0)
            {
                kategoriaComboBox.Items.Add("");
                kategoriaCombobox2.Items.Add("");
                List<string> kategorie = await dbtimy.GetKategorieAsync();
                for (int i = 0; i < kategorie.Count; i++)
                {
                    kategoriaComboBox.Items.Add(kategorie[i]);
                    kategoriaCombobox2.Items.Add(kategorie[i]);
                }
            }
        }

        private void NaplnTimyLB()
        {
            TimyListBox.Items.Clear();
            hracTimCB.Items.Clear();
            timyFilterCB.Items.Clear();
            timyFilterCB.Items.Add("Všetci hráči");
            timyFilterCB.Items.Add("Nezaradení");
            hracTimCB.Items.Add("");
            upravaHracaTimCB.Items.Add("");

            timy.Sort((x, y) => x.NazovTimu.CompareTo(y.NazovTimu));

            for (int i = 0; i < timy.Count; i++)
            {
                TimyListBox.Items.Add(timy[i].NazovTimu);
                hracTimCB.Items.Add(timy[i].NazovTimu);
                timyFilterCB.Items.Add(timy[i].NazovTimu);
                upravaHracaTimCB.Items.Add(timy[i].NazovTimu);
            }
            if (timy.Count > 0)
            {
                TimyListBox.SelectedIndex = 0;
                ZmenitTimBtn.Enabled = true;
                OdstranitTimBtn.Enabled = true;
            }
        }

        private void ZobrazTimUprava()
        {
            pridatTimGroupBox.Visible = true;
            upravitTimGroupBox.Visible = true;
            pridatTimGroupBox.SendToBack();
            upravitTimGroupBox.BringToFront();

            timIndex = TimyListBox.SelectedIndex;
            logoCesta = string.Empty;
            aktTim = timy[TimyListBox.SelectedIndex];
            editNazovTextBox.Text = aktTim.NazovTimu;
            kategoriaCombobox2.SelectedIndex = aktTim.Kategoria;

            try
            {
                if (aktTim.LogoBlob != null)
                {
                    upravaLogoPictureBox.Image = aktTim.LogoImage;
                }
                else
                {
                    upravaLogoPictureBox.Image = null;
                }
            }
            catch
            {
                logoCesta = string.Empty;
                upravaLogoPictureBox.Image = null;
            }
            pridatTimGroupBox.Visible = false;
            pridatTimGroupBox.SendToBack();

            upravitTimGroupBox.Visible = true;
            upravitTimGroupBox.BringToFront();

            editNazovTextBox.Focus();

        }

        private void VlozitTimBtn_Click(object sender, EventArgs e)
        {
            logoCesta = string.Empty;
            logoPictureBox.Image = null;
            nazovTextBox.Text = string.Empty;
            pridatTimGroupBox.Visible = true;
            upravitTimGroupBox.Visible = true;
            upravitTimGroupBox.SendToBack();
            pridatTimGroupBox.BringToFront();
            nazovTextBox.Focus();
        }

        private void VlozitLogoBtn_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Multiselect = false;
                ofd.Filter = "jpeg files (*.jpg)|*.jpg|png files (*.png)|*.png|All files (*.*)|*.*";
                ofd.FilterIndex = 1;
                ofd.RestoreDirectory = true;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    logoPictureBox.Image = Image.FromFile(ofd.FileName);
                    logoCesta = ofd.FileName;
                }
            }
            catch
            {
                logoPictureBox.Image = null;
                logoCesta = string.Empty;
            }
        }

        private void ZrusitLogoBtn_Click(object sender, EventArgs e)
        {
            logoPictureBox.Image = null;
            logoCesta = string.Empty;
        }

        private void UlozitTimBtn_Click(object sender, EventArgs e)
        {
            string novyNazov = nazovTextBox.Text.Trim();
            if (novyNazov.Equals(string.Empty))
                MessageBox.Show("Názov tímu nesmie byť prázdny!", Properties.Settings.Default.NazovProgramu, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                if (dbtimy.CheckNazovTimu(novyNazov))
                    MessageBox.Show("V databáze sa už nachádza tím s týmto názvom!", Properties.Settings.Default.NazovProgramu, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    FutbalovyTim t = new FutbalovyTim();
                    t.NazovTimu = novyNazov;
                    t.Kategoria = kategoriaComboBox.SelectedIndex;
                    if (logoCesta.Equals(string.Empty))
                        t.Logo = null;
                    else
                    {
                        t.Logo = logoCesta;
                    }
                    try
                    {
                        dbtimy.InsertFutbalovyTeam(t);
                        timy.Add(t);
                        NaplnTimyLB();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), Properties.Settings.Default.NazovProgramu, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    upravitTimGroupBox.Visible = false;
                    pridatTimGroupBox.Visible = false;
                }
            }
        }

        private void ZmenitTimBtn_Click(object sender, EventArgs e)
        {
            if (TimyListBox.SelectedIndex != -1)
                ZobrazTimUprava();
        }

        private void OdstranitTimBtn_Click(object sender, EventArgs e)
        {
            pridatTimGroupBox.Visible = false;

            if (MessageBox.Show("Naozaj chcete odstrániť z databázy hráča " + TimyListBox.SelectedItem.ToString() + "?",
                Properties.Settings.Default.NazovProgramu, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                dbtimy.OdstranTim(timy[TimyListBox.SelectedIndex]);

                timy.RemoveAt(TimyListBox.SelectedIndex);
                NaplnTimyLB();
            }
        }

        private void UpravaZmenitLogoBtn_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Multiselect = false;
                ofd.Filter = "jpeg files (*.jpg)|*.jpg|png files (*.png)|*.png|All files (*.*)|*.*";
                ofd.FilterIndex = 1;
                ofd.RestoreDirectory = true;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    upravaLogoPictureBox.Image = Image.FromFile(ofd.FileName);
                    logoCesta = ofd.FileName;
                    aktTim.LogoImage = Image.FromFile(ofd.FileName);
                }
            }
            catch
            {
                upravaLogoPictureBox.Image = null;
                logoCesta = string.Empty;
            }
        }

        private void UpravaZrusitLogoBtn_Click(object sender, EventArgs e)
        {
            upravaLogoPictureBox.Image = null;
            logoCesta = string.Empty;
        }

        private void PotvrditUpravuTimBtn_Click(object sender, EventArgs e)
        {
            string novyNazov = editNazovTextBox.Text.Trim();
            if (novyNazov.Equals(string.Empty))
                MessageBox.Show("Názov tímu nesmie byť prázdny!", Properties.Settings.Default.NazovProgramu, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {

                if (dbtimy.CheckNazovTimu(novyNazov) && aktTim.NazovTimu != novyNazov)
                    MessageBox.Show("V databáze sa už nachádza tím s týmto názvom!", Properties.Settings.Default.NazovProgramu, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    if (!logoCesta.Equals(string.Empty))
                    {
                        aktTim.LogoBlob = null;
                        aktTim.Logo = logoCesta;
                    }
                    else if (upravaLogoPictureBox.Image != null)
                    {
                        aktTim.Logo = "x";
                    }
                    try
                    {
                        aktTim.NazovTimu = novyNazov;
                        aktTim.Kategoria = kategoriaCombobox2.SelectedIndex;
                        dbtimy.UpdateTim(aktTim);

                        timy[timIndex] = aktTim;
                        NaplnTimyLB();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), Properties.Settings.Default.NazovProgramu, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    upravitTimGroupBox.Visible = false;
                    pridatTimGroupBox.Visible = false;
                }
            }
        }

        private void TimyListBox_DoubleClick(object sender, EventArgs e)
        {
            if (TimyListBox.Items.Count > 0)
                ZobrazTimUprava();
        }

        #endregion TIMY

        #region HRACI

        private void UpravaZrusFotoBtn_Click(object sender, EventArgs e)
        {
            fotoPictureBox.Image = null;
            fotoCesta = string.Empty;
        }

        private void VlozitHracaBtn_Click(object sender, EventArgs e)
        {
            fotoCesta = string.Empty;
            fotoPictureBox.Image = null;

            VlozitHracaGroupBox.Visible = true;
            UpravaHracaGroupBox.Visible = true;
            UpravaHracaGroupBox.SendToBack();
            VlozitHracaGroupBox.BringToFront();
        }

        private void ZobrazUdajeHraca()
        {
            VlozitHracaGroupBox.Visible = true;
            UpravaHracaGroupBox.Visible = true;
            VlozitHracaGroupBox.SendToBack();
            UpravaHracaGroupBox.BringToFront();
            hracIndex = HraciListBox.SelectedIndex;
            try
            {
                int index = -1;
                aktHrac = dbhraci.GetHrac(hraci[HraciListBox.SelectedIndex].IdHrac);

                if (aktHrac.IdFutbalovyTim != 0)
                {
                    for (int i = 0; i < timy.Count; i++)
                    {
                        if (timy[i].IdFutbalovyTim == aktHrac.IdFutbalovyTim)
                        {
                            index = i + 1;
                            break;
                        }
                    }
                }
                editCisloTextBox.Text = aktHrac.CisloDresu;
                editMenoTextBox.Text = aktHrac.Meno;
                editPriezviskoTextBox.Text = aktHrac.Priezvisko;
                editPostTextBox.Text = aktHrac.Pozicia;
                upravaHracaTimCB.SelectedIndex = index;
                upravaHracaRTextBox.Text = aktHrac.Poznamka;
                upravaFotoPictureBox.Image = aktHrac.FotkaImage;
                if (aktHrac.Pohlavie == 'M')
                {
                    upravaPohlavieCB.SelectedIndex = 1;
                }
                else if (aktHrac.Pohlavie == 'Z')
                {
                    upravaPohlavieCB.SelectedIndex = 2;
                }
                else
                {
                    upravaPohlavieCB.SelectedIndex = 0;
                }
                editDateTimePicker.Value = aktHrac.DatumNarodenia;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Properties.Settings.Default.NazovProgramu, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void UpravitHracaBtn_Click(object sender, EventArgs e)
        {
            if (HraciListBox.Items.Count > 0)
                ZobrazUdajeHraca();
        }

        private void HraciListBox_DoubleClick(object sender, EventArgs e)
        {
            if (HraciListBox.Items.Count > 0)
                ZobrazUdajeHraca();
        }

        private void OdstranitHracaBtn_Click(object sender, EventArgs e)
        {
            try
            {
                UpravaHracaGroupBox.Visible = false;
                if (MessageBox.Show("Naozaj chcete odstrániť z databázy hráča " + HraciListBox.SelectedItem.ToString() + "?"
                , Properties.Settings.Default.NazovProgramu, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dbhraci.OdstranHrac(hraci[HraciListBox.SelectedIndex]);
                    hraci.RemoveAt(HraciListBox.SelectedIndex);
                    NaplnHraciLB();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Properties.Settings.Default.NazovProgramu, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void UpravaVlozitFotoBtn_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Multiselect = false;
                ofd.Filter = "jpeg files (*.jpg)|*.jpg|png files (*.png)|*.png|All files (*.*)|*.*";
                ofd.FilterIndex = 1;
                ofd.RestoreDirectory = true;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    fotoCesta = ofd.FileName;
                    upravaFotoPictureBox.Image = Image.FromFile(ofd.FileName);
                }
            }
            catch
            {
                upravaFotoPictureBox.Image = null;
                fotoCesta = string.Empty;
            }
        }

        private void VlozitFotoBtn_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Multiselect = false;
                ofd.Filter = "jpeg files (*.jpg)|*.jpg|png files (*.png)|*.png|All files (*.*)|*.*";
                ofd.FilterIndex = 1;
                ofd.RestoreDirectory = true;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    fotoPictureBox.Image = Image.FromFile(ofd.FileName);
                    fotoCesta = ofd.FileName;
                }
            }
            catch
            {
                fotoPictureBox.Image = null;
                fotoCesta = string.Empty;
            }
        }

        private void ZrusitFotoBtn_Click(object sender, EventArgs e)
        {
            fotoPictureBox.Image = null;
            fotoCesta = string.Empty;
        }

        private void UlozitHracaBtn_Click(object sender, EventArgs e)
        {
            //VlozitHracaGroupBox.BringToFront();
            //VlozitHracaGroupBox.Visible = true;
            //UpravaHracaGroupBox.SendToBack();
            //UpravaHracaGroupBox.Visible = false;
            Hrac h = new Hrac();
            string Meno = menoTextBox.Text.Trim();
            string Priezvisko = priezviskoTextBox.Text.Trim();
            bool pokracuj = true;
            if (Meno.Equals(string.Empty))
            {
                MessageBox.Show("Hráčovi chýba meno", Properties.Settings.Default.NazovProgramu, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                pokracuj = false;
            }
            if (Priezvisko.Equals(string.Empty))
            {
                MessageBox.Show("Hráčovi chýba priezvisko", Properties.Settings.Default.NazovProgramu, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                pokracuj = false;
            }
            if (!cisloHracaTextBox.Text.Equals(string.Empty) && !int.TryParse(cisloHracaTextBox.Text, out int cislo))
            {
                MessageBox.Show("Vkladajte len celé čísla", Properties.Settings.Default.NazovProgramu, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                pokracuj = false;
            }

            if (pokracuj)
            {
                if (fotoCesta.Equals(string.Empty))
                    h.Fotka = null;
                else
                {
                    h.Fotka = fotoCesta;
                }
                try
                {
                    h.CisloDresu = cisloHracaTextBox.Text;
                    h.Meno = menoTextBox.Text;
                    h.Priezvisko = priezviskoTextBox.Text;
                    h.Pozicia = postTextBox.Text;
                    h.DatumNarodenia = datumPicker.Value;
                    h.Poznamka = hracaRTextBox.Text;
                    h.IdFutbalovyTim = hracTimCB.SelectedIndex == -1 || hracTimCB.SelectedIndex == 0 ? 0 : timy[hracTimCB.SelectedIndex - 1].IdFutbalovyTim;
                    if (hracPohlavieCB.SelectedIndex == 0 || hracPohlavieCB.SelectedIndex == -1)
                    {
                        h.Pohlavie = 'X';
                    }
                    else
                    {
                        if (hracPohlavieCB.SelectedIndex == 1)
                        {
                            h.Pohlavie = 'M';
                        }
                        else
                        {
                            h.Pohlavie = 'Z';
                        }
                    }
                    dbhraci.InsertHrac(h);

                    if (poslednyFilterHraci == -1 || poslednyFilterHraci == 0 || poslednyFilterHraci == 1 || h.IdFutbalovyTim == timy[poslednyFilterHraci - 2].IdFutbalovyTim)
                        hraci.Add(h);

                    NaplnHraciLB();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), Properties.Settings.Default.NazovProgramu, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                UpravaHracaGroupBox.Visible = false;
                VlozitHracaGroupBox.Visible = false;
                cisloHracaTextBox.Text = string.Empty;
                menoTextBox.Text = string.Empty;
                priezviskoTextBox.Text = string.Empty;
                postTextBox.Text = string.Empty;
                hracaRTextBox.Text = string.Empty;
            }
        }

        private void FiltrujHracovBtn_Click(object sender, EventArgs e)
        {
            VlozitHracaGroupBox.Visible = true;
            UpravaHracaGroupBox.Visible = true;
            UpravaHracaGroupBox.SendToBack();
            VlozitHracaGroupBox.BringToFront();

            FiltrujHracov();
        }

        private async void FiltrujHracov()
        {
            fotoCesta = string.Empty;
            HraciListBox.Items.Clear();
            poslednyFilterHraci = timyFilterCB.SelectedIndex;
            try
            {
                if (poslednyFilterHraci == -1 || poslednyFilterHraci == 0)
                {
                    hraci = await dbhraci.GetVsetciHraciAsync();
                    NaplnHraciLB();
                }
                else if (poslednyFilterHraci == 1)
                {
                    hraci = await dbhraci.GetNezaradeniHraci();
                    NaplnHraciLB();
                }
                else
                {
                    hraci = await dbhraci.GetHraciVTime(timy[poslednyFilterHraci - 2].IdFutbalovyTim);
                    NaplnHraciLB();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Properties.Settings.Default.NazovProgramu, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void NaplnHraciLB()
        {
            HraciListBox.Items.Clear();
            hraci.Sort((x, y) => x.Priezvisko.CompareTo(y.Priezvisko));
            foreach (var hrac in hraci)
            {
                HraciListBox.Items.Add(hrac.Meno + " " + hrac.Priezvisko);
            }
            if (HraciListBox.Items.Count > 0)
            {
                HraciListBox.SelectedIndex = 0;
                UpravitHracaBtn.Enabled = true;
                OdstranitHracaBtn.Enabled = true;
            }
            else
            {
                UpravitHracaBtn.Enabled = false;
                OdstranitHracaBtn.Enabled = false;
            }
        }

        private void UlozitUpravaHracaBtn_Click(object sender, EventArgs e)
        {
            string Meno = editMenoTextBox.Text.Trim();
            string Priezvisko = editPriezviskoTextBox.Text.Trim();
            bool pokracuj = true;
            if (Meno.Equals(string.Empty))
            {
                MessageBox.Show("Hráčovi chýba meno", Properties.Settings.Default.NazovProgramu, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                pokracuj = false;
            }
            if (Priezvisko.Equals(string.Empty))
            {
                MessageBox.Show("Hráčovi chýba priezvisko", Properties.Settings.Default.NazovProgramu, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                pokracuj = false;
            }
            if (!cisloHracaTextBox.Text.Equals(string.Empty) && !int.TryParse(cisloHracaTextBox.Text, out int cislo))
            {
                MessageBox.Show("Vkladajte len celé čísla", Properties.Settings.Default.NazovProgramu, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                pokracuj = false;
            }
            if (pokracuj)
            {
                if (!fotoCesta.Equals(string.Empty))
                {
                    aktHrac.FotkaBlob = null;
                    aktHrac.Fotka = fotoCesta;
                }
                else if (upravaFotoPictureBox.Image != null)
                {
                    aktHrac.Fotka = "x";
                }
                try
                {
                    aktHrac.Meno = Meno;
                    aktHrac.CisloDresu = editCisloTextBox.Text;
                    aktHrac.Priezvisko = Priezvisko;
                    aktHrac.IdFutbalovyTim = upravaHracaTimCB.SelectedIndex == -1 || upravaHracaTimCB.SelectedIndex == 0 ? 0 : timy[upravaHracaTimCB.SelectedIndex - 1].IdFutbalovyTim;
                    aktHrac.Pozicia = editPostTextBox.Text;
                    aktHrac.DatumNarodenia = editDateTimePicker.Value;
                    aktHrac.Poznamka = upravaHracaRTextBox.Text;
                    if (upravaPohlavieCB.SelectedIndex == 0 || upravaPohlavieCB.SelectedIndex == -1)
                    {
                        aktHrac.Pohlavie = 'X';
                    }
                    else
                    {
                        if (upravaPohlavieCB.SelectedIndex == 1)
                        {
                            aktHrac.Pohlavie = 'M';
                        }
                        else
                        {
                            aktHrac.Pohlavie = 'Z';
                        }
                    }
                    dbhraci.UpdateHrac(aktHrac);

                    if (poslednyFilterHraci == -1 || poslednyFilterHraci == 0 || poslednyFilterHraci == 1 || aktHrac.IdFutbalovyTim == timy[poslednyFilterHraci - 2].IdFutbalovyTim)
                        hraci[hracIndex] = aktHrac;
                    else
                        hraci.RemoveAt(hracIndex);

                    NaplnHraciLB();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), Properties.Settings.Default.NazovProgramu, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                UpravaHracaGroupBox.Visible = false;
                VlozitHracaGroupBox.Visible = false;
            }
        }

        #endregion HRACI

        #region ROZHODCOVIA

        private void NaplnRozhodcoviaLB()
        {
            RozhodcoviaListBox.Items.Clear();
            rozhodcovia.Sort((x, y) => x.Priezvisko.CompareTo(y.Priezvisko));

            rozhodcaPohlavieCB.SelectedIndex = 0;
            for (int i = 0; i < rozhodcovia.Count; i++)
            {
                RozhodcoviaListBox.Items.Add(rozhodcovia[i].Meno + " " + rozhodcovia[i].Priezvisko);
            }

            if (rozhodcovia.Count > 0)
            {
                RozhodcoviaListBox.SelectedIndex = 0;
                UpravaRozhodcuBtn.Enabled = true;
                OdstranitRozhodcuBtn.Enabled = true;
            }
            else
            {
                UpravaRozhodcuBtn.Enabled = false;
                OdstranitRozhodcuBtn.Enabled = false;
            }
        }

        private void VlozitRozhodcuBtn_Click(object sender, EventArgs e)
        {
            addRozhodcuGroupBox.Visible = true;
            editRozhodcuGroupBox.Visible = true;
            editRozhodcuGroupBox.SendToBack();
            addRozhodcuGroupBox.BringToFront();
        }

        private void PotrvditUpravuRozhodcuBtn_Click(object sender, EventArgs e)
        {
            string Meno = editRozhodcaMeno.Text.Trim();
            string Priezvisko = editRozhdocaPriezvisko.Text.Trim();
            bool pokracuj = true;
            bool uspech = true;
            if (Meno.Equals(string.Empty))
            {
                MessageBox.Show("Rozhodcovi chýba meno", Properties.Settings.Default.NazovProgramu, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                pokracuj = false;
            }
            if (Priezvisko.Equals(string.Empty))
            {
                MessageBox.Show("Rozhodcovi chýba priezvisko", Properties.Settings.Default.NazovProgramu, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                pokracuj = false;
            }
            if (pokracuj)
            {
                aktRozhodca.Meno = Meno;
                aktRozhodca.Priezvisko = Priezvisko;
                if (upravaRozhodcaPohlavieCB.SelectedIndex == -1 || upravaRozhodcaPohlavieCB.SelectedIndex == 0)
                {
                    aktRozhodca.Pohlavie = 'X';
                }
                else
                {
                    if (upravaRozhodcaPohlavieCB.SelectedIndex == 1)
                    {
                        aktRozhodca.Pohlavie = 'M';
                    }
                    else
                    {
                        aktRozhodca.Pohlavie = 'Z';
                    }
                }
                try
                {
                    dbrozhodcovia.UpdateRozhodca(aktRozhodca);
                    rozhodcovia[rozhodcaIndex] = aktRozhodca;
                    NaplnRozhodcoviaLB();
                }
                catch (Exception ex)
                {
                    uspech = false;
                    MessageBox.Show(ex.ToString(), Properties.Settings.Default.NazovProgramu, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                if (uspech)
                    MessageBox.Show("Rozhodca úspešne upravený!", Properties.Settings.Default.NazovProgramu, MessageBoxButtons.OK);

                addRozhodcuGroupBox.Visible = false;
                editRozhodcuGroupBox.Visible = false;
            }
        }

        private void UlozitRozhodcuBtn_Click(object sender, EventArgs e)
        {
            string Meno = addRozhodcaMeno.Text.Trim();
            string Priezvisko = addRozhdocaPriezvisko.Text.Trim();
            bool pokracuj = true;
            bool uspech = true;
            if (Meno.Equals(string.Empty))
            {
                MessageBox.Show("Hráčovi chýba meno", Properties.Settings.Default.NazovProgramu, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                pokracuj = false;
            }
            if (Priezvisko.Equals(string.Empty))
            {
                MessageBox.Show("Hráčovi chýba priezvisko", Properties.Settings.Default.NazovProgramu, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                pokracuj = false;
            }
            if (pokracuj)
            {
                Rozhodca r = new Rozhodca();
                r.Meno = Meno;
                r.Priezvisko = Priezvisko;
                if (rozhodcaPohlavieCB.SelectedIndex == -1 || rozhodcaPohlavieCB.SelectedIndex == 0)
                {
                    r.Pohlavie = 'X';
                }
                else
                {
                    if (rozhodcaPohlavieCB.SelectedIndex == 1)
                    {
                        r.Pohlavie = 'M';
                    }
                    else
                    {
                        r.Pohlavie = 'Z';
                    }
                }
                try
                {
                    dbrozhodcovia.InsertRozhodca(r);
                    rozhodcovia.Add(r);
                    NaplnRozhodcoviaLB();
                }
                catch (Exception ex)
                {
                    uspech = false;
                    MessageBox.Show(ex.ToString(), Properties.Settings.Default.NazovProgramu, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                if (uspech)
                    MessageBox.Show("Rozhodca úspešne pridaný!", Properties.Settings.Default.NazovProgramu, MessageBoxButtons.OK);

                editRozhodcuGroupBox.SendToBack();
                addRozhodcuGroupBox.BringToFront();
                addRozhodcaMeno.Text = string.Empty;
                addRozhdocaPriezvisko.Text = string.Empty;
                rozhodcaPohlavieCB.SelectedIndex = 0;
            }
        }

        private void UpravaRozhodcuBtn_Click(object sender, EventArgs e)
        {

            NastavRozhodcoveUdaje();
        }

        private void NastavRozhodcoveUdaje()
        {
            rozhodcaIndex = RozhodcoviaListBox.SelectedIndex;
            addRozhodcuGroupBox.Visible = true;
            editRozhodcuGroupBox.Visible = true;
            addRozhodcuGroupBox.SendToBack();
            editRozhodcuGroupBox.BringToFront();

            try
            {
                aktRozhodca = dbrozhodcovia.GetRozhodca(rozhodcovia[RozhodcoviaListBox.SelectedIndex].IdRozhodca);

                editRozhodcaMeno.Text = aktRozhodca.Meno;
                editRozhdocaPriezvisko.Text = aktRozhodca.Priezvisko;
                if (aktRozhodca.Pohlavie == 'M')
                {
                    upravaRozhodcaPohlavieCB.SelectedIndex = 1;
                }
                else if (aktRozhodca.Pohlavie == 'Z')
                {
                    upravaRozhodcaPohlavieCB.SelectedIndex = 2;
                }
                else
                {
                    upravaRozhodcaPohlavieCB.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Properties.Settings.Default.NazovProgramu, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void RozhodcoviaListBox_DoubleClick(object sender, EventArgs e)
        {
            NastavRozhodcoveUdaje();
        }

        private void OdstranitRozhodcuBtn_Click(object sender, EventArgs e)
        {
            try
            {
                editRozhodcuGroupBox.Visible = false;
                if (MessageBox.Show("Naozaj chcete odstrániť z databázy rozhodcu " + RozhodcoviaListBox.SelectedItem.ToString() + "?"
                , Properties.Settings.Default.NazovProgramu, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dbrozhodcovia.OdstranRozhodca(rozhodcovia[RozhodcoviaListBox.SelectedIndex]);

                    rozhodcovia.RemoveAt(RozhodcoviaListBox.SelectedIndex);
                    NaplnRozhodcoviaLB();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Properties.Settings.Default.NazovProgramu, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion ROZHODCOVIA

        #region ZAPASY

        private void NaplnZapasyLB()
        {
            try
            {
                ZapasyListBox.Items.Clear();
                if (zapasy.Count > 0)
                {
                    zapasy.Sort((x, y) => y.DatumZapasu.CompareTo(x.DatumZapasu));

                    for (int i = 0; i < zapasy.Count; i++)
                    {
                        ZapasyListBox.Items.Add(zapasy[i].DatumZapasu + " " + zapasy[i].NazovDomaci + " " + zapasy[i].DomaciSkore + " : " + zapasy[i].HostiaSkore +
                            " " + zapasy[i].NazovHostia);
                    }
                    ZapasyListBox.SelectedIndex = 0;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Properties.Settings.Default.NazovProgramu, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void ZapasyListBox_DoubleClick(object sender, EventArgs e)
        {
            if (zapasy.Count > 0)
                ZapasUdalostForm();
        }

        private void VybratZapasBtn_Click(object sender, EventArgs e)
        {
            ZapasUdalostForm();
        }

        private async void ZapasUdalostForm()
        {
            Zapas zapas = zapasy[ZapasyListBox.SelectedIndex];
            try
            {
                zapas.Udalosti.Clear();
                zapas = await dbzapasy.NastavZapasAsync(zapas);
                UdalostiForm uf = new UdalostiForm(zapas, true, dbzapasy);
                uf.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Properties.Settings.Default.NazovProgramu, MessageBoxButtons.OK, MessageBoxIcon.Warning); ;
            }
        }

        private void OdstranitZapasBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Naozaj chcete odstrániť tento zápas z databázy?"
                    , Properties.Settings.Default.NazovProgramu, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dbzapasy.OdstranZapas(zapasy[ZapasyListBox.SelectedIndex]);

                    zapasy.RemoveAt(ZapasyListBox.SelectedIndex);
                    NaplnZapasyLB();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Properties.Settings.Default.NazovProgramu, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion ZAPASY

        #region INE

        private void TimyBtn_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void HraciBtn_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void RozhodcoviaBtn_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }

        private void ZapasyBtn_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 3;
        }

        private async void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 2)
            {
                if (RozhodcoviaListBox.Items.Count == 0)
                {
                    rozhodcovia = await dbrozhodcovia.GetRozhodcoviaAsync();
                    NaplnRozhodcoviaLB();
                }
            }
            else if (tabControl1.SelectedIndex == 3)
            {
                if (ZapasyListBox.Items.Count == 0)
                {
                    zapasy = await dbzapasy.GetZapasyAsync();
                    NaplnZapasyLB();
                }
            }
        }

        #endregion INE          
    }
}

