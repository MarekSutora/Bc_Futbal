namespace LGR_Futbal.Forms
{
    partial class UdalostiForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.skoreLabel = new System.Windows.Forms.Label();
            this.csvGenButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ColumnCas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPolcas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMinuta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNadstMin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnHráč = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPoznamka = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUdalost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 45);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1003, 519);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Čas";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Polčas";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Minúta";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Nadstavená minúta";
            this.columnHeader4.Width = 150;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Hráč";
            this.columnHeader5.Width = 230;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Poznámka";
            this.columnHeader6.Width = 200;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Udalosť";
            this.columnHeader7.Width = 200;
            // 
            // skoreLabel
            // 
            this.skoreLabel.AutoSize = true;
            this.skoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.skoreLabel.Location = new System.Drawing.Point(12, 9);
            this.skoreLabel.Name = "skoreLabel";
            this.skoreLabel.Size = new System.Drawing.Size(93, 33);
            this.skoreLabel.TabIndex = 2;
            this.skoreLabel.Text = "label2";
            // 
            // csvGenButton
            // 
            this.csvGenButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.csvGenButton.Location = new System.Drawing.Point(842, 9);
            this.csvGenButton.Name = "csvGenButton";
            this.csvGenButton.Size = new System.Drawing.Size(173, 30);
            this.csvGenButton.TabIndex = 3;
            this.csvGenButton.Text = "vygenerovať súbor";
            this.csvGenButton.UseVisualStyleBackColor = true;
            this.csvGenButton.Click += new System.EventHandler(this.csvGenButton_Click);
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnCas,
            this.ColumnPolcas,
            this.ColumnMinuta,
            this.ColumnNadstMin,
            this.ColumnHráč,
            this.ColumnPoznamka,
            this.ColumnUdalost});
            this.dataGridView1.Location = new System.Drawing.Point(12, 45);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1003, 520);
            this.dataGridView1.TabIndex = 4;
            // 
            // ColumnCas
            // 
            this.ColumnCas.HeaderText = "Čas";
            this.ColumnCas.Name = "ColumnCas";
            // 
            // ColumnPolcas
            // 
            this.ColumnPolcas.HeaderText = "Polčas";
            this.ColumnPolcas.Name = "ColumnPolcas";
            this.ColumnPolcas.Width = 70;
            // 
            // ColumnMinuta
            // 
            this.ColumnMinuta.HeaderText = "Minúta";
            this.ColumnMinuta.Name = "ColumnMinuta";
            this.ColumnMinuta.Width = 70;
            // 
            // ColumnNadstMin
            // 
            this.ColumnNadstMin.HeaderText = "Nadstavená minúta";
            this.ColumnNadstMin.Name = "ColumnNadstMin";
            this.ColumnNadstMin.Width = 120;
            // 
            // ColumnHráč
            // 
            this.ColumnHráč.HeaderText = "Hráč";
            this.ColumnHráč.Name = "ColumnHráč";
            this.ColumnHráč.Width = 200;
            // 
            // ColumnPoznamka
            // 
            this.ColumnPoznamka.HeaderText = "Poznámka";
            this.ColumnPoznamka.Name = "ColumnPoznamka";
            this.ColumnPoznamka.Width = 200;
            // 
            // ColumnUdalost
            // 
            this.ColumnUdalost.HeaderText = "Udalosť";
            this.ColumnUdalost.Name = "ColumnUdalost";
            this.ColumnUdalost.Width = 200;
            // 
            // UdalostiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1027, 577);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.csvGenButton);
            this.Controls.Add(this.skoreLabel);
            this.Controls.Add(this.listView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "UdalostiForm";
            this.Text = "Udalosti";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Label skoreLabel;
        private System.Windows.Forms.Button csvGenButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCas;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPolcas;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMinuta;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNadstMin;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnHráč;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPoznamka;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUdalost;
    }
}