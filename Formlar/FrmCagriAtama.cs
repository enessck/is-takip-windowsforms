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
    public partial class FrmCagriAtama : Form
    {
        public FrmCagriAtama()
        {
            InitializeComponent();
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void labelControl6_Click(object sender, EventArgs e)
        {

        }

        private void pictureEdit6_EditValueChanged(object sender, EventArgs e)
        {

        }
        public int id;
        dbis_TakipEntities6 db = new dbis_TakipEntities6();
        private void FrmCagriAtama_Load(object sender, EventArgs e)
        {
            var degerler = (from x in db.tblpersonel
                            select new
                            {
                                x.ID,
                                AdSoyad = x.Ad + " " + x.Soyad // Soyad da varsa ekleyebilirsiniz
                            }).ToList();

            // --- BU KISMI EKLEYİN ---
            lookUpEdit1.Properties.ValueMember = "ID";   // Arka planda tutulacak değer (Sayı)
            lookUpEdit1.Properties.DisplayMember = "AdSoyad"; // Ekranda görünecek değer (İsim)
            lookUpEdit1.Properties.DataSource = degerler;
            TxtCagriID.Text = id.ToString();
            var gelenveri = db.tblcagrilar.Find(id);
            TxtAciklama.Text = gelenveri.Aciklama;
            TxtTarih.Text = gelenveri.Tarih.ToString();
            TxtKonu.Text = gelenveri.Konu;
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            var gelenveri = db.tblcagrilar.Find(id);
            gelenveri.Konu = TxtKonu.Text;
            gelenveri.Tarih = Convert.ToDateTime(TxtTarih.Text);
            gelenveri.Aciklama = TxtAciklama.Text;
            gelenveri.CagriPersonel = int.Parse(lookUpEdit1.EditValue.ToString());
            db.SaveChanges();
        }
    }
}
