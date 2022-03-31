namespace LGR_Futbal.Forms
{
    partial class TypZapasuForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TypZapasuForm));
            this.PridatTypBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nazovTextBox = new System.Windows.Forms.TextBox();
            this.minutyNum = new System.Windows.Forms.NumericUpDown();
            this.prerCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.minutyNum)).BeginInit();
            this.SuspendLayout();
            // 
            // PridatTypBtn
            // 
            this.PridatTypBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PridatTypBtn.Image = global::LGR_Futbal.Properties.Resources.Forward___Next;
            this.PridatTypBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.PridatTypBtn.Location = new System.Drawing.Point(365, 12);
            this.PridatTypBtn.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.PridatTypBtn.Name = "PridatTypBtn";
            this.PridatTypBtn.Size = new System.Drawing.Size(109, 46);
            this.PridatTypBtn.TabIndex = 547;
            this.PridatTypBtn.Text = "  Pridať";
            this.PridatTypBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.PridatTypBtn.UseVisualStyleBackColor = true;
            this.PridatTypBtn.Click += new System.EventHandler(this.PridatTypBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(8, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 18);
            this.label1.TabIndex = 549;
            this.label1.Text = "Názov:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(8, 49);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 18);
            this.label2.TabIndex = 550;
            this.label2.Text = "Dĺžka polčasu [min]:";
            // 
            // nazovTextBox
            // 
            this.nazovTextBox.Location = new System.Drawing.Point(67, 12);
            this.nazovTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.nazovTextBox.Name = "nazovTextBox";
            this.nazovTextBox.Size = new System.Drawing.Size(294, 20);
            this.nazovTextBox.TabIndex = 552;
            // 
            // minutyNum
            // 
            this.minutyNum.Location = new System.Drawing.Point(154, 49);
            this.minutyNum.Margin = new System.Windows.Forms.Padding(2);
            this.minutyNum.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.minutyNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.minutyNum.Name = "minutyNum";
            this.minutyNum.Size = new System.Drawing.Size(57, 20);
            this.minutyNum.TabIndex = 553;
            this.minutyNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.minutyNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // prerCheckBox
            // 
            this.prerCheckBox.AutoSize = true;
            this.prerCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.prerCheckBox.Location = new System.Drawing.Point(215, 48);
            this.prerCheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.prerCheckBox.Name = "prerCheckBox";
            this.prerCheckBox.Size = new System.Drawing.Size(146, 22);
            this.prerCheckBox.TabIndex = 554;
            this.prerCheckBox.Text = "Povoliť prerušenie";
            this.prerCheckBox.UseVisualStyleBackColor = true;
            // 
            // TypZapasuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 86);
            this.Controls.Add(this.prerCheckBox);
            this.Controls.Add(this.minutyNum);
            this.Controls.Add(this.nazovTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PridatTypBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TypZapasuForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nový typ zápasu";
            ((System.ComponentModel.ISupportInitialize)(this.minutyNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button PridatTypBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nazovTextBox;
        private System.Windows.Forms.NumericUpDown minutyNum;
        private System.Windows.Forms.CheckBox prerCheckBox;
    }
}