namespace Proje_Kuafor
{
    partial class Form2
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFiyat = new System.Windows.Forms.TextBox();
            this.txtAd = new System.Windows.Forms.TextBox();
            this.btnHizmetEkle = new System.Windows.Forms.Button();
            this.btnListele = new System.Windows.Forms.Button();
            this.dgvHizmetler = new System.Windows.Forms.DataGridView();
            this.npgsqlCommand1 = new Npgsql.NpgsqlCommand();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.btnArama = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHizmetler)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(545, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 16);
            this.label2.TabIndex = 16;
            this.label2.Text = "Ucret";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(568, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 16);
            this.label1.TabIndex = 15;
            this.label1.Text = "Ad";
            // 
            // txtFiyat
            // 
            this.txtFiyat.Location = new System.Drawing.Point(598, 68);
            this.txtFiyat.Name = "txtFiyat";
            this.txtFiyat.Size = new System.Drawing.Size(135, 22);
            this.txtFiyat.TabIndex = 14;
            // 
            // txtAd
            // 
            this.txtAd.Location = new System.Drawing.Point(598, 40);
            this.txtAd.Name = "txtAd";
            this.txtAd.Size = new System.Drawing.Size(135, 22);
            this.txtAd.TabIndex = 13;
            // 
            // btnHizmetEkle
            // 
            this.btnHizmetEkle.Location = new System.Drawing.Point(645, 108);
            this.btnHizmetEkle.Name = "btnHizmetEkle";
            this.btnHizmetEkle.Size = new System.Drawing.Size(88, 23);
            this.btnHizmetEkle.TabIndex = 12;
            this.btnHizmetEkle.Text = "Ekle";
            this.btnHizmetEkle.UseVisualStyleBackColor = true;
            this.btnHizmetEkle.Click += new System.EventHandler(this.btnHizmetEkle_Click_1);
            // 
            // btnListele
            // 
            this.btnListele.Location = new System.Drawing.Point(598, 275);
            this.btnListele.Name = "btnListele";
            this.btnListele.Size = new System.Drawing.Size(135, 23);
            this.btnListele.TabIndex = 17;
            this.btnListele.Text = "Listele";
            this.btnListele.UseVisualStyleBackColor = true;
            this.btnListele.Click += new System.EventHandler(this.btnListele_Click_1);
            // 
            // dgvHizmetler
            // 
            this.dgvHizmetler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHizmetler.Location = new System.Drawing.Point(12, 12);
            this.dgvHizmetler.Name = "dgvHizmetler";
            this.dgvHizmetler.RowHeadersWidth = 51;
            this.dgvHizmetler.RowTemplate.Height = 24;
            this.dgvHizmetler.Size = new System.Drawing.Size(474, 300);
            this.dgvHizmetler.TabIndex = 18;
            this.dgvHizmetler.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHizmetler_CellClick);
            // 
            // npgsqlCommand1
            // 
            this.npgsqlCommand1.AllResultTypesAreUnknown = false;
            this.npgsqlCommand1.Transaction = null;
            this.npgsqlCommand1.UnknownResultTypeList = null;
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(645, 146);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(88, 23);
            this.btnSil.TabIndex = 19;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Location = new System.Drawing.Point(645, 184);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(88, 23);
            this.btnGuncelle.TabIndex = 20;
            this.btnGuncelle.Text = "Guncelle";
            this.btnGuncelle.UseVisualStyleBackColor = true;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // btnArama
            // 
            this.btnArama.Location = new System.Drawing.Point(645, 225);
            this.btnArama.Name = "btnArama";
            this.btnArama.Size = new System.Drawing.Size(88, 23);
            this.btnArama.TabIndex = 21;
            this.btnArama.Text = "Arama";
            this.btnArama.UseVisualStyleBackColor = true;
            this.btnArama.Click += new System.EventHandler(this.btnArama_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(595, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 16);
            this.label3.TabIndex = 22;
            this.label3.Text = "HİZMET DÜZENLE";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 333);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnArama);
            this.Controls.Add(this.btnGuncelle);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.dgvHizmetler);
            this.Controls.Add(this.btnListele);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFiyat);
            this.Controls.Add(this.txtAd);
            this.Controls.Add(this.btnHizmetEkle);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHizmetler)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFiyat;
        private System.Windows.Forms.TextBox txtAd;
        private System.Windows.Forms.Button btnHizmetEkle;
        private System.Windows.Forms.Button btnListele;
        private System.Windows.Forms.DataGridView dgvHizmetler;
        private Npgsql.NpgsqlCommand npgsqlCommand1;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Button btnArama;
        private System.Windows.Forms.Label label3;
    }
}