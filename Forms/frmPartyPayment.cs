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
          //  GetPartyName();
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

            Co = cs.GenaricConnection();
            txtVoucherID.Text = CRUD.GetMaxIdentity(Co, "Vouchers");
            fillComboBox(cbPartyName,"PartyCode", "PartyName", "select PartyCode, PartyName from PartyInfo where IsDeleted='0' Order By PartyCode");

            txtVoucherID.ReadOnly = true;
            btnSearch.Text = "Search";
            btnClear.Text = "Cancel";
            IsUpdate = false;
            txtPartyID.Focus();
       
        }

        private void fillComboBox(ComboBox comboName, string value, string display, string qry)
        {
            try
            {
                DataRow dr;

                SqlConnection Co = cs.GenaricConnection();
                if (Co.State != ConnectionState.Open)
                    Co.Open();
                SqlCommand cmd = new SqlCommand(qry, Co);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dr = dt.NewRow();
                dt.Rows.InsertAt(dr, 0);
                comboName.ValueMember = value;
                comboName.DisplayMember = display;
                comboName.DataSource = dt;
                Co.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        public void GetPartyName()
        {
            try
            {
                using (SqlConnection connection = new Connection().GenaricConnection()) 
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
            //GetPartyName();
            //Co = cs.GenaricConnection();
            //if (txtPartyID.Text != "")
            //{
            //    txtAmountPending.Text = CRUD.CalculatePendingAmount(Co, txtPartyID.Text);
            //}
        }
  

        private void cbPartyName_TextChanged(object sender, EventArgs e)
        {            Co = cs.GenaricConnection();
            if (txtPartyID.Text != "")
            {
                txtPartyID.Text = CRUD.GetPartyIdData(Co, cbPartyName.Text);
                txtAmountPending.Text = CRUD.CalculatePendingAmount(Co, txtPartyID.Text);

            }
        }

        private void txtPartyID_KeyDown(object sender, KeyEventArgs e)
        {
         
            Co = cs.GenaricConnection();
            if (txtPartyID.Text != "")
            {
                cbPartyName.Text = CRUD.GetPartyNameData(Co, txtPartyID.Text);
                txtAmountPending.Text = CRUD.CalculatePendingAmount(Co, txtPartyID.Text);
            }
        }
    }
}
