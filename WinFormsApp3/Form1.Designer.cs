namespace WinFormsApp3
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            urunSil = new Button();
            listeSil = new Button();
            satisYap = new Button();
            toplamTutarTextBox = new TextBox();
            gecmisSatislar = new Button();
            yiyeceklerListView = new ListView();
            yenile = new Button();
            iceceklerListView = new ListView();
            atistirmalikListView = new ListView();
            kirtasiyeListView = new ListView();
            satisaGonder2 = new Button();
            listView1 = new ListView();
            urunAdı = new ColumnHeader();
            fiyat = new ColumnHeader();
            urunEkleButton = new Button();
            fiyatGuncelleButton = new Button();
            digerListView = new ListView();
            urunSilButton = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            yeniKartButton = new Button();
            kayitSilButton = new Button();
            SuspendLayout();
            // 
            // urunSil
            // 
            urunSil.Location = new Point(306, 55);
            urunSil.Name = "urunSil";
            urunSil.Size = new Size(113, 42);
            urunSil.TabIndex = 0;
            urunSil.Text = "Ürünü Sil";
            urunSil.UseVisualStyleBackColor = true;
            urunSil.Click += urunSil_Click;
            // 
            // listeSil
            // 
            listeSil.Location = new Point(306, 103);
            listeSil.Name = "listeSil";
            listeSil.Size = new Size(113, 42);
            listeSil.TabIndex = 1;
            listeSil.Text = "Listeyi Temizle";
            listeSil.UseVisualStyleBackColor = true;
            listeSil.Click += listeSil_Click;
            // 
            // satisYap
            // 
            satisYap.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            satisYap.Location = new Point(306, 200);
            satisYap.Name = "satisYap";
            satisYap.Size = new Size(113, 86);
            satisYap.TabIndex = 3;
            satisYap.Text = "SATIŞ";
            satisYap.UseVisualStyleBackColor = true;
            satisYap.Click += satisYap_Click;
            // 
            // toplamTutarTextBox
            // 
            toplamTutarTextBox.Location = new Point(14, 263);
            toplamTutarTextBox.Name = "toplamTutarTextBox";
            toplamTutarTextBox.ReadOnly = true;
            toplamTutarTextBox.Size = new Size(286, 23);
            toplamTutarTextBox.TabIndex = 9;
            // 
            // gecmisSatislar
            // 
            gecmisSatislar.Location = new Point(727, 55);
            gecmisSatislar.Name = "gecmisSatislar";
            gecmisSatislar.Size = new Size(177, 36);
            gecmisSatislar.TabIndex = 12;
            gecmisSatislar.Text = "Geçmiş Satışlar";
            gecmisSatislar.UseVisualStyleBackColor = true;
            gecmisSatislar.Click += gecmisSatislar_Click;
            // 
            // yiyeceklerListView
            // 
            yiyeceklerListView.FullRowSelect = true;
            yiyeceklerListView.Location = new Point(23, 349);
            yiyeceklerListView.Name = "yiyeceklerListView";
            yiyeceklerListView.Size = new Size(170, 208);
            yiyeceklerListView.TabIndex = 13;
            yiyeceklerListView.UseCompatibleStateImageBehavior = false;
            yiyeceklerListView.View = View.Details;
            // 
            // yenile
            // 
            yenile.Location = new Point(727, 250);
            yenile.Name = "yenile";
            yenile.Size = new Size(177, 36);
            yenile.TabIndex = 14;
            yenile.Text = "Yenile";
            yenile.UseVisualStyleBackColor = true;
            yenile.Click += yenile_Click;
            // 
            // iceceklerListView
            // 
            iceceklerListView.FullRowSelect = true;
            iceceklerListView.Location = new Point(199, 349);
            iceceklerListView.Name = "iceceklerListView";
            iceceklerListView.Size = new Size(170, 208);
            iceceklerListView.TabIndex = 15;
            iceceklerListView.UseCompatibleStateImageBehavior = false;
            iceceklerListView.View = View.Details;
            // 
            // atistirmalikListView
            // 
            atistirmalikListView.FullRowSelect = true;
            atistirmalikListView.Location = new Point(375, 349);
            atistirmalikListView.Name = "atistirmalikListView";
            atistirmalikListView.Size = new Size(170, 208);
            atistirmalikListView.TabIndex = 16;
            atistirmalikListView.UseCompatibleStateImageBehavior = false;
            atistirmalikListView.View = View.Details;
            // 
            // kirtasiyeListView
            // 
            kirtasiyeListView.FullRowSelect = true;
            kirtasiyeListView.Location = new Point(551, 349);
            kirtasiyeListView.Name = "kirtasiyeListView";
            kirtasiyeListView.Size = new Size(170, 208);
            kirtasiyeListView.TabIndex = 17;
            kirtasiyeListView.UseCompatibleStateImageBehavior = false;
            kirtasiyeListView.View = View.Details;
            // 
            // satisaGonder2
            // 
            satisaGonder2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            satisaGonder2.Location = new Point(23, 576);
            satisaGonder2.Name = "satisaGonder2";
            satisaGonder2.Size = new Size(874, 76);
            satisaGonder2.TabIndex = 18;
            satisaGonder2.Text = "Satışa Gönder";
            satisaGonder2.UseVisualStyleBackColor = true;
            satisaGonder2.Click += satisaGonder2_Click;
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { urunAdı, fiyat });
            listView1.FullRowSelect = true;
            listView1.Location = new Point(14, 55);
            listView1.Name = "listView1";
            listView1.Size = new Size(286, 202);
            listView1.TabIndex = 19;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // urunAdı
            // 
            urunAdı.Text = "Ürün Adı";
            urunAdı.Width = 90;
            // 
            // fiyat
            // 
            fiyat.Text = "Fiyat";
            fiyat.Width = 50;
            // 
            // urunEkleButton
            // 
            urunEkleButton.Location = new Point(727, 97);
            urunEkleButton.Name = "urunEkleButton";
            urunEkleButton.Size = new Size(177, 36);
            urunEkleButton.TabIndex = 20;
            urunEkleButton.Text = "Ürün Ekle";
            urunEkleButton.UseVisualStyleBackColor = true;
            urunEkleButton.Click += urunEkleButton_Click;
            // 
            // fiyatGuncelleButton
            // 
            fiyatGuncelleButton.Location = new Point(727, 139);
            fiyatGuncelleButton.Name = "fiyatGuncelleButton";
            fiyatGuncelleButton.Size = new Size(177, 36);
            fiyatGuncelleButton.TabIndex = 21;
            fiyatGuncelleButton.Text = "Fiyat Güncelle";
            fiyatGuncelleButton.UseVisualStyleBackColor = true;
            fiyatGuncelleButton.Click += fiyatGuncelleButton_Click;
            // 
            // digerListView
            // 
            digerListView.Location = new Point(727, 349);
            digerListView.Name = "digerListView";
            digerListView.Size = new Size(170, 208);
            digerListView.TabIndex = 22;
            digerListView.UseCompatibleStateImageBehavior = false;
            // 
            // urunSilButton
            // 
            urunSilButton.Location = new Point(544, 55);
            urunSilButton.Name = "urunSilButton";
            urunSilButton.Size = new Size(177, 36);
            urunSilButton.TabIndex = 23;
            urunSilButton.Text = "Ürün Sil";
            urunSilButton.UseVisualStyleBackColor = true;
            urunSilButton.Click += urunSilButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(83, 324);
            label1.Name = "label1";
            label1.Size = new Size(60, 15);
            label1.TabIndex = 24;
            label1.Text = "Yiyecekler";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(256, 324);
            label2.Name = "label2";
            label2.Size = new Size(53, 15);
            label2.TabIndex = 26;
            label2.Text = "İçecekler";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(422, 324);
            label3.Name = "label3";
            label3.Size = new Size(80, 15);
            label3.TabIndex = 27;
            label3.Text = "Atıştırmalıklar";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(617, 324);
            label4.Name = "label4";
            label4.Size = new Size(51, 15);
            label4.TabIndex = 28;
            label4.Text = "Kırtasiye";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(799, 324);
            label5.Name = "label5";
            label5.Size = new Size(35, 15);
            label5.TabIndex = 29;
            label5.Text = "Diğer";
            // 
            // yeniKartButton
            // 
            yeniKartButton.Location = new Point(544, 97);
            yeniKartButton.Name = "yeniKartButton";
            yeniKartButton.Size = new Size(177, 36);
            yeniKartButton.TabIndex = 32;
            yeniKartButton.Text = "Yeni Kayıt Ekle";
            yeniKartButton.UseVisualStyleBackColor = true;
            yeniKartButton.Click += yeniKartButton_Click;
            // 
            // kayitSilButton
            // 
            kayitSilButton.Location = new Point(544, 139);
            kayitSilButton.Name = "kayitSilButton";
            kayitSilButton.Size = new Size(177, 36);
            kayitSilButton.TabIndex = 33;
            kayitSilButton.Text = "Kayıt Sil";
            kayitSilButton.UseVisualStyleBackColor = true;
            kayitSilButton.Click += kayitSilButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(909, 688);
            Controls.Add(kayitSilButton);
            Controls.Add(yeniKartButton);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(urunSilButton);
            Controls.Add(digerListView);
            Controls.Add(fiyatGuncelleButton);
            Controls.Add(urunEkleButton);
            Controls.Add(listView1);
            Controls.Add(satisaGonder2);
            Controls.Add(kirtasiyeListView);
            Controls.Add(atistirmalikListView);
            Controls.Add(iceceklerListView);
            Controls.Add(yenile);
            Controls.Add(yiyeceklerListView);
            Controls.Add(gecmisSatislar);
            Controls.Add(toplamTutarTextBox);
            Controls.Add(satisYap);
            Controls.Add(listeSil);
            Controls.Add(urunSil);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 162);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Satış Ekranı";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button urunSil;
        private Button listeSil;
        private Button satisYap;
        private TextBox toplamTutarTextBox;
        private Button gecmisSatislar;
        private ListView yiyeceklerListView;
        private Button yenile;
        private ListView iceceklerListView;
        private ListView atistirmalikListView;
        private ListView kirtasiyeListView;
        private Button satisaGonder2;
        private ListView listView1;
        private ColumnHeader urunAdı;
        private ColumnHeader fiyat;
        private Button urunEkleButton;
        private Button fiyatGuncelleButton;
        private ListView digerListView;
        private Button urunSilButton;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button yeniKartButton;
        private Button kayitSilButton;
    }
}
