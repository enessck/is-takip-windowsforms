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
using WindowsFormsApp4.PersonelGorevFormlari;

namespace WindowsFormsApp4.Formlar
{
    public partial class FrmAktifCagrilar : Form
    {
        public FrmAktifCagrilar()
        {
            InitializeComponent();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void FrmAktifCagrilar_Load(object sender, EventArgs e)
        {
            dbis_TakipEntities6 db = new dbis_TakipEntities6();
            var degerler = (from x in db.tblcagrilar
                            select new
                            {
                                x.ID,
                                x.tblfirmalar.Ad,
                                x.tblfirmalar.Telefon,
                                x.Konu,
                                x.Aciklama,
                                Personel = x.tblpersonel.Ad,
                                x.Durum
                            }
                            ).Where(y => y.Durum == true).ToList();
            gridControl1.DataSource = degerler;
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmCagriAtama fr = new FrmCagriAtama();
            fr.id = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
            fr.Show();
        }
    }
}
