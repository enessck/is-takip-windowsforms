using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp4.Entity;
using WindowsFormsApp4.Formlar;

namespace WindowsFormsApp4.Login
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 fr = new Form1();
            fr.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PersonelGorevFormlari.FrmPersonelFormu fr =new PersonelGorevFormlari.FrmPersonelFormu();
            fr.Show();
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void hyperlinkLabelControl1_Click(object sender, EventArgs e)
        {

        }

        private void hyperlinkLabelControl2_Click(object sender, EventArgs e)
        {

        }

        private void textEdit1_Click(object sender, EventArgs e)
        {  
            panel3.BackColor = Color.White;
            panel2.BackColor = SystemColors.Control;
        }

        private void textEdit2_Click(object sender, EventArgs e)
        {
            panel2.BackColor= Color.White;
            panel3.BackColor = SystemColors.Control;
        }
        dbis_TakipEntities6 db = new dbis_TakipEntities6();
        private void BtnAdmin_Click(object sender, EventArgs e)
        {
            var adminvalue = db.tbladmin.Where(x => x.Kullanici == TxtKullaniciAdi.Text && x.Sifre == TxtSifre.Text).FirstOrDefault();
            if (adminvalue != null)
            {
                XtraMessageBox.Show("Hoşgeldiniz");
                Form1 fr = new Form1();
                fr.Show();
                this.Hide();
            }
            else
            {
                XtraMessageBox.Show("Hatalı Giriş");
            }
        }

        private void BtnPersonel_Click(object sender, EventArgs e)
        {
            var personel = db.tblpersonel.Where(x => x.Mail == TxtKullaniciAdi.Text && x.Sifre == TxtSifre.Text).FirstOrDefault();
            if (personel != null)
            {
                PersonelGorevFormlari.FrmPersonelFormu fr = new PersonelGorevFormlari.FrmPersonelFormu();
                fr.mail = TxtKullaniciAdi.Text;
                fr.Show();
                this.Hide();
            }
            else
            {
                XtraMessageBox.Show("Hatalı Giriş");
            }


        }

        private void hyperlinkLabelControl1_Click_1(object sender, EventArgs e)
        {
            FrmSifreDegistir frm = new FrmSifreDegistir();
            frm.Show(); // Diğer formu açar
        }

        private void hyperlinkLabelControl3_Click(object sender, EventArgs e)
        {
            try
            {
                // Gitmek istediğin URL adresini buraya yaz
                string url = "https://localhost:44363/Login/Index";

                // Tarayıcıyı başlatır
                Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true // .NET Core/5+ kullanıyorsan bu satır zorunludur
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Web sayfası açılamadı: " + ex.Message);
            }
        }

        private void hyperlinkLabelControl4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void hyperlinkLabelControl2_Click_1(object sender, EventArgs e)
        {
            FrmYardim frm = new FrmYardim();
            // Formun ekranın ortasında açılması için:
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
