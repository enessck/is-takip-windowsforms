using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4.PersonelGorevFormlari
{
    public partial class FrmPersonelFormu : Form
    {
        public FrmPersonelFormu()
        {
            InitializeComponent();
        }
        public string mail;
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PersonelGorevFormlari.FrmAktifGorevler Frm = new PersonelGorevFormlari.FrmAktifGorevler();
            Frm.mail2 = mail;
            Frm.MdiParent = this;
            Frm.Show();
        }

        private void BtnPasifGorevler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PersonelGorevFormlari.FrmPasifGorevler Frm = new PersonelGorevFormlari.FrmPasifGorevler();
            Frm.mail2 = mail;
            Frm.MdiParent = this;
            Frm.Show();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PersonelGorevFormlari.FrmCagriListesi Frm = new PersonelGorevFormlari.FrmCagriListesi();
            Frm.MdiParent = this;
            Frm.mail2 = mail;
            Frm.Show();
        }

        private void FrmPersonelFormu_Load(object sender, EventArgs e)
        {
            //this.Text = mail.ToString();
            this.Text = "Personel Paneli";
        }
    }
}
