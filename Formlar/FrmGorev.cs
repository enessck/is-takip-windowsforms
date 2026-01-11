using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp4.Entity;

namespace WindowsFormsApp4.Formlar
{
    public partial class FrmGorev : Form
    {
        public FrmGorev()
        {
            InitializeComponent();
        }

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        dbis_TakipEntities6 db = new dbis_TakipEntities6();
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            tblgorevler t = new tblgorevler();
            t.Aciklama = TxtAciklama.Text;
            t.Durum = true;
            t.GorevAlan = Convert.ToInt32(lookUpEdit1.EditValue);
            t.Tarih = DateTime.Parse(TxtTarih.Text);
            t.GorevVeren = int.Parse(TxtGorevVeren.Text);
            db.tblgorevler.Add(t);
            db.SaveChanges();
            XtraMessageBox.Show("Görev başarılı bir şekilde tamamlandı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FrmGorev_Load(object sender, EventArgs e)
        {
            var degerler = (from x in db.tblpersonel
                            select new
                            {
                                x.ID,
                                AdSoyad =x.Ad +" " + x.Soyad // Soyad da varsa ekleyebilirsiniz
                            }).ToList();

            // --- BU KISMI EKLEYİN ---
            lookUpEdit1.Properties.ValueMember = "ID";   // Arka planda tutulacak değer (Sayı)
            lookUpEdit1.Properties.DisplayMember = "AdSoyad"; // Ekranda görünecek değer (İsim)
            lookUpEdit1.Properties.DataSource = degerler; // Veriyi bağla
        }
    }   
}
