using LGR_Futbal.Properties;
using LGR_Futbal.Triedy;
using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace LGR_Futbal.Forms
{
    public delegate void FileSavedHandler(string s);

    public partial class FarbyForm : Form
    {
        private string adresar;
        public event FileSavedHandler OnFileSaved;

        public FarbyForm(string cesta, FarebnaSchema fs)
        {
            InitializeComponent();
            if (Settings.Default.Jazyk == 1)
            {
                this.Text = "Vytvoření vlastní barevné konfigurace";
                saveButton.Text = "Uložit   ";
                zrusitButton.Text = "Zavřít   ";
                
                button1.Text = "Změnit";
                button3.Text = "Změnit";
                button4.Text = "Změnit";
                button6.Text = "Změnit";
                button7.Text = "Změnit";

                label5.Text = "POLOČAS";
                label2.Text = "HOSTÉ";
                label1.Text = "DOMÁCÍ";
            }

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

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = adresar;
            sfd.Filter = "xml files (*.xml)|*.xml";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                TextWriter textWriter = null;
                bool uspech = true;

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
                    uspech = false;
                    MessageBox.Show(ex.Message, "LGR Futbal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (textWriter != null)
                        textWriter.Close();

                    if (uspech)
                    {
                        if (OnFileSaved != null)
                            OnFileSaved(sfd.FileName);
                    }
                    this.Close();
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
    }
}
