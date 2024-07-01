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
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace POS.Forms
{
    public partial class frmSizeCoding : Form
    {
        public static bool IsUpdate;
        private Connection cs = new Connection();
        private SqlConnection Co = null;
        private CrudOperation CRUD = new CrudOperation();
        public frmSizeCoding()
        {
            InitializeComponent();
            Initiatefields();
        }
        public void Initiatefields()
        {
            txtSize.Text = string.Empty;
            txtSearch.Text = string.Empty;
            Co = cs.GenaricConnection();
            txtSizeCode.Text = CRUD.GetMaxIdentity(Co, "SizeInfo");
            txtSizeCode.ReadOnly = true;
            btnSearch.Text = "Search";
            btnClear.Text = "Cancel";
            IsUpdate = false;
            txtSize.Focus();
            txtSearch.Show();
            dgvSizeInfo.Show();
            dgvSizeInfo.Refresh();
            DataTable dt = new DataTable();
            dt = CRUD.GetSizeInfoData(Co);
            dgvSizeInfo.DataSource = dt;
        }
        private void dgvSizeInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow selectedRow = dgvSizeInfo.Rows[e.RowIndex];
                    txtSizeCode.Text = selectedRow.Cells[0].Value.ToString();
                    txtSize.Text = selectedRow.Cells[1].Value.ToString();
                    dgvSizeInfo.Rows.Remove(selectedRow);
                    btnClear.Text = "Clear";
                    IsUpdate = true;
                    txtSize.Focus();
                    dgvSizeInfo.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void dgvSizeInfo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (dgvSizeInfo.Rows.Count > 0 && dgvSizeInfo.CurrentRow.Index != -1)
                    {
                        txtSizeCode.Text = dgvSizeInfo.Rows[dgvSizeInfo.CurrentRow.Index].Cells[0].Value.ToString();
                        txtSize.Text = dgvSizeInfo.Rows[dgvSizeInfo.CurrentRow.Index].Cells[1].Value.ToString();

                        btnClear.Text = "Clear";
                        dgvSizeInfo.Hide();
                        txtSearch.Hide();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Co = cs.GenaricConnection();
                if (txtSize.Text == "")
                {
                    MessageBox.Show("Please Enter Size", "Alert");
                    txtSize.Focus();
                }
                else
                {
                    if (!CRUD.CheckName(Co, "SizeInfo", (txtSize.Text).Trim()))
                    {
                        if (IsUpdate)
                        {
                            if (!LoginInfo.UserType.Equals("User"))
                            {
                                CRUD.InsertUpdateSizeInfo(Co, Convert.ToInt32(txtSizeCode.Text), txtSize.Text, IsUpdate);
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
                            
                                txtSizeCode.Text = CRUD.GetMaxIdentity(Co, "SizeInfo");
                                CRUD.InsertUpdateSizeInfo(Co, Convert.ToInt32(txtSizeCode.Text), txtSize.Text, IsUpdate);

                                MessageBox.Show("Record Saved Successfully.", "Success Message");
                           
                        }

                        btnAdd.Show();
                        btnAdd.Focus();
                        Initiatefields();
                        Co.Close();
                    }
                    else
                    {
                        MessageBox.Show("This Size Exsits Already", "Not Saved");
                        txtSize.Focus();
                        return;
                    }
                }
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
                txtSizeCode.ReadOnly = false;
                txtSizeCode.Focus();
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Co = cs.GenaricConnection();
                if (!LoginInfo.UserType.Equals("User"))
                {
                    CRUD.DeleteSizeInfo(Co, Convert.ToInt32(txtSizeCode.Text));
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

        private void txtSizeCode_TextAlignChanged(object sender, EventArgs e)
        {
            if (txtSizeCode.Text != "" && btnSearch.Text == "Go")
            {
                SearchForm search = new SearchForm();
                DataTable Data = search.SearchByID(Convert.ToInt16(txtSizeCode.Text), "SizeInfo");
                if (Data.Rows.Count > 0)
                {
                    txtSizeCode.Text = Data.Rows[0]["SizeCode"].ToString();
                    txtSize.Text = Data.Rows[0]["Size"].ToString();
                }
            }
        }
        private void txtSizeCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode)
            {
                e.SuppressKeyPress = true;
                txtSize.Focus();
            }
        }
        private void txtSizeCode_TextChanged(object sender, EventArgs e)
        {
            if (txtSizeCode.Text != "" && btnSearch.Text == "Go")
            {
                SearchForm search = new SearchForm();
                DataTable Data = search.SearchByID(Convert.ToInt16(txtSizeCode.Text), "SizeInfo");
                if (Data.Rows.Count > 0)
                {
                    txtSizeCode.Text = Data.Rows[0]["SizeCode"].ToString();
                    txtSize.Text = Data.Rows[0]["Size"].ToString();
                }
            }
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                Co = cs.GenaricConnection();
                string qry = @"Select SizeCode,Size from SizeInfo 
                where Size like '%" + txtSearch.Text + "%' and IsDeleted =0 order by SizeCode desc";
                SqlCommand cmd = new SqlCommand(qry, Co);
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                dt.Load(reader);
                dgvSizeInfo.DataSource = dt;
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
                dgvSizeInfo.Focus();
                if (dgvSizeInfo.Rows.Count > 0)
                {
                    dgvSizeInfo.CurrentCell = dgvSizeInfo.Rows[0].Cells[0];
                }
                e.Handled = true;
            }
        }
        private void txtSize_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode)
            {
                e.SuppressKeyPress = true;
                btnAdd.Focus();
            }
        }

        private void txtSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}

