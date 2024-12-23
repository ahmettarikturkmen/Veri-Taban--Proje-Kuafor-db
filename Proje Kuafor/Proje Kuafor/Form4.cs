using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proje_Kuafor
{
    public partial class Form4 : Form
    {
        private string _baglantiString = "Host=localhost;Port=5432;Username=postgres;Password=161616;Database=KuaforSistemi2";
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void iletisimListele_Click(object sender, EventArgs e)
        {
            IletisimBilgileriListele();
        }

        private void IletisimBilgileriListele()
        {
            // Veritabanına bağlanma
            using (var baglanti = new NpgsqlConnection(_baglantiString))
            {
                try
                {
                    baglanti.Open();
                    string sql = "SELECT * FROM IletisimBilgileri"; // İletişim Bilgileri tablosunun tüm sütunlarını seçmek için *

                    using (var komut = new NpgsqlCommand(sql, baglanti))
                    {
                        using (var reader = komut.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader); // Veriyi DataTable'a yükleyelim
                            dataGridView1.DataSource = dt; // DataGridView'e yükleyelim
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private void btnİletisimEkle_Click(object sender, EventArgs e)
        {
            // Kullanıcıdan alınan veriler
            int kisiID = int.Parse(txtİletisimKisiId.Text); // Kişi ID'si
            string telefon = txtTelefon.Text;      // Telefon
            string eposta = txtEposta.Text;        // E-posta
            string adres = txtİletisimAdres.Text;          // Adres

            // Veritabanına veri ekleme
            IletisimBilgileriEkle(kisiID, telefon, eposta, adres);
        }

        private void IletisimBilgileriEkle(int kisiID, string telefon, string eposta, string adres)
        {
            using (var baglanti = new NpgsqlConnection(_baglantiString))
            {
                try
                {
                    baglanti.Open();
                    string sql = "INSERT INTO IletisimBilgileri (kisiID, telefon, eposta, adres) VALUES (@kisiID, @telefon, @eposta, @adres)";
                    using (var komut = new NpgsqlCommand(sql, baglanti))
                    {
                        komut.Parameters.AddWithValue("kisiID", kisiID);
                        komut.Parameters.AddWithValue("telefon", telefon);
                        komut.Parameters.AddWithValue("eposta", eposta);
                        komut.Parameters.AddWithValue("adres", adres);
                        komut.ExecuteNonQuery();
                        MessageBox.Show("İletişim bilgileri başarıyla eklendi.");
                        IletisimBilgileriListele(); // Ekleme işleminden sonra listeyi yenileyin
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message + "\n\nDetaylar: " + ex.StackTrace);
                }
            }
        }

        private void btnİletisimSil_Click(object sender, EventArgs e)
        {
            // DataGridView'de seçili satırdan iletisimID'yi alalım
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Seçilen satırdaki iletisimID'yi alıyoruz
                int iletisimID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["iletisimID"].Value); // "iletisimID" sütunun adını kullanın

                // İletişim bilgisini veritabanından silme
                IletisimBilgileriSil(iletisimID);
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz iletişim bilgisini seçin.");
            }
        }

        private void IletisimBilgileriSil(int iletisimID)
        {
            // Veritabanına bağlanma
            using (var baglanti = new NpgsqlConnection(_baglantiString))
            {
                try
                {
                    baglanti.Open();
                    string sql = "DELETE FROM IletisimBilgileri WHERE iletisimID = @iletisimID"; // Tabloya göre sorgu

                    using (var komut = new NpgsqlCommand(sql, baglanti))
                    {
                        // Parametre ile iletişim bilgisini silme
                        komut.Parameters.AddWithValue("iletisimID", iletisimID);

                        int sonuc = komut.ExecuteNonQuery();

                        if (sonuc > 0)
                        {
                            MessageBox.Show("İletişim bilgisi başarıyla silindi.");
                            IletisimBilgileriListele(); // Silme işleminden sonra listeyi yenileyin
                        }
                        else
                        {
                            MessageBox.Show("Silme işlemi başarısız.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private void btnİletisimGuncelle_Click(object sender, EventArgs e)
        {
            // DataGridView'de seçili satırdan iletisimID'yi alalım
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Seçilen satırdaki iletisimID ve diğer verileri alıyoruz
                int iletisimID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["iletisimID"].Value); // "iletisimID" sütunun adını kullanın
                string yeniTelefon = txtTelefon.Text; // TextBox'tan alınan yeni telefon
                string yeniEposta = txtEposta.Text;   // TextBox'tan alınan yeni e-posta
                string yeniAdres = txtİletisimAdres.Text;     // TextBox'tan alınan yeni adres

                // Veritabanındaki kaydı güncelleme
                IletisimBilgileriGuncelle(iletisimID, yeniTelefon, yeniEposta, yeniAdres);
            }
            else
            {
                MessageBox.Show("Lütfen güncellemek istediğiniz iletişim bilgisini seçin.");
            }
        }

        private void IletisimBilgileriGuncelle(int iletisimID, string yeniTelefon, string yeniEposta, string yeniAdres)
        {
            // Veritabanına bağlanma
            using (var baglanti = new NpgsqlConnection(_baglantiString))
            {
                try
                {
                    baglanti.Open();
                    string sql = "UPDATE IletisimBilgileri SET telefon = @yeniTelefon, eposta = @yeniEposta, adres = @yeniAdres WHERE iletisimID = @iletisimID"; // Tabloya göre sorgu

                    using (var komut = new NpgsqlCommand(sql, baglanti))
                    {
                        // Parametreler ile veriyi güncelleme
                        komut.Parameters.AddWithValue("iletisimID", iletisimID);
                        komut.Parameters.AddWithValue("yeniTelefon", yeniTelefon);
                        komut.Parameters.AddWithValue("yeniEposta", yeniEposta);
                        komut.Parameters.AddWithValue("yeniAdres", yeniAdres);

                        int sonuc = komut.ExecuteNonQuery();

                        if (sonuc > 0)
                        {
                            MessageBox.Show("İletişim bilgisi başarıyla güncellendi.");
                            IletisimBilgileriListele(); // Güncelleme işleminden sonra listeyi yenileyin
                        }
                        else
                        {
                            MessageBox.Show("Güncelleme işlemi başarısız.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private void btnİletisimAra_Click(object sender, EventArgs e)
        {
            int kisiID;

            // Kullanıcıdan alınan kisiID değerinin doğruluğunu kontrol edelim
            if (int.TryParse(txtİletisimKisiId.Text, out kisiID))
            {
                IletisimBilgileriAra(kisiID); // Arama işlemini başlat
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir KisiID girin.");
            }
        }

        private void IletisimBilgileriAra(int kisiID)
        {
            // Veritabanına bağlanma
            using (var baglanti = new NpgsqlConnection(_baglantiString))
            {
                try
                {
                    baglanti.Open();
                    string sql = "SELECT iletisimid, kisiid, telefon, eposta, adres FROM IletisimBilgileri WHERE kisiid = @kisiID"; // KisiID ile eşleşen kayıtları bulma

                    using (var komut = new NpgsqlCommand(sql, baglanti))
                    {
                        // Parametreyi ekleyerek arama yapıyoruz
                        komut.Parameters.AddWithValue("kisiID", kisiID);

                        using (var reader = komut.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader); // Veriyi DataTable'a yükleyelim
                            dataGridView1.DataSource = dt; // DataGridView'e yükleyelim
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Tıklanan satırın index kontrolü
            if (e.RowIndex >= 0) // Geçerli bir satır mı
            {
                DataGridViewRow satir = dataGridView1.Rows[e.RowIndex]; // Seçili satırı al

                // TextBox'lara değerleri aktar

                txtİletisimKisiId.Text = satir.Cells["kisiid"].Value.ToString();
                txtTelefon.Text = satir.Cells["telefon"].Value.ToString();
                txtEposta.Text = satir.Cells["eposta"].Value.ToString();
                txtİletisimAdres.Text = satir.Cells["adres"].Value.ToString();
            }
        }
    }
}
