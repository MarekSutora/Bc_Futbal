namespace LGR_Futbal.Forms
{
    partial class SelectForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectForm));
            this.hostiaLabel = new System.Windows.Forms.Label();
            this.domaciLabel = new System.Windows.Forms.Label();
            this.zrusitButton = new System.Windows.Forms.Button();
            this.aktivovatButton = new System.Windows.Forms.Button();
            this.domaciLB = new System.Windows.Forms.ListBox();
            this.hostiaLB = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // hostiaLabel
            // 
            this.hostiaLabel.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.hostiaLabel.ForeColor = System.Drawing.Color.Black;
            this.hostiaLabel.Location = new System.Drawing.Point(298, 7);
            this.hostiaLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.hostiaLabel.Name = "hostiaLabel";
            this.hostiaLabel.Size = new System.Drawing.Size(227, 37);
            this.hostiaLabel.TabIndex = 544;
            this.hostiaLabel.Text = "HOSTIA";
            this.hostiaLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // domaciLabel
            // 
            this.domaciLabel.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.domaciLabel.ForeColor = System.Drawing.Color.Black;
            this.domaciLabel.Location = new System.Drawing.Point(14, 7);
            this.domaciLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.domaciLabel.Name = "domaciLabel";
            this.domaciLabel.Size = new System.Drawing.Size(227, 37);
            this.domaciLabel.TabIndex = 543;
            this.domaciLabel.Text = "DOMÁCI";
            this.domaciLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // zrusitButton
            // 
            this.zrusitButton.Image = global::LGR_Futbal.Properties.Resources.Stop_2;
            this.zrusitButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.zrusitButton.Location = new System.Drawing.Point(529, 61);
            this.zrusitButton.Margin = new System.Windows.Forms.Padding(2);
            this.zrusitButton.Name = "zrusitButton";
            this.zrusitButton.Size = new System.Drawing.Size(109, 52);
            this.zrusitButton.TabIndex = 546;
            this.zrusitButton.Text = "Zrušiť     ";
            this.zrusitButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.zrusitButton.UseVisualStyleBackColor = true;
            this.zrusitButton.Click += new System.EventHandler(this.ZrusitButton_Click);
            // 
            // aktivovatButton
            // 
            this.aktivovatButton.Image = global::LGR_Futbal.Properties.Resources.Forward___Next;
            this.aktivovatButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.aktivovatButton.Location = new System.Drawing.Point(529, 6);
            this.aktivovatButton.Margin = new System.Windows.Forms.Padding(2);
            this.aktivovatButton.Name = "aktivovatButton";
            this.aktivovatButton.Size = new System.Drawing.Size(109, 52);
            this.aktivovatButton.TabIndex = 545;
            this.aktivovatButton.Text = "Vybrať    ";
            this.aktivovatButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.aktivovatButton.UseVisualStyleBackColor = true;
            this.aktivovatButton.Click += new System.EventHandler(this.AktivovatButton_Click);
            // 
            // domaciLB
            // 
            this.domaciLB.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.domaciLB.FormattingEnabled = true;
            this.domaciLB.ItemHeight = 26;
            this.domaciLB.Location = new System.Drawing.Point(14, 61);
            this.domaciLB.Margin = new System.Windows.Forms.Padding(2);
            this.domaciLB.Name = "domaciLB";
            this.domaciLB.Size = new System.Drawing.Size(227, 342);
            this.domaciLB.TabIndex = 547;
            // 
            // hostiaLB
            // 
            this.hostiaLB.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.hostiaLB.FormattingEnabled = true;
            this.hostiaLB.ItemHeight = 26;
            this.hostiaLB.Location = new System.Drawing.Point(298, 61);
            this.hostiaLB.Margin = new System.Windows.Forms.Padding(2);
            this.hostiaLB.Name = "hostiaLB";
            this.hostiaLB.Size = new System.Drawing.Size(227, 342);
            this.hostiaLB.TabIndex = 548;
            // 
            // SelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 431);
            this.Controls.Add(this.hostiaLB);
            this.Controls.Add(this.domaciLB);
            this.Controls.Add(this.zrusitButton);
            this.Controls.Add(this.aktivovatButton);
            this.Controls.Add(this.hostiaLabel);
            this.Controls.Add(this.domaciLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Výber tímov z databázy";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectForm_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label hostiaLabel;
        private System.Windows.Forms.Label domaciLabel;
        private System.Windows.Forms.Button zrusitButton;
        private System.Windows.Forms.Button aktivovatButton;
        private System.Windows.Forms.ListBox domaciLB;
        private System.Windows.Forms.ListBox hostiaLB;
    }
}