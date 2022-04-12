namespace BC_Futbal.Forms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HraciKartyForm));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.HrajuciListView = new System.Windows.Forms.ListView();
            this.NahradniciListView = new System.Windows.Forms.ListView();
            this.UlozitBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(330, 9);
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
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 20);
            this.label1.TabIndex = 34;
            this.label1.Text = "Základná jedenástka:";
            // 
            // HrajuciListView
            // 
            this.HrajuciListView.BackColor = System.Drawing.Color.White;
            this.HrajuciListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.HrajuciListView.FullRowSelect = true;
            this.HrajuciListView.GridLines = true;
            this.HrajuciListView.HideSelection = false;
            this.HrajuciListView.Location = new System.Drawing.Point(15, 32);
            this.HrajuciListView.MultiSelect = false;
            this.HrajuciListView.Name = "HrajuciListView";
            this.HrajuciListView.Size = new System.Drawing.Size(313, 387);
            this.HrajuciListView.TabIndex = 37;
            this.HrajuciListView.UseCompatibleStateImageBehavior = false;
            this.HrajuciListView.View = System.Windows.Forms.View.Details;
            this.HrajuciListView.SelectedIndexChanged += new System.EventHandler(this.HrajuciListView_SelectedIndexChanged);
            // 
            // NahradniciListView
            // 
            this.NahradniciListView.BackColor = System.Drawing.Color.White;
            this.NahradniciListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.NahradniciListView.FullRowSelect = true;
            this.NahradniciListView.GridLines = true;
            this.NahradniciListView.HideSelection = false;
            this.NahradniciListView.Location = new System.Drawing.Point(334, 32);
            this.NahradniciListView.MultiSelect = false;
            this.NahradniciListView.Name = "NahradniciListView";
            this.NahradniciListView.Size = new System.Drawing.Size(313, 387);
            this.NahradniciListView.TabIndex = 38;
            this.NahradniciListView.UseCompatibleStateImageBehavior = false;
            this.NahradniciListView.View = System.Windows.Forms.View.Details;
            this.NahradniciListView.SelectedIndexChanged += new System.EventHandler(this.NahradniciListView_SelectedIndexChanged);
            // 
            // UlozitBtn
            // 
            this.UlozitBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UlozitBtn.Image = global::BC_Futbal.Properties.Resources.Forward___Next;
            this.UlozitBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.UlozitBtn.Location = new System.Drawing.Point(652, 32);
            this.UlozitBtn.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.UlozitBtn.Name = "UlozitBtn";
            this.UlozitBtn.Size = new System.Drawing.Size(115, 52);
            this.UlozitBtn.TabIndex = 29;
            this.UlozitBtn.Text = " Uložiť      zmeny     ";
            this.UlozitBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.UlozitBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.UlozitBtn.UseVisualStyleBackColor = true;
            this.UlozitBtn.Click += new System.EventHandler(this.UlozitBtn_Click);
            // 
            // HraciKartyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 426);
            this.Controls.Add(this.NahradniciListView);
            this.Controls.Add(this.HrajuciListView);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UlozitBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HraciKartyForm";
            this.Text = "HraciKartyForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button UlozitBtn;
        private System.Windows.Forms.ListView HrajuciListView;
        private System.Windows.Forms.ListView NahradniciListView;
    }
}