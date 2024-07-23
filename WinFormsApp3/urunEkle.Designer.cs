namespace WinFormsApp3
{
    partial class urunEkle
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
            urunEkleKaydet = new Button();
            urunEkleIptal = new Button();
            comboBox1 = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            labelSayac1 = new Label();
            labelSayac2 = new Label();
            label5 = new Label();
            SuspendLayout();
            // 
            // urunEkleKaydet
            // 
            urunEkleKaydet.Location = new Point(258, 240);
            urunEkleKaydet.Name = "urunEkleKaydet";
            urunEkleKaydet.Size = new Size(88, 32);
            urunEkleKaydet.TabIndex = 0;
            urunEkleKaydet.Text = "Kaydet";
            urunEkleKaydet.UseVisualStyleBackColor = true;
            urunEkleKaydet.Click += urunEkleKaydet_Click;
            // 
            // urunEkleIptal
            // 
            urunEkleIptal.Location = new Point(352, 240);
            urunEkleIptal.Name = "urunEkleIptal";
            urunEkleIptal.Size = new Size(88, 32);
            urunEkleIptal.TabIndex = 1;
            urunEkleIptal.Text = "İptal";
            urunEkleIptal.UseVisualStyleBackColor = true;
            urunEkleIptal.Click += urunEkleIptal_Click;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Yiyecek", "İçecek", "Atıştırmalık", "Kırtasiye", "Diğer" });
            comboBox1.Location = new Point(139, 77);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(207, 23);
            comboBox1.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(67, 80);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 6;
            label1.Text = "Kategori";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(78, 109);
            label2.Name = "label2";
            label2.Size = new Size(40, 15);
            label2.TabIndex = 7;
            label2.Text = "Marka";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(64, 138);
            label3.Name = "label3";
            label3.Size = new Size(54, 15);
            label3.TabIndex = 8;
            label3.Text = "Ürün Adı";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(86, 167);
            label4.Name = "label4";
            label4.Size = new Size(32, 15);
            label4.TabIndex = 9;
            label4.Text = "Fiyat";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(139, 106);
            textBox1.MaxLength = 50;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(207, 23);
            textBox1.TabIndex = 10;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(139, 135);
            textBox2.MaxLength = 50;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(207, 23);
            textBox2.TabIndex = 11;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(139, 164);
            textBox3.MaxLength = 3;
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(207, 23);
            textBox3.TabIndex = 12;
            textBox3.KeyPress += textBox3_KeyPress;
            // 
            // labelSayac1
            // 
            labelSayac1.AutoSize = true;
            labelSayac1.Font = new Font("Segoe UI", 8F);
            labelSayac1.ForeColor = SystemColors.ControlDarkDark;
            labelSayac1.Location = new Point(352, 111);
            labelSayac1.Name = "labelSayac1";
            labelSayac1.Size = new Size(19, 13);
            labelSayac1.TabIndex = 13;
            labelSayac1.Text = "50";
            // 
            // labelSayac2
            // 
            labelSayac2.AutoSize = true;
            labelSayac2.Font = new Font("Segoe UI", 8.25F);
            labelSayac2.ForeColor = SystemColors.ControlDarkDark;
            labelSayac2.Location = new Point(352, 139);
            labelSayac2.Name = "labelSayac2";
            labelSayac2.Size = new Size(19, 13);
            labelSayac2.TabIndex = 14;
            labelSayac2.Text = "50";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 8F);
            label5.ForeColor = SystemColors.ControlDarkDark;
            label5.Location = new Point(352, 169);
            label5.Name = "label5";
            label5.Size = new Size(103, 13);
            label5.TabIndex = 15;
            label5.Text = "Sadece sayı giriniz.";
            // 
            // urunEkle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(459, 284);
            Controls.Add(label5);
            Controls.Add(labelSayac2);
            Controls.Add(labelSayac1);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Controls.Add(urunEkleIptal);
            Controls.Add(urunEkleKaydet);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "urunEkle";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ürün Ekle";
            Load += urunEkle_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button urunEkleKaydet;
        private Button urunEkleIptal;
        private ComboBox comboBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private Label labelSayac1;
        private Label labelSayac2;
        private Label label5;
    }
}