namespace LGR_Futbal.Forms
{
    partial class PredstavenieSettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PredstavenieSettingsForm));
            this.domaciButton = new System.Windows.Forms.Button();
            this.hostiaButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.farbyButton = new System.Windows.Forms.Button();
            this.fontyButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // domaciButton
            // 
            this.domaciButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.domaciButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.domaciButton.Location = new System.Drawing.Point(9, 9);
            this.domaciButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.domaciButton.Name = "domaciButton";
            this.domaciButton.Size = new System.Drawing.Size(175, 78);
            this.domaciButton.TabIndex = 6;
            this.domaciButton.Text = "Prezentácia\r\ndomáceho tímu";
            this.domaciButton.UseVisualStyleBackColor = false;
            this.domaciButton.Click += new System.EventHandler(this.DomaciButton_Click);
            // 
            // hostiaButton
            // 
            this.hostiaButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.hostiaButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.hostiaButton.Location = new System.Drawing.Point(204, 9);
            this.hostiaButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.hostiaButton.Name = "hostiaButton";
            this.hostiaButton.Size = new System.Drawing.Size(175, 78);
            this.hostiaButton.TabIndex = 7;
            this.hostiaButton.Text = "Prezentácia\r\ntímu hostí";
            this.hostiaButton.UseVisualStyleBackColor = false;
            this.hostiaButton.Click += new System.EventHandler(this.HostiaButton_Click);
            // 
            // backButton
            // 
            this.backButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.backButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.backButton.Location = new System.Drawing.Point(204, 177);
            this.backButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(175, 78);
            this.backButton.TabIndex = 8;
            this.backButton.Text = "Návrat späť";
            this.backButton.UseVisualStyleBackColor = false;
            this.backButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // farbyButton
            // 
            this.farbyButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.farbyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.farbyButton.Location = new System.Drawing.Point(9, 90);
            this.farbyButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.farbyButton.Name = "farbyButton";
            this.farbyButton.Size = new System.Drawing.Size(175, 78);
            this.farbyButton.TabIndex = 9;
            this.farbyButton.Text = "Nastavenie\r\nfarieb";
            this.farbyButton.UseVisualStyleBackColor = false;
            this.farbyButton.Click += new System.EventHandler(this.farbyButton_Click);
            // 
            // fontyButton
            // 
            this.fontyButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fontyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.fontyButton.Location = new System.Drawing.Point(204, 90);
            this.fontyButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.fontyButton.Name = "fontyButton";
            this.fontyButton.Size = new System.Drawing.Size(175, 78);
            this.fontyButton.TabIndex = 10;
            this.fontyButton.Text = "Nastavenie\r\nfontov";
            this.fontyButton.UseVisualStyleBackColor = false;
            this.fontyButton.Click += new System.EventHandler(this.fontyButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.stopButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.stopButton.Location = new System.Drawing.Point(9, 177);
            this.stopButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(175, 78);
            this.stopButton.TabIndex = 11;
            this.stopButton.Text = "Zastaviť prezentáciu";
            this.stopButton.UseVisualStyleBackColor = false;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(9, 282);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(201, 17);
            this.checkBox1.TabIndex = 12;
            this.checkBox1.Text = "Zahrnúť do prezentácie náhradníkov";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // PredstavenieSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 314);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.fontyButton);
            this.Controls.Add(this.farbyButton);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.hostiaButton);
            this.Controls.Add(this.domaciButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PredstavenieSettingsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Predstavenie hráčov";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PredstavenieSettingsForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PredstavenieSettingsForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button domaciButton;
        private System.Windows.Forms.Button hostiaButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button farbyButton;
        private System.Windows.Forms.Button fontyButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}