using System.Data.SqlClient;

namespace AkbilYonetimiUI
{
    public partial class frmGiris : Form
    {
        public frmGiris()
        {
            InitializeComponent();
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
            try
            {
                // 1) Email ve þifre textboxlarý dolu mu?,
                
                    if (string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtSifre.Text))
                {
                    MessageBox.Show("Bilgileri eksizsiz giriniz!", "UYARI", MessageBoxButtons.OK,MessageBoxIcon.Stop);
                    return;
                }
                //2) Girdiði email ve þifre veritabanýnda mevcut mu?
                //select*from Kullanicilar where Email=''and Sifre=''
                string baglantiCumlesi = " @\"Server=DESKTOP-E30TBPJ;Database=AKBILDB;Trusted_Connection=True;";
                SqlConnection baglanti = new SqlConnection(baglantiCumlesi);
                string sorgu = $"select*from Kullanicilar where Email='{txtEmail.Text.Trim()}'and Sifre='{txtSifre.Text.Trim()}'";

                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                baglanti.Open();

                SqlDataReader okuyucu = komut.ExecuteReader();
                if(!okuyucu.HasRows)
                {
                    MessageBox.Show("Email ya da þifrenizi doðru girdinize emin olunuz!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                else
                {
                    while(okuyucu.Read())
                    {
                        MessageBox.Show($"HOÞGELDÝNÝZ {okuyucu["Ad"]} {okuyucu["Soyad"]}");
                    }
                    baglanti.Close();

                }


                //Eðer email -þifre doðruysa
                //Eðer beni Hatýrla'yý týkladýysa ?? Bilgileri hatýrlanacak...
                //hoþgeldiniz yazacak ve anasayfa formuna yönlendirilecek
                //
                //
                //DEÐÝLSE yanlýþ giriþ mesajý verecek
            }
            catch (Exception hata)
            {
                //Dipnot: Exceptionlar asla kullanýcya gösterilmez. Exceptionlar loglanýr. Biz þu an geliþtirme/öðrenme aþamasýnda olduðumuz için yazdýk.
                MessageBox.Show("Beklenmedik bir sorun oluþtu! " + hata.Message);
            }
        }
    }
}