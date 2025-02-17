﻿using POS.DataSets;
using POS.F1SearchForm;
using POS.FunctionClasses;
using POS.Report;
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
using static System.Net.Mime.MediaTypeNames;

namespace POS.Forms
{
    public partial class frmSaleReturn : Form
    {
        public static string qry = "";
        public static bool IsUpdate;
        public frmSaleReturn()
        {
            InitializeComponent();
            initize();
        }
        public void initize() {
            txtPartyCode.Text = string.Empty;
            txtArticle.Text = string.Empty;
            txtRemainingQuantity.Text = string.Empty;
            txtPartyName.Text = string.Empty;
          
            txtSalesMan.Text = string.Empty;
            txtAmount.Text = string.Empty;
            txtStock.Text = string.Empty;
            txtSaleRate.Text = string.Empty;
            txtReturnQuantity.Text = string.Empty;
            txtNetAmount.Text = string.Empty;
            Connection cs = new Connection();
            SqlConnection Co = cs.GenaricConnection();
            CrudOperation CRUD = new CrudOperation();

            txtSaleReturnInv.Text = CRUD.GetMaxIdentity(Co, "SaleReturnMaster");
            txtSaleReturnInv.Text = "SR-" + txtSaleReturnInv.Text;
            txtSaleReturnInv.ReadOnly = true;
            lblSearchPurchase.Hide();
            btnSearch.Text = "Search";
            btnClear.Text = "Cancel";
            IsUpdate = false;
            txtPartyCode.Focus();
            dgvPurchaseReturn.Show();
         
            txtSalesMan.Text = LoginInfo.UserName;
            txtSalesMan.ReadOnly = true;
            txtRemainingQuantity.ReadOnly = true;
            FormatGrid();
        }
        private void FormatGrid()
        {
            dgvPurchaseReturn.Columns.Clear();
            dgvPurchaseReturn.Rows.Clear();
            dgvPurchaseReturn.ScrollBars = ScrollBars.Both;

            dgvPurchaseReturn.ColumnCount = 5;
            dgvPurchaseReturn.Columns[0].Name = "Article";
            dgvPurchaseReturn.Columns[1].Name = "Sale Rate"; 
            dgvPurchaseReturn.Columns[2].Name = "Discount";
            dgvPurchaseReturn.Columns[3].Name = "Returned Quantity";
            dgvPurchaseReturn.Columns[4].Name = "Net Amount";
        }

        private void txtPurchaseReturnInv_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode)
            {
                e.SuppressKeyPress = true;
                dtpInv.Focus();
            }
            if (e.KeyCode == Keys.F1)
            {
                frmSearchSaleReturn frm = new frmSearchSaleReturn();
                frm.ShowDialog();
                txtSaleReturnInv.Text = frm.Id;
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
                        txtPartyName.ReadOnly = true;
                        btnClear.Text = "Clear";
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
                btnClear.Text = "Clear";
            }
        }

        private void txtPartyName_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode)
            {
                e.SuppressKeyPress = true;
                txtAmount.Focus();
            }
        }

        private void txtAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode)
            {
                e.SuppressKeyPress = true;
                txtArticle.Focus();
            }
        }

        private void txtProductCode_KeyDown(object sender, KeyEventArgs e)
        {
            Connection cs = new Connection();
            SqlConnection Co = cs.GenaricConnection();
            CrudOperation crud = new CrudOperation();

            if (e.KeyCode == Keys.Enter)
            {
                txtStock.Text = "";
                txtRemainingQuantity.Text = "";
                txtNetAmount.Text = "";
                txtReturnQuantity.Text = "";
                e.SuppressKeyPress = true;
                if (txtArticle.Text != "")
                {
                    SearchForm search = new SearchForm();
                    DataTable Data = search.SearchByAricle(txtArticle.Text, "SaleReturnDetail");
                    if (Data.Rows.Count > 0)
                    {
                        txtStock.Text = crud.GetStock(Co, txtArticle.Text);
                        txtStock.ReadOnly = true;
                        txtSaleRate.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Product Not Registered", "Alert");
                        txtArticle.Text = "";
                        txtReturnQuantity.Text = "";
                        txtDiscount.Text = "";
                        txtSaleRate.Text = "";
                        txtArticle.Focus();
                    }
                }
            }
            else if (e.KeyCode == Keys.F1)
            {
                frmSearchArticle frm = new frmSearchArticle();
                frm.ShowDialog();
                txtArticle.Text = frm.article;
            }
        }

        private void txtProduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode)
            {
                e.SuppressKeyPress = true;
                txtStock.Focus();
            }
        }

        private void txtStock_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode)
            {
                e.SuppressKeyPress = true;
                txtReturnQuantity.Focus();
            }
        }

        private void txtReturnQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode)
            {
                e.SuppressKeyPress = true;
                txtRemainingQuantity.Focus();
            }
        }

        private void txtRemainingQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode)
            {
                e.SuppressKeyPress = true;
                btnAdd.Focus();
            }
        }

  
        private void txtReturnQuantity_TextChanged_1(object sender, EventArgs e)
        {
            if (txtStock.Text != "" && txtReturnQuantity.Text != "")
            {
                decimal stock = Convert.ToDecimal(txtStock.Text);
                int Return = Convert.ToInt32(txtReturnQuantity.Text);
                txtRemainingQuantity.Text= (stock + Return).ToString();
            }
            if (txtSaleRate.Text != "" && txtReturnQuantity.Text != "")
            {
                decimal Rate = Convert.ToDecimal(txtSaleRate.Text);
                int Quantity = Convert.ToInt32(txtReturnQuantity.Text);
                txtNetAmount.Text = (Rate * Quantity).ToString();
            }

        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            if (txtArticle.Text == "")
            {
                MessageBox.Show("Please Enter Product.", "Alert Message");
                txtArticle.Focus();
            }

            else if (txtReturnQuantity.Text == "")
            {
                MessageBox.Show("Please Enter Returned Quantity.", "Alert Message");
                txtReturnQuantity.Focus();
            }
            else if (Convert.ToInt32(txtReturnQuantity.Text) < 0)
            {
                MessageBox.Show("Please Enter Sale Return Quantity Greater Than 0.", "Alert Message");
             
            }


            else
            {
                string productCode = txtArticle.Text;
                    int newRowIndex = dgvPurchaseReturn.Rows.Add(
                        productCode,
                       txtSaleRate.Text,
                       txtDiscount.Text,
                        txtReturnQuantity.Text,
                       txtNetAmount.Text
                    );
                double totalAmount = 0.0;
                foreach (DataGridViewRow row in dgvPurchaseReturn.Rows)
                {
                    double netAmount;
                    if (row.Cells[4].Value != null && double.TryParse(row.Cells[4].Value.ToString(), out netAmount))
                    {
                        totalAmount += netAmount;
                    }
                }
                txtAmount.Text = totalAmount.ToString();
                txtArticle.Text = "";
              
                txtReturnQuantity.Text = "";
                txtSaleRate.Text = "";
                txtStock.Text = "";
                txtReturnQuantity.Text = "";
                txtRemainingQuantity.Text = "";
                txtNetAmount.Text = "";
                txtArticle.Focus();
                dgvPurchaseReturn.Show();
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
                    txtPartyCode.Focus();
                }

                else if (dgvPurchaseReturn.Rows.Count == 1)
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
                            crud.InsertSaleReturnMaster(Co, txtSaleReturnInv.Text, DateTime.Now, txtSalesMan.Text, Convert.ToInt32(txtPartyCode.Text),
                           txtPartyName.Text, Convert.ToInt64(txtAmount.Text), IsUpdate);
                        }
                        else
                        {
                            MessageBox.Show("You dont have permission to edit this.", "Warning Message");
                        }
                    }
                    if (IsUpdate != true)
                    {
                        crud.InsertSaleReturnMaster(Co, txtSaleReturnInv.Text, DateTime.Now, txtSalesMan.Text, Convert.ToInt32(txtPartyCode.Text),
                                  txtPartyName.Text, Convert.ToInt64(txtAmount.Text), IsUpdate);
                    }
                    crud.DeleteStock(Co, txtSaleReturnInv.Text);
                    for (int L = 0; L < dgvPurchaseReturn.Rows.Count; L++)
                    {
                        if (dgvPurchaseReturn.Rows[L].Cells[1].Value == null)
                        {
                            break;
                        }
                        else
                        {
                            if (Co.State != ConnectionState.Open)
                                Co.Open();
                            SqlCommand cmd = new SqlCommand("InsertSaleReturnDetail", Co);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@SaleReturnInv", SqlDbType.NVarChar).Value = txtSaleReturnInv.Text;
                            cmd.Parameters.Add("@Article", SqlDbType.NVarChar).Value = dgvPurchaseReturn.Rows[L].Cells[0].Value;
                            cmd.Parameters.Add("@SaleRate", SqlDbType.Float).Value = dgvPurchaseReturn.Rows[L].Cells[1].Value;
                            cmd.Parameters.Add("@Discount", SqlDbType.Int).Value = dgvPurchaseReturn.Rows[L].Cells[2].Value;
                            cmd.Parameters.Add("@ReturnQuantity", SqlDbType.Decimal).Value = dgvPurchaseReturn.Rows[L].Cells[3].Value;
                            cmd.Parameters.Add("@NetAmount", SqlDbType.Float).Value = dgvPurchaseReturn.Rows[L].Cells[4].Value;
                            cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = DateTime.Now;

                            dgvPurchaseReturn.Rows[L].Cells[0].ReadOnly = true;
                            dgvPurchaseReturn.Rows[L].Cells[1].ReadOnly = true;
                            dgvPurchaseReturn.Rows[L].Cells[2].ReadOnly = true;
                            dgvPurchaseReturn.Rows[L].Cells[3].ReadOnly = true;
                            dgvPurchaseReturn.Rows[L].Cells[4].ReadOnly = true;

                            cmd.ExecuteNonQuery();
                            cmd.Dispose();

                            SqlCommand cmd1 = new SqlCommand("InsertUpdateStock", Co);
                            cmd1.CommandType = CommandType.StoredProcedure;
                            cmd1.Parameters.Add("@InvType", SqlDbType.VarChar).Value = "SR";
                            cmd1.Parameters.Add("@InvId", SqlDbType.NVarChar).Value = txtSaleReturnInv.Text;
                            cmd1.Parameters.Add("@Article", SqlDbType.NVarChar).Value = dgvPurchaseReturn.Rows[L].Cells[0].Value;
                            cmd1.Parameters.Add("@UnitPrice", SqlDbType.Decimal).Value =Convert.ToDecimal(dgvPurchaseReturn.Rows[L].Cells[1].Value);
                            cmd1.Parameters.Add("@Discount", SqlDbType.Int).Value =Convert.ToInt32(dgvPurchaseReturn.Rows[L].Cells[2].Value);
                            cmd1.Parameters.Add("@Pair", SqlDbType.Decimal).Value = dgvPurchaseReturn.Rows[L].Cells[3].Value;
                            cmd1.Parameters.Add("@NetAmount", SqlDbType.Float).Value = dgvPurchaseReturn.Rows[L].Cells[4].Value;
                            cmd1.Parameters.Add("@TotalAmount", SqlDbType.Decimal).Value =Convert.ToDecimal(dgvPurchaseReturn.Rows[L].Cells[4].Value);
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
                    initize();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dgvPurchaseReturn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow selectedRow = dgvPurchaseReturn.Rows[e.RowIndex];
                    if (selectedRow.Cells[0].Value != null)
                    {
                        txtArticle.Text = selectedRow.Cells[0].Value.ToString();
                        txtSaleRate.Text = selectedRow.Cells[1].Value.ToString();
                        txtDiscount.Text = selectedRow.Cells[2].Value.ToString();
                        txtReturnQuantity.Text = selectedRow.Cells[3].Value.ToString();
                        txtNetAmount.Text = selectedRow.Cells[4].Value.ToString();

                        dgvPurchaseReturn.Rows.Remove(selectedRow);
                        btnClear.Text = "Clear";
                        txtArticle.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Please Select Accurate column", "Validation", MessageBoxButtons.OK);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            if (btnClear.Text== "Clear")
            {
                initize();
            }
            else {
                this.Close();
            }
        }
        private void txtProductCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            btnClear.Text = "Clear";
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtReturnQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (btnSearch.Text == "Search")
            {
                IsUpdate = true;
                txtSaleReturnInv.ReadOnly = false;
                txtSaleReturnInv.Text = "";
                lblSearchPurchase.Show();
                txtSaleReturnInv.Focus();
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
                if (txtSaleReturnInv.Text == "" || txtSaleReturnInv.Text == null)
                {
                    MessageBox.Show("Kindly insert valid code!", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSaleReturnInv.Focus();
                    return;
                }
                Connection cs = new Connection();
                SqlConnection Co = cs.GenaricConnection();

                string qry = @" SELECT  SaleReturnId,SaleReturnDate,SaleMan,PartyCode,
               PartyName,TotalAmount FROM SaleReturnMaster where SaleReturnId='" + txtSaleReturnInv.Text + "'";

                SqlCommand cmd = new SqlCommand(qry, Co);
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        txtSaleReturnInv.Text = reader["SaleReturnId"].ToString();
                        txtSaleReturnInv.ReadOnly = true;
                        dtpInv.Text = reader["SaleReturnDate"].ToString();
                        txtSalesMan.Text = reader["SaleMan"].ToString();
                        txtPartyCode.Text = reader["PartyCode"].ToString();
                        txtPartyName.Text = reader["PartyName"].ToString();
                        txtAmount.Text = reader["TotalAmount"].ToString();
                    }
                    reader.Close();

                    string qry2 = @"SELECT  SaleReturnDetailId,SaleReturnId,Article,Discount,
                    SaleRate,ReturnQuantity ,NetAmount,SaleReturnDate FROM SaleReturnDetail
                     where SaleReturnId= '" + txtSaleReturnInv.Text + "' ";
                    SqlCommand cmd2 = new SqlCommand(qry2, Co);
                    SqlDataReader reader2;
                    reader2 = cmd2.ExecuteReader();
                    if (reader2.HasRows)
                    {
                        while (reader2.Read())
                        {
                            if (reader2["ReturnQuantity"] != DBNull.Value)
                            {
                                decimal quantityValue;
                                if (decimal.TryParse(reader2["ReturnQuantity"].ToString(), out quantityValue))
                                {
                                    int quantityInt = (int)quantityValue; // Convert to integer
                                    dgvPurchaseReturn.Rows.Add(
                                        reader2["Article"].ToString(),
                                        reader2["SaleRate"].ToString(),
                                        reader2["Discount"].ToString(),
                                           quantityInt,
                                        reader2["NetAmount"].ToString()
                                    );
                                }           
                            }  
                        }
                        txtSaleReturnInv.ReadOnly = true;
                        reader2.Close();
                        IsUpdate = true;
                        btnDelete.Enabled = true;
                        btnSave.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPurchaseReturnInv_TextChanged(object sender, EventArgs e)
        {
            if (btnSearch.Text == "Go")
            {
                ShowRecord();
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
                    crud.DeletePurchaseReturnInv(Co, txtSaleReturnInv.Text);
                    crud.DeleteStock(Co, txtSaleReturnInv.Text);
                    MessageBox.Show("Record Deleted Successfully.", "Success Message");
                    initize();
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

        private void txtPartyCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            btnClear.Text = "Clear";
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;

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
                    txtStock.Text = crud.GetStock(Co,txtArticle.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void cmbSize_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode)
            {
                e.SuppressKeyPress = true;
                txtReturnQuantity.Focus();
            }
        }

        private void txtSaleRate_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode)
            {
                e.SuppressKeyPress = true;
                txtDiscount.Focus();
            }
        }

        private void txtDiscount_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode)
            {
                e.SuppressKeyPress = true;
                txtReturnQuantity.Focus();
            }
        }
        public void printReport()
        {
            try
            {
                ReportViewer frmRpt = new ReportViewer();
                frmRpt.SaleReturnInvReport(txtSaleReturnInv.Text);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
