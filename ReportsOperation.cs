using System;
using System.Data.SqlClient;
using System.Data;

namespace POS
{ 
    public class ReportsOperation
    {
        public void PurchaseInvQuery(SqlConnection con, DataSet dsPurchase, string purchaseInv)
        {
            SqlDataAdapter adp = new SqlDataAdapter(@"SELECT  PM.PurchaseId,PM.PurchaseDate, PM.SaleMen
      ,PM.PartyCode,PM.PartyName,PM.TotalAmount,PD.PurchaseDetailId,PD.Article
      ,PD.[Pair],PD.[Rate],PD.[Discount],PD.NetAmount,PD.UnitPrice
       FROM PurchaseMaster PM inner join PurchaseDetail PD on PD.PurchaseId=PM.PurchaseId  
       where PM.PurchaseId='" + purchaseInv + "'", con);
            adp.Fill(dsPurchase, "PurchaseInv");
        }
        public void PurchaseReturnInvQuery(SqlConnection con, DataSet dsWeight, string purchaseReturnInv)
        {
            SqlDataAdapter adp = new SqlDataAdapter(@"SELECT  PRM.PurchaseReturnId,PRM.PurchaseReturnDate
      ,PRM.SaleMan ,PRM.PartyCode,PRM.PartyName,PRM.TotalAmount, PRD.PurchaseReturnDetailId,
      PRD.Article,PRD.PurchaseRate,PRD.ReturnQuantity,PRD.NetAmount,PRD.Discount FROM PurchaseReturnMaster PRM
       inner join PurchaseReturnDetail PRD on PRD.PurchaseReturnId= PRM.PurchaseReturnId
       where PRM.PurchaseReturnId='" + purchaseReturnInv + "'", con);
            adp.Fill(dsWeight, "PurchaseReturnInv");
        }
        public void PurchaseInvBetweenDateQuery(SqlConnection con, DataSet dsPurchase, DateTime dtpFrom, DateTime dtpTo)
        {
            SqlDataAdapter adp = new SqlDataAdapter(@"SELECT  PM.PurchaseId,PM.PurchaseDate, PM.SaleMen
      ,PM.PartyCode,PM.PartyName,PM.TotalAmount,PD.PurchaseDetailId
      ,PD.Article,PD.Pair,PD.Rate,PD.NetAmount,PD.Discount,PD.UnitPrice
       FROM PurchaseMaster PM inner join PurchaseDetail PD on PD.PurchaseId=PM.PurchaseId 
       where PM.PurchaseDate between '" + dtpFrom + "' and '" + dtpTo + "' order by PM.PurchaseDate desc", con);
            adp.Fill(dsPurchase, "PurchaseInv");
        }
        public void SaleInvBetweenDateQuery(SqlConnection con, DataSet dsPurchase, DateTime dtpFrom, DateTime dtpTo)
        {
            SqlDataAdapter adp = new SqlDataAdapter(@"SELECT  SM.SaleId,SM.SaleDate, SM.SaleMan
      ,SM.PartyCode,SM.PartyName,SM.TotalAmount,SD.SaleDetailId
      ,SD.Article,SD.SaleRate,SD.Pair,SD.NetAmount,SD.Discount,SD.TotalSaleRate
       FROM SaleMaster SM inner join SaleDetail SD on SD.SaleId=SM.SaleId  
       where SM.SaleDate between '" + dtpFrom + "' and '" + dtpTo + "' order by SM.SaleDate desc", con);
            adp.Fill(dsPurchase, "SaleInv");
        }
        public void PurchaseReturnInvBetweenDateQuery(SqlConnection con, DataSet dsPurchase, DateTime dtpFrom, DateTime dtpTo)
        {
            SqlDataAdapter adp = new SqlDataAdapter(@"SELECT  PRM.PurchaseReturnId,PRM.PurchaseReturnDate, PRM.SaleMan
      ,PRM.PartyCode,PRM.PartyName,PRM.TotalAmount,PRD.PurchaseReturnDetailId
      ,PRD.Article,PRD.PurchaseRate,PRD.ReturnQuantity,PRD.NetAmount,PRD.Discount
       FROM PurchaseReturnMaster PRM inner join PurchaseReturnDetail PRD on PRD.PurchaseReturnId=PRM.PurchaseReturnId
       where PRM.PurchaseReturnDate between '" + dtpFrom + "' and '" + dtpTo + "' order by PRM.PurchaseReturnDate desc", con);
            adp.Fill(dsPurchase, "PurchaseReturnInv");
        }
        public void SaleInvQuery(SqlConnection con, DataSet dsPurchase, string saleInv)
        {
            SqlDataAdapter adp = new SqlDataAdapter(@"SELECT SM.SaleId,SM.SaleDate,SM.SaleMan
      ,SM.PartyCode,SM.PartyName,SM.TotalAmount,SD.SaleDetailId,SD.Article
      ,SD.Pair,SD.SaleRate,SD.NetAmount,isnull(SD.Discount,0) as  Discount FROM SaleMaster SM
      inner join SaleDetail SD on SD.SaleId= SM.SaleId where SM.SaleId='" + saleInv + "' ", con);
            adp.Fill(dsPurchase, "SaleInv");
        }
        public void SaleReturnInvQuery(SqlConnection con, DataSet dsPurchase, string saleReturnInv)
        {
            SqlDataAdapter adp = new SqlDataAdapter(@"SELECT SRM.SaleReturnId,SRM.SaleReturnDate,SRM.SaleMan
      ,SRM.PartyCode,SRM.PartyName,SRM.TotalAmount,SRD.SaleReturnDetailId,SRD.Article
      ,SRD.ReturnQuantity,SRD.SaleRate,SRD.NetAmount,SRD.Discount FROM SaleReturnMaster SRM
      inner join SaleReturnDetail SRD on SRD.SaleReturnId= SRM.SaleReturnId where SRM.SaleReturnId='" + saleReturnInv + "' ", con);
            adp.Fill(dsPurchase, "SaleReturnInv");
        }
        public void CashBookBetweenDateQuery(SqlConnection con, DataSet dsPurchase, DateTime dtpFrom, DateTime dtpTo)
        {
            SqlDataAdapter adp = new SqlDataAdapter(@"select SD.SaleId as ID ,SD.saledate as Date ,SD.NetAmount as DrAmount,0 as CrAmount, SM.PartyName from SaleDetail SD
inner join SaleMaster SM on SM.SaleId=SD.SaleId
Union All
select SRD.SaleReturnId as ID ,SRD.SaleReturnDate as Date ,0 as DrAmount,SRD.NetAmount as CrAmount,SRM.PartyName from SaleReturnDetail SRD
inner join SaleReturnMaster SRM on SRM.SaleReturnId=SRD.SaleReturnId 
Union All
SELECT  CAST(CONCAT('Exp', ID) AS NVARCHAR(50)) AS ID,Date, 0 AS DrAmount, Amount AS CrAmount,Purpose as Party FROM  Expense
Union All
SELECT  CAST(CONCAT('VI', V.VoucherID) AS NVARCHAR(50)) AS ID,V.VoucherDate as Date, 0 AS DrAmount, V.Amount AS CrAmount,P.PartyName FROM  Voucher V
inner join PartyInfo P on P.PartyCode=V.PartyID
       where DateTime between '" + dtpFrom + "' and '" + dtpTo + "' order by date", con);
            adp.Fill(dsPurchase, "CashBook");
        }
        public void StockBetweenDateQuery(SqlConnection con, DataSet dsPurchase, DateTime dtpFrom, DateTime dtpTo)
        {
            SqlCommand cmd = new SqlCommand("GetStockCalculations", con);
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FromDate", dtpFrom);
                cmd.Parameters.AddWithValue("@ToDate", dtpTo);

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dsPurchase, "StockCalculations");
            }
            finally
            {
                cmd.Dispose();
            }
        }


    }
}
