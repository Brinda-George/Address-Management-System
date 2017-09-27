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
            // Load connection string from web.config file
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            // Create connection to SQL Server
            using (SqlConnection con = new SqlConnection(CS))
            {
                // Create a command object and provide stored procedure name
                SqlCommand cmd = new SqlCommand("spAuthenticateUser", con);

                // Set the command type as Stored procedure
                cmd.CommandType = CommandType.StoredProcedure;

                //Produces a hash password based on the specified password and hash algorithm SHA1
                string EncryptedPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(password, "SHA1");

                // Create and add parameters to Parameters collection for the stored procedure.
                cmd.Parameters.AddWithValue("@UserName", username);
                cmd.Parameters.AddWithValue("@Password", EncryptedPassword);

                // Open database connection
                con.Open();

                // Execute the SQL statement
                int ReturnCode = (int)cmd.ExecuteScalar();

                // Returns 1 if user is authenticated
                // Return true if ReturnCode is 1 else false
                return ReturnCode == 1;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (AuthenticateUser(txtUserName.Text, txtPassword.Text))
                {
                    // Get current session object
                    Session["Name"] = txtUserName.Text;
                    Session["UserId"] = GetUserId();

                    // Create the authentication cookie and redirect the user to home page
                    FormsAuthentication.RedirectFromLoginPage(txtUserName.Text, chkBoxRememberMe.Checked);
                }
                else
                {
                    lblMessage.Text = "Invalid User Name and/or Password";
                }
            }
            catch (Exception ex)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = ex.Message;
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