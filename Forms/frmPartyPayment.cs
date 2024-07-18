using POS.DataSets;
using POS.F1SearchForm;
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
using static POS.Login;

namespace POS.Forms
{
    public partial class frmPartyPayment : Form
    {
        public int Id;
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
            txtVoucherID.Text = CRUD.GetMaxIdentity(Co, "Voucher");
            fillComboBox(cbPartyName, "PartyCode", "PartyName", "select PartyCode, PartyName from PartyInfo where IsDeleted='0' Order By PartyCode");

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
        {
            Co = cs.GenaricConnection();
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

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            if (txtAmount.Text != "")
            {
                decimal pending = Convert.ToDecimal(txtAmountPending.Text);
                decimal amount = Convert.ToInt32(txtAmount.Text);
                txtAmountRemaining.Text = (pending - amount).ToString();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Co = cs.GenaricConnection();
                if (txtPartyID.Text == "")
                {
                    MessageBox.Show("Please seclect Party Name.", "Alert");
                    cbPartyName.Focus();
                }
                if (txtAmount.Text == "")
                {
                    MessageBox.Show("Please enter Amount Paid.", "Alert");
                    txtAmount.Focus();
                }
                decimal amount = Convert.ToDecimal(txtAmountRemaining.Text);
                if (amount < 0)
                {
                    MessageBox.Show("Remaining Amount should not be less than 0!.", "Alert");
                    txtAmount.Focus();
                }
                else
                {
                    if (IsUpdate)
                    {
                        if (!LoginInfo.UserType.Equals("User"))
                        {
                            CRUD.InsertUpdatePartyPayment(Co, Convert.ToInt32(txtVoucherID.Text), DateTime.Now, Convert.ToInt32(txtPartyID.Text), Convert.ToDecimal(txtAmount.Text), txtDiscription.Text, IsUpdate);
                            MessageBox.Show("Record Updated Successfully.", "Success Message");
                            Initiatefields();
                        }
                        else
                        {
                            MessageBox.Show("You dont have permission to edit this.", "Warning Message");
                        }
                    }
                    else
                    {
                        //if (!CRUD.CheckName(Co, "ExpenseCoding", (txtExpenseType.Text).Trim()))
                        //{
                        txtVoucherID.Text = CRUD.GetMaxIdentity(Co, "Voucher");
                        CRUD.InsertUpdatePartyPayment(Co, Convert.ToInt32(txtVoucherID.Text), DateTime.Now, Convert.ToInt32(txtPartyID.Text), Convert.ToDecimal(txtAmount.Text), txtDiscription.Text, IsUpdate);

                        MessageBox.Show("Record Saved Successfully.", "Success Message");
                        //}
                        //else
                        //{
                        //    MessageBox.Show("This Expense Type Exsits Already", "Not Saved");
                        //    txtExpenseType.Focus();
                        //    return;
                        //}
                    }
                    Initiatefields();
                    Co.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void cbPartyName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPartyName.SelectedIndex > 0)
            {
                DataRowView drv = (DataRowView)cbPartyName.SelectedItem;
                txtPartyID.Text = drv["PartyCode"].ToString();
            }
            else
            {
                txtPartyID.Text = string.Empty;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (btnSearch.Text == "Search")
            {
                txtVoucherID.Text = "";
                IsUpdate = true;   
                txtVoucherID.ReadOnly = false;
                txtVoucherID.Focus();
                btnClear.Text = "Clear";
                btnSearch.Text = "Go";
            }
        }

        private void txtVoucherID_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.F1 == e.KeyCode)
            {
                frmSearchPartyPayment frm = new frmSearchPartyPayment();
                frm.ShowDialog();
                txtVoucherID.Text = frm.Id;
            }
            if (Keys.Enter == e.KeyCode)
            {
                e.SuppressKeyPress = true;
                dptDate.Focus();
            }
        }

     

        private void txtVoucherID_TextChanged(object sender, EventArgs e)
        {
            if (btnSearch.Text == "Go")
            {
                ShowRecord();
            }
        }


        private void ShowRecord()
        {
            try
            {
                if (txtVoucherID.Text == "" || txtVoucherID.Text == null)
                {
                    MessageBox.Show("Kindly insert valid code!", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtVoucherID.Focus();
                    return;
                }
                Connection cs = new Connection();
                SqlConnection Co = cs.GenaricConnection();

                string qry = @"SELECT  VoucherID,VoucherDate,PartyID,Amount ,Discritipn
                FROM Voucher where VoucherID =" + txtVoucherID.Text + "";

                SqlCommand cmd = new SqlCommand(qry, Co);
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        txtVoucherID.Text = reader["VoucherID"].ToString();
                        txtVoucherID.ReadOnly = true;
                        dptDate.Text = reader["VoucherDate"].ToString();
                        txtPartyID.Text = reader["PartyID"].ToString();
                        txtAmount.Text = reader["Amount"].ToString();

                        txtDiscription.Text = reader["Discritipn"].ToString();
                    }
                    reader.Close();


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
