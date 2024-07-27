using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
       where PM.PurchaseId='" + purchaseInv+"'", con);
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
      ,PM.PartyCode,PM.PartyName,PM.TotalAmount,PD.PurchaseDetailId,PD.ProductCode
      ,PD.ProductName,PD.SaleRate,PD.Quantity,PD.Rate,PD.NetAmount,PD.Size
       FROM PurchaseMaster PM inner join PurchaseDetail PD on PD.PurchaseId=PM.PurchaseId 
       where PM.PurchaseDate between '" + dtpFrom + "' and '"+dtpTo+ "' order by PM.PurchaseDate desc", con);
            adp.Fill(dsPurchase, "PurchaseInv");
        }
        public void SaleInvBetweenDateQuery(SqlConnection con, DataSet dsPurchase, DateTime dtpFrom, DateTime dtpTo)
        {
            SqlDataAdapter adp = new SqlDataAdapter(@"SELECT  SM.SaleId,SM.SaleDate, SM.SaleMan
      ,SM.PartyCode,SM.PartyName,SM.TotalAmount,SD.SaleDetailId,SD.ProductCode
      ,SD.ProductName,SD.SaleRate,SD.Quantity,SD.NetAmount,SD.Size
       FROM SaleMaster SM inner join SaleDetail SD on SD.SaleId=SM.SaleId 
       where SM.SaleDate between '" + dtpFrom + "' and '" + dtpTo + "' order by SM.SaleDate desc", con);
            adp.Fill(dsPurchase, "SaleInv");
        }
        public void PurchaseReturnInvBetweenDateQuery(SqlConnection con, DataSet dsPurchase, DateTime dtpFrom, DateTime dtpTo)
        {
            SqlDataAdapter adp = new SqlDataAdapter(@"SELECT  PRM.PurchaseReturnId,PRM.PurchaseReturnDate, PRM.SaleMan
      ,PRM.PartyCode,PRM.PartyName,PRM.TotalAmount,PRD.PurchaseReturnDetailId,PRD.ProductCode
      ,PRD.ProductName,PRD.PurchaseRate,PRD.ReturnQuantity,PRD.NetAmount,PRD.Size
       FROM PurchaseReturnMaster PRM inner join PurchaseReturnDetail PRD on PRD.PurchaseReturnId=PRM.PurchaseReturnId 
       where PRM.PurchaseReturnDate between '" + dtpFrom + "' and '" + dtpTo + "' order by PRM.PurchaseReturnDate desc", con);
            adp.Fill(dsPurchase, "PurchaseReturnInv");
        }
        public void SaleInvQuery(SqlConnection con, DataSet dsPurchase, string saleInv)
        {
            SqlDataAdapter adp = new SqlDataAdapter(@"SELECT SM.SaleId,SM.SaleDate,SM.SaleMan
      ,SM.PartyCode,SM.PartyName,SM.TotalAmount,SD.SaleDetailId,SD.Article
      ,SD.Pair,SD.SaleRate,SD.NetAmount FROM SaleMaster SM
      inner join SaleDetail SD on SD.SaleId= SM.SaleId where SM.SaleId='" + saleInv+"' ", con);
            adp.Fill(dsPurchase, "SaleInv");
        }
    }
}
