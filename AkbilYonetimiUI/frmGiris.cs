using System.Data.SqlClient;

namespace AkbilYonetimiUI
{
    public partial class frmGiris : Form
    {
        public string Email { get; set; }// kay�t ol formunda olan kullano�c�n�n emaili buraya gelsin
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
            //bu formu gizleyece�iz
            //kay�t ol formu a�aca��z
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
                // 1) Email ve �ifre textboxlar� dolu mu?,

                if (string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtSifre.Text))
                {
                    MessageBox.Show("Bilgileri eksizsiz giriniz!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                //2) Girdi�i email ve �ifre veritaban�nda mevcut mu?
                //select*from Kullanicilar where Email=''and Sifre=''
                string baglantiCumlesi = @"Server=DESKTOP-E30TBPJ;Database=AKBILDB;Trusted_Connection=True;";
                SqlConnection baglanti = new SqlConnection(baglantiCumlesi);
                string sorgu = $"select*from Kullanicilar where Email='{txtEmail.Text.Trim()}'and Parola='{txtSifre.Text.Trim()}'";

                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                baglanti.Open();

                SqlDataReader okuyucu = komut.ExecuteReader();
                if (!okuyucu.HasRows)//DE��LSE yanl�� giri� mesaj� verecek
                {
                    MessageBox.Show("Email ya da �ifrenizi do�ru girdinize emin olunuz!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    baglanti.Close();
                    return;
                }

                else
                {
                    while (okuyucu.Read())
                    {
                        MessageBox.Show($"HO�GELD�N�Z {okuyucu["Ad"]} {okuyucu["Soyad"]}");
                        Properties.Settings1.Default.KullaniciId = (int)okuyucu["Id"];
                    }
                    baglanti.Close();
                    //E�er email -�ifre do�ruysa
                    //E�er beni Hat�rla'y� t�klad�ysa ?? Bilgileri hat�rlanacak...
                    //ho�geldiniz yazacak ve anasayfa formuna y�nlendirilecek
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
                //Dipnot: Exceptionlar asla kullan�cya g�sterilmez. Exceptionlar loglan�r. Biz �u an geli�tirme/��renme a�amas�nda oldu�umuz i�in yazd�k.
                MessageBox.Show("Beklenmedik bir sorun olu�tu! " + hata.Message);
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
            if (e.KeyChar == Convert.ToChar(Keys.Enter)) // bas�lan tu� enter ise giri� yapacak.
            {
                GirisYap();

            }
        }
    }
}
