using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using POS.Main;
using POS.Report;

namespace POS.Report_Form
{
    public partial class ReportForm : Form
    {
        public ReportForm()
        {
            InitializeComponent();
            Inilitilze();
        }
        public void Inilitilze() {

            dtpFrom.Format = DateTimePickerFormat.Custom;
            dtpFrom.CustomFormat = "dd/MM/yyyy hh:mm:ss tt";

            dtpTo.Format = DateTimePickerFormat.Custom;
            dtpTo.CustomFormat = "dd/MM/yyyy hh:mm:ss tt";

            if (Main.Main.ReportType == "PurchaseInv")
            {
                ReportLabel.Text = "Purchase Invoice Between DateTime";
            }
            if (Main.Main.ReportType == "SaleInv")
            {
                ReportLabel.Text = "Sale Invoice Between DateTime";
            }
            if (Main.Main.ReportType == "PurchaseReturnInv")
            {
                ReportLabel.Text = "Purchase Return Invoice Between DateTime";
            }
            
            if (Main.Main.ReportType == "CashBookReeport")
            {
                ReportLabel.Text = "Cash Book Between DateTime";
            }
            if (Main.Main.ReportType == "StockReport")
            {
                ReportLabel.Text = "Stock Between DateTime";
            }
        }

        private void btnShowReport_Click(object sender, EventArgs e)
        {

            ReportViewer RptView = new ReportViewer();
            if (Main.Main.ReportType == "PurchaseInv") {
                RptView.PurchaseInvBetweenDateReport(dtpFrom.Value, dtpTo.Value);
            }
            if (Main.Main.ReportType == "SaleInv")
            {
                RptView.SaleInvBetweenDateReport(dtpFrom.Value, dtpTo.Value);
            }
            if (Main.Main.ReportType == "PurchaseReturnInv")
            {
                RptView.PurhcaseReturnInvBetweenDateReport(dtpFrom.Value, dtpTo.Value);
            }
            if (Main.Main.ReportType == "CashBookReeport")
            {
                RptView.CashBookBetweenDateReport(dtpFrom.Value, dtpTo.Value);
            }
            if (Main.Main.ReportType == "StockReport")
            {
                RptView.StockBetweenDateReport(dtpFrom.Value, dtpTo.Value);
            }
        }
    }
}
