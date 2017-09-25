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
    public partial class ViewUserDetails : System.Web.UI.Page
    {
        string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        static string editName;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Convert.ToString(Session["Name"])))
            {
                ((Site)this.Master).LblUserName = Convert.ToString(Session["Name"]);
                if (!IsPostBack)
                {
                    BindData();
                }
            }
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (GridViewUser.SelectedRow == null)
            {
                DetailsViewUser.Visible = false;
                btnPrint.Visible = false;
            }
            else
            {
                DetailsViewUser.Visible = true;
                btnPrint.Visible = true;
            }
        }
        private void BindData()
        {
            SqlConnection con = new SqlConnection(CS);
            SqlDataAdapter da = new SqlDataAdapter("spGetUserDetailsbyUserId", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter userId = new SqlParameter();
            userId.ParameterName = "@UserId";
            userId.Value = Session["UserId"];
            da.SelectCommand.Parameters.Add(userId);

            DataSet DS = new DataSet();
            da.Fill(DS);
            GridViewUser.DataSource = DS;
            GridViewUser.DataBind();
            con.Close();
        }
        protected void GridViewUser_RowEditing(object sender, GridViewEditEventArgs e)
        {
            editName = GridViewUser.Rows[e.NewEditIndex].Cells[0].Text;
            GridViewUser.EditIndex = e.NewEditIndex;
            BindData();
        }
        protected void GridViewUser_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewUser.EditIndex = -1;
            BindData();
        }
        protected void GridViewUser_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string name = GridViewUser.Rows[e.RowIndex].Cells[0].Text;
                SqlConnection con = new SqlConnection(CS);
                SqlDataAdapter da = new SqlDataAdapter("spDeleteUser", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter username = new SqlParameter("@Name", name);
                da.SelectCommand.Parameters.Add(username);
                con.Open();
                da.SelectCommand.ExecuteScalar();
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Server.Transfer("ViewUserDetails.aspx");
            }
            BindData();
        }
        protected void GridViewUser_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string UserName = editName;
            string Name = e.NewValues[0].ToString();
            string Age = e.NewValues[1].ToString();
            string DOB = e.NewValues[2].ToString();
            string Address = e.NewValues[3].ToString();
            string Email = e.NewValues[4].ToString();
            string PhoneNumber = e.NewValues[5].ToString();
            GridViewUser.EditIndex = -1;
            
            SqlConnection con = new SqlConnection(CS);
            SqlDataAdapter da = new SqlDataAdapter("spUpdateUser", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter userName = new SqlParameter("@UserName", UserName);
            SqlParameter name = new SqlParameter("@Name", Name);
            SqlParameter age = new SqlParameter("@Age", Age);
            SqlParameter dob = new SqlParameter("@DOB", DOB);
            SqlParameter address = new SqlParameter("@Address", Address);
            SqlParameter email = new SqlParameter("@Email", Email);
            SqlParameter phoneNo = new SqlParameter("@PhoneNumber", PhoneNumber);

            da.SelectCommand.Parameters.Add(userName);
            da.SelectCommand.Parameters.Add(name);
            da.SelectCommand.Parameters.Add(age);
            da.SelectCommand.Parameters.Add(dob);
            da.SelectCommand.Parameters.Add(address);
            da.SelectCommand.Parameters.Add(email);
            da.SelectCommand.Parameters.Add(phoneNo);

            con.Open();
            da.SelectCommand.ExecuteScalar();
            con.Close();
            BindData();
        }
        protected void GridViewUser_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Control control = e.Row.Cells[7].Controls[0];
                if (control is LinkButton)
                {
                    ((LinkButton)control).OnClientClick =
                      "return confirm('Are you sure you want to delete? This cannot be undone.');";
                }
            }
        }

    }
}