﻿using POS.F1SearchForm;
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
            txtAmount.Text = string.Empty;
            lblSearchExpense.Hide();
            Co = cs.GenaricConnection();
            txtID.Text = CRUD.GetMaxIdentity(Co, "Expense");
            txtID.ReadOnly = true;
            btnSearch.Text = "Search";
            btnClear.Text = "Cancel";
            IsUpdate = false;
            dptDate.Focus();
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
                Co = cs.GenaricConnection();
                if (dptDate.Text == "")
                {
                    MessageBox.Show("Please Enter Expense Type", "Alert");
                    dptDate.Focus();
                    return;
                }
                if (txtAmount.Text == "")
                {
                    MessageBox.Show("Please Enter Amount", "Alert");
                    txtAmount.Focus();
                    return;
                }
                if (IsUpdate)
                {
                    if (!LoginInfo.UserType.Equals("User"))
                    {
                        CRUD.InsertUpdateExpense(Co, Convert.ToInt32(txtID.Text), DateTime.Now, cbPurpose.Text , txtDiscription.Text,Convert.ToDecimal(txtAmount.Text), IsUpdate);
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
                        CRUD.InsertUpdateExpense(Co, Convert.ToInt32(txtID.Text),Convert.ToDateTime(DateTime.Now), cbPurpose.Text, txtDiscription.Text, Convert.ToDecimal(txtAmount.Text), IsUpdate);

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
                lblSearchExpense.Show();
                txtID.Text = "";
                btnClear.Text = "Clear";
                btnSearch.Text = "Go";
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

        private void txtID_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode) {
                e.SuppressKeyPress = true;
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
                        txtAmount.Text = Data.Rows[0]["Amount"].ToString();
                    }
                }
            }
            if (Keys.F1 == e.KeyCode)
            {
                frmSearchExpense frm = new frmSearchExpense();
                frm.ShowDialog();
                txtID.Text = frm.Id;
                dptDate.Text = frm.date;
                cbPurpose.Text = frm.purpose;
                txtAmount.Text = frm.amount;
                txtDiscription.Text = frm.description;
            }
        }
    }
}
