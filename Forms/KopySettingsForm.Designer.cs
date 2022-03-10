namespace LGR_Futbal.Forms
{
    partial class KopySettingsForm
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
            this.rohovyRB = new System.Windows.Forms.RadioButton();
            this.priamyRB = new System.Windows.Forms.RadioButton();
            this.nepriamyRB = new System.Windows.Forms.RadioButton();
            this.pokutovyRB = new System.Windows.Forms.RadioButton();
            this.potvrditButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.hrajuListView = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rohovyRB
            // 
            this.rohovyRB.AutoSize = true;
            this.rohovyRB.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.rohovyRB.Location = new System.Drawing.Point(265, 12);
            this.rohovyRB.Name = "rohovyRB";
            this.rohovyRB.Size = new System.Drawing.Size(128, 28);
            this.rohovyRB.TabIndex = 0;
            this.rohovyRB.TabStop = true;
            this.rohovyRB.Text = "Rohový kop";
            this.rohovyRB.UseVisualStyleBackColor = true;
            // 
            // priamyRB
            // 
            this.priamyRB.AutoSize = true;
            this.priamyRB.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.priamyRB.Location = new System.Drawing.Point(12, 12);
            this.priamyRB.Name = "priamyRB";
            this.priamyRB.Size = new System.Drawing.Size(121, 28);
            this.priamyRB.TabIndex = 1;
            this.priamyRB.TabStop = true;
            this.priamyRB.Text = "Priamy kop";
            this.priamyRB.UseVisualStyleBackColor = true;
            // 
            // nepriamyRB
            // 
            this.nepriamyRB.AutoSize = true;
            this.nepriamyRB.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.nepriamyRB.Location = new System.Drawing.Point(12, 46);
            this.nepriamyRB.Name = "nepriamyRB";
            this.nepriamyRB.Size = new System.Drawing.Size(145, 28);
            this.nepriamyRB.TabIndex = 2;
            this.nepriamyRB.TabStop = true;
            this.nepriamyRB.Text = "Nepriamy kop";
            this.nepriamyRB.UseVisualStyleBackColor = true;
            // 
            // pokutovyRB
            // 
            this.pokutovyRB.AutoSize = true;
            this.pokutovyRB.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.pokutovyRB.Location = new System.Drawing.Point(265, 46);
            this.pokutovyRB.Name = "pokutovyRB";
            this.pokutovyRB.Size = new System.Drawing.Size(140, 28);
            this.pokutovyRB.TabIndex = 3;
            this.pokutovyRB.TabStop = true;
            this.pokutovyRB.Text = "Pokutový kop";
            this.pokutovyRB.UseVisualStyleBackColor = true;
            // 
            // potvrditButton
            // 
            this.potvrditButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.potvrditButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.potvrditButton.Location = new System.Drawing.Point(12, 362);
            this.potvrditButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.potvrditButton.Name = "potvrditButton";
            this.potvrditButton.Size = new System.Drawing.Size(174, 78);
            this.potvrditButton.TabIndex = 555;
            this.potvrditButton.Text = "Potvrdiť";
            this.potvrditButton.UseVisualStyleBackColor = false;
            this.potvrditButton.Click += new System.EventHandler(this.potvrditButton_Click);
            // 
            // backButton
            // 
            this.backButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.backButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.backButton.Location = new System.Drawing.Point(231, 362);
            this.backButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(174, 78);
            this.backButton.TabIndex = 556;
            this.backButton.Text = "Návrat späť";
            this.backButton.UseVisualStyleBackColor = false;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // hrajuListView
            // 
            this.hrajuListView.BackColor = System.Drawing.Color.White;
            this.hrajuListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.hrajuListView.FullRowSelect = true;
            this.hrajuListView.GridLines = true;
            this.hrajuListView.HideSelection = false;
            this.hrajuListView.Location = new System.Drawing.Point(12, 113);
            this.hrajuListView.MultiSelect = false;
            this.hrajuListView.Name = "hrajuListView";
            this.hrajuListView.Size = new System.Drawing.Size(393, 238);
            this.hrajuListView.TabIndex = 557;
            this.hrajuListView.UseCompatibleStateImageBehavior = false;
            this.hrajuListView.View = System.Windows.Forms.View.Details;
            this.hrajuListView.SelectedIndexChanged += new System.EventHandler(this.hrajuListView_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(12, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 24);
            this.label1.TabIndex = 558;
            this.label1.Text = "Hráči:";
            // 
            // KopySettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.hrajuListView);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.potvrditButton);
            this.Controls.Add(this.pokutovyRB);
            this.Controls.Add(this.nepriamyRB);
            this.Controls.Add(this.priamyRB);
            this.Controls.Add(this.rohovyRB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "KopySettingsForm";
            this.Text = "KopySettingsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rohovyRB;
        private System.Windows.Forms.RadioButton priamyRB;
        private System.Windows.Forms.RadioButton nepriamyRB;
        private System.Windows.Forms.RadioButton pokutovyRB;
        private System.Windows.Forms.Button potvrditButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.ListView hrajuListView;
        private System.Windows.Forms.Label label1;
    }
}