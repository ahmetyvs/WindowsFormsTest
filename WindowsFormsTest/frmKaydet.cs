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
    public partial class frmKaydet : Form
    {
        int? id = null;
        public bool kaydedildi = false;
        public frmKaydet(int? Id = null)
        {
            InitializeComponent();
            if (Id != null)
            {
                this.id = Id;
            }

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (id==null)
            {
                string sql = "Insert into Bilgiler(AdiSoyadi, Telefon, Maas, Tarih) Values('" + txtAdiSoyadi.Text + "','" + maskedTelefon.Text + "','" + txtMaas.Text + "','" + dateTimeTarih.Value + "')";

                if (CRUD.ESG(sql))
                {
                    kaydedildi = true;
                   MessageBox.Show("Ekleme İşlemi Başarılı");
                    this.Close();
                }

            }
            else
            {
                string sql = "Update Bilgiler set AdiSoyadi='" + txtAdiSoyadi.Text + "', Telefon='" + maskedTelefon.Text + "', Maas='" + txtMaas.Text + "', Tarih='" + dateTimeTarih.Value + "' Where Id='"+id+"'";

                if (CRUD.ESG(sql))
                {
                    kaydedildi = true;
                    MessageBox.Show("Güncelleme İşlemi Başarılı");
                    this.Close();
                }
            }
        }
    }
}
