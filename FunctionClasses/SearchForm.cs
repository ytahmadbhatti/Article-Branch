using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static POS.Connection;

namespace POS.FunctionClasses
{
    public class SearchForm
    {
        public static string qry = "";
        private Connection cs = new Connection();
        private SqlConnection Co = null;
        private SqlCommand cmd = null;


        public DataTable SearchByID(int Code, string Table)
        {
            DataTable dataTable = new DataTable();
            try
            {
                Co = cs.GenaricConnection();
                if (Co.State != ConnectionState.Open)
                {
                    Co.Open();
                }
                if (Table == "PartyInfo")
                {
                    qry = @"select PartyCode,PartyName,Location,Contact  from " + Table.Trim() + "" + " where PartyCode='" + Code + "' and ISNULL(IsDeleted,0) =0  ";
                    cmd = new SqlCommand(qry, Co);
                    cmd.Parameters.AddWithValue("PartyCode", Code);
                }
                else if (Table == "ArticleInfo")
                {
                    qry = @"select Articlefrom " + Table.Trim() + "" + " where ArticleId='" + Code + "' and ISNULL(IsDeleted,0) =0  ";
                    cmd = new SqlCommand(qry, Co);
                    cmd.Parameters.AddWithValue("@Code", Code);
                }
                else if (Table == "[User]")
                {
                    qry = @"select ID,Name,PhoneNo,CNICNo,Logintype,UserName,UserPassword,isActive from " + Table.Trim() + "" + " where ID='" + Code + "' and ISNULL(IsActive,1) =1  ";
                    cmd = new SqlCommand(qry, Co);
                    cmd.Parameters.AddWithValue("@Code", Code);
                }
                else if (Table == "ExpenseCoding")
                {
                    qry = @"select ID,Type from " + Table.Trim() + "" + " where ID='" + Code + "' and ISNULL(IsDeleted,0) =0  ";
                    cmd = new SqlCommand(qry, Co);
                    cmd.Parameters.AddWithValue("@Code", Code);
                }
                else if (Table == "Expense")
                {
                    qry = @"select ID,Date, Purpose, Description,Amount from " + Table.Trim() + "" + " where ID='" + Code + "' and ISNULL(IsDeleted,0) =0  ";
                    cmd = new SqlCommand(qry, Co);
                    cmd.Parameters.AddWithValue("@Code", Code);
                }
                if (cmd != null)
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dataTable;
        }

        public DataTable SearchByCode(int Code, string Table)
        {
            DataTable dataTable = new DataTable();
            try
            {
                Co = cs.GenaricConnection();
                if (Co.State != ConnectionState.Open)
                {
                    Co.Open();
                }
                if (Table == "PartyInfo")
                {
                    qry = @"select PartyCode,PartyName,Contact  from " + Table.Trim() + " where PartyCode = '"+Code+"' and ISNULL(IsDeleted,0) =0  ";
                    cmd = new SqlCommand(qry, Co);
                    cmd.Parameters.AddWithValue("PartyCode", Code);
                }
                else if (Table == "ArticleInfo")
                {
                    qry = @"Select ArticleId,Article from  " + Table.Trim()+ " where ArticleId = '" + Code+"' and isnull(IsDeleted,0) =0 ";
                    cmd = new SqlCommand(qry, Co);
                    cmd.Parameters.AddWithValue("ProductInfo", Code);
                }
              

                if (cmd != null)
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dataTable;
        }


        public DataTable SearchByAricle(string Code, string Table)
        {
            DataTable dataTable = new DataTable();
            try
            {
                Co = cs.GenaricConnection();
                if (Co.State != ConnectionState.Open)
                {
                    Co.Open();
                }
              if (Table == "ArticleInfo")
                {
                    qry = @"Select ArticleId,Article from  " + Table.Trim() + " where Article = '" + Code + "' and isnull(IsDeleted,0) =0 ";
                    cmd = new SqlCommand(qry, Co);
                    cmd.Parameters.AddWithValue("ProductInfo", Code);
                }
                else if (Table == "PurchaseReturnDetail")
                {
                    qry = @"select Top (1) UnitPrice,Discount from PurchaseDetail where Article= '" + Code + "'  order by PurchaseDate desc";
                    cmd = new SqlCommand(qry, Co);
                    cmd.Parameters.AddWithValue("ProductInfo", Code);
                }
                else if (Table == "SaleReturnDetail")
                {
                    qry = @"select Top (1) SaleRate,Discount from SaleDetail where Article= '" + Code + "'";
                    cmd = new SqlCommand(qry, Co);
                    cmd.Parameters.AddWithValue("ProductInfo", Code);
                }
                if (cmd != null)
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dataTable;
        }



    }
}
