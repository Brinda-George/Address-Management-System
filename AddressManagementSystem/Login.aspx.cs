using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AddressManagementSystem
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        private bool AuthenticateUser(string username, string password)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spAuthenticateUser", con);
                cmd.CommandType = CommandType.StoredProcedure;

                string EncryptedPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(password, "SHA1");
                SqlParameter paramUsername = new SqlParameter("@UserName", username);
                SqlParameter paramPassword = new SqlParameter("@Password", EncryptedPassword);

                cmd.Parameters.Add(paramUsername);
                cmd.Parameters.Add(paramPassword);

                con.Open();
                int ReturnCode = (int)cmd.ExecuteScalar();
                return ReturnCode == 1;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (AuthenticateUser(txtUserName.Text, txtPassword.Text))
            {
                Session["Name"] = txtUserName.Text;
                Session["UserId"] = GetUserId();
                FormsAuthentication.RedirectFromLoginPage(txtUserName.Text, chkBoxRememberMe.Checked);
            }
            else
            {
                lblMessage.Text = "Invalid User Name and/or Password";
            }
        }
        protected int GetUserId()
        {
            int id;
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con1 = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spGetUserIdByUserName", con1);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter name = new SqlParameter("@UserName", Session["Name"].ToString());
                cmd.Parameters.Add(name);
                con1.Open();
                id = (int)cmd.ExecuteScalar();
            }
            return id;
        }
    }
}