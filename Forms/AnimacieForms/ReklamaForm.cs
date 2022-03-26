using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Timers;
using LGR_Futbal.Setup;

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
            LayoutSetter.ZobrazNaDruhejObrazovke(this);

            FileInfo fi = new FileInfo(video);
            this.vlcControl1.SetMedia(fi);
            this.vlcControl1.Play();


        }

        private void vlcControl1_VlcLibDirectoryNeeded(object sender, Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs e)
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
