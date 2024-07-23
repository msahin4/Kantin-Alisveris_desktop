namespace WinFormsApp3
{
    partial class yeniKartEkle
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
            textBox1 = new TextBox();
            kartOkut = new Button();
            AdTextBox1 = new TextBox();
            adLabel = new Label();
            ogrNoLabel = new Label();
            ogrNoTextBox2 = new TextBox();
            sinifTextBox3 = new TextBox();
            sinifLabel = new Label();
            KaydetButton = new Button();
            IptalButton = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            iletisimNoTextBox3 = new TextBox();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.None;
            textBox1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            textBox1.Location = new Point(164, 39);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(187, 29);
            textBox1.TabIndex = 1;
            // 
            // kartOkut
            // 
            kartOkut.Location = new Point(164, 74);
            kartOkut.Name = "kartOkut";
            kartOkut.Size = new Size(187, 29);
            kartOkut.TabIndex = 2;
            kartOkut.Text = "Kartı Okut";
            kartOkut.UseVisualStyleBackColor = true;
            kartOkut.Click += kartOkut_Click;
            // 
            // AdTextBox1
            // 
            AdTextBox1.Location = new Point(164, 163);
            AdTextBox1.MaxLength = 50;
            AdTextBox1.Name = "AdTextBox1";
            AdTextBox1.Size = new Size(187, 23);
            AdTextBox1.TabIndex = 3;
            AdTextBox1.KeyPress += AdTextBox1_KeyPress;
            // 
            // adLabel
            // 
            adLabel.AutoSize = true;
            adLabel.Location = new Point(54, 166);
            adLabel.Name = "adLabel";
            adLabel.Size = new Size(63, 15);
            adLabel.TabIndex = 4;
            adLabel.Text = "Adı Soyadı";
            // 
            // ogrNoLabel
            // 
            ogrNoLabel.AutoSize = true;
            ogrNoLabel.Location = new Point(54, 224);
            ogrNoLabel.Name = "ogrNoLabel";
            ogrNoLabel.Size = new Size(103, 15);
            ogrNoLabel.TabIndex = 5;
            ogrNoLabel.Text = "Öğrenci Numarası";
            // 
            // ogrNoTextBox2
            // 
            ogrNoTextBox2.Location = new Point(164, 221);
            ogrNoTextBox2.MaxLength = 4;
            ogrNoTextBox2.Name = "ogrNoTextBox2";
            ogrNoTextBox2.Size = new Size(187, 23);
            ogrNoTextBox2.TabIndex = 6;
            ogrNoTextBox2.KeyPress += ogrNoTextBox2_KeyPress;
            // 
            // sinifTextBox3
            // 
            sinifTextBox3.Location = new Point(164, 279);
            sinifTextBox3.MaxLength = 2;
            sinifTextBox3.Name = "sinifTextBox3";
            sinifTextBox3.Size = new Size(187, 23);
            sinifTextBox3.TabIndex = 8;
            // 
            // sinifLabel
            // 
            sinifLabel.AutoSize = true;
            sinifLabel.Location = new Point(54, 282);
            sinifLabel.Name = "sinifLabel";
            sinifLabel.Size = new Size(30, 15);
            sinifLabel.TabIndex = 9;
            sinifLabel.Text = "Sınıf";
            // 
            // KaydetButton
            // 
            KaydetButton.Location = new Point(321, 407);
            KaydetButton.Name = "KaydetButton";
            KaydetButton.Size = new Size(85, 38);
            KaydetButton.TabIndex = 10;
            KaydetButton.Text = "Kaydet";
            KaydetButton.UseVisualStyleBackColor = true;
            KaydetButton.Click += KaydetButton_Click;
            // 
            // IptalButton
            // 
            IptalButton.Location = new Point(425, 407);
            IptalButton.Name = "IptalButton";
            IptalButton.Size = new Size(85, 38);
            IptalButton.TabIndex = 11;
            IptalButton.Text = "İptal";
            IptalButton.UseVisualStyleBackColor = true;
            IptalButton.Click += IptalButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.ControlDarkDark;
            label1.Location = new Point(358, 166);
            label1.Name = "label1";
            label1.Size = new Size(19, 15);
            label1.TabIndex = 12;
            label1.Text = "50";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.ControlDarkDark;
            label2.Location = new Point(358, 224);
            label2.Name = "label2";
            label2.Size = new Size(105, 15);
            label2.TabIndex = 13;
            label2.Text = "Sadece sayı giriniz.";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = SystemColors.ControlDarkDark;
            label3.Location = new Point(357, 282);
            label3.Name = "label3";
            label3.Size = new Size(49, 15);
            label3.TabIndex = 14;
            label3.Text = "Ör: \"2B\"";
            // 
            // iletisimNoTextBox3
            // 
            iletisimNoTextBox3.Location = new Point(164, 337);
            iletisimNoTextBox3.MaxLength = 10;
            iletisimNoTextBox3.Name = "iletisimNoTextBox3";
            iletisimNoTextBox3.Size = new Size(187, 23);
            iletisimNoTextBox3.TabIndex = 16;
            iletisimNoTextBox3.KeyPress += textBox3_KeyPress;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(54, 340);
            label4.Name = "label4";
            label4.Size = new Size(64, 15);
            label4.TabIndex = 17;
            label4.Text = "İletişim No";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = SystemColors.ControlDarkDark;
            label5.Location = new Point(358, 340);
            label5.Name = "label5";
            label5.Size = new Size(161, 15);
            label5.TabIndex = 18;
            label5.Text = "Başında sıfır olmadan yazınız.";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label6.Location = new Point(54, 42);
            label6.Name = "label6";
            label6.Size = new Size(79, 21);
            label6.TabIndex = 19;
            label6.Text = "KART ID :";
            // 
            // yeniKartEkle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(522, 457);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(iletisimNoTextBox3);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(IptalButton);
            Controls.Add(KaydetButton);
            Controls.Add(sinifLabel);
            Controls.Add(sinifTextBox3);
            Controls.Add(ogrNoTextBox2);
            Controls.Add(ogrNoLabel);
            Controls.Add(adLabel);
            Controls.Add(AdTextBox1);
            Controls.Add(kartOkut);
            Controls.Add(textBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "yeniKartEkle";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "yeniKartEkle";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBox1;
        private Button kartOkut;
        private TextBox AdTextBox1;
        private Label adLabel;
        private Label ogrNoLabel;
        private TextBox ogrNoTextBox2;
        private TextBox sinifTextBox3;
        private Label sinifLabel;
        private Button KaydetButton;
        private Button IptalButton;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox iletisimNoTextBox3;
        private Label label4;
        private Label label5;
        private Label label6;
    }
}