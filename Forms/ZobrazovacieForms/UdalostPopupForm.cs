using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LGR_Futbal.Forms
{
    public partial class UdalostPopupForm : Form
    {
        private Timer timer = new Timer();
        public UdalostPopupForm(string text, float pomer)
        {
            InitializeComponent();
            label1.Text = text;
            label1.Font = new Font(label1.Font.Name, (float)Math.Floor(label1.Font.Size * pomer));


        }

        void timer_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UdalostPopupForm_Load(object sender, EventArgs e)
        {
            timer.Interval = 2000;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }
    }
}
