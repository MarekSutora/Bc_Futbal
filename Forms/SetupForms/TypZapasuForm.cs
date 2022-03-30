using LGR_Futbal.Properties;
using LGR_Futbal.Setup;
using System;
using System.Windows.Forms;

namespace LGR_Futbal.Forms
{
    public delegate void NovyTypZapasuHandler(ParametreZapasu parZap);

    public partial class TypZapasuForm : Form
    {
        private const string nazovProgramuString = "LGR Futbal";

        public event NovyTypZapasuHandler onNovyTypZapasu;

        public TypZapasuForm()
        {
            InitializeComponent();
        }

        private void aktivovatButton_Click(object sender, EventArgs e)
        {
            string n = nazovTextBox.Text.Trim();
            if (n.Equals(string.Empty))
            {
                MessageBox.Show("Nezadali ste názov!", nazovProgramuString, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                ParametreZapasu pz = new ParametreZapasu();
                pz.Nazov = n;
                pz.DlzkaPolcasu = (int)minutyNum.Value;
                pz.Prerusenie = prerCheckBox.Checked;

                if (onNovyTypZapasu != null)
                    onNovyTypZapasu(pz);

                this.Close();
            }
        }

        private void zrusitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TypZapasuForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
