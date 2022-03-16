using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Timers;

namespace LGR_Futbal.Forms
{
    public delegate void SafeCallDelegate();
    public partial class ReklamaForm : Form
    {

        private string video = string.Empty;
        private int tiky = 0;
        private RiadiaciForm riadiaci;

        public ReklamaForm(int sirka, string video, RiadiaciForm rf)
        {
            InitializeComponent();

            this.video = video;
            this.riadiaci = rf;
            float pomer = (float)sirka / (float)this.Width;
            Scale(new SizeF(pomer, pomer));
            Label l;
            Panel p;
            foreach (object item in Controls)
            {
                if (item.GetType() == typeof(Label))
                {
                    l = (Label)item;
                    l.Font = new Font(l.Font.Name, (float)Math.Floor(l.Font.Size * pomer));
                }
                else if (item.GetType() == typeof(Panel))
                {
                    p = (Panel)item;
                    foreach (object prvok in p.Controls)
                    {
                        if (prvok.GetType() == typeof(Label))
                        {
                            l = (Label)prvok;
                            l.Font = new Font(l.Font.Name, (float)Math.Floor(l.Font.Size * pomer));
                        }
                    }
                }
            }
        }

        private void Casovac_Elapsed(object sender, ElapsedEventArgs e)
        {
            tiky++;
            if (tiky == 2)
            {
                vlcControl1.Stop();
                this.Close();
            }
        }

        private void ReklamaForm_Load(object sender, EventArgs e)
        {
            var primaryDisplay = Screen.AllScreens.ElementAtOrDefault(0);
            var extendedDisplay = Screen.AllScreens.FirstOrDefault(s => s != primaryDisplay) ?? primaryDisplay;

            this.Left = extendedDisplay.WorkingArea.Left + (extendedDisplay.Bounds.Size.Width / 2) - (this.Size.Width / 2);
            this.Top = extendedDisplay.WorkingArea.Top + (extendedDisplay.Bounds.Size.Height / 2) - (this.Size.Height / 2);

            FileInfo fi = new FileInfo(video);
            this.vlcControl1.SetMedia(fi);
            this.vlcControl1.Play();


        }

        private void vlcControl1_VlcLibDirectoryNeeded_1(object sender, Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs e)
        {
            var currentAssembly = Assembly.GetEntryAssembly();
            var currentDirectory = new FileInfo(currentAssembly.Location).DirectoryName;
            e.VlcLibDirectory = new DirectoryInfo(Path.Combine(currentDirectory, "libvlc", IntPtr.Size == 4 ? "win-x86" : "win-x64"));
        }

        public void VypnutVideo()
        {
            vlcControl1.Stop();
            this.Close();
        }

        private void vlcControl1_EndReached(object sender, Vlc.DotNet.Core.VlcMediaPlayerEndReachedEventArgs e)
        {

            Action act = new Action(() =>
            {
                VypnutVideo();
            });
            new Task(() =>
            {
                if (this.InvokeRequired)
                    this.Invoke(act);
                else
                    act();
            }).Start();

        }

        private void ReklamaForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            riadiaci.KoniecVidea();
        }
    }
}
