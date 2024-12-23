namespace Proje_Kuafor
{
    partial class Form5
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMusteriKisiId = new System.Windows.Forms.TextBox();
            this.txtKuaforKisiId = new System.Windows.Forms.TextBox();
            this.txtSubeId = new System.Windows.Forms.TextBox();
            this.txtKampanyaId = new System.Windows.Forms.TextBox();
            this.dtpRandevuTarihi = new System.Windows.Forms.DateTimePicker();
            this.btnRandevuEkle = new System.Windows.Forms.Button();
            this.btnRandevuSil = new System.Windows.Forms.Button();
            this.btnRandevuGuncelle = new System.Windows.Forms.Button();
            this.btnRandevuAra = new System.Windows.Forms.Button();
            this.btnRandevuListele = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtHizmetID = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 205);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1023, 227);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Müşteri ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(183, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Kuaför ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(332, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Şube ID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(480, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Kampanya ID";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(862, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "Hizmet ID";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(624, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 16);
            this.label6.TabIndex = 6;
            this.label6.Text = "Randevu Tarihi";
            // 
            // txtMusteriKisiId
            // 
            this.txtMusteriKisiId.Location = new System.Drawing.Point(42, 83);
            this.txtMusteriKisiId.Name = "txtMusteriKisiId";
            this.txtMusteriKisiId.Size = new System.Drawing.Size(100, 22);
            this.txtMusteriKisiId.TabIndex = 7;
            // 
            // txtKuaforKisiId
            // 
            this.txtKuaforKisiId.Location = new System.Drawing.Point(186, 83);
            this.txtKuaforKisiId.Name = "txtKuaforKisiId";
            this.txtKuaforKisiId.Size = new System.Drawing.Size(100, 22);
            this.txtKuaforKisiId.TabIndex = 8;
            // 
            // txtSubeId
            // 
            this.txtSubeId.Location = new System.Drawing.Point(335, 83);
            this.txtSubeId.Name = "txtSubeId";
            this.txtSubeId.Size = new System.Drawing.Size(100, 22);
            this.txtSubeId.TabIndex = 9;
            // 
            // txtKampanyaId
            // 
            this.txtKampanyaId.Location = new System.Drawing.Point(483, 83);
            this.txtKampanyaId.Name = "txtKampanyaId";
            this.txtKampanyaId.Size = new System.Drawing.Size(100, 22);
            this.txtKampanyaId.TabIndex = 10;
            // 
            // dtpRandevuTarihi
            // 
            this.dtpRandevuTarihi.Location = new System.Drawing.Point(627, 82);
            this.dtpRandevuTarihi.Name = "dtpRandevuTarihi";
            this.dtpRandevuTarihi.Size = new System.Drawing.Size(200, 22);
            this.dtpRandevuTarihi.TabIndex = 12;
            // 
            // btnRandevuEkle
            // 
            this.btnRandevuEkle.Location = new System.Drawing.Point(732, 123);
            this.btnRandevuEkle.Name = "btnRandevuEkle";
            this.btnRandevuEkle.Size = new System.Drawing.Size(92, 33);
            this.btnRandevuEkle.TabIndex = 13;
            this.btnRandevuEkle.Text = "Ekle";
            this.btnRandevuEkle.UseVisualStyleBackColor = true;
            this.btnRandevuEkle.Click += new System.EventHandler(this.btnRandevuEkle_Click);
            // 
            // btnRandevuSil
            // 
            this.btnRandevuSil.Location = new System.Drawing.Point(830, 123);
            this.btnRandevuSil.Name = "btnRandevuSil";
            this.btnRandevuSil.Size = new System.Drawing.Size(92, 33);
            this.btnRandevuSil.TabIndex = 14;
            this.btnRandevuSil.Text = "Sil";
            this.btnRandevuSil.UseVisualStyleBackColor = true;
            this.btnRandevuSil.Click += new System.EventHandler(this.btnRandevuSil_Click);
            // 
            // btnRandevuGuncelle
            // 
            this.btnRandevuGuncelle.Location = new System.Drawing.Point(732, 157);
            this.btnRandevuGuncelle.Name = "btnRandevuGuncelle";
            this.btnRandevuGuncelle.Size = new System.Drawing.Size(92, 33);
            this.btnRandevuGuncelle.TabIndex = 15;
            this.btnRandevuGuncelle.Text = "Güncelle";
            this.btnRandevuGuncelle.UseVisualStyleBackColor = true;
            this.btnRandevuGuncelle.Click += new System.EventHandler(this.btnRandevuGuncelle_Click);
            // 
            // btnRandevuAra
            // 
            this.btnRandevuAra.Location = new System.Drawing.Point(830, 157);
            this.btnRandevuAra.Name = "btnRandevuAra";
            this.btnRandevuAra.Size = new System.Drawing.Size(92, 33);
            this.btnRandevuAra.TabIndex = 16;
            this.btnRandevuAra.Text = "Arama";
            this.btnRandevuAra.UseVisualStyleBackColor = true;
            this.btnRandevuAra.Click += new System.EventHandler(this.btnRandevuAra_Click);
            // 
            // btnRandevuListele
            // 
            this.btnRandevuListele.Location = new System.Drawing.Point(928, 135);
            this.btnRandevuListele.Name = "btnRandevuListele";
            this.btnRandevuListele.Size = new System.Drawing.Size(92, 40);
            this.btnRandevuListele.TabIndex = 17;
            this.btnRandevuListele.Text = "Listele";
            this.btnRandevuListele.UseVisualStyleBackColor = true;
            this.btnRandevuListele.Click += new System.EventHandler(this.btnRandevuListele_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(39, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(204, 16);
            this.label7.TabIndex = 24;
            this.label7.Text = "RANDEVU BİLGİLERİ DÜZENLE";
            // 
            // txtHizmetID
            // 
            this.txtHizmetID.Location = new System.Drawing.Point(865, 84);
            this.txtHizmetID.Name = "txtHizmetID";
            this.txtHizmetID.Size = new System.Drawing.Size(100, 22);
            this.txtHizmetID.TabIndex = 25;
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1047, 444);
            this.Controls.Add(this.txtHizmetID);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnRandevuListele);
            this.Controls.Add(this.btnRandevuAra);
            this.Controls.Add(this.btnRandevuGuncelle);
            this.Controls.Add(this.btnRandevuSil);
            this.Controls.Add(this.btnRandevuEkle);
            this.Controls.Add(this.dtpRandevuTarihi);
            this.Controls.Add(this.txtKampanyaId);
            this.Controls.Add(this.txtSubeId);
            this.Controls.Add(this.txtKuaforKisiId);
            this.Controls.Add(this.txtMusteriKisiId);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form5";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form5";
            this.Load += new System.EventHandler(this.Form5_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMusteriKisiId;
        private System.Windows.Forms.TextBox txtKuaforKisiId;
        private System.Windows.Forms.TextBox txtSubeId;
        private System.Windows.Forms.TextBox txtKampanyaId;
        private System.Windows.Forms.DateTimePicker dtpRandevuTarihi;
        private System.Windows.Forms.Button btnRandevuEkle;
        private System.Windows.Forms.Button btnRandevuSil;
        private System.Windows.Forms.Button btnRandevuGuncelle;
        private System.Windows.Forms.Button btnRandevuAra;
        private System.Windows.Forms.Button btnRandevuListele;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtHizmetID;
    }
}