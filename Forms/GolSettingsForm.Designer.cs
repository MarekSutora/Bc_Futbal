﻿namespace LGR_Futbal.Forms
{
    partial class GolSettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GolSettingsForm));
            this.potvrditButton = new System.Windows.Forms.Button();
            this.hraciLB = new System.Windows.Forms.ListBox();
            this.backButton = new System.Windows.Forms.Button();
            this.znizitSkoreButton = new System.Windows.Forms.Button();
            this.resetSkoreButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // potvrditButton
            // 
            this.potvrditButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.potvrditButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.potvrditButton.Location = new System.Drawing.Point(289, 12);
            this.potvrditButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.potvrditButton.Name = "potvrditButton";
            this.potvrditButton.Size = new System.Drawing.Size(175, 78);
            this.potvrditButton.TabIndex = 552;
            this.potvrditButton.Text = "Potvrdiť gól";
            this.potvrditButton.UseVisualStyleBackColor = false;
            this.potvrditButton.Click += new System.EventHandler(this.PotvrditButton_Click);
            // 
            // hraciLB
            // 
            this.hraciLB.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.hraciLB.FormattingEnabled = true;
            this.hraciLB.ItemHeight = 26;
            this.hraciLB.Location = new System.Drawing.Point(10, 12);
            this.hraciLB.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.hraciLB.Name = "hraciLB";
            this.hraciLB.Size = new System.Drawing.Size(276, 394);
            this.hraciLB.TabIndex = 551;
            this.hraciLB.DoubleClick += new System.EventHandler(this.hraciLB_DoubleClick);
            // 
            // backButton
            // 
            this.backButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.backButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.backButton.Location = new System.Drawing.Point(291, 345);
            this.backButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(175, 78);
            this.backButton.TabIndex = 550;
            this.backButton.Text = "Návrat späť";
            this.backButton.UseVisualStyleBackColor = false;
            this.backButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // znizitSkoreButton
            // 
            this.znizitSkoreButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.znizitSkoreButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.znizitSkoreButton.Location = new System.Drawing.Point(289, 94);
            this.znizitSkoreButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.znizitSkoreButton.Name = "znizitSkoreButton";
            this.znizitSkoreButton.Size = new System.Drawing.Size(176, 78);
            this.znizitSkoreButton.TabIndex = 553;
            this.znizitSkoreButton.Text = "Znížiť skóre";
            this.znizitSkoreButton.UseVisualStyleBackColor = false;
            this.znizitSkoreButton.Click += new System.EventHandler(this.ZnizitSkoreButton_Click);
            // 
            // resetSkoreButton
            // 
            this.resetSkoreButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.resetSkoreButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.resetSkoreButton.Location = new System.Drawing.Point(289, 175);
            this.resetSkoreButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.resetSkoreButton.Name = "resetSkoreButton";
            this.resetSkoreButton.Size = new System.Drawing.Size(176, 78);
            this.resetSkoreButton.TabIndex = 554;
            this.resetSkoreButton.Text = "Resetovať skóre";
            this.resetSkoreButton.UseVisualStyleBackColor = false;
            this.resetSkoreButton.Click += new System.EventHandler(this.ResetSkoreButton_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.Location = new System.Drawing.Point(291, 296);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(174, 42);
            this.button1.TabIndex = 555;
            this.button1.Text = "Nastaviť";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(331, 264);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 20);
            this.label1.TabIndex = 556;
            this.label1.Text = "Hodnota:";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.numericUpDown1.Location = new System.Drawing.Point(408, 263);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(57, 26);
            this.numericUpDown1.TabIndex = 557;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // GolSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 430);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.resetSkoreButton);
            this.Controls.Add(this.znizitSkoreButton);
            this.Controls.Add(this.potvrditButton);
            this.Controls.Add(this.hraciLB);
            this.Controls.Add(this.backButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GolSettingsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gól - nastavenia";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GolSettingsForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button potvrditButton;
        private System.Windows.Forms.ListBox hraciLB;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button znizitSkoreButton;
        private System.Windows.Forms.Button resetSkoreButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}