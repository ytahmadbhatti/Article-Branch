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
    public partial class frmExpenseCoding : Form
    {
        public static bool IsUpdate;
        private Connection cs = new Connection();
        private SqlConnection Co = null;
        private CrudOperation CRUD = new CrudOperation();
        public frmExpenseCoding()
        {
            InitializeComponent();
            Initiatefields();
        }

        private void frmExpenseCoding_Load(object sender, EventArgs e)
        {

        }

        public void Initiatefields()
        {
            txtID.Text = string.Empty;
            txtExpenseType.Text = string.Empty;
            txtSearch.Text = string.Empty;
            Co = cs.GenaricConnection();
            txtID.Text = CRUD.GetMaxIdentity(Co, "ExpenseCoding");
            txtID.ReadOnly = true;
            btnSearch.Text = "Search";
            btnClear.Text = "Cancel";
            IsUpdate = false;
            txtExpenseType.Focus();
            dgvExpense.Show();
            txtSearch.Show();
            dgvExpense.Refresh();
            DataTable dt = new DataTable();
            dt = CRUD.GetExpenseCodingData(Co);
            dgvExpense.DataSource = dt;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtExpenseType.Text == "")
                {
                    MessageBox.Show("Please Enter Expense Type", "Alert");
                    txtExpenseType.Focus();
                }
                    if (IsUpdate)
                    {
                        if (!LoginInfo.UserType.Equals("User"))
                        {
                            CRUD.InsertUpdateExpenseCoding(Co, Convert.ToInt32(txtID.Text), txtExpenseType.Text, IsUpdate);
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
                        if (!CRUD.CheckName(Co, "ExpenseCoding", (txtExpenseType.Text).Trim()))
                        {
                            txtID.Text = CRUD.GetMaxIdentity(Co, "ExpenseCoding");
                            CRUD.InsertUpdateExpenseCoding(Co, Convert.ToInt32(txtID.Text), txtExpenseType.Text, IsUpdate);

                            MessageBox.Show("Record Saved Successfully.", "Success Message");
                        }
                        else
                        {
                            MessageBox.Show("This Expense Type Exsits Already", "Not Saved");
                            txtExpenseType.Focus();
                            return;
                        }
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
            if(btnClear.Text == "Clear")
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
                    txtExpenseType.Text = selectedRow.Cells[1].Value.ToString();
                    dgvExpense.Rows.Remove(selectedRow);
                    btnClear.Text = "Clear";
                    IsUpdate = true;
                    txtExpenseType.Focus();
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
            if(txtID.Text != "" && btnSearch.Text == "Go")
            {
                SearchForm search = new SearchForm();
                DataTable Data = search.SearchByID(Convert.ToInt16(txtID.Text), "ExpenseCoding");
                if (Data.Rows.Count > 0)
                {
                    txtID.Text = Data.Rows[0]["ID"].ToString();
                    txtExpenseType.Text = Data.Rows[0]["Type"].ToString();
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
                    CRUD.DeleteExpenseCoding(Co, Convert.ToInt32(txtID.Text));
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

                string qry = @"select ID,IdType from ExpenseCoding 
                where IdType like '%" + txtSearch.Text + "%' and IsDeleted =0 order by ID desc";
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
                        txtExpenseType.Text = dgvExpense.Rows[dgvExpense.CurrentRow.Index].Cells[1].Value.ToString();
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
        private void txtExpenseType_KeyDown(object sender, KeyEventArgs e)
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
