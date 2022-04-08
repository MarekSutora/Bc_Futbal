namespace LGR_Futbal.Forms
{
    partial class RozhodcoviaForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.rozhodcoviaLabel = new System.Windows.Forms.Label();
            this.rozhodcoviaCheckListBox = new System.Windows.Forms.CheckedListBox();
            this.AktivovatBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.Image = global::LGR_Futbal.Properties.Resources.Spell;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(296, 198);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 52);
            this.button1.TabIndex = 34;
            this.button1.Text = "Označiť   \r\nvšetko    ";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.OznacitVsetkoBtn_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button2.Image = global::LGR_Futbal.Properties.Resources.Stop_2;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(296, 258);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(107, 52);
            this.button2.TabIndex = 33;
            this.button2.Text = "Zrušiť     \r\nvšetko    ";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.ZrusitVsetkoBtn_Click);
            // 
            // rozhodcoviaLabel
            // 
            this.rozhodcoviaLabel.AutoSize = true;
            this.rozhodcoviaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rozhodcoviaLabel.Location = new System.Drawing.Point(8, 9);
            this.rozhodcoviaLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.rozhodcoviaLabel.Name = "rozhodcoviaLabel";
            this.rozhodcoviaLabel.Size = new System.Drawing.Size(105, 20);
            this.rozhodcoviaLabel.TabIndex = 32;
            this.rozhodcoviaLabel.Text = "Rozhodcovia:";
            // 
            // rozhodcoviaCheckListBox
            // 
            this.rozhodcoviaCheckListBox.CheckOnClick = true;
            this.rozhodcoviaCheckListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rozhodcoviaCheckListBox.FormattingEnabled = true;
            this.rozhodcoviaCheckListBox.Location = new System.Drawing.Point(12, 32);
            this.rozhodcoviaCheckListBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.rozhodcoviaCheckListBox.Name = "rozhodcoviaCheckListBox";
            this.rozhodcoviaCheckListBox.Size = new System.Drawing.Size(279, 277);
            this.rozhodcoviaCheckListBox.TabIndex = 31;
            // 
            // AktivovatBtn
            // 
            this.AktivovatBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.AktivovatBtn.Image = global::LGR_Futbal.Properties.Resources.Forward___Next;
            this.AktivovatBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AktivovatBtn.Location = new System.Drawing.Point(296, 32);
            this.AktivovatBtn.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.AktivovatBtn.Name = "AktivovatBtn";
            this.AktivovatBtn.Size = new System.Drawing.Size(107, 52);
            this.AktivovatBtn.TabIndex = 29;
            this.AktivovatBtn.Text = "Uložiť      \nzmeny     ";
            this.AktivovatBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.AktivovatBtn.UseVisualStyleBackColor = true;
            this.AktivovatBtn.Click += new System.EventHandler(this.AktivovatBtn_Click);
            // 
            // RozhodcoviaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 317);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.rozhodcoviaLabel);
            this.Controls.Add(this.rozhodcoviaCheckListBox);
            this.Controls.Add(this.AktivovatBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RozhodcoviaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RozhodcoviaForm";
            this.Load += new System.EventHandler(this.RozhodcoviaForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label rozhodcoviaLabel;
        private System.Windows.Forms.CheckedListBox rozhodcoviaCheckListBox;
        private System.Windows.Forms.Button AktivovatBtn;
    }
}