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
            this.label2 = new System.Windows.Forms.Label();
            this.rozhodcoviaCheckListBox = new System.Windows.Forms.CheckedListBox();
            this.zrusitButton = new System.Windows.Forms.Button();
            this.aktivovatButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Image = global::LGR_Futbal.Properties.Resources.Spell;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(305, 321);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 52);
            this.button1.TabIndex = 34;
            this.button1.Text = "Označiť   \r\nvšetko    ";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Image = global::LGR_Futbal.Properties.Resources.Stop_2;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(305, 377);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(107, 52);
            this.button2.TabIndex = 33;
            this.button2.Text = "Zrušiť     \r\nvšetko    ";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(9, 19);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 20);
            this.label2.TabIndex = 32;
            this.label2.Text = "Rozhodcovia:";
            // 
            // rozhodcoviaCheckListBox
            // 
            this.rozhodcoviaCheckListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rozhodcoviaCheckListBox.FormattingEnabled = true;
            this.rozhodcoviaCheckListBox.Location = new System.Drawing.Point(12, 52);
            this.rozhodcoviaCheckListBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.rozhodcoviaCheckListBox.Name = "rozhodcoviaCheckListBox";
            this.rozhodcoviaCheckListBox.Size = new System.Drawing.Size(279, 361);
            this.rozhodcoviaCheckListBox.TabIndex = 31;
            // 
            // zrusitButton
            // 
            this.zrusitButton.Image = global::LGR_Futbal.Properties.Resources.Stop_2;
            this.zrusitButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.zrusitButton.Location = new System.Drawing.Point(305, 74);
            this.zrusitButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.zrusitButton.Name = "zrusitButton";
            this.zrusitButton.Size = new System.Drawing.Size(107, 52);
            this.zrusitButton.TabIndex = 30;
            this.zrusitButton.Text = "Zrušiť     ";
            this.zrusitButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.zrusitButton.UseVisualStyleBackColor = true;
            this.zrusitButton.Click += new System.EventHandler(this.zrusitButton_Click);
            // 
            // aktivovatButton
            // 
            this.aktivovatButton.Image = global::LGR_Futbal.Properties.Resources.Forward___Next;
            this.aktivovatButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.aktivovatButton.Location = new System.Drawing.Point(305, 19);
            this.aktivovatButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.aktivovatButton.Name = "aktivovatButton";
            this.aktivovatButton.Size = new System.Drawing.Size(107, 52);
            this.aktivovatButton.TabIndex = 29;
            this.aktivovatButton.Text = "Uložiť     \r\nzmeny     ";
            this.aktivovatButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.aktivovatButton.UseVisualStyleBackColor = true;
            this.aktivovatButton.Click += new System.EventHandler(this.aktivovatButton_Click);
            // 
            // RozhodcoviaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rozhodcoviaCheckListBox);
            this.Controls.Add(this.zrusitButton);
            this.Controls.Add(this.aktivovatButton);
            this.Name = "RozhodcoviaForm";
            this.Text = "RozhodcoviaForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox rozhodcoviaCheckListBox;
        private System.Windows.Forms.Button zrusitButton;
        private System.Windows.Forms.Button aktivovatButton;
    }
}