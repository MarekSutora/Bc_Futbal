namespace LGR_Futbal.Forms
{
    partial class HraciZapasForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HraciZapasForm));
            this.zoznamCheckListBox = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nahradniciCheckListBox = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.OznacitNahradniciBtn = new System.Windows.Forms.Button();
            this.ZrusitNahradniciBtn = new System.Windows.Forms.Button();
            this.ZrusitZakladniBtn = new System.Windows.Forms.Button();
            this.aktivovatButton = new System.Windows.Forms.Button();
            this.OznacitZakladniBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // zoznamCheckListBox
            // 
            this.zoznamCheckListBox.CheckOnClick = true;
            this.zoznamCheckListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.zoznamCheckListBox.FormattingEnabled = true;
            this.zoznamCheckListBox.Location = new System.Drawing.Point(8, 42);
            this.zoznamCheckListBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.zoznamCheckListBox.Name = "zoznamCheckListBox";
            this.zoznamCheckListBox.Size = new System.Drawing.Size(279, 361);
            this.zoznamCheckListBox.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(5, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 20);
            this.label1.TabIndex = 24;
            this.label1.Text = "Základná jedenástka:";
            // 
            // nahradniciCheckListBox
            // 
            this.nahradniciCheckListBox.CheckOnClick = true;
            this.nahradniciCheckListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nahradniciCheckListBox.FormattingEnabled = true;
            this.nahradniciCheckListBox.Location = new System.Drawing.Point(401, 42);
            this.nahradniciCheckListBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.nahradniciCheckListBox.Name = "nahradniciCheckListBox";
            this.nahradniciCheckListBox.Size = new System.Drawing.Size(279, 361);
            this.nahradniciCheckListBox.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(398, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 20);
            this.label2.TabIndex = 26;
            this.label2.Text = "Náhradníci:";
            // 
            // OznacitNahradniciBtn
            // 
            this.OznacitNahradniciBtn.Image = global::LGR_Futbal.Properties.Resources.Spell;
            this.OznacitNahradniciBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.OznacitNahradniciBtn.Location = new System.Drawing.Point(694, 311);
            this.OznacitNahradniciBtn.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.OznacitNahradniciBtn.Name = "OznacitNahradniciBtn";
            this.OznacitNahradniciBtn.Size = new System.Drawing.Size(107, 52);
            this.OznacitNahradniciBtn.TabIndex = 28;
            this.OznacitNahradniciBtn.Text = "Označiť   \r\nvšetko    ";
            this.OznacitNahradniciBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.OznacitNahradniciBtn.UseVisualStyleBackColor = true;
            this.OznacitNahradniciBtn.Click += new System.EventHandler(this.OznacitNahradniciBtn_Click);
            // 
            // ZrusitNahradniciBtn
            // 
            this.ZrusitNahradniciBtn.Image = global::LGR_Futbal.Properties.Resources.Stop_2;
            this.ZrusitNahradniciBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ZrusitNahradniciBtn.Location = new System.Drawing.Point(694, 367);
            this.ZrusitNahradniciBtn.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.ZrusitNahradniciBtn.Name = "ZrusitNahradniciBtn";
            this.ZrusitNahradniciBtn.Size = new System.Drawing.Size(107, 52);
            this.ZrusitNahradniciBtn.TabIndex = 27;
            this.ZrusitNahradniciBtn.Text = "Zrušiť     \r\nvšetko    ";
            this.ZrusitNahradniciBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ZrusitNahradniciBtn.UseVisualStyleBackColor = true;
            this.ZrusitNahradniciBtn.Click += new System.EventHandler(this.ZrusitNahradniciBtn_Click);
            // 
            // ZrusitZakladniBtn
            // 
            this.ZrusitZakladniBtn.Image = global::LGR_Futbal.Properties.Resources.Stop_2;
            this.ZrusitZakladniBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ZrusitZakladniBtn.Location = new System.Drawing.Point(291, 367);
            this.ZrusitZakladniBtn.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.ZrusitZakladniBtn.Name = "ZrusitZakladniBtn";
            this.ZrusitZakladniBtn.Size = new System.Drawing.Size(107, 52);
            this.ZrusitZakladniBtn.TabIndex = 22;
            this.ZrusitZakladniBtn.Text = "Zrušiť     \r\nvšetko    ";
            this.ZrusitZakladniBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ZrusitZakladniBtn.UseVisualStyleBackColor = true;
            this.ZrusitZakladniBtn.Click += new System.EventHandler(this.ZrusitZakladniBtn_Click);
            // 
            // aktivovatButton
            // 
            this.aktivovatButton.Image = global::LGR_Futbal.Properties.Resources.Forward___Next;
            this.aktivovatButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.aktivovatButton.Location = new System.Drawing.Point(694, 9);
            this.aktivovatButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.aktivovatButton.Name = "aktivovatButton";
            this.aktivovatButton.Size = new System.Drawing.Size(107, 52);
            this.aktivovatButton.TabIndex = 19;
            this.aktivovatButton.Text = "Uložiť     \r\nzmeny     ";
            this.aktivovatButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.aktivovatButton.UseVisualStyleBackColor = true;
            this.aktivovatButton.Click += new System.EventHandler(this.AktivovatButton_Click);
            // 
            // OznacitZakladniBtn
            // 
            this.OznacitZakladniBtn.Image = global::LGR_Futbal.Properties.Resources.Spell;
            this.OznacitZakladniBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.OznacitZakladniBtn.Location = new System.Drawing.Point(291, 311);
            this.OznacitZakladniBtn.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.OznacitZakladniBtn.Name = "OznacitZakladniBtn";
            this.OznacitZakladniBtn.Size = new System.Drawing.Size(107, 52);
            this.OznacitZakladniBtn.TabIndex = 23;
            this.OznacitZakladniBtn.Text = "Označiť   \r\nvšetko    ";
            this.OznacitZakladniBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.OznacitZakladniBtn.UseVisualStyleBackColor = true;
            this.OznacitZakladniBtn.Click += new System.EventHandler(this.OznacitZakladniBtn_Click);
            // 
            // HraciZapasForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 432);
            this.Controls.Add(this.OznacitNahradniciBtn);
            this.Controls.Add(this.ZrusitNahradniciBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nahradniciCheckListBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OznacitZakladniBtn);
            this.Controls.Add(this.ZrusitZakladniBtn);
            this.Controls.Add(this.zoznamCheckListBox);
            this.Controls.Add(this.aktivovatButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HraciZapasForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Výber hráčov na zápas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button aktivovatButton;
        private System.Windows.Forms.CheckedListBox zoznamCheckListBox;
        private System.Windows.Forms.Button ZrusitZakladniBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox nahradniciCheckListBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button OznacitNahradniciBtn;
        private System.Windows.Forms.Button ZrusitNahradniciBtn;
        private System.Windows.Forms.Button OznacitZakladniBtn;
    }
}