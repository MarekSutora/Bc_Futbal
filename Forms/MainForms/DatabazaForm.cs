using LGR_Futbal.Properties;
using LGR_Futbal.Setup;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using LGR_Futbal.Model;
using LGR_Futbal.Databaza;

namespace LGR_Futbal.Forms
{
    public partial class DatabazaForm : Form
    {

        #region ATRIBUTY

        private const string nazovProgramuString = "FutbalApp";

        private string logoCesta = string.Empty;
        private string fotoCesta = string.Empty;
        private int lastFilterHraci = 0;

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

            NaplnTimyLB();
            NaplnRozhodcoviaCB();
            kategoriaComboBox.Items.Add("");
            kategoriaCombobox2.Items.Add("");
            for (int i = 0; i < dbtimy.GetKategorie().Count; i++)
            {
                kategoriaComboBox.Items.Add(dbtimy.GetKategorie()[i]);
                kategoriaCombobox2.Items.Add(dbtimy.GetKategorie()[i]);

            }
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

            if (timy.Count > 0)
            {
                TimyListBox.SelectedIndex = 0;
                ZmenitTimBtn.Enabled = true;
                OdstranitTimBtn.Enabled = true;
            }

        }

        #region TIMY

        private void NaplnTimyLB()
        {
            TimyListBox.Items.Clear();
            hracTimCB.Items.Clear();
            timyFilterCB.Items.Clear();
            timy = dbtimy.GetTimy();
            timyFilterCB.Items.Add("Všetci hráči");
            timyFilterCB.Items.Add("Nezaradení");

            for (int i = 0; i < timy.Count; i++)
            {
                TimyListBox.Items.Add(timy[i].NazovTimu);
                hracTimCB.Items.Add(timy[i].NazovTimu);
                timyFilterCB.Items.Add(timy[i].NazovTimu);
                upravaHracaTimCB.Items.Add(timy[i].NazovTimu);
            }
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
                MessageBox.Show("Názov tímu nesmie byť prázdny!", nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                if (dbtimy.CheckNazovTimu(novyNazov))
                    MessageBox.Show("V databáze sa už nachádza tím s týmto názvom!", nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    FutbalovyTim t = new FutbalovyTim();
                    t.NazovTimu = novyNazov;
                    if (logoCesta.Equals(string.Empty))
                        t.Logo = null;
                    else
                    {
                        t.Logo = logoCesta;
                        t.Kategoria = kategoriaComboBox.SelectedIndex + 1;
                    }
                    try
                    {
                        dbtimy.InsertFutbalovyTeam(t);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    upravitTimGroupBox.Visible = true;
                    pridatTimGroupBox.Visible = true;

                    ZmenitTimBtn.Enabled = true;
                    OdstranitTimBtn.Enabled = true;
                    pridatTimGroupBox.Visible = false;
                    NaplnTimyLB();
                }
            }
        }

        private void ZmenitTimBtn_Click(object sender, EventArgs e)
        {
            ZobrazTimUprava();
        }

        private void OdstranitTimBtn_Click(object sender, EventArgs e)
        {
            pridatTimGroupBox.Visible = false;
            upravitTimGroupBox.Visible = false;

            if (MessageBox.Show("Naozaj chcete odstrániť z databázy hráča " + TimyListBox.SelectedItem.ToString() + "?",
                nazovProgramuString, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                dbtimy.OdstranTim(timy[TimyListBox.SelectedIndex]);
                NaplnTimyLB();
                if (TimyListBox.Items.Count > 0)
                    TimyListBox.SelectedIndex = 0;
                else
                {
                    ZmenitTimBtn.Enabled = false;
                    OdstranitTimBtn.Enabled = false;
                }
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
                MessageBox.Show("Názov tímu nesmie byť prázdny!", nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {

                if (dbtimy.CheckNazovTimu(novyNazov) && aktTim.NazovTimu != novyNazov)
                    MessageBox.Show("V databáze sa už nachádza tím s týmto názvom!", nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    NaplnTimyLB();
                    upravitTimGroupBox.Visible = false;
                    pridatTimGroupBox.Visible = false;
                }
            }
        }

        private void TimyListBox_DoubleClick(object sender, EventArgs e)
        {
            ZobrazTimUprava();
        }

        private void ZobrazTimUprava()
        {
            pridatTimGroupBox.Visible = true;
            upravitTimGroupBox.Visible = true;
            pridatTimGroupBox.SendToBack();
            upravitTimGroupBox.BringToFront();

            logoCesta = string.Empty;
            if (TimyListBox.SelectedIndex >= 0)
            {
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

        private void UpravitHracaBtn_Click(object sender, EventArgs e)
        {
            ZobrazUdajeHraca();
        }

        private void HraciListBox_DoubleClick(object sender, EventArgs e)
        {
            ZobrazUdajeHraca();
        }

        private void ZobrazUdajeHraca()
        {
            VlozitHracaGroupBox.Visible = true;
            UpravaHracaGroupBox.Visible = true;
            VlozitHracaGroupBox.SendToBack();
            UpravaHracaGroupBox.BringToFront();

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
                            index = i;
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
                MessageBox.Show(ex.ToString(), nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void OdstranitHracaBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Naozaj chcete odstrániť z databázy hráča " + HraciListBox.SelectedItem.ToString() + "?"
                , nazovProgramuString, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                dbhraci.OdstranHraca(hraci[HraciListBox.SelectedIndex]);
                FiltrujHracov(lastFilterHraci);
                if (HraciListBox.Items.Count > 0)
                    HraciListBox.SelectedIndex = 0;
                else
                {
                    UpravitHracaBtn.Enabled = false;
                    OdstranitHracaBtn.Enabled = false;
                }
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
            VlozitHracaGroupBox.BringToFront();
            VlozitHracaGroupBox.Visible = true;
            UpravaHracaGroupBox.SendToBack();
            UpravaHracaGroupBox.Visible = false;
            Hrac h = new Hrac();
            string Meno = menoTextBox.Text.Trim();
            string Priezvisko = priezviskoTextBox.Text.Trim();
            bool pokracuj = true;
            if (Meno.Equals(string.Empty))
            {
                MessageBox.Show("Hráčovi chýba meno", nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                pokracuj = false;
            }
            if (Priezvisko.Equals(string.Empty))
            {
                MessageBox.Show("Hráčovi chýba priezvisko", nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                pokracuj = false;
            }
            int cislo;
            if (!cisloHracaTextBox.Text.Equals(string.Empty) && !int.TryParse(cisloHracaTextBox.Text, out cislo))
            {
                MessageBox.Show("Vkladajte len celé čísla", nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    h.IdFutbalovyTim = hracTimCB.SelectedIndex == -1 ? 0 : timy[hracTimCB.SelectedIndex].IdFutbalovyTim;
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
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                UpravaHracaGroupBox.Visible = false;
                VlozitHracaGroupBox.Visible = false;

                UpravitHracaBtn.Enabled = true;
                OdstranitHracaBtn.Enabled = true;
                cisloHracaTextBox.Text = string.Empty;
                menoTextBox.Text = string.Empty;
                priezviskoTextBox.Text = string.Empty;
                postTextBox.Text = string.Empty;
                hracaRTextBox.Text = string.Empty;

                FilterZobrazHracov();
            }
        }

        private void FiltrujHracovBtn_Click(object sender, EventArgs e)
        {
            VlozitHracaGroupBox.Visible = true;
            VlozitHracaGroupBox.BringToFront();

            FilterZobrazHracov();
        }

        private void FilterZobrazHracov()
        {
            fotoCesta = string.Empty;
            HraciListBox.Items.Clear();
            try
            {
                if (timyFilterCB.SelectedIndex == -1 || timyFilterCB.SelectedIndex == 0)
                {
                    lastFilterHraci = 0;
                    hraci = dbhraci.GetVsetciHraci();
                    foreach (var hrac in hraci)
                    {
                        HraciListBox.Items.Add(hrac.Meno + " " + hrac.Priezvisko);
                    }
                }
                else if (timyFilterCB.SelectedIndex == 1)
                {
                    lastFilterHraci = 1;
                    hraci = dbhraci.GetNezaradeniHraci();
                    foreach (var hrac in hraci)
                    {
                        HraciListBox.Items.Add(hrac.Meno + " " + hrac.Priezvisko);
                    }
                }
                else
                {
                    int pom = 0;
                    hraci = dbhraci.GetHraciVTime(timy[timyFilterCB.SelectedIndex - 2].IdFutbalovyTim); ;
                    foreach (var hrac in hraci)
                    {
                        pom++;
                        HraciListBox.Items.Add(hrac.Meno + " " + hrac.Priezvisko);
                    }
                    lastFilterHraci = pom + 2;
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void FiltrujHracov(int filter)
        {
            fotoCesta = string.Empty;
            HraciListBox.Items.Clear();
            try
            {
                if (filter == 0)
                {
                    lastFilterHraci = 0;
                    hraci = dbhraci.GetVsetciHraci();
                    foreach (var hrac in hraci)
                    {
                        HraciListBox.Items.Add(hrac.Meno + " " + hrac.Priezvisko);
                    }
                }
                else if (filter == 1)
                {
                    lastFilterHraci = 1;
                    hraci = dbhraci.GetNezaradeniHraci();
                    foreach (var hrac in hraci)
                    {
                        HraciListBox.Items.Add(hrac.Meno + " " + hrac.Priezvisko);
                    }
                }
                else
                {
                    hraci = dbhraci.GetHraciVTime(timy[lastFilterHraci].IdFutbalovyTim); ;
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void UlozitUpravaHracaBtn_Click(object sender, EventArgs e)
        {
            string Meno = editMenoTextBox.Text.Trim();
            string Priezvisko = editPriezviskoTextBox.Text.Trim();
            bool pokracuj = true;
            if (Meno.Equals(string.Empty))
            {
                MessageBox.Show("Hráčovi chýba meno", nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                pokracuj = false;
            }
            if (Priezvisko.Equals(string.Empty))
            {
                MessageBox.Show("Hráčovi chýba priezvisko", nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                pokracuj = false;
            }
            int cislo;
            if (!cisloHracaTextBox.Text.Equals(string.Empty) && !int.TryParse(cisloHracaTextBox.Text, out cislo))
            {
                MessageBox.Show("Vkladajte len celé čísla", nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    aktHrac.IdFutbalovyTim = upravaHracaTimCB.SelectedIndex == -1 ? 0 : timy[upravaHracaTimCB.SelectedIndex].IdFutbalovyTim;
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
                    FiltrujHracov(lastFilterHraci);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                finally
                {
                    UpravaHracaGroupBox.Visible = false;
                    VlozitHracaGroupBox.Visible = false;

                }
            }
        }

        #endregion HRACI

        #region ROZHODCOVIA

        private void NaplnRozhodcoviaCB()
        {
            RozhodcoviaListBox.Items.Clear();
            rozhodcovia = dbrozhodcovia.GetRozhodcovia();

            for (int i = 0; i < rozhodcovia.Count; i++)
            {
                RozhodcoviaListBox.Items.Add(rozhodcovia[i].Meno + " " + rozhodcovia[i].Priezvisko);
            }

            if (rozhodcovia.Count > 0)
            {
                UpravaRozhodcuBtn.Enabled = true;
                OdstranitRozhodcuBtn.Enabled = true;
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
            if (Meno.Equals(string.Empty))
            {
                MessageBox.Show("Rozhdodcovi chýba meno", nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                pokracuj = false;
            }
            if (Priezvisko.Equals(string.Empty))
            {
                MessageBox.Show("Rozhdodcovi chýba priezvisko", nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString(), nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                finally
                {
                    NaplnRozhodcoviaCB();
                    editRozhodcuGroupBox.Visible = false;
                    addRozhodcuGroupBox.Visible = false;
                }
            }
        }

        private void UlozitRozhodcuBtn_Click(object sender, EventArgs e)
        {
            string Meno = addRozhodcaMeno.Text.Trim();
            string Priezvisko = addRozhdocaPriezvisko.Text.Trim();
            bool pokracuj = true;
            if (Meno.Equals(string.Empty))
            {
                MessageBox.Show("Hráčovi chýba meno", nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                pokracuj = false;
            }
            if (Priezvisko.Equals(string.Empty))
            {
                MessageBox.Show("Hráčovi chýba priezvisko", nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                pokracuj = false;
            }
            if (pokracuj)
            {
                Rozhodca r = new Rozhodca();
                r.Meno = Meno;
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
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString(), nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                finally
                {
                    NaplnRozhodcoviaCB();
                    editRozhodcuGroupBox.Visible = false;
                    addRozhodcuGroupBox.Visible = false;
                    addRozhodcaMeno.Text = string.Empty;
                    addRozhdocaPriezvisko.Text = string.Empty;
                    rozhodcaPohlavieCB.SelectedIndex = 0;
                }
            }
        }

        private void UpravaRozhodcuBtn_Click(object sender, EventArgs e)
        {

            NastavRozhodcoveUdaje();
        }

        private void NastavRozhodcoveUdaje()
        {
            addRozhodcuGroupBox.Visible = true;
            editRozhodcuGroupBox.Visible = true;
            addRozhodcuGroupBox.SendToBack();
            editRozhodcuGroupBox.BringToFront();

            try
            {
                if (RozhodcoviaListBox.SelectedIndex == -1)
                {
                    aktRozhodca = dbrozhodcovia.GetRozhodca(rozhodcovia[0].IdRozhodca);
                }
                else
                {
                    aktRozhodca = dbrozhodcovia.GetRozhodca(rozhodcovia[RozhodcoviaListBox.SelectedIndex].IdRozhodca);
                }


                editRozhodcaMeno.Text = aktRozhodca.Meno;
                editRozhdocaPriezvisko.Text = aktRozhodca.Priezvisko;
                if (aktRozhodca.Pohlavie == 'M')
                {
                    upravaRozhodcaPohlavieCB.SelectedIndex = 1;
                }
                else
                {
                    upravaRozhodcaPohlavieCB.SelectedIndex = 2;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void RozhodcoviaListBox_DoubleClick(object sender, EventArgs e)
        {
            NastavRozhodcoveUdaje();
        }

        private void OdstranitRozhodcuBtn_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Naozaj chcete odstrániť z databázy rozhodcu " + RozhodcoviaListBox.SelectedItem.ToString() + "?"
                , nazovProgramuString, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                dbrozhodcovia.OdstranRozhodcu(rozhodcovia[RozhodcoviaListBox.SelectedIndex]);
                NaplnRozhodcoviaCB();
                if (rozhodcovia.Count > 0)
                    RozhodcoviaListBox.SelectedIndex = 0;
                else
                {
                    UpravaRozhodcuBtn.Enabled = false;
                    OdstranitRozhodcuBtn.Enabled = false;
                }
            }
        }

        #endregion ROZHODCOVIA

        #region ZAPASY

        private void ZapasyListBox_DoubleClick(object sender, EventArgs e)
        {
            ZapasUdalostForm();
        }

        private void NaplnZapasyLB()
        {
            if (zapasy == null)
            {
                zapasy = dbzapasy.GetZapasy();
                for (int i = 0; i < zapasy.Count; i++)
                {
                    ZapasyListBox.Items.Add(zapasy[i].DatumZapasu + " " + zapasy[i].NazovDomaci + " " + zapasy[i].DomaciSkore + " : " + zapasy[i].HostiaSkore +
                        " " + zapasy[i].NazovHostia);
                }
            }

        }

        private void VybratZapasBtn_Click(object sender, EventArgs e)
        {
            ZapasUdalostForm();
        }

        private void ZapasUdalostForm()
        {
            try
            {
                if (zapasy[ZapasyListBox.SelectedIndex].Udalosti.Count == 0)
                    dbzapasy.NastavZapas(zapasy[ZapasyListBox.SelectedIndex]);

                UdalostiForm uf = new UdalostiForm(zapasy[ZapasyListBox.SelectedIndex], true, dbzapasy);
                uf.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Warning); ;
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

        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 3)
                NaplnZapasyLB();
        }

        #endregion INE        
    }
}

