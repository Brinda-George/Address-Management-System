using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AddressManagementSystem
{
    public partial class AddUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Convert.ToString(Session["Name"])))
            {
                ((Site)this.Master).LblUserName = Convert.ToString(Session["Name"]);
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("spAddUser", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter name = new SqlParameter("@Name", txtName.Text);
                    SqlParameter age = new SqlParameter("@Age", txtAge.Text);
                    SqlParameter dob = new SqlParameter("@DOB", txtDOB.Text);
                    SqlParameter address = new SqlParameter("@Address", txtAddress.Text);
                    SqlParameter email = new SqlParameter("@Email", txtEmail.Text);
                    SqlParameter phoneNo = new SqlParameter("@PhoneNo", txtPhoneNo.Text);
                    int id = Convert.ToInt32(Session["UserId"]);
                    SqlParameter userId = new SqlParameter("@UserId", id);

                    cmd.Parameters.Add(name);
                    cmd.Parameters.Add(age);
                    cmd.Parameters.Add(dob);
                    cmd.Parameters.Add(address);
                    cmd.Parameters.Add(email);
                    cmd.Parameters.Add(phoneNo);
                    cmd.Parameters.Add(userId);

                    con.Open();
                    int ReturnCode = (int)cmd.ExecuteScalar();
                    if (ReturnCode == -1)
                    {
                        lblMessage.Text = "Name already in use, please choose another user name";
                    }
                    else
                    {
                        txtName.Text = "";
                        txtAge.Text = "";
                        txtDOB.Text = "";
                        txtAddress.Text = "";
                        txtEmail.Text = "";
                        txtPhoneNo.Text = "";
                        lblMessage.Text = "Registered Successfully!!";
                    }
                }
            }
        }
        
    }
}