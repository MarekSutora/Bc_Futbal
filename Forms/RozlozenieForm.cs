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

namespace LGR_Futbal.Forms
{

    public delegate void LayoutConfirmedHandler();

    public partial class RozlozenieForm : Form
    {

        public LayoutConfirmedHandler OnLayoutConfirmed;
        public RozlozenieTabule rozlozenieTabule { get; set; }

        public RozlozenieForm()
        {
            InitializeComponent();
            rozlozenieTabule = new RozlozenieTabule();
        }

        private void RozlozenieForm_Load(object sender, EventArgs e)
        {

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
                rozlozenieTabule.LogoHostiaZobrazit = checkBox2.Checked;

                rozlozenieTabule.polCasX = (int)numericUpDown14.Value;
                rozlozenieTabule.polCasY = (int)numericUpDown13.Value;
                OnLayoutConfirmed();
            }
               
        }

        private void ulozitRozlozenie_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = Directory.c;
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
    }
}
