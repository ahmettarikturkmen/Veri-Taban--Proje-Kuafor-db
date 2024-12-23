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
    public partial class Form5 : Form
    {
        private string _baglantiString = "Host=localhost;Port=5432;Username=postgres;Password=161616;Database=KuaforSistemi2";
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            dtpRandevuTarihi.Format = DateTimePickerFormat.Custom;
            dtpRandevuTarihi.CustomFormat = "dd/MM/yyyy HH:mm"; // Tarih ve saat formatı
            dtpRandevuTarihi.ShowUpDown = true; // Takvim yerine yukarı-aşağı okları gösterir

            
        }

        private void btnRandevuListele_Click(object sender, EventArgs e)
        {
            RandevularListele();
        }

        private void RandevularListele()
        {
            // Veritabanına bağlanma
            using (var baglanti = new NpgsqlConnection(_baglantiString))
            {
                try
                {
                    baglanti.Open();
                    string sql = "SELECT * FROM Randevu"; // Tüm sütunları seçmek için *

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

        private void btnRandevuEkle_Click(object sender, EventArgs e)
        {
            // Kullanıcıdan alınan veriler
            int musteriKisiID = int.Parse(txtMusteriKisiId.Text);  // Müşteri ID
            int berberKisiID = int.Parse(txtKuaforKisiId.Text);    // Berber ID
            int subeID = int.Parse(txtSubeId.Text);                // Şube ID
            int? kampanyaID = string.IsNullOrWhiteSpace(txtKampanyaId.Text) ? (int?)null : int.Parse(txtKampanyaId.Text); // Kampanya ID (boşsa null olacak)
            DateTime randevuTarihi = dtpRandevuTarihi.Value;       // Randevu Tarihi
            int hizmetID = int.Parse(txtHizmetID.Text);            // Hizmet ID

            // Veritabanına veri ekleme
            RandevuEkle(musteriKisiID, berberKisiID, subeID, kampanyaID, randevuTarihi, hizmetID);
        }

        private void RandevuEkle(int musteriKisiID, int berberKisiID, int subeID, int? kampanyaID, DateTime randevuTarihi, int hizmetID)
        {
            using (var baglanti = new NpgsqlConnection(_baglantiString))
            {
                try
                {
                    baglanti.Open();
                    string sql = "INSERT INTO randevu (musteriKisiID, berberKisiID, subeID, kampanyaID, randevuTarihi, hizmetID) " +
                                 "VALUES (@musteriKisiID, @berberKisiID, @subeID, @kampanyaID, @randevuTarihi, @hizmetID)";
                    using (var komut = new NpgsqlCommand(sql, baglanti))
                    {
                        komut.Parameters.AddWithValue("musteriKisiID", musteriKisiID);
                        komut.Parameters.AddWithValue("berberKisiID", berberKisiID);
                        komut.Parameters.AddWithValue("subeID", subeID);
                        komut.Parameters.AddWithValue("kampanyaID", (object)kampanyaID ?? DBNull.Value); // Eğer kampanyaID null ise DBNull.Value olarak ekle
                        komut.Parameters.AddWithValue("randevuTarihi", randevuTarihi);
                        komut.Parameters.AddWithValue("hizmetID", hizmetID);
                        komut.ExecuteNonQuery();
                        MessageBox.Show("Randevu başarıyla eklendi.");
                        RandevularListele(); // Ekleme işleminden sonra listeyi yenileyin
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message + "\n\nDetaylar: " + ex.StackTrace);
                }
            }
        }

        private void btnRandevuSil_Click(object sender, EventArgs e)
        {
            // DataGridView'de seçili satırdan RandevuID'yi alalım
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Seçilen satırdaki randevuid'yi alıyoruz
                int randevuID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["randevuID"].Value); // "randevuID" sütunun adını kullanın

                // Randevuyu veritabanından silme
                RandevuSil(randevuID);
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz randevuyu seçin.");
            }
        }

        private void RandevuSil(int randevuID)
        {
            // Veritabanına bağlanma
            using (var baglanti = new NpgsqlConnection(_baglantiString))
            {
                try
                {
                    baglanti.Open();
                    string sql = "DELETE FROM randevu WHERE randevuID = @randevuID"; // Tabloya göre sorgu

                    using (var komut = new NpgsqlCommand(sql, baglanti))
                    {
                        // Parametre ile randevuyu silme
                        komut.Parameters.AddWithValue("randevuID", randevuID);

                        int sonuc = komut.ExecuteNonQuery();

                        if (sonuc > 0)
                        {
                            MessageBox.Show("Randevu başarıyla silindi.");
                            RandevularListele(); // Silme işleminden sonra listeyi yenileyin
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

        private void btnRandevuGuncelle_Click(object sender, EventArgs e)
        {
            // DataGridView'de seçili satırdan RandevuID'yi alalım
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Seçilen satırdaki randevuid'yi ve diğer verileri alıyoruz
                int randevuID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["randevuID"].Value); // "randevuID" sütunun adını kullanın
                int musteriKisiID = int.Parse(txtMusteriKisiId.Text);  // TextBox'tan alınan yeni müşteri ID
                int berberKisiID = int.Parse(txtKuaforKisiId.Text);    // TextBox'tan alınan yeni berber ID
                int subeID = int.Parse(txtSubeId.Text);                // TextBox'tan alınan yeni şube ID
                int? kampanyaID = string.IsNullOrWhiteSpace(txtKampanyaId.Text) ? (int?)null : int.Parse(txtKampanyaId.Text); // Kampanya ID (boşsa null olacak)
                DateTime randevuTarihi = dtpRandevuTarihi.Value;       // DateTimePicker'dan alınan yeni randevu tarihi
                int hizmetID = int.Parse(txtHizmetID.Text);            // TextBox'tan alınan yeni hizmet ID

                // Veritabanındaki kaydı güncelleme
                RandevuGuncelle(randevuID, musteriKisiID, berberKisiID, subeID, kampanyaID, randevuTarihi, hizmetID);
            }
            else
            {
                MessageBox.Show("Lütfen güncellemek istediğiniz randevuyu seçin.");
            }
        }

        private void RandevuGuncelle(int randevuID, int musteriKisiID, int berberKisiID, int subeID, int? kampanyaID, DateTime randevuTarihi, int hizmetID)
        {
            // Veritabanına bağlanma
            using (var baglanti = new NpgsqlConnection(_baglantiString))
            {
                try
                {
                    baglanti.Open();
                    string sql = "UPDATE randevu SET musteriKisiID = @musteriKisiID, berberKisiID = @berberKisiID, subeID = @subeID, " +
                                 "kampanyaID = @kampanyaID, randevuTarihi = @randevuTarihi, hizmetID = @hizmetID WHERE randevuID = @randevuID"; // Tabloya göre sorgu

                    using (var komut = new NpgsqlCommand(sql, baglanti))
                    {
                        // Parametreler ile veriyi güncelleme
                        komut.Parameters.AddWithValue("randevuID", randevuID);
                        komut.Parameters.AddWithValue("musteriKisiID", musteriKisiID);
                        komut.Parameters.AddWithValue("berberKisiID", berberKisiID);
                        komut.Parameters.AddWithValue("subeID", subeID);
                        komut.Parameters.AddWithValue("kampanyaID", (object)kampanyaID ?? DBNull.Value); // Eğer kampanyaID null ise DBNull.Value olarak ekle
                        komut.Parameters.AddWithValue("randevuTarihi", randevuTarihi);
                        komut.Parameters.AddWithValue("hizmetID", hizmetID);

                        int sonuc = komut.ExecuteNonQuery();

                        if (sonuc > 0)
                        {
                            MessageBox.Show("Randevu başarıyla güncellendi.");
                            RandevularListele(); // Güncelleme işleminden sonra listeyi yenileyin
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Tıklanan satırın index kontrolü
            if (e.RowIndex >= 0) // Geçerli bir satır mı
            {
                DataGridViewRow satir = dataGridView1.Rows[e.RowIndex]; // Seçili satırı al

                // TextBox'lara değerleri aktar

                txtMusteriKisiId.Text = satir.Cells["musterikisiid"].Value.ToString();
                txtKuaforKisiId.Text = satir.Cells["berberkisiid"].Value.ToString();
                txtSubeId.Text = satir.Cells["subeid"].Value.ToString();
                txtKampanyaId.Text = satir.Cells["kampanyaid"].Value.ToString();
                dtpRandevuTarihi.Text = satir.Cells["randevutarihi"].Value.ToString();
                txtHizmetID.Text = satir.Cells["hizmetid"].Value.ToString();
            }
        }

        private void btnRandevuAra_Click(object sender, EventArgs e)
        {
            // Kullanıcıdan alınan müşteri KisiID
            string musteriKisiIDText = txtMusteriKisiId.Text;

            if (!string.IsNullOrEmpty(musteriKisiIDText) && int.TryParse(musteriKisiIDText, out int musteriKisiID))
            {
                // Arama işlemini başlat
                RandevuAra(musteriKisiID);
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir müşteri KisiID girin.");
            }
        }

        private void RandevuAra(int musteriKisiID)
        {
            // Veritabanına bağlanma
            using (var baglanti = new NpgsqlConnection(_baglantiString))
            {
                try
                {
                    baglanti.Open();
                    string sql = "SELECT randevuID, musteriKisiID, berberKisiID, subeID, kampanyaID, randevuTarihi, hizmetID FROM randevu WHERE musteriKisiID = @musteriKisiID"; // MüşteriKisiID'ye göre sorgu

                    using (var komut = new NpgsqlCommand(sql, baglanti))
                    {
                        // Parametreyi ekleyerek müşteriKisiID'ye göre arama yapıyoruz
                        komut.Parameters.AddWithValue("musteriKisiID", musteriKisiID);

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
    }
}
