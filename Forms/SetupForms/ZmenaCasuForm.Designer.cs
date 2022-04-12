namespace BC_Futbal.Forms
{
    partial class ZmenaCasuForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZmenaCasuForm));
            this.PotvrditBtn = new System.Windows.Forms.Button();
            this.SpatBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.minuta = new System.Windows.Forms.NumericUpDown();
            this.sekunda = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.minuta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sekunda)).BeginInit();
            this.SuspendLayout();
            // 
            // PotvrditBtn
            // 
            this.PotvrditBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.PotvrditBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PotvrditBtn.Location = new System.Drawing.Point(174, 10);
            this.PotvrditBtn.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.PotvrditBtn.Name = "PotvrditBtn";
            this.PotvrditBtn.Size = new System.Drawing.Size(174, 78);
            this.PotvrditBtn.TabIndex = 554;
            this.PotvrditBtn.Text = "Potvrdiť";
            this.PotvrditBtn.UseVisualStyleBackColor = false;
            this.PotvrditBtn.Click += new System.EventHandler(this.PotvrditBtn_Click);
            // 
            // SpatBtn
            // 
            this.SpatBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.SpatBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.SpatBtn.Location = new System.Drawing.Point(174, 93);
            this.SpatBtn.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.SpatBtn.Name = "SpatBtn";
            this.SpatBtn.Size = new System.Drawing.Size(174, 78);
            this.SpatBtn.TabIndex = 553;
            this.SpatBtn.Text = "Návrat späť";
            this.SpatBtn.UseVisualStyleBackColor = false;
            this.SpatBtn.Click += new System.EventHandler(this.SpatBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 20);
            this.label1.TabIndex = 555;
            this.label1.Text = "Minúta:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(12, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 20);
            this.label2.TabIndex = 556;
            this.label2.Text = "Sekunda:";
            // 
            // minuta
            // 
            this.minuta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.minuta.Location = new System.Drawing.Point(95, 12);
            this.minuta.Name = "minuta";
            this.minuta.Size = new System.Drawing.Size(70, 26);
            this.minuta.TabIndex = 557;
            this.minuta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.minuta.ValueChanged += new System.EventHandler(this.Minuta_ValueChanged);
            // 
            // sekunda
            // 
            this.sekunda.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.sekunda.Location = new System.Drawing.Point(95, 44);
            this.sekunda.Name = "sekunda";
            this.sekunda.Size = new System.Drawing.Size(70, 26);
            this.sekunda.TabIndex = 558;
            this.sekunda.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ZmenaCasuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 181);
            this.Controls.Add(this.sekunda);
            this.Controls.Add(this.minuta);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PotvrditBtn);
            this.Controls.Add(this.SpatBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ZmenaCasuForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Zmena aktuálneho času";
            ((System.ComponentModel.ISupportInitialize)(this.minuta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sekunda)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button PotvrditBtn;
        private System.Windows.Forms.Button SpatBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown minuta;
        private System.Windows.Forms.NumericUpDown sekunda;
    }
}