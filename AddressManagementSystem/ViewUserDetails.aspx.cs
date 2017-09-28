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

        #region Page Load
        /// <summary>
        ///     Assign session variable to label in master page
        ///     Bind data to Grid View on page load
        /// </summary>
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
        #endregion

        #region Page PreRender
        /// <summary>
        ///     Show DetailsView if any row is selected
        ///     Hide DetailsView if no row is selected
        /// </summary>
        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Check if any row in Gridview is selected
            if (GridViewUser.SelectedRow == null)
            {
                // Hide DetailsView and print button
                DetailsViewUser.Visible = false;
                lnkBtnPrint.Visible = false;
            }
            else
            {
                // Show DetailsView and print button
                DetailsViewUser.Visible = true;
                lnkBtnPrint.Visible = true;
            }
        }
        #endregion

        #region Bind GridView
        /// <summary>
        ///     Binding data from stored procedure to Grid View
        /// </summary>
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
                    if (DS.Tables[0].Rows.Count == 0)
                    {
                        Message.Text = "No users yet......";
                    }
                    else
                    {
                        GridViewUser.DataBind();
                    } 
                }
            }
            catch (Exception ex)
            {
                ErrorMessage.Text = ex.Message;
            }
        }
        #endregion

        #region Row Editing
        /// <summary>
        ///     Get name on row to be edited
        ///     Update EditIndex of Grid View
        /// </summary>
        protected void GridViewUser_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Get name in the row
            editName = ((Label)GridViewUser.Rows[e.NewEditIndex].Cells[2].FindControl("lblName")).Text;

            // Update EditIndex with the Row Index of the GridView Row to be edited.
            GridViewUser.EditIndex = e.NewEditIndex;

            // Bind data to GridView
            BindData();
        }
        #endregion

        #region Row Updating
        /// <summary>
        ///     Set EditIndex as -1
        ///     Update row in database using stored procedure
        ///     Bind data to Grid View
        /// </summary>
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
        #endregion

        #region Row Cancel Editing
        /// <summary>
        ///     Set EditIndex to -1 
        ///     Bind data to Grid View
        /// </summary>
        protected void GridViewUser_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            // Set EditIndex to - 1
            GridViewUser.EditIndex = -1;

            // Bind data to GridView
            BindData();
        }
        #endregion

        #region Deleting Row
        /// <summary>
        ///     Get name in the row to be deleted
        ///     Delete row from database using stored procedure
        ///     Bind Data to Grid View
        /// </summary>
        protected void GridViewUser_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                // Get user name in the row to be deleted 
                string name = ((Label)GridViewUser.Rows[e.RowIndex].Cells[2].FindControl("lblName")).Text;
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
        #endregion

        #region Row Data Bound
        /// <summary>
        ///     Deteremine whether delete button is clicked
        ///     Run javascript to display confirmation message
        /// </summary>
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
        #endregion

        #region Sorting Rows
        /// <summary>
        /// 
        /// </summary>
        protected void GridViewUser_Sorting(object sender, GridViewSortEventArgs e)
        {
            //Specify the direction in which to sort a list of items as ascending
            SortDirection sortDirection = SortDirection.Ascending;
            string sortField = string.Empty;

            SortGridview((GridView)sender, e, out sortDirection, out sortField);

            string strSortDirection = sortDirection == SortDirection.Ascending ? "ASC" : "DESC";

            // Create connection to SQL Server
            using (SqlConnection con = new SqlConnection(CS))
            {
                //Create a DataAdapter, and then provide the name of the stored procedure.
                SqlDataAdapter da = new SqlDataAdapter("spSortGridViewByField", con);

                //Set the command type as StoredProcedure.
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                //Create and add a parameter to Parameters collection for the stored procedure.
                da.SelectCommand.Parameters.AddWithValue("@UserId", Convert.ToInt32(Session["UserId"]));
                da.SelectCommand.Parameters.AddWithValue("@SortExpression", e.SortExpression.ToString());
                da.SelectCommand.Parameters.AddWithValue("@SortDirection", strSortDirection);

                // Create a new DataSet to hold the records.
                DataSet DS = new DataSet();

                // Fill the DataSet with the rows that are returned.
                da.Fill(DS);

                // Set the data source for the GridView as the DataSet that holds the rows.
                GridViewUser.DataSource = DS;
                GridViewUser.DataBind();
            }
        }
        protected void GridViewUser_RowCreated(object sender, GridViewRowEventArgs e)
        {
            // Check if CurrentSortField and CurrentSortDirection is not null
            if (GridViewUser.Attributes["CurrentSortField"] != null && GridViewUser.Attributes["CurrentSortDirection"] != null)
            {
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    foreach (TableCell tableCell in e.Row.Cells)
                    {
                        if (tableCell.HasControls())
                        {
                            LinkButton sortLinkButton = null;
                            if (tableCell.Controls[0] is LinkButton)
                            {
                                sortLinkButton = (LinkButton)tableCell.Controls[0];
                            }

                            if (sortLinkButton != null && GridViewUser.Attributes["CurrentSortField"] == sortLinkButton.CommandArgument)
                            {
                                Image image = new Image();
                                // Check the Current Sort Direction
                                if (GridViewUser.Attributes["CurrentSortDirection"] == "ASC")
                                {
                                    // Set image of up arrow to image url
                                    image.ImageUrl = "~/Images/up_arrow.png";
                                    image.Width = Unit.Pixel(10);
                                }
                                else
                                {
                                    // Set image of down arrow to image url
                                    image.ImageUrl = "~/Images/down_arrow.png";
                                    image.Width = Unit.Pixel(10);
                                }
                                // Add image to column heading
                                tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                                tableCell.Controls.Add(image);
                            }
                        }
                    }
                }
            }
        }
        private void SortGridview(GridView GridViewUser, GridViewSortEventArgs e, out SortDirection sortDirection, out string sortField)
        {
            //Get field used to sort items in Grid View
            sortField = e.SortExpression;

            //Get direction in which to sort items in Grid View
            sortDirection = e.SortDirection;

            // Check if CurrentSortField and CurrentSortDirection is not null
            if (GridViewUser.Attributes["CurrentSortField"] != null && GridViewUser.Attributes["CurrentSortDirection"] != null)
            {
                //Check if CurrentSortField is equal to the field
                if (sortField == GridViewUser.Attributes["CurrentSortField"])
                {
                    //Check if CurrentSortDirection is ascending
                    if (GridViewUser.Attributes["CurrentSortDirection"] == "ASC")
                    {
                        //Specify the direction in which to sort the items as descending
                        sortDirection = SortDirection.Descending;
                    }
                    else
                    {
                        //Specify the direction in which to sort the items  as ascending
                        sortDirection = SortDirection.Ascending;
                    }
                }
                //Set CurrentSortField and CurrentSortDirection
                GridViewUser.Attributes["CurrentSortField"] = sortField;
                GridViewUser.Attributes["CurrentSortDirection"] = (sortDirection == SortDirection.Ascending ? "ASC" : "DESC");
            }
        }
        #endregion
    }
}