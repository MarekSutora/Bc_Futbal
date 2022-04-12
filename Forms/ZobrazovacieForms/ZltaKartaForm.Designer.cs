namespace BC_Futbal.Forms
{
    partial class ZltaKartaForm
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
            this.prezentacnyPanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.fotkaPictureBox = new System.Windows.Forms.PictureBox();
            this.cisloHracaLabel = new System.Windows.Forms.Label();
            this.menoHracaLabel = new System.Windows.Forms.Label();
            this.uvodnyPanel = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.nadpisLabel1 = new System.Windows.Forms.Label();
            this.prezentacnyPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fotkaPictureBox)).BeginInit();
            this.uvodnyPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // casovac
            // 
            this.casovac.Interval = 500;
            this.casovac.Tick += new System.EventHandler(this.Casovac_Tick);
            // 
            // prezentacnyPanel
            // 
            this.prezentacnyPanel.Controls.Add(this.label2);
            this.prezentacnyPanel.Controls.Add(this.fotkaPictureBox);
            this.prezentacnyPanel.Controls.Add(this.cisloHracaLabel);
            this.prezentacnyPanel.Controls.Add(this.menoHracaLabel);
            this.prezentacnyPanel.Location = new System.Drawing.Point(11, 12);
            this.prezentacnyPanel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.prezentacnyPanel.Name = "prezentacnyPanel";
            this.prezentacnyPanel.Size = new System.Drawing.Size(460, 273);
            this.prezentacnyPanel.TabIndex = 547;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial", 31.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(163, 3);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(296, 170);
            this.label2.TabIndex = 548;
            this.label2.Text = "1. žltá karta";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fotkaPictureBox
            // 
            this.fotkaPictureBox.Location = new System.Drawing.Point(6, 3);
            this.fotkaPictureBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.fotkaPictureBox.Name = "fotkaPictureBox";
            this.fotkaPictureBox.Size = new System.Drawing.Size(153, 170);
            this.fotkaPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.fotkaPictureBox.TabIndex = 547;
            this.fotkaPictureBox.TabStop = false;
            // 
            // cisloHracaLabel
            // 
            this.cisloHracaLabel.Font = new System.Drawing.Font("Arial", 31.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cisloHracaLabel.ForeColor = System.Drawing.Color.Black;
            this.cisloHracaLabel.Location = new System.Drawing.Point(10, 172);
            this.cisloHracaLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.cisloHracaLabel.Name = "cisloHracaLabel";
            this.cisloHracaLabel.Size = new System.Drawing.Size(75, 94);
            this.cisloHracaLabel.TabIndex = 546;
            this.cisloHracaLabel.Text = "XX";
            this.cisloHracaLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menoHracaLabel
            // 
            this.menoHracaLabel.Font = new System.Drawing.Font("Arial", 31.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.menoHracaLabel.ForeColor = System.Drawing.Color.Black;
            this.menoHracaLabel.Location = new System.Drawing.Point(89, 172);
            this.menoHracaLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.menoHracaLabel.Name = "menoHracaLabel";
            this.menoHracaLabel.Size = new System.Drawing.Size(368, 94);
            this.menoHracaLabel.TabIndex = 545;
            this.menoHracaLabel.Text = "DOMÁCI";
            this.menoHracaLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uvodnyPanel
            // 
            this.uvodnyPanel.BackColor = System.Drawing.Color.Yellow;
            this.uvodnyPanel.Controls.Add(this.pictureBox1);
            this.uvodnyPanel.Controls.Add(this.nadpisLabel1);
            this.uvodnyPanel.Location = new System.Drawing.Point(10, 10);
            this.uvodnyPanel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.uvodnyPanel.Name = "uvodnyPanel";
            this.uvodnyPanel.Size = new System.Drawing.Size(459, 273);
            this.uvodnyPanel.TabIndex = 550;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BC_Futbal.Properties.Resources.yc;
            this.pictureBox1.Location = new System.Drawing.Point(2, 2);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 271);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 546;
            this.pictureBox1.TabStop = false;
            // 
            // nadpisLabel1
            // 
            this.nadpisLabel1.BackColor = System.Drawing.Color.Yellow;
            this.nadpisLabel1.Font = new System.Drawing.Font("Arial", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nadpisLabel1.ForeColor = System.Drawing.Color.Black;
            this.nadpisLabel1.Location = new System.Drawing.Point(206, 0);
            this.nadpisLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.nadpisLabel1.Name = "nadpisLabel1";
            this.nadpisLabel1.Size = new System.Drawing.Size(255, 276);
            this.nadpisLabel1.TabIndex = 545;
            this.nadpisLabel1.Text = "ŽLTÁ\r\nKARTA";
            this.nadpisLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ZltaKartaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Yellow;
            this.ClientSize = new System.Drawing.Size(480, 292);
            this.Controls.Add(this.uvodnyPanel);
            this.Controls.Add(this.prezentacnyPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ZltaKartaForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.ZltaKartaForm_Load);
            this.prezentacnyPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fotkaPictureBox)).EndInit();
            this.uvodnyPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer casovac;
        private System.Windows.Forms.Panel prezentacnyPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox fotkaPictureBox;
        private System.Windows.Forms.Label cisloHracaLabel;
        private System.Windows.Forms.Label menoHracaLabel;
        private System.Windows.Forms.Panel uvodnyPanel;
        private System.Windows.Forms.Label nadpisLabel1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}