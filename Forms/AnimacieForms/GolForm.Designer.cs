namespace LGR_Futbal.Forms
{
    partial class GolForm
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
            this.prezentacnyPanel = new System.Windows.Forms.Panel();
            this.infoRichTextBox = new System.Windows.Forms.RichTextBox();
            this.postLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.vekLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.fotkaPictureBox = new System.Windows.Forms.PictureBox();
            this.cisloHracaLabel = new System.Windows.Forms.Label();
            this.menoHracaLabel = new System.Windows.Forms.Label();
            this.uvodnyPanel = new System.Windows.Forms.Panel();
            this.nadpisLabel1 = new System.Windows.Forms.Label();
            this.animacnyPanel = new System.Windows.Forms.Panel();
            this.animaciaPB = new System.Windows.Forms.PictureBox();
            this.casovac = new System.Windows.Forms.Timer(this.components);
            this.prezentacnyPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fotkaPictureBox)).BeginInit();
            this.uvodnyPanel.SuspendLayout();
            this.animacnyPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.animaciaPB)).BeginInit();
            this.SuspendLayout();
            // 
            // prezentacnyPanel
            // 
            this.prezentacnyPanel.BackColor = System.Drawing.Color.Transparent;
            this.prezentacnyPanel.Controls.Add(this.infoRichTextBox);
            this.prezentacnyPanel.Controls.Add(this.postLabel);
            this.prezentacnyPanel.Controls.Add(this.label5);
            this.prezentacnyPanel.Controls.Add(this.vekLabel);
            this.prezentacnyPanel.Controls.Add(this.label2);
            this.prezentacnyPanel.Controls.Add(this.fotkaPictureBox);
            this.prezentacnyPanel.Controls.Add(this.cisloHracaLabel);
            this.prezentacnyPanel.Controls.Add(this.menoHracaLabel);
            this.prezentacnyPanel.Location = new System.Drawing.Point(11, 10);
            this.prezentacnyPanel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.prezentacnyPanel.Name = "prezentacnyPanel";
            this.prezentacnyPanel.Size = new System.Drawing.Size(460, 273);
            this.prezentacnyPanel.TabIndex = 548;
            // 
            // infoRichTextBox
            // 
            this.infoRichTextBox.BackColor = System.Drawing.Color.Black;
            this.infoRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.infoRichTextBox.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.infoRichTextBox.ForeColor = System.Drawing.Color.Yellow;
            this.infoRichTextBox.Location = new System.Drawing.Point(167, 77);
            this.infoRichTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.infoRichTextBox.Name = "infoRichTextBox";
            this.infoRichTextBox.Size = new System.Drawing.Size(291, 95);
            this.infoRichTextBox.TabIndex = 561;
            this.infoRichTextBox.Text = "";
            // 
            // postLabel
            // 
            this.postLabel.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.postLabel.ForeColor = System.Drawing.Color.Yellow;
            this.postLabel.Location = new System.Drawing.Point(232, 39);
            this.postLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.postLabel.Name = "postLabel";
            this.postLabel.Size = new System.Drawing.Size(225, 36);
            this.postLabel.TabIndex = 560;
            this.postLabel.Text = "999";
            this.postLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.ForeColor = System.Drawing.Color.Lime;
            this.label5.Location = new System.Drawing.Point(162, 39);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 36);
            this.label5.TabIndex = 559;
            this.label5.Text = "Post:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // vekLabel
            // 
            this.vekLabel.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.vekLabel.ForeColor = System.Drawing.Color.Yellow;
            this.vekLabel.Location = new System.Drawing.Point(232, 3);
            this.vekLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.vekLabel.Name = "vekLabel";
            this.vekLabel.Size = new System.Drawing.Size(225, 36);
            this.vekLabel.TabIndex = 558;
            this.vekLabel.Text = "999";
            this.vekLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.Color.Lime;
            this.label2.Location = new System.Drawing.Point(162, 3);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 36);
            this.label2.TabIndex = 557;
            this.label2.Text = "Vek:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // fotkaPictureBox
            // 
            this.fotkaPictureBox.Location = new System.Drawing.Point(5, 3);
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
            this.cisloHracaLabel.ForeColor = System.Drawing.Color.Yellow;
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
            this.menoHracaLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
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
            this.uvodnyPanel.BackColor = System.Drawing.Color.Black;
            this.uvodnyPanel.Controls.Add(this.nadpisLabel1);
            this.uvodnyPanel.Location = new System.Drawing.Point(11, 10);
            this.uvodnyPanel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.uvodnyPanel.Name = "uvodnyPanel";
            this.uvodnyPanel.Size = new System.Drawing.Size(459, 273);
            this.uvodnyPanel.TabIndex = 551;
            // 
            // nadpisLabel1
            // 
            this.nadpisLabel1.BackColor = System.Drawing.Color.Black;
            this.nadpisLabel1.Font = new System.Drawing.Font("Arial", 75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nadpisLabel1.ForeColor = System.Drawing.Color.Yellow;
            this.nadpisLabel1.Location = new System.Drawing.Point(1, 0);
            this.nadpisLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.nadpisLabel1.Name = "nadpisLabel1";
            this.nadpisLabel1.Size = new System.Drawing.Size(460, 276);
            this.nadpisLabel1.TabIndex = 545;
            this.nadpisLabel1.Text = "GÓÓÓL";
            this.nadpisLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // animacnyPanel
            // 
            this.animacnyPanel.BackColor = System.Drawing.Color.Black;
            this.animacnyPanel.Controls.Add(this.animaciaPB);
            this.animacnyPanel.Location = new System.Drawing.Point(11, 10);
            this.animacnyPanel.Name = "animacnyPanel";
            this.animacnyPanel.Size = new System.Drawing.Size(456, 270);
            this.animacnyPanel.TabIndex = 546;
            // 
            // animaciaPB
            // 
            this.animaciaPB.BackColor = System.Drawing.Color.Black;
            this.animaciaPB.Location = new System.Drawing.Point(3, 3);
            this.animaciaPB.Name = "animaciaPB";
            this.animaciaPB.Size = new System.Drawing.Size(450, 263);
            this.animaciaPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.animaciaPB.TabIndex = 0;
            this.animaciaPB.TabStop = false;
            // 
            // casovac
            // 
            this.casovac.Interval = 500;
            this.casovac.Tick += new System.EventHandler(this.Casovac_Tick);
            // 
            // GolForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(480, 292);
            this.Controls.Add(this.animacnyPanel);
            this.Controls.Add(this.uvodnyPanel);
            this.Controls.Add(this.prezentacnyPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GolForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.GolForm_Load);
            this.prezentacnyPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fotkaPictureBox)).EndInit();
            this.uvodnyPanel.ResumeLayout(false);
            this.animacnyPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.animaciaPB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel prezentacnyPanel;
        private System.Windows.Forms.PictureBox fotkaPictureBox;
        private System.Windows.Forms.Label cisloHracaLabel;
        private System.Windows.Forms.Label menoHracaLabel;
        private System.Windows.Forms.Panel uvodnyPanel;
        private System.Windows.Forms.Label nadpisLabel1;
        private System.Windows.Forms.RichTextBox infoRichTextBox;
        private System.Windows.Forms.Label postLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label vekLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel animacnyPanel;
        private System.Windows.Forms.PictureBox animaciaPB;
        private System.Windows.Forms.Timer casovac;
    }
}