using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using POS.Forms;
using POS.Report_Form;
using static POS.Login;

namespace POS.Main
{
    public partial class Main : Form
    {
        public static string ReportType;
        public Main()
        {
            InitializeComponent();
        
        }



        private void partyCodingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPartyCoding frm = new frmPartyCoding();
           frm.ShowDialog(); 
        }

        private void productCodingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProduct frm = new frmProduct();
            frm.ShowDialog();
        }

        private void purchaseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmPurchase frm = new frmPurchase();    
            frm.ShowDialog();
        }

        private void saleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmSale frm = new frmSale();
            frm.ShowDialog();
        }

        private void sizeCodingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSizeCoding frm = new frmSizeCoding();
            frm.ShowDialog();
        }

        private void purToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPurchaseReturn frm = new frmPurchaseReturn();
            frm.ShowDialog();
        }

        private void saleReturnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSaleReturn frm = new frmSaleReturn();
            frm.Show();
        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUser frm = new frmUser();
            frm.ShowDialog();
        }

        private void purchaseReportBetweenDateTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportType = "PurchaseInv";
            ReportForm frm = new ReportForm();
            frm.ShowDialog();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            List<string> users = new List<string>();
            users = LoginInfo.Rights;
            if (!users.Contains("PartyCoding"))
            {
                partyCodingToolStripMenuItem.Visible = false;
            }
            if (!users.Contains("ProductCoding"))
            {
                 productCodingToolStripMenuItem.Visible = false;
            }
            if (!users.Contains("SizeCoding"))
            {
                 sizeCodingToolStripMenuItem.Visible = false;
            }
            if (!users.Contains("Purchase"))
            {
                 purchaseToolStripMenuItem1.Visible = false;
            }
            if (!users.Contains("PurchaseReturn"))
            {
                purToolStripMenuItem.Visible = false;
            }
            if (!users.Contains("Sale"))
            {
                 saleToolStripMenuItem1.Visible = false;
            }
            if (!users.Contains("SaleReturn"))
            {
                 saleReturnToolStripMenuItem.Visible = false;
            }
            if (!users.Contains("PurchaeReportBetween"))
            {
                 purchaseReportBetweenDateTimeToolStripMenuItem.Visible = false;
            }
            if (!users.Contains("User"))
            {
                 userToolStripMenuItem.Visible = false;
            }
        }

        private void saleReportBetweenDateTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportType = "SaleInv";
            ReportForm frm = new ReportForm();
            frm.ShowDialog();

        }

        private void purchaseReturnReportBetweenDateTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportType = "PurchaseReturnInv";
            ReportForm frm = new ReportForm();
            frm.ShowDialog();
        }
    }
}
