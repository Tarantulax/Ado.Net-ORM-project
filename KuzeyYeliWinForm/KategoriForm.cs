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
    public partial class KategoriForm : Form
    {
        public KategoriForm()
        {
            InitializeComponent();
        }

        private void KategoriForm_Load(object sender, EventArgs e)
        {
          
            dataGridView1.DataSource = korm.Listele();
        }
        KategoriORM korm = new KategoriORM();
        private void btnEkle_Click(object sender, EventArgs e)
        {
            Kategoriler k = new Kategoriler();
            k.KategoriAdi = txtKatAd.Text;
            k.Tanimi = txtTanim.Text;
            byte[] resim = {1};
            k.Resim = resim;
            korm.Ekle(k);
            korm.Listele();
        }
    }
}
