namespace Proje_Kuafor
{
    partial class Form4
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
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtİletisimKisiId = new System.Windows.Forms.TextBox();
            this.txtTelefon = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEposta = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtİletisimAdres = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnİletisimEkle = new System.Windows.Forms.Button();
            this.btnİletisimSil = new System.Windows.Forms.Button();
            this.btnİletisimAra = new System.Windows.Forms.Button();
            this.btnİletisimGuncelle = new System.Windows.Forms.Button();
            this.iletisimListele = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 22);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(776, 294);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(847, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(191, 16);
            this.label3.TabIndex = 23;
            this.label3.Text = "İLETİŞİM BİLGİLERİ DÜZENLE";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(847, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 24;
            this.label1.Text = "KisiID:";
            // 
            // txtİletisimKisiId
            // 
            this.txtİletisimKisiId.Location = new System.Drawing.Point(897, 56);
            this.txtİletisimKisiId.Name = "txtİletisimKisiId";
            this.txtİletisimKisiId.Size = new System.Drawing.Size(183, 22);
            this.txtİletisimKisiId.TabIndex = 25;
            // 
            // txtTelefon
            // 
            this.txtTelefon.Location = new System.Drawing.Point(897, 95);
            this.txtTelefon.Name = "txtTelefon";
            this.txtTelefon.Size = new System.Drawing.Size(183, 22);
            this.txtTelefon.TabIndex = 27;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(835, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 26;
            this.label2.Text = "Telefon:";
            // 
            // txtEposta
            // 
            this.txtEposta.Location = new System.Drawing.Point(897, 134);
            this.txtEposta.Name = "txtEposta";
            this.txtEposta.Size = new System.Drawing.Size(183, 22);
            this.txtEposta.TabIndex = 29;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(835, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 16);
            this.label4.TabIndex = 28;
            this.label4.Text = "EPosta:";
            // 
            // txtİletisimAdres
            // 
            this.txtİletisimAdres.Location = new System.Drawing.Point(897, 174);
            this.txtİletisimAdres.Name = "txtİletisimAdres";
            this.txtİletisimAdres.Size = new System.Drawing.Size(236, 22);
            this.txtİletisimAdres.TabIndex = 31;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(845, 180);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 16);
            this.label5.TabIndex = 30;
            this.label5.Text = "Adres:";
            // 
            // btnİletisimEkle
            // 
            this.btnİletisimEkle.Location = new System.Drawing.Point(928, 237);
            this.btnİletisimEkle.Name = "btnİletisimEkle";
            this.btnİletisimEkle.Size = new System.Drawing.Size(85, 23);
            this.btnİletisimEkle.TabIndex = 32;
            this.btnİletisimEkle.Text = "Ekle";
            this.btnİletisimEkle.UseVisualStyleBackColor = true;
            this.btnİletisimEkle.Click += new System.EventHandler(this.btnİletisimEkle_Click);
            // 
            // btnİletisimSil
            // 
            this.btnİletisimSil.Location = new System.Drawing.Point(1029, 237);
            this.btnİletisimSil.Name = "btnİletisimSil";
            this.btnİletisimSil.Size = new System.Drawing.Size(85, 23);
            this.btnİletisimSil.TabIndex = 33;
            this.btnİletisimSil.Text = "Sil";
            this.btnİletisimSil.UseVisualStyleBackColor = true;
            this.btnİletisimSil.Click += new System.EventHandler(this.btnİletisimSil_Click);
            // 
            // btnİletisimAra
            // 
            this.btnİletisimAra.Location = new System.Drawing.Point(1029, 277);
            this.btnİletisimAra.Name = "btnİletisimAra";
            this.btnİletisimAra.Size = new System.Drawing.Size(85, 23);
            this.btnİletisimAra.TabIndex = 34;
            this.btnİletisimAra.Text = "Arama";
            this.btnİletisimAra.UseVisualStyleBackColor = true;
            this.btnİletisimAra.Click += new System.EventHandler(this.btnİletisimAra_Click);
            // 
            // btnİletisimGuncelle
            // 
            this.btnİletisimGuncelle.Location = new System.Drawing.Point(928, 277);
            this.btnİletisimGuncelle.Name = "btnİletisimGuncelle";
            this.btnİletisimGuncelle.Size = new System.Drawing.Size(85, 23);
            this.btnİletisimGuncelle.TabIndex = 35;
            this.btnİletisimGuncelle.Text = "Güncelle";
            this.btnİletisimGuncelle.UseVisualStyleBackColor = true;
            this.btnİletisimGuncelle.Click += new System.EventHandler(this.btnİletisimGuncelle_Click);
            // 
            // iletisimListele
            // 
            this.iletisimListele.Location = new System.Drawing.Point(826, 237);
            this.iletisimListele.Name = "iletisimListele";
            this.iletisimListele.Size = new System.Drawing.Size(75, 63);
            this.iletisimListele.TabIndex = 36;
            this.iletisimListele.Text = "Listele";
            this.iletisimListele.UseVisualStyleBackColor = true;
            this.iletisimListele.Click += new System.EventHandler(this.iletisimListele_Click);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1193, 373);
            this.Controls.Add(this.iletisimListele);
            this.Controls.Add(this.btnİletisimGuncelle);
            this.Controls.Add(this.btnİletisimAra);
            this.Controls.Add(this.btnİletisimSil);
            this.Controls.Add(this.btnİletisimEkle);
            this.Controls.Add(this.txtİletisimAdres);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtEposta);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTelefon);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtİletisimKisiId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form4";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form4";
            this.Load += new System.EventHandler(this.Form4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtİletisimKisiId;
        private System.Windows.Forms.TextBox txtTelefon;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEposta;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtİletisimAdres;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnİletisimEkle;
        private System.Windows.Forms.Button btnİletisimSil;
        private System.Windows.Forms.Button btnİletisimAra;
        private System.Windows.Forms.Button btnİletisimGuncelle;
        private System.Windows.Forms.Button iletisimListele;
    }
}