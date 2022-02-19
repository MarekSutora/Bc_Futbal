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
            this.oznacitVsetkoButton = new System.Windows.Forms.Button();
            this.zrusOznaceniaButton = new System.Windows.Forms.Button();
            this.zrusitButton = new System.Windows.Forms.Button();
            this.aktivovatButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.nahradniciCheckListBox = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // zoznamCheckListBox
            // 
            this.zoznamCheckListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.zoznamCheckListBox.FormattingEnabled = true;
            this.zoznamCheckListBox.Location = new System.Drawing.Point(8, 42);
            this.zoznamCheckListBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.zoznamCheckListBox.Name = "zoznamCheckListBox";
            this.zoznamCheckListBox.Size = new System.Drawing.Size(279, 361);
            this.zoznamCheckListBox.TabIndex = 21;
            // 
            // oznacitVsetkoButton
            // 
            this.oznacitVsetkoButton.Image = global::LGR_Futbal.Properties.Resources.Spell;
            this.oznacitVsetkoButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.oznacitVsetkoButton.Location = new System.Drawing.Point(291, 311);
            this.oznacitVsetkoButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.oznacitVsetkoButton.Name = "oznacitVsetkoButton";
            this.oznacitVsetkoButton.Size = new System.Drawing.Size(107, 52);
            this.oznacitVsetkoButton.TabIndex = 23;
            this.oznacitVsetkoButton.Text = "Označiť   \r\nvšetko    ";
            this.oznacitVsetkoButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.oznacitVsetkoButton.UseVisualStyleBackColor = true;
            this.oznacitVsetkoButton.Click += new System.EventHandler(this.OznacitVsetkoButton_Click);
            // 
            // zrusOznaceniaButton
            // 
            this.zrusOznaceniaButton.Image = global::LGR_Futbal.Properties.Resources.Stop_2;
            this.zrusOznaceniaButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.zrusOznaceniaButton.Location = new System.Drawing.Point(291, 367);
            this.zrusOznaceniaButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.zrusOznaceniaButton.Name = "zrusOznaceniaButton";
            this.zrusOznaceniaButton.Size = new System.Drawing.Size(107, 52);
            this.zrusOznaceniaButton.TabIndex = 22;
            this.zrusOznaceniaButton.Text = "Zrušiť     \r\nvšetko    ";
            this.zrusOznaceniaButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.zrusOznaceniaButton.UseVisualStyleBackColor = true;
            this.zrusOznaceniaButton.Click += new System.EventHandler(this.ZrusOznaceniaButton_Click);
            // 
            // zrusitButton
            // 
            this.zrusitButton.Image = global::LGR_Futbal.Properties.Resources.Stop_2;
            this.zrusitButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.zrusitButton.Location = new System.Drawing.Point(694, 64);
            this.zrusitButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.zrusitButton.Name = "zrusitButton";
            this.zrusitButton.Size = new System.Drawing.Size(107, 52);
            this.zrusitButton.TabIndex = 20;
            this.zrusitButton.Text = "Zrušiť     ";
            this.zrusitButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.zrusitButton.UseVisualStyleBackColor = true;
            this.zrusitButton.Click += new System.EventHandler(this.ZrusitButton_Click);
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
            // button1
            // 
            this.button1.Image = global::LGR_Futbal.Properties.Resources.Spell;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(694, 311);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 52);
            this.button1.TabIndex = 28;
            this.button1.Text = "Označiť   \r\nvšetko    ";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Image = global::LGR_Futbal.Properties.Resources.Stop_2;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(694, 367);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(107, 52);
            this.button2.TabIndex = 27;
            this.button2.Text = "Zrušiť     \r\nvšetko    ";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // HraciZapasForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 432);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nahradniciCheckListBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.oznacitVsetkoButton);
            this.Controls.Add(this.zrusOznaceniaButton);
            this.Controls.Add(this.zoznamCheckListBox);
            this.Controls.Add(this.zrusitButton);
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
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HraciZapasForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button zrusitButton;
        private System.Windows.Forms.Button aktivovatButton;
        private System.Windows.Forms.CheckedListBox zoznamCheckListBox;
        private System.Windows.Forms.Button zrusOznaceniaButton;
        private System.Windows.Forms.Button oznacitVsetkoButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox nahradniciCheckListBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}