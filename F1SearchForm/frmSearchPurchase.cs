using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.F1SearchForm
{
    public partial class frmSearchPurchase : Form
    {
        string ID;
        public string Id
        {
            get { return ID; }
        }
        public frmSearchPurchase()
        {
            InitializeComponent();
            Initlize();
        }
        public void Initlize()
        {
            Connection cs = new Connection();
            SqlConnection Co = cs.GenaricConnection();
            CrudOperation CRUD = new CrudOperation();
            dgvPurchaseInv.Refresh();
            DataTable dt = new DataTable();
            dt = CRUD.GetPurchaseData(Co);
            dgvPurchaseInv.DataSource = dt;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                Connection cs = new Connection();
                SqlConnection Co = cs.GenaricConnection();

                string qry = @"SELECT PurchaseId, PurchaseDate, SaleMen, PartyCode,PartyName, TotalAmount FROM
                PurchaseMaster where PurchaseId like '%" + txtSearch.Text + "%' order by PurchaseId desc";
                SqlCommand cmd = new SqlCommand(qry, Co);
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                dt.Load(reader);
                dgvPurchaseInv.DataSource = dt;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void dgvPurchaseInv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvPurchaseInv.Rows.Count > 0 && dgvPurchaseInv.CurrentRow.Index != -1)
                {
                    ID = dgvPurchaseInv.Rows[dgvPurchaseInv.CurrentRow.Index].Cells[0].Value.ToString();
                  //  PartyName = dgvPurchaseInv.Rows[dgvPurchaseInv.CurrentRow.Index].Cells[1].Value.ToString();
                  //  Contact = dgvPurchaseInv.Rows[dgvPurchaseInv.CurrentRow.Index].Cells[2].Value.ToString();
                }
                else ID = "";

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvPurchaseInv_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (dgvPurchaseInv.Rows.Count > 0 && dgvPurchaseInv.CurrentRow.Index != -1)
                    {
                        ID = dgvPurchaseInv.Rows[dgvPurchaseInv.CurrentRow.Index].Cells[0].Value.ToString();
                     //   PartyName = dgvPurchaseInv.Rows[dgvPurchaseInv.CurrentRow.Index].Cells[1].Value.ToString();
                     //   Contact = dgvPurchaseInv.Rows[dgvPurchaseInv.CurrentRow.Index].Cells[2].Value.ToString();
                    }
                    else ID = "";
                    Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {

                if (dgvPurchaseInv.Rows.Count > 0 && dgvPurchaseInv.CurrentRow.Index != -1)
                {
                    ID = dgvPurchaseInv.Rows[dgvPurchaseInv.CurrentRow.Index].Cells[0].Value.ToString();
                 //   PartyName = dgvPartyInfo.Rows[dgvPartyInfo.CurrentRow.Index].Cells[1].Value.ToString();
                 //   Contact = dgvPartyInfo.Rows[dgvPartyInfo.CurrentRow.Index].Cells[2].Value.ToString();
                }
                else ID = "";

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
