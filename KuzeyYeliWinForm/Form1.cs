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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        UrunForm uf = new UrunForm();

        private void ürünlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (uf.IsDisposed)
                uf = new UrunForm();
            uf.MdiParent = this;
            uf.Show();
        }
          KategoriForm kf = new KategoriForm();
        private void kategorilerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (kf.IsDisposed)//bellekte yoksa 
                kf = new KategoriForm();
            kf.MdiParent = this;
            kf.Show();
        }
    }
}
