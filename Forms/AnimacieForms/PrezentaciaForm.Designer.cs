namespace LGR_Futbal.Forms
{
    partial class PrezentaciaForm
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
            this.uvodnyPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.nazovLabel = new System.Windows.Forms.Label();
            this.prezentacnyPanel = new System.Windows.Forms.Panel();
            this.infoRichTextBox = new System.Windows.Forms.RichTextBox();
            this.postLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.vekLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.fotkaPictureBox = new System.Windows.Forms.PictureBox();
            this.cisloHracaLabel = new System.Windows.Forms.Label();
            this.menoHracaLabel = new System.Windows.Forms.Label();
            this.casovac = new System.Windows.Forms.Timer(this.components);
            this.nahradniciPanel = new System.Windows.Forms.Panel();
            this.nahradniciLabel = new System.Windows.Forms.Label();
            this.uvodnyPanel.SuspendLayout();
            this.prezentacnyPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fotkaPictureBox)).BeginInit();
            this.nahradniciPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // uvodnyPanel
            // 
            this.uvodnyPanel.BackColor = System.Drawing.Color.Black;
            this.uvodnyPanel.Controls.Add(this.label1);
            this.uvodnyPanel.Controls.Add(this.nazovLabel);
            this.uvodnyPanel.Location = new System.Drawing.Point(9, 10);
            this.uvodnyPanel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.uvodnyPanel.Name = "uvodnyPanel";
            this.uvodnyPanel.Size = new System.Drawing.Size(462, 273);
            this.uvodnyPanel.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 25.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(-2, 172);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(462, 101);
            this.label1.TabIndex = 545;
            this.label1.Text = "predstavenie hráčov";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // nazovLabel
            // 
            this.nazovLabel.Font = new System.Drawing.Font("Arial", 66F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nazovLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.nazovLabel.Location = new System.Drawing.Point(0, 0);
            this.nazovLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.nazovLabel.Name = "nazovLabel";
            this.nazovLabel.Size = new System.Drawing.Size(462, 172);
            this.nazovLabel.TabIndex = 544;
            this.nazovLabel.Text = "DOMÁCI";
            this.nazovLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // prezentacnyPanel
            // 
            this.prezentacnyPanel.BackColor = System.Drawing.Color.Black;
            this.prezentacnyPanel.Controls.Add(this.infoRichTextBox);
            this.prezentacnyPanel.Controls.Add(this.postLabel);
            this.prezentacnyPanel.Controls.Add(this.label5);
            this.prezentacnyPanel.Controls.Add(this.vekLabel);
            this.prezentacnyPanel.Controls.Add(this.label2);
            this.prezentacnyPanel.Controls.Add(this.fotkaPictureBox);
            this.prezentacnyPanel.Controls.Add(this.cisloHracaLabel);
            this.prezentacnyPanel.Controls.Add(this.menoHracaLabel);
            this.prezentacnyPanel.Location = new System.Drawing.Point(8, 7);
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
            this.infoRichTextBox.TabIndex = 556;
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
            this.postLabel.TabIndex = 555;
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
            this.label5.TabIndex = 553;
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
            this.vekLabel.TabIndex = 549;
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
            this.label2.TabIndex = 548;
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
            // casovac
            // 
            this.casovac.Interval = 500;
            this.casovac.Tick += new System.EventHandler(this.Casovac_Tick);
            // 
            // nahradniciPanel
            // 
            this.nahradniciPanel.BackColor = System.Drawing.Color.Black;
            this.nahradniciPanel.Controls.Add(this.nahradniciLabel);
            this.nahradniciPanel.Location = new System.Drawing.Point(7, 7);
            this.nahradniciPanel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.nahradniciPanel.Name = "nahradniciPanel";
            this.nahradniciPanel.Size = new System.Drawing.Size(462, 273);
            this.nahradniciPanel.TabIndex = 549;
            // 
            // nahradniciLabel
            // 
            this.nahradniciLabel.Font = new System.Drawing.Font("Arial", 40F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nahradniciLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.nahradniciLabel.Location = new System.Drawing.Point(0, 0);
            this.nahradniciLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.nahradniciLabel.Name = "nahradniciLabel";
            this.nahradniciLabel.Size = new System.Drawing.Size(462, 276);
            this.nahradniciLabel.TabIndex = 544;
            this.nahradniciLabel.Text = "NÁHRADNÍCI";
            this.nahradniciLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PrezentaciaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(480, 292);
            this.Controls.Add(this.nahradniciPanel);
            this.Controls.Add(this.prezentacnyPanel);
            this.Controls.Add(this.uvodnyPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PrezentaciaForm";
            this.Load += new System.EventHandler(this.PrezentaciaForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PrezentaciaForm_KeyDown);
            this.uvodnyPanel.ResumeLayout(false);
            this.prezentacnyPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fotkaPictureBox)).EndInit();
            this.nahradniciPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel uvodnyPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label nazovLabel;
        private System.Windows.Forms.Timer casovac;
        private System.Windows.Forms.Panel prezentacnyPanel;
        private System.Windows.Forms.Label postLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label vekLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox fotkaPictureBox;
        private System.Windows.Forms.Label cisloHracaLabel;
        private System.Windows.Forms.Label menoHracaLabel;
        private System.Windows.Forms.RichTextBox infoRichTextBox;
        private System.Windows.Forms.Panel nahradniciPanel;
        private System.Windows.Forms.Label nahradniciLabel;
    }
}