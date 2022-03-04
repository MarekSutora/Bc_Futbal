using LGR_Futbal.Properties;
using LGR_Futbal.Triedy;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using LGR_Futbal.Model;

namespace LGR_Futbal.Forms
{
    public partial class DatabazaForm : Form
    {
        #region Konstanty

        private const string nazovProgramuString = "LGR Futbal";
        private const string logaAdresar = "Databaza\\Loga\\";

        #endregion

        #region Atributy

        private Databaza dbs;
        private FutbalovyTim aktTim = null;
        private Hrac aktHrac = null;

        //private List<string> nazvyTimov = null;
        private List<FutbalovyTim> timy = null;
        private List<Hrac> hraci = null;
        //private string originalLogoCesta = string.Empty;
        //private string originalFotoCesta = string.Empty;
        private string currentDirectory = null;

        #endregion

        #region Konstruktor a metody

        public DatabazaForm(Databaza d, string folder)
        {
            InitializeComponent();

            if (Settings.Default.Jazyk == 1)
            {
                this.Text = "Správa databáze hráčů";
                infoLabel1.Text = "Seznam týmů";
                //zrusitButton.Text = "Zavřít   ";
                addButton.Text = addButton.Text.Replace("Vložiť", "Vložit");
                addButton.Text = addButton.Text.Replace("tím", "tým");
                editButton.Text = editButton.Text.Replace("Zmeniť", "Změnit");
                removeButton.Text = removeButton.Text.Replace("tím", "tým");
                removeButton.Text = removeButton.Text.Replace("Odstrániť", "Odstranit");
                importButton.Text = importButton.Text.Replace("tím", "tým");
                exportButton.Text = exportButton.Text.Replace("tím", "tým");

                addGroupBox.Text = "Vložení nového týmu";
                infoLabel2.Text = "Název týmu:";
                zmenaObrazkaButton.Text = "Změnit logo";
                zrusitLogoButton.Text = "Zrušit logo";
                spatButton.Text = "Zpět    ";
                vlozitButton.Text = vlozitButton.Text.Replace("Vložiť", "Vložit");
                vlozitButton.Text = vlozitButton.Text.Replace("tím", "tým");

                editGroupBox.Text = "Změna údajů týmu";
                label1.Text = "Název týmu:";
                editZmenaButton.Text = "Změnit logo";
                editZrusButton.Text = "Zrušit logo";
                editBackButton.Text = "Zpět    ";
                editHraciButton.Text = "Provést změny \nseznamu hráčů";
                editConfirmButton.Text = editConfirmButton.Text.Replace("zmeny", "změny");
                editConfirmButton.Text = editConfirmButton.Text.Replace("Potvrdiť", "Potvrdit");
            }
            //nazvyTimov = new List<string>();
            dbs = d;
            currentDirectory = folder;
            FillTimyCB();
            kategoriaComboBox.Items.Add("");
            kategoriaCombobox2.Items.Add("");
            for (int i = 0; i < dbs.GetKategorie().Count; i++)
            {
                kategoriaComboBox.Items.Add(dbs.GetKategorie()[i]);
                kategoriaCombobox2.Items.Add(dbs.GetKategorie()[i]);

            }
            button6.Enabled = false;
            button7.Enabled = false;
            vlozHracaGroupBox.Visible = true;
            if (timy.Count > 0)
            {
                timyListBox.SelectedIndex = 0;
                editButton.Enabled = true;
                zapasButton.Enabled = true;
                removeButton.Enabled = true;
                exportButton.Enabled = true;
            }
        }

        private void FillTimyCB()
        {
            timyListBox.Items.Clear();
            timHracCB.Items.Clear();
            timFilterCB.Items.Clear();
            //nazvyTimov.Clear();
            timy = dbs.GetTimy();
            timFilterCB.Items.Add("Všetci hráči");
            timFilterCB.Items.Add("Nezaradení");

            for (int i = 0; i < timy.Count; i++)
            {
                //nazvyTimov.Add(dbs.ZoznamTimov[i].NazovTimu);
                timyListBox.Items.Add(timy[i].NazovTimu);
                timHracCB.Items.Add(timy[i].NazovTimu);
                timFilterCB.Items.Add(timy[i].NazovTimu);
                editTimComboBox.Items.Add(timy[i].NazovTimu);
            }
        }

        private void ZrusitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            //originalLogoCesta = string.Empty;
            aktTim.LogoImage = null;
            logoPictureBox.Image = null;
            nazovTextBox.Text = string.Empty;
            editGroupBox.Visible = false;
            addGroupBox.Visible = true;
            nazovTextBox.Focus();
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
                    logoPictureBox.Image = Image.FromFile(ofd.FileName);
                    aktTim.LogoImage = Image.FromFile(ofd.FileName);
                    //originalLogoCesta = ofd.FileName;
                }
            }
            catch
            {
                logoPictureBox.Image = null;
                aktTim.LogoImage = null;
                //originalLogoCesta = string.Empty;
            }
        }

        private void ZrusitLogoButton_Click(object sender, EventArgs e)
        {
            logoPictureBox.Image = null;
            aktTim.LogoImage = null;
            //originalLogoCesta = string.Empty;
        }

        private void VlozitButton_Click(object sender, EventArgs e)
        {
            string novyNazov = nazovTextBox.Text.Trim();
            if (novyNazov.Equals(string.Empty))
                MessageBox.Show(Translate(1), nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                if (dbs.CheckNazovTimu(novyNazov))
                    MessageBox.Show(Translate(2), nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    FutbalovyTim t = new FutbalovyTim();
                    t.NazovTimu = novyNazov;
                    if (aktTim.LogoImage == null)
                        t.LogoImage = null;
                    else
                    {
                        t.LogoBlob = dbs.ImageToByteArray(aktTim.LogoImage);
                        t.Kategoria = kategoriaComboBox.SelectedIndex + 1;
                    }
                    try
                    {
                        dbs.InsertFutbalovyTeam(t);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    editButton.Enabled = true;
                    zapasButton.Enabled = true;
                    removeButton.Enabled = true;
                    exportButton.Enabled = true;
                    addGroupBox.Visible = false;
                    FillTimyCB();
                }
            }
        }

        private void SpatButton_Click(object sender, EventArgs e)
        {
            addGroupBox.Visible = false;
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            addGroupBox.Visible = false;
            ZobrazEdit();
        //    originalLogoCesta = string.Empty;
        //    aktTim = timy[timyListBox.SelectedIndex];
        //    editNazovTextBox.Text = aktTim.NazovTimu;
        //    kategoriaCombobox2.SelectedIndex = aktTim.Kategoria - 1;
        //    try
        //    {
        //        //originalLogoCesta = currentDirectory + "\\" + logaAdresar + aktTim.Logo;
        //        //editPictureBox.Image = Image.FromFile(originalLogoCesta);
        //        if (aktTim != null && aktTim.LogoBlob != null)
        //        {
        //            editPictureBox.Image = aktTim.LogoImage;
        //        }
        //        else
        //        {
        //            editPictureBox.Image = null;
        //        }
        //    }
        //    catch
        //    {
        //        originalLogoCesta = string.Empty;
        //        editPictureBox.Image = null;
        //    }
        //    editGroupBox.Visible = true;
        //    addGroupBox.Visible = false;
        //    editNazovTextBox.Focus();
        }

        private void ZapasButton_Click(object sender, EventArgs e)
        {
            FutbalovyTim tim = dbs.ZoznamTimov[timyListBox.SelectedIndex];
            if (tim.ZoznamHracov.Count == 0)
                MessageBox.Show(Translate(3), nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                HraciZapasForm formular = new HraciZapasForm(tim);
                formular.Show();
            }
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            addGroupBox.Visible = false;
            editGroupBox.Visible = false;

            //FutbalovyTim t = dbs.ZoznamTimov[timyListBox.SelectedIndex];
            //var i = timyListBox.Items[timyListBox.SelectedIndex];
            if (MessageBox.Show(Translate(4) + timyListBox.SelectedItem.ToString() + "?", nazovProgramuString, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                dbs.VymazTim(timy[timyListBox.SelectedIndex]);
                FillTimyCB();
                if (timyListBox.Items.Count > 0)
                    timyListBox.SelectedIndex = 0;
                else
                {
                    editButton.Enabled = false;
                    zapasButton.Enabled = false;
                    removeButton.Enabled = false;
                    exportButton.Enabled = false;
                }
            }
        }

        private void EditZmenaButton_Click(object sender, EventArgs e)
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
                    editPictureBox.Image = Image.FromFile(ofd.FileName);
                    //originalLogoCesta = ofd.FileName;
                    aktTim.LogoImage = Image.FromFile(ofd.FileName);
                }
            }
            catch
            {
                editPictureBox.Image = null;
                //originalLogoCesta = string.Empty;
                aktTim.LogoImage = null;
            }
        }

        private void EditZrusButton_Click(object sender, EventArgs e)
        {
            editPictureBox.Image = null;
            //originalLogoCesta = string.Empty;
        }

        private void EditConfirmButton_Click(object sender, EventArgs e)
        {
            string novyNazov = editNazovTextBox.Text.Trim();
            if (novyNazov.Equals(string.Empty))
                MessageBox.Show(Translate(1), nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {

                if (dbs.CheckNazovTimu(novyNazov) && aktTim.NazovTimu != novyNazov)
                    MessageBox.Show(Translate(2), nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    aktTim.NazovTimu = novyNazov;
                    if (aktTim.LogoImage != null)
                    {
                        aktTim.LogoBlob = null;
                        aktTim.LogoBlob = dbs.ImageToByteArray(aktTim.LogoImage);
                    }
                    //timyListBox.Items[timyListBox.SelectedIndex] = aktTim.NazovTimu;
                    try
                    {
                        aktTim.Kategoria = kategoriaCombobox2.SelectedIndex;
                        dbs.UpdateTim(aktTim);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    FillTimyCB();
                    editGroupBox.Visible = false;
                }
            }
        }

        private void EditHraciButton_Click(object sender, EventArgs e)
        {
            HraciForm hraciForm = new HraciForm(dbs, aktTim, currentDirectory, false);
            hraciForm.Show();
        }

        private void EditBackButton_Click(object sender, EventArgs e)
        {
            editGroupBox.Visible = false;
        }

        private void TimyListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            addGroupBox.Visible = false;
            ZobrazEdit();
        }

        private void timyListBox_DoubleClick(object sender, EventArgs e)
        {
            ZobrazEdit();
            HraciForm hraciForm = new HraciForm(dbs, aktTim, currentDirectory, false);
            hraciForm.Show();

        }

        private void ZobrazEdit()
        {
            //originalLogoCesta = string.Empty;
            if (timyListBox.SelectedIndex >= 0)
            {
                aktTim = timy[timyListBox.SelectedIndex];
                editNazovTextBox.Text = aktTim.NazovTimu;
                kategoriaCombobox2.SelectedIndex = aktTim.Kategoria - 1;
                
                try
                {
                    //originalLogoCesta = currentDirectory + "\\" + logaAdresar + aktTim.Logo;
                    //editPictureBox.Image = Image.FromFile(originalLogoCesta);
                    if (aktTim.LogoBlob != null)
                    {
                        editPictureBox.Image = aktTim.LogoImage;
                    }
                    else
                    {
                        editPictureBox.Image = null;
                    }
                }
                catch
                {
                    //originalLogoCesta = string.Empty;
                    editPictureBox.Image = null;
                }
                editGroupBox.Visible = true;
                addGroupBox.Visible = false;
                editNazovTextBox.Focus();
            }
        }

        private string Translate(int cisloVety)
        {
            if (Settings.Default.Jazyk == 0)
            {
                switch (cisloVety)
                {
                    case 1: return "Názov tímu nesmie byť prázdny!";
                    case 2: return "V databáze sa už nachádza tím s týmto názvom!";
                    case 3: return "Tím neobsahuje žiadneho hráča!";
                    case 4: return "Naozaj chcete odstrániť z databázy tím ";
                    case 5: return "Tím ";
                    case 6: return " bol úspešne exportovaný.";
                }
            }
            else if (Settings.Default.Jazyk == 1)
            {
                switch (cisloVety)
                {
                    case 1: return "Název týmu nesmí být prázdný!";
                    case 2: return "V databázi se již nachází tým s tímto názvem!";
                    case 3: return "Tým neobsahuje žádného hráče!";
                    case 4: return "Opravdu chcete odebrat z databáze tým ";
                    case 5: return "Tým ";
                    case 6: return " byl úspěšně exportován.";
                }
            }

            return string.Empty;
        }

        private void DatabazaForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        #endregion

        private void timyButton_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void hracButton_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            vlozHracaGroupBox.Visible = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            vlozHracaGroupBox.Visible = false;
            editHracGroupBox.Visible = true;
            try
            {
                int index = -1;
                aktHrac = dbs.getHrac(hraci[hraciListBox.SelectedIndex].IdHrac);
                
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
                editTimComboBox.SelectedIndex = index;
                editRichTextBox.Text = aktHrac.Poznamka;
                pictureBox.Image = aktHrac.FotkaImage;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void zrusitObrazokButton_Click(object sender, EventArgs e)
        {
            pictureBox.Image = null;
            //originalFotoCesta = string.Empty;
        }

        private void vlozFotobtn_Click(object sender, EventArgs e)
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
                    //originalFotoCesta = ofd.FileName;
                }
            }
            catch
            {
                fotkaPictureBox.Image = null;
                //originalFotoCesta = string.Empty;
            }
        }

        private void vlozHracaButton_Click(object sender, EventArgs e)
        {
            vlozHracaGroupBox.Visible = true;
            editHracGroupBox.Visible = false;
            Hrac h = new Hrac();
            string Meno = nazovTextBox.Text.Trim();
            string Priezvisko = nazovTextBox.Text.Trim();
            bool pokracuj = true;
            if (!Meno.Equals(string.Empty))
            {
                MessageBox.Show("Hráčovi chýba meno", nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                pokracuj = false;
            }
            if (!Priezvisko.Equals(string.Empty))
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
                if (true)
                    h.Fotka = null;
                else
                {
                    //FileInfo fi = new FileInfo(originalFotoCesta);
                    //if (!originalLogoCesta.Contains(currentDirectory + "\\" + logaAdresar))
                    //{
                    //    if (!File.Exists(currentDirectory + "\\" + logaAdresar + fi.Name))
                    //        File.Copy(originalLogoCesta, currentDirectory + "\\" + logaAdresar + fi.Name);
                    //}
                    //h.Fotka = originalFotoCesta;
                }
                try
                {
                    h.CisloDresu = cisloHracaTextBox.Text;
                    h.Meno = menoTextBox.Text;
                    h.Priezvisko = priezviskoTextBox.Text;
                    h.Pozicia = postTextBox.Text;
                    h.DatumNarodenia = datumPicker.Value;
                    h.Poznamka = poznamkaRichTextBox.Text;
                    h.IdFutbalovyTim = timHracCB.SelectedIndex == -1 ? 0 : timy[timHracCB.SelectedIndex].IdFutbalovyTim;
                    dbs.InsertHrac(h);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                hraciListBox.SelectedIndex = hraci.Count - 1;
                button7.Enabled = true;
                button6.Enabled = true;
                cisloHracaTextBox.Text = string.Empty;
                menoTextBox.Text = string.Empty;
                priezviskoTextBox.Text = string.Empty;
                postTextBox.Text = string.Empty;
                poznamkaRichTextBox.Text = string.Empty;

                FillTimyCB();
            }
        }

        private void filterHracovbtn_Click(object sender, EventArgs e)
        {
            vlozHracaGroupBox.Visible = false;
            ZobrazEditHraca();
        }
        private void ZobrazEditHraca()
        {
            hraciListBox.Items.Clear();
            try
            {
                if (timFilterCB.SelectedIndex == -1 || timFilterCB.SelectedIndex == 0)
                {
                    hraci = dbs.GetVsetciHraci();
                    foreach (var hrac in hraci)
                    {
                        hraciListBox.Items.Add(hrac.Meno + " " + hrac.Priezvisko);
                    }
                }
                else if (timFilterCB.SelectedIndex == 1)
                {
                    hraci = dbs.GetNezaradeniHraci();
                    foreach (var hrac in hraci)
                    {
                        hraciListBox.Items.Add(hrac.Meno + " " + hrac.Priezvisko);
                    }
                }
                else
                {
                    hraci = dbs.GetHraciVTime(timy[timFilterCB.SelectedIndex - 2].IdFutbalovyTim); ;
                    foreach (var hrac in hraci)
                    {
                        hraciListBox.Items.Add(hrac.Meno + " " + hrac.Priezvisko);
                    }
                }
                if (hraciListBox.Items.Count > 0)
                {
                    hraciListBox.SelectedIndex = 0;  
                    button7.Enabled = true;
                    button6.Enabled = true;
                }
                else
                {
                    button7.Enabled = false;
                    button6.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void timyListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            vlozHracaGroupBox.Visible = false;
            ZobrazEditHraca();
        }

        private void editHracConfirmbutton_Click(object sender, EventArgs e)
        {
            string Meno = nazovTextBox.Text.Trim();
            string Priezvisko = nazovTextBox.Text.Trim();
            bool pokracuj = true;
            if (!Meno.Equals(string.Empty))
            {
                MessageBox.Show("Hráčovi chýba meno", nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                pokracuj = false;
            }
            if (!Priezvisko.Equals(string.Empty))
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
                try
                {

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}

