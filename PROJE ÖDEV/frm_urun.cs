using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROJE_ÖDEV
{
    public partial class frm_urun : Form
    {
        public frm_urun()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        DbürünEntities db = new DbürünEntities();
        private void btnlistele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Tbl_urun.ToList();
        }

        private void button1abtnekle_Click(object sender, EventArgs e)
        {
            Tbl_urun t = new Tbl_urun();
            t.URUNAD = textBox2.Text;
            t.MARKA = textBox3.Text;
            t.STOK = short.Parse(textBox5.Text);
            t.KATEGORİ = int.Parse(comboBox1.SelectedValue.ToString());
            t.FİYAT = decimal.Parse(textBox4.Text);
            t.DURUM = true;
            db.Tbl_urun.Add(t);
            db.SaveChanges();
            MessageBox.Show("ürün eklendi");

        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox1.Text);
            var urun = db.Tbl_urun.Find(x);
            db.Tbl_urun.Remove(urun);
            db.SaveChanges();
            MessageBox.Show("ürün silindi");
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox1.Text);
            var urun = db.Tbl_urun.Find(x);
            urun.URUNAD = textBox2.Text;
            urun.MARKA = textBox3.Text;
            urun.STOK = short.Parse(textBox5.Text);
            urun.KATEGORİ = int.Parse(comboBox1.Text);
            urun.FİYAT = decimal.Parse(textBox4.Text);
            urun.DURUM = true;
            db.SaveChanges();
            MessageBox.Show("ürün güncellendi");
        }

        private void frm_urun_Load(object sender, EventArgs e)
        {
            var kategoriler = (from x in db.Tbl_katagori 
                               select new 
                               {
                                   x.ID,
                                   x.AD
                               }
                               ).ToList();
            comboBox1.ValueMember = "ID";
            comboBox1.DisplayMember = "AD";
            comboBox1.DataSource = kategoriler;

        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            textBox2.Text = comboBox1.SelectedValue.ToString();
        }
    }
}
