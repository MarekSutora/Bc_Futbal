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
            this.potvrditButton = new System.Windows.Forms.Button();
            this.hraciLBodch = new System.Windows.Forms.ListBox();
            this.backButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.hraciLBnast = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // potvrditButton
            // 
            this.potvrditButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.potvrditButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.potvrditButton.Location = new System.Drawing.Point(571, 13);
            this.potvrditButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.potvrditButton.Name = "potvrditButton";
            this.potvrditButton.Size = new System.Drawing.Size(176, 78);
            this.potvrditButton.TabIndex = 555;
            this.potvrditButton.Text = "Potvrdiť";
            this.potvrditButton.UseVisualStyleBackColor = false;
            this.potvrditButton.Click += new System.EventHandler(this.PotvrditButton_Click);
            // 
            // hraciLBodch
            // 
            this.hraciLBodch.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.hraciLBodch.FormattingEnabled = true;
            this.hraciLBodch.ItemHeight = 29;
            this.hraciLBodch.Location = new System.Drawing.Point(9, 38);
            this.hraciLBodch.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.hraciLBodch.Name = "hraciLBodch";
            this.hraciLBodch.Size = new System.Drawing.Size(278, 381);
            this.hraciLBodch.TabIndex = 554;
            // 
            // backButton
            // 
            this.backButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.backButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.backButton.Location = new System.Drawing.Point(571, 94);
            this.backButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(176, 78);
            this.backButton.TabIndex = 553;
            this.backButton.Text = "Návrat späť";
            this.backButton.UseVisualStyleBackColor = false;
            this.backButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(8, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(235, 29);
            this.label1.TabIndex = 556;
            this.label1.Text = "Odchádzajúci hráč:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(285, 6);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(214, 29);
            this.label2.TabIndex = 557;
            this.label2.Text = "Nastupujúci hráč:";
            // 
            // hraciLBnast
            // 
            this.hraciLBnast.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.hraciLBnast.FormattingEnabled = true;
            this.hraciLBnast.ItemHeight = 29;
            this.hraciLBnast.Location = new System.Drawing.Point(290, 38);
            this.hraciLBnast.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.hraciLBnast.Name = "hraciLBnast";
            this.hraciLBnast.Size = new System.Drawing.Size(278, 381);
            this.hraciLBnast.TabIndex = 558;
            // 
            // StriedanieSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 430);
            this.Controls.Add(this.hraciLBnast);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.potvrditButton);
            this.Controls.Add(this.hraciLBodch);
            this.Controls.Add(this.backButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StriedanieSettingsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Striedanie - nastavenia";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StriedanieSettingsForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button potvrditButton;
        private System.Windows.Forms.ListBox hraciLBodch;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox hraciLBnast;
    }
}