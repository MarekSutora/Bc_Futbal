using LGR_Futbal.Properties;
using LGR_Futbal.Triedy;
using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Drawing;

namespace LGR_Futbal.Forms
{
    public delegate void FileSavedHandler(string s);
    public delegate void ObnovaFariebHandlerFF();
    public delegate void ColorsLoadedHandlerFF(FarebnaSchema fs);
    public delegate void FileSelectedHandlerFF(string cesta);

    public partial class FarbyForm : Form
    {
        private string adresar;
        //public event FileSavedHandler OnFileSaved;
        public event ObnovaFariebHandlerFF OnObnovaFariebFF;
        public event ColorsLoadedHandlerFF OnColorsLoadedFF;
        public event FileSelectedHandlerFF OnFileSelectedFF;
        private FarebnaSchema fs = null;

        public FarbyForm(string cesta, FarebnaSchema fs)
        {
            InitializeComponent();
            if (Settings.Default.Jazyk == 1)
            {
                this.Text = "Vytvoření vlastní barevné konfigurace";
                saveButton.Text = "Uložit   ";
                zrusitButton.Text = "Zavřít   ";
                obnovaFariebButton.Text = "Obnovit výrobní \nnastavení barev         ";
                loadColorsButton.Text = loadColorsButton.Text.Replace("Načítať", "Načíst ");
                loadColorsButton.Text = loadColorsButton.Text.Replace("nastavenia", "nastavení");
                loadColorsButton.Text = loadColorsButton.Text.Replace("farieb", "barev");
                aktivovatFarby.Text = "Aktivovat změny";



                button1.Text = "Změnit";
                button3.Text = "Změnit";
                button4.Text = "Změnit";
                button6.Text = "Změnit";
                button7.Text = "Změnit";

                label5.Text = "POLOČAS";
                label2.Text = "HOSTÉ";
                label1.Text = "DOMÁCÍ";
                
            }
            this.fs = fs;
            adresar = cesta;

            label1.ForeColor = fs.NadpisDomFarba();
            label2.ForeColor = fs.NadpisHosFarba();
            label3.ForeColor = fs.CasFarba();
            label4.ForeColor = fs.SkoreFarba();
            label5.ForeColor = fs.PolcasFarba();
        }

        private void zrusitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aktivovatFarby_Click(object sender, EventArgs e)
        {
            fs.CasFarba_r = label3.ForeColor.R;
            fs.CasFarba_g = label3.ForeColor.G;
            fs.CasFarba_b = label3.ForeColor.B;

            fs.NadpisDomFarba_r = label1.ForeColor.R;
            fs.NadpisDomFarba_g = label1.ForeColor.G;
            fs.NadpisDomFarba_b = label1.ForeColor.B;

            fs.NadpisHosFarba_r = label2.ForeColor.R;
            fs.NadpisHosFarba_g = label2.ForeColor.G;
            fs.NadpisHosFarba_b = label2.ForeColor.B;

            fs.SkoreFarba_r = label4.ForeColor.R;
            fs.SkoreFarba_g = label4.ForeColor.G;
            fs.SkoreFarba_b = label4.ForeColor.B;

            fs.PolcasFarba_r = label5.ForeColor.R;
            fs.PolcasFarba_g = label5.ForeColor.G;
            fs.PolcasFarba_b = label5.ForeColor.B;

            if (OnColorsLoadedFF != null)
            {
                OnColorsLoadedFF(fs);
            }
            Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = adresar;
            sfd.Filter = "xml files (*.xml)|*.xml";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                TextWriter textWriter = null;

                try
                {
                    FarebnaSchema sch = new FarebnaSchema();
                    sch.setNadpisDomFarba(label1.ForeColor);
                    sch.setNadpisHosFarba(label2.ForeColor);
                    sch.setCasFarba(label3.ForeColor);
                    sch.setSkoreFarba(label4.ForeColor);
                    sch.setPolcasFarba(label5.ForeColor);
                    sch.setPredlzenieFarba(label5.ForeColor);
                    sch.setKoniecFarba(label5.ForeColor);

                    XmlSerializer serializer = new XmlSerializer(typeof(FarebnaSchema));
                    textWriter = new StreamWriter(sfd.FileName);
                    serializer.Serialize(textWriter, sch);
                }
                catch (Exception ex)
                { 
                    MessageBox.Show(ex.Message, "LGR Futbal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (textWriter != null)
                        textWriter.Close();
                    if (OnFileSelectedFF != null)
                        OnFileSelectedFF(sfd.FileName);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
                label1.ForeColor = cd.Color;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
                label2.ForeColor = cd.Color;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
                label3.ForeColor = cd.Color;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
                label4.ForeColor = cd.Color;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
                label5.ForeColor = cd.Color;
        }

        private void FarbyForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void loadColorsButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            ofd.InitialDirectory = adresar;
            ofd.Filter = "xml files (*.xml)|*.xml";
            if (ofd.ShowDialog() == DialogResult.OK)
                nacitajFarby(ofd.FileName);
        }

        private void obnovaFariebButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Translate(2), "LGR Futbal", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (OnObnovaFariebFF != null)
                    OnObnovaFariebFF();
                if (OnFileSelectedFF != null)
                    OnFileSelectedFF(string.Empty);
                //this.Close();
            }

            label3.ForeColor = Color.Lime;

            label1.ForeColor = Color.Aqua;

            label2.ForeColor = Color.Aqua;

            label4.ForeColor = Color.Red;

            label5.ForeColor = Color.Lime;
        }


        private void nacitajFarby(string cesta)
        {
            TextReader textReader = null;
            bool uspech = true;
            FarebnaSchema schema = null;

            try
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(FarebnaSchema));
                textReader = new StreamReader(cesta);
                schema = (FarebnaSchema)deserializer.Deserialize(textReader);
            }
            catch (Exception ex)
            {
                uspech = false;
                MessageBox.Show(ex.Message, "LGR futbal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (textReader != null)
                    textReader.Close();

                if (uspech)
                {
                     label3.ForeColor = Color.FromArgb(schema.CasFarba_r, schema.CasFarba_g, schema.CasFarba_b);

                     label1.ForeColor = Color.FromArgb(schema.NadpisDomFarba_r, schema.NadpisDomFarba_g, schema.NadpisDomFarba_b);

                     label2.ForeColor = Color.FromArgb(schema.NadpisHosFarba_r, schema.NadpisHosFarba_g, schema.NadpisHosFarba_b);

                     label4.ForeColor = Color.FromArgb(schema.SkoreFarba_r, schema.SkoreFarba_g, schema.SkoreFarba_b);

                     label5.ForeColor = Color.FromArgb(schema.PolcasFarba_r, schema.PolcasFarba_g, schema.PolcasFarba_b);

                    if (OnColorsLoadedFF != null)
                        OnColorsLoadedFF(schema);
                    if (OnFileSelectedFF != null)
                        OnFileSelectedFF(cesta);
                    
                }
            }
        }

        private string Translate(int cisloVety)
        {
            if (Settings.Default.Jazyk == 0)
            {
                switch (cisloVety)
                {
                    case 1: return "Naozaj chcete resetovať výsledkovú tabuľu?";
                    case 2: return "Naozaj chcete obnoviť výrobné nastavenia farieb?";
                    case 3: return "V databáze sa už nachádza súbor s rovnakým názvom!";
                    case 4: return "Naozaj chcete zrušiť obrázok (animáciu)?";
                }
            }
            else if (Settings.Default.Jazyk == 1)
            {
                switch (cisloVety)
                {
                    case 1: return "Opravdu chcete resetovat výsledkovou tabuli?";
                    case 2: return "Opravdu chcete obnovit výrobní nastavení barev?";
                    case 3: return "V databázi se již nachází soubor se stejným názvem!";
                    case 4: return "Opravdu chcete zrušit obrázek (animaci)?";
                }
            }

            return string.Empty;
        }

        
    }
}
