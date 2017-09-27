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
    /// <summary>
    /// 
    /// </summary>
    public partial class ViewUserDetails : System.Web.UI.Page
    {
        // Load connection string from web.config file
        string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

        static string editName;
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if session variable is null, empty, or consists only of white-space characters.
            if (!string.IsNullOrWhiteSpace(Convert.ToString(Session["Name"])))
            {
                // Assign session variable to label in master page
                ((Site)this.Master).LblUserName = Convert.ToString(Session["Name"]);

                // Run this code the first time the page is loaded.
                if (!IsPostBack)
                {
                    // Bind data to GridView
                    BindData();
                }
            }
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Check if any row in Gridview is selected
            if (GridViewUser.SelectedRow == null)
            {
                // Hide DetailsView and print button
                DetailsViewUser.Visible = false;
                btnPrint.Visible = false;
            }
            else
            {
                // Show DetailsView and print button
                DetailsViewUser.Visible = true;
                btnPrint.Visible = true;
            }
        }
        private void BindData()
        {
            try
            {
                // Create connection to SQL Server
                using (SqlConnection con = new SqlConnection(CS))
                {
                    // Create a DataAdapter, and then provide the name of the stored procedure.
                    SqlDataAdapter da = new SqlDataAdapter("spGetUserDetailsbyUserId", con);

                    // Set the command type as StoredProcedure.
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;

                    // Create and add parameter to Parameters collection for the stored procedure.
                    da.SelectCommand.Parameters.AddWithValue("@UserId", Session["UserId"]);

                    // Create a new DataSet to hold the records.
                    DataSet DS = new DataSet();

                    // Fill the DataSet with the rows that are returned.
                    da.Fill(DS);

                    // Set the data source for the GridView as the DataSet that holds the rows.
                    GridViewUser.DataSource = DS;
                    GridViewUser.DataBind();
                }
            }
            catch (Exception ex)
            {
                ErrorMessage.Text = ex.Message;
            }
        }
        protected void GridViewUser_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Get name in the row
            editName = GridViewUser.Rows[e.NewEditIndex].Cells[0].Text;

            // Update EditIndex with the Row Index of the GridView Row to be edited.
            GridViewUser.EditIndex = e.NewEditIndex;

            // Bind data to GridView
            BindData();
        }
        protected void GridViewUser_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                GridViewUser.EditIndex = -1;

                // Create connection to SQL Server
                using (SqlConnection con = new SqlConnection(CS))
                {
                    // Create a DataAdapter, and then provide the name of the stored procedure.
                    SqlDataAdapter da = new SqlDataAdapter("spUpdateUser", con);

                    // Set the command type as StoredProcedure.
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;

                    // Create and add parameters to Parameters collection for the stored procedure.
                    da.SelectCommand.Parameters.AddWithValue("@UserName", editName);
                    da.SelectCommand.Parameters.AddWithValue("@Name", e.NewValues[0].ToString());
                    da.SelectCommand.Parameters.AddWithValue("@Age", e.NewValues[1].ToString());
                    da.SelectCommand.Parameters.AddWithValue("@DOB", e.NewValues[2].ToString());
                    da.SelectCommand.Parameters.AddWithValue("@Address", e.NewValues[3].ToString());
                    da.SelectCommand.Parameters.AddWithValue("@Email", e.NewValues[4].ToString());
                    da.SelectCommand.Parameters.AddWithValue("@PhoneNumber", e.NewValues[5].ToString());

                    // Open the connection
                    con.Open();

                    // Run the SQL statement
                    da.SelectCommand.ExecuteScalar();
                }

                // Bind data to GridView
                BindData();
            }
            catch (Exception ex)
            {
                ErrorMessage.Text = ex.Message;

            }
        }
        protected void GridViewUser_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            // Set EditIndex to - 1 and the GridView is populated with data.
            GridViewUser.EditIndex = -1;

            // Bind data to GridView
            BindData();
        }
        protected void GridViewUser_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                // Get user name in the row to be deleted 
                string name = GridViewUser.Rows[e.RowIndex].Cells[0].Text;

                // Create connection to SQL Server
                using (SqlConnection con = new SqlConnection(CS))
                {
                    //Create a DataAdapter, and then provide the name of the stored procedure.
                    SqlDataAdapter da = new SqlDataAdapter("spDeleteUser", con);

                    //Set the command type as StoredProcedure.
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;

                    //Create and add a parameter to Parameters collection for the stored procedure.
                    da.SelectCommand.Parameters.AddWithValue("@Name", name);

                    // Open the connection
                    con.Open();

                    // Run the SQL statement
                    da.SelectCommand.ExecuteScalar();

                    // Bind data to GridView
                    BindData();
                }
            }
            catch (Exception ex)
            {
                ErrorMessage.Text = ex.Message;
            }
        }
        protected void GridViewUser_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                // Check if delete button is clicked
                if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != GridViewUser.EditIndex)
                {
                    Control control = e.Row.Cells[7].Controls[0];
                    if (control is LinkButton)
                    {
                        // Run javascript on client side click to display confirmation message
                        ((LinkButton)control).OnClientClick = "return confirm('Are you sure you want to delete? This cannot be undone.');";
                    }
                }

            }
            catch (Exception ex)
            {
                ErrorMessage.Text = ex.Message;

            }
        }
    }
}