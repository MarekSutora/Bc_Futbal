using System;
using System.Windows.Forms;
using BC_Futbal.Setup;

namespace BC_Futbal.Forms
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
                MessageBox.Show("Nezadali ste názov!", Properties.Settings.Default.NazovProgramu, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
