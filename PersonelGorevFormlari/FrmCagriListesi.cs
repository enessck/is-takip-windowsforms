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

namespace WindowsFormsApp4.PersonelGorevFormlari
{
    public partial class FrmCagriListesi : Form
    {
        public FrmCagriListesi()
        {
            InitializeComponent();
        }
        dbis_TakipEntities6 db = new dbis_TakipEntities6();
        public string mail2;
        private void FrmCagriListesi_Load(object sender, EventArgs e)
        {
            var personelid = db.tblpersonel.Where(x => x.Mail == mail2).Select(y => y.ID).FirstOrDefault();
            gridControl1.DataSource = (from x in db.tblcagrilar
                                       select new
                                       {
                                           x.tblfirmalar.ID,
                                           x.tblfirmalar.Ad,
                                           x.tblfirmalar.Telefon,
                                           x.tblfirmalar.Mail,
                                           x.Aciklama,
                                           x.CagriPersonel,
                                           x.Durum
                                       }).Where(y => y.Durum == true && y.CagriPersonel ==personelid).ToList();
            gridView1.Columns["Durum"].Visible = false;
            gridView1.Columns["ÇAĞRI PERSONEL"].Visible = false;
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmCagriDetayGirisi fr = new FrmCagriDetayGirisi ();
            fr.id = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
            fr.Show();
        }
    }
}
