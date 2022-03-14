using KuzeyYeliEntity;
using KuzeyYeliORM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KuzeyYeliWinForm
{
    public partial class UrunForm : Form
    {
        public UrunForm()
        {
            InitializeComponent();
        }

        private void UrunForm_Load(object sender, EventArgs e)
        {
            UrunlerORM orm = new UrunlerORM();
            dataGridView1.DataSource = orm.Listele();

            KategoriORM korm = new KategoriORM();
            cmbKategori.DataSource = korm.Listele();
            cmbKategori.DisplayMember = "KategoriAdi";
            cmbKategori.ValueMember = "KategoriID";

            TedarikciORM torm = new TedarikciORM();
            cmbTedarikci.DataSource = torm.Listele();
            cmbTedarikci.DisplayMember = "SirketAdi";
            cmbTedarikci.ValueMember = "TedarikciID";

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Urunler u = new Urunler();
            u.UrunAdi = txtUrunAdi.Text;
            u.Fiyat = nudFiyat.Value;
            u.Stok =(short)nudStok.Value;
            u.KategoriID = (int)cmbKategori.SelectedValue;
            u.TedarikciID = (int)cmbTedarikci.SelectedValue;
            u.BirimdekiMiktar = "";
            UrunlerORM orm = new UrunlerORM();
            orm.Ekle(u);
            orm.Listele();
        }

        private void btn_Guncelle_Click(object sender, EventArgs e)
        {
            Urunler u = new Urunler();
            u.UrunID =(int)txtUrunAdi.Tag;
            u.UrunAdi = txtUrunAdi.Text;
            u.Fiyat = nudFiyat.Value;
            u.Stok = (short)nudStok.Value;
            u.KategoriID = (int)cmbKategori.SelectedValue;
            u.TedarikciID = (int)cmbTedarikci.SelectedValue;
            u.BirimdekiMiktar = "";
            UrunlerORM orm = new UrunlerORM();
            orm.Guncelle(u);

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtUrunAdi.Text = dataGridView1.CurrentRow.Cells["UrunAdi"].Value.ToString();
      
            txtUrunAdi.Tag = dataGridView1.CurrentRow.Cells["UrunID"].Value;

            nudFiyat.Value =(decimal)dataGridView1.CurrentRow.Cells["Fiyat"].Value;

            nudStok.Value =Convert.ToDecimal(dataGridView1.CurrentRow.Cells["Stok"].Value);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Urunler u = new Urunler();
            u.UrunID = (int)txtUrunAdi.Tag;
            UrunlerORM orm = new UrunlerORM();
            orm.Sil(u.UrunID);
        }
    }
}
