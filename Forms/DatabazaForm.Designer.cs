namespace LGR_Futbal.Forms
{
    partial class DatabazaForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DatabazaForm));
            this.infoLabel1 = new System.Windows.Forms.Label();
            this.timyListBox = new System.Windows.Forms.ListBox();
            this.addGroupBox = new System.Windows.Forms.GroupBox();
            this.spatButton = new System.Windows.Forms.Button();
            this.zrusitLogoButton = new System.Windows.Forms.Button();
            this.vlozitButton = new System.Windows.Forms.Button();
            this.zmenaObrazkaButton = new System.Windows.Forms.Button();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.nazovTextBox = new System.Windows.Forms.TextBox();
            this.infoLabel2 = new System.Windows.Forms.Label();
            this.editGroupBox = new System.Windows.Forms.GroupBox();
            this.editHraciButton = new System.Windows.Forms.Button();
            this.editBackButton = new System.Windows.Forms.Button();
            this.editZrusButton = new System.Windows.Forms.Button();
            this.editConfirmButton = new System.Windows.Forms.Button();
            this.editZmenaButton = new System.Windows.Forms.Button();
            this.editPictureBox = new System.Windows.Forms.PictureBox();
            this.editNazovTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.exportButton = new System.Windows.Forms.Button();
            this.importButton = new System.Windows.Forms.Button();
            this.zapasButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.zrusitButton = new System.Windows.Forms.Button();
            this.addGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.editGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.editPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // infoLabel1
            // 
            this.infoLabel1.AutoSize = true;
            this.infoLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.infoLabel1.Location = new System.Drawing.Point(9, 9);
            this.infoLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.infoLabel1.Name = "infoLabel1";
            this.infoLabel1.Size = new System.Drawing.Size(96, 17);
            this.infoLabel1.TabIndex = 20;
            this.infoLabel1.Text = "Zoznam tímov";
            // 
            // timyListBox
            // 
            this.timyListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.timyListBox.FormattingEnabled = true;
            this.timyListBox.ItemHeight = 17;
            this.timyListBox.Location = new System.Drawing.Point(8, 29);
            this.timyListBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.timyListBox.Name = "timyListBox";
            this.timyListBox.Size = new System.Drawing.Size(189, 378);
            this.timyListBox.TabIndex = 21;
            this.timyListBox.SelectedIndexChanged += new System.EventHandler(this.TimyListBox_SelectedIndexChanged);
            this.timyListBox.DoubleClick += new System.EventHandler(this.timyListBox_DoubleClick);
            // 
            // addGroupBox
            // 
            this.addGroupBox.Controls.Add(this.spatButton);
            this.addGroupBox.Controls.Add(this.zrusitLogoButton);
            this.addGroupBox.Controls.Add(this.vlozitButton);
            this.addGroupBox.Controls.Add(this.zmenaObrazkaButton);
            this.addGroupBox.Controls.Add(this.logoPictureBox);
            this.addGroupBox.Controls.Add(this.nazovTextBox);
            this.addGroupBox.Controls.Add(this.infoLabel2);
            this.addGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.addGroupBox.Location = new System.Drawing.Point(318, 27);
            this.addGroupBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.addGroupBox.Name = "addGroupBox";
            this.addGroupBox.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.addGroupBox.Size = new System.Drawing.Size(401, 242);
            this.addGroupBox.TabIndex = 26;
            this.addGroupBox.TabStop = false;
            this.addGroupBox.Text = "Vloženie nového tímu";
            this.addGroupBox.Visible = false;
            // 
            // spatButton
            // 
            this.spatButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.spatButton.Image = global::LGR_Futbal.Properties.Resources.Back_2;
            this.spatButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.spatButton.Location = new System.Drawing.Point(162, 181);
            this.spatButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.spatButton.Name = "spatButton";
            this.spatButton.Size = new System.Drawing.Size(113, 52);
            this.spatButton.TabIndex = 26;
            this.spatButton.Text = "Späť    ";
            this.spatButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.spatButton.UseVisualStyleBackColor = true;
            this.spatButton.Click += new System.EventHandler(this.SpatButton_Click);
            // 
            // zrusitLogoButton
            // 
            this.zrusitLogoButton.Location = new System.Drawing.Point(162, 83);
            this.zrusitLogoButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.zrusitLogoButton.Name = "zrusitLogoButton";
            this.zrusitLogoButton.Size = new System.Drawing.Size(113, 30);
            this.zrusitLogoButton.TabIndex = 25;
            this.zrusitLogoButton.Text = "Zrušiť logo";
            this.zrusitLogoButton.UseVisualStyleBackColor = true;
            this.zrusitLogoButton.Click += new System.EventHandler(this.ZrusitLogoButton_Click);
            // 
            // vlozitButton
            // 
            this.vlozitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.vlozitButton.Image = global::LGR_Futbal.Properties.Resources.Add_Folder;
            this.vlozitButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.vlozitButton.Location = new System.Drawing.Point(279, 181);
            this.vlozitButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.vlozitButton.Name = "vlozitButton";
            this.vlozitButton.Size = new System.Drawing.Size(118, 52);
            this.vlozitButton.TabIndex = 24;
            this.vlozitButton.Text = "Vložiť    \r\nnový tím  ";
            this.vlozitButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.vlozitButton.UseVisualStyleBackColor = true;
            this.vlozitButton.Click += new System.EventHandler(this.VlozitButton_Click);
            // 
            // zmenaObrazkaButton
            // 
            this.zmenaObrazkaButton.Location = new System.Drawing.Point(162, 48);
            this.zmenaObrazkaButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.zmenaObrazkaButton.Name = "zmenaObrazkaButton";
            this.zmenaObrazkaButton.Size = new System.Drawing.Size(113, 30);
            this.zmenaObrazkaButton.TabIndex = 4;
            this.zmenaObrazkaButton.Text = "Zmeniť logo";
            this.zmenaObrazkaButton.UseVisualStyleBackColor = true;
            this.zmenaObrazkaButton.Click += new System.EventHandler(this.ZmenaObrazkaButton_Click);
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.Location = new System.Drawing.Point(279, 48);
            this.logoPictureBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.logoPictureBox.Name = "logoPictureBox";
            this.logoPictureBox.Size = new System.Drawing.Size(118, 127);
            this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logoPictureBox.TabIndex = 3;
            this.logoPictureBox.TabStop = false;
            // 
            // nazovTextBox
            // 
            this.nazovTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nazovTextBox.Location = new System.Drawing.Point(91, 21);
            this.nazovTextBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.nazovTextBox.Name = "nazovTextBox";
            this.nazovTextBox.Size = new System.Drawing.Size(307, 23);
            this.nazovTextBox.TabIndex = 1;
            // 
            // infoLabel2
            // 
            this.infoLabel2.AutoSize = true;
            this.infoLabel2.Location = new System.Drawing.Point(5, 23);
            this.infoLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.infoLabel2.Name = "infoLabel2";
            this.infoLabel2.Size = new System.Drawing.Size(82, 17);
            this.infoLabel2.TabIndex = 0;
            this.infoLabel2.Text = "Názov tímu:";
            // 
            // editGroupBox
            // 
            this.editGroupBox.Controls.Add(this.editHraciButton);
            this.editGroupBox.Controls.Add(this.editBackButton);
            this.editGroupBox.Controls.Add(this.editZrusButton);
            this.editGroupBox.Controls.Add(this.editConfirmButton);
            this.editGroupBox.Controls.Add(this.editZmenaButton);
            this.editGroupBox.Controls.Add(this.editPictureBox);
            this.editGroupBox.Controls.Add(this.editNazovTextBox);
            this.editGroupBox.Controls.Add(this.label1);
            this.editGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.editGroupBox.Location = new System.Drawing.Point(318, 27);
            this.editGroupBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.editGroupBox.Name = "editGroupBox";
            this.editGroupBox.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.editGroupBox.Size = new System.Drawing.Size(401, 242);
            this.editGroupBox.TabIndex = 28;
            this.editGroupBox.TabStop = false;
            this.editGroupBox.Text = "Zmena údajov tímu";
            this.editGroupBox.Visible = false;
            // 
            // editHraciButton
            // 
            this.editHraciButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.editHraciButton.Image = global::LGR_Futbal.Properties.Resources.Contacts;
            this.editHraciButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.editHraciButton.Location = new System.Drawing.Point(125, 181);
            this.editHraciButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.editHraciButton.Name = "editHraciButton";
            this.editHraciButton.Size = new System.Drawing.Size(150, 52);
            this.editHraciButton.TabIndex = 27;
            this.editHraciButton.Text = "Vykonať zmeny \r\nzoznamu hráčov";
            this.editHraciButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.editHraciButton.UseVisualStyleBackColor = true;
            this.editHraciButton.Click += new System.EventHandler(this.EditHraciButton_Click);
            // 
            // editBackButton
            // 
            this.editBackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.editBackButton.Image = global::LGR_Futbal.Properties.Resources.Back_2;
            this.editBackButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.editBackButton.Location = new System.Drawing.Point(7, 181);
            this.editBackButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.editBackButton.Name = "editBackButton";
            this.editBackButton.Size = new System.Drawing.Size(113, 52);
            this.editBackButton.TabIndex = 26;
            this.editBackButton.Text = "Späť    ";
            this.editBackButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.editBackButton.UseVisualStyleBackColor = true;
            this.editBackButton.Click += new System.EventHandler(this.EditBackButton_Click);
            // 
            // editZrusButton
            // 
            this.editZrusButton.Location = new System.Drawing.Point(162, 83);
            this.editZrusButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.editZrusButton.Name = "editZrusButton";
            this.editZrusButton.Size = new System.Drawing.Size(113, 30);
            this.editZrusButton.TabIndex = 25;
            this.editZrusButton.Text = "Zrušiť logo";
            this.editZrusButton.UseVisualStyleBackColor = true;
            this.editZrusButton.Click += new System.EventHandler(this.EditZrusButton_Click);
            // 
            // editConfirmButton
            // 
            this.editConfirmButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.editConfirmButton.Image = global::LGR_Futbal.Properties.Resources.Write;
            this.editConfirmButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.editConfirmButton.Location = new System.Drawing.Point(279, 181);
            this.editConfirmButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.editConfirmButton.Name = "editConfirmButton";
            this.editConfirmButton.Size = new System.Drawing.Size(118, 52);
            this.editConfirmButton.TabIndex = 24;
            this.editConfirmButton.Text = "Potvrdiť   \r\nzmeny    ";
            this.editConfirmButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.editConfirmButton.UseVisualStyleBackColor = true;
            this.editConfirmButton.Click += new System.EventHandler(this.EditConfirmButton_Click);
            // 
            // editZmenaButton
            // 
            this.editZmenaButton.Location = new System.Drawing.Point(162, 48);
            this.editZmenaButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.editZmenaButton.Name = "editZmenaButton";
            this.editZmenaButton.Size = new System.Drawing.Size(113, 30);
            this.editZmenaButton.TabIndex = 4;
            this.editZmenaButton.Text = "Zmeniť logo";
            this.editZmenaButton.UseVisualStyleBackColor = true;
            this.editZmenaButton.Click += new System.EventHandler(this.EditZmenaButton_Click);
            // 
            // editPictureBox
            // 
            this.editPictureBox.Location = new System.Drawing.Point(279, 48);
            this.editPictureBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.editPictureBox.Name = "editPictureBox";
            this.editPictureBox.Size = new System.Drawing.Size(118, 127);
            this.editPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.editPictureBox.TabIndex = 3;
            this.editPictureBox.TabStop = false;
            // 
            // editNazovTextBox
            // 
            this.editNazovTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.editNazovTextBox.Location = new System.Drawing.Point(91, 21);
            this.editNazovTextBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.editNazovTextBox.Name = "editNazovTextBox";
            this.editNazovTextBox.Size = new System.Drawing.Size(307, 23);
            this.editNazovTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Názov tímu:";
            // 
            // exportButton
            // 
            this.exportButton.Enabled = false;
            this.exportButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.exportButton.Image = global::LGR_Futbal.Properties.Resources.Save;
            this.exportButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.exportButton.Location = new System.Drawing.Point(201, 338);
            this.exportButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(113, 57);
            this.exportButton.TabIndex = 30;
            this.exportButton.Text = "Export   \r\ntímu     ";
            this.exportButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // importButton
            // 
            this.importButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.importButton.Image = global::LGR_Futbal.Properties.Resources.Forward_Email;
            this.importButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.importButton.Location = new System.Drawing.Point(201, 276);
            this.importButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(113, 57);
            this.importButton.TabIndex = 29;
            this.importButton.Text = "Import   \r\ntímu     ";
            this.importButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.importButton.UseVisualStyleBackColor = true;
            this.importButton.Click += new System.EventHandler(this.importButton_Click);
            // 
            // zapasButton
            // 
            this.zapasButton.Enabled = false;
            this.zapasButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.zapasButton.Image = global::LGR_Futbal.Properties.Resources.Properties;
            this.zapasButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.zapasButton.Location = new System.Drawing.Point(201, 151);
            this.zapasButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.zapasButton.Name = "zapasButton";
            this.zapasButton.Size = new System.Drawing.Size(113, 57);
            this.zapasButton.TabIndex = 27;
            this.zapasButton.Text = "Hráči    \r\nna zápas ";
            this.zapasButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.zapasButton.UseVisualStyleBackColor = true;
            this.zapasButton.Click += new System.EventHandler(this.ZapasButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Enabled = false;
            this.removeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.removeButton.Image = global::LGR_Futbal.Properties.Resources.Delete;
            this.removeButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.removeButton.Location = new System.Drawing.Point(201, 213);
            this.removeButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(113, 57);
            this.removeButton.TabIndex = 25;
            this.removeButton.Text = "Odstrániť \r\ntím      ";
            this.removeButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // editButton
            // 
            this.editButton.Enabled = false;
            this.editButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.editButton.Image = global::LGR_Futbal.Properties.Resources.Fonts_2;
            this.editButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.editButton.Location = new System.Drawing.Point(201, 90);
            this.editButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(113, 57);
            this.editButton.TabIndex = 24;
            this.editButton.Text = "Zmeniť   \r\núdaje    ";
            this.editButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // addButton
            // 
            this.addButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.addButton.Image = global::LGR_Futbal.Properties.Resources.Add_Folder;
            this.addButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addButton.Location = new System.Drawing.Point(201, 27);
            this.addButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(113, 57);
            this.addButton.TabIndex = 23;
            this.addButton.Text = "Vložiť    \r\nnový tím  ";
            this.addButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // zrusitButton
            // 
            this.zrusitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.zrusitButton.Image = global::LGR_Futbal.Properties.Resources.Stop_2;
            this.zrusitButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.zrusitButton.Location = new System.Drawing.Point(724, 9);
            this.zrusitButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.zrusitButton.Name = "zrusitButton";
            this.zrusitButton.Size = new System.Drawing.Size(106, 52);
            this.zrusitButton.TabIndex = 19;
            this.zrusitButton.Text = "Zatvoriť ";
            this.zrusitButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.zrusitButton.UseVisualStyleBackColor = true;
            this.zrusitButton.Click += new System.EventHandler(this.ZrusitButton_Click);
            // 
            // DatabazaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 432);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.importButton);
            this.Controls.Add(this.zapasButton);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.timyListBox);
            this.Controls.Add(this.infoLabel1);
            this.Controls.Add(this.zrusitButton);
            this.Controls.Add(this.addGroupBox);
            this.Controls.Add(this.editGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DatabazaForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Správa databázy hráčov";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DatabazaForm_KeyDown);
            this.addGroupBox.ResumeLayout(false);
            this.addGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.editGroupBox.ResumeLayout(false);
            this.editGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.editPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button zrusitButton;
        private System.Windows.Forms.Label infoLabel1;
        private System.Windows.Forms.ListBox timyListBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.GroupBox addGroupBox;
        private System.Windows.Forms.Button zmenaObrazkaButton;
        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.TextBox nazovTextBox;
        private System.Windows.Forms.Label infoLabel2;
        private System.Windows.Forms.Button zrusitLogoButton;
        private System.Windows.Forms.Button vlozitButton;
        private System.Windows.Forms.Button zapasButton;
        private System.Windows.Forms.Button spatButton;
        private System.Windows.Forms.GroupBox editGroupBox;
        private System.Windows.Forms.Button editBackButton;
        private System.Windows.Forms.Button editZrusButton;
        private System.Windows.Forms.Button editConfirmButton;
        private System.Windows.Forms.Button editZmenaButton;
        private System.Windows.Forms.PictureBox editPictureBox;
        private System.Windows.Forms.TextBox editNazovTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button editHraciButton;
        private System.Windows.Forms.Button importButton;
        private System.Windows.Forms.Button exportButton;
    }
}