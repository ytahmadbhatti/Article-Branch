using POS.FunctionClasses;
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
    public partial class frmExpense : Form
    {
        public static bool IsUpdate;
        private Connection cs = new Connection();
        private SqlConnection Co = null;
        private CrudOperation CRUD = new CrudOperation();
        public frmExpense()
        {
            InitializeComponent();
            Initiatefields();
            GetExpenseType();
        }

        public void Initiatefields()
        {
            txtID.Text = string.Empty;
            cbPurpose.Text = string.Empty;
            txtDiscription.Text = string.Empty;
            txtSearch.Text = string.Empty;
            Co = cs.GenaricConnection();
            txtID.Text = CRUD.GetMaxIdentity(Co, "Expense");
            txtID.ReadOnly = true;
            btnSearch.Text = "Search";
            btnClear.Text = "Cancel";
            IsUpdate = false;
            dptDate.Focus();
            dgvExpense.Show();
            txtSearch.Show();
            dgvExpense.Refresh();
            DataTable dt = new DataTable();
            dt = CRUD.GetExpenseData(Co);
            dgvExpense.DataSource = dt;
        }

        public void GetExpenseType()
        {
            try
            {
                using (SqlConnection connection = new Connection().GenaricConnection()) // Using your GenaricConnection method
                using (SqlCommand command = new SqlCommand("select ID, Type from ExpenseCoding where IsDeleted != 1", connection))
                {
                    SqlDataAdapter objDataAdapter = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    objDataAdapter.Fill(dt);

                    DataRow dr = dt.NewRow();
                    dr["ID"] = 0;
                    dr["Type"] = "--Select--";
                    dt.Rows.InsertAt(dr, 0);

                    cbPurpose.ValueMember = "ID"; // Corrected ValueMember to match
                    cbPurpose.DisplayMember = "Type";
                        cbPurpose.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception : " + ex);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (dptDate.Text == "")
                {
                    MessageBox.Show("Please Enter Expense Type", "Alert");
                    dptDate.Focus();
                }
                if (IsUpdate)
                {
                    if (!LoginInfo.UserType.Equals("User"))
                    {
                        CRUD.InsertUpdateExpense(Co, Convert.ToInt32(txtID.Text), DateTime.Now, cbPurpose.Text , txtDiscription.Text, IsUpdate);
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
                    //if (!CRUD.CheckName(Co, "Expense", (txtExpenseType.Text).Trim()))
                    //{
                        txtID.Text = CRUD.GetMaxIdentity(Co, "Expense");
                        CRUD.InsertUpdateExpense(Co, Convert.ToInt32(txtID.Text),Convert.ToDateTime(DateTime.Now), cbPurpose.Text, txtDiscription.Text, IsUpdate);

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
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (btnSearch.Text == "Search")
            {
                IsUpdate = true;
                txtID.ReadOnly = false;
                txtID.Focus();
                btnClear.Text = "Clear";
                btnSearch.Text = "Go";
            }
            else
            {

            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (btnClear.Text == "Clear")
            {
                Initiatefields();
            }
            else
            {
                this.Close();
            }
        }

        private void dgvExpense_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow selectedRow = dgvExpense.Rows[e.RowIndex];
                    txtID.Text = selectedRow.Cells[0].Value.ToString();
                    dptDate.Text = selectedRow.Cells[1].Value.ToString();
                    cbPurpose.Text = selectedRow.Cells[2].Value.ToString();
                    txtDiscription.Text = selectedRow.Cells[3].Value.ToString();
                    dgvExpense.Rows.Remove(selectedRow);
                    btnClear.Text = "Clear";
                    IsUpdate = true;
                    dptDate.Focus();
                    dgvExpense.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            if (txtID.Text != "" && btnSearch.Text == "Go")
            {
                SearchForm search = new SearchForm();
                DataTable Data = search.SearchByID(Convert.ToInt16(txtID.Text), "Expense");
                if (Data.Rows.Count > 0)
                {
                    txtID.Text = Data.Rows[0]["ID"].ToString();
                    dptDate.Text = Data.Rows[0]["Date"].ToString();
                    cbPurpose.Text = Data.Rows[0]["Purpose"].ToString();
                    txtDiscription.Text = Data.Rows[0]["Description"].ToString();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Co = cs.GenaricConnection();
                if (!LoginInfo.UserType.Equals("User"))
                {
                    CRUD.DeleteExpense(Co, Convert.ToInt32(txtID.Text));
                    MessageBox.Show("Record Deleted Successfully.", "Success Message");
                    Initiatefields();
                }
                else
                {
                    MessageBox.Show("You dont have permission to Delete this.", "Warning Message");
                }
                Co.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                Co = cs.GenaricConnection();

                string qry = @"select ID,Date, Purpose, Description from Expense 
                where Purpose like '%" + txtSearch.Text + "%' and IsDeleted =0 order by ID desc";
                SqlCommand cmd = new SqlCommand(qry, Co);
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                dt.Load(reader);

                dgvExpense.DataSource = dt;
                //  dgvPartyInfo.Columns[2].Width = 140;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                dgvExpense.Focus();
                if (dgvExpense.Rows.Count > 0)
                {
                    dgvExpense.CurrentCell = dgvExpense.Rows[0].Cells[0];
                }
                e.Handled = true;
            }
        }

        private void dgvExpense_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (dgvExpense.Rows.Count > 0 && dgvExpense.CurrentRow.Index != -1)
                    {
                        txtID.Text = dgvExpense.Rows[dgvExpense.CurrentRow.Index].Cells[0].Value.ToString();
                        dptDate.Text = dgvExpense.Rows[dgvExpense.CurrentRow.Index].Cells[1].Value.ToString();
                        cbPurpose.Text = dgvExpense.Rows[dgvExpense.CurrentRow.Index].Cells[1].Value.ToString();
                        txtDiscription.Text = dgvExpense.Rows[dgvExpense.CurrentRow.Index].Cells[1].Value.ToString();
                        btnClear.Text = "Clear";
                        dgvExpense.Hide();
                        IsUpdate = true;
                        txtSearch.Hide();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dptDate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (Keys.Enter == e.KeyCode)
                {
                    e.SuppressKeyPress = true;
                    cbPurpose.Focus();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void cbPurpose_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (Keys.Enter == e.KeyCode)
                {
                    e.SuppressKeyPress = true;
                    txtDiscription.Focus();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void txtDiscription_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (Keys.Enter == e.KeyCode)
                {
                    e.SuppressKeyPress = true;
                    btnAdd.Focus();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
    }
}
