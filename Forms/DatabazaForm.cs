using LGR_Futbal.Properties;
using LGR_Futbal.Triedy;
using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

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
        private Tim aktTim = null;
        private string originalLogoCesta = string.Empty;
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
                zrusitButton.Text = "Zavřít   ";
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

            dbs = d;
            currentDirectory = folder;

            foreach (Tim t in dbs.ZoznamTimov)
            {
                timyListBox.Items.Add(t.Nazov);
            }

            if (dbs.ZoznamTimov.Count > 0)
            {
                timyListBox.SelectedIndex = 0;
                editButton.Enabled = true;
                zapasButton.Enabled = true;
                removeButton.Enabled = true;
                exportButton.Enabled = true;
            }
        }

        private void ZrusitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            originalLogoCesta = string.Empty;
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
                    originalLogoCesta = ofd.FileName;
                }
            }
            catch
            {
                logoPictureBox.Image = null;
                originalLogoCesta = string.Empty;
            }
        }

        private void ZrusitLogoButton_Click(object sender, EventArgs e)
        {
            logoPictureBox.Image = null;
            originalLogoCesta = string.Empty;
        }

        private void VlozitButton_Click(object sender, EventArgs e)
        {
            string novyNazov = nazovTextBox.Text.Trim();
            if (novyNazov.Equals(string.Empty))
                MessageBox.Show(Translate(1), nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                if (dbs.NajstTim(novyNazov) != null)
                    MessageBox.Show(Translate(2), nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    Tim t = new Tim();
                    t.Nazov = novyNazov;
                    if (originalLogoCesta.Equals(string.Empty))
                        t.Logo = string.Empty;
                    else
                    {
                        FileInfo fi = new FileInfo(originalLogoCesta);
                        if (!originalLogoCesta.Contains(currentDirectory + "\\" + logaAdresar))
                        {
                            if (!File.Exists(currentDirectory + "\\" + logaAdresar + fi.Name))
                                File.Copy(originalLogoCesta, currentDirectory + "\\" + logaAdresar + fi.Name);
                        }
                        t.Logo = fi.Name;
                    }
                    dbs.ZoznamTimov.Add(t);

                    timyListBox.Items.Add(novyNazov);
                    timyListBox.SelectedIndex = timyListBox.Items.Count - 1;
                    editButton.Enabled = true;
                    zapasButton.Enabled = true;
                    removeButton.Enabled = true;
                    exportButton.Enabled = true;
                    addGroupBox.Visible = false;
                }
            }
        }

        private void SpatButton_Click(object sender, EventArgs e)
        {
            addGroupBox.Visible = false;
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            aktTim = dbs.ZoznamTimov[timyListBox.SelectedIndex];
            editNazovTextBox.Text = aktTim.Nazov;

            try
            {
                originalLogoCesta = currentDirectory + "\\" + logaAdresar + aktTim.Logo;
                editPictureBox.Image = Image.FromFile(originalLogoCesta);
            }
            catch
            {
                originalLogoCesta = string.Empty;
                editPictureBox.Image = null;
            }

            editGroupBox.Visible = true;
            addGroupBox.Visible = false;
            editNazovTextBox.Focus();
        }

        private void ZapasButton_Click(object sender, EventArgs e)
        {
            Tim tim = dbs.ZoznamTimov[timyListBox.SelectedIndex];
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

            Tim t = dbs.ZoznamTimov[timyListBox.SelectedIndex];
            var i = timyListBox.Items[timyListBox.SelectedIndex];
            if (MessageBox.Show(Translate(4) + t.Nazov + "?", nazovProgramuString, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                dbs.ZoznamTimov.Remove(t);
                timyListBox.Items.Remove(i);
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
                    originalLogoCesta = ofd.FileName;
                }
            }
            catch
            {
                editPictureBox.Image = null;
                originalLogoCesta = string.Empty;
            }
        }

        private void EditZrusButton_Click(object sender, EventArgs e)
        {
            editPictureBox.Image = null;
            originalLogoCesta = string.Empty;
        }

        private void EditConfirmButton_Click(object sender, EventArgs e)
        {
            string novyNazov = editNazovTextBox.Text.Trim();
            if (novyNazov.Equals(string.Empty))
                MessageBox.Show(Translate(1), nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                Tim pomTim = dbs.NajstTim(novyNazov);
                if ((pomTim != aktTim) && (pomTim != null))
                    MessageBox.Show(Translate(2), nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    aktTim.Nazov = novyNazov;
                    if (originalLogoCesta.Equals(string.Empty))
                        aktTim.Logo = string.Empty;
                    else
                    {
                        FileInfo fi = new FileInfo(originalLogoCesta);
                        if (!originalLogoCesta.Contains(currentDirectory + "\\" + logaAdresar))
                        {
                            if (!File.Exists(currentDirectory + "\\" + logaAdresar + fi.Name))
                                File.Copy(originalLogoCesta, currentDirectory + "\\" + logaAdresar + fi.Name);
                        }
                        aktTim.Logo = fi.Name;
                    }
                    timyListBox.Items[timyListBox.SelectedIndex] = aktTim.Nazov;

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
            editGroupBox.Visible = false;
        }

        private void timyListBox_DoubleClick(object sender, EventArgs e)
        {
            if (timyListBox.SelectedIndex >= 0)
            {
                aktTim = dbs.ZoznamTimov[timyListBox.SelectedIndex];
                editNazovTextBox.Text = aktTim.Nazov;

                try
                {
                    originalLogoCesta = currentDirectory + "\\" + logaAdresar + aktTim.Logo;
                    editPictureBox.Image = Image.FromFile(originalLogoCesta);
                }
                catch
                {
                    originalLogoCesta = string.Empty;
                    editPictureBox.Image = null;
                }

                editGroupBox.Visible = true;
                addGroupBox.Visible = false;
                editNazovTextBox.Focus();

                HraciForm hraciForm = new HraciForm(dbs, aktTim, currentDirectory, false);
                hraciForm.Show();
            }
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            ofd.InitialDirectory = currentDirectory + "\\Databaza";
            ofd.Filter = "xml files (.xml)|*.xml|txt files (.txt)|*.txt|csv files (.csv)|*.csv";
            if (ofd.ShowDialog() == DialogResult.OK)
                importujFile(ofd.FileName);
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            if (timyListBox.SelectedIndex >= 0)
            {
                aktTim = dbs.ZoznamTimov[timyListBox.SelectedIndex];
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.InitialDirectory = currentDirectory + "\\Databaza";
                sfd.Filter = "xml files (.xml)|*.xml|txt files (.txt)|*.txt|csv files (.csv)|*.csv";
                if (sfd.ShowDialog() == DialogResult.OK)
                    exportujFile(sfd.FileName);
            }
        }

        private void importujFile(string cesta)
        {
            if (cesta.EndsWith(".xml"))
            {
                TextReader textReader = null;
                bool uspech = true;
                Tim novyTim = null;

                try
                {
                    XmlSerializer deserializer = new XmlSerializer(typeof(Tim));
                    textReader = new StreamReader(cesta);
                    novyTim = (Tim)deserializer.Deserialize(textReader);
                }
                catch (Exception ex)
                {
                    uspech = false;
                    MessageBox.Show(ex.Message, nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (textReader != null)
                        textReader.Close();

                    if (uspech)
                    {
                        dbs.ZoznamTimov.Add(novyTim);
                        aktTim = novyTim;
                        timyListBox.Items.Add(novyTim.Nazov);
                        timyListBox.SelectedIndex = timyListBox.Items.Count - 1;
                        editGroupBox.Visible = false;
                        addGroupBox.Visible = false;
                    }
                }
            }
            else if ((cesta.EndsWith(".txt")) || (cesta.EndsWith(".csv")))
            {
                TextReader textReader = null;
                bool uspech = true;
                Tim novyTim = null;

                try
                {
                    textReader = new StreamReader(cesta);
                    novyTim = new Tim();
                    novyTim.Nazov = textReader.ReadLine();
                    novyTim.Logo = textReader.ReadLine();
                    int pocet = Convert.ToInt32(textReader.ReadLine());
                    textReader.ReadLine();
                    for (int i = 0; i < pocet; i++)
                    {
                        novyTim.ZoznamHracov.Add(new Hrac(textReader.ReadLine()));
                    }
                }
                catch (Exception ex)
                {
                    uspech = false;
                    MessageBox.Show(ex.Message, nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (textReader != null)
                        textReader.Close();

                    if (uspech)
                    {
                        dbs.ZoznamTimov.Add(novyTim);
                        aktTim = novyTim;
                        timyListBox.Items.Add(novyTim.Nazov);
                        timyListBox.SelectedIndex = timyListBox.Items.Count - 1;
                        editGroupBox.Visible = false;
                        addGroupBox.Visible = false;
                    }
                }
            }
        }

        private void exportujFile(string cesta)
        {
            if (cesta.EndsWith(".xml"))
            {
                TextWriter textWriter = null;
                bool uspech = true;

                try
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Tim));
                    textWriter = new StreamWriter(cesta);
                    serializer.Serialize(textWriter, aktTim);
                }
                catch (Exception ex)
                {
                    uspech = false;
                    MessageBox.Show(ex.Message, nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (textWriter != null)
                        textWriter.Close();

                    if (uspech)
                        MessageBox.Show(Translate(5) + aktTim.Nazov + Translate(6), nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if ((cesta.EndsWith(".txt")) || (cesta.EndsWith(".csv")))
            {
                TextWriter textWriter = null;
                bool uspech = true;

                try
                {
                    textWriter = new StreamWriter(cesta);
                    textWriter.WriteLine(aktTim.Nazov);
                    textWriter.WriteLine(aktTim.Logo);
                    textWriter.WriteLine(aktTim.ZoznamHracov.Count);

                    StringBuilder sb = new StringBuilder();
                    if (Settings.Default.Jazyk == 0)
                    {
                        sb.Append("Číslo hráča" + ";");
                        sb.Append("Meno" + ";");
                        sb.Append("Priezvisko" + ";");
                        sb.Append("Hrá aktuálny zápas" + ";");
                        sb.Append("Fotografia" + ";");
                        sb.Append("Post" + ";");
                        sb.Append("Dátum narodenia" + ";");
                        sb.Append("Žltá karta" + ";");
                        sb.Append("Červená karta" + ";");
                        sb.Append("Poznámka" + ";");
                        sb.Append("Náhradník" + ";");
                        sb.Append("Funkcionár");
                    }
                    else
                    {
                        sb.Append("Číslo hráče" + ";");
                        sb.Append("Jméno" + ";");
                        sb.Append("Příjmení" + ";");
                        sb.Append("Hraje aktuální zápas" + ";");
                        sb.Append("Fotografie" + ";");
                        sb.Append("Post" + ";");
                        sb.Append("Datum narození" + ";");
                        sb.Append("Žlutá karta" + ";");
                        sb.Append("Červená karta" + ";");
                        sb.Append("Poznámka" + ";");
                        sb.Append("Náhradník" + ";");
                        sb.Append("Funkcionář");
                    }
                    textWriter.WriteLine(sb.ToString());

                    foreach (Hrac h in aktTim.ZoznamHracov)
                    {
                        textWriter.WriteLine(h.toCSVString());
                    }
                }
                catch (Exception ex)
                {
                    uspech = false;
                    MessageBox.Show(ex.Message, nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (textWriter != null)
                        textWriter.Close();

                    if (uspech)
                        MessageBox.Show(Translate(5) + aktTim.Nazov + Translate(6), nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private string Translate(int cisloVety)
        {
            if (Settings.Default.Jazyk == 0)
            {
                switch(cisloVety)
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
    }
}
