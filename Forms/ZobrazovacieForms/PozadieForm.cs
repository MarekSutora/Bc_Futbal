using System;
using System.Windows.Forms;
using LGR_Futbal.Setup;

namespace LGR_Futbal.Forms
{
    public partial class PozadieForm : Form
    {
        public PozadieForm()
        {
            InitializeComponent();
        }

        private void PozadieForm_Load(object sender, EventArgs e)
        {
            LayoutSetter.ZobrazNaDruhejObrazovke(this);
            WindowState = FormWindowState.Maximized;
        }
    }
}
