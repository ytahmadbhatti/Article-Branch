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

namespace POS.F1SearchForm
{
    public partial class frmSearchExpense : Form
    {
        string ID;
        string Date;
        string Purpose;
        string Amount;
        string Description;

        public string Id
        {
            get { return ID; }
        }
        public string date
        {
            get { return Date; }
        }
        public string purpose
        {
            get { return Purpose; }
        }
        public string amount
        {
            get { return Amount; }
        }
        public string description
        {
            get { return Description; }
        }
        public frmSearchExpense()
        {
            InitializeComponent();
            Initlize();
        }
        public void Initlize()
        {
            Connection cs = new Connection();
            SqlConnection Co = cs.GenaricConnection();
            CrudOperation CRUD = new CrudOperation();
            dgvExpense.Refresh();
            DataTable dt = new DataTable();
            dt = CRUD.GetExpanseData(Co);
            dgvExpense.DataSource = dt;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                Connection cs = new Connection();
                SqlConnection Co = cs.GenaricConnection();
                string qry = @"SELECT  ID,Date,Purpose,Description ,Amount
                FROM Expense where ID like '%" + txtSearch.Text + "%' and IsDeleted = 0 order by ID desc";
                SqlCommand cmd = new SqlCommand(qry, Co);
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                dt.Load(reader);
                dgvExpense.DataSource = dt;
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

        private void dgvExpense_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvExpense.Rows.Count > 0 && dgvExpense.CurrentRow.Index != -1)
                {
                    ID = dgvExpense.Rows[dgvExpense.CurrentRow.Index].Cells[0].Value.ToString();
                    Date = dgvExpense.Rows[dgvExpense.CurrentRow.Index].Cells[1].Value.ToString();
                    Purpose = dgvExpense.Rows[dgvExpense.CurrentRow.Index].Cells[2].Value.ToString();
                    Amount = dgvExpense.Rows[dgvExpense.CurrentRow.Index].Cells[3].Value.ToString();
                    Description = dgvExpense.Rows[dgvExpense.CurrentRow.Index].Cells[4].Value.ToString();
                }
                else ID = "";

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                        ID = dgvExpense.Rows[dgvExpense.CurrentRow.Index].Cells[0].Value.ToString();
                        Date = dgvExpense.Rows[dgvExpense.CurrentRow.Index].Cells[1].Value.ToString();
                        Purpose = dgvExpense.Rows[dgvExpense.CurrentRow.Index].Cells[2].Value.ToString();
                        Amount = dgvExpense.Rows[dgvExpense.CurrentRow.Index].Cells[3].Value.ToString();
                        Description = dgvExpense.Rows[dgvExpense.CurrentRow.Index].Cells[4].Value.ToString();
                    }
                    else ID = "";
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvExpense.Rows.Count > 0 && dgvExpense.CurrentRow.Index != -1)
                    {
                        ID = dgvExpense.Rows[dgvExpense.CurrentRow.Index].Cells[0].Value.ToString();
                        Date = dgvExpense.Rows[dgvExpense.CurrentRow.Index].Cells[1].Value.ToString();
                        Purpose = dgvExpense.Rows[dgvExpense.CurrentRow.Index].Cells[2].Value.ToString();
                        Amount = dgvExpense.Rows[dgvExpense.CurrentRow.Index].Cells[3].Value.ToString();
                        Description = dgvExpense.Rows[dgvExpense.CurrentRow.Index].Cells[4].Value.ToString();
                }
                else ID = "";

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
