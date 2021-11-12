using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsTest
{
    public partial class frmListeler : Form
    {
        public frmListeler()
        {
            InitializeComponent();
            listele();
        }
        void listele()
        {
            string sql = "Select Id, AdiSoyadi, Telefon, Cast(Maas as varchar) as Maas, Tarih from Bilgiler";
            dataGridView1.DataSource = CRUD.Listele(sql);
        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            frmKaydet frm = new frmKaydet();
            frm.ShowDialog();
            if (frm.kaydedildi)
            {
                listele();
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int seciliId = Convert.ToInt32( dataGridView1.CurrentRow.Cells["Id"].Value.ToString());
            frmKaydet frm = new frmKaydet(seciliId);
            // burada ilk önce kaydet formundaki veri giriş alanlarının tamamı seçilerek özellikleri private den publice çevriliyor. Böylece listeden seçilen verinin Keydet formuna gitmesi sağlanıyor
            frm.txtAdiSoyadi.Text = dataGridView1.CurrentRow.Cells["AdiSoyadi"].Value.ToString();
            frm.maskedTelefon.Text = dataGridView1.CurrentRow.Cells["Telefon"].Value.ToString();
            frm.txtMaas.Text = dataGridView1.CurrentRow.Cells["Maas"].Value.ToString();
            frm.dateTimeTarih.Text = dataGridView1.CurrentRow.Cells["Tarih"].Value.ToString();
            frm.ShowDialog();
            if (frm.kaydedildi)
            {
                listele();
            }

        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seçili kayıt silinecek, onaylıyor musunuz", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
            {
                int seciliId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value.ToString());
                string sql = "Delete from Bilgiler Where Id= '" + seciliId + "'";
                if (CRUD.ESG(sql))
                {
                    listele();
                } 
            }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
