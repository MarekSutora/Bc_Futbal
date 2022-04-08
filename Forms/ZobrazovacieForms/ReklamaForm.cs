using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using LGR_Futbal.Setup;

namespace LGR_Futbal.Forms
{
    public delegate void ReklamaKoniecHandler();
    public partial class ReklamaForm : Form
    {

        public event ReklamaKoniecHandler OnReklamaKoniec;
        private string video = string.Empty;

        public ReklamaForm(int sirka, string video)
        {
            InitializeComponent();

            float pomer = (float)sirka /Width;
            Scale(new SizeF(pomer, pomer));

            this.video = video;
        }

        private void ReklamaForm_Load(object sender, EventArgs e)
        {
            LayoutSetter.ZobrazNaDruhejObrazovke(this);

            FileInfo fi = new FileInfo(video);
            VlcControl.SetMedia(fi);
            VlcControl.Play();
        }

        private void VlcControl_VlcLibDirectoryNeeded(object sender, Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs e)
        {
            e.VlcLibDirectory = new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), "libvlc", IntPtr.Size == 4 ? "win-x86" : "win-x64"));
        }

        public void VypnutVideo()
        {
            VlcControl.Stop();
            Close();
        }

        private void VlcControl_EndReached(object sender, Vlc.DotNet.Core.VlcMediaPlayerEndReachedEventArgs e)
        {

            Action act = new Action(() =>
            {
                VypnutVideo();
            });
            new Task(() =>
            {
                if (InvokeRequired)
                    Invoke(act);
                else
                    act();
            }).Start();

        }

        private void ReklamaForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            OnReklamaKoniec?.Invoke();
        }
    }
}
