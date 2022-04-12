namespace BC_Futbal.Forms
{
    partial class StriedanieForm
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
            this.components = new System.ComponentModel.Container();
            this.casovac = new System.Windows.Forms.Timer(this.components);
            this.uvodnyPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.nazovLabel = new System.Windows.Forms.Label();
            this.prezentacnyPanel = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menoHraca2Label = new System.Windows.Forms.Label();
            this.cisloHraca2Label = new System.Windows.Forms.Label();
            this.fotka2PictureBox = new System.Windows.Forms.PictureBox();
            this.fotka1PictureBox = new System.Windows.Forms.PictureBox();
            this.cisloHraca1Label = new System.Windows.Forms.Label();
            this.menoHraca1Label = new System.Windows.Forms.Label();
            this.uvodnyPanel.SuspendLayout();
            this.prezentacnyPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fotka2PictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fotka1PictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // casovac
            // 
            this.casovac.Interval = 500;
            this.casovac.Tick += new System.EventHandler(this.Casovac_Tick);
            // 
            // uvodnyPanel
            // 
            this.uvodnyPanel.BackColor = System.Drawing.Color.Black;
            this.uvodnyPanel.Controls.Add(this.label1);
            this.uvodnyPanel.Controls.Add(this.nazovLabel);
            this.uvodnyPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.uvodnyPanel.Location = new System.Drawing.Point(11, 10);
            this.uvodnyPanel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.uvodnyPanel.Name = "uvodnyPanel";
            this.uvodnyPanel.Size = new System.Drawing.Size(459, 273);
            this.uvodnyPanel.TabIndex = 551;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 25.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(-3, 172);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(462, 101);
            this.label1.TabIndex = 547;
            this.label1.Text = "STRIEDANIE";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // nazovLabel
            // 
            this.nazovLabel.Font = new System.Drawing.Font("Arial", 66F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nazovLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.nazovLabel.Location = new System.Drawing.Point(-1, 0);
            this.nazovLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.nazovLabel.Name = "nazovLabel";
            this.nazovLabel.Size = new System.Drawing.Size(462, 172);
            this.nazovLabel.TabIndex = 546;
            this.nazovLabel.Text = "DOMÁCI";
            this.nazovLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // prezentacnyPanel
            // 
            this.prezentacnyPanel.BackColor = System.Drawing.Color.Black;
            this.prezentacnyPanel.Controls.Add(this.pictureBox2);
            this.prezentacnyPanel.Controls.Add(this.pictureBox1);
            this.prezentacnyPanel.Controls.Add(this.menoHraca2Label);
            this.prezentacnyPanel.Controls.Add(this.cisloHraca2Label);
            this.prezentacnyPanel.Controls.Add(this.fotka2PictureBox);
            this.prezentacnyPanel.Controls.Add(this.fotka1PictureBox);
            this.prezentacnyPanel.Controls.Add(this.cisloHraca1Label);
            this.prezentacnyPanel.Controls.Add(this.menoHraca1Label);
            this.prezentacnyPanel.Location = new System.Drawing.Point(11, 10);
            this.prezentacnyPanel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.prezentacnyPanel.Name = "prezentacnyPanel";
            this.prezentacnyPanel.Size = new System.Drawing.Size(460, 273);
            this.prezentacnyPanel.TabIndex = 552;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::BC_Futbal.Properties.Resources.Obrázok4;
            this.pictureBox2.Location = new System.Drawing.Point(6, 144);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(334, 62);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 552;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BC_Futbal.Properties.Resources.Obrázok3;
            this.pictureBox1.Location = new System.Drawing.Point(128, 62);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(329, 62);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 551;
            this.pictureBox1.TabStop = false;
            // 
            // menoHraca2Label
            // 
            this.menoHraca2Label.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.menoHraca2Label.ForeColor = System.Drawing.Color.Lime;
            this.menoHraca2Label.Location = new System.Drawing.Point(85, 209);
            this.menoHraca2Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.menoHraca2Label.Name = "menoHraca2Label";
            this.menoHraca2Label.Size = new System.Drawing.Size(254, 57);
            this.menoHraca2Label.TabIndex = 550;
            this.menoHraca2Label.Text = "DOMÁCI";
            this.menoHraca2Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cisloHraca2Label
            // 
            this.cisloHraca2Label.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cisloHraca2Label.ForeColor = System.Drawing.Color.Yellow;
            this.cisloHraca2Label.Location = new System.Drawing.Point(-5, 209);
            this.cisloHraca2Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.cisloHraca2Label.Name = "cisloHraca2Label";
            this.cisloHraca2Label.Size = new System.Drawing.Size(75, 57);
            this.cisloHraca2Label.TabIndex = 549;
            this.cisloHraca2Label.Text = "XX";
            this.cisloHraca2Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fotka2PictureBox
            // 
            this.fotka2PictureBox.Location = new System.Drawing.Point(344, 144);
            this.fotka2PictureBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.fotka2PictureBox.Name = "fotka2PictureBox";
            this.fotka2PictureBox.Size = new System.Drawing.Size(113, 122);
            this.fotka2PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.fotka2PictureBox.TabIndex = 548;
            this.fotka2PictureBox.TabStop = false;
            // 
            // fotka1PictureBox
            // 
            this.fotka1PictureBox.Location = new System.Drawing.Point(6, 3);
            this.fotka1PictureBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.fotka1PictureBox.Name = "fotka1PictureBox";
            this.fotka1PictureBox.Size = new System.Drawing.Size(113, 122);
            this.fotka1PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.fotka1PictureBox.TabIndex = 547;
            this.fotka1PictureBox.TabStop = false;
            // 
            // cisloHraca1Label
            // 
            this.cisloHraca1Label.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cisloHraca1Label.ForeColor = System.Drawing.Color.Yellow;
            this.cisloHraca1Label.Location = new System.Drawing.Point(123, 3);
            this.cisloHraca1Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.cisloHraca1Label.Name = "cisloHraca1Label";
            this.cisloHraca1Label.Size = new System.Drawing.Size(75, 57);
            this.cisloHraca1Label.TabIndex = 546;
            this.cisloHraca1Label.Text = "XX";
            this.cisloHraca1Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menoHraca1Label
            // 
            this.menoHraca1Label.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.menoHraca1Label.ForeColor = System.Drawing.Color.Red;
            this.menoHraca1Label.Location = new System.Drawing.Point(203, 3);
            this.menoHraca1Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.menoHraca1Label.Name = "menoHraca1Label";
            this.menoHraca1Label.Size = new System.Drawing.Size(254, 57);
            this.menoHraca1Label.TabIndex = 545;
            this.menoHraca1Label.Text = "DOMÁCI";
            this.menoHraca1Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // StriedanieForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(480, 292);
            this.Controls.Add(this.uvodnyPanel);
            this.Controls.Add(this.prezentacnyPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StriedanieForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.StriedanieForm_Load);
            this.uvodnyPanel.ResumeLayout(false);
            this.prezentacnyPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fotka2PictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fotka1PictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer casovac;
        private System.Windows.Forms.Panel uvodnyPanel;
        private System.Windows.Forms.Panel prezentacnyPanel;
        private System.Windows.Forms.PictureBox fotka1PictureBox;
        private System.Windows.Forms.Label cisloHraca1Label;
        private System.Windows.Forms.Label menoHraca1Label;
        private System.Windows.Forms.PictureBox fotka2PictureBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label menoHraca2Label;
        private System.Windows.Forms.Label cisloHraca2Label;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label nazovLabel;
    }
}