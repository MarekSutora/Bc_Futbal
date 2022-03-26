using System;
using System.Data;
using System.Linq;
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
            WindowState = FormWindowState.Normal;
            LayoutSetter.ZobrazNaDruhejObrazovke(this);
            WindowState = FormWindowState.Maximized;
        }
    }
}
