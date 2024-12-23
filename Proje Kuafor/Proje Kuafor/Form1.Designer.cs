namespace Proje_Kuafor
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.hizmetlerForm = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.kisilerForm = new System.Windows.Forms.Button();
            this.iletisimForm = new System.Windows.Forms.Button();
            this.randevuForm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // hizmetlerForm
            // 
            this.hizmetlerForm.Location = new System.Drawing.Point(36, 80);
            this.hizmetlerForm.Name = "hizmetlerForm";
            this.hizmetlerForm.Size = new System.Drawing.Size(177, 60);
            this.hizmetlerForm.TabIndex = 11;
            this.hizmetlerForm.Text = "Hizmet İşlemleri";
            this.hizmetlerForm.UseVisualStyleBackColor = true;
            this.hizmetlerForm.Click += new System.EventHandler(this.hizmetlerForm_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(115, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(241, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "YAPMAK İSTEDİĞİNİZ İŞLEMİ SEÇİNİZ";
            // 
            // kisilerForm
            // 
            this.kisilerForm.Location = new System.Drawing.Point(252, 80);
            this.kisilerForm.Name = "kisilerForm";
            this.kisilerForm.Size = new System.Drawing.Size(177, 60);
            this.kisilerForm.TabIndex = 13;
            this.kisilerForm.Text = "Kişi İşlemleri";
            this.kisilerForm.UseVisualStyleBackColor = true;
            this.kisilerForm.Click += new System.EventHandler(this.kisilerForm_Click);
            // 
            // iletisimForm
            // 
            this.iletisimForm.Location = new System.Drawing.Point(36, 181);
            this.iletisimForm.Name = "iletisimForm";
            this.iletisimForm.Size = new System.Drawing.Size(177, 60);
            this.iletisimForm.TabIndex = 14;
            this.iletisimForm.Text = "İletişim İşlemleri";
            this.iletisimForm.UseVisualStyleBackColor = true;
            this.iletisimForm.Click += new System.EventHandler(this.iletisimForm_Click);
            // 
            // randevuForm
            // 
            this.randevuForm.Location = new System.Drawing.Point(252, 181);
            this.randevuForm.Name = "randevuForm";
            this.randevuForm.Size = new System.Drawing.Size(177, 60);
            this.randevuForm.TabIndex = 15;
            this.randevuForm.Text = "Randevu İşlemleri";
            this.randevuForm.UseVisualStyleBackColor = true;
            this.randevuForm.Click += new System.EventHandler(this.randevuForm_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 313);
            this.Controls.Add(this.randevuForm);
            this.Controls.Add(this.iletisimForm);
            this.Controls.Add(this.kisilerForm);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.hizmetlerForm);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button hizmetlerForm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button kisilerForm;
        private System.Windows.Forms.Button iletisimForm;
        private System.Windows.Forms.Button randevuForm;
    }
}

