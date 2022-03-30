namespace LGR_Futbal.Forms
{
    partial class ReklamaForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.VlcControl = new Vlc.DotNet.Forms.VlcControl();
            ((System.ComponentModel.ISupportInitialize)(this.VlcControl)).BeginInit();
            this.SuspendLayout();
            // 
            // VlcControl
            // 
            this.VlcControl.BackColor = System.Drawing.Color.Black;
            this.VlcControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VlcControl.Location = new System.Drawing.Point(0, 0);
            this.VlcControl.Name = "VlcControl";
            this.VlcControl.Size = new System.Drawing.Size(800, 450);
            this.VlcControl.Spu = -1;
            this.VlcControl.TabIndex = 0;
            this.VlcControl.Text = "vlcControl1";
            this.VlcControl.VlcLibDirectory = null;
            this.VlcControl.VlcMediaplayerOptions = null;
            this.VlcControl.VlcLibDirectoryNeeded += new System.EventHandler<Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs>(this.VlcControl_VlcLibDirectoryNeeded);
            this.VlcControl.EndReached += new System.EventHandler<Vlc.DotNet.Core.VlcMediaPlayerEndReachedEventArgs>(this.VlcControl_EndReached);
            // 
            // ReklamaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.VlcControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ReklamaForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReklamaForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ReklamaForm_FormClosed);
            this.Load += new System.EventHandler(this.ReklamaForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.VlcControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Vlc.DotNet.Forms.VlcControl VlcControl;
    }
}