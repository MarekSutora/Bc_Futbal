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
            this.zakladCheckListBox = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nahradniciCheckListBox = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.OznacitNahradniciBtn = new System.Windows.Forms.Button();
            this.ZrusitNahradniciBtn = new System.Windows.Forms.Button();
            this.ZrusitZakladBtn = new System.Windows.Forms.Button();
            this.AktivovatBtn = new System.Windows.Forms.Button();
            this.OznacitZakladBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // zakladCheckListBox
            // 
            this.zakladCheckListBox.CheckOnClick = true;
            this.zakladCheckListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.zakladCheckListBox.FormattingEnabled = true;
            this.zakladCheckListBox.Location = new System.Drawing.Point(8, 42);
            this.zakladCheckListBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.zakladCheckListBox.Name = "zakladCheckListBox";
            this.zakladCheckListBox.Size = new System.Drawing.Size(279, 361);
            this.zakladCheckListBox.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(4, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 24);
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
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(397, 15);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 24);
            this.label2.TabIndex = 26;
            this.label2.Text = "Náhradníci:";
            // 
            // OznacitNahradniciBtn
            // 
            this.OznacitNahradniciBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.OznacitNahradniciBtn.Image = global::LGR_Futbal.Properties.Resources.Spell;
            this.OznacitNahradniciBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.OznacitNahradniciBtn.Location = new System.Drawing.Point(684, 295);
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
            this.ZrusitNahradniciBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ZrusitNahradniciBtn.Image = global::LGR_Futbal.Properties.Resources.Stop_2;
            this.ZrusitNahradniciBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ZrusitNahradniciBtn.Location = new System.Drawing.Point(684, 351);
            this.ZrusitNahradniciBtn.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.ZrusitNahradniciBtn.Name = "ZrusitNahradniciBtn";
            this.ZrusitNahradniciBtn.Size = new System.Drawing.Size(107, 52);
            this.ZrusitNahradniciBtn.TabIndex = 27;
            this.ZrusitNahradniciBtn.Text = "Zrušiť     \r\nvšetko    ";
            this.ZrusitNahradniciBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ZrusitNahradniciBtn.UseVisualStyleBackColor = true;
            this.ZrusitNahradniciBtn.Click += new System.EventHandler(this.ZrusitNahradniciBtn_Click);
            // 
            // ZrusitZakladBtn
            // 
            this.ZrusitZakladBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ZrusitZakladBtn.Image = global::LGR_Futbal.Properties.Resources.Stop_2;
            this.ZrusitZakladBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ZrusitZakladBtn.Location = new System.Drawing.Point(291, 351);
            this.ZrusitZakladBtn.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.ZrusitZakladBtn.Name = "ZrusitZakladBtn";
            this.ZrusitZakladBtn.Size = new System.Drawing.Size(107, 52);
            this.ZrusitZakladBtn.TabIndex = 22;
            this.ZrusitZakladBtn.Text = "Zrušiť     \r\nvšetko    ";
            this.ZrusitZakladBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ZrusitZakladBtn.UseVisualStyleBackColor = true;
            this.ZrusitZakladBtn.Click += new System.EventHandler(this.ZrusitZakladBtn_Click);
            // 
            // AktivovatBtn
            // 
            this.AktivovatBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.AktivovatBtn.Image = global::LGR_Futbal.Properties.Resources.Forward___Next;
            this.AktivovatBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AktivovatBtn.Location = new System.Drawing.Point(684, 42);
            this.AktivovatBtn.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.AktivovatBtn.Name = "AktivovatBtn";
            this.AktivovatBtn.Size = new System.Drawing.Size(107, 52);
            this.AktivovatBtn.TabIndex = 19;
            this.AktivovatBtn.Text = "  Uložiť      zmeny     ";
            this.AktivovatBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.AktivovatBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.AktivovatBtn.UseVisualStyleBackColor = true;
            this.AktivovatBtn.Click += new System.EventHandler(this.AktivovatBtn_Click);
            // 
            // OznacitZakladBtn
            // 
            this.OznacitZakladBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.OznacitZakladBtn.Image = global::LGR_Futbal.Properties.Resources.Spell;
            this.OznacitZakladBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.OznacitZakladBtn.Location = new System.Drawing.Point(291, 295);
            this.OznacitZakladBtn.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.OznacitZakladBtn.Name = "OznacitZakladBtn";
            this.OznacitZakladBtn.Size = new System.Drawing.Size(107, 52);
            this.OznacitZakladBtn.TabIndex = 23;
            this.OznacitZakladBtn.Text = "Označiť   \r\nvšetko    ";
            this.OznacitZakladBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.OznacitZakladBtn.UseVisualStyleBackColor = true;
            this.OznacitZakladBtn.Click += new System.EventHandler(this.OznacitZakladBtn_Click);
            // 
            // HraciZapasForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 411);
            this.Controls.Add(this.OznacitNahradniciBtn);
            this.Controls.Add(this.ZrusitNahradniciBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nahradniciCheckListBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OznacitZakladBtn);
            this.Controls.Add(this.ZrusitZakladBtn);
            this.Controls.Add(this.zakladCheckListBox);
            this.Controls.Add(this.AktivovatBtn);
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
        private System.Windows.Forms.Button AktivovatBtn;
        private System.Windows.Forms.CheckedListBox zakladCheckListBox;
        private System.Windows.Forms.Button ZrusitZakladBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox nahradniciCheckListBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button OznacitNahradniciBtn;
        private System.Windows.Forms.Button ZrusitNahradniciBtn;
        private System.Windows.Forms.Button OznacitZakladBtn;
    }
}