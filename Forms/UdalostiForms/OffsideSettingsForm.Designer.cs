namespace LGR_Futbal.Forms
{
    partial class OffsideSettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OffsideSettingsForm));
            this.label1 = new System.Windows.Forms.Label();
            this.SpatBtn = new System.Windows.Forms.Button();
            this.PotvrditBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.HraciLB = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 24);
            this.label1.TabIndex = 566;
            this.label1.Text = "Hráči:";
            // 
            // SpatBtn
            // 
            this.SpatBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.SpatBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.SpatBtn.Location = new System.Drawing.Point(232, 362);
            this.SpatBtn.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.SpatBtn.Name = "SpatBtn";
            this.SpatBtn.Size = new System.Drawing.Size(174, 78);
            this.SpatBtn.TabIndex = 564;
            this.SpatBtn.Text = "Návrat späť";
            this.SpatBtn.UseVisualStyleBackColor = false;
            this.SpatBtn.Click += new System.EventHandler(this.SpatBtn_Click);
            // 
            // PotvrditBtn
            // 
            this.PotvrditBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.PotvrditBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PotvrditBtn.Location = new System.Drawing.Point(13, 362);
            this.PotvrditBtn.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.PotvrditBtn.Name = "PotvrditBtn";
            this.PotvrditBtn.Size = new System.Drawing.Size(174, 78);
            this.PotvrditBtn.TabIndex = 563;
            this.PotvrditBtn.Text = "Potvrdiť";
            this.PotvrditBtn.UseVisualStyleBackColor = false;
            this.PotvrditBtn.Click += new System.EventHandler(this.PotvrditBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(13, 324);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(387, 16);
            this.label2.TabIndex = 567;
            this.label2.Text = "Označte hráča ktorý sa dostal do postavenia mimo hry (ofsajdu).";
            // 
            // HraciLB
            // 
            this.HraciLB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.HraciLB.FormattingEnabled = true;
            this.HraciLB.ItemHeight = 20;
            this.HraciLB.Location = new System.Drawing.Point(16, 37);
            this.HraciLB.Name = "HraciLB";
            this.HraciLB.Size = new System.Drawing.Size(384, 264);
            this.HraciLB.TabIndex = 568;
            this.HraciLB.DoubleClick += new System.EventHandler(this.HraciLB_DoubleClick);
            // 
            // OffsideSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 450);
            this.Controls.Add(this.HraciLB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SpatBtn);
            this.Controls.Add(this.PotvrditBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OffsideSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Offside";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OffsideSettingsForm_FormClosed);
            this.Click += new System.EventHandler(this.OffsideSettingsForm_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SpatBtn;
        private System.Windows.Forms.Button PotvrditBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox HraciLB;
    }
}