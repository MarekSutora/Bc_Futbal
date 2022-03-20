using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LGR_Futbal.Triedy;
using System.Xml.Serialization;
using System.IO;
using LGR_Futbal.Properties;

namespace LGR_Futbal.Forms
{

    public delegate void LayoutConfirmedHandler();
    public delegate void FileSelectedHandlerRF(string cesta);

    public partial class RozlozenieForm : Form
    {
        private string adresa;
        private int sirka;
        private int vyska;
        public event LayoutConfirmedHandler OnLayoutConfirmed;
        public event FileSelectedHandlerRF OnFileSelected;
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
            numericUpDown1.Value = RozlozenieTabule.CasX;
            numericUpDown2.Value = RozlozenieTabule.CasY;

            numericUpDown4.Value = RozlozenieTabule.DomaciX;
            numericUpDown3.Value = RozlozenieTabule.DomaciY;

            numericUpDown8.Value = RozlozenieTabule.HostiaX;
            numericUpDown7.Value = RozlozenieTabule.HostiaY;

            numericUpDown16.Value = RozlozenieTabule.DomaciSkoreX;
            numericUpDown15.Value = RozlozenieTabule.DomaciSkoreY;

            numericUpDown18.Value = RozlozenieTabule.HostiaSkoreX;
            numericUpDown17.Value = RozlozenieTabule.HostiaSkoreY;

            numericUpDown6.Value = RozlozenieTabule.LogoDomaciX;
            numericUpDown5.Value = RozlozenieTabule.LogoDomaciY;
            numericUpDown11.Value = RozlozenieTabule.LogoDomaciSirka;
            checkBox2.Checked = RozlozenieTabule.LogoDomaciZobrazit;

            numericUpDown10.Value = RozlozenieTabule.LogoHostiaX;
            numericUpDown9.Value = RozlozenieTabule.LogoHostiaY;
            numericUpDown12.Value = RozlozenieTabule.LogoHostiaSirka;
            checkBox1.Checked = RozlozenieTabule.LogoHostiaZobrazit;

            numericUpDown14.Value = RozlozenieTabule.polCasX;
            numericUpDown13.Value = RozlozenieTabule.polCasY;
        }

        private void aktivovatRozlozenieButton_Click(object sender, EventArgs e)
        {
            if (OnLayoutConfirmed != null)
            {
                RozlozenieTabule.CasX = (int)numericUpDown1.Value;
                RozlozenieTabule.CasY = (int)numericUpDown2.Value;

                RozlozenieTabule.DomaciX = (int)numericUpDown4.Value;
                RozlozenieTabule.DomaciY = (int)numericUpDown3.Value;

                RozlozenieTabule.HostiaX = (int)numericUpDown8.Value;
                RozlozenieTabule.HostiaY = (int)numericUpDown7.Value;

                RozlozenieTabule.DomaciSkoreX = (int)numericUpDown16.Value;
                RozlozenieTabule.DomaciSkoreY = (int)numericUpDown15.Value;

                RozlozenieTabule.HostiaSkoreX = (int)numericUpDown18.Value;
                RozlozenieTabule.HostiaSkoreY = (int)numericUpDown17.Value;

                RozlozenieTabule.LogoDomaciX = (int)numericUpDown6.Value;
                RozlozenieTabule.LogoDomaciY = (int)numericUpDown5.Value;
                RozlozenieTabule.LogoDomaciSirka = (int)numericUpDown11.Value;
                RozlozenieTabule.LogoDomaciZobrazit = checkBox2.Checked;

                RozlozenieTabule.LogoHostiaX = (int)numericUpDown10.Value;
                RozlozenieTabule.LogoHostiaY = (int)numericUpDown9.Value;
                RozlozenieTabule.LogoHostiaSirka = (int)numericUpDown12.Value;
                RozlozenieTabule.LogoHostiaZobrazit = checkBox1.Checked;

                RozlozenieTabule.polCasX = (int)numericUpDown14.Value;
                RozlozenieTabule.polCasY = (int)numericUpDown13.Value;
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
                bool uspech = true;

                try
                {
                    RozlozenieTabule rt = new RozlozenieTabule();
                    rt.CasX = (int)numericUpDown1.Value;
                    rt.CasY = (int)numericUpDown2.Value;

                    rt.DomaciX = (int)numericUpDown4.Value;
                    rt.DomaciY = (int)numericUpDown3.Value;

                    rt.HostiaX = (int)numericUpDown8.Value;
                    rt.HostiaY = (int)numericUpDown7.Value;

                    rt.DomaciSkoreX = (int)numericUpDown16.Value;
                    rt.DomaciSkoreY = (int)numericUpDown15.Value;

                    rt.HostiaSkoreX = (int)numericUpDown18.Value;
                    rt.HostiaSkoreY = (int)numericUpDown17.Value;

                    rt.LogoDomaciX = (int)numericUpDown6.Value;
                    rt.LogoDomaciY = (int)numericUpDown5.Value;
                    rt.LogoDomaciSirka = (int)numericUpDown11.Value;
                    rt.LogoDomaciZobrazit = checkBox2.Checked;

                    rt.LogoHostiaX = (int)numericUpDown10.Value;
                    rt.LogoHostiaY = (int)numericUpDown9.Value;
                    rt.LogoHostiaSirka = (int)numericUpDown12.Value;
                    rt.LogoHostiaZobrazit = checkBox2.Checked;

                    rt.polCasX = (int)numericUpDown14.Value;
                    rt.polCasY = (int)numericUpDown13.Value;

                    XmlSerializer serializer = new XmlSerializer(typeof(RozlozenieTabule));
                    textWriter = new StreamWriter(sfd.FileName);
                    serializer.Serialize(textWriter, rt);
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

                    if (uspech && OnFileSelected != null)
                    {
                        OnFileSelected(sfd.FileName);
                    }
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
                    MessageBox.Show(ex.Message, "LGR Futbal", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        if (OnFileSelected != null)
                        {
                            OnFileSelected(ofd.FileName);
                        }
                    }
                }
            }
        }

        public void NativneRozlozenie()
        {
            double pom = sirka / (1920 / 540.0);
            numericUpDown1.Value = (int)(sirka / (1920 / 540.0));
            numericUpDown2.Value = (int)(vyska / (1080 / 20.0));

            numericUpDown4.Value = (int)(sirka / (1920 / 20.0));
            numericUpDown3.Value = (int)(vyska / (1080 / 544.0));

            numericUpDown8.Value = (int)(sirka / (1920 / 1098.0));
            numericUpDown7.Value = (int)(vyska / (1080 / 544.0));

            numericUpDown16.Value = (int)(sirka / (1920 / 38.0));
            numericUpDown15.Value = (int)(vyska / (1080 / 674.0));

            numericUpDown18.Value = (int)(sirka / (1920 / 1118.0));
            numericUpDown17.Value = (int)(vyska / (1080 / 674.0));

            numericUpDown6.Value = (int)(sirka / (1920 / 20.0));
            numericUpDown5.Value = (int)(vyska / (1080 / 20.0));
            numericUpDown11.Value = (int)(sirka / (1920 / 510.0));
            checkBox2.Checked = true;

            numericUpDown10.Value = (int)(sirka / (1920 / 1390.0)); ;
            numericUpDown9.Value = (int)(vyska / (1080 / 20.0)); ;
            numericUpDown12.Value = (int)(sirka / (1920 / 510.0)); ;
            checkBox2.Checked = true;

            numericUpDown14.Value = (int)(sirka / (1920 / 550.0)); ;
            numericUpDown13.Value = (int)(vyska / (1080 / 878.0)); ;

            RozlozenieTabule.CasX = (int)numericUpDown1.Value;
            RozlozenieTabule.CasY = (int)numericUpDown2.Value;

            RozlozenieTabule.DomaciX = (int)numericUpDown4.Value;
            RozlozenieTabule.DomaciY = (int)numericUpDown3.Value;

            RozlozenieTabule.HostiaX = (int)numericUpDown8.Value;
            RozlozenieTabule.HostiaY = (int)numericUpDown7.Value;

            RozlozenieTabule.DomaciSkoreX = (int)numericUpDown16.Value;
            RozlozenieTabule.DomaciSkoreY = (int)numericUpDown15.Value;

            RozlozenieTabule.HostiaSkoreX = (int)numericUpDown18.Value;
            RozlozenieTabule.HostiaSkoreY = (int)numericUpDown17.Value;

            RozlozenieTabule.LogoDomaciX = (int)numericUpDown6.Value;
            RozlozenieTabule.LogoDomaciY = (int)numericUpDown5.Value;
            RozlozenieTabule.LogoDomaciSirka = (int)numericUpDown11.Value;
            RozlozenieTabule.LogoDomaciZobrazit = checkBox2.Checked;

            RozlozenieTabule.LogoHostiaX = (int)numericUpDown10.Value;
            RozlozenieTabule.LogoHostiaY = (int)numericUpDown9.Value;
            RozlozenieTabule.LogoHostiaSirka = (int)numericUpDown12.Value;
            RozlozenieTabule.LogoHostiaZobrazit = checkBox1.Checked;

            RozlozenieTabule.polCasX = (int)numericUpDown14.Value;
            RozlozenieTabule.polCasY = (int)numericUpDown13.Value;
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
