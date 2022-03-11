namespace LGR_Futbal.Forms
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
            this.backButton = new System.Windows.Forms.Button();
            this.hraciLB = new System.Windows.Forms.ListBox();
            this.potvrditButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // backButton
            // 
            this.backButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.backButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.backButton.Location = new System.Drawing.Point(291, 92);
            this.backButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(174, 78);
            this.backButton.TabIndex = 9;
            this.backButton.Text = "Návrat späť";
            this.backButton.UseVisualStyleBackColor = false;
            this.backButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // hraciLB
            // 
            this.hraciLB.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.hraciLB.FormattingEnabled = true;
            this.hraciLB.ItemHeight = 26;
            this.hraciLB.Location = new System.Drawing.Point(11, 12);
            this.hraciLB.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.hraciLB.Name = "hraciLB";
            this.hraciLB.Size = new System.Drawing.Size(276, 394);
            this.hraciLB.TabIndex = 548;
            this.hraciLB.DoubleClick += new System.EventHandler(this.hraciLB_DoubleClick);
            // 
            // potvrditButton
            // 
            this.potvrditButton.BackColor = System.Drawing.Color.Yellow;
            this.potvrditButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.potvrditButton.Location = new System.Drawing.Point(291, 12);
            this.potvrditButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.potvrditButton.Name = "potvrditButton";
            this.potvrditButton.Size = new System.Drawing.Size(174, 78);
            this.potvrditButton.TabIndex = 549;
            this.potvrditButton.Text = "Potvrdiť";
            this.potvrditButton.UseVisualStyleBackColor = false;
            this.potvrditButton.Click += new System.EventHandler(this.PotvrditButton_Click);
            // 
            // ZltaKartaSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 430);
            this.Controls.Add(this.potvrditButton);
            this.Controls.Add(this.hraciLB);
            this.Controls.Add(this.backButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ZltaKartaSettingsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Žltá karta - nastavenia";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ZltaKartaSettingsForm_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ZltaKartaSettingsForm_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.ListBox hraciLB;
        private System.Windows.Forms.Button potvrditButton;
    }
}