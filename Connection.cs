using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace POS
{
    public class Connection
    {
        public SqlConnection GenaricConnection()
        {
            string connectionString;

            //Ahmad Bhatti PC
           connectionString = "server=AHMAD-BHATTI;database=Shop;Integrated Security=True";

            //  Ali Bhatt PC
            //connectionString = "server=DESKTOP-V2407GU\\SQLEXPRESS;database=Shop;Integrated Security=True";


            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            return con;

        }
        public void createConnection(string Server, string Database, string ID, string Password)
        {
            Properties.Settings.Default["Server"] = Server;
            Properties.Settings.Default["Database"] = Database;
            Properties.Settings.Default["ID"] = ID;
            Properties.Settings.Default["Password"] = Password;
            Properties.Settings.Default.Save();
        }

    }
}


