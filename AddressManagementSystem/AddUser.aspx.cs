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
    public partial class AddUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if session variable is null, empty, or consists only of white-space characters.
            if (!string.IsNullOrWhiteSpace(Convert.ToString(Session["Name"])))
            {
                // Assign session variable to label in master page
                ((Site)this.Master).LblUserName = Convert.ToString(Session["Name"]);
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    // Load connection string from web.config file
                    string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                    // Create connection to SQL Server
                    using (SqlConnection con = new SqlConnection(CS))
                    {
                        // Create a command object
                        SqlCommand cmd = new SqlCommand("spAddUser", con);
                        // Set the command type as Stored procedure
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Create and add parameters to Parameters collection for the stored procedure.
                        cmd.Parameters.AddWithValue("@Name", txtName.Text);
                        cmd.Parameters.AddWithValue("@Age", txtAge.Text);
                        cmd.Parameters.AddWithValue("@DOB", txtDOB.Text);
                        cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                        cmd.Parameters.AddWithValue("@PhoneNo", txtPhoneNo.Text);
                        cmd.Parameters.AddWithValue("@UserId", Convert.ToInt32(Session["UserId"]));

                        // Open connection
                        con.Open();
                        // Run the SQL statement
                        int ReturnCode = (int)cmd.ExecuteScalar();
                        // Returns -1, if user name already exists in database
                        if (ReturnCode == -1)
                        {
                            // Display message that name already exists
                            lblMessage.ForeColor = System.Drawing.Color.Red;
                            lblMessage.Text = "Name already in use, please choose another user name";
                        }
                        else
                        {
                            // Clear the form
                            txtName.Text = "";
                            txtAge.Text = "";
                            txtDOB.Text = "";
                            txtAddress.Text = "";
                            txtEmail.Text = "";
                            txtPhoneNo.Text = "";

                            // Display message that registration is successful
                            lblMessage.ForeColor = System.Drawing.Color.Green;
                            lblMessage.Text = "Registered Successfully!!";
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception information to event viewer
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = ex.Message;
                }

            }
        }
    }
}