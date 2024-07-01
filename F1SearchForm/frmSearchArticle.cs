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
    public partial class frmSearchArticle : Form
    {
        string ID;
        string Article;
        public string Id
        {
            get { return ID; }
        }
        public string article
        {
            get { return Article; }
        }

        public frmSearchArticle()
        {
            InitializeComponent();
            Initlize();
        }
        public void Initlize() {
            Connection cs = new Connection();
            SqlConnection Co = cs.GenaricConnection();
            CrudOperation CRUD = new CrudOperation();
            dgvProductInfo.Refresh();
            DataTable dt = new DataTable();
            dt = CRUD.GetArticleInfoData(Co);
            dgvProductInfo.DataSource = dt;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                Connection cs = new Connection();
                SqlConnection Co = cs.GenaricConnection();
                // Select PartyCode, PartyName, Location, Contact  from PartyInfo where IsDeleted = 0
                string qry = @"Select ArticleId, Article from ArticleInfo where
                Article like '%" + txtSearch.Text + "%' and IsDeleted = 0 order by ArticleId desc";
                SqlCommand cmd = new SqlCommand(qry, Co);
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                dt.Load(reader);
                dgvProductInfo.DataSource = dt;
                // dgvPartyInfo.Columns[2].Width = 140;
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

        private void dgvProductInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvProductInfo.Rows.Count > 0 && dgvProductInfo.CurrentRow.Index != -1)
                {
                    ID = dgvProductInfo.Rows[dgvProductInfo.CurrentRow.Index].Cells[0].Value.ToString();
                    Article = dgvProductInfo.Rows[dgvProductInfo.CurrentRow.Index].Cells[1].Value.ToString();
                }
                else ID = "";

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                        ID = dgvProductInfo.Rows[dgvProductInfo.CurrentRow.Index].Cells[0].Value.ToString();
                        Article = dgvProductInfo.Rows[dgvProductInfo.CurrentRow.Index].Cells[1].Value.ToString();
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

                if (dgvProductInfo.Rows.Count > 0 && dgvProductInfo.CurrentRow.Index != -1)
                {
                    ID = dgvProductInfo.Rows[dgvProductInfo.CurrentRow.Index].Cells[0].Value.ToString();
                    Article = dgvProductInfo.Rows[dgvProductInfo.CurrentRow.Index].Cells[1].Value.ToString();
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
