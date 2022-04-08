using System;
using System.Drawing;
using System.Windows.Forms;

namespace LGR_Futbal.Forms
{
    public partial class UdalostPopupForm : Form
    {
        public UdalostPopupForm(string text, float pomer)
        {
            InitializeComponent();
            label1.Text = text;
            label1.Font = new Font(label1.Font.Name, (float)Math.Floor(label1.Font.Size * pomer));
            Casovac = new Timer();
            Casovac.Interval = 2000;
            Casovac.Tick += new EventHandler(Casovac_Tick);
            Casovac.Start();
        }

        private void Casovac_Tick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
