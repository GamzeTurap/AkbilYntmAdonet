namespace AkbilYonetimiUI
{
    partial class frmKayitOl
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
            groupBox1 = new GroupBox();
            dtpDogumTarihi = new DateTimePicker();
            btnGiris = new Button();
            txtIsim = new TextBox();
            btnKayitOl = new Button();
            label1 = new Label();
            txtSifre = new TextBox();
            label2 = new Label();
            txtEmail = new TextBox();
            label3 = new Label();
            txtSoyisim = new TextBox();
            label4 = new Label();
            label5 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.Window;
            groupBox1.Controls.Add(dtpDogumTarihi);
            groupBox1.Controls.Add(btnGiris);
            groupBox1.Controls.Add(txtIsim);
            groupBox1.Controls.Add(btnKayitOl);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtSifre);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtEmail);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtSoyisim);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label5);
            groupBox1.Location = new Point(64, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(370, 346);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // dtpDogumTarihi
            // 
            dtpDogumTarihi.Location = new Point(129, 176);
            dtpDogumTarihi.Name = "dtpDogumTarihi";
            dtpDogumTarihi.Size = new Size(212, 23);
            dtpDogumTarihi.TabIndex = 4;
            // 
            // btnGiris
            // 
            btnGiris.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            btnGiris.Location = new Point(58, 285);
            btnGiris.Name = "btnGiris";
            btnGiris.Size = new Size(291, 41);
            btnGiris.TabIndex = 6;
            btnGiris.Text = "GİRİŞ YAP";
            btnGiris.UseVisualStyleBackColor = true;
            btnGiris.Click += btnGiris_Click;
            // 
            // txtIsim
            // 
            txtIsim.Location = new Point(129, 22);
            txtIsim.Name = "txtIsim";
            txtIsim.Size = new Size(211, 23);
            txtIsim.TabIndex = 0;
            // 
            // btnKayitOl
            // 
            btnKayitOl.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            btnKayitOl.Location = new Point(58, 223);
            btnKayitOl.Name = "btnKayitOl";
            btnKayitOl.Size = new Size(291, 41);
            btnKayitOl.TabIndex = 5;
            btnKayitOl.Text = "KAYIT OL";
            btnKayitOl.UseVisualStyleBackColor = true;
            btnKayitOl.Click += btnKayitOl_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label1.Location = new Point(18, 28);
            label1.Name = "label1";
            label1.Size = new Size(35, 17);
            label1.TabIndex = 44;
            label1.Text = "AD :";
            // 
            // txtSifre
            // 
            txtSifre.Location = new Point(129, 139);
            txtSifre.Name = "txtSifre";
            txtSifre.Size = new Size(211, 23);
            txtSifre.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label2.Location = new Point(18, 65);
            label2.Name = "label2";
            label2.Size = new Size(60, 17);
            label2.TabIndex = 43;
            label2.Text = "SOYAD :";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(129, 101);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(211, 23);
            txtEmail.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label3.Location = new Point(18, 102);
            label3.Name = "label3";
            label3.Size = new Size(59, 17);
            label3.TabIndex = 42;
            label3.Text = "e-MAİL :";
            // 
            // txtSoyisim
            // 
            txtSoyisim.Location = new Point(129, 59);
            txtSoyisim.Name = "txtSoyisim";
            txtSoyisim.Size = new Size(211, 23);
            txtSoyisim.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label4.Location = new Point(18, 176);
            label4.Name = "label4";
            label4.Size = new Size(112, 17);
            label4.TabIndex = 41;
            label4.Text = "DOĞUM TARİHİ :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label5.Location = new Point(18, 139);
            label5.Name = "label5";
            label5.Size = new Size(49, 17);
            label5.TabIndex = 40;
            label5.Text = "ŞİFRE :";
            // 
            // frmKayitOl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Yellow;
            ClientSize = new Size(536, 370);
            Controls.Add(groupBox1);
            Name = "frmKayitOl";
            Text = "frmKayitOl";
            FormClosed += frmKayitOl_FormClosed;
            Load += frmKayitOl_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private DateTimePicker dtpDogumTarihi;
        private Button btnGiris;
        private TextBox txtIsim;
        private Button btnKayitOl;
        private Label label1;
        private TextBox txtSifre;
        private Label label2;
        private TextBox txtEmail;
        private Label label3;
        private TextBox txtSoyisim;
        private Label label4;
        private Label label5;
    }
}