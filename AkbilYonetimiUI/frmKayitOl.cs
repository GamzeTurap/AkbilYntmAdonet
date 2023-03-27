
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AkbilYonetimiUI
{
    public partial class frmKayitOl : Form
    {
        public frmKayitOl()
        {
            InitializeComponent();
        }

        private void frmKayitOl_Load(object sender, EventArgs e)
        {
            txtSifre.PasswordChar = '*';
            dtpDogumTarihi.MaxDate = new DateTime(2016, 1, 1);
            dtpDogumTarihi.Value = new DateTime(2016, 1, 1);
            dtpDogumTarihi.Format = DateTimePickerFormat.Short;
        }

        private void btnKayitOl_Click(object sender, EventArgs e)
        {
            try
            {

                //1) Emailden kayıtlı biri zaten var mı? 
                string baglantiCumlesi = @"Server=DESKTOP-E30TBPJ;Database=AKBILDB;Trusted_Connection=True;";

                SqlConnection baglanti = new SqlConnection(); // baglanti nesnesi
                baglanti.ConnectionString = baglantiCumlesi; // nereye bağlanacak ?
                SqlCommand komut = new SqlCommand(); //komut nesnesi türettik
                komut.Connection = baglanti; // komutun hangi bağlantıda çalışacağını atadık.
                komut.CommandText = $"select*from Kullanicilar(nolock) where eMail='{txtEmail.Text.Trim()}'"; // sql komutu
                baglanti.Open();

                SqlDataReader okuyucu = komut.ExecuteReader(); // çalıştır
                if (okuyucu.HasRows) // Satır var mı?
                {
                    while (okuyucu.Read()) // verileri okurken x işlemleri yap
                    {
                        MessageBox.Show("Bu mail zaten sisteme kayıtlıdır!", "UYARI,", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                }
                baglanti.Close();

                //2) Emaili daha önce kayıtlı değilse KAYIT OLACAK.
                if (string.IsNullOrEmpty(txtIsim.Text) || string.IsNullOrEmpty(txtSoyisim.Text) || string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtSifre.Text))
                // baglanti.ConnectionString = baglantiCumlesi;
                {
                    MessageBox.Show("Bilgileri eksiksiz giriniz !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                string insertSQL = $"insert into Kullanicilar(EklenmeTarihi,Email,Parola,Ad,Soyad,DogumTarihi) values" +
                           $"('{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}','{txtEmail.Text.Trim()}','{txtSifre.Text.Trim()}','{txtIsim.Text.Trim()}','{txtSoyisim.Text.Trim()}','{dtpDogumTarihi.Value.ToString("yyyyMMdd")}')";
                SqlCommand eklemeKomut = new SqlCommand(insertSQL, baglanti);
                baglanti.Open();
                int rowEffected = eklemeKomut.ExecuteNonQuery();
                if (rowEffected > 0)
                {
                    MessageBox.Show("KAYIT EKLENDİ !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GirisFormunaGit();
                }
                else
                {
                    MessageBox.Show("KAYIT EKLENEMEDİ !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                baglanti.Close();
                //temizlik gerekli

            }
            catch (Exception ex)
            {
                //ex log.txt'ye yazılacak (loglama)
                MessageBox.Show("Beklenmedik bir hata oluştu. Lütfen tekrar deneyiniz.");
            }
        }

        private void GirisFormunaGit()
        {
            frmGiris frmG = new frmGiris();
            frmG.Email = txtEmail.Text.Trim();
            this.Hide();
            frmG.Show();
        }

        private void frmKayitOl_FormClosed(object sender, FormClosedEventArgs e)
        {
            GirisFormunaGit();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            GirisFormunaGit();
        }
    }
}
