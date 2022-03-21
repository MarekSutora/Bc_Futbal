namespace LGR_Futbal.Forms
{
    partial class HraciKartyForm
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
            this.nahradniciListView = new System.Windows.Forms.ListView();
            this.zrusitButton = new System.Windows.Forms.Button();
            this.aktivovatButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(344, 10);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 20);
            this.label2.TabIndex = 36;
            this.label2.Text = "Náhradníci:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(18, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 20);
            this.label1.TabIndex = 34;
            this.label1.Text = "Základná jedenástka:";
            // 
            // hrajuListView
            // 
            this.hrajuListView.BackColor = System.Drawing.Color.White;
            this.hrajuListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.hrajuListView.FullRowSelect = true;
            this.hrajuListView.GridLines = true;
            this.hrajuListView.HideSelection = false;
            this.hrajuListView.Location = new System.Drawing.Point(29, 33);
            this.hrajuListView.MultiSelect = false;
            this.hrajuListView.Name = "hrajuListView";
            this.hrajuListView.Size = new System.Drawing.Size(313, 387);
            this.hrajuListView.TabIndex = 37;
            this.hrajuListView.UseCompatibleStateImageBehavior = false;
            this.hrajuListView.View = System.Windows.Forms.View.Details;
            this.hrajuListView.SelectedIndexChanged += new System.EventHandler(this.hrajuListView_SelectedIndexChanged);
            // 
            // nahradniciListView
            // 
            this.nahradniciListView.BackColor = System.Drawing.Color.White;
            this.nahradniciListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nahradniciListView.FullRowSelect = true;
            this.nahradniciListView.GridLines = true;
            this.nahradniciListView.HideSelection = false;
            this.nahradniciListView.Location = new System.Drawing.Point(348, 33);
            this.nahradniciListView.MultiSelect = false;
            this.nahradniciListView.Name = "nahradniciListView";
            this.nahradniciListView.Size = new System.Drawing.Size(313, 387);
            this.nahradniciListView.TabIndex = 38;
            this.nahradniciListView.UseCompatibleStateImageBehavior = false;
            this.nahradniciListView.View = System.Windows.Forms.View.Details;
            this.nahradniciListView.SelectedIndexChanged += new System.EventHandler(this.nahradniciListView_SelectedIndexChanged);
            // 
            // zrusitButton
            // 
            this.zrusitButton.Image = global::LGR_Futbal.Properties.Resources.Stop_2;
            this.zrusitButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.zrusitButton.Location = new System.Drawing.Point(680, 64);
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
            this.aktivovatButton.Location = new System.Drawing.Point(680, 9);
            this.aktivovatButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.aktivovatButton.Name = "aktivovatButton";
            this.aktivovatButton.Size = new System.Drawing.Size(107, 52);
            this.aktivovatButton.TabIndex = 29;
            this.aktivovatButton.Text = "Uložiť     \r\nzmeny     ";
            this.aktivovatButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.aktivovatButton.UseVisualStyleBackColor = true;
            this.aktivovatButton.Click += new System.EventHandler(this.aktivovatButton_Click);
            // 
            // HraciKartyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 432);
            this.Controls.Add(this.nahradniciListView);
            this.Controls.Add(this.hrajuListView);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.zrusitButton);
            this.Controls.Add(this.aktivovatButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "HraciKartyForm";
            this.Text = "HraciKartyForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button zrusitButton;
        private System.Windows.Forms.Button aktivovatButton;
        private System.Windows.Forms.ListView hrajuListView;
        private System.Windows.Forms.ListView nahradniciListView;
    }
}