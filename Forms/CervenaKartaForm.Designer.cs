namespace LGR_Futbal.Forms
{
    partial class CervenaKartaForm
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
            this.uvodnyPanel1 = new System.Windows.Forms.Panel();
            this.prezentacnyPanel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.cisloHracaLabel = new System.Windows.Forms.Label();
            this.menoHracaLabel = new System.Windows.Forms.Label();
            this.uvodnyPanel2 = new System.Windows.Forms.Panel();
            this.prezentacnyPanel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.chLabel = new System.Windows.Forms.Label();
            this.mhLabel = new System.Windows.Forms.Label();
            this.nadpisLabel1 = new System.Windows.Forms.Label();
            this.nadpisLabel2 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.fotkaPB = new System.Windows.Forms.PictureBox();
            this.fotkaPictureBox = new System.Windows.Forms.PictureBox();
            this.uvodnyPanel1.SuspendLayout();
            this.prezentacnyPanel1.SuspendLayout();
            this.uvodnyPanel2.SuspendLayout();
            this.prezentacnyPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fotkaPB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fotkaPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // casovac
            // 
            this.casovac.Interval = 500;
            this.casovac.Tick += new System.EventHandler(this.Casovac_Tick);
            // 
            // uvodnyPanel1
            // 
            this.uvodnyPanel1.BackColor = System.Drawing.Color.Yellow;
            this.uvodnyPanel1.Controls.Add(this.pictureBox1);
            this.uvodnyPanel1.Controls.Add(this.nadpisLabel1);
            this.uvodnyPanel1.Location = new System.Drawing.Point(16, 15);
            this.uvodnyPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uvodnyPanel1.Name = "uvodnyPanel1";
            this.uvodnyPanel1.Size = new System.Drawing.Size(688, 420);
            this.uvodnyPanel1.TabIndex = 551;
            // 
            // prezentacnyPanel1
            // 
            this.prezentacnyPanel1.Controls.Add(this.label2);
            this.prezentacnyPanel1.Controls.Add(this.fotkaPictureBox);
            this.prezentacnyPanel1.Controls.Add(this.cisloHracaLabel);
            this.prezentacnyPanel1.Controls.Add(this.menoHracaLabel);
            this.prezentacnyPanel1.Location = new System.Drawing.Point(16, 15);
            this.prezentacnyPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.prezentacnyPanel1.Name = "prezentacnyPanel1";
            this.prezentacnyPanel1.Size = new System.Drawing.Size(690, 420);
            this.prezentacnyPanel1.TabIndex = 552;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial", 31.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(245, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(444, 261);
            this.label2.TabIndex = 548;
            this.label2.Text = "2. žltá karta";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cisloHracaLabel
            // 
            this.cisloHracaLabel.Font = new System.Drawing.Font("Arial", 31.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cisloHracaLabel.ForeColor = System.Drawing.Color.Black;
            this.cisloHracaLabel.Location = new System.Drawing.Point(15, 265);
            this.cisloHracaLabel.Name = "cisloHracaLabel";
            this.cisloHracaLabel.Size = new System.Drawing.Size(112, 144);
            this.cisloHracaLabel.TabIndex = 546;
            this.cisloHracaLabel.Text = "XX";
            this.cisloHracaLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menoHracaLabel
            // 
            this.menoHracaLabel.Font = new System.Drawing.Font("Arial", 31.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.menoHracaLabel.ForeColor = System.Drawing.Color.Navy;
            this.menoHracaLabel.Location = new System.Drawing.Point(134, 265);
            this.menoHracaLabel.Name = "menoHracaLabel";
            this.menoHracaLabel.Size = new System.Drawing.Size(552, 144);
            this.menoHracaLabel.TabIndex = 545;
            this.menoHracaLabel.Text = "DOMÁCI";
            this.menoHracaLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uvodnyPanel2
            // 
            this.uvodnyPanel2.BackColor = System.Drawing.Color.Red;
            this.uvodnyPanel2.Controls.Add(this.pictureBox2);
            this.uvodnyPanel2.Controls.Add(this.nadpisLabel2);
            this.uvodnyPanel2.Location = new System.Drawing.Point(16, 15);
            this.uvodnyPanel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uvodnyPanel2.Name = "uvodnyPanel2";
            this.uvodnyPanel2.Size = new System.Drawing.Size(688, 420);
            this.uvodnyPanel2.TabIndex = 553;
            // 
            // prezentacnyPanel2
            // 
            this.prezentacnyPanel2.BackColor = System.Drawing.Color.Red;
            this.prezentacnyPanel2.Controls.Add(this.label3);
            this.prezentacnyPanel2.Controls.Add(this.fotkaPB);
            this.prezentacnyPanel2.Controls.Add(this.chLabel);
            this.prezentacnyPanel2.Controls.Add(this.mhLabel);
            this.prezentacnyPanel2.Location = new System.Drawing.Point(16, 15);
            this.prezentacnyPanel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.prezentacnyPanel2.Name = "prezentacnyPanel2";
            this.prezentacnyPanel2.Size = new System.Drawing.Size(690, 420);
            this.prezentacnyPanel2.TabIndex = 554;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Arial", 31.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(245, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(444, 261);
            this.label3.TabIndex = 548;
            this.label3.Text = "vylúčený";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chLabel
            // 
            this.chLabel.Font = new System.Drawing.Font("Arial", 31.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chLabel.ForeColor = System.Drawing.Color.White;
            this.chLabel.Location = new System.Drawing.Point(15, 265);
            this.chLabel.Name = "chLabel";
            this.chLabel.Size = new System.Drawing.Size(112, 144);
            this.chLabel.TabIndex = 546;
            this.chLabel.Text = "XX";
            this.chLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mhLabel
            // 
            this.mhLabel.Font = new System.Drawing.Font("Arial", 31.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.mhLabel.ForeColor = System.Drawing.Color.White;
            this.mhLabel.Location = new System.Drawing.Point(134, 265);
            this.mhLabel.Name = "mhLabel";
            this.mhLabel.Size = new System.Drawing.Size(552, 144);
            this.mhLabel.TabIndex = 545;
            this.mhLabel.Text = "DOMÁCI";
            this.mhLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nadpisLabel1
            // 
            this.nadpisLabel1.BackColor = System.Drawing.Color.Yellow;
            this.nadpisLabel1.Font = new System.Drawing.Font("Arial", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nadpisLabel1.ForeColor = System.Drawing.Color.Black;
            this.nadpisLabel1.Location = new System.Drawing.Point(306, -2);
            this.nadpisLabel1.Name = "nadpisLabel1";
            this.nadpisLabel1.Size = new System.Drawing.Size(382, 424);
            this.nadpisLabel1.TabIndex = 547;
            this.nadpisLabel1.Text = "ŽLTÁ\r\nKARTA";
            this.nadpisLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nadpisLabel2
            // 
            this.nadpisLabel2.BackColor = System.Drawing.Color.Red;
            this.nadpisLabel2.Font = new System.Drawing.Font("Arial", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nadpisLabel2.ForeColor = System.Drawing.Color.Black;
            this.nadpisLabel2.Location = new System.Drawing.Point(306, -2);
            this.nadpisLabel2.Name = "nadpisLabel2";
            this.nadpisLabel2.Size = new System.Drawing.Size(382, 424);
            this.nadpisLabel2.TabIndex = 547;
            this.nadpisLabel2.Text = "ČERVENÁ\r\nKARTA";
            this.nadpisLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::LGR_Futbal.Properties.Resources.rc;
            this.pictureBox2.Location = new System.Drawing.Point(0, 1);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(300, 417);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 548;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::LGR_Futbal.Properties.Resources.yc;
            this.pictureBox1.Location = new System.Drawing.Point(0, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(300, 417);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 548;
            this.pictureBox1.TabStop = false;
            // 
            // fotkaPB
            // 
            this.fotkaPB.Location = new System.Drawing.Point(9, 5);
            this.fotkaPB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.fotkaPB.Name = "fotkaPB";
            this.fotkaPB.Size = new System.Drawing.Size(230, 261);
            this.fotkaPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.fotkaPB.TabIndex = 547;
            this.fotkaPB.TabStop = false;
            // 
            // fotkaPictureBox
            // 
            this.fotkaPictureBox.Location = new System.Drawing.Point(9, 5);
            this.fotkaPictureBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.fotkaPictureBox.Name = "fotkaPictureBox";
            this.fotkaPictureBox.Size = new System.Drawing.Size(230, 261);
            this.fotkaPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.fotkaPictureBox.TabIndex = 547;
            this.fotkaPictureBox.TabStop = false;
            // 
            // CervenaKartaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Yellow;
            this.ClientSize = new System.Drawing.Size(720, 450);
            this.Controls.Add(this.uvodnyPanel2);
            this.Controls.Add(this.uvodnyPanel1);
            this.Controls.Add(this.prezentacnyPanel2);
            this.Controls.Add(this.prezentacnyPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CervenaKartaForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.CervenaKartaForm_Load);
            this.uvodnyPanel1.ResumeLayout(false);
            this.prezentacnyPanel1.ResumeLayout(false);
            this.uvodnyPanel2.ResumeLayout(false);
            this.prezentacnyPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fotkaPB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fotkaPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer casovac;
        private System.Windows.Forms.Panel uvodnyPanel1;
        private System.Windows.Forms.Panel prezentacnyPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox fotkaPictureBox;
        private System.Windows.Forms.Label cisloHracaLabel;
        private System.Windows.Forms.Label menoHracaLabel;
        private System.Windows.Forms.Panel uvodnyPanel2;
        private System.Windows.Forms.Panel prezentacnyPanel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox fotkaPB;
        private System.Windows.Forms.Label chLabel;
        private System.Windows.Forms.Label mhLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label nadpisLabel1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label nadpisLabel2;
    }
}