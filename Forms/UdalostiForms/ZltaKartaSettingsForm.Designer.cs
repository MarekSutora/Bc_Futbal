namespace LGR_Futbal.Forms.UdalostiForms
{
    partial class ZltaKartaSettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZltaKartaSettingsForm));
            this.BackButton = new System.Windows.Forms.Button();
            this.HraciLB = new System.Windows.Forms.ListBox();
            this.PotvrditButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BackButton
            // 
            this.BackButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.BackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BackButton.Location = new System.Drawing.Point(291, 92);
            this.BackButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(174, 78);
            this.BackButton.TabIndex = 9;
            this.BackButton.Text = "Návrat späť";
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // HraciLB
            // 
            this.HraciLB.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.HraciLB.FormattingEnabled = true;
            this.HraciLB.ItemHeight = 26;
            this.HraciLB.Location = new System.Drawing.Point(11, 12);
            this.HraciLB.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.HraciLB.Name = "HraciLB";
            this.HraciLB.Size = new System.Drawing.Size(276, 394);
            this.HraciLB.TabIndex = 548;
            // 
            // PotvrditButton
            // 
            this.PotvrditButton.BackColor = System.Drawing.Color.Yellow;
            this.PotvrditButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PotvrditButton.Location = new System.Drawing.Point(291, 12);
            this.PotvrditButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.PotvrditButton.Name = "PotvrditButton";
            this.PotvrditButton.Size = new System.Drawing.Size(174, 78);
            this.PotvrditButton.TabIndex = 549;
            this.PotvrditButton.Text = "Potvrdiť";
            this.PotvrditButton.UseVisualStyleBackColor = false;
            this.PotvrditButton.Click += new System.EventHandler(this.PotvrditButton_Click);
            // 
            // ZltaKartaSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 429);
            this.Controls.Add(this.PotvrditButton);
            this.Controls.Add(this.HraciLB);
            this.Controls.Add(this.BackButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ZltaKartaSettingsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Žltá karta - nastavenia";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ZltaKartaSettingsForm_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.ListBox HraciLB;
        private System.Windows.Forms.Button PotvrditButton;
    }
}