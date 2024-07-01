using POS.Main;
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
using POS.Main;
using System.Web.UI.WebControls;

namespace POS
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                Connection cs = new Connection();
                SqlConnection Co = cs.GenaricConnection();
                Authentication login = new Authentication();
                string User = login.VerifyPassword(Co, txtUserName.Text, txtPassword.Text);
                if (User == "Clear")
                {
                    using (SqlCommand cmd1 = new SqlCommand("SELECT PhoneNo,Logintype,UserName FROM [User]  where UserName='" + txtUserName.Text + "'", Co))
                    {
                        SqlDataReader reader = cmd1.ExecuteReader();
                        if (reader.Read())
                        {
                            string userName = reader["UserName"].ToString();
                            string Userttype = reader["Logintype"].ToString();
                            string Phone = reader["PhoneNo"].ToString();

                            LoginInfo.UserName = userName;
                            LoginInfo.UserType = Userttype;
                            LoginInfo.PhoneNumber = Phone;
         
                        }
                        reader.Close();
                        LoginInfo.Rights = login.GetUserRights(Co, txtUserName.Text);
                    }



                    this.Hide();
                    Main.Main frm = new Main.Main();
                    frm.Show();


                }
                else
                {
                    MessageBox.Show("Invalid UserName or Password!", "Users",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUserName.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)

        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                txtPassword.Focus();
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode)
            {
                e.SuppressKeyPress = true;
                btnLogin.Focus();
            }
        }
        public static class LoginInfo
        {
            public static string UserName;
            public static string UserType;
            public static string PhoneNumber;
            public static List<string> Rights;
        }
    }
}
