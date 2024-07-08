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
using static System.Net.WebRequestMethods;
using POS.F1SearchForm;
using POS.Report;

namespace POS.Forms
{
    public partial class frmPurchase : Form
    {
        public static string qry = "";
        public static bool IsUpdate;
        public frmPurchase()
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
            txtPair.Text = string.Empty;
            txtTotalPurchase.Text = string.Empty;
            txtDiscount.Text = string.Empty;

            Connection cs = new Connection();
            SqlConnection Co = cs.GenaricConnection();
            CrudOperation CRUD = new CrudOperation();

            txtPurchaseInv.Text = CRUD.GetMaxIdentity(Co, "PurchaseMaster");
            txtPurchaseInv.Text = "PI-" + txtPurchaseInv.Text;
            txtPurchaseInv.ReadOnly = true;
            lblSearchPurchase.Hide();
            btnSearch.Text = "Search";
            btnClear.Text = "Cancel";
            IsUpdate = false;

            dgvPurchase.Show();
            FormatGrid();
            txtSalesMan.Text = LoginInfo.UserName;
            txtSalesMan.ReadOnly = true;
            txtNetAmount.ReadOnly = true;
            txtPartyCode.Focus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Connection cs = new Connection();
                SqlConnection Co = cs.GenaricConnection();
                CrudOperation crud = new CrudOperation();
                if (txtPurchaseInv.Text == "")
                {
                    MessageBox.Show("Please Enter Party Name.", "Alert");
                    txtPurchaseInv.Focus();
                }

                else if (dgvPurchase.Rows.Count == 1)
                {
                    MessageBox.Show("Please Enter Article.", "Alert");
                    txtArticle.Focus();
                }
                else
                {
                    if (IsUpdate == true)
                    {
                        if (!LoginInfo.UserType.Equals("User"))
                        {
                            crud.InsertPurchaseMaster(Co, txtPurchaseInv.Text, DateTime.Now, txtSalesMan.Text, Convert.ToInt32(txtPartyCode.Text),
                           txtPartyName.Text, Convert.ToDecimal(txtAmount.Text), IsUpdate);
                        }
                        else
                        {
                            MessageBox.Show("You dont have permission to edit this.", "Warning Message");
                        }
                    }
                    else
                    {
                        crud.InsertPurchaseMaster(Co, txtPurchaseInv.Text, DateTime.Now, txtSalesMan.Text, Convert.ToInt32(txtPartyCode.Text),
                                   txtPartyName.Text, Convert.ToDecimal(txtAmount.Text), IsUpdate);
                    }

                    crud.DeleteStock(Co, txtPurchaseInv.Text);
                    for (int L = 0; L < dgvPurchase.Rows.Count; L++)
                    {
                        if (dgvPurchase.Rows[L].Cells[1].Value == null)
                        {
                            break;
                        }
                        else
                        {
                            if (Co.State != ConnectionState.Open)
                                Co.Open();
                            SqlCommand cmd = new SqlCommand("InsertPurchaseDetail", Co);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@PurchaseInv", SqlDbType.NVarChar).Value = txtPurchaseInv.Text;
                            cmd.Parameters.Add("@Article", SqlDbType.NVarChar).Value = dgvPurchase.Rows[L].Cells[0].Value;
                            cmd.Parameters.Add("@Pair", SqlDbType.NVarChar).Value = dgvPurchase.Rows[L].Cells[1].Value;
                            cmd.Parameters.Add("@UnitPrice", SqlDbType.Decimal).Value = Convert.ToDecimal(dgvPurchase.Rows[L].Cells[2].Value);
                            cmd.Parameters.Add("@Rate", SqlDbType.Decimal).Value =Convert.ToDecimal(dgvPurchase.Rows[L].Cells[3].Value);
                            cmd.Parameters.Add("@Discount", SqlDbType.Int).Value = Convert.ToInt32(dgvPurchase.Rows[L].Cells[4].Value);
                            cmd.Parameters.Add("@NetAmount", SqlDbType.Decimal).Value = Convert.ToDecimal(dgvPurchase.Rows[L].Cells[5].Value);
                            cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = DateTime.Now;

                            dgvPurchase.Rows[L].Cells[0].ReadOnly = true;
                            dgvPurchase.Rows[L].Cells[1].ReadOnly = true;
                            dgvPurchase.Rows[L].Cells[2].ReadOnly = true;
                            dgvPurchase.Rows[L].Cells[3].ReadOnly = true;
                            dgvPurchase.Rows[L].Cells[4].ReadOnly = true;
                            dgvPurchase.Rows[L].Cells[5].ReadOnly = true;

                            cmd.ExecuteNonQuery();
                            cmd.Dispose();

                            SqlCommand cmd1 = new SqlCommand("InsertUpdateStock", Co);
                            cmd1.CommandType = CommandType.StoredProcedure;
                            cmd1.Parameters.Add("@InvType", SqlDbType.VarChar).Value = "PI";
                            cmd1.Parameters.Add("@InvId", SqlDbType.NVarChar).Value = txtPurchaseInv.Text;
                            cmd1.Parameters.Add("@Article", SqlDbType.NVarChar).Value = dgvPurchase.Rows[L].Cells[0].Value;             
                            cmd1.Parameters.Add("@Pair", SqlDbType.Int).Value = Convert.ToInt32(dgvPurchase.Rows[L].Cells[1].Value);
                            cmd1.Parameters.Add("@NetAmount", SqlDbType.Decimal).Value =Convert.ToDecimal(dgvPurchase.Rows[L].Cells[5].Value);
                            cmd1.Parameters.Add("@DateTime", SqlDbType.DateTime).Value = DateTime.Now;
                            cmd1.Parameters.Add("@UserName", SqlDbType.VarChar).Value = txtSalesMan.Text;

                            cmd1.ExecuteNonQuery();
                            cmd1.Dispose();

                            Co.Close();
                        }
                    }
                    MessageBox.Show("Record Saved Successfully.", "Success Message");

                    printReport();


                    Co.Close();
                    Initiatefields();
                    Co.Close();
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
                frmRpt.PurchaseInvReport(txtPurchaseInv.Text);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtPartyName_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode)
            {
                e.SuppressKeyPress = true;
                txtSalesMan.Focus();
            }
        }

        private void txtLocation_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode)
            {
                e.SuppressKeyPress = true;
                // txtContact.Focus();
            }
        }
        private void txtContact_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode)
            {
                e.SuppressKeyPress = true;
                btnSave.Focus();
            }
        }

        private void txtPartyCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode)
            {
                e.SuppressKeyPress = true;
                dtpInv.Focus();
            }
            if (e.KeyCode == Keys.F1)
            {
                frmSearchPurchase frm = new frmSearchPurchase();
                frm.ShowDialog();
                txtPurchaseInv.Text = frm.Id;
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
                    DataGridViewRow selectedRow = dgvPurchase.Rows[e.RowIndex];
                    txtArticle.Text = selectedRow.Cells[0].Value.ToString();
                    txtPair.Text = selectedRow.Cells[1].Value.ToString();
                    txtTotalPurchase.Text = selectedRow.Cells[2].Value.ToString();
                    int disc = Convert.ToInt32(selectedRow.Cells[3].Value);
                    txtDiscount.Text = Convert.ToString(disc);
                    txtNetAmount.Text = selectedRow.Cells[4].Value.ToString();

                    dgvPurchase.Rows.Remove(selectedRow);
                    btnClear.Text = "Clear";
                    txtArticle.Focus();
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
                txtPurchaseInv.ReadOnly = false;
                txtPurchaseInv.Text = "";
                lblSearchPurchase.Show();
                txtPurchaseInv.Focus();
                btnClear.Text = "Clear";
                btnSearch.Text = "Go";
            }
            else
            {
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
                    crud.DeletePurchaseInv(Co, txtPurchaseInv.Text);
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

        private void txtPartyCode_KeyDown_1(object sender, KeyEventArgs e)
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
                txtArticle.Focus();
            }
        }

        private void FormatGrid()
        {
            dgvPurchase.Columns.Clear();
            dgvPurchase.Rows.Clear();
            dgvPurchase.ScrollBars = ScrollBars.Both;

            dgvPurchase.ColumnCount = 6;
            dgvPurchase.Columns[0].Name = "Article";
            dgvPurchase.Columns[1].Name = "Pair";
            dgvPurchase.Columns[2].Name = "Unit Price";  
            dgvPurchase.Columns[3].Name = "Rate";
            dgvPurchase.Columns[4].Name = "Discount";
            dgvPurchase.Columns[5].Name = "Net Amount";

            dgvPurchase.Columns[0].DefaultCellStyle.ForeColor = Color.Black;
            dgvPurchase.Columns[1].DefaultCellStyle.ForeColor = Color.Black;
            dgvPurchase.Columns[2].DefaultCellStyle.ForeColor = Color.Black;
            dgvPurchase.Columns[3].DefaultCellStyle.ForeColor = Color.Black;
            dgvPurchase.Columns[4].DefaultCellStyle.ForeColor = Color.Black;

            dgvPurchase.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvPurchase.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvPurchase.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvPurchase.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvPurchase.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
        }
        private void txtQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                txtDiscount.Focus();
            }
        }

        private void txtRate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                txtNetAmount.Focus();
            }
        }
        private void txtNetAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnAdd.Focus();
            }
        }

        private void dtpInv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                txtPartyCode.Focus();
            }
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            if (txtArticle.Text == "")
            {
                MessageBox.Show("Please Enter Product.", "Alert Message");
                txtArticle.Focus();
            }
            else if (txtPartyCode.Text == "")
            {
                MessageBox.Show("Please Enter Party.", "Alert Message");
                txtArticle.Focus();
            }

            else if (txtTotalPurchase.Text == "")
            {
                MessageBox.Show("Please Enter Quantity.", "Alert Message");
                txtTotalPurchase.Focus();
            }

            else
            {
                string productCode = txtArticle.Text;
                int newRowIndex = dgvPurchase.Rows.Add(
                    productCode,
                    txtPair.Text,
                    txtPurchaseRate.Text,
                    txtTotalPurchase.Text,
                    txtDiscount.Text,
                    txtNetAmount.Text
                );

                double totalAmount = 0.0;
                foreach (DataGridViewRow row in dgvPurchase.Rows)
                {
                    double netAmount;
                    if (row.Cells[5].Value != null && double.TryParse(row.Cells[5].Value.ToString(), out netAmount))
                    {
                        totalAmount += netAmount;
                    }
                }
                txtAmount.Text = totalAmount.ToString();
                txtPair.Text = "";
                txtTotalPurchase.Text = "";
                txtDiscount.Text = "";
                txtNetAmount.Text = "";
                txtArticle.Text = "";
                txtPurchaseRate.Text = "";
                txtArticle.Focus();
                dgvPurchase.Show();
            }
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void txtRate_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtPartyCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            btnClear.Text = "Clear";
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;

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


        private void txtPurchaseInv_TextChanged(object sender, EventArgs e)
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
                if (txtPurchaseInv.Text == "" || txtPurchaseInv.Text == null)
                {
                    MessageBox.Show("Kindly insert valid code!", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPurchaseInv.Focus();
                    return;
                }
                Connection cs = new Connection();
                SqlConnection Co = cs.GenaricConnection();

                string qry = @" SELECT  PurchaseId,PurchaseDate,SaleMen,PartyCode,PartyName,
              TotalAmount FROM PurchaseMaster where PurchaseId='" + txtPurchaseInv.Text + "'";

                SqlCommand cmd = new SqlCommand(qry, Co);
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        txtPurchaseInv.Text = reader["PurchaseId"].ToString();
                        txtPurchaseInv.ReadOnly = true;
                        dtpInv.Text = reader["PurchaseDate"].ToString();
                        txtSalesMan.Text = reader["SaleMen"].ToString();
                        txtPartyCode.Text = reader["PartyCode"].ToString();
                        txtPartyName.Text = reader["PartyName"].ToString();
                        txtAmount.Text = reader["TotalAmount"].ToString();
                    }
                    reader.Close();

                 string qry2 = @"SELECT  PurchaseDetailId,PurchaseId,Article,Discount, Pair,Rate,NetAmount,
                 PurchaseDate,UnitPrice FROM PurchaseDetail where PurchaseId= '" + txtPurchaseInv.Text +"' order by PurchaseId";
                    SqlCommand cmd2 = new SqlCommand(qry2, Co);
                    SqlDataReader reader2;
                    reader2 = cmd2.ExecuteReader();

                    if (reader2.HasRows)
                    {
                        while (reader2.Read())
                        {
                            if (reader2["Pair"] != DBNull.Value)
                            {
                                decimal quantityValue;
                                if (decimal.TryParse(reader2["Pair"].ToString(), out quantityValue))
                                {
                                    int quantityInt = (int)quantityValue; // Convert to integer
                                    dgvPurchase.Rows.Add(
                                        reader2["Article"].ToString(),
                                        quantityInt,
                                        reader2["UnitPrice"].ToString(),
                                        reader2["Rate"].ToString(),
                                         reader2["Discount"].ToString(),
                                        reader2["NetAmount"].ToString()
                                    );
                                }
                                else
                                {
                                }
                            }
                            else
                            {
                            }
                        }
                        txtPurchaseInv.ReadOnly = true;

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

        private void txtPartyCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtpInv_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                txtPartyCode.Focus();
            }
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            if (txtDiscount.Text != "" && txtTotalPurchase.Text != "")
            {
                decimal Rate = Convert.ToDecimal(txtDiscount.Text);
                int Quantity = Convert.ToInt32(txtTotalPurchase.Text);
                txtNetAmount.Text = (Rate * Quantity).ToString();
            }
        }

        private void cmbSize_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                txtTotalPurchase.Focus();
            }
        }

        private void txtArticle_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (txtArticle.Text != "")
                {
                    SearchForm search = new SearchForm();
                    DataTable Data = search.SearchByAricle(txtArticle.Text, "ArticleInfo");
                    if (Data.Rows.Count > 0)
                    {
                        txtArticle.Text = Data.Rows[0]["Article"].ToString();
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

        private void txtPurchaseRate_TextChanged(object sender, EventArgs e)
        {
            PurchaseCalculation();
            if(txtPurchaseRate.Text == "")
            {
                txtTotalPurchase.Clear();
                txtNetAmount.Clear();
            }
        }

        private void txtPair_TextChanged(object sender, EventArgs e)
        {
            PurchaseCalculation();
            if (txtPair.Text == "")
            {
                txtTotalPurchase.Clear();
                txtNetAmount.Clear();
            }
        }

       public void PurchaseCalculation()
        {
            if (txtPurchaseRate.Text != "" && txtPair.Text != "")
            {
                decimal Rate = Convert.ToDecimal(txtPurchaseRate.Text);
                int Quantity = Convert.ToInt32(txtPair.Text);
                txtNetAmount.Text = (Rate * Quantity).ToString();
                txtTotalPurchase.Text = (Rate * Quantity).ToString();
            }
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            if (txtTotalPurchase.Text != "" && txtDiscount.Text != "")
            {
                decimal TotalPurchase = Convert.ToDecimal(txtTotalPurchase.Text);
                decimal Discount = Convert.ToInt32(txtDiscount.Text);
                decimal DiscountRupee = ((TotalPurchase * Discount) / 100);
                txtNetAmount.Text = (TotalPurchase - DiscountRupee).ToString();
            }
            else
            {
                PurchaseCalculation();
            }
        }

        private void txtPair_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                txtPurchaseRate.Focus();
            }
        }

        private void txtPurchaseRate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                txtDiscount.Focus();
            }
        }
    }
}
