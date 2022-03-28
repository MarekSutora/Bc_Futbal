using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LGR_Futbal.Setup;
using System.Xml.Serialization;
using System.IO;
using LGR_Futbal.Properties;

namespace LGR_Futbal.Forms
{

    public delegate void LayoutConfirmedHandler();

    public partial class RozlozenieForm : Form
    {
        private string adresa;
        private int sirka;
        private int vyska;
        public event LayoutConfirmedHandler OnLayoutConfirmed;
        public RozlozenieTabule RozlozenieTabule { get; set; }

        public RozlozenieForm(string adresa, RozlozenieTabule rt, int sirka, int vyska)
        {
            InitializeComponent();
            if (Settings.Default.Jazyk == 1)
            {
                this.Text = "Rozložení tabule";
                label1.Text = "Čas:";
                label20.Text = "Poločas:";
                label23.Text = "Skóre domáci:";
                label26.Text = "Skóre hosté:";
                label6.Text = "Domáci:";
                label12.Text = "Hosté:";
                label9.Text = "Logo Domáci:";

                checkBox2.Text = "Zobrazit logo:";
                checkBox1.Text = "Zobrazit logo:";

                this.aktivovatRozlozenieButton.Text = "Aktivovat zmeny";
                ulozitRozlozenie.Text = "Uložit rozložení:";
                nacitatRozlozenieButton.Text = "Načíst rozložení";
                obnovaRozlozeniaButton.Text = "Obnovit výrobní        nastavení";


            }
            toolTip1.SetToolTip(numericUpDown1, "Zvyšovanie - doprava \nZnižovanie - doľava");
            toolTip1.SetToolTip(numericUpDown14, "Zvyšovanie - doprava \nZnižovanie - doľava");
            toolTip1.SetToolTip(numericUpDown16, "Zvyšovanie - doprava \nZnižovanie - doľava");
            toolTip1.SetToolTip(numericUpDown18, "Zvyšovanie - doprava \nZnižovanie - doľava");
            toolTip1.SetToolTip(numericUpDown4, "Zvyšovanie - doprava \nZnižovanie - doľava");
            toolTip1.SetToolTip(numericUpDown8, "Zvyšovanie - doprava \nZnižovanie - doľava");
            toolTip1.SetToolTip(numericUpDown6, "Zvyšovanie - doprava \nZnižovanie - doľava");
            toolTip1.SetToolTip(numericUpDown10, "Zvyšovanie - doprava \nZnižovanie - doľava");

            toolTip1.SetToolTip(numericUpDown2, "Zvyšovanie - dole \nZnižovanie - hore");
            toolTip1.SetToolTip(numericUpDown13, "Zvyšovanie - dole \nZnižovanie - hore");
            toolTip1.SetToolTip(numericUpDown15, "Zvyšovanie - dole \nZnižovanie - hore");
            toolTip1.SetToolTip(numericUpDown17, "Zvyšovanie - dole \nZnižovanie - hore");
            toolTip1.SetToolTip(numericUpDown3, "Zvyšovanie - dole \nZnižovanie - hore");
            toolTip1.SetToolTip(numericUpDown7, "Zvyšovanie - dole \nZnižovanie - hore");
            toolTip1.SetToolTip(numericUpDown5, "Zvyšovanie - dole \nZnižovanie - hore");
            toolTip1.SetToolTip(numericUpDown9, "Zvyšovanie - dole \nZnižovanie - hore");

            this.adresa = adresa;
            this.sirka = sirka;
            this.vyska = vyska;
            RozlozenieTabule = rt;
            nastavRozlozenie();
        }

        private void RozlozenieForm_Load(object sender, EventArgs e)
        {

        }

        private void nastavRozlozenie()
        {
            numericUpDown1.Value = RozlozenieTabule.Cas_X;
            numericUpDown2.Value = RozlozenieTabule.Cas_Y;

            numericUpDown4.Value = RozlozenieTabule.Domaci_X;
            numericUpDown3.Value = RozlozenieTabule.Domaci_Y;

            numericUpDown8.Value = RozlozenieTabule.Hostia_X;
            numericUpDown7.Value = RozlozenieTabule.Hostia_Y;

            numericUpDown16.Value = RozlozenieTabule.DomaciSkore_X;
            numericUpDown15.Value = RozlozenieTabule.DomaciSkore_Y;

            numericUpDown18.Value = RozlozenieTabule.HostiaSkore_X;
            numericUpDown17.Value = RozlozenieTabule.HostiaSkore_Y;

            numericUpDown6.Value = RozlozenieTabule.LogoDomaci_X;
            numericUpDown5.Value = RozlozenieTabule.LogoDomaci_Y;
            numericUpDown11.Value = RozlozenieTabule.LogoDomaciSirka;
            checkBox2.Checked = RozlozenieTabule.LogoDomaciZobrazit;

            numericUpDown10.Value = RozlozenieTabule.LogoHostia_X;
            numericUpDown9.Value = RozlozenieTabule.LogoHostia_Y;
            numericUpDown12.Value = RozlozenieTabule.LogoHostiaSirka;
            checkBox1.Checked = RozlozenieTabule.LogoHostiaZobrazit;

            numericUpDown14.Value = RozlozenieTabule.Polcas_X;
            numericUpDown13.Value = RozlozenieTabule.Polcas_Y;
        }

        private void aktivovatRozlozenieButton_Click(object sender, EventArgs e)
        {
            if (OnLayoutConfirmed != null)
            {
                RozlozenieTabule.Cas_X = (int)numericUpDown1.Value;
                RozlozenieTabule.Cas_Y = (int)numericUpDown2.Value;

                RozlozenieTabule.Domaci_X = (int)numericUpDown4.Value;
                RozlozenieTabule.Domaci_Y = (int)numericUpDown3.Value;

                RozlozenieTabule.Hostia_X = (int)numericUpDown8.Value;
                RozlozenieTabule.Hostia_Y = (int)numericUpDown7.Value;

                RozlozenieTabule.DomaciSkore_X = (int)numericUpDown16.Value;
                RozlozenieTabule.DomaciSkore_Y = (int)numericUpDown15.Value;

                RozlozenieTabule.HostiaSkore_X = (int)numericUpDown18.Value;
                RozlozenieTabule.HostiaSkore_Y = (int)numericUpDown17.Value;

                RozlozenieTabule.LogoDomaci_X = (int)numericUpDown6.Value;
                RozlozenieTabule.LogoDomaci_Y = (int)numericUpDown5.Value;
                RozlozenieTabule.LogoDomaciSirka = (int)numericUpDown11.Value;
                RozlozenieTabule.LogoDomaciZobrazit = checkBox2.Checked;

                RozlozenieTabule.LogoHostia_X = (int)numericUpDown10.Value;
                RozlozenieTabule.LogoHostia_Y = (int)numericUpDown9.Value;
                RozlozenieTabule.LogoHostiaSirka = (int)numericUpDown12.Value;
                RozlozenieTabule.LogoHostiaZobrazit = checkBox1.Checked;

                RozlozenieTabule.Polcas_X = (int)numericUpDown14.Value;
                RozlozenieTabule.Polcas_Y = (int)numericUpDown13.Value;
                OnLayoutConfirmed();
            }
               
        }

        private void ulozitRozlozenie_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = adresa;
            sfd.Filter = "xml files (*.xml)|*.xml";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                TextWriter textWriter = null;

                try
                {
                    RozlozenieTabule rt = new RozlozenieTabule();
                    rt.Cas_X = (int)numericUpDown1.Value;
                    rt.Cas_Y = (int)numericUpDown2.Value;

                    rt.Domaci_X = (int)numericUpDown4.Value;
                    rt.Domaci_Y = (int)numericUpDown3.Value;

                    rt.Hostia_X = (int)numericUpDown8.Value;
                    rt.Hostia_Y = (int)numericUpDown7.Value;

                    rt.DomaciSkore_X = (int)numericUpDown16.Value;
                    rt.DomaciSkore_Y = (int)numericUpDown15.Value;

                    rt.HostiaSkore_X = (int)numericUpDown18.Value;
                    rt.HostiaSkore_Y = (int)numericUpDown17.Value;

                    rt.LogoDomaci_X = (int)numericUpDown6.Value;
                    rt.LogoDomaci_Y = (int)numericUpDown5.Value;
                    rt.LogoDomaciSirka = (int)numericUpDown11.Value;
                    rt.LogoDomaciZobrazit = checkBox2.Checked;

                    rt.LogoHostia_X = (int)numericUpDown10.Value;
                    rt.LogoHostia_Y = (int)numericUpDown9.Value;
                    rt.LogoHostiaSirka = (int)numericUpDown12.Value;
                    rt.LogoHostiaZobrazit = checkBox2.Checked;

                    rt.Polcas_X = (int)numericUpDown14.Value;
                    rt.Polcas_Y = (int)numericUpDown13.Value;

                    XmlSerializer serializer = new XmlSerializer(typeof(RozlozenieTabule));
                    textWriter = new StreamWriter(sfd.FileName);
                    serializer.Serialize(textWriter, rt);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Futbal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (textWriter != null)
                        textWriter.Close();

                    this.Close();
                }
            }
        }

        private void nacitatRozlozenieButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            ofd.InitialDirectory = adresa;
            ofd.Filter = "xml files (*.xml)|*.xml";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                RozlozenieTabule rt = null;
                TextReader textReader = null;
                bool uspech = true;
                try
                {
                    
                    XmlSerializer deserializer = new XmlSerializer(typeof(RozlozenieTabule));
                    textReader = new StreamReader(ofd.FileName);
                    rt = (RozlozenieTabule)deserializer.Deserialize(textReader);
                }
                catch (Exception ex)
                {
                    uspech = false;
                    MessageBox.Show(ex.Message, "Futbal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (textReader != null)
                        textReader.Close();

                    if (uspech)
                    {
                        RozlozenieTabule = rt;
                        nastavRozlozenie();
                        if (OnLayoutConfirmed != null)
                        {
                            OnLayoutConfirmed();
                        }
                    }
                }
            }
        }

        public void NativneRozlozenie()
        {
            RozlozenieTabule.NativneRozlozenie(sirka, vyska);

            numericUpDown1.Value = RozlozenieTabule.Cas_X;
            numericUpDown2.Value = RozlozenieTabule.Cas_Y;

            numericUpDown4.Value = RozlozenieTabule.Domaci_X;
            numericUpDown3.Value = RozlozenieTabule.Domaci_Y;

            numericUpDown8.Value = RozlozenieTabule.Hostia_X;
            numericUpDown7.Value = RozlozenieTabule.Hostia_Y;

            numericUpDown16.Value = RozlozenieTabule.DomaciSkore_X;
            numericUpDown15.Value = RozlozenieTabule.DomaciSkore_Y;

            numericUpDown18.Value = RozlozenieTabule.HostiaSkore_X;
            numericUpDown17.Value = RozlozenieTabule.HostiaSkore_Y;

            numericUpDown6.Value = RozlozenieTabule.LogoDomaci_X;
            numericUpDown5.Value = RozlozenieTabule.LogoDomaci_Y;
            numericUpDown11.Value = RozlozenieTabule.LogoDomaciSirka;
            checkBox2.Checked = true;

            numericUpDown10.Value = RozlozenieTabule.LogoHostia_X; 
            numericUpDown9.Value = RozlozenieTabule.LogoHostia_Y;
            numericUpDown12.Value = RozlozenieTabule.LogoHostiaSirka;
            checkBox2.Checked = true;

            numericUpDown14.Value = RozlozenieTabule.Polcas_X; 
            numericUpDown13.Value = RozlozenieTabule.Polcas_Y; 

            if (adresa != null)
            {
                OnLayoutConfirmed();
            }      
        }

        private void obnovaRozlozeniaButton_Click(object sender, EventArgs e)
        {
            NativneRozlozenie();
        }
    }
}
