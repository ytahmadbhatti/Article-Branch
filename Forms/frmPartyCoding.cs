using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static POS.Login;
using POS.FunctionClasses;

namespace POS.Forms
{
    public partial class frmPartyCoding : Form
    {
        public static bool IsUpdate;
        private Connection cs = new Connection();
        private SqlConnection Co = null;
        private CrudOperation CRUD = new CrudOperation();
        public frmPartyCoding()
        {
            InitializeComponent();
            Initiatefields();
        }
        public void Initiatefields()
        {
            txtPartyName.Text = string.Empty;
            txtLocation.Text = string.Empty;
            txtContact.Text = string.Empty;
            txtSearch.Text=string.Empty;
            Co = cs.GenaricConnection();
            txtPartyCode.Text = CRUD.GetMaxIdentity(Co, "PartyInfo");
            txtPartyCode.ReadOnly = true;
            btnSearch.Text = "Search";
            btnClear.Text = "Cancel";
            IsUpdate = false;
            txtPartyName.Focus();
            dgvPartyInfo.Show();          
            txtSearch.Show();
                dgvPartyInfo.Refresh();
                DataTable dt = new DataTable();
                dt = CRUD.GetPartyInfoData(Co);
                dgvPartyInfo.DataSource = dt;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Co = cs.GenaricConnection();
                if (txtPartyName.Text == "")
                {
                    MessageBox.Show("Please Enter Party Name", "Alert");
                    txtPartyName.Focus();
                }
                else
                {
                    if (txtLocation.Text == null || txtLocation.Text == "")
                    {
                        txtLocation.Text = "NULL";
                    }
                    if (txtContact.Text == null || txtContact.Text == "")
                    {
                        txtContact.Text = "NULL";
                    }
                    if (IsUpdate)
                    {
                        if (!LoginInfo.UserType.Equals("User"))
                        {
                            CRUD.InsertUpdatePartyInfo(Co, Convert.ToInt32(txtPartyCode.Text), txtPartyName.Text, txtLocation.Text, txtContact.Text, IsUpdate);
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
                        if (!CRUD.CheckName(Co,"Partynfo",(txtPartyName.Text).Trim()))
                        {
                            txtPartyCode.Text = CRUD.GetMaxIdentity(Co, "PartyInfo");
                            CRUD.InsertUpdatePartyInfo(Co, Convert.ToInt32(txtPartyCode.Text), txtPartyName.Text, txtLocation.Text, txtContact.Text, IsUpdate);

                            MessageBox.Show("Record Saved Successfully.", "Success Message");
                        }
                        else
                        {
                            MessageBox.Show("This Party Name Exsits Already", "Not Saved");
                            txtPartyName.Focus();
                            return;

                        }
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
        private void txtPartyName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (Keys.Enter == e.KeyCode)
                {
                    e.SuppressKeyPress = true;
                    txtLocation.Focus();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
        private void txtLocation_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode)
            {
                e.SuppressKeyPress = true;
                txtContact.Focus();
            }
        }
        private void txtContact_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode)
            {
                e.SuppressKeyPress = true;
                btnAdd.Focus();
            }
        }

        private void txtPartyCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode)
            {
                e.SuppressKeyPress = true;
                txtPartyName.Focus();
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
        private void dgvPartyInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow selectedRow = dgvPartyInfo.Rows[e.RowIndex];
                    txtPartyCode.Text = selectedRow.Cells[0].Value.ToString();
                    txtPartyName.Text = selectedRow.Cells[1].Value.ToString();
                    txtLocation.Text = selectedRow.Cells[2].Value.ToString();
                    txtContact.Text = selectedRow.Cells[3].Value.ToString();
                    dgvPartyInfo.Rows.Remove(selectedRow);
                    btnClear.Text = "Clear";
                    IsUpdate = true;
                    txtPartyName.Focus();
                    dgvPartyInfo.Hide();
                }
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
                txtPartyCode.ReadOnly = false;
                txtPartyCode.Focus();
                btnClear.Text = "Clear";
                btnSearch.Text = "Go";
            }
            else
            {

            }
        }
        private void txtPartyCode_TextChanged(object sender, EventArgs e)
        {
            if (txtPartyCode.Text != "" && btnSearch.Text == "Go")
            {
                SearchForm search = new SearchForm();
                DataTable Data = search.SearchByID(Convert.ToInt16(txtPartyCode.Text), "PartyInfo");
                if (Data.Rows.Count > 0)
                {
                    txtPartyCode.Text = Data.Rows[0]["PartyCode"].ToString();
                    txtPartyName.Text = Data.Rows[0]["PartyName"].ToString();
                    txtLocation.Text = Data.Rows[0]["Location"].ToString();
                    txtContact.Text = Data.Rows[0]["Contact"].ToString();
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
                    CRUD.DeletePartyInfo(Co, Convert.ToInt32(txtPartyCode.Text));
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

                string qry = @"select PartyCode,PartyName,Location,Contact  from PartyInfo 
                where PartyName like '%" + txtSearch.Text + "%' and IsDeleted =0 order by PartyCode desc";
                SqlCommand cmd = new SqlCommand(qry, Co);
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                dt.Load(reader);

                dgvPartyInfo.DataSource = dt;
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
                dgvPartyInfo.Focus();
                if (dgvPartyInfo.Rows.Count > 0)
                {
                    dgvPartyInfo.CurrentCell = dgvPartyInfo.Rows[0].Cells[0];
                }
                e.Handled = true;
            }
        }
        private void dgvPartyInfo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (dgvPartyInfo.Rows.Count > 0 && dgvPartyInfo.CurrentRow.Index != -1)
                    {
                        txtPartyCode.Text = dgvPartyInfo.Rows[dgvPartyInfo.CurrentRow.Index].Cells[0].Value.ToString();
                        txtPartyName.Text = dgvPartyInfo.Rows[dgvPartyInfo.CurrentRow.Index].Cells[1].Value.ToString();
                        txtLocation.Text = dgvPartyInfo.Rows[dgvPartyInfo.CurrentRow.Index].Cells[2].Value.ToString();
                        txtContact.Text = dgvPartyInfo.Rows[dgvPartyInfo.CurrentRow.Index].Cells[3].Value.ToString();
                        btnClear.Text = "Clear";
                        dgvPartyInfo.Hide();
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
    }
}
