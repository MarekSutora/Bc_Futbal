namespace LGR_Futbal.Forms
{
    partial class SizeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SizeForm));
            this.velkostGroupBox = new System.Windows.Forms.GroupBox();
            this.rozlisenieLabel = new System.Windows.Forms.Label();
            this.aktLabel = new System.Windows.Forms.Label();
            this.infoLabel = new System.Windows.Forms.Label();
            this.vyskaLabel = new System.Windows.Forms.Label();
            this.vyskaNumUpDown = new System.Windows.Forms.NumericUpDown();
            this.sirkaNumUpDown = new System.Windows.Forms.NumericUpDown();
            this.sirkaLabel = new System.Windows.Forms.Label();
            this.pozadieCheckBox = new System.Windows.Forms.CheckBox();
            this.initNastaveniaCheckBox = new System.Windows.Forms.CheckBox();
            this.zrusitButton = new System.Windows.Forms.Button();
            this.aktivovatButton = new System.Windows.Forms.Button();
            this.jazykGroupBox = new System.Windows.Forms.GroupBox();
            this.czRadioButton = new System.Windows.Forms.RadioButton();
            this.skRadioButton = new System.Windows.Forms.RadioButton();
            this.velkostGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vyskaNumUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sirkaNumUpDown)).BeginInit();
            this.jazykGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // velkostGroupBox
            // 
            this.velkostGroupBox.BackColor = System.Drawing.SystemColors.Control;
            this.velkostGroupBox.Controls.Add(this.rozlisenieLabel);
            this.velkostGroupBox.Controls.Add(this.aktLabel);
            this.velkostGroupBox.Controls.Add(this.infoLabel);
            this.velkostGroupBox.Controls.Add(this.vyskaLabel);
            this.velkostGroupBox.Controls.Add(this.vyskaNumUpDown);
            this.velkostGroupBox.Controls.Add(this.sirkaNumUpDown);
            this.velkostGroupBox.Controls.Add(this.sirkaLabel);
            this.velkostGroupBox.Location = new System.Drawing.Point(8, 8);
            this.velkostGroupBox.Margin = new System.Windows.Forms.Padding(2);
            this.velkostGroupBox.Name = "velkostGroupBox";
            this.velkostGroupBox.Padding = new System.Windows.Forms.Padding(2);
            this.velkostGroupBox.Size = new System.Drawing.Size(235, 130);
            this.velkostGroupBox.TabIndex = 2;
            this.velkostGroupBox.TabStop = false;
            this.velkostGroupBox.Text = "Veľkosť zobrazovacej plochy";
            // 
            // rozlisenieLabel
            // 
            this.rozlisenieLabel.AutoSize = true;
            this.rozlisenieLabel.Location = new System.Drawing.Point(166, 108);
            this.rozlisenieLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.rozlisenieLabel.Name = "rozlisenieLabel";
            this.rozlisenieLabel.Size = new System.Drawing.Size(25, 13);
            this.rozlisenieLabel.TabIndex = 7;
            this.rozlisenieLabel.Text = "???";
            // 
            // aktLabel
            // 
            this.aktLabel.AutoSize = true;
            this.aktLabel.Location = new System.Drawing.Point(4, 108);
            this.aktLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.aktLabel.Name = "aktLabel";
            this.aktLabel.Size = new System.Drawing.Size(163, 13);
            this.aktLabel.TabIndex = 6;
            this.aktLabel.Text = "Aktuálne rozlíšenie obrazovky je:";
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.Location = new System.Drawing.Point(4, 82);
            this.infoLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(214, 13);
            this.infoLabel.TabIndex = 4;
            this.infoLabel.Text = "Poznámka: Pomer strán je fixovaný na 16:9!";
            // 
            // vyskaLabel
            // 
            this.vyskaLabel.AutoSize = true;
            this.vyskaLabel.Location = new System.Drawing.Point(4, 51);
            this.vyskaLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.vyskaLabel.Name = "vyskaLabel";
            this.vyskaLabel.Size = new System.Drawing.Size(39, 13);
            this.vyskaLabel.TabIndex = 3;
            this.vyskaLabel.Text = "Výška:";
            // 
            // vyskaNumUpDown
            // 
            this.vyskaNumUpDown.Location = new System.Drawing.Point(53, 49);
            this.vyskaNumUpDown.Margin = new System.Windows.Forms.Padding(2);
            this.vyskaNumUpDown.Maximum = new decimal(new int[] {
            30000,
            0,
            0,
            0});
            this.vyskaNumUpDown.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.vyskaNumUpDown.Name = "vyskaNumUpDown";
            this.vyskaNumUpDown.Size = new System.Drawing.Size(53, 20);
            this.vyskaNumUpDown.TabIndex = 2;
            this.vyskaNumUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.vyskaNumUpDown.Value = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.vyskaNumUpDown.ValueChanged += new System.EventHandler(this.VyskaNumUpDown_ValueChanged);
            // 
            // sirkaNumUpDown
            // 
            this.sirkaNumUpDown.Location = new System.Drawing.Point(53, 16);
            this.sirkaNumUpDown.Margin = new System.Windows.Forms.Padding(2);
            this.sirkaNumUpDown.Maximum = new decimal(new int[] {
            40000,
            0,
            0,
            0});
            this.sirkaNumUpDown.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.sirkaNumUpDown.Name = "sirkaNumUpDown";
            this.sirkaNumUpDown.Size = new System.Drawing.Size(53, 20);
            this.sirkaNumUpDown.TabIndex = 1;
            this.sirkaNumUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.sirkaNumUpDown.Value = new decimal(new int[] {
            800,
            0,
            0,
            0});
            this.sirkaNumUpDown.ValueChanged += new System.EventHandler(this.SirkaNumUpDown_ValueChanged);
            // 
            // sirkaLabel
            // 
            this.sirkaLabel.AutoSize = true;
            this.sirkaLabel.Location = new System.Drawing.Point(4, 18);
            this.sirkaLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.sirkaLabel.Name = "sirkaLabel";
            this.sirkaLabel.Size = new System.Drawing.Size(36, 13);
            this.sirkaLabel.TabIndex = 0;
            this.sirkaLabel.Text = "Šírka:";
            // 
            // pozadieCheckBox
            // 
            this.pozadieCheckBox.AutoSize = true;
            this.pozadieCheckBox.Checked = true;
            this.pozadieCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.pozadieCheckBox.Location = new System.Drawing.Point(15, 205);
            this.pozadieCheckBox.Name = "pozadieCheckBox";
            this.pozadieCheckBox.Size = new System.Drawing.Size(184, 17);
            this.pozadieCheckBox.TabIndex = 13;
            this.pozadieCheckBox.Text = "Prekryť obrazovku čiernou farbou";
            this.pozadieCheckBox.UseVisualStyleBackColor = true;
            // 
            // initNastaveniaCheckBox
            // 
            this.initNastaveniaCheckBox.AutoSize = true;
            this.initNastaveniaCheckBox.Checked = true;
            this.initNastaveniaCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.initNastaveniaCheckBox.Location = new System.Drawing.Point(15, 227);
            this.initNastaveniaCheckBox.Name = "initNastaveniaCheckBox";
            this.initNastaveniaCheckBox.Size = new System.Drawing.Size(232, 17);
            this.initNastaveniaCheckBox.TabIndex = 14;
            this.initNastaveniaCheckBox.Text = "Zobrazovať toto okno pri spustení aplikácie";
            this.initNastaveniaCheckBox.UseVisualStyleBackColor = true;
            // 
            // zrusitButton
            // 
            this.zrusitButton.Image = global::LGR_Futbal.Properties.Resources.Stop_2;
            this.zrusitButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.zrusitButton.Location = new System.Drawing.Point(247, 86);
            this.zrusitButton.Margin = new System.Windows.Forms.Padding(2);
            this.zrusitButton.Name = "zrusitButton";
            this.zrusitButton.Size = new System.Drawing.Size(106, 52);
            this.zrusitButton.TabIndex = 16;
            this.zrusitButton.Text = "Zrušiť      ";
            this.zrusitButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.zrusitButton.UseVisualStyleBackColor = true;
            this.zrusitButton.Click += new System.EventHandler(this.ZrusitButton_Click);
            // 
            // aktivovatButton
            // 
            this.aktivovatButton.Image = global::LGR_Futbal.Properties.Resources.Forward___Next;
            this.aktivovatButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.aktivovatButton.Location = new System.Drawing.Point(247, 8);
            this.aktivovatButton.Margin = new System.Windows.Forms.Padding(2);
            this.aktivovatButton.Name = "aktivovatButton";
            this.aktivovatButton.Size = new System.Drawing.Size(106, 52);
            this.aktivovatButton.TabIndex = 15;
            this.aktivovatButton.Text = "Aktivovať  ";
            this.aktivovatButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.aktivovatButton.UseVisualStyleBackColor = true;
            this.aktivovatButton.Click += new System.EventHandler(this.AktivovatButton_Click);
            // 
            // jazykGroupBox
            // 
            this.jazykGroupBox.Controls.Add(this.czRadioButton);
            this.jazykGroupBox.Controls.Add(this.skRadioButton);
            this.jazykGroupBox.Location = new System.Drawing.Point(8, 142);
            this.jazykGroupBox.Margin = new System.Windows.Forms.Padding(2);
            this.jazykGroupBox.Name = "jazykGroupBox";
            this.jazykGroupBox.Padding = new System.Windows.Forms.Padding(2);
            this.jazykGroupBox.Size = new System.Drawing.Size(235, 58);
            this.jazykGroupBox.TabIndex = 17;
            this.jazykGroupBox.TabStop = false;
            this.jazykGroupBox.Text = "Jazykové nastavenia";
            // 
            // czRadioButton
            // 
            this.czRadioButton.AutoSize = true;
            this.czRadioButton.Location = new System.Drawing.Point(7, 36);
            this.czRadioButton.Margin = new System.Windows.Forms.Padding(2);
            this.czRadioButton.Name = "czRadioButton";
            this.czRadioButton.Size = new System.Drawing.Size(77, 17);
            this.czRadioButton.TabIndex = 1;
            this.czRadioButton.TabStop = true;
            this.czRadioButton.Text = "české (CZ)";
            this.czRadioButton.UseVisualStyleBackColor = true;
            // 
            // skRadioButton
            // 
            this.skRadioButton.AutoSize = true;
            this.skRadioButton.Location = new System.Drawing.Point(7, 16);
            this.skRadioButton.Margin = new System.Windows.Forms.Padding(2);
            this.skRadioButton.Name = "skRadioButton";
            this.skRadioButton.Size = new System.Drawing.Size(96, 17);
            this.skRadioButton.TabIndex = 0;
            this.skRadioButton.TabStop = true;
            this.skRadioButton.Text = "slovenské (SK)";
            this.skRadioButton.UseVisualStyleBackColor = true;
            // 
            // SizeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 256);
            this.Controls.Add(this.jazykGroupBox);
            this.Controls.Add(this.zrusitButton);
            this.Controls.Add(this.aktivovatButton);
            this.Controls.Add(this.initNastaveniaCheckBox);
            this.Controls.Add(this.pozadieCheckBox);
            this.Controls.Add(this.velkostGroupBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SizeForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nastavenie veľkosti zobrazovacej plochy";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SizeForm_KeyDown);
            this.velkostGroupBox.ResumeLayout(false);
            this.velkostGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vyskaNumUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sirkaNumUpDown)).EndInit();
            this.jazykGroupBox.ResumeLayout(false);
            this.jazykGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox velkostGroupBox;
        private System.Windows.Forms.Label rozlisenieLabel;
        private System.Windows.Forms.Label aktLabel;
        private System.Windows.Forms.Label infoLabel;
        private System.Windows.Forms.Label vyskaLabel;
        private System.Windows.Forms.NumericUpDown vyskaNumUpDown;
        private System.Windows.Forms.NumericUpDown sirkaNumUpDown;
        private System.Windows.Forms.Label sirkaLabel;
        private System.Windows.Forms.CheckBox pozadieCheckBox;
        private System.Windows.Forms.CheckBox initNastaveniaCheckBox;
        private System.Windows.Forms.Button zrusitButton;
        private System.Windows.Forms.Button aktivovatButton;
        private System.Windows.Forms.GroupBox jazykGroupBox;
        private System.Windows.Forms.RadioButton czRadioButton;
        private System.Windows.Forms.RadioButton skRadioButton;
    }
}