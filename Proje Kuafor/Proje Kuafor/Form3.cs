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
    public partial class Form3 : Form
    {
        private string _baglantiString = "Host=localhost;Port=5432;Username=postgres;Password=161616;Database=KuaforSistemi2";
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // ComboBox'a seçenekler ekleniyor
            cmbCinsiyet.Items.Add("Erkek");
            cmbCinsiyet.Items.Add("Kadın");

            // ComboBox'a seçenekler ekleniyor
            cmbKisiTuru.Items.Add("Personel");
            cmbKisiTuru.Items.Add("Musteri");

            cmbPersonelTipi.Items.Add("Kuafor");
            cmbPersonelTipi.Items.Add("Yonetici");

            cmbMusteriTipi.Items.Add("Ogrenci");
            cmbMusteriTipi.Items.Add("Yetiskin");
        }

        private void btnKisiEkle_Click(object sender, EventArgs e)
        {
            // Kullanıcıdan alınan veriler
            string ad = txtAd.Text;
            string soyad = txtSoyad.Text;
            // Cinsiyet boş olabilir, kontrol ediyoruz
            string cinsiyet = cmbCinsiyet.SelectedItem?.ToString(); // Eğer seçim yapılmadıysa null olabilir
            DateTime dogumtarihi = dtpDogumTarihi.Value;
            string kisiTuru = cmbKisiTuru.SelectedItem.ToString();

            // Veritabanına veri ekleme
            KisiEkle(ad, soyad, cinsiyet, dogumtarihi, kisiTuru);
        }
        private void KisiEkle(string ad, string soyad, string cinsiyet, DateTime dogumtarihi, string kisiTuru)
        {
            // Veritabanına bağlanma
            using (var baglanti = new NpgsqlConnection(_baglantiString))
            {
                try
                {
                    baglanti.Open();
                    string sql = "INSERT INTO Kisi (ad, soyad, cinsiyet, dogumtarihi, kisiTuru) VALUES (@ad, @soyad, @cinsiyet, @dogumtarihi, @kisiTuru)";

                    using (var komut = new NpgsqlCommand(sql, baglanti))
                    {
                        // Parametreler ile veri ekleme
                        komut.Parameters.AddWithValue("ad", ad);
                        komut.Parameters.AddWithValue("soyad", soyad);
                        // Eğer cinsiyet null ise DBNull.Value gönderiyoruz
                        if (string.IsNullOrEmpty(cinsiyet))
                        {
                            komut.Parameters.AddWithValue("cinsiyet", DBNull.Value);
                        }
                        else
                        {
                            komut.Parameters.AddWithValue("cinsiyet", cinsiyet);
                        }
                        komut.Parameters.AddWithValue("dogumtarihi", dogumtarihi);
                        komut.Parameters.AddWithValue("kisiTuru", kisiTuru);

                        komut.ExecuteNonQuery();
                        MessageBox.Show("Kisi başarıyla eklendi.");
                        KisilerListele();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private void btnKisiListele_Click(object sender, EventArgs e)
        {
            KisilerListele();
        }

        private void KisilerListele()
        {
            // Veritabanına bağlanma
            using (var baglanti = new NpgsqlConnection(_baglantiString))
            {
                try
                {
                    baglanti.Open();
                    string sql = "SELECT * FROM Kisi"; // Tüm sütunları seçmek için *

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

        private void btnKisiSil_Click(object sender, EventArgs e)
        {
            // DataGridView'de seçili satırdan KisiID'yi alalım
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Seçilen satırdaki kisiID'yi alıyoruz
                int kisiID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["kisiid"].Value); // "kisiid" sütunun adını kullanın

                // Kişiyi veritabanından silme
                KisiSil(kisiID);
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz kişiyi seçin.");
            }
        }

        private void KisiSil(int kisiID)
        {
            // Veritabanına bağlanma
            using (var baglanti = new NpgsqlConnection(_baglantiString))
            {
                try
                {
                    baglanti.Open();
                    string sql = "DELETE FROM Kisi WHERE kisiid = @kisiID"; // Tabloya göre sorgu

                    using (var komut = new NpgsqlCommand(sql, baglanti))
                    {
                        // Parametre ile kişiyi silme
                        komut.Parameters.AddWithValue("kisiID", kisiID);

                        int sonuc = komut.ExecuteNonQuery();

                        if (sonuc > 0)
                        {
                            MessageBox.Show("Kişi başarıyla silindi.");
                            KisilerListele(); // Silme işleminden sonra listeyi yenileyin
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

        private void btnKisiGuncelle_Click(object sender, EventArgs e)
        {
            // DataGridView'de seçili satırdan KisiID'yi alalım
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Seçilen satırdaki kisiID'yi ve diğer verileri alıyoruz
                int kisiID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["kisiid"].Value); // "kisiid" sütunun adını kullanın
                string yeniAd = txtAd.Text; // TextBox'tan alınan yeni ad
                string yeniSoyad = txtSoyad.Text; // TextBox'tan alınan yeni soyad
                string yeniCinsiyet = cmbCinsiyet.SelectedItem.ToString(); // ComboBox'tan alınan yeni cinsiyet
                DateTime yeniDogumTarihi = dtpDogumTarihi.Value; // Yeni doğum tarihi
                string yeniKisiTuru = cmbKisiTuru.SelectedItem.ToString(); // Yeni kişi türü

                // Veritabanındaki kaydı güncelleme
                KisiGuncelle(kisiID, yeniAd, yeniSoyad, yeniCinsiyet, yeniDogumTarihi, yeniKisiTuru);
            }
            else
            {
                MessageBox.Show("Lütfen güncellemek istediğiniz kişiyi seçin.");
            }
        }

        private void KisiGuncelle(int kisiID, string yeniAd, string yeniSoyad, string yeniCinsiyet, DateTime yeniDogumTarihi, string yeniKisiTuru)
        {
            // Veritabanına bağlanma
            using (var baglanti = new NpgsqlConnection(_baglantiString))
            {
                try
                {
                    baglanti.Open();
                    string sql = "UPDATE Kisi SET ad = @yeniAd, soyad = @yeniSoyad, cinsiyet = @yeniCinsiyet, dogumtarihi = @yeniDogumTarihi, kisiTuru = @yeniKisiTuru WHERE kisiid = @kisiID"; // Tabloya göre sorgu

                    using (var komut = new NpgsqlCommand(sql, baglanti))
                    {
                        // Parametreler ile veriyi güncelleme
                        komut.Parameters.AddWithValue("kisiID", kisiID);
                        komut.Parameters.AddWithValue("yeniAd", yeniAd);
                        komut.Parameters.AddWithValue("yeniSoyad", yeniSoyad);
                        komut.Parameters.AddWithValue("yeniCinsiyet", yeniCinsiyet);
                        komut.Parameters.AddWithValue("yeniDogumTarihi", yeniDogumTarihi);
                        komut.Parameters.AddWithValue("yeniKisiTuru", yeniKisiTuru);

                        int sonuc = komut.ExecuteNonQuery();

                        if (sonuc > 0)
                        {
                            MessageBox.Show("Kişi başarıyla güncellendi.");
                            KisilerListele(); // Güncelleme işleminden sonra listeyi yenileyin
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

        private void btnKisiArama_Click(object sender, EventArgs e)
        {
            string kisiAd = txtAd.Text; // Kullanıcıdan alınan kişi adı

            if (!string.IsNullOrEmpty(kisiAd))
            {
                KisiAra(kisiAd); // Arama işlemini başlat
            }
            else
            {
                MessageBox.Show("Lütfen aramak istediğiniz kişi adını girin.");
            }
        }

        private void KisiAra(string kisiAd)
        {
            // Veritabanına bağlanma
            using (var baglanti = new NpgsqlConnection(_baglantiString))
            {
                try
                {
                    baglanti.Open();
                    string sql = "SELECT kisiid, ad, soyad, cinsiyet, dogumtarihi, kisiTuru FROM Kisi WHERE ad LIKE @kisiAd"; // LIKE sorgusu

                    using (var komut = new NpgsqlCommand(sql, baglanti))
                    {
                        // Parametreyi ekleyerek LIKE sorgusu ile arama yapıyoruz
                        komut.Parameters.AddWithValue("kisiAd", "%" + kisiAd + "%"); // % işaretleri, herhangi bir şeyle başlayabilir veya bitirebilir demek

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

        private void btnPersonelEkle_Click(object sender, EventArgs e)
        {
            // Kullanıcıdan alınan veriler
            int kisiID = int.Parse(txtPersonelKisiId.Text); // TextBox'tan alınan KisiID
            int subeID = int.Parse(txtSubeID.Text); // TextBox'tan alınan SubeID
            DateTime baslamaTarihi = dtpPersonelBaslamaTarihi.Value; // DateTimePicker'dan alınan Başlama Tarihi
            string personelTipi = cmbPersonelTipi.SelectedItem.ToString(); // ComboBox'tan alınan Personel Tipi

            // Veritabanına veri ekleme
            PersonelEkle(kisiID, subeID, baslamaTarihi, personelTipi);
        }

        private void PersonelEkle(int kisiID, int subeID, DateTime baslamaTarihi, string personelTipi)
        {
            using (var baglanti = new NpgsqlConnection(_baglantiString))
            {
                try
                {
                    baglanti.Open();
                    string sql = "INSERT INTO personel (kisiID, subeID, baslamaTarihi, personelTipi) VALUES (@kisiID, @subeID, @baslamaTarihi, @personelTipi)";

                    using (var komut = new NpgsqlCommand(sql, baglanti))
                    {
                        // Parametrelerle veritabanına veri ekleme
                        komut.Parameters.AddWithValue("kisiID", kisiID);
                        komut.Parameters.AddWithValue("subeID", subeID);
                        komut.Parameters.AddWithValue("baslamaTarihi", baslamaTarihi);
                        komut.Parameters.AddWithValue("personelTipi", personelTipi);

                        komut.ExecuteNonQuery();
                        MessageBox.Show("Personel başarıyla eklendi.");
                        PersonellerListele(); // Ekleme işleminden sonra listeyi yenileyin
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message + "\n\nDetaylar: " + ex.StackTrace);
                }
            }
        }

        private void btnPersonelListele_Click(object sender, EventArgs e)
        {
            PersonellerListele();
        }

        private void PersonellerListele()
        {
            // Veritabanına bağlanma
            using (var baglanti = new NpgsqlConnection(_baglantiString))
            {
                try
                {
                    baglanti.Open();
                    string sql = "SELECT * FROM Personel"; // Personel tablosundaki tüm sütunları getir

                    using (var komut = new NpgsqlCommand(sql, baglanti))
                    {
                        using (var reader = komut.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader); // Veriyi DataTable'a yükle
                            dataGridView1.DataSource = dt; // DataGridView'e yükle
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private void btnPersonelSil_Click(object sender, EventArgs e)
        {
            // DataGridView'de seçili satırdan KisiID'yi alalım
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Seçilen satırdaki KisiID'yi alıyoruz
                int personelID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["kisiid"].Value); // "kisiid" sütunun adını kullanın

                // Personeli veritabanından silme
                PersonelSil(personelID);
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz personeli seçin.");
            }
        }

        private void PersonelSil(int personelID)
        {
            // Veritabanına bağlanma
            using (var baglanti = new NpgsqlConnection(_baglantiString))
            {
                try
                {
                    baglanti.Open();
                    string sql = "DELETE FROM personel WHERE kisiid = @personelID"; // Tabloya göre sorgu

                    using (var komut = new NpgsqlCommand(sql, baglanti))
                    {
                        // Parametre ile personeli silme
                        komut.Parameters.AddWithValue("personelID", personelID);

                        int sonuc = komut.ExecuteNonQuery();

                        if (sonuc > 0)
                        {
                            MessageBox.Show("Personel başarıyla silindi.");
                            PersonellerListele(); // Silme işleminden sonra listeyi yenileyin
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

        private void btnPersonelGuncelle_Click(object sender, EventArgs e)
        {
            // DataGridView'de seçili satırdan PersonelID'yi alalım
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Seçilen satırdaki personelID'yi ve diğer verileri alıyoruz
                int kisiID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["kisiid"].Value); // "kisiid" sütunun adını kullanın
                int subeID = int.Parse(txtSubeID.Text); // TextBox'tan alınan yeni ŞubeID
                DateTime baslamaTarihi = dtpPersonelBaslamaTarihi.Value; // DateTimePicker'dan alınan yeni başlama tarihi
                string personelTipi = cmbPersonelTipi.SelectedItem.ToString(); // ComboBox'tan alınan personel tipi

                // Veritabanındaki kaydı güncelleme
                PersonelGuncelle(kisiID, subeID, baslamaTarihi, personelTipi);
            }
            else
            {
                MessageBox.Show("Lütfen güncellemek istediğiniz personeli seçin.");
            }
        }

        private void PersonelGuncelle(int kisiID, int subeID, DateTime baslamaTarihi, string personelTipi)
        {
            // Veritabanına bağlanma
            using (var baglanti = new NpgsqlConnection(_baglantiString))
            {
                try
                {
                    baglanti.Open();
                    string sql = "UPDATE personel SET subeid = @subeID, baslamatarihi = @baslamaTarihi, personeltipi = @personelTipi WHERE kisiid = @kisiID";

                    using (var komut = new NpgsqlCommand(sql, baglanti))
                    {
                        // Parametreler ile veriyi güncelleme
                        komut.Parameters.AddWithValue("kisiID", kisiID);
                        komut.Parameters.AddWithValue("subeID", subeID);
                        komut.Parameters.AddWithValue("baslamaTarihi", baslamaTarihi);
                        komut.Parameters.AddWithValue("personelTipi", personelTipi);

                        int sonuc = komut.ExecuteNonQuery();

                        if (sonuc > 0)
                        {
                            MessageBox.Show("Personel başarıyla güncellendi.");
                            PersonellerListele(); // Güncelleme işleminden sonra listeyi yenileyin
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

        private void btnPersonelArama_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtPersonelKisiId.Text, out int kisiID))
            {
                PersonelAra(kisiID); // Arama işlemini başlat
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir KisiID girin.");
            }
        }

        private void PersonelAra(int kisiID)
        {
            // Veritabanına bağlanma
            using (var baglanti = new NpgsqlConnection(_baglantiString))
            {
                try
                {
                    baglanti.Open();
                    string sql = "SELECT kisiid, subeid, baslamatarihi, personeltipi " +
                                 "FROM personel WHERE kisiid = @kisiID"; // KisiID'ye göre arama yapıyoruz

                    using (var komut = new NpgsqlCommand(sql, baglanti))
                    {
                        // Parametreyi ekleyerek sorguyu özelleştiriyoruz
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

        private void btnTumPersonelleriListele_Click(object sender, EventArgs e)
        {
            TumPersonelleriListele();
        }

        private void TumPersonelleriListele()
        {
            using (var baglanti = new NpgsqlConnection(_baglantiString))
            {
                try
                {
                    baglanti.Open();
                    string sql = @"
                    SELECT 
                        k.kisiid AS ""KisiID"",
                        k.ad AS ""Ad"",
                        k.soyad AS ""Soyad"",
                        p.subeid AS ""ŞubeID"",
                        p.baslamatarihi AS ""Başlama Tarihi"",
                        p.personeltipi AS ""Personel Tipi"",
                        ku.uzmanlikAlani AS ""Uzmanlık Alanı"",
                        yo.yonetimBaslamaTarihi AS ""Yönetim Başlama Tarihi"",
                        yo.yonetimBitisTarihi AS ""Yönetim Bitiş Tarihi""
                    FROM kisi k
                    INNER JOIN personel p ON k.kisiid = p.kisiid
                    LEFT JOIN kuafor ku ON p.kisiid = ku.kisiid
                    LEFT JOIN yonetici yo ON p.kisiid = yo.kisiid
                ";


                    using (var komut = new NpgsqlCommand(sql, baglanti))
                    {
                        using (var reader = komut.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);
                            dataGridView1.DataSource = dt; // DataGridView'e yükleme
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private void btnTümMusteriListele_Click(object sender, EventArgs e)
        {
            TumMusteriListele();
        }

        private void TumMusteriListele()
        {
            // Veritabanına bağlanma
            using (var baglanti = new NpgsqlConnection(_baglantiString))
            {
                try
                {
                    baglanti.Open();
                    string sql = @"
                SELECT 
                    k.kisiid AS ""KisiID"",
                    k.ad AS ""Ad"",
                    k.soyad AS ""Soyad"",
                    k.cinsiyet AS ""Cinsiyet"",
                    m.uyelikTarihi AS ""Üyelik Tarihi"",
                    m.musteriTipi AS ""Müşteri Tipi"",
                    o.ogrenciBelgeNo AS ""Öğrenci Belge No"",
                    y.yasliMi AS ""Yaşlı mı""
                FROM kisi k
                INNER JOIN musteri m ON k.kisiid = m.kisiid
                LEFT JOIN ogrenci o ON m.kisiid = o.kisiid
                LEFT JOIN yetiskin y ON m.kisiid = y.kisiid
            ";

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

        private void btnMusteriEkle_Click(object sender, EventArgs e)
        {
            // Kullanıcıdan alınan veriler
            int kisiID = int.Parse(txtMusteriKisiId.Text); // KisiID textbox'tan alınır
            DateTime uyelikTarihi = dtpMusteriUyelikTarihi.Value; // Üyelik tarihi DateTimePicker'dan alınır
            string musteriTipi = cmbMusteriTipi.SelectedItem.ToString(); // Müşteri tipi ComboBox'tan alınır

            // Veritabanına veri ekleme
            MusteriEkle(kisiID, uyelikTarihi, musteriTipi);
        }

        private void MusteriEkle(int kisiID, DateTime uyelikTarihi, string musteriTipi)
        {
            using (var baglanti = new NpgsqlConnection(_baglantiString))
            {
                try
                {
                    baglanti.Open();
                    string sql = "INSERT INTO musteri (kisiID, uyelikTarihi, musteriTipi) VALUES (@kisiID, @uyelikTarihi, @musteriTipi)";
                    using (var komut = new NpgsqlCommand(sql, baglanti))
                    {
                        komut.Parameters.AddWithValue("kisiID", kisiID);
                        komut.Parameters.AddWithValue("uyelikTarihi", uyelikTarihi);
                        komut.Parameters.AddWithValue("musteriTipi", musteriTipi);
                        komut.ExecuteNonQuery();
                        MessageBox.Show("Müşteri başarıyla eklendi.");
                        MusterileriListele(); // Ekleme işleminden sonra listeyi yenileyin
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message + "\n\nDetaylar: " + ex.StackTrace);
                }
            }
        }

        private void btnMusteriListele_Click(object sender, EventArgs e)
        {
            MusterileriListele();
        }

        private void MusterileriListele()
        {
            // Veritabanına bağlanma
            using (var baglanti = new NpgsqlConnection(_baglantiString))
            {
                try
                {
                    baglanti.Open();
                    string sql = "SELECT * FROM Musteri"; // Tüm sütunları seçmek için *

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

        private void btnMusteriSil_Click(object sender, EventArgs e)
        {
            // DataGridView'de seçili satırdan KisiID'yi alalım
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Seçilen satırdaki KisiID'yi alıyoruz
                int kisiID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["kisiid"].Value); // "kisiid" sütunun adını kullanın

                // Müşteriyi veritabanından silme
                MusteriSil(kisiID);
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz müşteriyi seçin.");
            }
        }

        private void MusteriSil(int kisiID)
        {
            // Veritabanına bağlanma
            using (var baglanti = new NpgsqlConnection(_baglantiString))
            {
                try
                {
                    baglanti.Open();
                    string sql = "DELETE FROM musteri WHERE kisiid = @kisiID"; // Tabloya göre sorgu

                    using (var komut = new NpgsqlCommand(sql, baglanti))
                    {
                        // Parametre ile müşteriyi silme
                        komut.Parameters.AddWithValue("kisiID", kisiID);

                        int sonuc = komut.ExecuteNonQuery();

                        if (sonuc > 0)
                        {
                            MessageBox.Show("Müşteri başarıyla silindi.");
                            MusterileriListele(); // Silme işleminden sonra listeyi yenileyin
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

        private void btnMusteriGuncelle_Click(object sender, EventArgs e)
        {
            // DataGridView'de seçili satırdan KisiID'yi alalım
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Seçilen satırdaki KisiID'yi ve diğer verileri alıyoruz
                int kisiID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["kisiid"].Value); // "kisiid" sütunun adını kullanın
                DateTime yeniUyelikTarihi = dtpMusteriUyelikTarihi.Value; // DateTimePicker'dan alınan yeni üyelik tarihi
                string yeniMusteriTipi = cmbMusteriTipi.SelectedItem.ToString(); // ComboBox'tan alınan yeni müşteri tipi

                // Veritabanındaki kaydı güncelleme
                MusteriGuncelle(kisiID, yeniUyelikTarihi, yeniMusteriTipi);
            }
            else
            {
                MessageBox.Show("Lütfen güncellemek istediğiniz müşteriyi seçin.");
            }
        }

        private void MusteriGuncelle(int kisiID, DateTime yeniUyelikTarihi, string yeniMusteriTipi)
        {
            // Veritabanına bağlanma
            using (var baglanti = new NpgsqlConnection(_baglantiString))
            {
                try
                {
                    baglanti.Open();
                    string sql = "UPDATE musteri SET uyelikTarihi = @yeniUyelikTarihi, musteriTipi = @yeniMusteriTipi WHERE kisiid = @kisiID"; // Tabloya göre sorgu

                    using (var komut = new NpgsqlCommand(sql, baglanti))
                    {
                        // Parametreler ile veriyi güncelleme
                        komut.Parameters.AddWithValue("kisiID", kisiID);
                        komut.Parameters.AddWithValue("yeniUyelikTarihi", yeniUyelikTarihi);
                        komut.Parameters.AddWithValue("yeniMusteriTipi", yeniMusteriTipi);

                        int sonuc = komut.ExecuteNonQuery();

                        if (sonuc > 0)
                        {
                            MessageBox.Show("Müşteri başarıyla güncellendi.");
                            MusterileriListele(); // Güncelleme işleminden sonra listeyi yenileyin
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

        private void btnMusteriArama_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtMusteriKisiId.Text, out int kisiID)) // Kullanıcıdan alınan Kişi ID'yi doğrula
            {
                MusteriAra(kisiID); // Arama işlemini başlat
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir Kişi ID girin.");
            }
        }

        private void MusteriAra(int kisiID)
        {
            // Veritabanına bağlanma
            using (var baglanti = new NpgsqlConnection(_baglantiString))
            {
                try
                {
                    baglanti.Open();
                    string sql = "SELECT kisiid, uyelikTarihi, musteriTipi FROM musteri WHERE kisiid = @kisiID"; // Kişi ID ile arama sorgusu

                    using (var komut = new NpgsqlCommand(sql, baglanti))
                    {
                        // Parametreyi ekleyerek sorguyu çalıştırıyoruz
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

        private void btnKuaforListele_Click(object sender, EventArgs e)
        {
            KuaforleriListele();
        }

        private void KuaforleriListele()
        {
            // Veritabanına bağlanma
            using (var baglanti = new NpgsqlConnection(_baglantiString))
            {
                try
                {
                    baglanti.Open();
                    string sql = "SELECT kisiid, uzmanlikAlani FROM Kuafor"; // Kuaför tablosunu sorgulama

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

        private void btnKuaforEkle_Click(object sender, EventArgs e)
        {
            // Kullanıcıdan alınan veriler
            int kisiID = int.Parse(txtKuaforKisiId.Text); // Kuaförün KisiID'si
            string uzmanlikAlani = txtUzmanlikAlani.Text; // Uzmanlık alanı

            // Veritabanına veri ekleme
            KuaforEkle(kisiID, uzmanlikAlani);
        }

        private void KuaforEkle(int kisiID, string uzmanlikAlani)
        {
            using (var baglanti = new NpgsqlConnection(_baglantiString))
            {
                try
                {
                    baglanti.Open();
                    string sql = "INSERT INTO Kuafor (kisiid, uzmanlikalani) VALUES (@kisiID, @uzmanlikAlani)";
                    using (var komut = new NpgsqlCommand(sql, baglanti))
                    {
                        komut.Parameters.AddWithValue("kisiID", kisiID);
                        komut.Parameters.AddWithValue("uzmanlikAlani", uzmanlikAlani);
                        komut.ExecuteNonQuery();
                        MessageBox.Show("Kuaför başarıyla eklendi.");
                        KuaforleriListele(); // Ekleme işleminden sonra listeyi yenileyin
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message + "\n\nDetaylar: " + ex.StackTrace);
                }
            }
        }

        private void btnKuaforSil_Click(object sender, EventArgs e)
        {
            // DataGridView'de seçili satırdan KisiID'yi alalım
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Seçilen satırdaki kisiID'yi alıyoruz
                int kisiID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["kisiid"].Value); // "kisiid" sütunun adını kullanın

                // Kuaförü veritabanından silme
                KuaforSil(kisiID);
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz kuaförü seçin.");
            }
        }

        private void KuaforSil(int kisiID)
        {
            // Veritabanına bağlanma
            using (var baglanti = new NpgsqlConnection(_baglantiString))
            {
                try
                {
                    baglanti.Open();
                    string sql = "DELETE FROM Kuafor WHERE kisiid = @kisiID"; // Tabloya göre sorgu

                    using (var komut = new NpgsqlCommand(sql, baglanti))
                    {
                        // Parametre ile kuaförü silme
                        komut.Parameters.AddWithValue("kisiID", kisiID);

                        int sonuc = komut.ExecuteNonQuery();

                        if (sonuc > 0)
                        {
                            MessageBox.Show("Kuaför başarıyla silindi.");
                            KuaforleriListele(); // Silme işleminden sonra listeyi yenileyin
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

        private void btnKuaforGuncelle_Click(object sender, EventArgs e)
        {
            // DataGridView'de seçili satırdan KisiID'yi alalım
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Seçilen satırdaki kisiID'yi ve diğer verileri alıyoruz
                int kisiID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["kisiid"].Value); // "kisiid" sütunun adını kullanın
                string yeniUzmanlikAlani = txtUzmanlikAlani.Text; // TextBox'tan alınan yeni uzmanlık alanı

                // Veritabanındaki kaydı güncelleme
                KuaforGuncelle(kisiID, yeniUzmanlikAlani);
            }
            else
            {
                MessageBox.Show("Lütfen güncellemek istediğiniz kuaförü seçin.");
            }
        }

        private void KuaforGuncelle(int kisiID, string yeniUzmanlikAlani)
        {
            // Veritabanına bağlanma
            using (var baglanti = new NpgsqlConnection(_baglantiString))
            {
                try
                {
                    baglanti.Open();
                    string sql = "UPDATE Kuafor SET uzmanlikalani = @yeniUzmanlikAlani WHERE kisiid = @kisiID"; // Tabloya göre sorgu

                    using (var komut = new NpgsqlCommand(sql, baglanti))
                    {
                        // Parametreler ile veriyi güncelleme
                        komut.Parameters.AddWithValue("kisiID", kisiID);
                        komut.Parameters.AddWithValue("yeniUzmanlikAlani", yeniUzmanlikAlani);

                        int sonuc = komut.ExecuteNonQuery();

                        if (sonuc > 0)
                        {
                            MessageBox.Show("Kuaför başarıyla güncellendi.");
                            KuaforleriListele(); // Güncelleme işleminden sonra listeyi yenileyin
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

        private void btnKuaforArama_Click(object sender, EventArgs e)
        {
            string kuaforId = txtKuaforKisiId.Text; // Kullanıcıdan alınan kuaför ID'si

            if (!string.IsNullOrEmpty(kuaforId))
            {
                KuaforAra(kuaforId); // Arama işlemini başlat
            }
            else
            {
                MessageBox.Show("Lütfen aramak istediğiniz kuaför ID'sini girin.");
            }
        }

        private void KuaforAra(string kuaforId)
        {
            // Veritabanına bağlanma
            using (var baglanti = new NpgsqlConnection(_baglantiString))
            {
                try
                {
                    baglanti.Open();
                    string sql = "SELECT kisiid, uzmanlikalani FROM Kuafor WHERE kisiid::text LIKE @kuaforId"; // LIKE sorgusu

                    using (var komut = new NpgsqlCommand(sql, baglanti))
                    {
                        // Parametreyi ekleyerek LIKE sorgusu ile arama yapıyoruz
                        komut.Parameters.AddWithValue("kuaforId", "%" + kuaforId + "%"); // % işaretleri, herhangi bir şeyle başlayabilir veya bitirebilir demek

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

        private void btnYoneticiListele_Click(object sender, EventArgs e)
        {
            YoneticiListele();
        }

        private void YoneticiListele()
        {
            // Veritabanına bağlanma
            using (var baglanti = new NpgsqlConnection(_baglantiString))
            {
                try
                {
                    baglanti.Open();
                    string sql = "SELECT kisiid, yonetimbaslamatarihi, yonetimbitistarihi FROM Yonetici"; // Yalnızca gerekli sütunları seçiyoruz

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

        private void btnYoneticiEkle_Click(object sender, EventArgs e)
        {
            // Kullanıcıdan alınan veriler
            int kisiID = int.Parse(txtYoneticiKisiId.Text); // KisiID
            DateTime yonetimBaslamaTarihi = dtpYonetimBaslangicTarihi.Value; // Yonetim Başlama Tarihi
            DateTime yonetimBitisTarihi = dtpYonetimBitisTarihi.Value; // Yonetim Bitiş Tarihi

            // Veritabanına veri ekleme
            YoneticiEkle(kisiID, yonetimBaslamaTarihi, yonetimBitisTarihi);
        }

        private void YoneticiEkle(int kisiID, DateTime yonetimBaslamaTarihi, DateTime yonetimBitisTarihi)
        {
            using (var baglanti = new NpgsqlConnection(_baglantiString))
            {
                try
                {
                    baglanti.Open();
                    string sql = "INSERT INTO Yonetici (kisiid, yonetimbaslamatarihi, yonetimbitistarihi) VALUES (@kisiID, @yonetimBaslamaTarihi, @yonetimBitisTarihi)";
                    using (var komut = new NpgsqlCommand(sql, baglanti))
                    {
                        // Parametreler ile veri ekleme
                        komut.Parameters.AddWithValue("kisiID", kisiID);
                        komut.Parameters.AddWithValue("yonetimBaslamaTarihi", yonetimBaslamaTarihi);
                        komut.Parameters.AddWithValue("yonetimBitisTarihi", yonetimBitisTarihi);
                        komut.ExecuteNonQuery();
                        MessageBox.Show("Yönetici başarıyla eklendi.");
                        YoneticiListele(); // Ekleme işleminden sonra listeyi yenileyin
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message + "\n\nDetaylar: " + ex.StackTrace);
                }
            }
        }

        private void btnYoneticiSil_Click(object sender, EventArgs e)
        {
            // DataGridView'de seçili satırdan KisiID'yi alalım
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Seçilen satırdaki kisiID'yi alıyoruz
                int kisiID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["kisiid"].Value); // "kisiid" sütunun adını kullanın

                // Yöneticiyi veritabanından silme
                YoneticiSil(kisiID);
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz yöneticiyi seçin.");
            }
        }

        private void YoneticiSil(int kisiID)
        {
            // Veritabanına bağlanma
            using (var baglanti = new NpgsqlConnection(_baglantiString))
            {
                try
                {
                    baglanti.Open();
                    string sql = "DELETE FROM Yonetici WHERE kisiid = @kisiID"; // Tabloya göre sorgu

                    using (var komut = new NpgsqlCommand(sql, baglanti))
                    {
                        // Parametre ile yöneticiyi silme
                        komut.Parameters.AddWithValue("kisiID", kisiID);

                        int sonuc = komut.ExecuteNonQuery();

                        if (sonuc > 0)
                        {
                            MessageBox.Show("Yönetici başarıyla silindi.");
                            YoneticiListele(); // Silme işleminden sonra listeyi yenileyin
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

        private void btnYoneticiGuncelle_Click(object sender, EventArgs e)
        {
            // DataGridView'de seçili satırdan KisiID'yi alalım
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Seçilen satırdaki kisiID'yi ve diğer verileri alıyoruz
                int kisiID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["kisiid"].Value); // "kisiid" sütunun adını kullanın
                DateTime yonetimBaslamaTarihi = dtpYonetimBaslangicTarihi.Value; // DateTimePicker'tan alınan yönetim başlama tarihi
                DateTime yonetimBitisTarihi = dtpYonetimBitisTarihi.Value; // DateTimePicker'tan alınan yönetim bitiş tarihi

                // Veritabanındaki kaydı güncelleme
                YoneticiGuncelle(kisiID, yonetimBaslamaTarihi, yonetimBitisTarihi);
            }
            else
            {
                MessageBox.Show("Lütfen güncellemek istediğiniz yöneticiyi seçin.");
            }
        }
        private void YoneticiGuncelle(int kisiID, DateTime yonetimBaslamaTarihi, DateTime yonetimBitisTarihi)
        {
            // Veritabanına bağlanma
            using (var baglanti = new NpgsqlConnection(_baglantiString))
            {
                try
                {
                    baglanti.Open();
                    string sql = "UPDATE Yonetici SET yonetimBaslamaTarihi = @yonetimBaslamaTarihi, yonetimBitisTarihi = @yonetimBitisTarihi WHERE kisiid = @kisiID"; // Tabloya göre sorgu

                    using (var komut = new NpgsqlCommand(sql, baglanti))
                    {
                        // Parametreler ile veriyi güncelleme
                        komut.Parameters.AddWithValue("kisiID", kisiID);
                        komut.Parameters.AddWithValue("yonetimBaslamaTarihi", yonetimBaslamaTarihi);
                        komut.Parameters.AddWithValue("yonetimBitisTarihi", yonetimBitisTarihi);

                        int sonuc = komut.ExecuteNonQuery();

                        if (sonuc > 0)
                        {
                            MessageBox.Show("Yönetici başarıyla güncellendi.");
                            YoneticiListele(); // Güncelleme işleminden sonra listeyi yenileyin
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

        private void btnYoneticiArama_Click(object sender, EventArgs e)
        {
            string kisiIDText = txtYoneticiKisiId.Text; // Kullanıcıdan alınan kişi ID'si

            // Girilen değeri integer'a dönüştürmeyi deneyelim
            if (int.TryParse(kisiIDText, out int kisiID))
            {
                YoneticiAra(kisiID); // Arama işlemini başlat
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir yönetici ID'si girin.");
            }
        }

        private void YoneticiAra(int kisiID)
        {
            // Veritabanına bağlanma
            using (var baglanti = new NpgsqlConnection(_baglantiString))
            {
                try
                {
                    baglanti.Open();
                    string sql = "SELECT kisiid, yonetimBaslamaTarihi, yonetimBitisTarihi FROM Yonetici WHERE kisiid = @kisiID"; // kisiID'ye göre arama sorgusu

                    using (var komut = new NpgsqlCommand(sql, baglanti))
                    {
                        // Parametreyi ekleyerek kisiID ile arama yapıyoruz
                        komut.Parameters.AddWithValue("kisiID", kisiID); // Yalnızca belirli bir kisiID'yi arıyoruz

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

        private void btnOgrenciListele_Click(object sender, EventArgs e)
        {
            OgrencileriListele();
        }

        private void OgrencileriListele()
        {
            // Veritabanına bağlanma
            using (var baglanti = new NpgsqlConnection(_baglantiString))
            {
                try
                {
                    baglanti.Open();
                    string sql = "SELECT kisiID, ogrenciBelgeNo FROM Ogrenci"; // Ogrenci tablosundaki gerekli sütunları seçiyoruz

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

        private void btnOgrenciEkle_Click(object sender, EventArgs e)
        {
            // Kullanıcıdan alınan veriler
            int kisiID = Convert.ToInt32(txtOgrenciKisiId.Text);  // Öğrencinin kisiID'si
            string ogrenciBelgeNo = txtOgrenciBelgeNo.Text;  // Öğrencinin belge numarası

            // Veritabanına veri ekleme
            OgrenciEkle(kisiID, ogrenciBelgeNo);
        }

        private void OgrenciEkle(int kisiID, string ogrenciBelgeNo)
        {
            using (var baglanti = new NpgsqlConnection(_baglantiString))
            {
                try
                {
                    baglanti.Open();
                    string sql = "INSERT INTO Ogrenci (kisiID, ogrenciBelgeNo) VALUES (@kisiID, @ogrenciBelgeNo)";
                    using (var komut = new NpgsqlCommand(sql, baglanti))
                    {
                        komut.Parameters.AddWithValue("kisiID", kisiID);
                        komut.Parameters.AddWithValue("ogrenciBelgeNo", ogrenciBelgeNo);
                        komut.ExecuteNonQuery();
                        MessageBox.Show("Öğrenci başarıyla eklendi.");
                        OgrencileriListele(); // Ekleme işleminden sonra listeyi yenileyin
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message + "\n\nDetaylar: " + ex.StackTrace);
                }
            }
        }

        private void btnOgrenciSil_Click(object sender, EventArgs e)
        {
            // DataGridView'de seçili satırdan KisiID'yi alalım
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Seçilen satırdaki kisiID'yi alıyoruz
                int kisiID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["kisiID"].Value); // "kisiID" sütunun adını kullanın

                // Öğrenciyi veritabanından silme
                OgrenciSil(kisiID);
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz öğrenciyi seçin ve öğrencinin ID'sini girin.");
            }
        }

        private void OgrenciSil(int kisiID)
        {
            // Veritabanına bağlanma
            using (var baglanti = new NpgsqlConnection(_baglantiString))
            {
                try
                {
                    baglanti.Open();
                    string sql = "DELETE FROM Ogrenci WHERE kisiID = @kisiID"; // Tabloya göre sorgu

                    using (var komut = new NpgsqlCommand(sql, baglanti))
                    {
                        // Parametre ile öğrenciyi silme
                        komut.Parameters.AddWithValue("kisiID", kisiID);

                        int sonuc = komut.ExecuteNonQuery();

                        if (sonuc > 0)
                        {
                            MessageBox.Show("Öğrenci başarıyla silindi.");
                            OgrencileriListele(); // Silme işleminden sonra listeyi yenileyin
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

        private void btnOgrenciGuncelle_Click(object sender, EventArgs e)
        {
            // DataGridView'de seçili satırdan KisiID'yi alalım
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Seçilen satırdaki kisiID'yi ve diğer verileri alıyoruz
                int kisiID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["kisiID"].Value); // "kisiID" sütunun adını kullanın
                string yeniBelgeNo = txtOgrenciBelgeNo.Text; // TextBox'tan alınan yeni öğrenci belge numarası

                // Veritabanındaki kaydı güncelleme
                OgrenciGuncelle(kisiID, yeniBelgeNo);
            }
            else
            {
                MessageBox.Show("Lütfen güncellemek istediğiniz öğrenciyi seçin.");
            }
        }

        private void OgrenciGuncelle(int kisiID, string yeniBelgeNo)
        {
            // Veritabanına bağlanma
            using (var baglanti = new NpgsqlConnection(_baglantiString))
            {
                try
                {
                    baglanti.Open();
                    string sql = "UPDATE Ogrenci SET ogrenciBelgeNo = @yeniBelgeNo WHERE kisiID = @kisiID"; // Tabloya göre sorgu

                    using (var komut = new NpgsqlCommand(sql, baglanti))
                    {
                        // Parametreler ile veriyi güncelleme
                        komut.Parameters.AddWithValue("kisiID", kisiID);
                        komut.Parameters.AddWithValue("yeniBelgeNo", yeniBelgeNo);

                        int sonuc = komut.ExecuteNonQuery();

                        if (sonuc > 0)
                        {
                            MessageBox.Show("Öğrenci başarıyla güncellendi.");
                            OgrencileriListele(); // Güncelleme işleminden sonra listeyi yenileyin
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

        private void btnOgrenciArama_Click(object sender, EventArgs e)
        {
            int kisiID;
            // Kullanıcıdan alınan kisiID
            if (int.TryParse(txtOgrenciKisiId.Text, out kisiID)) // txtKisiID, kullanıcının girdiği kişi ID'si
            {
                OgrenciAra(kisiID); // Arama işlemini başlat
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir Öğrenci ID girin.");
            }
        }

        private void OgrenciAra(int kisiID)
        {
            // Veritabanına bağlanma
            using (var baglanti = new NpgsqlConnection(_baglantiString))
            {
                try
                {
                    baglanti.Open();
                    string sql = "SELECT kisiID, ogrenciBelgeNo FROM Ogrenci WHERE kisiID = @kisiID"; // kisiID üzerinden arama

                    using (var komut = new NpgsqlCommand(sql, baglanti))
                    {
                        // Parametreyi ekleyerek sorguyu yapıyoruz
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
    }
}
