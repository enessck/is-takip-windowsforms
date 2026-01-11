using DevExpress.XtraGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp4.Entity;

namespace WindowsFormsApp4.Formlar
{
    public partial class FrmAnaform : Form
    {
        public FrmAnaform()
        {
            InitializeComponent();
        }
        dbis_TakipEntities6 db = new dbis_TakipEntities6();
        private void FrmAnaform_Load(object sender, EventArgs e)
        {
        

            gridControl1.DataSource = (from x in db.tblgorevler
                                       select new
                                       {
                                           x.Aciklama,
                                           Personel = x.tblpersonel.Ad + " " + x.tblpersonel.Soyad, x.Durum
                                       }).Where(y => y.Durum == true).ToList();
            gridView1.Columns["Durum"].Visible = false;

            DateTime bugun = DateTime.Parse(DateTime.Now.ToShortDateString());
            //MessageBox.Show(bugun.ToString());
            gridControl2.DataSource = (from x in db.tblgorevdetaylar
                                       select new
                                       {
                                           Görev = x.tblgorevler.Aciklama,
                                           x.Aciklama,
                                           x.Tarih
                                       }).Where(x => x.Tarih == bugun).ToList();
         
            gridControl3.DataSource = (from x in db.tblcagrilar
                                       select new
                                       {
                                           x.tblfirmalar.Ad,
                                           x.Konu,
                                           x.Tarih,
                                           x.Durum
                                       }).Where(x =>x.Durum == true).ToList();
            gridControl4.DataSource = (from x in db.tblfirmalar
                                       select new
                                       {
                                           x.Ad,
                                           x.Telefon,
                                           x.Mail
                                       }).ToList();
            int aktif_cagrilar = db.tblcagrilar.Where(x => x.Durum == true).Count();
            int pasif_cagrilar = db.tblgorevler.Where(x => x.Durum == false).Count();
           


            chartControl1.Series["Series 1"].Points.AddPoint("Aktif çağrılar", aktif_cagrilar);
            chartControl1.Series["Series 1"].Points.AddPoint("Pasif çağrılar", pasif_cagrilar);
        }

           
    }
}

