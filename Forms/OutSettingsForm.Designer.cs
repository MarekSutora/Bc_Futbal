namespace LGR_Futbal.Forms
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
            this.hrajuListView = new System.Windows.Forms.ListView();
            this.backButton = new System.Windows.Forms.Button();
            this.potvrditButton = new System.Windows.Forms.Button();
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
            // hrajuListView
            // 
            this.hrajuListView.BackColor = System.Drawing.Color.White;
            this.hrajuListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.hrajuListView.FullRowSelect = true;
            this.hrajuListView.GridLines = true;
            this.hrajuListView.HideSelection = false;
            this.hrajuListView.Location = new System.Drawing.Point(19, 35);
            this.hrajuListView.MultiSelect = false;
            this.hrajuListView.Name = "hrajuListView";
            this.hrajuListView.Size = new System.Drawing.Size(393, 285);
            this.hrajuListView.TabIndex = 570;
            this.hrajuListView.UseCompatibleStateImageBehavior = false;
            this.hrajuListView.View = System.Windows.Forms.View.Details;
            this.hrajuListView.SelectedIndexChanged += new System.EventHandler(this.hrajuListView_SelectedIndexChanged);
            this.hrajuListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.hrajuListView_MouseDoubleClick);
            // 
            // backButton
            // 
            this.backButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.backButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.backButton.Location = new System.Drawing.Point(238, 361);
            this.backButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(174, 78);
            this.backButton.TabIndex = 569;
            this.backButton.Text = "Návrat späť";
            this.backButton.UseVisualStyleBackColor = false;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // potvrditButton
            // 
            this.potvrditButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.potvrditButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.potvrditButton.Location = new System.Drawing.Point(19, 361);
            this.potvrditButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.potvrditButton.Name = "potvrditButton";
            this.potvrditButton.Size = new System.Drawing.Size(174, 78);
            this.potvrditButton.TabIndex = 568;
            this.potvrditButton.Text = "Potvrdiť";
            this.potvrditButton.UseVisualStyleBackColor = false;
            this.potvrditButton.Click += new System.EventHandler(this.potvrditButton_Click);
            // 
            // OutSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 451);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.hrajuListView);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.potvrditButton);
            this.Name = "OutSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OutSettingsForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OutSettingsForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView hrajuListView;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button potvrditButton;
    }
}