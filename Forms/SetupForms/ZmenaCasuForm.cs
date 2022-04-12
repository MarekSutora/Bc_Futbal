using System;
using System.Windows.Forms;

namespace BC_Futbal.Forms
{
    public delegate void ZmenaCasuHandler(int novaMin, int novaSek);

    public partial class ZmenaCasuForm : Form
    {
        public event ZmenaCasuHandler OnZmenaCasu;
        public ZmenaCasuForm(int m, int s, int dlzka)
        {
            InitializeComponent();

            minuta.Minimum = 0;
            minuta.Maximum = 2 * dlzka;
            minuta.Value = m;

            sekunda.Minimum = 0;
            sekunda.Maximum = 59;
            sekunda.Value = s;
            
        }
        private void PotvrditBtn_Click(object sender, EventArgs e)
        {
            int nm = (int)minuta.Value;
            int ns = (int)sekunda.Value;
            if (minuta.Value == minuta.Maximum)
            {
                ns = 0;
            }
            OnZmenaCasu?.Invoke(nm, ns);
            Close();
        }

        private void Minuta_ValueChanged(object sender, EventArgs e)
        {
            if (minuta.Value == minuta.Maximum)
            {
                sekunda.Enabled = false;
                sekunda.Value = 0;
            } 
            else
            {
                sekunda.Enabled = true;
            }
        }
        private void SpatBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
