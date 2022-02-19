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

namespace LGR_Futbal.Forms
{

    public delegate void LayoutConfirmedHandler();

    public partial class RozlozenieForm : Form
    {
        private string adresa;
        public LayoutConfirmedHandler OnLayoutConfirmed;
        public RozlozenieTabule rozlozenieTabule { get; set; }

        public RozlozenieForm(string adresa, RozlozenieTabule rt)
        {
            this.adresa = adresa;
            InitializeComponent();
            rozlozenieTabule = rt;
            nastavRozlozenie();
        }

        private void RozlozenieForm_Load(object sender, EventArgs e)
        {

        }

        private void nastavRozlozenie()
        {
            numericUpDown1.Value = rozlozenieTabule.CasX;
            numericUpDown2.Value = rozlozenieTabule.CasY;

            numericUpDown4.Value = rozlozenieTabule.DomaciX;
            numericUpDown3.Value = rozlozenieTabule.DomaciY;

            numericUpDown8.Value = rozlozenieTabule.HostiaX;
            numericUpDown7.Value = rozlozenieTabule.HostiaY;

            numericUpDown6.Value = rozlozenieTabule.LogoDomaciX;
            numericUpDown5.Value = rozlozenieTabule.LogoDomaciY;
            numericUpDown11.Value = rozlozenieTabule.LogoDomaciSirka;
            checkBox2.Checked = rozlozenieTabule.LogoDomaciZobrazit;

            numericUpDown10.Value = rozlozenieTabule.LogoHostiaX;
            numericUpDown9.Value = rozlozenieTabule.LogoHostiaY;
            numericUpDown12.Value = rozlozenieTabule.LogoHostiaSirka;
            checkBox2.Checked = rozlozenieTabule.LogoHostiaZobrazit;

            numericUpDown14.Value = rozlozenieTabule.polCasX;
            numericUpDown13.Value = rozlozenieTabule.polCasY;
        }

        private void aktivovatRozlozenieButton_Click(object sender, EventArgs e)
        {
            if (OnLayoutConfirmed != null)
            {
                rozlozenieTabule.CasX = (int)numericUpDown1.Value;
                rozlozenieTabule.CasY = (int)numericUpDown2.Value;

                rozlozenieTabule.DomaciX = (int)numericUpDown4.Value;
                rozlozenieTabule.DomaciY = (int)numericUpDown3.Value;

                rozlozenieTabule.HostiaX = (int)numericUpDown8.Value;
                rozlozenieTabule.HostiaY = (int)numericUpDown7.Value;

                rozlozenieTabule.LogoDomaciX = (int)numericUpDown6.Value;
                rozlozenieTabule.LogoDomaciY = (int)numericUpDown5.Value;
                rozlozenieTabule.LogoDomaciSirka = (int)numericUpDown11.Value;
                rozlozenieTabule.LogoDomaciZobrazit = checkBox2.Checked;

                rozlozenieTabule.LogoHostiaX = (int)numericUpDown10.Value;
                rozlozenieTabule.LogoHostiaY = (int)numericUpDown9.Value;
                rozlozenieTabule.LogoHostiaSirka = (int)numericUpDown12.Value;
                rozlozenieTabule.LogoHostiaZobrazit = checkBox1.Checked;

                rozlozenieTabule.polCasX = (int)numericUpDown14.Value;
                rozlozenieTabule.polCasY = (int)numericUpDown13.Value;
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

                    if (uspech)
                    { 
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
                        rozlozenieTabule = rt;
                        nastavRozlozenie();
                    }
                }
            }
        }
    }
}
