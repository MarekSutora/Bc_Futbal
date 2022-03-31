namespace LGR_Futbal.Forms
{
    partial class TimyForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimyForm));
            this.hostiaLabel = new System.Windows.Forms.Label();
            this.domaciLabel = new System.Windows.Forms.Label();
            this.AktivovatBtn = new System.Windows.Forms.Button();
            this.domaciLB = new System.Windows.Forms.ListBox();
            this.hostiaLB = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // hostiaLabel
            // 
            this.hostiaLabel.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.hostiaLabel.ForeColor = System.Drawing.Color.Black;
            this.hostiaLabel.Location = new System.Drawing.Point(332, 22);
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
            this.domaciLabel.Location = new System.Drawing.Point(51, 22);
            this.domaciLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.domaciLabel.Name = "domaciLabel";
            this.domaciLabel.Size = new System.Drawing.Size(227, 37);
            this.domaciLabel.TabIndex = 543;
            this.domaciLabel.Text = "DOMÁCI";
            this.domaciLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AktivovatBtn
            // 
            this.AktivovatBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.AktivovatBtn.Image = global::LGR_Futbal.Properties.Resources.Forward___Next;
            this.AktivovatBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AktivovatBtn.Location = new System.Drawing.Point(588, 61);
            this.AktivovatBtn.Margin = new System.Windows.Forms.Padding(2);
            this.AktivovatBtn.Name = "AktivovatBtn";
            this.AktivovatBtn.Size = new System.Drawing.Size(109, 60);
            this.AktivovatBtn.TabIndex = 545;
            this.AktivovatBtn.Text = "   Vybrať    tímy  ";
            this.AktivovatBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.AktivovatBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.AktivovatBtn.UseVisualStyleBackColor = true;
            this.AktivovatBtn.Click += new System.EventHandler(this.AktivovatBtn_Click);
            // 
            // domaciLB
            // 
            this.domaciLB.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.domaciLB.FormattingEnabled = true;
            this.domaciLB.ItemHeight = 26;
            this.domaciLB.Location = new System.Drawing.Point(14, 61);
            this.domaciLB.Margin = new System.Windows.Forms.Padding(2);
            this.domaciLB.Name = "domaciLB";
            this.domaciLB.Size = new System.Drawing.Size(280, 342);
            this.domaciLB.TabIndex = 547;
            // 
            // hostiaLB
            // 
            this.hostiaLB.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.hostiaLB.FormattingEnabled = true;
            this.hostiaLB.ItemHeight = 26;
            this.hostiaLB.Location = new System.Drawing.Point(304, 61);
            this.hostiaLB.Margin = new System.Windows.Forms.Padding(2);
            this.hostiaLB.Name = "hostiaLB";
            this.hostiaLB.Size = new System.Drawing.Size(280, 342);
            this.hostiaLB.TabIndex = 548;
            // 
            // TimyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 417);
            this.Controls.Add(this.hostiaLB);
            this.Controls.Add(this.domaciLB);
            this.Controls.Add(this.AktivovatBtn);
            this.Controls.Add(this.hostiaLabel);
            this.Controls.Add(this.domaciLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TimyForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Výber tímov z databázy";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label hostiaLabel;
        private System.Windows.Forms.Label domaciLabel;
        private System.Windows.Forms.Button AktivovatBtn;
        private System.Windows.Forms.ListBox domaciLB;
        private System.Windows.Forms.ListBox hostiaLB;
    }
}