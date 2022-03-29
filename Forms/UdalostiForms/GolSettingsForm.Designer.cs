namespace LGR_Futbal.Forms.UdalostiForms
{
    partial class GolSettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GolSettingsForm));
            this.potvrditButton = new System.Windows.Forms.Button();
            this.HraciLB = new System.Windows.Forms.ListBox();
            this.BackButton = new System.Windows.Forms.Button();
            this.znizitSkoreButton = new System.Windows.Forms.Button();
            this.resetSkoreButton = new System.Windows.Forms.Button();
            this.NastavitButton = new System.Windows.Forms.Button();
            this.HodnotaLabel = new System.Windows.Forms.Label();
            this.HodnotaNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.AsistHraciLB = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.PenaltaCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.HodnotaNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // potvrditButton
            // 
            this.potvrditButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.potvrditButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.potvrditButton.Location = new System.Drawing.Point(598, 12);
            this.potvrditButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.potvrditButton.Name = "potvrditButton";
            this.potvrditButton.Size = new System.Drawing.Size(175, 78);
            this.potvrditButton.TabIndex = 552;
            this.potvrditButton.Text = "Potvrdiť gól";
            this.potvrditButton.UseVisualStyleBackColor = false;
            this.potvrditButton.Click += new System.EventHandler(this.PotvrditButton_Click);
            // 
            // HraciLB
            // 
            this.HraciLB.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.HraciLB.FormattingEnabled = true;
            this.HraciLB.ItemHeight = 26;
            this.HraciLB.Location = new System.Drawing.Point(11, 55);
            this.HraciLB.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.HraciLB.Name = "HraciLB";
            this.HraciLB.Size = new System.Drawing.Size(276, 368);
            this.HraciLB.TabIndex = 551;
            this.HraciLB.DoubleClick += new System.EventHandler(this.HraciLB_DoubleClick);
            // 
            // BackButton
            // 
            this.BackButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.BackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BackButton.Location = new System.Drawing.Point(600, 345);
            this.BackButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(175, 78);
            this.BackButton.TabIndex = 550;
            this.BackButton.Text = "Návrat späť";
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // znizitSkoreButton
            // 
            this.znizitSkoreButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.znizitSkoreButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.znizitSkoreButton.Location = new System.Drawing.Point(598, 94);
            this.znizitSkoreButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.znizitSkoreButton.Name = "znizitSkoreButton";
            this.znizitSkoreButton.Size = new System.Drawing.Size(176, 78);
            this.znizitSkoreButton.TabIndex = 553;
            this.znizitSkoreButton.Text = "Znížiť skóre";
            this.znizitSkoreButton.UseVisualStyleBackColor = false;
            this.znizitSkoreButton.Click += new System.EventHandler(this.ZnizitSkoreButton_Click);
            // 
            // resetSkoreButton
            // 
            this.resetSkoreButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.resetSkoreButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.resetSkoreButton.Location = new System.Drawing.Point(598, 175);
            this.resetSkoreButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.resetSkoreButton.Name = "resetSkoreButton";
            this.resetSkoreButton.Size = new System.Drawing.Size(176, 78);
            this.resetSkoreButton.TabIndex = 554;
            this.resetSkoreButton.Text = "Resetovať skóre";
            this.resetSkoreButton.UseVisualStyleBackColor = false;
            this.resetSkoreButton.Click += new System.EventHandler(this.ResetSkoreButton_Click);
            // 
            // NastavitButton
            // 
            this.NastavitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.NastavitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.NastavitButton.Location = new System.Drawing.Point(600, 296);
            this.NastavitButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.NastavitButton.Name = "NastavitButton";
            this.NastavitButton.Size = new System.Drawing.Size(174, 42);
            this.NastavitButton.TabIndex = 555;
            this.NastavitButton.Text = "Nastaviť";
            this.NastavitButton.UseVisualStyleBackColor = false;
            this.NastavitButton.Click += new System.EventHandler(this.NastavitButton_Click);
            // 
            // HodnotaLabel
            // 
            this.HodnotaLabel.AutoSize = true;
            this.HodnotaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.HodnotaLabel.Location = new System.Drawing.Point(640, 264);
            this.HodnotaLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.HodnotaLabel.Name = "HodnotaLabel";
            this.HodnotaLabel.Size = new System.Drawing.Size(75, 20);
            this.HodnotaLabel.TabIndex = 556;
            this.HodnotaLabel.Text = "Hodnota:";
            // 
            // HodnotaNumericUpDown
            // 
            this.HodnotaNumericUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.HodnotaNumericUpDown.Location = new System.Drawing.Point(717, 263);
            this.HodnotaNumericUpDown.Margin = new System.Windows.Forms.Padding(2);
            this.HodnotaNumericUpDown.Name = "HodnotaNumericUpDown";
            this.HodnotaNumericUpDown.Size = new System.Drawing.Size(57, 26);
            this.HodnotaNumericUpDown.TabIndex = 557;
            this.HodnotaNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // AsistHraciLB
            // 
            this.AsistHraciLB.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.AsistHraciLB.FormattingEnabled = true;
            this.AsistHraciLB.ItemHeight = 26;
            this.AsistHraciLB.Location = new System.Drawing.Point(300, 55);
            this.AsistHraciLB.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.AsistHraciLB.Name = "AsistHraciLB";
            this.AsistHraciLB.Size = new System.Drawing.Size(276, 368);
            this.AsistHraciLB.TabIndex = 558;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(12, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 24);
            this.label2.TabIndex = 559;
            this.label2.Text = "Strelec:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(306, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 24);
            this.label3.TabIndex = 560;
            this.label3.Text = "Asistujúci:";
            // 
            // PenaltaCheckBox
            // 
            this.PenaltaCheckBox.AutoSize = true;
            this.PenaltaCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PenaltaCheckBox.Location = new System.Drawing.Point(16, 3);
            this.PenaltaCheckBox.Name = "PenaltaCheckBox";
            this.PenaltaCheckBox.Size = new System.Drawing.Size(191, 24);
            this.PenaltaCheckBox.TabIndex = 561;
            this.PenaltaCheckBox.Text = "Gól z pokutového kopu";
            this.PenaltaCheckBox.UseVisualStyleBackColor = true;
            this.PenaltaCheckBox.CheckedChanged += new System.EventHandler(this.PenaltaCheckBox_CheckedChanged);
            // 
            // GolSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 430);
            this.Controls.Add(this.PenaltaCheckBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.AsistHraciLB);
            this.Controls.Add(this.HodnotaNumericUpDown);
            this.Controls.Add(this.HodnotaLabel);
            this.Controls.Add(this.NastavitButton);
            this.Controls.Add(this.resetSkoreButton);
            this.Controls.Add(this.znizitSkoreButton);
            this.Controls.Add(this.potvrditButton);
            this.Controls.Add(this.HraciLB);
            this.Controls.Add(this.BackButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GolSettingsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gól - nastavenia";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GolSettingsForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.HodnotaNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button potvrditButton;
        private System.Windows.Forms.ListBox HraciLB;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Button znizitSkoreButton;
        private System.Windows.Forms.Button resetSkoreButton;
        private System.Windows.Forms.Button NastavitButton;
        private System.Windows.Forms.Label HodnotaLabel;
        private System.Windows.Forms.NumericUpDown HodnotaNumericUpDown;
        private System.Windows.Forms.ListBox AsistHraciLB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox PenaltaCheckBox;
    }
}