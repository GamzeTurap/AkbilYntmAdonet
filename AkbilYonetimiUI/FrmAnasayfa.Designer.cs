namespace AkbilYonetimiUI
{
    partial class FrmAnasayfa
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
            btnAkbil = new Button();
            btnTalimat = new Button();
            btnAyarlar = new Button();
            SuspendLayout();
            // 
            // btnAkbil
            // 
            btnAkbil.BackColor = Color.Gold;
            btnAkbil.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            btnAkbil.ForeColor = Color.DarkOliveGreen;
            btnAkbil.Location = new Point(38, 31);
            btnAkbil.Name = "btnAkbil";
            btnAkbil.Size = new Size(180, 75);
            btnAkbil.TabIndex = 0;
            btnAkbil.Text = "AKBİL İŞLEMLERİ";
            btnAkbil.UseVisualStyleBackColor = false;
            btnAkbil.Click += btnAkbil_Click;
            // 
            // btnTalimat
            // 
            btnTalimat.BackColor = Color.Gold;
            btnTalimat.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            btnTalimat.ForeColor = Color.DarkOliveGreen;
            btnTalimat.Location = new Point(38, 135);
            btnTalimat.Name = "btnTalimat";
            btnTalimat.Size = new Size(180, 76);
            btnTalimat.TabIndex = 0;
            btnTalimat.Text = "TALİMATLAR";
            btnTalimat.UseVisualStyleBackColor = false;
            // 
            // btnAyarlar
            // 
            btnAyarlar.BackColor = Color.Gold;
            btnAyarlar.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            btnAyarlar.ForeColor = Color.DarkOliveGreen;
            btnAyarlar.Location = new Point(38, 235);
            btnAyarlar.Name = "btnAyarlar";
            btnAyarlar.Size = new Size(180, 82);
            btnAyarlar.TabIndex = 0;
            btnAyarlar.Text = "AYARLAR";
            btnAyarlar.UseVisualStyleBackColor = false;
            btnAyarlar.Click += btnAyarlar_Click;
            // 
            // FrmAnasayfa
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(251, 329);
            Controls.Add(btnAyarlar);
            Controls.Add(btnTalimat);
            Controls.Add(btnAkbil);
            Name = "FrmAnasayfa";
            Text = "FrmAnasayfa";
            ResumeLayout(false);
        }

        #endregion

        private Button btnAkbil;
        private Button btnTalimat;
        private Button btnAyarlar;
    }
}