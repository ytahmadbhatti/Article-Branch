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

    }
}
  