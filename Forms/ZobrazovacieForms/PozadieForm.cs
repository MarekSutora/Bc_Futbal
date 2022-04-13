using System;
using System.Windows.Forms;
using BC_Futbal.Setup;

namespace BC_Futbal.Forms
{
    public partial class PozadieForm : Form
    {
        public PozadieForm()
        {
            InitializeComponent();
        }

        private void PozadieForm_Load(object sender, EventArgs e)
        {

            if (Screen.AllScreens.Length == 1)
            {
                //Screen primarnyDisplej = Screen.AllScreens[0];
                //int sirkaObr = primarnyDisplej.Bounds.Width;
                //float pomer = (float)sirkaObr / Width;
                //Scale(new SizeF(pomer, pomer));
                Height = Screen.PrimaryScreen.WorkingArea.Height;
                Width = Screen.PrimaryScreen.WorkingArea.Width;
                Location = Screen.PrimaryScreen.WorkingArea.Location;
                MaximumSize = Screen.PrimaryScreen.WorkingArea.Size;
            }
            else
            {
                LayoutSetter.ZobrazNaDruhejObrazovke(this);
                WindowState = FormWindowState.Maximized;
            }  
        }
    }
}
