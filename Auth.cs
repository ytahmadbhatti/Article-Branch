using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS
{
    public class Authentication
    {
        public string VerifyPassword(SqlConnection con, string UserName, string Password)
        {
            string login;
            SqlCommand cmd = new SqlCommand("Select UserPassword from [User] where UserName ='" + UserName + "' and isActive='1'", con);
          //  string DBPassword = cmd.ExecuteScalar().ToString();
            cmd.Parameters.AddWithValue("@UserName", UserName);

            object result = cmd.ExecuteScalar();
            if (result != null)
            {
                string DBPassword = result.ToString();

                if (Password == DBPassword)
                {
                    login = "Clear";
                }
                else
                {
                    login = "DeClear";
                }
            }
            else
            {
                login = "DeClear"; 
            }

            return login;
        }
        public List<string> GetUserRights(SqlConnection con, string UserName)
        {

            List<string> Rights = new List<string>();

            SqlCommand cmd = new SqlCommand("Select UserRights.Name from UserRights join User_Rights_junction on UserRights.ID=User_Rights_junction.Rightid Where User_Rights_junction.Userid = (Select ID from [User] where UserName='" + UserName + "')", con);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Rights.Add(reader.GetValue(0).ToString());
            }
            reader.Close();
            return Rights;
        }

    }

    }
