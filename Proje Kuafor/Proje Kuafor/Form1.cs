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
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        

        private void hizmetlerForm_Click(object sender, EventArgs e)
        {
            // Yeni form oluştur ve göster
            Form2 yeniForm = new Form2();
            yeniForm.Show(); // Formu aç, ana form açık kalır
           
        }

        private void kisilerForm_Click(object sender, EventArgs e)
        {
            // Yeni form oluştur ve göster
            Form3 yeniForm = new Form3();
            yeniForm.Show(); // Formu aç, ana form açık kalır
        }

        private void iletisimForm_Click(object sender, EventArgs e)
        {
            // Yeni form oluştur ve göster
            Form4 yeniForm = new Form4();
            yeniForm.Show(); // Formu aç, ana form açık kalır
        }

        private void randevuForm_Click(object sender, EventArgs e)
        {
            // Yeni form oluştur ve göster
            Form5 yeniForm = new Form5();
            yeniForm.Show(); // Formu aç, ana form açık kalır
        }
    }
}
