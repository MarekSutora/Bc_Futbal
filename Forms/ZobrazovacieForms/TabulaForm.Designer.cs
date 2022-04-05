namespace LGR_Futbal.Forms
{
    partial class TabulaForm
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
            this.domaciLabel = new System.Windows.Forms.Label();
            this.hostiaLabel = new System.Windows.Forms.Label();
            this.skoreHostiaLabel = new System.Windows.Forms.Label();
            this.skoreDomaciLabel = new System.Windows.Forms.Label();
            this.polcasLabel = new System.Windows.Forms.Label();
            this.casLabel = new System.Windows.Forms.Label();
            this.logoHostia = new System.Windows.Forms.PictureBox();
            this.logoDomaci = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.logoHostia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoDomaci)).BeginInit();
            this.SuspendLayout();
            // 
            // domaciLabel
            // 
            this.domaciLabel.Font = new System.Drawing.Font("Arial", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.domaciLabel.ForeColor = System.Drawing.Color.Aqua;
            this.domaciLabel.Location = new System.Drawing.Point(10, 272);
            this.domaciLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.domaciLabel.Name = "domaciLabel";
            this.domaciLabel.Size = new System.Drawing.Size(400, 65);
            this.domaciLabel.TabIndex = 543;
            this.domaciLabel.Text = "DOMÁCI";
            this.domaciLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // hostiaLabel
            // 
            this.hostiaLabel.Font = new System.Drawing.Font("Arial", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.hostiaLabel.ForeColor = System.Drawing.Color.Aqua;
            this.hostiaLabel.Location = new System.Drawing.Point(549, 272);
            this.hostiaLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.hostiaLabel.Name = "hostiaLabel";
            this.hostiaLabel.Size = new System.Drawing.Size(400, 65);
            this.hostiaLabel.TabIndex = 544;
            this.hostiaLabel.Text = "HOSTIA";
            this.hostiaLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // skoreHostiaLabel
            // 
            this.skoreHostiaLabel.Font = new System.Drawing.Font("Arial", 100.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.skoreHostiaLabel.ForeColor = System.Drawing.Color.Red;
            this.skoreHostiaLabel.Location = new System.Drawing.Point(684, 337);
            this.skoreHostiaLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.skoreHostiaLabel.Name = "skoreHostiaLabel";
            this.skoreHostiaLabel.Size = new System.Drawing.Size(256, 220);
            this.skoreHostiaLabel.TabIndex = 546;
            this.skoreHostiaLabel.Text = "0";
            this.skoreHostiaLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // skoreDomaciLabel
            // 
            this.skoreDomaciLabel.Font = new System.Drawing.Font("Arial", 100.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.skoreDomaciLabel.ForeColor = System.Drawing.Color.Red;
            this.skoreDomaciLabel.Location = new System.Drawing.Point(20, 337);
            this.skoreDomaciLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.skoreDomaciLabel.Name = "skoreDomaciLabel";
            this.skoreDomaciLabel.Size = new System.Drawing.Size(256, 220);
            this.skoreDomaciLabel.TabIndex = 545;
            this.skoreDomaciLabel.Text = "0";
            this.skoreDomaciLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // polcasLabel
            // 
            this.polcasLabel.Font = new System.Drawing.Font("Arial", 45F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.polcasLabel.ForeColor = System.Drawing.Color.Yellow;
            this.polcasLabel.Location = new System.Drawing.Point(270, 439);
            this.polcasLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.polcasLabel.Name = "polcasLabel";
            this.polcasLabel.Size = new System.Drawing.Size(420, 81);
            this.polcasLabel.TabIndex = 547;
            this.polcasLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // casLabel
            // 
            this.casLabel.Font = new System.Drawing.Font("Arial", 100.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.casLabel.ForeColor = System.Drawing.Color.Lime;
            this.casLabel.Location = new System.Drawing.Point(270, 10);
            this.casLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.casLabel.Name = "casLabel";
            this.casLabel.Size = new System.Drawing.Size(420, 157);
            this.casLabel.TabIndex = 549;
            this.casLabel.Text = "00:00";
            this.casLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // logoHostia
            // 
            this.logoHostia.Location = new System.Drawing.Point(695, 10);
            this.logoHostia.Name = "logoHostia";
            this.logoHostia.Size = new System.Drawing.Size(255, 244);
            this.logoHostia.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logoHostia.TabIndex = 542;
            this.logoHostia.TabStop = false;
            // 
            // logoDomaci
            // 
            this.logoDomaci.Location = new System.Drawing.Point(10, 10);
            this.logoDomaci.Name = "logoDomaci";
            this.logoDomaci.Size = new System.Drawing.Size(255, 244);
            this.logoDomaci.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logoDomaci.TabIndex = 541;
            this.logoDomaci.TabStop = false;
            // 
            // TabulaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(960, 585);
            this.Controls.Add(this.casLabel);
            this.Controls.Add(this.polcasLabel);
            this.Controls.Add(this.skoreHostiaLabel);
            this.Controls.Add(this.skoreDomaciLabel);
            this.Controls.Add(this.hostiaLabel);
            this.Controls.Add(this.domaciLabel);
            this.Controls.Add(this.logoHostia);
            this.Controls.Add(this.logoDomaci);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "TabulaForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.TabulaForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.logoHostia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoDomaci)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label domaciLabel;
        private System.Windows.Forms.PictureBox logoHostia;
        private System.Windows.Forms.PictureBox logoDomaci;
        private System.Windows.Forms.Label hostiaLabel;
        private System.Windows.Forms.Label skoreHostiaLabel;
        private System.Windows.Forms.Label skoreDomaciLabel;
        private System.Windows.Forms.Label polcasLabel;
        private System.Windows.Forms.Label casLabel;
    }
}