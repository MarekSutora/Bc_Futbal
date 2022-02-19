namespace LGR_Futbal.Forms
{
    partial class HraciForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HraciForm));
            this.hraciListBox = new System.Windows.Forms.ListBox();
            this.infoLabel1 = new System.Windows.Forms.Label();
            this.addGroupBox = new System.Windows.Forms.GroupBox();
            this.funkcionarCheckBox = new System.Windows.Forms.CheckBox();
            this.nahradnikCheckBox = new System.Windows.Forms.CheckBox();
            this.cisloHracaTextBox = new System.Windows.Forms.TextBox();
            this.zmenaUdajovButton = new System.Windows.Forms.Button();
            this.cervenaKartaCheckBox = new System.Windows.Forms.CheckBox();
            this.zltaKartaCheckBox = new System.Windows.Forms.CheckBox();
            this.zapasCheckBox = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.poznamkaRichTextBox = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.datumPicker = new System.Windows.Forms.DateTimePicker();
            this.postTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.priezviskoTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.menoTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.vlozitButton = new System.Windows.Forms.Button();
            this.spatButton = new System.Windows.Forms.Button();
            this.zrusitObrazokButton = new System.Windows.Forms.Button();
            this.zmenaObrazkaButton = new System.Windows.Forms.Button();
            this.fotkaPictureBox = new System.Windows.Forms.PictureBox();
            this.prestupGroupBox = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.prestupConfirmButton = new System.Windows.Forms.Button();
            this.prestupSpatButton = new System.Windows.Forms.Button();
            this.cieleListBox = new System.Windows.Forms.ListBox();
            this.filterButton = new System.Windows.Forms.Button();
            this.showAllButton = new System.Windows.Forms.Button();
            this.prestupButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.zrusitButton = new System.Windows.Forms.Button();
            this.addGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fotkaPictureBox)).BeginInit();
            this.prestupGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // hraciListBox
            // 
            this.hraciListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.hraciListBox.FormattingEnabled = true;
            this.hraciListBox.ItemHeight = 17;
            this.hraciListBox.Location = new System.Drawing.Point(9, 29);
            this.hraciListBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.hraciListBox.Name = "hraciListBox";
            this.hraciListBox.Size = new System.Drawing.Size(189, 378);
            this.hraciListBox.TabIndex = 24;
            this.hraciListBox.SelectedIndexChanged += new System.EventHandler(this.HraciListBox_SelectedIndexChanged);
            this.hraciListBox.DoubleClick += new System.EventHandler(this.hraciListBox_DoubleClick);
            // 
            // infoLabel1
            // 
            this.infoLabel1.AutoSize = true;
            this.infoLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.infoLabel1.Location = new System.Drawing.Point(9, 10);
            this.infoLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.infoLabel1.Name = "infoLabel1";
            this.infoLabel1.Size = new System.Drawing.Size(106, 17);
            this.infoLabel1.TabIndex = 23;
            this.infoLabel1.Text = "Zoznam hráčov";
            // 
            // addGroupBox
            // 
            this.addGroupBox.BackColor = System.Drawing.SystemColors.Control;
            this.addGroupBox.Controls.Add(this.funkcionarCheckBox);
            this.addGroupBox.Controls.Add(this.nahradnikCheckBox);
            this.addGroupBox.Controls.Add(this.cisloHracaTextBox);
            this.addGroupBox.Controls.Add(this.zmenaUdajovButton);
            this.addGroupBox.Controls.Add(this.cervenaKartaCheckBox);
            this.addGroupBox.Controls.Add(this.zltaKartaCheckBox);
            this.addGroupBox.Controls.Add(this.zapasCheckBox);
            this.addGroupBox.Controls.Add(this.label9);
            this.addGroupBox.Controls.Add(this.poznamkaRichTextBox);
            this.addGroupBox.Controls.Add(this.label8);
            this.addGroupBox.Controls.Add(this.label5);
            this.addGroupBox.Controls.Add(this.datumPicker);
            this.addGroupBox.Controls.Add(this.postTextBox);
            this.addGroupBox.Controls.Add(this.label4);
            this.addGroupBox.Controls.Add(this.label3);
            this.addGroupBox.Controls.Add(this.priezviskoTextBox);
            this.addGroupBox.Controls.Add(this.label2);
            this.addGroupBox.Controls.Add(this.menoTextBox);
            this.addGroupBox.Controls.Add(this.label1);
            this.addGroupBox.Controls.Add(this.vlozitButton);
            this.addGroupBox.Controls.Add(this.spatButton);
            this.addGroupBox.Controls.Add(this.zrusitObrazokButton);
            this.addGroupBox.Controls.Add(this.zmenaObrazkaButton);
            this.addGroupBox.Controls.Add(this.fotkaPictureBox);
            this.addGroupBox.Location = new System.Drawing.Point(318, 29);
            this.addGroupBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.addGroupBox.Name = "addGroupBox";
            this.addGroupBox.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.addGroupBox.Size = new System.Drawing.Size(401, 393);
            this.addGroupBox.TabIndex = 32;
            this.addGroupBox.TabStop = false;
            this.addGroupBox.Text = "Vloženie nového hráča";
            this.addGroupBox.Visible = false;
            // 
            // funkcionarCheckBox
            // 
            this.funkcionarCheckBox.AutoSize = true;
            this.funkcionarCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.funkcionarCheckBox.Location = new System.Drawing.Point(8, 255);
            this.funkcionarCheckBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.funkcionarCheckBox.Name = "funkcionarCheckBox";
            this.funkcionarCheckBox.Size = new System.Drawing.Size(97, 21);
            this.funkcionarCheckBox.TabIndex = 76;
            this.funkcionarCheckBox.Text = "Funkcionár";
            this.funkcionarCheckBox.UseVisualStyleBackColor = true;
            // 
            // nahradnikCheckBox
            // 
            this.nahradnikCheckBox.AutoSize = true;
            this.nahradnikCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nahradnikCheckBox.Location = new System.Drawing.Point(8, 231);
            this.nahradnikCheckBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.nahradnikCheckBox.Name = "nahradnikCheckBox";
            this.nahradnikCheckBox.Size = new System.Drawing.Size(92, 21);
            this.nahradnikCheckBox.TabIndex = 71;
            this.nahradnikCheckBox.Text = "Náhradník";
            this.nahradnikCheckBox.UseVisualStyleBackColor = true;
            // 
            // cisloHracaTextBox
            // 
            this.cisloHracaTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cisloHracaTextBox.Location = new System.Drawing.Point(133, 19);
            this.cisloHracaTextBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cisloHracaTextBox.Name = "cisloHracaTextBox";
            this.cisloHracaTextBox.Size = new System.Drawing.Size(134, 23);
            this.cisloHracaTextBox.TabIndex = 70;
            // 
            // zmenaUdajovButton
            // 
            this.zmenaUdajovButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.zmenaUdajovButton.Image = global::LGR_Futbal.Properties.Resources.Rename___Edit;
            this.zmenaUdajovButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.zmenaUdajovButton.Location = new System.Drawing.Point(269, 335);
            this.zmenaUdajovButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.zmenaUdajovButton.Name = "zmenaUdajovButton";
            this.zmenaUdajovButton.Size = new System.Drawing.Size(118, 52);
            this.zmenaUdajovButton.TabIndex = 69;
            this.zmenaUdajovButton.Text = "Uložiť     \r\nzmeny    ";
            this.zmenaUdajovButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.zmenaUdajovButton.UseVisualStyleBackColor = true;
            this.zmenaUdajovButton.Click += new System.EventHandler(this.ZmenaUdajovButton_Click);
            // 
            // cervenaKartaCheckBox
            // 
            this.cervenaKartaCheckBox.AutoSize = true;
            this.cervenaKartaCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cervenaKartaCheckBox.Location = new System.Drawing.Point(8, 305);
            this.cervenaKartaCheckBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cervenaKartaCheckBox.Name = "cervenaKartaCheckBox";
            this.cervenaKartaCheckBox.Size = new System.Drawing.Size(116, 21);
            this.cervenaKartaCheckBox.TabIndex = 68;
            this.cervenaKartaCheckBox.Text = "Červená karta";
            this.cervenaKartaCheckBox.UseVisualStyleBackColor = true;
            // 
            // zltaKartaCheckBox
            // 
            this.zltaKartaCheckBox.AutoSize = true;
            this.zltaKartaCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.zltaKartaCheckBox.Location = new System.Drawing.Point(8, 280);
            this.zltaKartaCheckBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.zltaKartaCheckBox.Name = "zltaKartaCheckBox";
            this.zltaKartaCheckBox.Size = new System.Drawing.Size(87, 21);
            this.zltaKartaCheckBox.TabIndex = 67;
            this.zltaKartaCheckBox.Text = "Žltá karta";
            this.zltaKartaCheckBox.UseVisualStyleBackColor = true;
            // 
            // zapasCheckBox
            // 
            this.zapasCheckBox.AutoSize = true;
            this.zapasCheckBox.Checked = true;
            this.zapasCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.zapasCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.zapasCheckBox.Location = new System.Drawing.Point(8, 205);
            this.zapasCheckBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.zapasCheckBox.Name = "zapasCheckBox";
            this.zapasCheckBox.Size = new System.Drawing.Size(92, 21);
            this.zapasCheckBox.TabIndex = 66;
            this.zapasCheckBox.Text = "Hrá zápas";
            this.zapasCheckBox.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label9.Location = new System.Drawing.Point(5, 374);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 13);
            this.label9.TabIndex = 63;
            this.label9.Text = "* povinné údaje";
            // 
            // poznamkaRichTextBox
            // 
            this.poznamkaRichTextBox.Location = new System.Drawing.Point(132, 153);
            this.poznamkaRichTextBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.poznamkaRichTextBox.Name = "poznamkaRichTextBox";
            this.poznamkaRichTextBox.Size = new System.Drawing.Size(134, 179);
            this.poznamkaRichTextBox.TabIndex = 51;
            this.poznamkaRichTextBox.Text = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.Location = new System.Drawing.Point(5, 153);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 17);
            this.label8.TabIndex = 50;
            this.label8.Text = "Iné záznamy:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(5, 130);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 17);
            this.label5.TabIndex = 41;
            this.label5.Text = "Dátum narodenia:";
            // 
            // datumPicker
            // 
            this.datumPicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.datumPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datumPicker.Location = new System.Drawing.Point(132, 126);
            this.datumPicker.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.datumPicker.Name = "datumPicker";
            this.datumPicker.Size = new System.Drawing.Size(134, 23);
            this.datumPicker.TabIndex = 40;
            // 
            // postTextBox
            // 
            this.postTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.postTextBox.Location = new System.Drawing.Point(132, 99);
            this.postTextBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.postTextBox.Name = "postTextBox";
            this.postTextBox.Size = new System.Drawing.Size(134, 23);
            this.postTextBox.TabIndex = 39;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(5, 103);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 17);
            this.label4.TabIndex = 38;
            this.label4.Text = "Post:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(5, 75);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 17);
            this.label3.TabIndex = 36;
            this.label3.Text = "Priezvisko (*):";
            // 
            // priezviskoTextBox
            // 
            this.priezviskoTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.priezviskoTextBox.Location = new System.Drawing.Point(132, 72);
            this.priezviskoTextBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.priezviskoTextBox.Name = "priezviskoTextBox";
            this.priezviskoTextBox.Size = new System.Drawing.Size(134, 23);
            this.priezviskoTextBox.TabIndex = 35;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(5, 48);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 17);
            this.label2.TabIndex = 34;
            this.label2.Text = "Meno (*):";
            // 
            // menoTextBox
            // 
            this.menoTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.menoTextBox.Location = new System.Drawing.Point(132, 45);
            this.menoTextBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.menoTextBox.Name = "menoTextBox";
            this.menoTextBox.Size = new System.Drawing.Size(134, 23);
            this.menoTextBox.TabIndex = 33;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(5, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 17);
            this.label1.TabIndex = 31;
            this.label1.Text = "Číslo hráča:";
            // 
            // vlozitButton
            // 
            this.vlozitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.vlozitButton.Image = global::LGR_Futbal.Properties.Resources.Add_Card;
            this.vlozitButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.vlozitButton.Location = new System.Drawing.Point(269, 335);
            this.vlozitButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.vlozitButton.Name = "vlozitButton";
            this.vlozitButton.Size = new System.Drawing.Size(118, 52);
            this.vlozitButton.TabIndex = 30;
            this.vlozitButton.Text = "Vložiť     \r\nhráča     ";
            this.vlozitButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.vlozitButton.UseVisualStyleBackColor = true;
            this.vlozitButton.Click += new System.EventHandler(this.VlozitButton_Click);
            // 
            // spatButton
            // 
            this.spatButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.spatButton.Image = global::LGR_Futbal.Properties.Resources.Back_2;
            this.spatButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.spatButton.Location = new System.Drawing.Point(132, 335);
            this.spatButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.spatButton.Name = "spatButton";
            this.spatButton.Size = new System.Drawing.Size(133, 52);
            this.spatButton.TabIndex = 29;
            this.spatButton.Text = "Späť       ";
            this.spatButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.spatButton.UseVisualStyleBackColor = true;
            this.spatButton.Click += new System.EventHandler(this.SpatButton_Click);
            // 
            // zrusitObrazokButton
            // 
            this.zrusitObrazokButton.Location = new System.Drawing.Point(269, 188);
            this.zrusitObrazokButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.zrusitObrazokButton.Name = "zrusitObrazokButton";
            this.zrusitObrazokButton.Size = new System.Drawing.Size(118, 30);
            this.zrusitObrazokButton.TabIndex = 28;
            this.zrusitObrazokButton.Text = "Zrušiť fotografiu";
            this.zrusitObrazokButton.UseVisualStyleBackColor = true;
            this.zrusitObrazokButton.Click += new System.EventHandler(this.ZrusitObrazokButton_Click);
            // 
            // zmenaObrazkaButton
            // 
            this.zmenaObrazkaButton.Location = new System.Drawing.Point(269, 153);
            this.zmenaObrazkaButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.zmenaObrazkaButton.Name = "zmenaObrazkaButton";
            this.zmenaObrazkaButton.Size = new System.Drawing.Size(118, 30);
            this.zmenaObrazkaButton.TabIndex = 27;
            this.zmenaObrazkaButton.Text = "Zmeniť fotografiu";
            this.zmenaObrazkaButton.UseVisualStyleBackColor = true;
            this.zmenaObrazkaButton.Click += new System.EventHandler(this.ZmenaObrazkaButton_Click);
            // 
            // fotkaPictureBox
            // 
            this.fotkaPictureBox.Location = new System.Drawing.Point(269, 20);
            this.fotkaPictureBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.fotkaPictureBox.Name = "fotkaPictureBox";
            this.fotkaPictureBox.Size = new System.Drawing.Size(118, 127);
            this.fotkaPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.fotkaPictureBox.TabIndex = 26;
            this.fotkaPictureBox.TabStop = false;
            // 
            // prestupGroupBox
            // 
            this.prestupGroupBox.BackColor = System.Drawing.SystemColors.Control;
            this.prestupGroupBox.Controls.Add(this.label10);
            this.prestupGroupBox.Controls.Add(this.prestupConfirmButton);
            this.prestupGroupBox.Controls.Add(this.prestupSpatButton);
            this.prestupGroupBox.Controls.Add(this.cieleListBox);
            this.prestupGroupBox.Location = new System.Drawing.Point(318, 29);
            this.prestupGroupBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.prestupGroupBox.Name = "prestupGroupBox";
            this.prestupGroupBox.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.prestupGroupBox.Size = new System.Drawing.Size(401, 393);
            this.prestupGroupBox.TabIndex = 34;
            this.prestupGroupBox.TabStop = false;
            this.prestupGroupBox.Text = "Prestup hráča";
            this.prestupGroupBox.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label10.Location = new System.Drawing.Point(5, 20);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(205, 17);
            this.label10.TabIndex = 32;
            this.label10.Text = "Zoznam možných nových tímov";
            // 
            // prestupConfirmButton
            // 
            this.prestupConfirmButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.prestupConfirmButton.Image = global::LGR_Futbal.Properties.Resources.Attach;
            this.prestupConfirmButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.prestupConfirmButton.Location = new System.Drawing.Point(269, 17);
            this.prestupConfirmButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.prestupConfirmButton.Name = "prestupConfirmButton";
            this.prestupConfirmButton.Size = new System.Drawing.Size(118, 52);
            this.prestupConfirmButton.TabIndex = 31;
            this.prestupConfirmButton.Text = "Presunúť  \r\nhráča     ";
            this.prestupConfirmButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.prestupConfirmButton.UseVisualStyleBackColor = true;
            this.prestupConfirmButton.Click += new System.EventHandler(this.PrestupConfirmButton_Click);
            // 
            // prestupSpatButton
            // 
            this.prestupSpatButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.prestupSpatButton.Image = global::LGR_Futbal.Properties.Resources.Back_2;
            this.prestupSpatButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.prestupSpatButton.Location = new System.Drawing.Point(269, 79);
            this.prestupSpatButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.prestupSpatButton.Name = "prestupSpatButton";
            this.prestupSpatButton.Size = new System.Drawing.Size(118, 52);
            this.prestupSpatButton.TabIndex = 30;
            this.prestupSpatButton.Text = "Späť     ";
            this.prestupSpatButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.prestupSpatButton.UseVisualStyleBackColor = true;
            this.prestupSpatButton.Click += new System.EventHandler(this.PrestupSpatButton_Click);
            // 
            // cieleListBox
            // 
            this.cieleListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cieleListBox.FormattingEnabled = true;
            this.cieleListBox.ItemHeight = 17;
            this.cieleListBox.Location = new System.Drawing.Point(8, 42);
            this.cieleListBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cieleListBox.Name = "cieleListBox";
            this.cieleListBox.Size = new System.Drawing.Size(257, 344);
            this.cieleListBox.TabIndex = 25;
            // 
            // filterButton
            // 
            this.filterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.filterButton.Image = global::LGR_Futbal.Properties.Resources.Favourites;
            this.filterButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.filterButton.Location = new System.Drawing.Point(201, 339);
            this.filterButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.filterButton.Name = "filterButton";
            this.filterButton.Size = new System.Drawing.Size(113, 57);
            this.filterButton.TabIndex = 36;
            this.filterButton.Text = "Zápasový\r\nfilter    ";
            this.filterButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.filterButton.UseVisualStyleBackColor = true;
            this.filterButton.Click += new System.EventHandler(this.filterButton_Click);
            // 
            // showAllButton
            // 
            this.showAllButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.showAllButton.Image = global::LGR_Futbal.Properties.Resources.Browse_11;
            this.showAllButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.showAllButton.Location = new System.Drawing.Point(201, 276);
            this.showAllButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.showAllButton.Name = "showAllButton";
            this.showAllButton.Size = new System.Drawing.Size(113, 57);
            this.showAllButton.TabIndex = 35;
            this.showAllButton.Text = "Zobraziť \r\ncelý tím  ";
            this.showAllButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.showAllButton.UseVisualStyleBackColor = true;
            this.showAllButton.Click += new System.EventHandler(this.showAllButton_Click);
            // 
            // prestupButton
            // 
            this.prestupButton.Enabled = false;
            this.prestupButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.prestupButton.Image = global::LGR_Futbal.Properties.Resources.Publish;
            this.prestupButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.prestupButton.Location = new System.Drawing.Point(201, 152);
            this.prestupButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.prestupButton.Name = "prestupButton";
            this.prestupButton.Size = new System.Drawing.Size(113, 57);
            this.prestupButton.TabIndex = 31;
            this.prestupButton.Text = "Prestup do\r\niného tímu";
            this.prestupButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.prestupButton.UseVisualStyleBackColor = true;
            this.prestupButton.Click += new System.EventHandler(this.PrestupButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Enabled = false;
            this.removeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.removeButton.Image = global::LGR_Futbal.Properties.Resources.Cut;
            this.removeButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.removeButton.Location = new System.Drawing.Point(201, 214);
            this.removeButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(113, 57);
            this.removeButton.TabIndex = 30;
            this.removeButton.Text = "Odstrániť \r\nhráča    ";
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
            this.editButton.TabIndex = 29;
            this.editButton.Text = "Zmeniť   \r\núdaje    ";
            this.editButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // addButton
            // 
            this.addButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.addButton.Image = global::LGR_Futbal.Properties.Resources.List;
            this.addButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addButton.Location = new System.Drawing.Point(201, 29);
            this.addButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(113, 57);
            this.addButton.TabIndex = 28;
            this.addButton.Text = "Pridať   \r\nhráča   ";
            this.addButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // zrusitButton
            // 
            this.zrusitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.zrusitButton.Image = global::LGR_Futbal.Properties.Resources.Stop_2;
            this.zrusitButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.zrusitButton.Location = new System.Drawing.Point(724, 10);
            this.zrusitButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.zrusitButton.Name = "zrusitButton";
            this.zrusitButton.Size = new System.Drawing.Size(106, 52);
            this.zrusitButton.TabIndex = 22;
            this.zrusitButton.Text = "Zatvoriť ";
            this.zrusitButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.zrusitButton.UseVisualStyleBackColor = true;
            this.zrusitButton.Click += new System.EventHandler(this.ZrusitButton_Click);
            // 
            // HraciForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 432);
            this.Controls.Add(this.filterButton);
            this.Controls.Add(this.showAllButton);
            this.Controls.Add(this.prestupButton);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.hraciListBox);
            this.Controls.Add(this.infoLabel1);
            this.Controls.Add(this.zrusitButton);
            this.Controls.Add(this.addGroupBox);
            this.Controls.Add(this.prestupGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HraciForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Evidencia hráčov";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HraciForm_KeyDown);
            this.addGroupBox.ResumeLayout(false);
            this.addGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fotkaPictureBox)).EndInit();
            this.prestupGroupBox.ResumeLayout(false);
            this.prestupGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox hraciListBox;
        private System.Windows.Forms.Label infoLabel1;
        private System.Windows.Forms.Button zrusitButton;
        private System.Windows.Forms.Button prestupButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.GroupBox addGroupBox;
        private System.Windows.Forms.Button zrusitObrazokButton;
        private System.Windows.Forms.Button zmenaObrazkaButton;
        private System.Windows.Forms.PictureBox fotkaPictureBox;
        private System.Windows.Forms.Button spatButton;
        private System.Windows.Forms.Button vlozitButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox priezviskoTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox menoTextBox;
        private System.Windows.Forms.TextBox postTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker datumPicker;
        private System.Windows.Forms.RichTextBox poznamkaRichTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox prestupGroupBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button prestupConfirmButton;
        private System.Windows.Forms.Button prestupSpatButton;
        private System.Windows.Forms.ListBox cieleListBox;
        private System.Windows.Forms.CheckBox cervenaKartaCheckBox;
        private System.Windows.Forms.CheckBox zltaKartaCheckBox;
        private System.Windows.Forms.CheckBox zapasCheckBox;
        private System.Windows.Forms.Button zmenaUdajovButton;
        private System.Windows.Forms.TextBox cisloHracaTextBox;
        private System.Windows.Forms.Button showAllButton;
        private System.Windows.Forms.Button filterButton;
        private System.Windows.Forms.CheckBox funkcionarCheckBox;
        private System.Windows.Forms.CheckBox nahradnikCheckBox;
    }
}