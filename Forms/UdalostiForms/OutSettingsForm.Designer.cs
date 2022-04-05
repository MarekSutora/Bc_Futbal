namespace LGR_Futbal.Forms.UdalostiForms
{
    partial class OutSettingsForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SpatBtn = new System.Windows.Forms.Button();
            this.PotvrditBtn = new System.Windows.Forms.Button();
            this.HraciLB = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(19, 323);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(291, 16);
            this.label2.TabIndex = 572;
            this.label2.Text = "Označte hráča, ktorý vhadzuje loptu z poza čiary";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(18, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 24);
            this.label1.TabIndex = 571;
            this.label1.Text = "Hráči:";
            // 
            // SpatBtn
            // 
            this.SpatBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.SpatBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.SpatBtn.Location = new System.Drawing.Point(238, 361);
            this.SpatBtn.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.SpatBtn.Name = "SpatBtn";
            this.SpatBtn.Size = new System.Drawing.Size(174, 78);
            this.SpatBtn.TabIndex = 569;
            this.SpatBtn.Text = "Návrat späť";
            this.SpatBtn.UseVisualStyleBackColor = false;
            this.SpatBtn.Click += new System.EventHandler(this.SpatBtn_Click);
            // 
            // PotvrditBtn
            // 
            this.PotvrditBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.PotvrditBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PotvrditBtn.Location = new System.Drawing.Point(19, 361);
            this.PotvrditBtn.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.PotvrditBtn.Name = "PotvrditBtn";
            this.PotvrditBtn.Size = new System.Drawing.Size(174, 78);
            this.PotvrditBtn.TabIndex = 568;
            this.PotvrditBtn.Text = "Potvrdiť";
            this.PotvrditBtn.UseVisualStyleBackColor = false;
            this.PotvrditBtn.Click += new System.EventHandler(this.PotvrditBtn_Click);
            // 
            // HraciLB
            // 
            this.HraciLB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.HraciLB.FormattingEnabled = true;
            this.HraciLB.ItemHeight = 20;
            this.HraciLB.Location = new System.Drawing.Point(22, 36);
            this.HraciLB.Name = "HraciLB";
            this.HraciLB.Size = new System.Drawing.Size(390, 284);
            this.HraciLB.TabIndex = 573;
            this.HraciLB.DoubleClick += new System.EventHandler(this.HraciLB_DoubleClick);
            // 
            // OutSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 451);
            this.Controls.Add(this.HraciLB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SpatBtn);
            this.Controls.Add(this.PotvrditBtn);
            this.Name = "OutSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OutSettingsForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OutSettingsForm_FormClosed);
            this.Click += new System.EventHandler(this.OutSettingsForm_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SpatBtn;
        private System.Windows.Forms.Button PotvrditBtn;
        private System.Windows.Forms.ListBox HraciLB;
    }
}