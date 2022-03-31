using LGR_Futbal.Properties;
using LGR_Futbal.Setup;
using System;
using System.Windows.Forms;

namespace LGR_Futbal.Forms
{
    public delegate void NovyTypZapasuHandler(ParametreZapasu parZap);

    public partial class TypZapasuForm : Form
    {
        
        public event NovyTypZapasuHandler OnNovyTypZapasu;

        public TypZapasuForm()
        {
            InitializeComponent();
        }

        private void PridatTypBtn_Click(object sender, EventArgs e)
        {
            string n = nazovTextBox.Text.Trim();
            if (n.Equals(string.Empty))
            {
                MessageBox.Show("Nezadali ste názov!", "FutbalApp", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                ParametreZapasu pz = new ParametreZapasu();
                pz.Nazov = n;
                pz.DlzkaPolcasu = (int)minutyNum.Value;
                pz.Prerusenie = prerCheckBox.Checked;

                OnNovyTypZapasu?.Invoke(pz);

                this.Close();
            }
        }
    }
}
