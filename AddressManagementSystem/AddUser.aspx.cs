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
        //protected void Page_PreInit(object sender, EventArgs e)
        //{
        //    List<string> EmailKeys = Request.Form.AllKeys.Where(key => key.Contains("txtEmail")).ToList();
        //    int i = 1;
        //    foreach (string key in EmailKeys)
        //    {
        //        this.CreateEmailTextBox("txtEmail" + i);
        //        i++;
        //    }
        //    List<string> PhoneKeys = Request.Form.AllKeys.Where(key => key.Contains("txtPhoneNo")).ToList();
        //    int j = 1;
        //    foreach (string key in PhoneKeys)
        //    {
        //        this.CreatePhoneTextBox("txtPhoneNo" + j);
        //        j++;
        //    }
        //}
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //protected void btnAddEmail_Click(object sender, EventArgs e)
        //{
        //    int index = pnlEmails.Controls.OfType<TextBox>().ToList().Count + 1;
        //    this.CreateEmailTextBox("txtEmail" + index);
        //}

        //private void CreateEmailTextBox(string id)
        //{
        //    TextBox txt = new TextBox();
        //    txt.ID = id;
        //    pnlEmails.Controls.Add(txt);

        //    Literal lt = new Literal();
        //    lt.Text = "<br />";
        //    pnlEmails.Controls.Add(lt);
        //}
        //protected void btnAddPhoneNo_Click(object sender, EventArgs e)
        //{
        //    int index = pnlPhoneNos.Controls.OfType<TextBox>().ToList().Count + 1;
        //    this.CreatePhoneTextBox("txtEmail" + index);
        //}

        //private void CreatePhoneTextBox(string id)
        //{
        //    TextBox txt = new TextBox();
        //    txt.ID = id;
        //    pnlPhoneNos.Controls.Add(txt);

        //    Literal lt = new Literal();
        //    lt.Text = "<br />";
        //    pnlPhoneNos.Controls.Add(lt);
        //}
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
                    int id = GetUserId();
                    SqlParameter userId = new SqlParameter("@UserId", id);
                    cmd.Parameters.Add(name);
                    cmd.Parameters.Add(age);
                    cmd.Parameters.Add(dob);
                    cmd.Parameters.Add(address);
                    cmd.Parameters.Add(email);
                    cmd.Parameters.Add(phoneNo);
                    cmd.Parameters.Add(userId);
                    //int countEmail = 0;
                    //int countPhoneNo = 0;
                    //foreach (TextBox textBox in pnlEmails.Controls.OfType<TextBox>())
                    //{
                    //    countEmail += 1;
                    //    SqlParameter email = new SqlParameter("@Email" + countEmail, textBox.Text);
                    //    cmd.Parameters.Add(email);
                    //}
                    //foreach (TextBox textBox in pnlPhoneNos.Controls.OfType<TextBox>())
                    //{
                    //    countPhoneNo += 1;
                    //    SqlParameter phoneNo = new SqlParameter("@PhoneNo" + countPhoneNo, textBox.Text);
                    //    cmd.Parameters.Add(phoneNo);
                    //}
                    con.Open();
                    int ReturnCode = (int)cmd.ExecuteScalar();
                    if (ReturnCode == -1)
                    {
                        lblMessage.Text = "Name already in use, please choose another user name";
                    }
                    else
                    {
                        Response.Redirect("~/Login.aspx");
                    }
                }
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