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
using POS.FunctionClasses;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using System.Xml;
using POS.F1SearchForm;
using POS.Report;
using POS.DataSets;

namespace POS.Forms
{
    public partial class frmSale : Form
    {
        public static string qry = "";
        public static bool IsUpdate;
        public frmSale()
        {
            InitializeComponent();
            Initiatefields();
        }
        public void Initiatefields()
        {
            txtPartyCode.Text = string.Empty;
            txtArticle.Text = string.Empty;
            txtNetAmount.Text = string.Empty;
            txtPartyName.Text = string.Empty;
            txtSalesMan.Text = string.Empty;
            txtAmount.Text = string.Empty;
            txtStock.Text = string.Empty;
            Connection cs = new Connection();
            SqlConnection Co = cs.GenaricConnection();
            CrudOperation CRUD = new CrudOperation();
            txtSaleInv.Text = CRUD.GetMaxIdentity(Co, "SaleMaster");
            txtSaleInv.Text="SI-"+txtSaleInv.Text;
            txtSaleInv.ReadOnly = true;
            btnSearch.Text = "Search";
            btnClear.Text = "Cancel";
            IsUpdate = false;
            txtPartyName.Focus();
            dgvSale.Show();
            FormatGrid();
            txtSalesMan.Text = LoginInfo.UserName;
            txtSalesMan.ReadOnly = true;
            txtNetAmount.ReadOnly = true;
        }
        private void FormatGrid()
        {
            dgvSale.Columns.Clear();
            dgvSale.Rows.Clear();
            dgvSale.ScrollBars = ScrollBars.Both;

            dgvSale.ColumnCount = 6;
            dgvSale.Columns[0].Name = "Article";
            dgvSale.Columns[1].Name = "Pair";
            dgvSale.Columns[2].Name = "Sale Rate";
            dgvSale.Columns[3].Name = "Total Sale Rate";
            dgvSale.Columns[4].Name = "Discount";
            dgvSale.Columns[5].Name = "Net Amount";
        }

        private void txtPartyCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (txtPartyCode.Text != "")
                {
                    SearchForm search = new SearchForm();
                    DataTable Data = search.SearchByCode(Convert.ToInt16(txtPartyCode.Text), "PartyInfo");
                    if (Data.Rows.Count > 0)
                    {
                        txtPartyCode.Text = Data.Rows[0]["PartyCode"].ToString();
                        txtPartyName.Text = Data.Rows[0]["PartyName"].ToString();
                      //  txtAmount.Text = Data.Rows[0]["Contact"].ToString();

                        txtPartyName.ReadOnly = true;
                        txtAmount.ReadOnly = true;
                        txtArticle.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Party Not Registered", "Alert");
                        txtPartyCode.Text = "";
                        txtPartyCode.Focus();
                    }
                }
            }
            else if (e.KeyCode == Keys.F1)
            {
                frmSearchParty frm = new frmSearchParty();
                frm.ShowDialog();
                txtPartyCode.Text = frm.Id;
                txtPartyName.Text = frm.Party;
                txtPartyName.ReadOnly = true;
                txtAmount.ReadOnly = true;
                txtArticle.Focus();
            }
        }

        private void txtProductCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
            
  


                if (txtArticle.Text != "")
                {
                    SearchForm search = new SearchForm();
                    DataTable Data = search.SearchByAricle(txtArticle.Text, "ArticleInfo");
                    if (Data.Rows.Count > 0)
                    {
                        txtArticle.Text = Data.Rows[0]["Article"].ToString();
                        e.SuppressKeyPress = true;
                        txtPair.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Article Not Registered", "Alert");
                        txtArticle.Text = "";
                        txtArticle.Focus();
                    }
                }
            }
            else if (e.KeyCode == Keys.F1)
            {
                frmSearchArticle frm = new frmSearchArticle();
                frm.ShowDialog();
                txtArticle.Text = frm.article;    
                txtPair.Focus();
            }
        }
            private void txtQuantity_TextChanged(object sender, EventArgs e)
        {

            if (txtSaleRate.Text != "" && txtPair.Text != "")
            {
                Decimal salerate = Convert.ToDecimal(txtSaleRate.Text);
                int guantity = Convert.ToInt32(txtPair.Text);
                txtTotalSale.Text = (salerate * guantity).ToString();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtArticle.Text == "")
                {
                    MessageBox.Show("Please Enter Product.", "Alert Message");
                    txtArticle.Focus();
                    return;
                }
                else if (txtPair.Text == "")
                {
                    MessageBox.Show("Please Enter Quantity.", "Alert Message");
                    txtPair.Focus();
                    return;
                }
              
                else if (Convert.ToInt32(txtPair.Text) > Convert.ToInt32(txtStock.Text))
                {
                    MessageBox.Show("Entered quantity exceeds available stock.", "Alert Message");
                    txtPair.Focus();
                    return;
                }
                else if (Convert.ToInt32(txtPair.Text) < 0)
                {
                    MessageBox.Show("Please Enter Quantity Greater Than 0.", "Alert Message");
                   
                }
                else
                {
                    string article = txtArticle.Text;
                   
                        int newRowIndex = dgvSale.Rows.Add(
                            article,
                            txtPair.Text,
                            txtSaleRate.Text,
                            txtTotalSale.Text,
                            txtDiscount.Text,
                            txtNetAmount.Text
                        );
                    
                    double totalAmount = 0.0;
                    foreach (DataGridViewRow row in dgvSale.Rows)
                    {
                        double netAmount;
                        if (row.Cells[5].Value != null && double.TryParse(row.Cells[5].Value.ToString(), out netAmount))
                        {
                            totalAmount += netAmount;
                        }
                    }
                    txtAmount.Text =Convert.ToDecimal(totalAmount).ToString();
                   
                    txtPair.Text = "";
                    txtSaleRate.Text = "";
                    txtNetAmount.Text = "";
                    txtTotalSale.Text = "";
                    txtDiscount.Text = "";
                    txtStock.Text = "";
                    txtArticle.Text = "";
                    txtArticle.Focus();
                    dgvSale.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtPartyCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtProductCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Connection cs = new Connection();
                SqlConnection Co = cs.GenaricConnection();
                CrudOperation crud = new CrudOperation();
                if (txtPartyCode.Text == "")
                {
                    MessageBox.Show("Please Enter Party Name.", "Alert");
                    txtSaleInv.Focus();
                }

                else if (dgvSale.Rows.Count == 1)
                {
                    MessageBox.Show("Please Enter Product.", "Alert");
                    txtArticle.Focus();
                }
                else
                {
                    if (IsUpdate == true)
                    {
                        if (!LoginInfo.UserType.Equals("User"))
                        {
                            crud.InsertSaleMaster(Co, txtSaleInv.Text, DateTime.Now, txtSalesMan.Text, Convert.ToInt32(txtPartyCode.Text),
                           txtPartyName.Text, Convert.ToDecimal(txtAmount.Text), IsUpdate);
                        }
                        else
                        {
                            MessageBox.Show("You dont have permission to edit this.", "Warning Message");
                        }
                    }
                    if (IsUpdate != true)
                    {
                        crud.InsertSaleMaster(Co, txtSaleInv.Text, DateTime.Now, txtSalesMan.Text, Convert.ToInt32(txtPartyCode.Text),
                                  txtPartyName.Text, Convert.ToDecimal(txtAmount.Text), IsUpdate);
                    }
                    crud.DeleteStock(Co, txtSaleInv.Text);
                    for (int L = 0; L < dgvSale.Rows.Count; L++)
                    {
                        if (dgvSale.Rows[L].Cells[1].Value == null)
                        {
                            break;
                        }
                        else
                        {
                            if (Co.State != ConnectionState.Open)
                                Co.Open();
                            SqlCommand cmd = new SqlCommand("InsertSaleDetail", Co);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@SaleInv", SqlDbType.NVarChar).Value = txtSaleInv.Text;
                            cmd.Parameters.Add("@Article", SqlDbType.NVarChar).Value = dgvSale.Rows[L].Cells[0].Value;
                            cmd.Parameters.Add("@Pair", SqlDbType.Int).Value = Convert.ToInt32(dgvSale.Rows[L].Cells[1].Value);
                            cmd.Parameters.Add("@SaleRate", SqlDbType.Decimal).Value = Convert.ToDecimal(dgvSale.Rows[L].Cells[2].Value);
                            cmd.Parameters.Add("@TotalSaleRate", SqlDbType.Decimal).Value = Convert.ToDecimal(dgvSale.Rows[L].Cells[3].Value);
                            cmd.Parameters.Add("@Discount", SqlDbType.Int).Value = Convert.ToInt32(dgvSale.Rows[L].Cells[4].Value);
                            cmd.Parameters.Add("@NetAmount", SqlDbType.Decimal).Value =Convert.ToDecimal(dgvSale.Rows[L].Cells[5].Value);
                            cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = DateTime.Now;

                            dgvSale.Rows[L].Cells[0].ReadOnly = true;
                            dgvSale.Rows[L].Cells[1].ReadOnly = true;
                            dgvSale.Rows[L].Cells[2].ReadOnly = true;
                            dgvSale.Rows[L].Cells[3].ReadOnly = true;
                            dgvSale.Rows[L].Cells[4].ReadOnly = true;

                            cmd.ExecuteNonQuery();
                            cmd.Dispose();

                            SqlCommand cmd1 = new SqlCommand("InsertUpdateStock", Co);
                            cmd1.CommandType = CommandType.StoredProcedure;
                            cmd1.Parameters.Add("@InvType", SqlDbType.VarChar).Value = "SI";
                            cmd1.Parameters.Add("@InvId", SqlDbType.NVarChar).Value = txtSaleInv.Text;
                            cmd1.Parameters.Add("@Article", SqlDbType.NVarChar).Value = dgvSale.Rows[L].Cells[0].Value;
                            cmd1.Parameters.Add("@Pair", SqlDbType.Decimal).Value = dgvSale.Rows[L].Cells[1].Value;
                            cmd1.Parameters.Add("@UnitPrice", SqlDbType.Decimal).Value = Convert.ToDecimal(dgvSale.Rows[L].Cells[2].Value);
                            cmd1.Parameters.Add("@TotalAmount", SqlDbType.Decimal).Value =Convert.ToDecimal(dgvSale.Rows[L].Cells[3].Value);
                            cmd1.Parameters.Add("@Discount", SqlDbType.Int).Value = Convert.ToInt32(dgvSale.Rows[L].Cells[4].Value);
                            cmd1.Parameters.Add("@NetAmount", SqlDbType.Float).Value = dgvSale.Rows[L].Cells[5].Value;
                            cmd1.Parameters.Add("@DateTime", SqlDbType.DateTime).Value = DateTime.Now;
                            cmd1.Parameters.Add("@UserName", SqlDbType.VarChar).Value = txtSalesMan.Text;

                            cmd1.ExecuteNonQuery();
                            cmd1.Dispose();

                            Co.Close();
                        }
                    }
                    MessageBox.Show("Record Saved Successfully.", "Success Message");
                    DialogResult result = MessageBox.Show("Do you want to print the report?", "Print Report", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        printReport();
                    }
                    else
                    {
                        MessageBox.Show("Printing canceled.", "Canceled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    Co.Close();
                    Initiatefields();
                  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void printReport()
        {
            try
            {
                ReportViewer frmRpt = new ReportViewer();
                frmRpt.SaleInvReport(txtSaleInv.Text);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (btnSearch.Text == "Search")
            {
                IsUpdate = true;
                txtSaleInv.ReadOnly = false;
                txtSaleInv.Text = "";
                lblSearchSale.Show();
                txtSaleInv.Focus();
                btnClear.Text = "Clear";
                btnSearch.Text = "Go";
            }
            else
            {
            }
        }
        private void ShowRecord()
        {
            try
            {
                if (txtSaleInv.Text == "" || txtSaleInv.Text == null)
                {
                    MessageBox.Show("Kindly insert valid code!", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSaleInv.Focus();
                    return;
                }
                Connection cs = new Connection();
                SqlConnection Co = cs.GenaricConnection();

                string qry = @" SELECT  SaleId,SaleDate,SaleMan,PartyCode,PartyName,
              TotalAmount FROM SaleMaster where SaleId='" + txtSaleInv.Text + "'";

                SqlCommand cmd = new SqlCommand(qry, Co);
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        txtSaleInv.Text = reader["SaleId"].ToString();
                        txtSaleInv.ReadOnly = true;
                        dtpInv.Text = reader["SaleDate"].ToString();
                        txtSalesMan.Text = reader["SaleMan"].ToString();
                        txtPartyCode.Text = reader["PartyCode"].ToString();
                        txtPartyName.Text = reader["PartyName"].ToString();
                        txtAmount.Text = reader["TotalAmount"].ToString();
                    }
                    reader.Close();

                    string qry2 = @"SELECT SaleDetailId,SaleId,Article,Discount,
                    Pair,SaleRate,NetAmount,SaleDate,TotalSaleRate FROM SaleDetail
                     where SaleId= '" + txtSaleInv.Text + "'";
                    SqlCommand cmd2 = new SqlCommand(qry2, Co);
                    SqlDataReader reader2;
                    reader2 = cmd2.ExecuteReader();

                    if (reader2.HasRows)
                    {
                        while (reader2.Read())
                        {
                            dgvSale.Rows.Add(
                                reader2["Article"].ToString(),
                                reader2["Pair"].ToString(),
                                reader2["SaleRate"].ToString(),
                                reader2["TotalSaleRate"].ToString(),
                                reader2["Discount"].ToString(),
                                reader2["NetAmount"].ToString()
                                ) ;
                        }
                        txtSaleInv.ReadOnly = true;

                        reader2.Close();
                        IsUpdate = true;
                        btnDelete.Enabled = true;
                        btnSave.Enabled = true;

                        //btnClear.Text = "Clear";
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtSaleInv_TextChanged(object sender, EventArgs e)
        {
            if (btnSearch.Text == "Go")
            {
                ShowRecord();
            }
        }

        private void txtSaleInv_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode)
            {
                e.SuppressKeyPress = true;
                dtpInv.Focus();
            }
            if (e.KeyCode == Keys.F1)
            {
                frmSearchSale frm = new frmSearchSale();
                frm.ShowDialog();
                txtSaleInv.Text = frm.Id;
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

        private void dgvSale_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow selectedRow = dgvSale.Rows[e.RowIndex];
                if (selectedRow.Cells[0].Value != null)
                {  
                    txtArticle.Text = selectedRow.Cells[0].Value.ToString();
                    txtPair.Text = selectedRow.Cells[1].Value.ToString();
                    txtSaleRate.Text = selectedRow.Cells[2].Value.ToString();
                    txtTotalSale.Text = selectedRow.Cells[3].Value.ToString();
                    txtDiscount.Text = selectedRow.Cells[4].Value.ToString();
                    txtNetAmount.Text = selectedRow.Cells[5].Value.ToString();
                    
                    dgvSale.Rows.Remove(selectedRow);
                    btnClear.Text = "Clear";
                    txtArticle.Focus();
                }
                else
                {
                    MessageBox.Show("Please Select Accurate column", "Validation", MessageBoxButtons.OK);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode)
            {
                e.SuppressKeyPress = true;
               txtDiscount.Focus();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Connection cs = new Connection();
                SqlConnection Co = cs.GenaricConnection();
                CrudOperation crud = new CrudOperation();
                if (!LoginInfo.UserType.Equals("User"))
                {
                    crud.DeleteSaleInv(Co, txtSaleInv.Text);
                    crud.DeleteStock(Co, txtSaleInv.Text);
                    MessageBox.Show("Record Deleted Successfully.", "Success Message");
                    Initiatefields();
                }
                else
                {
                    MessageBox.Show("You dont have permission to Delete this.", "Warning Message");
                }
                Co.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dtpInv_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode)
            {
                e.SuppressKeyPress = true;
                txtSalesMan.Focus();
            }
        }

        private void txtSalesMan_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode)
            {
                e.SuppressKeyPress = true;
                txtPartyCode.Focus();
            }
        }

        private void txtNetAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode)
            {
                e.SuppressKeyPress = true;
                btnAdd.Focus();
            }
        }

        private void txtPartyCode_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtProductCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Connection cs = new Connection();
                SqlConnection Co = cs.GenaricConnection();
                CrudOperation crud = new CrudOperation();
                if (txtArticle.Text != "")
                {
                    txtStock.Text = crud.GetStock(Co, txtArticle.Text);
                    txtSaleRate.Text = crud.GetSalePrice(Co, txtArticle.Text);

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void cmbSize_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode)
            {
                e.SuppressKeyPress = true;
                txtPair.Focus();
            }
        }

        private void cmbSize_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Connection cs = new Connection();
                SqlConnection Co = cs.GenaricConnection();
                CrudOperation crud = new CrudOperation();
                if (txtArticle.Text != "")
                {
                   // txtStock.Text = crud.GetStock(Co, Convert.ToInt32(Article.Text), Convert.ToInt32(cmbSize.Text));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            
            if (txtTotalSale.Text != "" && txtDiscount.Text != "")
            {
                
                decimal TotalPurchase = Convert.ToDecimal(txtTotalSale.Text);
                decimal Discount = Convert.ToInt32(txtDiscount.Text);
                decimal DiscountRupee = ((TotalPurchase * Discount) / 100);
                txtNetAmount.Text = (TotalPurchase - DiscountRupee).ToString();
            }
           
        }

        private void txtDiscount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                e.SuppressKeyPress = true;
                btnAdd.Focus();
            }
        }
    }
}
