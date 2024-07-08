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

namespace POS.Forms
{
    public partial class frmPartyPayment : Form
    {
        public static bool IsUpdate;
        private Connection cs = new Connection();
        private SqlConnection Co = null;
        private CrudOperation CRUD = new CrudOperation();
        public frmPartyPayment()
        {
            InitializeComponent();
            Initiatefields();
            GetPartyName();
        }
        public void Initiatefields()
        {
            txtVoucherID.Text = string.Empty;
            txtPartyID.Text = string.Empty;
            cbPartyName.Text = string.Empty;
            txtAmountPending.Text = string.Empty;
            txtAmount.Text = string.Empty;
            txtAmountRemaining.Text = string.Empty;
            txtDiscription.Text = string.Empty;
            txtSearch.Text = string.Empty;
            Co = cs.GenaricConnection();
            txtVoucherID.Text = CRUD.GetMaxIdentity(Co, "Vouchers");
            txtVoucherID.ReadOnly = true;
            btnSearch.Text = "Search";
            btnClear.Text = "Cancel";
            IsUpdate = false;
            txtPartyID.Focus();
            dgvPartyPayment.Show();
            txtSearch.Show();
            dgvPartyPayment.Refresh();
            DataTable dt = new DataTable();
            dt = CRUD.GetPartyPaymentData(Co);
            dgvPartyPayment.DataSource = dt;
        }

        public void GetPartyName()
        {
            try
            {
                using (SqlConnection connection = new Connection().GenaricConnection()) // Using your GenaricConnection method
                using (SqlCommand command = new SqlCommand("select PartyCode, PartyName from PartyInfo where IsDeleted != 1", connection))
                {
                    SqlDataAdapter objDataAdapter = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    objDataAdapter.Fill(dt);

                    DataRow dr = dt.NewRow();
                    dr["PartyCode"] = 0;
                    dr["PartyName"] = "--Select--";
                    dt.Rows.InsertAt(dr, 0);
                    cbPartyName.ValueMember = "PartyCode"; 
                    cbPartyName.DisplayMember = "PartyName";
                    cbPartyName.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception : " + ex);
            }
        }

        private void txtPartyID_TextChanged(object sender, EventArgs e)
        {
            GetPartyName();
            Co = cs.GenaricConnection();
            if (txtPartyID.Text != "")
            {
                txtAmountPending.Text = CRUD.CalculatePendingAmount(Co, txtPartyID.Text);

            }
        }

        private void txtPartyID_KeyPress(object sender, KeyPressEventArgs e)
        {
            

        }
    }
}
