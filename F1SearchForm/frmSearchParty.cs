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
    public partial class frmSearchParty : Form
    {
        string ID;
        string PartyName;
        string Contact;
        public string Id
        {
            get { return ID; }
        }
        public string Party
        {
            get { return PartyName; }
        }
        //public string contanct
        //{
        //    get { return Contact; }
        //}


        public frmSearchParty()
        {
            InitializeComponent();
            initlize();
        }
        public void initlize() {
            Connection cs = new Connection();
            SqlConnection Co = cs.GenaricConnection();
            CrudOperation CRUD = new CrudOperation();
            dgvPartyInfo.Refresh();
            DataTable dt = new DataTable();
            dt = CRUD.GetPartyInfoData(Co);
            dgvPartyInfo.DataSource = dt;
            txtSearch.Focus();
        }

        private void dgvPartyInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmSearchParty_Load(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                Connection cs = new Connection();
                SqlConnection Co = cs.GenaricConnection();
               // Select PartyCode, PartyName, Location, Contact  from PartyInfo where IsDeleted = 0
                string qry = @"Select PartyCode, PartyName, Location, Contact  from PartyInfo where
                PartyName like '%" + txtSearch.Text + "%' and  isnull(IsDeleted,0) =0  order by PartyCode desc";
                SqlCommand cmd = new SqlCommand(qry, Co);
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                dt.Load(reader);
                dgvPartyInfo.DataSource = dt;
               // dgvPartyInfo.Columns[2].Width = 140;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvPartyInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvPartyInfo.Rows.Count > 0 && dgvPartyInfo.CurrentRow.Index != -1)
                {
                    ID = dgvPartyInfo.Rows[dgvPartyInfo.CurrentRow.Index].Cells[0].Value.ToString();
                    PartyName = dgvPartyInfo.Rows[dgvPartyInfo.CurrentRow.Index].Cells[1].Value.ToString();
                 //   Contact = dgvPartyInfo.Rows[dgvPartyInfo.CurrentRow.Index].Cells[2].Value.ToString();
                }
                else ID = "";

                Close();
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

                if (dgvPartyInfo.Rows.Count > 0 && dgvPartyInfo.CurrentRow.Index != -1)
                {
                    ID = dgvPartyInfo.Rows[dgvPartyInfo.CurrentRow.Index].Cells[0].Value.ToString();
                    PartyName = dgvPartyInfo.Rows[dgvPartyInfo.CurrentRow.Index].Cells[1].Value.ToString();
                    Contact = dgvPartyInfo.Rows[dgvPartyInfo.CurrentRow.Index].Cells[2].Value.ToString();
                }
                else ID = "";

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                        ID = dgvPartyInfo.Rows[dgvPartyInfo.CurrentRow.Index].Cells[0].Value.ToString();
                        PartyName = dgvPartyInfo.Rows[dgvPartyInfo.CurrentRow.Index].Cells[1].Value.ToString();
                        Contact = dgvPartyInfo.Rows[dgvPartyInfo.CurrentRow.Index].Cells[2].Value.ToString();
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
