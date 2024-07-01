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
    public partial class frmUser : Form
    {
        public static bool IsUpdate;
        private Connection cs = new Connection();
        private SqlConnection Co = null;
        private CrudOperation CRUD = new CrudOperation();
        public frmUser()
        {
            InitializeComponent();
            Initiatefields();
        }
        public void Initiatefields()
        {
            txtName.Text = string.Empty;
            txtPhoneNo.Text = string.Empty;
            txtCNICNo.Text = string.Empty;
            txtUserName.Text = string.Empty;
            txtUserPassword.Text = string.Empty;
            cmbLoginType.Text = string.Empty;
            cbIsActive.Checked = true;
            txtSearch.Text = string.Empty;
            Co = cs.GenaricConnection();
            txtID.Text = CRUD.GetMaxIdentity(Co, "[User]");
            txtID.ReadOnly = true;
            btnSearch.Text = "Search";
            btnClear.Text = "Cancel";
            IsUpdate = false;
            txtName.Focus();
            txtSearch.Show();
            dgvUser.Show();
            dgvUser.Refresh();
            DataTable dt = new DataTable();
            dt = CRUD.GetUserInfoData(Co);
            dgvUser.DataSource = dt;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtID_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode)
            {
                e.SuppressKeyPress = true;
                txtName.Focus();
            }
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode)
            {
                e.SuppressKeyPress = true;
                txtPhoneNo.Focus();
            }
        }

        private void txtPhoneNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode)
            {
                e.SuppressKeyPress = true;
                txtCNICNo.Focus();
            }
        }

        private void txtCNICNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode)
            {
                e.SuppressKeyPress = true;
                cmbLoginType.Focus();
            }
        }

        private void cbLoginType_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode)
            {
                e.SuppressKeyPress = true;
                txtUserName.Focus();
            }
        }

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode)
            {
                e.SuppressKeyPress = true;
                txtUserPassword.Focus();
            }
        }
        private void txtUserPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode)
            {
                e.SuppressKeyPress = true;
                btnAdd.Focus();
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {

            try
            {
                Co = cs.GenaricConnection();
                if (txtName.Text == "")
                {
                    MessageBox.Show("Please Enter Name", "Alert");
                    txtName.Focus();
                }
                else if (cmbLoginType.Text == "")
                {
                    MessageBox.Show("Please select Login Type", "Alert");
                    cmbLoginType.Focus();
                }
                else if (txtUserName.Text == "")
                {
                    MessageBox.Show("Please select UserNme", "Alert");
                    txtUserName.Focus();
                }
                else if (txtUserPassword.Text == "")
                {
                    MessageBox.Show("Please Enter UserPassword", "Alert");
                    txtUserPassword.Focus();
                }
                else
                {
                    List<int> userrights = new List<int>();
                    foreach (CheckBox right in gdRights.Controls)
                    {
                        if (right.Checked)
                        {
                            userrights.Add(Convert.ToInt32(right.Tag));
                        }
                    }

                    if (userrights.Count > 1)
                    {

                        if (IsUpdate)
                        {
                            if (!LoginInfo.UserType.Equals("User"))
                            {

                                CRUD.InsertUpdateUserInfo(Co, Convert.ToInt32(txtID.Text), txtName.Text, txtPhoneNo.Text, txtCNICNo.Text, cmbLoginType.Text, txtUserName.Text, txtUserPassword.Text, cbIsActive.Checked, userrights, IsUpdate);
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
                            if (!CRUD.CheckName(Co, "[User]", (txtUserName.Text).Trim()))
                            {
                                txtID.Text = CRUD.GetMaxIdentity(Co, "[User]");
                                CRUD.InsertUpdateUserInfo(Co, Convert.ToInt32(txtID.Text), txtName.Text, txtPhoneNo.Text, txtCNICNo.Text, cmbLoginType.Text, txtUserName.Text, txtUserPassword.Text, cbIsActive.Checked, userrights, IsUpdate);

                                MessageBox.Show("Record Saved Successfully.", "Success Message");
                            }
                            else
                            {
                                MessageBox.Show("This  UserName Exsits Already", "Not Saved");
                                txtName.Focus();
                                return;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Atleast 1 Right Reuqired", "Validation");
                        return;
                    }
                    btnAdd.Show();
                    btnAdd.Focus();
                    Initiatefields();
                    Co.Close();
                }
            }
            catch (Exception ex)

            {
                MessageBox.Show(ex.ToString());
            }

        }




        private void dgvUser_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (dgvUser.Rows.Count > 0 && dgvUser.CurrentRow.Index != -1)
                    {
                        txtID.Text = dgvUser.Rows[dgvUser.CurrentRow.Index].Cells[0].Value.ToString();
                        txtName.Text = dgvUser.Rows[dgvUser.CurrentRow.Index].Cells[1].Value.ToString();
                        txtPhoneNo.Text = dgvUser.Rows[dgvUser.CurrentRow.Index].Cells[2].Value.ToString();
                        txtCNICNo.Text = dgvUser.Rows[dgvUser.CurrentRow.Index].Cells[3].Value.ToString();
                        cmbLoginType.Text = dgvUser.Rows[dgvUser.CurrentRow.Index].Cells[4].Value.ToString();
                        txtUserName.Text = dgvUser.Rows[dgvUser.CurrentRow.Index].Cells[5].Value.ToString();
                        txtUserPassword.Text = dgvUser.Rows[dgvUser.CurrentRow.Index].Cells[6].Value.ToString();
                        cbIsActive.Checked = (bool)dgvUser.Rows[dgvUser.CurrentRow.Index].Cells[7].Value;
                        btnClear.Text = "Clear";
                        dgvUser.Hide();
                        txtSearch.Hide();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                Co = cs.GenaricConnection();
                string qry = @"Select ID,Name,PhoneNo, CNICNo, Logintype,UserName, UserPassword, isActive 
                from [User] where
                UserName like '%" + txtSearch.Text + "%' and IsActive =1 order by ID desc";
                SqlCommand cmd = new SqlCommand(qry, Co);
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                dt.Load(reader);
                dgvUser.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Co = cs.GenaricConnection();
                if (!LoginInfo.UserType.Equals("User"))
                {
                    CRUD.DeleteUserInfo(Co, Convert.ToInt32(txtID.Text));
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

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            if (txtID.Text != "" && btnSearch.Text == "Go")
            {
                SearchForm search = new SearchForm();
                DataTable Data = search.SearchByID(Convert.ToInt16(txtID.Text), "[User]");
                if (Data.Rows.Count > 0)
                {
                    txtID.Text = Data.Rows[0]["ID"].ToString();
                    txtName.Text = Data.Rows[0]["Name"].ToString();
                    txtPhoneNo.Text = Data.Rows[0]["PhoneNo"].ToString();
                    txtCNICNo.Text = Data.Rows[0]["CNICNo"].ToString();
                    cmbLoginType.Text = Data.Rows[0]["Logintype"].ToString();
                    txtUserName.Text = Data.Rows[0]["UserName"].ToString();
                    txtUserPassword.Text = Data.Rows[0]["UserPassword"].ToString();

                }
            }
        }

        private void dgvUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow selectedRow = dgvUser.Rows[e.RowIndex];
                    txtID.Text = selectedRow.Cells[0].Value.ToString();
                    txtName.Text = selectedRow.Cells[1].Value.ToString();
                    txtPhoneNo.Text = selectedRow.Cells[2].Value.ToString();
                    txtCNICNo.Text = selectedRow.Cells[3].Value.ToString();
                    cmbLoginType.Text = selectedRow.Cells[4].Value.ToString();
                    txtUserName.Text = selectedRow.Cells[5].Value.ToString();
                    txtUserPassword.Text = selectedRow.Cells[6].Value.ToString();
                    cbIsActive.Checked = selectedRow.Cells[7].Value != null && (bool)selectedRow.Cells[7].Value;
                    // cbIsActive.Checked = (bool)selectedRow.Cells[7].Value;
                    dgvUser.Rows.Remove(selectedRow);
                    btnClear.Text = "Clear";
                    IsUpdate = true;
                    txtName.Focus();
                    dgvUser.Hide();
                    txtSearch.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRights_Click(object sender, EventArgs e)
        {
            try
            {
                Connection cs = new Connection();
                Co = cs.GenaricConnection();
                CrudOperation crud = new CrudOperation();
                DataTable dt = new DataTable();
                dt = crud.GetAllRights(Co);
                CheckBox box;
                int y = 15;
                foreach (Control ctr in gdRights.Controls)
                {
                    if (ctr is CheckBox)
                    {
                        ((CheckBox)ctr).Checked = false;
                    }
                }
                foreach (DataRow row in dt.Rows)
                {
                    box = new CheckBox();
                    box.Tag = row["ID"].ToString();
                    box.Text = row["Name"].ToString();
                    box.AutoSize = true;
                    box.Location = new Point(10, y);
                    gdRights.Controls.Add(box);
                    y += 15;
                }
                dt.Clear();
                if (txtID.Text != "" && txtID.Text != null)
                {
                    dt = crud.GetthisUserRights(Co, Int32.Parse(txtID.Text));
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            foreach (CheckBox right in gdRights.Controls)
                            {
                                if (right.Tag.ToString() == row["Rightid"].ToString())
                                {
                                    right.Checked = true;
                                }
                            }
                        }
                    }
                    else
                    {
                        foreach (CheckBox right in gdRights.Controls)
                        {

                            right.Checked = false;
                        }
                    }
                }
                gdRights.Show();
                chkSelecAll.Show();
                Co.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkSelecAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkSelecAll.Checked)
                {
                    foreach (CheckBox right in gdRights.Controls)
                    {
                        right.Checked = true;
                    }
                }
                else
                {
                    foreach (CheckBox right in gdRights.Controls)
                    {
                        right.Checked = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
