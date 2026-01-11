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
    public partial class FrmPersonelİstatistik : Form
    {
        public FrmPersonelİstatistik()
        {
            InitializeComponent();
        }

        dbis_TakipEntities6 db = new dbis_TakipEntities6();
        private void FrmPersonelİstatistik_Load(object sender, EventArgs e)
        {
           LblToplamDepartman.Text  = db.tbldepartmanlar.Count().ToString();
           LblToplamFirma.Text = db.tblfirmalar.Count().ToString();
           LblToplamPersonel.Text = db.tblpersonel.Count().ToString();
           LblAktifİs.Text = db.tblgorevler.Count(X =>X.Durum == true).ToString();
           LblPasifİs.Text = db.tblgorevler.Count(X => X.Durum == false).ToString();
           LblSonGorevDetay.Text = db.tblgorevler.OrderByDescending(x => x.Id).Select(x => x.Tarih).FirstOrDefault().ToString();
           LblSonGorev.Text = db.tblgorevler.OrderByDescending(x => x.Id).Select(x => x.Aciklama).FirstOrDefault();
           LblSehirSayisi.Text = db.tblfirmalar.Select(x =>x.il).Distinct().Count().ToString();
           LblSektor.Text = db.tblfirmalar.Select(x => x.Sektor).Distinct().Count().ToString();
           DateTime bugun = DateTime.Today;
           LblBugunAcilanGorevler.Text = db.tblgorevler.Count(x=>x.Tarih == bugun).ToString();
           var d1 = db.tblgorevler.GroupBy(x =>x.GorevAlan).OrderByDescending(z => z.Count()).Select(y =>y.Key).FirstOrDefault();
          
           LblAyinPersoneli.Text = db.tblpersonel.Where(x => x.ID == d1).Select(y => y.Ad + " "+ y.Soyad).FirstOrDefault().ToString();
            LblAyinDepartmani.Text = db.tbldepartmanlar.Where(x => x.ID == db.tblpersonel.Where(t => t.ID ==d1).Select(z => z.Departman).FirstOrDefault()).Select(y => y.Ad).FirstOrDefault().ToString(); 
        }
    }
}
