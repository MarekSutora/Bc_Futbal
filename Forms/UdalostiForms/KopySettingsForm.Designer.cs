namespace LGR_Futbal.Forms
{
    partial class KopySettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KopySettingsForm));
            this.RohovyRB = new System.Windows.Forms.RadioButton();
            this.PriamyRB = new System.Windows.Forms.RadioButton();
            this.NepriamyRB = new System.Windows.Forms.RadioButton();
            this.PokutovyRB = new System.Windows.Forms.RadioButton();
            this.PotvrditButton = new System.Windows.Forms.Button();
            this.BackButton = new System.Windows.Forms.Button();
            this.HraciLabel = new System.Windows.Forms.Label();
            this.HraciLB = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // RohovyRB
            // 
            this.RohovyRB.AutoSize = true;
            this.RohovyRB.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.RohovyRB.Location = new System.Drawing.Point(265, 12);
            this.RohovyRB.Name = "RohovyRB";
            this.RohovyRB.Size = new System.Drawing.Size(128, 28);
            this.RohovyRB.TabIndex = 0;
            this.RohovyRB.TabStop = true;
            this.RohovyRB.Text = "Rohový kop";
            this.RohovyRB.UseVisualStyleBackColor = true;
            // 
            // PriamyRB
            // 
            this.PriamyRB.AutoSize = true;
            this.PriamyRB.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.PriamyRB.Location = new System.Drawing.Point(12, 12);
            this.PriamyRB.Name = "PriamyRB";
            this.PriamyRB.Size = new System.Drawing.Size(121, 28);
            this.PriamyRB.TabIndex = 1;
            this.PriamyRB.TabStop = true;
            this.PriamyRB.Text = "Priamy kop";
            this.PriamyRB.UseVisualStyleBackColor = true;
            // 
            // NepriamyRB
            // 
            this.NepriamyRB.AutoSize = true;
            this.NepriamyRB.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.NepriamyRB.Location = new System.Drawing.Point(12, 46);
            this.NepriamyRB.Name = "NepriamyRB";
            this.NepriamyRB.Size = new System.Drawing.Size(145, 28);
            this.NepriamyRB.TabIndex = 2;
            this.NepriamyRB.TabStop = true;
            this.NepriamyRB.Text = "Nepriamy kop";
            this.NepriamyRB.UseVisualStyleBackColor = true;
            // 
            // PokutovyRB
            // 
            this.PokutovyRB.AutoSize = true;
            this.PokutovyRB.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.PokutovyRB.Location = new System.Drawing.Point(265, 46);
            this.PokutovyRB.Name = "PokutovyRB";
            this.PokutovyRB.Size = new System.Drawing.Size(140, 28);
            this.PokutovyRB.TabIndex = 3;
            this.PokutovyRB.TabStop = true;
            this.PokutovyRB.Text = "Pokutový kop";
            this.PokutovyRB.UseVisualStyleBackColor = true;
            // 
            // PotvrditButton
            // 
            this.PotvrditButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.PotvrditButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PotvrditButton.Location = new System.Drawing.Point(12, 362);
            this.PotvrditButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.PotvrditButton.Name = "PotvrditButton";
            this.PotvrditButton.Size = new System.Drawing.Size(174, 78);
            this.PotvrditButton.TabIndex = 555;
            this.PotvrditButton.Text = "Potvrdiť";
            this.PotvrditButton.UseVisualStyleBackColor = false;
            this.PotvrditButton.Click += new System.EventHandler(this.PotvrditBtn_Click);
            // 
            // BackButton
            // 
            this.BackButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.BackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BackButton.Location = new System.Drawing.Point(231, 362);
            this.BackButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(174, 78);
            this.BackButton.TabIndex = 556;
            this.BackButton.Text = "Návrat späť";
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Click += new System.EventHandler(this.SpatBtn_Click);
            // 
            // HraciLabel
            // 
            this.HraciLabel.AutoSize = true;
            this.HraciLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.HraciLabel.Location = new System.Drawing.Point(12, 86);
            this.HraciLabel.Name = "HraciLabel";
            this.HraciLabel.Size = new System.Drawing.Size(59, 24);
            this.HraciLabel.TabIndex = 558;
            this.HraciLabel.Text = "Hráči:";
            // 
            // HraciLB
            // 
            this.HraciLB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.HraciLB.FormattingEnabled = true;
            this.HraciLB.ItemHeight = 20;
            this.HraciLB.Location = new System.Drawing.Point(16, 114);
            this.HraciLB.Name = "HraciLB";
            this.HraciLB.Size = new System.Drawing.Size(389, 224);
            this.HraciLB.TabIndex = 559;
            this.HraciLB.DoubleClick += new System.EventHandler(this.HraciLB_DoubleClick);
            // 
            // KopySettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 450);
            this.Controls.Add(this.HraciLB);
            this.Controls.Add(this.HraciLabel);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.PotvrditButton);
            this.Controls.Add(this.PokutovyRB);
            this.Controls.Add(this.NepriamyRB);
            this.Controls.Add(this.PriamyRB);
            this.Controls.Add(this.RohovyRB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "KopySettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KopySettingsForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.KopySettingsForm_FormClosed);
            this.Click += new System.EventHandler(this.KopySettingsForm_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton RohovyRB;
        private System.Windows.Forms.RadioButton PriamyRB;
        private System.Windows.Forms.RadioButton NepriamyRB;
        private System.Windows.Forms.RadioButton PokutovyRB;
        private System.Windows.Forms.Button PotvrditButton;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Label HraciLabel;
        private System.Windows.Forms.ListBox HraciLB;
    }
}