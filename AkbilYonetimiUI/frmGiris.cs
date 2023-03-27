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
            //bu formu gizleyece�iz
            //kay�t ol formu a�aca��z
            this.Hide();
            frmKayitOl frm = new frmKayitOl();
            frm.Show();
        }

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            try
            {
                // 1) Email ve �ifre textboxlar� dolu mu?,
                
                    if (string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtSifre.Text))
                {
                    MessageBox.Show("Bilgileri eksizsiz giriniz!", "UYARI", MessageBoxButtons.OK,MessageBoxIcon.Stop);
                    return;
                }
                //2) Girdi�i email ve �ifre veritaban�nda mevcut mu?
                //select*from Kullanicilar where Email=''and Sifre=''
                string baglantiCumlesi = " @\"Server=DESKTOP-E30TBPJ;Database=AKBILDB;Trusted_Connection=True;";
                SqlConnection baglanti = new SqlConnection(baglantiCumlesi);
                string sorgu = $"select*from Kullanicilar where Email='{txtEmail.Text.Trim()}'and Sifre='{txtSifre.Text.Trim()}'";

                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                baglanti.Open();

                SqlDataReader okuyucu = komut.ExecuteReader();
                if(!okuyucu.HasRows)
                {
                    MessageBox.Show("Email ya da �ifrenizi do�ru girdinize emin olunuz!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                else
                {
                    while(okuyucu.Read())
                    {
                        MessageBox.Show($"HO�GELD�N�Z {okuyucu["Ad"]} {okuyucu["Soyad"]}");
                    }
                    baglanti.Close();

                }


                //E�er email -�ifre do�ruysa
                //E�er beni Hat�rla'y� t�klad�ysa ?? Bilgileri hat�rlanacak...
                //ho�geldiniz yazacak ve anasayfa formuna y�nlendirilecek
                //
                //
                //DE��LSE yanl�� giri� mesaj� verecek
            }
            catch (Exception hata)
            {
                //Dipnot: Exceptionlar asla kullan�cya g�sterilmez. Exceptionlar loglan�r. Biz �u an geli�tirme/��renme a�amas�nda oldu�umuz i�in yazd�k.
                MessageBox.Show("Beklenmedik bir sorun olu�tu! " + hata.Message);
            }
        }
    }
}