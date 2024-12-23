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
    public partial class Form2 : Form
    {
        private string _baglantiString = "Host=localhost;Port=5432;Username=postgres;Password=161616;Database=KuaforSistemi2";
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
           
        }

        private void btnHizmetEkle_Click_1(object sender, EventArgs e)
        {
            // Kullanıcıdan alınan veriler
            string ad = txtAd.Text;
            decimal ucret = decimal.Parse(txtFiyat.Text);  // Hizmet fiyatı
            


            // Veritabanına veri ekleme
            HizmetEkle(ad, ucret);
        }


        private void HizmetEkle(string ad, decimal ucret)
        {
            using (var baglanti = new NpgsqlConnection(_baglantiString))
            {
                try
                {
                    baglanti.Open();
                    string sql = "INSERT INTO hizmet (ad, ucret) VALUES (@ad, @ucret)";
                    using (var komut = new NpgsqlCommand(sql, baglanti))
                    {
                        komut.Parameters.AddWithValue("ad", ad);
                        komut.Parameters.AddWithValue("ucret", ucret);
                        komut.ExecuteNonQuery();
                        MessageBox.Show("Hizmet başarıyla eklendi.");
                        HizmetleriListele(); // Ekleme işleminden sonra listeyi yenileyin
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message + "\n\nDetaylar: " + ex.StackTrace);
                }
            }
        }

        private void btnListele_Click_1(object sender, EventArgs e)
        {
            // Veritabanından hizmetleri listeleme
            HizmetleriListele();
        }

        private void HizmetleriListele()
        {
            using (var baglanti = new NpgsqlConnection(_baglantiString))
            {
                try
                {
                    baglanti.Open();
                    string sql = "SELECT * FROM Hizmet"; // Tüm hizmetleri listele

                    using (var komut = new NpgsqlCommand(sql, baglanti))
                    {
                        // Verileri tutmak için DataAdapter kullanıyoruz
                        using (var adapter = new NpgsqlDataAdapter(komut))
                        {
                            DataTable dt = new DataTable();
                            int rows = adapter.Fill(dt); // DataTable'i doldur

                            // Verinin olup olmadığını kontrol edelim
                            if (rows > 0)  // Eğer veri varsa
                            {
                                dgvHizmetler.DataSource = dt;  // DataGridView'e veri aktar
                                
                            }
                            else
                            {
                                MessageBox.Show("Veri bulunamadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            // DataGridView'de seçili satırdan HizmetID'yi alalım
            if (dgvHizmetler.SelectedRows.Count > 0)
            {
                // Seçilen satırdaki hizmetid'yi alıyoruz
                int hizmetID = Convert.ToInt32(dgvHizmetler.SelectedRows[0].Cells["hizmetid"].Value); // "hizmetid" sütunun adını kullanın

                // Hizmeti veritabanından silme
                HizmetSil(hizmetID);
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz hizmeti seçin.");
            }
        }

        private void HizmetSil(int hizmetID)
        {
            // Veritabanına bağlanma
            using (var baglanti = new NpgsqlConnection(_baglantiString))
            {
                try
                {
                    baglanti.Open();
                    string sql = "DELETE FROM hizmet WHERE hizmetid = @hizmetID"; // Tabloya göre sorgu

                    using (var komut = new NpgsqlCommand(sql, baglanti))
                    {
                        // Parametre ile hizmeti silme
                        komut.Parameters.AddWithValue("hizmetID", hizmetID);

                        int sonuc = komut.ExecuteNonQuery();

                        if (sonuc > 0)
                        {
                            MessageBox.Show("Hizmet başarıyla silindi.");
                            HizmetleriListele(); // Silme işleminden sonra listeyi yenileyin
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

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            // DataGridView'de seçili satırdan HizmetID'yi alalım
            if (dgvHizmetler.SelectedRows.Count > 0)
            {
                // Seçilen satırdaki hizmetid'yi ve diğer verileri alıyoruz
                int hizmetID = Convert.ToInt32(dgvHizmetler.SelectedRows[0].Cells["hizmetid"].Value); // "hizmetid" sütunun adını kullanın
                string yeniAd = txtAd.Text; // TextBox'tan alınan yeni ad
                decimal yeniUcret = decimal.Parse(txtFiyat.Text);  // TextBox'tan alınan yeni ücret

                // Veritabanındaki kaydı güncelleme
                HizmetGuncelle(hizmetID, yeniAd, yeniUcret);
            }
            else
            {
                MessageBox.Show("Lütfen güncellemek istediğiniz hizmeti seçin.");
            }
        }

        private void HizmetGuncelle(int hizmetID, string yeniAd, decimal yeniUcret)
        {
            // Veritabanına bağlanma
            using (var baglanti = new NpgsqlConnection(_baglantiString))
            {
                try
                {
                    baglanti.Open();
                    string sql = "UPDATE hizmet SET ad = @yeniAd, ucret = @yeniUcret WHERE hizmetid = @hizmetID"; // Tabloya göre sorgu

                    using (var komut = new NpgsqlCommand(sql, baglanti))
                    {
                        // Parametreler ile veriyi güncelleme
                        komut.Parameters.AddWithValue("hizmetID", hizmetID);
                        komut.Parameters.AddWithValue("yeniAd", yeniAd);
                        komut.Parameters.AddWithValue("yeniUcret", yeniUcret);

                        int sonuc = komut.ExecuteNonQuery();

                        if (sonuc > 0)
                        {
                            MessageBox.Show("Hizmet başarıyla güncellendi.");
                            HizmetleriListele(); // Güncelleme işleminden sonra listeyi yenileyin
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

        private void btnArama_Click(object sender, EventArgs e)
        {
            string hizmetAd = txtAd.Text; // Kullanıcıdan alınan hizmet adı

            if (!string.IsNullOrEmpty(hizmetAd))
            {
                HizmetAra(hizmetAd); // Arama işlemini başlat
            }
            else
            {
                MessageBox.Show("Lütfen aramak istediğiniz hizmet adını girin.");
            }
        }
        private void HizmetAra(string hizmetAd)
        {
            // Veritabanına bağlanma
            using (var baglanti = new NpgsqlConnection(_baglantiString))
            {
                try
                {
                    baglanti.Open();
                    string sql = "SELECT hizmetid, ad, ucret FROM hizmet WHERE ad LIKE @hizmetAd"; // LIKE sorgusu

                    using (var komut = new NpgsqlCommand(sql, baglanti))
                    {
                        // Parametreyi ekleyerek LIKE sorgusu ile arama yapıyoruz
                        komut.Parameters.AddWithValue("hizmetAd", "%" + hizmetAd + "%"); // % işaretleri, herhangi bir şeyle başlayabilir veya bitirebilir demek

                        using (var reader = komut.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader); // Veriyi DataTable'a yükleyelim
                            dgvHizmetler.DataSource = dt; // DataGridView'e yükleyelim
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private void dgvHizmetler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Tıklanan satırın index kontrolü
            if (e.RowIndex >= 0) // Geçerli bir satır mı
            {
                DataGridViewRow satir = dgvHizmetler.Rows[e.RowIndex]; // Seçili satırı al

                // TextBox'lara değerleri aktar

                txtAd.Text = satir.Cells["ad"].Value.ToString();
                txtFiyat.Text = satir.Cells["ucret"].Value.ToString();
                
            }
        }
    }
}
