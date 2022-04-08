namespace LGR_Futbal.Forms
{
    partial class StriedanieSettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StriedanieSettingsForm));
            this.PotvrditButton = new System.Windows.Forms.Button();
            this.HraciLBodch = new System.Windows.Forms.ListBox();
            this.BackButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.HraciLBnast = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // PotvrditButton
            // 
            this.PotvrditButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.PotvrditButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PotvrditButton.Location = new System.Drawing.Point(571, 13);
            this.PotvrditButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.PotvrditButton.Name = "PotvrditButton";
            this.PotvrditButton.Size = new System.Drawing.Size(176, 78);
            this.PotvrditButton.TabIndex = 555;
            this.PotvrditButton.Text = "Potvrdiť";
            this.PotvrditButton.UseVisualStyleBackColor = false;
            this.PotvrditButton.Click += new System.EventHandler(this.PotvrditBtn_Click);
            // 
            // HraciLBodch
            // 
            this.HraciLBodch.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.HraciLBodch.FormattingEnabled = true;
            this.HraciLBodch.ItemHeight = 29;
            this.HraciLBodch.Location = new System.Drawing.Point(9, 38);
            this.HraciLBodch.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.HraciLBodch.Name = "HraciLBodch";
            this.HraciLBodch.Size = new System.Drawing.Size(278, 381);
            this.HraciLBodch.TabIndex = 554;
            // 
            // BackButton
            // 
            this.BackButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.BackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BackButton.Location = new System.Drawing.Point(571, 94);
            this.BackButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(176, 78);
            this.BackButton.TabIndex = 553;
            this.BackButton.Text = "Návrat späť";
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Click += new System.EventHandler(this.SpatBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(5, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 24);
            this.label1.TabIndex = 556;
            this.label1.Text = "Odchádzajúci hráč:";
            this.label1.Click += new System.EventHandler(this.OdznacVsetko);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(286, 13);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 24);
            this.label2.TabIndex = 557;
            this.label2.Text = "Nastupujúci hráč:";
            this.label2.Click += new System.EventHandler(this.OdznacVsetko);
            // 
            // HraciLBnast
            // 
            this.HraciLBnast.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.HraciLBnast.FormattingEnabled = true;
            this.HraciLBnast.ItemHeight = 29;
            this.HraciLBnast.Location = new System.Drawing.Point(290, 38);
            this.HraciLBnast.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.HraciLBnast.Name = "HraciLBnast";
            this.HraciLBnast.Size = new System.Drawing.Size(278, 381);
            this.HraciLBnast.TabIndex = 558;
            // 
            // StriedanieSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 430);
            this.Controls.Add(this.HraciLBnast);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PotvrditButton);
            this.Controls.Add(this.HraciLBodch);
            this.Controls.Add(this.BackButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StriedanieSettingsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Striedanie - nastavenia";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.StriedanieSettingsForm_FormClosed);
            this.Click += new System.EventHandler(this.OdznacVsetko);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button PotvrditButton;
        private System.Windows.Forms.ListBox HraciLBodch;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox HraciLBnast;
    }
}