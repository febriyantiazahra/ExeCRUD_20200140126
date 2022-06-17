using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ExerciseCRUD
{
    public partial class fMain : Form
    {
        DataTable dt;
        DataRow dr;
        string code;
        public fMain()
        {
            InitializeComponent();
        }
        private void fMain_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hRDataSet.empdetails' table. You can move, or remove it, as needed.
            this.barangTableAdapter.Fill(this.toko_BarangDataSet.barang);
            txtKodeBRG.Enabled = false;
            txtNamaBRG.Enabled = false;
            txtJenisBRG.Enabled = false;
            txtHargaBRG.Enabled = false;
            txtJumlahBRG.Enabled = false;
            btnSave.Enabled = false;
        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            txtNamaBRG.Enabled = true;
            txtJenisBRG.Enabled = true;
            txtHargaBRG.Enabled = true;
            txtJumlahBRG.Enabled = true;

            txtNamaBRG.Text = "";
            txtJenisBRG.Text = "";
            txtHargaBRG.Text = "";
            txtJumlahBRG.Text = "";
            int ctr, len;
            string codeval;
            dt = toko_BarangDataSet.Tables["barang"];
            len = dt.Rows.Count - 1;
            dr = dt.Rows[len];
            code = dr["Kode_Barang"].ToString();
            codeval = code.Substring(1, 3);
            ctr = Convert.ToInt32(codeval);
            if ((ctr >= 0) && (ctr < 9))
            {
                ctr = ctr + 1;
                txtKodeBRG.Text = "BR00" + ctr;
            }
            else if ((ctr >= 9) && (ctr < 99))
            {
                ctr = ctr + 1;
                txtKodeBRG.Text = "BR0" + ctr;
            }
            else if (ctr >= 99)
            {
                ctr = ctr + 1;
                txtKodeBRG.Text = "BR" + ctr;
            }
            btnInput.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string code;
            code = txtKodeBRG.Text;
            dr = toko_BarangDataSet.Tables["barang"].Rows.Find(code);
            dr.Delete();
            barangTableAdapter.Update(toko_BarangDataSet);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            dt = toko_BarangDataSet.Tables["barang"];
            dr = dt.NewRow();
            dr[0] = txtKodeBRG.Text;
            dr[1] = txtNamaBRG.Text;
            dr[2] = txtJenisBRG.Text;
            dr[3] = txtHargaBRG.Text;
            dr[4] = txtJumlahBRG.Text;
            dt.Rows.Add(dr);
            barangTableAdapter.Update(toko_BarangDataSet);
            txtKodeBRG.Text = System.Convert.ToString(dr[0]);
            txtKodeBRG.Enabled = false;
            txtNamaBRG.Enabled = false;
            txtJenisBRG.Enabled = false;
            txtHargaBRG.Enabled = false;
            txtJumlahBRG.Enabled = false;
            this.barangTableAdapter.Fill(this.toko_BarangDataSet.barang);
            btnInput.Enabled = true;
            btnSave.Enabled = false;
        }
    }
}
