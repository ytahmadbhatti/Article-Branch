using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using POS.DataSets;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
namespace POS.Report
{
    public partial class ReportViewer : Form
    {
        ReportDocument rpt = new ReportDocument();
        string APPPATH = Path.Combine(Application.StartupPath);

        public ReportViewer()
        {
            InitializeComponent();
        }
        public void PurchaseInvReport(string purchaseInv)
        {
            Connection cs = new Connection();
            SqlConnection Co = cs.GenaricConnection();
            ReportsOperation rptOperations = new ReportsOperation();
            dsPurchase ds = new dsPurchase();
            rptOperations.PurchaseInvQuery(Co, ds, purchaseInv); 
            rpt.Load(Path.Combine(Application.StartupPath, "Report", "rptPurchase.rpt"));
            rpt.SummaryInfo.ReportTitle = "Purchase Invoice";
            rpt.SetDataSource(ds);
            crystalReportViewer1.ReportSource = rpt;
            Co.Close();
            this.ShowDialog();
        }
        public void PurchaseReturnInvReport(string purchaseeturnInv)
        {
            Connection cs = new Connection();
            SqlConnection Co = cs.GenaricConnection();
            ReportsOperation rptOperations = new ReportsOperation();
            dsPurchase ds = new dsPurchase();
            rptOperations.PurchaseReturnInvQuery(Co, ds, purchaseeturnInv);
            rpt.Load(Path.Combine(Application.StartupPath, "Report", "rptPurchaseReturnInv.rpt"));
            rpt.SummaryInfo.ReportTitle = "Purchase Return Invoice";
            rpt.SetDataSource(ds);
            crystalReportViewer1.ReportSource = rpt;
            Co.Close();
            this.ShowDialog();
        }

        public void PurchaseInvBetweenDateReport(DateTime dtpFrom ,DateTime dtpTo)
        {
            Connection cs = new Connection();
            SqlConnection Co = cs.GenaricConnection();
            ReportsOperation rptOperations = new ReportsOperation();
            dsPurchase ds = new dsPurchase();
            rptOperations.PurchaseInvBetweenDateQuery(Co, ds, dtpFrom,dtpTo);
            rpt.Load(Path.Combine(Application.StartupPath, "Report", "rptPurchaseBetweenDate.rpt"));
            rpt.SummaryInfo.ReportTitle = "Purchase Invoice Between Date Time";
            rpt.SummaryInfo.ReportComments = "Sadar Bazar Jahanian";
            rpt.SummaryInfo.ReportAuthor = "From Date :" + dtpFrom + " To Date: " + dtpTo;
            rpt.SetDataSource(ds);
            crystalReportViewer1.ReportSource = rpt;
            Co.Close();
            this.ShowDialog();
        }
        public void SaleInvBetweenDateReport(DateTime dtpFrom, DateTime dtpTo)
        {
            Connection cs = new Connection();
            SqlConnection Co = cs.GenaricConnection();
            ReportsOperation rptOperations = new ReportsOperation();
            dsPurchase ds = new dsPurchase();
            rptOperations.SaleInvBetweenDateQuery(Co, ds, dtpFrom, dtpTo);
            rpt.Load(Path.Combine(Application.StartupPath, "Report", "rptSaleInvBetweenDate.rpt"));
            rpt.SummaryInfo.ReportTitle = "Sale Invoice Between Date Time";
            rpt.SummaryInfo.ReportComments = "Sadar Bazar Jahanian";
            rpt.SummaryInfo.ReportAuthor = "From Date :" + dtpFrom + " To Date: " + dtpTo;
            rpt.SetDataSource(ds);
            crystalReportViewer1.ReportSource = rpt;
            Co.Close();
            this.ShowDialog();
        }

        public void PurhcaseReturnInvBetweenDateReport(DateTime dtpFrom, DateTime dtpTo)
        {
            Connection cs = new Connection();
            SqlConnection Co = cs.GenaricConnection();
            ReportsOperation rptOperations = new ReportsOperation();
            dsPurchase ds = new dsPurchase();
            rptOperations.PurchaseReturnInvBetweenDateQuery(Co, ds, dtpFrom, dtpTo);
            rpt.Load(Path.Combine(Application.StartupPath, "Report", "rptPurchaseReturnBetweenDate.rpt"));
            rpt.SummaryInfo.ReportTitle = "Purchase Return Invoice Between Date Time";
            rpt.SummaryInfo.ReportComments = "Sadar Bazar Jahanian";
            rpt.SummaryInfo.ReportAuthor = "From Date :" + dtpFrom + " To Date: " + dtpTo;
            rpt.SetDataSource(ds);
            crystalReportViewer1.ReportSource = rpt;
            Co.Close();
            this.ShowDialog();
        }
        public void SaleInvReport(string saleInv)
        {
            Connection cs = new Connection();
            SqlConnection Co = cs.GenaricConnection();
            ReportsOperation rptOperations = new ReportsOperation();
            dsPurchase ds = new dsPurchase();
            rptOperations.SaleInvQuery(Co, ds, saleInv);
            rpt.Load(Path.Combine(Application.StartupPath, "Report", "rptSaleInv3Inch.rpt"));
            rpt.SummaryInfo.ReportTitle = "Sale Invoice";
            rpt.SetDataSource(ds);
            crystalReportViewer1.ReportSource = rpt;
            Co.Close();
            this.ShowDialog();
        }
        public void SaleReturnInvReport(string saleReturnInv)
        {
            Connection cs = new Connection();
            SqlConnection Co = cs.GenaricConnection();
            ReportsOperation rptOperations = new ReportsOperation();
            dsPurchase ds = new dsPurchase();
            rptOperations.SaleReturnInvQuery(Co, ds, saleReturnInv);
            rpt.Load(Path.Combine(Application.StartupPath, "Report", "rptSaleReturnInv3Inch.rpt"));
            rpt.SummaryInfo.ReportTitle = "Sale Return Invoice";
            rpt.SetDataSource(ds);
            crystalReportViewer1.ReportSource = rpt;
            Co.Close();
            this.ShowDialog();
        }
        public void CashBookBetweenDateReport(DateTime dtpFrom, DateTime dtpTo)
        {
            Connection cs = new Connection();
            SqlConnection Co = cs.GenaricConnection();
            ReportsOperation rptOperations = new ReportsOperation();
            dsPurchase ds = new dsPurchase();
            rptOperations.CashBookBetweenDateQuery(Co, ds, dtpFrom, dtpTo);
            rpt.Load(Path.Combine(Application.StartupPath, "Report", "rptCashBook.rpt"));
            rpt.SummaryInfo.ReportTitle = "Cash Book";
            rpt.SummaryInfo.ReportComments = "Sadar Bazar Jahanian";
            rpt.SummaryInfo.ReportAuthor = "From Date :"+ dtpFrom + " To Date: " +dtpTo;
            rpt.SetDataSource(ds);
            crystalReportViewer1.ReportSource = rpt;
            Co.Close();
            this.ShowDialog();
        }
        public void StockBetweenDateReport(DateTime dtpFrom, DateTime dtpTo)
        {
            Connection cs = new Connection();
            SqlConnection Co = cs.GenaricConnection();
            ReportsOperation rptOperations = new ReportsOperation();
            dsPurchase ds = new dsPurchase();
            rptOperations.StockBetweenDateQuery(Co, ds, dtpFrom, dtpTo);
            rpt.Load(Path.Combine(Application.StartupPath, "Report", "rptStockBetweenDate.rpt"));
            rpt.SummaryInfo.ReportTitle = "Stock Report";
            rpt.SummaryInfo.ReportComments = "Sadar Bazar Jahanian";
            rpt.SummaryInfo.ReportAuthor = "From Date :" + dtpFrom + " To Date: " + dtpTo;
            rpt.SetDataSource(ds);
            crystalReportViewer1.ReportSource = rpt;
            Co.Close();
            this.ShowDialog();
        }

    }
}
  