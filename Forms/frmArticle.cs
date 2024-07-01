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
    public partial class frmProduct : Form
    {
        public static bool IsUpdate;
        private Connection cs = new Connection();
        private SqlConnection Co = null;
        private CrudOperation CRUD = new CrudOperation();
        public frmProduct()
        {
            InitializeComponent();
            Initiatefields();
        }
        public void Initiatefields()
        {
            txtArticle.Text = string.Empty;
            txtSearch.Text=string.Empty;
            Co = cs.GenaricConnection();
            txtArticleId.Text = CRUD.GetMaxIdentity(Co, "ArticleInfo");
            txtArticleId.ReadOnly = true;
            btnSearch.Text = "Search";
            btnClear.Text = "Cancel";
            IsUpdate = false;
            txtArticle.Focus();
            txtSearch.Show();
            dgvProductInfo.Show();
            dgvProductInfo.Refresh();
            DataTable dt = new DataTable();
            dt = CRUD.GetArticleInfoData
                (Co);
            dgvProductInfo.DataSource = dt;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Co = cs.GenaricConnection();
                if (txtArticle.Text == "")
                {
                    MessageBox.Show("Please Enter Article", "Alert");
                    txtArticle.Focus();
                }
                else
                {
                    if (IsUpdate)
                    {
                        if (!LoginInfo.UserType.Equals("User"))
                        {
                            
                                CRUD.InsertUpdateArticleInfo(Co, Convert.ToInt32(txtArticleId.Text), txtArticle.Text, IsUpdate);
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
                        if (!CRUD.CheckName(Co, "ArticleInfo", (txtArticle.Text).Trim()))
                        {
                            txtArticleId.Text = CRUD.GetMaxIdentity(Co, "ArticleInfo");
                            CRUD.InsertUpdateArticleInfo(Co, Convert.ToInt32(txtArticleId.Text), txtArticle.Text, IsUpdate);

                            MessageBox.Show("Record Saved Successfully.", "Success Message");
                        }
                        else
                        {
                            MessageBox.Show("This Product Name Exsits Already", "Not Saved");
                            txtArticle.Focus();
                            return;
                        }
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

        private void dgvProductInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow selectedRow = dgvProductInfo.Rows[e.RowIndex];
                    txtArticleId.Text = selectedRow.Cells[0].Value.ToString();
                    txtArticle.Text = selectedRow.Cells[1].Value.ToString();
                    dgvProductInfo.Rows.Remove(selectedRow);
                    btnClear.Text = "Clear";
                    IsUpdate = true;
                    txtArticle.Focus();
                    dgvProductInfo.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (btnSearch.Text == "Search")
            {
                IsUpdate = true;
                txtArticleId.ReadOnly = false;
                txtArticleId.Focus();
                btnClear.Text = "Clear";
                btnSearch.Text = "Go";
            }
            else
            {

            }
        }
        private void txtArticleId_TextChanged(object sender, EventArgs e)
        {
            if (txtArticleId.Text != "" && btnSearch.Text == "Go")
            {
                SearchForm search = new SearchForm();
                DataTable Data = search.SearchByID(Convert.ToInt16(txtArticleId.Text), "ProductInfo");
                if (Data.Rows.Count > 0)
                {
                    txtArticleId.Text = Data.Rows[0]["ProductCode"].ToString();
                    txtArticle.Text = Data.Rows[0]["ProductName"].ToString();
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
                    CRUD.DeleteProductInfo(Co, Convert.ToInt32(txtArticleId.Text));
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
                string qry = @"Select ProductCode,ProductName,PurchaseRate, SaleRate from ProductInfo where
               ProductName like '%" + txtSearch.Text + "%' and IsDeleted =0 order by ProductCode desc";
                SqlCommand cmd = new SqlCommand(qry, Co);
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                dt.Load(reader);
                dgvProductInfo.DataSource = dt;
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
                dgvProductInfo.Focus();
                if (dgvProductInfo.Rows.Count > 0)
                {
                    dgvProductInfo.CurrentCell = dgvProductInfo.Rows[0].Cells[0];
                }
                e.Handled = true;
            }
        }

        private void dgvProductInfo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (dgvProductInfo.Rows.Count > 0 && dgvProductInfo.CurrentRow.Index != -1)
                    {
                        txtArticleId.Text = dgvProductInfo.Rows[dgvProductInfo.CurrentRow.Index].Cells[0].Value.ToString();
                        txtArticle.Text = dgvProductInfo.Rows[dgvProductInfo.CurrentRow.Index].Cells[1].Value.ToString();                        
                        btnClear.Text = "Clear";
                        dgvProductInfo.Hide();
                        txtSearch.Hide();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtArticle_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode)
            {
                e.SuppressKeyPress = true;
            }
        }
    }
}