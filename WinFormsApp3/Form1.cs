using System;
using System.Data;
using System.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.VisualBasic;
using System.Text.RegularExpressions;
using System.IO.Ports;
using System.Diagnostics.Metrics;
using System.Security.AccessControl;
namespace WinFormsApp3
{
    public partial class Form1 : Form
    {
        //private string connectionString = "Data Source=DESKTOP-TN16GPU;Initial Catalog=Kantin;Integrated Security=True";
        private SqlConnection baglanti; 
        private int toplamTutar = 0;
        private SerialPort serialPort;

        public Form1()
        {
            InitializeComponent();


        }



        private void Form1_Load(object sender, EventArgs e)
        {
            dbConnection();
            if (baglanti != null && baglanti.State == ConnectionState.Open)
            {
                LoadYiyecekler();
                LoadIcecekler();
                LoadAtistirmalik();
                LoadKirtasiye();
                LoadDiger();
                baglanti.Close(); // Form yüklenmesi tamamlandýktan sonra baðlantýyý kapat
                toplamTutarTextBox.Text = "Toplam Tutar = " + toplamTutar.ToString() + " \u20BA";
            }
            else
            {
                MessageBox.Show("Baðlantý oluþturulamadý veya açýlamadý.");
            }

        }






        private void LoadYiyecekler()
        {

            LoadListView(1, yiyeceklerListView);//Yiyecek kategoriID=1
        }

        private void LoadIcecekler()
        {

            LoadListView(2, iceceklerListView);//Ýçecek kategoriID=2
        }
        private void LoadAtistirmalik()
        {

            LoadListView(3, atistirmalikListView);//Atýþtýrmalýk kategoriID=3
        }

        private void LoadKirtasiye()
        {

            LoadListView(4, kirtasiyeListView);//Kýrtasiye kategoriID=4

        }

        private void LoadDiger()
        {
            LoadListView(5, digerListView);
        }




        private void LoadListView(int kategoriID, ListView listView)
        {
            try
            {
                string query = $"SELECT urunAdi, fiyat FROM tbl_urunler WHERE kategoriID = {kategoriID}";
                SqlCommand command = new SqlCommand(query, baglanti);
                SqlDataReader reader = command.ExecuteReader();

                listView.Items.Clear(); 
                listView.View = View.Details; 

                // Sütunlarý oluþtur
                listView.Columns.Clear();
                listView.Columns.Add("Ürün Adý", 90);
                listView.Columns.Add("Fiyat", 50);

                while (reader.Read())
                {
                    ListViewItem item = new ListViewItem(reader["urunAdi"].ToString());
                    item.SubItems.Add(reader["fiyat"].ToString() + " \u20BA"); 
                    listView.Items.Add(item);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Verileri yükleme sýrasýnda bir hata oluþtu: " + ex.ToString());
            }
        }



        private void dbConnection()
        {
            try
            {
                //baglanti = new SqlConnection("local");
                baglanti = new SqlConnection(/*cloud*/  /* AZURE baglantı adresı */);

                baglanti.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("SQL Query sýrasýnda hata oluþtu !" + ex.ToString());
            }
        }



        //


        private void urunSil_Click(object sender, EventArgs e)
        {
            if ((listView1.SelectedItems.Count != 0) && (listView1.Items.Count != 0))
            {
                string silinenUrunFiyati = listView1.SelectedItems[0].SubItems[1].Text;
                string silinenUrunFiyati2 = silinenUrunFiyati.Remove(silinenUrunFiyati.Length - 2);
                int silinecekTutar = int.Parse(silinenUrunFiyati2);
                toplamTutar = toplamTutar - silinecekTutar;
                toplamTutarTextBox.Text = "Toplam Tutar = " + toplamTutar.ToString() + " \u20BA";
                listView1.Items.Remove(listView1.SelectedItems[0]);


            }
            else
            {
                MessageBox.Show("Listeden silmek istediðiniz öðeyi seçiniz.", "HATA");
            }
        }

        private void listeSil_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            toplamTutar = 0;
            toplamTutarTextBox.Text = "Toplam Tutar = " + toplamTutar.ToString() + " \u20BA";
        }



        private void gecmisSatislar_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                string query = "select * from tbl_satis";
                SqlCommand command = new SqlCommand(query, baglanti);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                Form2 form2 = new Form2(dataTable);
                form2.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                if (baglanti.State == ConnectionState.Open)
                    baglanti.Close();
            }
        }


        private void yenile_Click(object sender, EventArgs e)
        {
            dbConnection();
            if (baglanti != null && baglanti.State == ConnectionState.Open)
            {
                LoadYiyecekler();
                LoadIcecekler();
                LoadAtistirmalik();
                LoadKirtasiye();
                LoadDiger();
                baglanti.Close();
            }
            else
            {
                MessageBox.Show("Baðlantý oluþturulamadý veya açýlamadý.");
            }
        }

        private void SatisListesineEkle(ListView sourceListView)
        {

            foreach (ListViewItem selectedItem in sourceListView.SelectedItems)
            {
                string urunAdi = selectedItem.SubItems[0].Text;
                string urunFiyati = selectedItem.SubItems[1].Text;


                ListViewItem satisItem = new ListViewItem(urunAdi);
                satisItem.SubItems.Add(urunFiyati);

                listView1.Items.Add(satisItem);
                string urunFiyati2 = urunFiyati.Remove(urunFiyati.Length - 2);
                int eklenecekTutar = int.Parse(urunFiyati2);
                toplamTutar += eklenecekTutar;
                toplamTutarTextBox.Text = "Toplam Tutar = " + toplamTutar.ToString() + " \u20BA";
            }

            sourceListView.SelectedItems.Clear();
        }

        private void satisaGonder2_Click(object sender, EventArgs e)
        {
            if (yiyeceklerListView.SelectedItems.Count != 0)
            {
                SatisListesineEkle(yiyeceklerListView);
            }

            if (iceceklerListView.SelectedItems.Count != 0)
            {
                SatisListesineEkle(iceceklerListView);
            }

            if (atistirmalikListView.SelectedItems.Count != 0)
            {
                SatisListesineEkle(atistirmalikListView);
            }

            if (kirtasiyeListView.SelectedItems.Count != 0)
            {
                SatisListesineEkle(kirtasiyeListView);
            }
            if (digerListView.SelectedItems.Count != 0)
            {
                SatisListesineEkle(digerListView);
            }
        }

        private void urunEkleButton_Click(object sender, EventArgs e)
        {
            urunEkle urunEkle = new urunEkle();
            urunEkle.Show();
            object urunBilgi = urunEkle;

        }

        private void fiyatGuncelleButton_Click(object sender, EventArgs e)
        {
            int secilenUrunSayisi = yiyeceklerListView.SelectedItems.Count + iceceklerListView.SelectedItems.Count +
                                    atistirmalikListView.SelectedItems.Count + kirtasiyeListView.SelectedItems.Count + digerListView.SelectedItems.Count;

            if (secilenUrunSayisi == 0)
            {
                MessageBox.Show("Lütfen bir ürün seçiniz.");
            }
            else if (secilenUrunSayisi == 1)
            {
                ListViewItem secilenUrun;
                if (yiyeceklerListView.SelectedItems.Count > 0)
                    secilenUrun = yiyeceklerListView.SelectedItems[0];
                else if (iceceklerListView.SelectedItems.Count > 0)
                    secilenUrun = iceceklerListView.SelectedItems[0];
                else if (atistirmalikListView.SelectedItems.Count > 0)
                    secilenUrun = atistirmalikListView.SelectedItems[0];
                else if (kirtasiyeListView.SelectedItems.Count > 0)
                    secilenUrun = kirtasiyeListView.SelectedItems[0];
                else
                    secilenUrun = digerListView.SelectedItems[0];

                string urunAdi = secilenUrun.SubItems[0].Text;

                string yeniFiyat = Interaction.InputBox("Ürünün yeni fiyatýný giriniz", "Fiyat Güncelleme");

                bool sayiMi = double.TryParse(yeniFiyat, out double yeniFiyat2);
                if (sayiMi)
                {
                    dbConnection();
                    string query = "UPDATE tbl_urunler SET fiyat = @yeniFiyat WHERE urunAdi = @urunAdi";
                    using (SqlCommand cmd = new SqlCommand(query, baglanti))
                    {
                        cmd.Parameters.AddWithValue("@yeniFiyat", yeniFiyat2);
                        cmd.Parameters.AddWithValue("@urunAdi", urunAdi);
                        cmd.ExecuteNonQuery();
                    }
                    baglanti.Close();
                    MessageBox.Show("Fiyat baþarýyla güncellendi.");
                }
                else
                {
                    MessageBox.Show("Hatalý bir deðer girdiniz. Lütfen tekrar deneyin.");
                }
            }
            else
            {
                MessageBox.Show("Fiyat güncellemek için yalnýzca bir ürün seçmelisiniz.");
            }
        }

        private void urunSilButton_Click(object sender, EventArgs e)
        {
            int secilenUrunSayisi = yiyeceklerListView.SelectedItems.Count + iceceklerListView.SelectedItems.Count +
                                     atistirmalikListView.SelectedItems.Count + kirtasiyeListView.SelectedItems.Count + digerListView.SelectedItems.Count;

            if (secilenUrunSayisi == 0)
            {
                MessageBox.Show("Lütfen bir ürün seçiniz.");
            }
            else if (secilenUrunSayisi == 1)
            {
                ListViewItem secilenUrun;
                if (yiyeceklerListView.SelectedItems.Count > 0)
                    secilenUrun = yiyeceklerListView.SelectedItems[0];
                else if (iceceklerListView.SelectedItems.Count > 0)
                    secilenUrun = iceceklerListView.SelectedItems[0];
                else if (atistirmalikListView.SelectedItems.Count > 0)
                    secilenUrun = atistirmalikListView.SelectedItems[0];
                else if (kirtasiyeListView.SelectedItems.Count > 0)
                    secilenUrun = kirtasiyeListView.SelectedItems[0];
                else
                    secilenUrun = digerListView.SelectedItems[0];

                string urunAdi = secilenUrun.SubItems[0].Text;
                dbConnection();
                string query = "DELETE FROM tbl_urunler WHERE urunAdi=@urunAdi";

                using (SqlCommand command = new SqlCommand(query, baglanti))
                {
                    command.Parameters.AddWithValue("@urunAdi", urunAdi);
                    try
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Ürün baþarýyla silindi.");
                        secilenUrun.Remove();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Ürün silinirken bir hata oluþtu: " + ex.Message);
                    }
                }
                baglanti.Close();
            }
            else
            {
                MessageBox.Show("Silmek için yalnýzca bir ürün seçmelisiniz.");
            }
        }



        private void yeniKartButton_Click(object sender, EventArgs e)
        {
            yeniKartEkle yeniKartEkle = new yeniKartEkle();
            yeniKartEkle.Show();
        }

        private void kayitSilButton_Click(object sender, EventArgs e)
        {
            string ogrNo = Interaction.InputBox("Kaydýný silmek istediðiniz öðrencinin numarasýný giriniz.\nDÝKKAT ! Öðrencinin geçmiþ alýþveriþ bilgileri ve kart bilgileri de silinecektir.", "Kayýt Sil");
            bool sayiMi = true;
            ogrNo = ogrNo.Trim();
            foreach (char karakter in ogrNo)
            {
                if (!Char.IsDigit(karakter))
                {
                    sayiMi = false;
                    break;
                }
            }
            if (sayiMi)
            {
                dbConnection();

                try
                {
                    string queryKart = "SELECT kartID FROM tbl_kart WHERE ogrenciNo=@ogrNo";
                    SqlCommand komut = new SqlCommand(queryKart, baglanti);
                    komut.Parameters.AddWithValue("@ogrNo", ogrNo);

                    SqlDataReader reader = komut.ExecuteReader();
                    string kartID = "";

                    if (reader.Read())
                    {
                        kartID = reader["kartID"].ToString();
                        reader.Close(); 

                        string selectSatisIDQuery = "SELECT satisID FROM tbl_satis WHERE kartID=@kartID";
                        SqlCommand selectSatisIDCmd = new SqlCommand(selectSatisIDQuery, baglanti);
                        selectSatisIDCmd.Parameters.AddWithValue("@kartID", kartID);

                        DataTable satisIDTable = new DataTable();
                        using (SqlDataAdapter adapter = new SqlDataAdapter(selectSatisIDCmd))
                        {
                            adapter.Fill(satisIDTable);
                        }

                        string deleteSatisDetayQuery = "DELETE FROM tbl_satisDetaylari WHERE satisID=@satisID";
                        SqlCommand deleteSatisDetayCmd = new SqlCommand(deleteSatisDetayQuery, baglanti);

                        foreach (DataRow row in satisIDTable.Rows)
                        {
                            deleteSatisDetayCmd.Parameters.Clear();
                            deleteSatisDetayCmd.Parameters.AddWithValue("@satisID", row["satisID"]);
                            deleteSatisDetayCmd.ExecuteNonQuery();
                        }

                        string query1 = "DELETE FROM tbl_satis WHERE kartID=@kartID";
                        string query2 = "DELETE FROM tbl_kart WHERE kartID=@kartID";
                        string query3 = "DELETE FROM tbl_ogrenci WHERE ogrenciNo=@ogrNo";

                        SqlCommand deleteSatis = new SqlCommand(query1, baglanti);
                        deleteSatis.Parameters.AddWithValue("@kartID", kartID);
                        deleteSatis.ExecuteNonQuery();

                        SqlCommand deleteKart = new SqlCommand(query2, baglanti);
                        deleteKart.Parameters.AddWithValue("@kartID", kartID);
                        deleteKart.ExecuteNonQuery();

                        SqlCommand deleteOgrenci = new SqlCommand(query3, baglanti);
                        deleteOgrenci.Parameters.AddWithValue("@ogrNo", ogrNo);
                        deleteOgrenci.ExecuteNonQuery();

                        MessageBox.Show("Öðrenci kaydý baþarýyla silindi.");
                    }
                    else
                    {
                        MessageBox.Show("Belirtilen öðrenci numarasýyla eþleþen bir kart bulunamadý.");
                        reader.Close(); 
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("SQL sorgusu sýrasýnda hata oluþtu! " + ex.ToString());
                }
                finally
                {
                    baglanti.Close();
                }
            }
            else
            {
                MessageBox.Show("Girdi rakam dýþýnda karakterler içeriyor.");
            }
        }



        private async void satisYap_Click(object sender, EventArgs e)
        {
            string kartIDNumbers = ""; 
            DateTime dateTime = DateTime.Now;
            if (listView1.Items.Count == 0)
            {
                MessageBox.Show("Satýþ ekraný boþ. Lütfen ürün ekleyin.");
            }
            else
            {
                ////////////////////////
                ///
                serialPort = new SerialPort();
                serialPort.PortName = "COM7";
                serialPort.BaudRate = 9600;
                try
                {
                    serialPort.Open();
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
                                // Zaman aþýmý durumunda beklemeye devam et
                            }
                        }
                    });
                    kartIDNumbers = kartID.Substring(10);
                    kartIDNumbers = kartIDNumbers.Trim();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Baðlantý hatasý: " + ex.Message);
                }
                finally
                {
                    if (serialPort.IsOpen)
                        serialPort.Close();
                }
                ////////////////////////////////////////////////////////////////////////////////////

                dbConnection(); 

                string query1 = "SELECT bakiye from tbl_kart where kartID = @kartIDNumbers";
                string query2 = "SELECT gunlukLimit from tbl_kart WHERE kartID = @kartIDNumbers";
                string query3 = "SELECT SUM(tutar) FROM tbl_satis WHERE kartID = @kartIDNumbers AND tarih >= CONVERT(date, GETDATE())";

                int bakiye = 0;
                int gunlukLimit = 0;
                int gunlukToplam = 0;

                try
                {
                    // Bakiye sorgusu
                    using (SqlCommand command1 = new SqlCommand(query1, baglanti))
                    {
                        command1.Parameters.AddWithValue("@kartIDNumbers", kartIDNumbers);

                        using (SqlDataReader reader = command1.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                bakiye = reader.GetInt32(0); 
                            }
                        }
                    }

                    // Günlük limit sorgusu
                    using (SqlCommand command2 = new SqlCommand(query2, baglanti))
                    {
                        command2.Parameters.AddWithValue("@kartIDNumbers", kartIDNumbers);

                        using (SqlDataReader reader = command2.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                gunlukLimit = reader.GetInt32(0); 
                            }
                        }
                    }

                    // Günlük toplam sorgusu
                    using (SqlCommand command3 = new SqlCommand(query3, baglanti))
                    {
                        command3.Parameters.AddWithValue("@kartIDNumbers", kartIDNumbers);

                        // Gün içindeki diðer satýþlarýn toplamý
                        object result = command3.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            gunlukToplam = Convert.ToInt32(result);
                        }
                    }

                    // Sonuçlarý yazdýrma
                    //MessageBox.Show("Bakiye: " + bakiye + "\nGünlük Limit: " + gunlukLimit);

                    if (toplamTutar <= bakiye)
                    {
                        if (toplamTutar + gunlukToplam <= gunlukLimit)
                        {
                            MessageBox.Show("Satýþ iþlemi baþarýlý.");
                            int yeniBakiye = bakiye - toplamTutar;
                            
                            dbConnection();

                            string queryBakiyeGuncelle = "UPDATE tbl_kart SET bakiye = @yeniBakiye WHERE kartID=@kartIDNumbers";
                            using (SqlCommand commandBakiye = new SqlCommand(queryBakiyeGuncelle, baglanti))
                            {
                                commandBakiye.Parameters.AddWithValue("@yeniBakiye", yeniBakiye);
                                commandBakiye.Parameters.AddWithValue("@kartIDNumbers", kartIDNumbers);

                                try
                                {
                                    commandBakiye.ExecuteNonQuery();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Bir hata oluþtu: " + ex.Message);
                                }
                            }

                            string querySatis = "INSERT INTO tbl_satis (kartID, tutar, tarih) VALUES (@kartID, @toplamTutar, @dateTime)";
                            using (SqlCommand commandSatis = new SqlCommand(querySatis, baglanti))
                            {
                                commandSatis.Parameters.AddWithValue("@kartID", kartIDNumbers);
                                commandSatis.Parameters.AddWithValue("@toplamTutar", toplamTutar);
                                commandSatis.Parameters.AddWithValue("@dateTime", dateTime);

                                try
                                {
                                    commandSatis.ExecuteNonQuery();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Bir hata oluþtu: " + ex.Message);
                                }
                            }
                            satisDetayKayit(dateTime);
                        }
                        else
                        {
                            MessageBox.Show("SATIÞ BAÞARISIZ.\nToplam tutar günlük bakiye limitinin üzerinde.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("SATIÞ BAÞARISIZ.\nBakiye Yetersiz.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata oluþtu: " + ex.Message);
                }
                finally
                {
                    if (baglanti != null && baglanti.State == System.Data.ConnectionState.Open)
                    {
                        baglanti.Close(); // Baðlantýyý kapat
                    }
                }
            }


            ///////////////////////////////////////////////////////////////////// satýþ detay kayýt
            //

            
            




/////////////////////////////////////////////////////////////////////
            //listView1.Clear();

        }
        private void satisDetayKayit(DateTime dateTime)
        {
            dbConnection();
            string query = "select satisID from tbl_satis where tarih = @dateTime";
            int satisID = 0;

            try
            {
                using (SqlCommand cmd = new SqlCommand(query, baglanti))
                {
                    cmd.Parameters.AddWithValue("@dateTime", dateTime);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            if (int.TryParse(reader["satisID"].ToString(), out int id))
                            {
                                satisID = id;
                            }
                            else
                            {
                                MessageBox.Show("satisID deðeri geçersiz.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabaný sorgusu sýrasýnda hata oluþtu! " + ex.ToString());
            }
            finally
            {
                if (baglanti != null && baglanti.State == System.Data.ConnectionState.Open)
                {
                    baglanti.Close();
                }
            }

            //MessageBox.Show(satisID.ToString());


            foreach (ListViewItem item in listView1.Items)
            {
                string urunAdi = item.SubItems[0].Text;
                string urunFiyat = item.SubItems[1].Text; 
                dbConnection();

                string queryID = "select urunID from tbl_urunler where urunAdi = @urunAdi";
                int urunID = 0;

                try
                {
                    using (SqlCommand cmd = new SqlCommand(queryID, baglanti))
                    {
                        cmd.Parameters.AddWithValue("@urunAdi", urunAdi);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                if (int.TryParse(reader["urunID"].ToString(), out int id))
                                {
                                    urunID = id;
                                }
                                else
                                {
                                    MessageBox.Show("urunID deðeri geçersiz.");
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabaný sorgusu sýrasýnda hata oluþtu! " + ex.ToString());
                }
                finally
                {
                    if (baglanti != null && baglanti.State == System.Data.ConnectionState.Open)
                    {
                        baglanti.Close();
                    }
                }

                if (urunID != 0)
                {
                    dbConnection();
                    string queryDetayKayit = "INSERT INTO tbl_satisDetaylari (satisID, urunID, birimFiyat) values (@satisID, @urunID, @urunFiyat)";

                    try
                    {
                        using (SqlCommand cmd = new SqlCommand(queryDetayKayit, baglanti))
                        {
                            cmd.Parameters.AddWithValue("@satisID", satisID);
                            cmd.Parameters.AddWithValue("@urunID", urunID);
                            cmd.Parameters.AddWithValue("@urunFiyat", urunFiyat); 

                            cmd.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Satýþ detay kaydý sýrasýnda hata oluþtu! " + ex.ToString());
                    }
                    finally
                    {
                        if (baglanti != null && baglanti.State == System.Data.ConnectionState.Open)
                        {
                            baglanti.Close();
                        }
                    }
                }
            }
        }




    }

}
/*
foreach (ListViewItem item in listView1.Items)
{
    string urunAdi = item.SubItems[0].Text;
    string urunFiyat = item.SubItems[1].Text;







    string queryDetay = "";
}
*/
