using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp3
{
    public partial class urunEkle : Form
    {
        public urunEkle()
        {
            InitializeComponent();
        }

        private void urunEkleIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int limit = 50;
            int kalan = limit - textBox1.Text.Length;
            labelSayac1.Text = kalan.ToString();

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            int limit = 50;
            int kalan = limit - textBox2.Text.Length;
            labelSayac2.Text = kalan.ToString();

        }

        private void urunEkle_Load(object sender, EventArgs e)
        {

        }

        private void urunEkleKaydet_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir kategori seçin.");
                return;
            }

            string kategori = comboBox1.SelectedItem.ToString();
            int kategoriID;

            switch (kategori)
            {
                case "Yiyecek":
                    kategoriID = 1;
                    break;
                case "İçecek":
                    kategoriID = 2;
                    break;
                case "Atıştırmalık":
                    kategoriID = 3;
                    break;
                case "Kırtasiye":
                    kategoriID = 4;
                    break;
                default:
                    kategoriID = 5;
                    break;
            }

            string marka = textBox1.Text.Trim();
            string urunAdi = textBox2.Text.Trim();
            int fiyat;

            if (string.IsNullOrEmpty(urunAdi))
            {
                MessageBox.Show("Ürün adı alanları boş bırakılamaz.");
                return;
            }

            if (!int.TryParse(textBox3.Text.Trim(), out fiyat))
            {
                MessageBox.Show("Lütfen geçerli bir fiyat girin.");
                return;
            }

            try
            {
                using (SqlConnection baglanti = new SqlConnection("Server=kantin.database.windows.net;Database=Kantin;User Id=kantinAdmin;Password=kantin123.;"))
                {
                    baglanti.Open();

                    string query = "INSERT INTO tbl_urunler (kategoriID, marka, urunAdi, fiyat) VALUES (@kategoriID, @marka, @urunAdi, @fiyat)";

                    using (SqlCommand cmd = new SqlCommand(query, baglanti))
                    {
                        cmd.Parameters.AddWithValue("@kategoriID", kategoriID);
                        cmd.Parameters.AddWithValue("@marka", marka);
                        cmd.Parameters.AddWithValue("@urunAdi", urunAdi);
                        cmd.Parameters.AddWithValue("@fiyat", fiyat);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Ürün başarıyla eklendi.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("SQL Query sırasında hata oluştu! " + ex.ToString());
            }
        }

    }
}