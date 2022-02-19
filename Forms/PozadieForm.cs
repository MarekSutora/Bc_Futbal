using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

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
            // Ak existuje externy monitor, cierne pozadie sa vykresli primarne nan,
            // ak nie, pouzije sa standardna obrazovka.
            WindowState = FormWindowState.Normal;
            var primaryDisplay = Screen.AllScreens.ElementAtOrDefault(0);
            var extendedDisplay = Screen.AllScreens.FirstOrDefault(s => s != primaryDisplay) ?? primaryDisplay;

            this.Left = extendedDisplay.WorkingArea.Left + (extendedDisplay.Bounds.Size.Width / 2) - (this.Size.Width / 2);
            this.Top = extendedDisplay.WorkingArea.Top + (extendedDisplay.Bounds.Size.Height / 2) - (this.Size.Height / 2);
            WindowState = FormWindowState.Maximized;
        }
    }
}
