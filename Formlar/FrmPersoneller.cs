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
    public partial class FrmPersoneller : Form
    {
        public FrmPersoneller()
        {
            InitializeComponent();
        }
        dbis_TakipEntities6 db = new dbis_TakipEntities6();
        void personeller()
        {
            var degerler = from x in db.tblpersonel
                           select new
                           {
                               x.ID,
                               x.Ad,
                               x.Soyad,
                               x.Mail,
                               Departman = x.tbldepartmanlar.Ad,
                               x.Durum
                           };
            gridControl1.DataSource = degerler.Where(x => x.Durum == true).ToList();
        }
        private void FrmPersoneller_Load(object sender, EventArgs e)
        {
            personeller();
            var departmanlar = (from x in db.tbldepartmanlar
                                select new
                                {
                                    x.ID,
                                    x.Ad,
                                }).ToList();
            lookUpEdit1.Properties.ValueMember = "ID";
            lookUpEdit1.Properties.ValueMember = "Ad";
            lookUpEdit1.Properties.DataSource = departmanlar;

        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            personeller();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            var x = int.Parse(TxtID.Text);
            var deger = db.tblpersonel.Find(x);
            deger.Durum = false;
            db.SaveChanges();
            XtraMessageBox.Show("Personel başarılı bir şekilde silindi, silinen personeller listesinden tüm silinmiş personel bilgilerine ulaşabilirsiniz...", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            personeller();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            TxtID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            TxtAd.Text = gridView1.GetFocusedRowCellValue("Ad").ToString();
            TxtSoyad.Text = gridView1.GetFocusedRowCellValue("Soyad").ToString();
            TxtMail.Text = gridView1.GetFocusedRowCellValue("Mail").ToString();
            //TxtGorsel.Text = gridView1.GetFocusedRowCellValue("Gorsel").ToString();
            lookUpEdit1.EditValue = gridView1.GetFocusedRowCellValue("Departman").ToString();
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {

            int x = int.Parse(TxtID.Text);
            var deger = db.tblpersonel.Find(x);

            deger.Ad = TxtAd.Text;
            deger.Soyad = TxtSoyad.Text;
            deger.Mail = TxtMail.Text;
            deger.Görsel = TxtGorsel.Text;

            // YENİ GÜVENLİ KISIM:
            if (lookUpEdit1.EditValue != null)
            {
                int departmanId;
                // EditValue içindeki değeri sayıya çevirmeyi dene
                if (int.TryParse(lookUpEdit1.EditValue.ToString(), out departmanId))
                {
                    deger.Departman = departmanId;
                }
                else
                {
                    // Eğer hala "Danışma" gibi bir metin geliyorsa burası çalışır
                    // Bu durumda ValueMember ayarın hala hatalı demektir.
                    MessageBox.Show("Departman ID alınamadı. Lütfen ValueMember ayarını kontrol edin.");
                    return;
                }
            }

            db.SaveChanges();
            personeller();
            MessageBox.Show("Personel başarıyla güncellendi.");
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
    } 
    
}

