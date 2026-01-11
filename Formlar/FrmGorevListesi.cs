
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
    public partial class FrmGorevListesi : Form
    {
        public FrmGorevListesi()
        {
            InitializeComponent();
        }
        dbis_TakipEntities6 db = new dbis_TakipEntities6();

        private void FrmGorevListesi_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.tblgorevler
                                       select new
                                       {
                                           x.Id,
                                           x.Aciklama
                                       }).ToList();
            LblAktifGorev.Text =  db.tblgorevler.Where(x => x.Durum == true).Count().ToString();
            LblPasifGorev.Text = db.tblgorevler.Where(x => x.Durum == false).Count().ToString();
            LblToplamDepartman.Text = db.tbldepartmanlar.Count().ToString();


            chartControl1.Series["Durum"].Points.AddPoint("Aktif Gorevler", int.Parse(LblAktifGorev.Text));
            chartControl1.Series["Durum"].Points.AddPoint("Pasif Gorevler", int.Parse(LblPasifGorev.Text));
        }
    }
}
