using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp3
{
    public partial class yeniKartEkle : Form
    {
        public yeniKartEkle()
        {
            InitializeComponent();
        }
        private SerialPort serialPort;

        private string MD5_Hesapla (string sifre)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(sifre);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    builder.Append(hashBytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }

        private async void kartOkut_Click(object sender, EventArgs e)
        {
            serialPort = new SerialPort();
            serialPort.PortName = "COM7";
            serialPort.BaudRate = 9600; 
            try
            {
                serialPort.Open();
                MessageBox.Show("RFID okuyucu bağlantısı başarılı. Lütfen kartı okutunuz.");

                // Kart ID verisini asenkron olarak al
                string kartID = await Task.Run(() =>
                {
                    while (true)
                    {
                        try
                        {
                            return serialPort.ReadLine();
                        }
                        catch (TimeoutException)
                        {
                            //  beklemeye devam et
                        }
                    }
                });
                string kartIDNumbers = kartID.Substring(10);
                kartIDNumbers = kartIDNumbers.Trim();   

                textBox1.Invoke(new Action(() => textBox1.Text = kartIDNumbers));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata "+ex.Message);
            }
            finally
            {
                if (serialPort.IsOpen)
                    serialPort.Close();
            }
        }

        private void IptalButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void KaydetButton_Click(object sender, EventArgs e)
        {
            string kartID = textBox1.Text;
            string adSoyad = AdTextBox1.Text;
            string ogrNoText = ogrNoTextBox2.Text;
            string sinif = sinifTextBox3.Text;
            string iletisimNo = iletisimNoTextBox3.Text;

            if (string.IsNullOrWhiteSpace(kartID) || string.IsNullOrWhiteSpace(adSoyad) || string.IsNullOrWhiteSpace(ogrNoText) || string.IsNullOrWhiteSpace(sinif) || string.IsNullOrWhiteSpace(iletisimNo))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.");
                return;
            }

            int ogrNo = 0;
            if (!int.TryParse(ogrNoText, out ogrNo))
            {
                MessageBox.Show("Lütfen geçerli bir öğrenci numarası girin.");
                return;
            }

            int bakiye = 100;
            int gunlukLimit = 100;
            string defaultParola = ogrNoText + iletisimNo.Substring(iletisimNo.Length - 4); ;
            // yeni kayıt eklendiğinde default parola okul numarası + telefon numarasının son 4 hanesi şeklinde ayarlanır.

            string parolaHASH = MD5_Hesapla(defaultParola);


            /*
            int seed = (int)DateTime.Now.Ticks;
            Random random = new Random(seed);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 40; i++)
            {
                char randomChar = (char)random.Next(48, 123);
                sb.Append(randomChar);
            }
            string defaultParola = sb.ToString();
            */




            try
            {
                using (SqlConnection baglanti = new SqlConnection("Server=kantin.database.windows.net;Database=Kantin;User Id=kantinAdmin;Password=kantin123.;"))
                {

                    baglanti.Open();

                    // Kart ID kontrolü
                    string kontrolQuery = "SELECT COUNT(*) FROM tbl_kart WHERE kartID = @kartID";
                    using (SqlCommand kontrolCmd = new SqlCommand(kontrolQuery, baglanti))
                    {
                        kontrolCmd.Parameters.AddWithValue("@kartID", kartID);
                        int kartSayisi = (int)kontrolCmd.ExecuteScalar();

                        if (kartSayisi > 0)
                        {
                            MessageBox.Show("Bu kart ID'si zaten kayıtlı.");
                            return;
                        }
                    }

                    // Kart ve öğrenci bilgilerini ekleme
                    string query1 = "INSERT INTO tbl_kart (kartID, ogrenciNo, bakiye, gunlukLimit) VALUES (@kartID, @ogrNo, @bakiye, @gunlukLimit)";
                    string query2 = "INSERT INTO tbl_ogrenci (ogrenciNo, ogrenciAdSoyad, sinif, parola, iletisimNo) VALUES (@ogrNo, @adSoyad, @sinif, @parolaHASH, @iletisimNo)";

                    using (SqlCommand cmd2 = new SqlCommand(query2, baglanti))
                    {
                        cmd2.Parameters.AddWithValue("@ogrNo", ogrNo);
                        cmd2.Parameters.AddWithValue("@adSoyad", adSoyad);
                        cmd2.Parameters.AddWithValue("@sinif", sinif);
                        cmd2.Parameters.AddWithValue("@parolaHASH", parolaHASH);
                        cmd2.Parameters.AddWithValue("@iletisimNo", iletisimNo);
                        cmd2.ExecuteNonQuery();
                    }

                    using (SqlCommand cmd1 = new SqlCommand(query1, baglanti))
                    {
                        cmd1.Parameters.AddWithValue("@kartID", kartID);
                        cmd1.Parameters.AddWithValue("@ogrNo", ogrNo);
                        cmd1.Parameters.AddWithValue("@bakiye", bakiye);
                        cmd1.Parameters.AddWithValue("@gunlukLimit", gunlukLimit);
                        cmd1.ExecuteNonQuery();
                    }

                    MessageBox.Show("Kayıt başarıyla eklendi.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("SQL Query sırasında hata oluştu! " + ex.ToString());
            }
        }



        private void ogrNoTextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void AdTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            int limit = 50;
            int kalan = limit - AdTextBox1.Text.Length;
            label1.Text = kalan.ToString();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

    }
}
