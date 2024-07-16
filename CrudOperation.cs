using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS
{
    public class CrudOperation
    {
        public DataTable GetAllRights(SqlConnection con)
        {
            SqlCommand cmd = new SqlCommand("Select * from UserRights", con);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);

            return dt;
        }
        public DataTable GetthisUserRights(SqlConnection con, int UserCode)
        {
            SqlCommand cmd = new SqlCommand("Select Rightid from User_Rights_junction where Userid=" + UserCode + "", con);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            reader.Close();
            return dt;
        }

        public bool CheckName(SqlConnection con, string Table, string name)
        {
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            if (Table == "Partynfo")
            {
                SqlCommand cmd = new SqlCommand("Select PartyName from PartyInfo where PartyName='" + name + "'and IsDeleted != 1", con);
                string Name = Convert.ToString(cmd.ExecuteScalar());
                if (Name == "" || Name == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else if (Table == "ArticleInfo")
            {
                    SqlCommand cmd = new SqlCommand("Select Article from ArticleInfo where Article='" + name + "'and IsDeleted != 1", con);
                    string Name = Convert.ToString(cmd.ExecuteScalar());
                    if (Name == "" || Name == null)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
            }
            else if (Table == "SizeInfo")
            {
                SqlCommand cmd = new SqlCommand("Select Size from SizeInfo where Size='" + name + "'and IsDeleted != 1", con);
                string Name = Convert.ToString(cmd.ExecuteScalar());
                if (Name == "" || Name == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else if (Table == "[User]")
            {
                SqlCommand cmd = new SqlCommand("Select UserName from [User] where UserName='" + name + "'and IsActive != 0", con);
                string Name = Convert.ToString(cmd.ExecuteScalar());
                if (Name == "" || Name == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else if (Table == "ExpenseCoding")
            {
                SqlCommand cmd = new SqlCommand("Select Type from ExpenseCoding where " +
                    "Type='" + name + "'and IsDeleted != 1", con);
                string Name = Convert.ToString(cmd.ExecuteScalar());
                if (Name == "" || Name == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return true;
        }
        public string GetMaxIdentity(SqlConnection con, string Table)
        {
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*)+1 as MaxID FROM " + Table + " ", con);
            string Name = Convert.ToString(cmd.ExecuteScalar());
            if (Name == "" || Name == null)
            {
                return "1";
            }
            else
            {
                return Name;
            }
        }


        public string GetPartyIdData(SqlConnection con, string Table)
        {
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("Select PartyCode from PartyInfo where IsDeleted =0 and partyname='"+Table+"' order by PartyCode", con);
            string Name = Convert.ToString(cmd.ExecuteScalar());
            if (Name == "" || Name == null)
            {
                return "1";
            }
            else
            {
                return Name;
            }
        }


        public string GetPartyNameData(SqlConnection con, string Table)
        {
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("Select partyname from PartyInfo where IsDeleted =0 and partyname='" + Table + "' order by PartyCode", con);
            string Name = Convert.ToString(cmd.ExecuteScalar());
            if (Name == "" || Name == null)
            {
                return "1";
            }
            else
            {
                return Name;
            }
        }



        public DataTable GetPartyInfoData(SqlConnection con)
        {
            SqlCommand cmd = new SqlCommand("Select PartyCode,PartyName,Location,Contact  from PartyInfo where IsDeleted =0 order by PartyCode", con);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            return dt;
        }
       
        public DataTable GetUserInfoData(SqlConnection con)
        {
            SqlCommand cmd = new SqlCommand("Select ID, Name, PhoneNo, CNICNo, Logintype, UserName, UserPassword, isActive from [User] where isActive =1 order by ID", con);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);

            return dt;
        }
        public DataTable GetArticleInfoData(SqlConnection con)
        {
            SqlCommand cmd = new SqlCommand("Select ArticleId,Article  from ArticleInfo where IsDeleted =0 order by ArticleId", con);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);

            return dt;
        }
        public DataTable GetPurchaseData(SqlConnection con)
        {
            SqlCommand cmd = new SqlCommand(@"SELECT PurchaseId,PurchaseDate,SaleMen,PartyCode,
            PartyName,TotalAmount FROM PurchaseMaster order by PurchaseDate desc", con);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            return dt;
        }
        public DataTable GetPurchaseReturnData(SqlConnection con)
        {
            SqlCommand cmd = new SqlCommand(@"SELECT PurchaseReturnId,PurchaseReturnDate,
         SaleMan,PartyCode,PartyName,TotalAmount FROM PurchaseReturnMaster order by 
         PurchaseReturnId desc", con);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            return dt;
        }

        public DataTable GetSaleReturnData(SqlConnection con)
        {
            SqlCommand cmd = new SqlCommand(@"SELECT  SaleReturnId,SaleReturnDate,SaleMan,PartyCode
      ,PartyName,TotalAmount FROM SaleReturnMaster order by SaleReturnDate desc", con);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            return dt;
        }

        public DataTable GetSaleData(SqlConnection con)
        {
            SqlCommand cmd = new SqlCommand(@"SELECT SaleId,SaleDate,SaleMan,PartyCode,
            PartyName,TotalAmount FROM SaleMaster order by SaleDate desc", con);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            return dt;
        }
        public DataTable GetSizeInfoData(SqlConnection con)
        {
            SqlCommand cmd = new SqlCommand("Select SizeCode,Size from SizeInfo where IsDeleted =0 order by SizeCode", con);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);

            return dt;
        }

        public DataTable GetExpenseCodingData(SqlConnection con)
        {
            SqlCommand cmd = new SqlCommand("Select ID,Type from ExpenseCoding where IsDeleted =0 order by ID", con);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            return dt;
        }

        public DataTable GetExpenseData(SqlConnection con)
        {
            SqlCommand cmd = new SqlCommand("Select ID,Date, Purpose, Description from Expense where IsDeleted =0 order by ID", con);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            return dt;
        }

        public DataTable GetPartyPaymentData(SqlConnection con)
        {
            SqlCommand cmd = new SqlCommand("Select VoucherID,VoucherDate, PartyID, Amount, Discritipn from Vouchers where IsDeleted =0 order by VoucherID", con);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            return dt;
        }

        public void InsertUpdatePartyInfo(SqlConnection Con, int partyCode, string PartyName, string Location,
            string Contact, bool IsUpdate)
        {
            SqlCommand cmd = new SqlCommand("InsertUpdateParty", Con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PartyCode", SqlDbType.Int).Value = partyCode;
            cmd.Parameters.Add("@PartyName", SqlDbType.NVarChar).Value = PartyName;
            cmd.Parameters.Add("@Location", SqlDbType.NVarChar).Value = Location;
            cmd.Parameters.Add("@Contact", SqlDbType.NVarChar).Value = Contact;
            cmd.Parameters.Add("@DateTime", SqlDbType.DateTime).Value = DateTime.Now;
            cmd.Parameters.Add("@IsUpdate", SqlDbType.Bit).Value = IsUpdate;
            cmd.ExecuteNonQuery();
        }
        public void InsertUpdateArticleInfo(SqlConnection Con, int articleId, string article, bool IsUpdate)
        {
            SqlCommand cmd = new SqlCommand("InsertUpdateArticle", Con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ArticleId", SqlDbType.Int).Value = articleId;
            cmd.Parameters.Add("@Article", SqlDbType.NVarChar).Value = article;
            cmd.Parameters.Add("@IsUpdate", SqlDbType.Bit).Value = IsUpdate;
            cmd.ExecuteNonQuery();
        }
        public void DeletePartyInfo(SqlConnection Con, int partyCode)
        {
            SqlCommand cmd = new SqlCommand("DeleteParty", Con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PartyCode", SqlDbType.Int).Value = partyCode;
            cmd.Parameters.Add("@IsDelete", SqlDbType.Bit).Value = 1;
            cmd.ExecuteNonQuery();
        }
        public void DeletePurchaseInv(SqlConnection Con, string PurchaseInv)
        {
            SqlCommand cmd = new SqlCommand("DeletePurchaseInv", Con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PurchaseInv", SqlDbType.NVarChar).Value = PurchaseInv;
            cmd.ExecuteNonQuery();
        }
        public void DeleteSaleInv(SqlConnection Con, string saleInv)
        {
            SqlCommand cmd = new SqlCommand("DeleteSaleInv", Con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SaleInv", SqlDbType.NVarChar).Value = saleInv;
            cmd.ExecuteNonQuery();
        }
        public string GetStock(SqlConnection Con, string Article)
        {
            string stockInHand = "0";
            SqlCommand cmd = new SqlCommand("GetStockInHand", Con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Article", SqlDbType.NVarChar).Value = Article;
            
            object result =  cmd.ExecuteScalar();
            if (result != null && result != DBNull.Value)
            {
                stockInHand = result.ToString();
            }
            return stockInHand;
        }

        public string GetSalePrice(SqlConnection Con, string Article)
        {
            string SaleRate = "0";
            SqlCommand cmd = new SqlCommand("Select top 1 UnitPrice from PurchaseDetail where article= '" + Article+"' order by PurchaseDate desc", Con);
            object result = cmd.ExecuteScalar();
            if (result != null && result != DBNull.Value)
            {
                SaleRate = result.ToString();
            }
            return SaleRate;
        }

        public void DeletePurchaseReturnInv(SqlConnection Con, string PurchaseRetuenInv)
        {
            SqlCommand cmd = new SqlCommand("DeletePurchaseReturnInv", Con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PurchaseReturnInv", SqlDbType.NVarChar).Value = PurchaseRetuenInv;
            cmd.ExecuteNonQuery();
        }
        public void DeleteProductInfo(SqlConnection Con, int productCode)
        {
            SqlCommand cmd = new SqlCommand("DeleteProduct", Con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ProductCode", SqlDbType.Int).Value = productCode;
            cmd.Parameters.Add("@IsDelete", SqlDbType.Bit).Value = 1;
            cmd.ExecuteNonQuery();
        }
        public void InsertPurchaseMaster(SqlConnection Con, string purchaseInv, DateTime dtpInv, string saleMan, int partyCode, string PartyName,
             decimal TotalAmount,bool isUpdate)
        {
            SqlCommand cmd = new SqlCommand("InsertUpdatePurchaeMaster", Con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PurchaseInv", SqlDbType.NVarChar).Value = purchaseInv;
            cmd.Parameters.Add("@dtpInv", SqlDbType.DateTime).Value = dtpInv;
            cmd.Parameters.Add("@SaleMan", SqlDbType.VarChar).Value = saleMan;
            cmd.Parameters.Add("@PartyCode", SqlDbType.Int).Value = partyCode;
            cmd.Parameters.Add("@PartyName", SqlDbType.NVarChar).Value = PartyName;
            cmd.Parameters.Add("@TotalAmount", SqlDbType.Float).Value = TotalAmount;
            cmd.Parameters.Add("@IsUpdate", SqlDbType.Bit).Value = isUpdate;
            cmd.ExecuteNonQuery();
        }

        public void DeleteStock(SqlConnection Con, string PurchsaseInv)
        {
            SqlCommand cmd = new SqlCommand("DeleteStock", Con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", SqlDbType.NVarChar).Value = PurchsaseInv;
            cmd.ExecuteNonQuery();
        }
        

        public void InsertSaleMaster(SqlConnection Con, string saleInv, DateTime dtpInv, string saleMan, int partyCode, string PartyName,
        Int64 TotalAmount, bool isUpdate)
        {
            SqlCommand cmd = new SqlCommand("InsertUpdateSaleMaster", Con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SaleInv", SqlDbType.NVarChar).Value = saleInv;
            cmd.Parameters.Add("@dtpInv", SqlDbType.DateTime).Value = dtpInv;
            cmd.Parameters.Add("@SaleMan", SqlDbType.VarChar).Value = saleMan;
            cmd.Parameters.Add("@PartyCode", SqlDbType.Int).Value = partyCode;
            cmd.Parameters.Add("@PartyName", SqlDbType.NVarChar).Value = PartyName;
            cmd.Parameters.Add("@TotalAmount", SqlDbType.Float).Value = TotalAmount;
            cmd.Parameters.Add("@IsUpdate", SqlDbType.Bit).Value = isUpdate;
            cmd.ExecuteNonQuery();
        }



        public void InsertUpdateSizeInfo(SqlConnection Con, int sizeId, string size, bool IsUpdate)
        {
            SqlCommand cmd = new SqlCommand("InsertUpdateSize", Con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SizeCode", SqlDbType.Int).Value = sizeId;
            cmd.Parameters.Add("@Size", SqlDbType.NVarChar).Value = size;
            cmd.Parameters.Add("@IsUpdate", SqlDbType.Bit).Value = IsUpdate;
            cmd.ExecuteNonQuery();
        }
        public void DeleteSizeInfo(SqlConnection Con, int sizeCode)
        {
            SqlCommand cmd = new SqlCommand("DeleteSize", Con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SizeCode", SqlDbType.Int).Value = sizeCode;
            cmd.Parameters.Add("@IsDelete", SqlDbType.Bit).Value = 1;
            cmd.ExecuteNonQuery();
        }
        public void InsertPurchaseReturnMaster(SqlConnection Con, string purchaseReturnInv, DateTime dtpInv, string saleMan, int partyCode, string PartyName,
           Int64 TotalAmount, bool isUpdate)
        {
            SqlCommand cmd = new SqlCommand("InsertUpdatePurchaeReturnMaster", Con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PurchaseReturnId", SqlDbType.NVarChar).Value = purchaseReturnInv;
            cmd.Parameters.Add("@dtpInv", SqlDbType.DateTime).Value = dtpInv;
            cmd.Parameters.Add("@SaleMan", SqlDbType.VarChar).Value = saleMan;
            cmd.Parameters.Add("@PartyCode", SqlDbType.Int).Value = partyCode;
            cmd.Parameters.Add("@PartyName", SqlDbType.NVarChar).Value = PartyName;
            cmd.Parameters.Add("@TotalAmount", SqlDbType.Float).Value = TotalAmount;
            cmd.Parameters.Add("@IsUpdate", SqlDbType.Bit).Value = isUpdate;
            cmd.ExecuteNonQuery();
        }
        public void InsertSaleReturnMaster(SqlConnection Con, string purchaseReturnInv, DateTime dtpInv, string saleMan, int partyCode, string PartyName,
          Int64 TotalAmount, bool isUpdate)
        {
            SqlCommand cmd = new SqlCommand("InsertUpdateSaleReturnMaster", Con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SaleReturnId", SqlDbType.NVarChar).Value = purchaseReturnInv;
            cmd.Parameters.Add("@dtpInv", SqlDbType.DateTime).Value = dtpInv;
            cmd.Parameters.Add("@SaleMan", SqlDbType.VarChar).Value = saleMan;
            cmd.Parameters.Add("@PartyCode", SqlDbType.Int).Value = partyCode;
            cmd.Parameters.Add("@PartyName", SqlDbType.NVarChar).Value = PartyName;
            cmd.Parameters.Add("@TotalAmount", SqlDbType.Float).Value = TotalAmount;
            cmd.Parameters.Add("@IsUpdate", SqlDbType.Bit).Value = isUpdate;
            cmd.ExecuteNonQuery();
        }
        public void InsertUpdateUserInfo(SqlConnection Con, int userid, string name, string phoneno, string cnicno,
         string logintype, string username, string userpassword, bool isactive, List<int> UserRights, bool isUpdate)
        {
            SqlCommand cmd = new SqlCommand("InsertUpdateUser", Con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@UserID", SqlDbType.NVarChar).Value = userid;
            cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = name;
            cmd.Parameters.Add("@CreationDate", SqlDbType.DateTime).Value = DateTime.Now;
            cmd.Parameters.Add("@PhoneNo", SqlDbType.NVarChar).Value = phoneno;
            cmd.Parameters.Add("@CNIC", SqlDbType.NVarChar).Value = cnicno;
            cmd.Parameters.Add("@LoginType", SqlDbType.NVarChar).Value = logintype;
            cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = username;
            cmd.Parameters.Add("@UserPassword", SqlDbType.NVarChar).Value = userpassword;
            cmd.Parameters.Add("@Active", SqlDbType.Bit).Value = isactive;
            cmd.Parameters.Add("@IsUpdate", SqlDbType.Bit).Value = isUpdate;
            cmd.ExecuteNonQuery();

            SqlCommand cmdDelete = new SqlCommand("Delete from User_Rights_junction where Userid=" + userid + "", Con);
            cmdDelete.ExecuteNonQuery();

            foreach (int right in UserRights)
            {
                SqlCommand cmdNew = new SqlCommand("Insert into User_Rights_junction Values(" + userid + "," + right + ")", Con);
                cmdNew.ExecuteNonQuery();
            }
        }
        public void DeleteUserInfo(SqlConnection Con, int userid)
        {
            SqlCommand cmd = new SqlCommand("DeleteUser", Con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = userid;
            cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = 0;
            cmd.ExecuteNonQuery();
        }

        public void InsertUpdateExpenseCoding(SqlConnection Con, int Id, string type, bool IsUpdate)
        {
            SqlCommand cmd = new SqlCommand("InsertUpdateExpenseCoding", Con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = Id;
            cmd.Parameters.Add("@Type", SqlDbType.NVarChar).Value = type;
            cmd.Parameters.Add("@IsUpdate", SqlDbType.Bit).Value = IsUpdate;
            cmd.ExecuteNonQuery();
        }

        public void DeleteExpenseCoding(SqlConnection Con, int id)
        {
            SqlCommand cmd = new SqlCommand("DeleteExpenseCoding", Con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@IsDelete", SqlDbType.Bit).Value = 1;
            cmd.ExecuteNonQuery();
        }

        public void InsertUpdateExpense(SqlConnection Con, int Id, DateTime date, string purpose, string description, decimal amount,bool IsUpdate)
        {
            SqlCommand cmd = new SqlCommand("InsertUpdateExpense", Con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = Id;
            cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = date;
            cmd.Parameters.Add("@Purpose", SqlDbType.NVarChar).Value = purpose;
            cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = description;
            cmd.Parameters.Add("@Amount", SqlDbType.Decimal).Value = amount;
            cmd.Parameters.Add("@IsUpdate", SqlDbType.Bit).Value = IsUpdate;
            cmd.ExecuteNonQuery();
        }
        public void DeleteExpense(SqlConnection Con, int id)
        {
            SqlCommand cmd = new SqlCommand("DeleteExpense", Con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@IsDelete", SqlDbType.Bit).Value = 1;
            cmd.ExecuteNonQuery();
        }

        public string CalculatePendingAmount(SqlConnection Con, string partycode)
        {
            string pendingamount = "0";
            SqlCommand cmd = new SqlCommand("CalculateDifference", Con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PartyCode", SqlDbType.NVarChar).Value = partycode;

            object result = cmd.ExecuteScalar();
            if (result != null && result != DBNull.Value)
            {
                pendingamount = result.ToString();
            }
            return pendingamount;
        }
    }
}
