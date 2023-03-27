using System.Data.SqlClient;

namespace AkbilYonetimiUI
{
    public partial class frmGiris : Form
    {
        public string Email { get; set; }// kayýt ol formunda olan kullanoýcýnýn emaili buraya gelsin
        public frmGiris()
        {
            InitializeComponent();
        }
        private void frmGiris_Load(object sender, EventArgs e)
        {
            if (Email != null)
            {
                txtEmail.Text = Email;
            }


            txtEmail.TabIndex = 1;
            txtSifre.TabIndex = 2;
            checkBoxHatirla.TabIndex = 3;
            btnGirisYap.TabIndex = 4;
            btnKayitOl.TabIndex = 5;

            if (Properties.Settings1.Default.BeniHatirla)
            {
                txtEmail.Text = Properties.Settings1.Default.KullaniciEmail;
                txtSifre.Text = Properties.Settings1.Default.KullaniciSifre;
                checkBoxHatirla.Checked = true;
            }


        }

        private void btnKayitOl_Click(object sender, EventArgs e)
        {
            //bu formu gizleyeceðiz
            //kayýt ol formu açacaðýz
            this.Hide();
            frmKayitOl frm = new frmKayitOl();
            frm.Show();
        }


        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            GirisYap();
        }

        private void GirisYap()
        {
            try
            {
                // 1) Email ve þifre textboxlarý dolu mu?,

                if (string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtSifre.Text))
                {
                    MessageBox.Show("Bilgileri eksizsiz giriniz!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                //2) Girdiði email ve þifre veritabanýnda mevcut mu?
                //select*from Kullanicilar where Email=''and Sifre=''
                string baglantiCumlesi = @"Server=DESKTOP-E30TBPJ;Database=AKBILDB;Trusted_Connection=True;";
                SqlConnection baglanti = new SqlConnection(baglantiCumlesi);
                string sorgu = $"select*from Kullanicilar where Email='{txtEmail.Text.Trim()}'and Parola='{txtSifre.Text.Trim()}'";

                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                baglanti.Open();

                SqlDataReader okuyucu = komut.ExecuteReader();
                if (!okuyucu.HasRows)//DEÐÝLSE yanlýþ giriþ mesajý verecek
                {
                    MessageBox.Show("Email ya da þifrenizi doðru girdinize emin olunuz!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    baglanti.Close();
                    return;
                }

                else
                {
                    while (okuyucu.Read())
                    {
                        MessageBox.Show($"HOÞGELDÝNÝZ {okuyucu["Ad"]} {okuyucu["Soyad"]}");
                        Properties.Settings1.Default.KullaniciId = (int)okuyucu["Id"];
                    }
                    baglanti.Close();
                    //Eðer email -þifre doðruysa
                    //Eðer beni Hatýrla'yý týkladýysa ?? Bilgileri hatýrlanacak...
                    //hoþgeldiniz yazacak ve anasayfa formuna yönlendirilecek
                    if (checkBoxHatirla.Checked)
                    {
                        Properties.Settings1.Default.BeniHatirla = true;
                        Properties.Settings1.Default.KullaniciEmail = txtEmail.Text.Trim();
                        Properties.Settings1.Default.KullaniciSifre = txtSifre.Text.Trim();
                        Properties.Settings1.Default.Save();
                    }
                    else
                    {
                        Properties.Settings1.Default.BeniHatirla = false;
                        Properties.Settings1.Default.KullaniciEmail = "";
                        Properties.Settings1.Default.KullaniciSifre = string.Empty;
                        Properties.Settings1.Default.Save();
                    }
                    this.Hide();
                    FrmAnasayfa frma = new FrmAnasayfa();
                    frma.Show();

                }

            }
            catch (Exception hata)
            {
                //Dipnot: Exceptionlar asla kullanýcya gösterilmez. Exceptionlar loglanýr. Biz þu an geliþtirme/öðrenme aþamasýnda olduðumuz için yazdýk.
                MessageBox.Show("Beklenmedik bir sorun oluþtu! " + hata.Message);
            }
        }

        private void checkBoxHatirla_CheckedChanged(object sender, EventArgs e)
        {

            BeniHatirlaAyarla();
        }

        private void BeniHatirlaAyarla()
        {
            if (checkBoxHatirla.Checked)
            {
                Properties.Settings1.Default.BeniHatirla = true;
            }
            else
            {
                Properties.Settings1.Default.BeniHatirla = false;
            }
        }
        private void txtSifre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter)) // basýlan tuþ enter ise giriþ yapacak.
            {
                GirisYap();

            }
        }
    }
}
